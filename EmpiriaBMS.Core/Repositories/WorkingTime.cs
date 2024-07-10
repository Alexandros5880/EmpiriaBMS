using EmpiriaBMS.Core.Hellpers;
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
    )
    {
        _dbContextFactory = dbFactory;
        _logger = logger;
    }

    #region Get Time Correction Requests
    public async Task<Dictionary<Type, List<DailyTimeRequest>>> GetDailyTimeRequests()
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var requests = await _context.Set<DailyTimeRequest>()
                                         .Where(r => !r.IsDeleted && !r.IsClosed)
                                         .Include(r => r.TimeSpan)
                                         .Include(r => r.DailyUser)
                                         .Include(r => r.PersonalUser)
                                         .Include(r => r.TrainingUser)
                                         .Include(r => r.CorporateUser)
                                         .Include(r => r.Drawing)
                                         .Include(r => r.Other)
                                         .Include(r => r.Discipline)
                                         .Include(r => r.Project)
                                         .Include(r => r.Lead)
                                         .Include(r => r.Offer)
                                         .ToListAsync();

            var groupedRequests = new Dictionary<Type, List<DailyTimeRequest>>();

            foreach (var request in requests)
            {
                Type key = await _getGroupingKey(request, _context);
                if (key == null)
                    continue;

                if (!groupedRequests.ContainsKey(key))
                {
                    groupedRequests[key] = new List<DailyTimeRequest>();
                }
                groupedRequests[key].Add(request);
            }

            return groupedRequests;
        }
    }

    private async Task<Type?> _getGroupingKey(DailyTimeRequest request, AppDbContext _context)
    {
        // DailyUser
        if (request.DailyUserId.HasValue &&
            !request.PersonalUserId.HasValue &&
            !request.TrainingUserId.HasValue &&
            !request.CorporateUserId.HasValue &&
            !request.LeadId.HasValue &&
            !request.OfferId.HasValue &&
            !request.ProjectId.HasValue &&
            !request.DisciplineId.HasValue &&
            !request.DrawingId.HasValue &&
            !request.OtherId.HasValue)
        {
            var dailyUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == request.DailyUserId);
            return dailyUser?.GetType();
        }
        // PersonalUser
        else if (request.PersonalUserId.HasValue &&
            !request.DailyUserId.HasValue &&
            !request.TrainingUserId.HasValue &&
            !request.CorporateUserId.HasValue &&
            !request.LeadId.HasValue &&
            !request.OfferId.HasValue &&
            !request.ProjectId.HasValue &&
            !request.DisciplineId.HasValue &&
            !request.DrawingId.HasValue &&
            !request.OtherId.HasValue)
        {
            var personalUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == request.PersonalUserId);
            return personalUser?.GetType();
        }
        // TrainingUser
        else if (request.TrainingUserId.HasValue &&
            !request.DailyUserId.HasValue &&
            !request.PersonalUserId.HasValue &&
            !request.CorporateUserId.HasValue &&
            !request.LeadId.HasValue &&
            !request.OfferId.HasValue &&
            !request.ProjectId.HasValue &&
            !request.DisciplineId.HasValue &&
            !request.DrawingId.HasValue &&
            !request.OtherId.HasValue)
        {
            var trainingUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == request.TrainingUserId);
            return trainingUser?.GetType();
        }
        // CorporateUser
        else if (request.CorporateUserId.HasValue &&
            !request.DailyUserId.HasValue &&
            !request.PersonalUserId.HasValue &&
            !request.TrainingUserId.HasValue &&
            !request.LeadId.HasValue &&
            !request.OfferId.HasValue &&
            !request.ProjectId.HasValue &&
            !request.DisciplineId.HasValue &&
            !request.DrawingId.HasValue &&
            !request.OtherId.HasValue)
        {
            var corporateUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == request.CorporateUserId);
            return corporateUser?.GetType();
        }
        // Lead
        else if (request.LeadId.HasValue &&
                 request.DailyUserId.HasValue &&
                !request.PersonalUserId.HasValue &&
                !request.TrainingUserId.HasValue &&
                !request.CorporateUserId.HasValue &&
                !request.OfferId.HasValue &&
                !request.ProjectId.HasValue &&
                !request.DisciplineId.HasValue &&
                !request.DrawingId.HasValue &&
                !request.OtherId.HasValue)
        {
            var lead = await _context.Set<Lead>().FirstOrDefaultAsync(u => u.Id == request.LeadId);
            return lead?.GetType();
        }
        // Offer
        else if (request.OfferId.HasValue &&
                 request.DailyUserId.HasValue &&
                !request.PersonalUserId.HasValue &&
                !request.TrainingUserId.HasValue &&
                !request.CorporateUserId.HasValue &&
                !request.LeadId.HasValue &&
                !request.ProjectId.HasValue &&
                !request.DisciplineId.HasValue &&
                !request.DrawingId.HasValue &&
                !request.OtherId.HasValue)
        {
            var offer = await _context.Set<Offer>().FirstOrDefaultAsync(u => u.Id == request.OfferId);
            return offer?.GetType();
        }
        // Project
        else if (request.ProjectId.HasValue &&
                 request.DailyUserId.HasValue &&
                !request.PersonalUserId.HasValue &&
                !request.TrainingUserId.HasValue &&
                !request.CorporateUserId.HasValue &&
                !request.LeadId.HasValue &&
                !request.OfferId.HasValue &&
                !request.DisciplineId.HasValue &&
                !request.DrawingId.HasValue &&
                !request.OtherId.HasValue)
        {
            var project = await _context.Set<Project>().FirstOrDefaultAsync(u => u.Id == request.ProjectId);
            return project?.GetType();
        }
        // Discipline
        else if (request.DisciplineId.HasValue &&
                 request.DailyUserId.HasValue &&
                 request.ProjectId.HasValue &&
                 request.DisciplineId.HasValue &&
                !request.PersonalUserId.HasValue &&
                !request.TrainingUserId.HasValue &&
                !request.CorporateUserId.HasValue &&
                !request.LeadId.HasValue &&
                !request.OfferId.HasValue &&
                !request.DrawingId.HasValue &&
                !request.OtherId.HasValue)
        {
            var discipline = await _context.Set<Discipline>().FirstOrDefaultAsync(u => u.Id == request.DisciplineId);
            return discipline?.GetType();
        }
        // Drawing
        else if (request.DrawingId.HasValue &&
                 request.DisciplineId.HasValue &&
                 request.ProjectId.HasValue &&
                 request.DailyUserId.HasValue &&
                !request.PersonalUserId.HasValue &&
                !request.TrainingUserId.HasValue &&
                !request.CorporateUserId.HasValue &&
                !request.LeadId.HasValue &&
                !request.OfferId.HasValue &&
                !request.OtherId.HasValue)
        {
            var deliverable = await _context.Set<Deliverable>().FirstOrDefaultAsync(u => u.Id == request.DrawingId);
            return deliverable?.GetType();
        }
        // Other
        else if (request.OtherId.HasValue &&
                 request.DisciplineId.HasValue &&
                 request.ProjectId.HasValue &&
                 request.DailyUserId.HasValue &&
                !request.PersonalUserId.HasValue &&
                !request.TrainingUserId.HasValue &&
                !request.CorporateUserId.HasValue &&
                !request.LeadId.HasValue &&
                !request.OfferId.HasValue &&
                !request.DrawingId.HasValue)
        {
            var supportiveWork = await _context.Set<SupportiveWork>().FirstOrDefaultAsync(u => u.Id == request.OtherId);
            return supportiveWork?.GetType();
        }

        return null;
    }
    #endregion


    #region User General Time
    public async Task<DailyTime> AddDailyTime(int userId, DateTime date, TimeSpan ts, bool isEditByAdmin = false)
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
                                                   .Where(u => u.DailyUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);
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
                        DailyUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        ),
                        IsEditByAdmin = isEditByAdmin,
                    }
                );

                await _context.SaveChangesAsync();

                return result.Entity;
            }
        }
    }

    public async Task AddDailyTimeRequest(int userId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task<DailyTime> AddPersonalTime(int userId, DateTime date, TimeSpan ts, bool isEditByAdmin = false)
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
                                                   .Where(u => u.PersonalUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);
                yesterdayDailyHour.IsEditByAdmin = isEditByAdmin;

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);

                await _context.SaveChangesAsync();

                return yesterdayDailyHour;
            }
            else
            {
                var result = await _context.Set<DailyTime>()
                .AddAsync(
                    new DailyTime
                    {
                        PersonalUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        ),
                        IsEditByAdmin = isEditByAdmin,
                    }
                );

                await _context.SaveChangesAsync();

                return result.Entity;
            }
        }
    }

    public async Task AddPersonaTimeRequest(int userId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    PersonalUserId = userId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task<DailyTime> AddTraningTime(int userId, DateTime date, TimeSpan ts, bool isEditByAdmin = false)
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
                                                   .Where(u => u.TrainingUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);
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
                        TrainingUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        ),
                        IsEditByAdmin = isEditByAdmin,
                    }
                );

                await _context.SaveChangesAsync();

                return result.Entity;
            }
        }
    }

    public async Task AddTraningTimeRequest(int userId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    TrainingUserId = userId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task<DailyTime> AddCorporateEventTime(int userId, DateTime date, TimeSpan ts, bool isEditByAdmin = false)
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
                                                   .Where(u => u.CorporateUserId == userId)
                                                   .FirstOrDefaultAsync(u => u.Date.CompareTo(yesterdayDate) == 0);
                yesterdayDailyHour.IsEditByAdmin = isEditByAdmin;

                if (yesterdayDailyHour == null)
                    throw new NullReferenceException(nameof(yesterdayDailyHour));

                var timespan = yesterdayDailyHour.TimeSpan;
                var newHours = timespan.Hours + ts.Hours;
                yesterdayDailyHour.TimeSpan = new Timespan(
                    timespan.Days, newHours, timespan.Minutes, timespan.Seconds);

                await _context.SaveChangesAsync();

                return yesterdayDailyHour;
            }
            else
            {
                var result = await _context.Set<DailyTime>()
                .AddAsync(
                    new DailyTime
                    {
                        CorporateUserId = userId,
                        Date = date,
                        TimeSpan = new Timespan(
                            ts.Days,
                            ts.Hours,
                            ts.Minutes,
                            ts.Seconds
                        ),
                        IsEditByAdmin = isEditByAdmin,
                    }
                );

                await _context.SaveChangesAsync();

                return result.Entity;
            }
        }
    }

    public async Task AddCorporateEventTimeRequest(int userId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        if (userId == 0)
            throw new ArgumentException(nameof(userId));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    CorporateUserId = userId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region Lead Time
    public async Task LeadAddTime(int userId, int ledId, TimeSpan timespan, bool isEditByAdmin = false)
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
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    LeadId = ledId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task LeadAddTimeRequest(int userId, int ledId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    LeadId = ledId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region Project Time
    public async Task ProjectAddTime(int userId, int projectId, TimeSpan timespan, bool isEditByAdmin = false)
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
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Where(r => !r.IsDeleted)
                                        .Include(p => p.DailyTime)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectsTimes = project.DailyTime.Select(dt => dt.TimeSpan).ToList();
            var projectMenHours = projectsTimes.Select(t => t.Hours).Sum();

            decimal divitionProResult = Convert.ToDecimal(projectMenHours) / Convert.ToDecimal(project.EstimatedHours);
            project.EstimatedCompleted = (float)divitionProResult * 100;

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task ProjectAddTimeRequest(int userId, int projectId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region Offer Time
    public async Task OfferAddTime(int userId, int offerId, TimeSpan timespan, bool isEditByAdmin = false)
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
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    OfferId = offerId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task OfferAddTimeRequest(int userId, int offerId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    OfferId = offerId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region Discipline Time
    public async Task DisciplineAddTime(int userId, int projectId, int disciplineId, TimeSpan timespan, bool isEditByAdmin = false)
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
                    Date = DateTime.Now,
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(p => p.DailyTime)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = discipline.DailyTime.Select(h => h.TimeSpan.Hours).Sum();

            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours) / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Where(r => !r.IsDeleted)
                                        .Include(p => p.DailyTime)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectsTimes = project.DailyTime.Select(dt => dt.TimeSpan).ToList();
            var projectMenHours = projectsTimes.Select(t => t.Hours).Sum();

            decimal divitionProResult = Convert.ToDecimal(projectMenHours) / Convert.ToDecimal(project.EstimatedHours);
            project.EstimatedCompleted = (float)divitionProResult * 100;

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task DisciplineAddTimeRequest(int userId, int projectId, int disciplineId, int otherId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now,
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region Deliverable Time
    public async Task DeliverableAddTime(int userId, int projectId, int disciplineId, int drawId, TimeSpan timespan, bool isEditByAdmin = false)
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
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    DrawingId = drawId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(p => p.DailyTime)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = await _context.Set<DailyTime>()
                                                   .Where(r => !r.IsDeleted)
                                                   .Where(d => d.DisciplineId == disciplineId)
                                                   .Select(d => d.TimeSpan.Hours)
                                                   .SumAsync();
            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours)
                                                    / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Where(r => !r.IsDeleted)
                                        .Include(p => p.DailyTime)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectsTimes = project.DailyTime.Where(r => !r.IsDeleted).Select(dt => dt.TimeSpan).ToList();
            var projectMenHours = await _context.Set<DailyTime>()
                                                .Where(r => !r.IsDeleted)
                                                .Where(d => d.ProjectId == projectId)
                                                .Select(d => d.TimeSpan.Hours)
                                                .SumAsync();
            decimal divitionProResult = Convert.ToDecimal(projectMenHours)
                                                    / Convert.ToDecimal(project.EstimatedHours);
            project.EstimatedCompleted = (float)divitionProResult * 100;

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeliverableAddTimeRequest(int userId, int projectId, int disciplineId, int drawId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    DrawingId = drawId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region SupportiveWork Time
    public async Task SupportiveWorkAddTime(int userId, int projectId, int disciplineId, int otherId, TimeSpan timespan, bool isEditByAdmin = false)
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
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    OtherId = otherId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin
                };
                await _context.Set<DailyTime>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();

            // Get Discipline && Calculate Estimated Hours
            var discipline = await _context.Set<Discipline>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(p => p.DailyTime)
                                           .FirstOrDefaultAsync(p => p.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var disciplineMenHours = await _context.Set<DailyTime>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(d => d.DisciplineId == disciplineId)
                                          .Select(d => d.TimeSpan.Hours)
                                          .SumAsync();
            decimal divitionDiscResult = Convert.ToDecimal(disciplineMenHours) / Convert.ToDecimal(discipline.EstimatedHours);
            discipline.EstimatedCompleted = (float)divitionDiscResult * 100;

            // Get Project && Calculate Estimated Hours
            var project = await _context.Set<Project>()
                                        .Where(r => !r.IsDeleted)
                                        .Include(p => p.DailyTime)
                                        .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
                throw new NullReferenceException(nameof(project));
            var projectsTimes = project.DailyTime.Where(r => !r.IsDeleted).Select(dt => dt.TimeSpan).ToList();
            var projectMenHours = await _context.Set<DailyTime>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(d => d.ProjectId == projectId)
                                          .Select(d => d.TimeSpan.Hours)
                                          .SumAsync();
            decimal divitionProResult = Convert.ToDecimal(projectMenHours) / Convert.ToDecimal(project.EstimatedHours);
            project.EstimatedCompleted = (float)divitionProResult * 100;

            // Save Changes
            await _context.SaveChangesAsync();
        }
    }

    public async Task SupportiveWorkAddTimeRequest(int userId, int projectId, int disciplineId, int otherId, TimeSpan timespan, string description, bool isEditByAdmin = false)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            TimeSpan[] timeSpans = TimeHelper.SplitTimeSpanToDays(timespan);
            for (int i = timeSpans.Count() - 1; i >= 0; i--)
            {
                DailyTimeRequest time = new DailyTimeRequest()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Date = DateTime.Now.AddDays(-i),
                    DailyUserId = userId,
                    ProjectId = projectId,
                    DisciplineId = disciplineId,
                    OtherId = otherId,
                    TimeSpan = new Timespan(
                        timeSpans[i].Days,
                        timeSpans[i].Hours,
                        timeSpans[i].Minutes,
                        timeSpans[i].Seconds
                    ),
                    IsEditByAdmin = isEditByAdmin,
                    Description = description,
                    IsClosed = false
                };
                await _context.Set<DailyTimeRequest>().AddAsync(time);
            }

            // Save Changes
            await _context.SaveChangesAsync();
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
