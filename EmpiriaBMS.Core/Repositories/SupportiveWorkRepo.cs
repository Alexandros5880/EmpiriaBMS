using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmpiriaBMS.Core.Repositories;

public class SupportiveWorkRepo : Repository<SupportiveWorkDto, SupportiveWork>, IDisposable
{
    public SupportiveWorkRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public new async Task<SupportiveWorkDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<SupportiveWork>()
                             .Where(r => !r.IsDeleted)
                             .Include(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(dis => dis.Project)
                             .Include(o => o.Discipline)
                             .ThenInclude(d => d.Type)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<SupportiveWorkDto>(dr);
        }
    }

    public new async Task<ICollection<SupportiveWorkDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<SupportiveWork> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<SupportiveWork>()
                                    .Where(r => !r.IsDeleted)
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
            }


            drs = await _context.Set<SupportiveWork>()
                                .Where(r => !r.IsDeleted)
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Include(o => o.Discipline)
                                .ThenInclude(d => d.Type)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
        }
    }

    public new async Task<ICollection<SupportiveWorkDto>> GetAll(
        Expression<Func<SupportiveWork, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<SupportiveWork> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<SupportiveWork>()
                                    .Where(r => !r.IsDeleted)
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
            }


            drs = await _context.Set<SupportiveWork>()
                                .Where(r => !r.IsDeleted)
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Include(o => o.Discipline)
                                .ThenInclude(d => d.Type)
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<SupportiveWork>, List<SupportiveWorkDto>>(drs);
        }
    }

    public async Task<long> GetMenHoursAsync(int otherId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(mh => mh.OtherId == otherId)
                                 .Include(mh => mh.TimeSpan)
                                 .Select(mh => mh.TimeSpan.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int otherId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(r => !r.IsDeleted)
                           .Where(mh => mh.OtherId == otherId)
                           .Include(mh => mh.TimeSpan)
                           .Select(mh => mh.TimeSpan.Hours)
                           .Sum();
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, int otherId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Other
            var other = await _context.Set<SupportiveWork>()
                                      .Where(r => !r.IsDeleted)
                                      .FirstOrDefaultAsync(d => d.Id == otherId);
            if (other == null)
                throw new NullReferenceException(nameof(other));
            other.CompletionEstimation += completed;

            // Calculate Parent Discipline Completed
            var discipline = await _context.Set<Discipline>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(d => d.Others)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allOthers = discipline.Others;
            var sumComplitionOfOthers = allOthers.Where(r => !r.IsDeleted)
                                                 .Select(d => d.CompletionEstimation)
                                                 .Sum();
            var othersCounter = allOthers.Where(r => !r.IsDeleted).Count();
            discipline.DeclaredCompleted = sumComplitionOfOthers / othersCounter;

            // Calculate Parent Project Complition
            var disciplines = await _context.Set<Discipline>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(d => d.ProjectId == projectId)
                                            .ToListAsync();
            var project = discipline.Project;
            var sumCompplitionOfDisciplines = disciplines.Select(d => d.DeclaredCompleted).Sum();
            var disciplinesCounter = disciplines.Count();
            project.DeclaredCompleted = sumCompplitionOfDisciplines / disciplinesCounter;

            await _context.SaveChangesAsync();
        }
    }

    public async Task AddTime(int userId, int projectId, int disciplineId, int otherId, TimeSpan timespan, bool isEditByAdmin = false)
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

    public async Task AddTimeRequest(int userId, int projectId, int disciplineId, int otherId, TimeSpan timespan, string description, bool isEditByAdmin = false)
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
}
