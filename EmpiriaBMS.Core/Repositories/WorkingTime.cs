using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class WorkingTime : IDisposable
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    protected readonly Logging.LoggerManager _logger;

    public WorkingTime(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    ) {
        _dbContextFactory = dbFactory;
        _logger = logger;
    }

    #region Time Correction Requests
    public async Task<Dictionary<DailyTimeTypes, List<DailyTime>>> GetDailyTimeRequests(DailyTimeState state)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var requests = await _context.Set<DailyTime>()
                                             .Where(r => !r.IsDeleted)
                                             .Where(r => r.State  == state)
                                             .Include(r => r.User)
                                             .Include(r => r.Deliverable)
                                             .ThenInclude(d => d.Type)
                                             .Include(r => r.SupportiveWork)
                                             .ThenInclude(sw => sw.Type)
                                             .Include(r => r.Discipline)
                                             .ThenInclude(d => d.Type)
                                             .Include(r => r.Project)
                                             .Include(r => r.Client)
                                             .Include(r => r.Offer)
                                             .ToListAsync();

                var groupedRequests = new Dictionary<DailyTimeTypes, List<DailyTime>>();

                foreach (var request in requests)
                {
                    DailyTimeTypes? key = request.Type;
                    if (key == null)
                        continue;

                    var k = (DailyTimeTypes)key;
                    if (!groupedRequests.ContainsKey(k))
                    {
                        groupedRequests[k] = new List<DailyTime>();
                    }
                    groupedRequests[k].Add(request);
                }

                return groupedRequests;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.GetDailyTimeRequests: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new Dictionary<DailyTimeTypes, List<DailyTime>>();
        }
    }

    public async Task<int> GetDailyTimeRequestsCount(DailyTimeState state)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                return await _context.Set<DailyTime>()
                    .Where(r => !r.IsDeleted)
                    .Where(r => r.State == state)
                    .CountAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.GetDailyTimeRequestsCount: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task ApproveDailyTimeRequest(DailyTime request, DailyTimeTypes type)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var dailyTime = request.GetDailyTime();

                TimeSpan timespan = dailyTime.ToTimeSpan();
                TimeSpan timeSpan = new TimeSpan((int)timespan.Days, (int)timespan.Hours, (int)timespan.Minutes, (int)timespan.Seconds);

                request.State = DailyTimeState.APPROVED;
                await UpdateDailyTimeRequest(request);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.ApproveDailyTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task RejectDailyTimeRequest(DailyTime request)
    {
        request.State = DailyTimeState.REJECT;
        await UpdateDailyTimeRequest(request);
    }

    public async Task<DailyTime> UpdateDailyTimeRequest(DailyTime request)
    {
        try
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<DailyTime>().FirstOrDefaultAsync(x => x.Id == request.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(request);
                    await _context.SaveChangesAsync();
                }

                var r = await GetDayliTymeRequest(request.Id);

                return r;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.UpdateDailyTimeRequest({request.GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(DailyTime)!;
        }
    }

    public async Task<DailyTime?> GetDayliTymeRequest(long id)
    {
        try
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            using (var _context = _dbContextFactory.CreateDbContext())
            {

                var i = await _context
                                 .Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .FirstOrDefaultAsync(r => r.Id == id);

                return i;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.GetDayliTymeRequest({typeof(DailyTime)}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }
    #endregion

    #region User General Time
    public async Task<DailyTime> AddUnusedTime(
        long userId,
        DateTime date,
        TimeSpan ts,
        bool isEditByAdmin = false
    ) {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            if (date > DateTime.Now)
                throw new ArgumentException(nameof(date));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                // Check if time is betoween 12 - 5 at morning
                TimeSpan start = new TimeSpan(12, 0, 0);
                TimeSpan end = new TimeSpan(5, 0, 0);
                TimeSpan now = date.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // Get Yesterday DailyHour
                    var yesterdayDate = date.AddDays(-1);
                    var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(u => u.Type == DailyTimeTypes.GeneralUserTime)
                                                       .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                    if (yesterdayDailyHour == null)
                        throw new NullReferenceException(nameof(yesterdayDailyHour));

                    var timespan = yesterdayDailyHour.ToTimeSpan();
                    var newHours = timespan.Hours + ts.Hours;
                    yesterdayDailyHour.Days = timespan.Days;
                    yesterdayDailyHour.Hours = newHours;
                    yesterdayDailyHour.Minutes = timespan.Minutes;
                    yesterdayDailyHour.Seconds = timespan.Seconds;

                    yesterdayDailyHour.IsEditByAdmin = isEditByAdmin;

                    await _context.SaveChangesAsync();

                    return yesterdayDailyHour;
                }
                else
                {
                    var result = await _context.Set<DailyTime>()
                                               .AddAsync(
                        new DailyTime
                        {
                            Type = DailyTimeTypes.UnusedTime,
                            UserId = userId,
                            Date = date,
                            Days = ts.Days,
                            Hours = ts.Hours,
                            Minutes = ts.Minutes,
                            Seconds = ts.Seconds,
                            IsEditByAdmin = isEditByAdmin,
                        }
                    );

                    await _context.SaveChangesAsync();

                    return result.Entity;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddUnusedTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(DailyTime)!;
        }
    }

    public async Task<DailyTime> AddDailyTime(
        long userId, 
        DateTime date, 
        TimeSpan ts, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            if (date > DateTime.Now)
                throw new ArgumentException(nameof(date));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                // Check if time is betoween 12 - 5 at morning
                TimeSpan start = new TimeSpan(12, 0, 0);
                TimeSpan end = new TimeSpan(5, 0, 0);
                TimeSpan now = date.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // Get Yesterday DailyHour
                    var yesterdayDate = date.AddDays(-1);
                    var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(u => u.Type == DailyTimeTypes.GeneralUserTime)
                                                       .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                    if (yesterdayDailyHour == null)
                        throw new NullReferenceException(nameof(yesterdayDailyHour));

                    var timespan = yesterdayDailyHour.ToTimeSpan();
                    var newHours = timespan.Hours + ts.Hours;
                    yesterdayDailyHour.Days = timespan.Days;
                    yesterdayDailyHour.Hours = newHours;
                    yesterdayDailyHour.Minutes = timespan.Minutes;
                    yesterdayDailyHour.Seconds = timespan.Seconds;

                    yesterdayDailyHour.IsEditByAdmin = isEditByAdmin;

                    await _context.SaveChangesAsync();

                    return yesterdayDailyHour;
                }
                else
                {
                    var result = await _context.Set<DailyTime>()
                                               .AddAsync(
                        new DailyTime
                        {
                            Type = DailyTimeTypes.GeneralUserTime,
                            UserId = userId,
                            Date = date,
                            Days = ts.Days,
                            Hours = ts.Hours,
                            Minutes = ts.Minutes,
                            Seconds = ts.Seconds,
                            IsEditByAdmin = isEditByAdmin,
                        }
                    );

                    await _context.SaveChangesAsync();

                    return result.Entity;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddDailyTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(DailyTime)!;
        }
    }

    public async Task AddDailyTimeRequest(
        long userId, 
        DateTime date, 
        TimeSpan timespan, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        Type = DailyTimeTypes.GeneralUserTime,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        UserId = userId,
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddDailyTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<DailyTime> AddPersonalTime(
        long userId, 
        DateTime date, 
        TimeSpan ts, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            if (date > DateTime.Now)
                throw new ArgumentException(nameof(date));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                // Check if time is betoween 12 - 5 at morning
                TimeSpan start = new TimeSpan(12, 0, 0);
                TimeSpan end = new TimeSpan(5, 0, 0);
                TimeSpan now = date.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // Get Yesterday DailyHour
                    var yesterdayDate = date.AddDays(-1);
                    var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(u => u.Type == DailyTimeTypes.PersonalTime)
                                                       .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);
                    yesterdayDailyHour.IsEditByAdmin = isEditByAdmin;

                    if (yesterdayDailyHour == null)
                        throw new NullReferenceException(nameof(yesterdayDailyHour));

                    var timespan = yesterdayDailyHour.ToTimeSpan();
                    var newHours = timespan.Hours + ts.Hours;
                    yesterdayDailyHour.Days = timespan.Days;
                    yesterdayDailyHour.Hours = newHours;
                    yesterdayDailyHour.Minutes = timespan.Minutes;
                    yesterdayDailyHour.Seconds = timespan.Seconds;

                    await _context.SaveChangesAsync();

                    return yesterdayDailyHour;
                }
                else
                {
                    var result = await _context.Set<DailyTime>()
                    .AddAsync(
                        new DailyTime
                        {
                            Type = DailyTimeTypes.PersonalTime,
                            UserId = userId,
                            Date = date,
                            Days = ts.Days,
                            Hours = ts.Hours,
                            Minutes = ts.Minutes,
                            Seconds = ts.Seconds,
                            IsEditByAdmin = isEditByAdmin,
                        }
                    );

                    await _context.SaveChangesAsync();

                    return result.Entity;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddPersonalTime(: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(DailyTime)!;
        }
    }

    public async Task AddPersonaTimeRequest(
        long userId, 
        DateTime date, 
        TimeSpan timespan, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        Type = DailyTimeTypes.PersonalTime,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        UserId = userId,
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddPersonaTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<DailyTime> AddTraningTime(
        long userId, 
        DateTime date, 
        TimeSpan ts,
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            if (date > DateTime.Now)
                throw new ArgumentException(nameof(date));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                // Check if time is betoween 12 - 5 at morning
                TimeSpan start = new TimeSpan(12, 0, 0);
                TimeSpan end = new TimeSpan(5, 0, 0);
                TimeSpan now = date.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // Get Yesterday DailyHour
                    var yesterdayDate = date.AddDays(-1);
                    var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(u => u.Type == DailyTimeTypes.TrainingTime)
                                                       .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                    if (yesterdayDailyHour == null)
                        throw new NullReferenceException(nameof(yesterdayDailyHour));

                    var timespan = yesterdayDailyHour.ToTimeSpan();
                    var newHours = timespan.Hours + ts.Hours;
                    yesterdayDailyHour.Days = timespan.Days;
                    yesterdayDailyHour.Hours = newHours;
                    yesterdayDailyHour.Minutes = timespan.Minutes;
                    yesterdayDailyHour.Seconds = timespan.Seconds;


                    await _context.SaveChangesAsync();

                    return yesterdayDailyHour;
                }
                else
                {
                    var result = await _context.Set<DailyTime>()
                    .AddAsync(
                        new DailyTime
                        {
                            Type = DailyTimeTypes.TrainingTime,
                            UserId = userId,
                            Date = date,
                            Days = ts.Days,
                            Hours = ts.Hours,
                            Minutes = ts.Minutes,
                            Seconds = ts.Seconds,
                            IsEditByAdmin = isEditByAdmin,
                        }
                    );

                    await _context.SaveChangesAsync();

                    return result.Entity;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddTraningTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(DailyTime)!;
        }
    }

    public async Task AddTraningTimeRequest(
        long userId, 
        DateTime date, 
        TimeSpan timespan, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        Type = DailyTimeTypes.TrainingTime,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        UserId = userId,
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddTraningTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<DailyTime> AddCorporateEventTime(
        long userId, 
        DateTime date, 
        TimeSpan ts, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            if (date > DateTime.Now)
                throw new ArgumentException(nameof(date));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                // Check if time is betoween 12 - 5 at morning
                TimeSpan start = new TimeSpan(12, 0, 0);
                TimeSpan end = new TimeSpan(5, 0, 0);
                TimeSpan now = date.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // Get Yesterday DailyHour
                    var yesterdayDate = date.AddDays(-1);
                    var yesterdayDailyHour = await _context.Set<DailyTime>()
                                                       .Where(r => !r.IsDeleted)
                                                       .Where(u => u.Type == DailyTimeTypes.CorporateTime)
                                                       .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);
                    yesterdayDailyHour.IsEditByAdmin = isEditByAdmin;

                    if (yesterdayDailyHour == null)
                        throw new NullReferenceException(nameof(yesterdayDailyHour));

                    var timespan = yesterdayDailyHour.ToTimeSpan();
                    var newHours = timespan.Hours + ts.Hours;
                    yesterdayDailyHour.Days = timespan.Days;
                    yesterdayDailyHour.Hours = newHours;
                    yesterdayDailyHour.Minutes = timespan.Minutes;
                    yesterdayDailyHour.Seconds = timespan.Seconds;


                    await _context.SaveChangesAsync();

                    return yesterdayDailyHour;
                }
                else
                {
                    var result = await _context.Set<DailyTime>()
                    .AddAsync(
                        new DailyTime
                        {
                            Type = DailyTimeTypes.CorporateTime,
                            UserId = userId,
                            Date = date,
                            Days = ts.Days,
                            Hours = ts.Hours,
                            Minutes = ts.Minutes,
                            Seconds = ts.Seconds,
                            IsEditByAdmin = isEditByAdmin,
                        }
                    );

                    await _context.SaveChangesAsync();

                    return result.Entity;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddCorporateEventTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(DailyTime)!;
        }
    }

    public async Task AddCorporateEventTimeRequest(
        long userId, 
        DateTime date, 
        TimeSpan timespan, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            if (userId == 0)
                throw new ArgumentException(nameof(userId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        Type = DailyTimeTypes.CorporateTime,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        UserId = userId,
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.AddCorporateEventTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Client Time
    public async Task ClientAddTime(
        long userId, 
        long clientId, 
        TimeSpan timespan, 
        DateTime date, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ClientId = clientId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        State = DailyTimeState.NOREQUEST,
                        Type = DailyTimeTypes.ClientTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.ClientAddTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task ClientAddTimeRequest(
        long userId, 
        long clientId, 
        TimeSpan timespan, 
        DateTime date, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ClientId = clientId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        Type = DailyTimeTypes.ClientTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.ClientAddTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Project Time
    public async Task ProjectAddTime(
        long userId, 
        long projectId, 
        TimeSpan timespan, 
        DateTime date, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        State = DailyTimeState.NOREQUEST,
                        Type = DailyTimeTypes.ProjectTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.ProjectAddTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task ProjectAddTimeRequest(
        long userId, 
        long projectId, 
        TimeSpan timespan, 
        DateTime date, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        Type = DailyTimeTypes.ProjectTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.ProjectAddTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Offer Time
    public async Task OfferAddTime(
        long userId, 
        long offerId, 
        TimeSpan timespan, 
        DateTime date, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        OfferId = offerId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        State = DailyTimeState.NOREQUEST,
                        Type = DailyTimeTypes.OfferTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.OfferAddTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task OfferAddTimeRequest(
        long userId, 
        long offerId, 
        TimeSpan timespan, 
        DateTime date, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        OfferId = offerId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        Type = DailyTimeTypes.OfferTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.OfferAddTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Discipline Time
    public async Task DisciplineAddTime(
        long userId, 
        long projectId, 
        long disciplineId, 
        TimeSpan timespan, 
        DateTime date, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        DisciplineId = disciplineId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        State = DailyTimeState.NOREQUEST,
                        Type = DailyTimeTypes.DisciplineTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.DisciplineAddTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task DisciplineAddTimeRequest(
        long userId, 
        long projectId, 
        long disciplineId, 
        TimeSpan timespan, 
        DateTime date, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        DisciplineId = disciplineId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        Type = DailyTimeTypes.DisciplineTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.DisciplineAddTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Deliverable Time
    public async Task DeliverableAddTime(
        long userId, 
        long projectId, 
        long disciplineId, 
        long drawId, 
        TimeSpan timespan, 
        DateTime date, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        DisciplineId = disciplineId,
                        DeliverableId = drawId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        State = DailyTimeState.NOREQUEST,
                        Type = DailyTimeTypes.DeliverableTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.DeliverableAddTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task DeliverableAddTimeRequest(
        long userId, 
        long projectId, 
        long disciplineId, 
        long drawId, 
        TimeSpan timespan, 
        DateTime date, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        DisciplineId = disciplineId,
                        DeliverableId = drawId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        Type = DailyTimeTypes.DeliverableTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.DeliverableAddTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region SupportiveWork Time
    public async Task SupportiveWorkAddTime(
        long userId, 
        long projectId, 
        long disciplineId, 
        long otherId, 
        TimeSpan timespan, 
        DateTime date, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        DisciplineId = disciplineId,
                        SupportiveWorkId = otherId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        State = DailyTimeState.NOREQUEST,
                        Type = DailyTimeTypes.SupportiveWorkTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.SupportiveWorkAddTime: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task SupportiveWorkAddTimeRequest(
        long userId, 
        long projectId, 
        long disciplineId, 
        long otherId, 
        TimeSpan timespan, 
        DateTime date, 
        string description, 
        bool isEditByAdmin = false
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
                for (int i = timeSpans.Count() - 1; i >= 0; i--)
                {
                    DailyTime time = new DailyTime()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        Date = date.AddDays(-i),
                        UserId = userId,
                        ProjectId = projectId,
                        DisciplineId = disciplineId,
                        SupportiveWorkId = otherId,
                        Days = timeSpans[i].Days,
                        Hours = timeSpans[i].Hours,
                        Minutes = timeSpans[i].Minutes,
                        Seconds = timeSpans[i].Seconds,
                        IsEditByAdmin = isEditByAdmin,
                        Description = description,
                        State = DailyTimeState.AWAITING,
                        Type = DailyTimeTypes.SupportiveWorkTime
                    };
                    await _context.Set<DailyTime>().AddAsync(time);
                }

                // Save Changes
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On WorkingTime.SupportiveWorkAddTimeRequest: {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

}
