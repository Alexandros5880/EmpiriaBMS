using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace EmpiriaBMS.Core.Repositories;

public class DeliverableRepo : Repository<DeliverableDto, Deliverable>
{
    public DeliverableRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public new async Task<DeliverableDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var dr = await _context
                             .Set<Deliverable>()
                             .Where(r => !r.IsDeleted)
                             .Include(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(d => d.Type)
                             .Include(d => d.Discipline)
                             .ThenInclude(dis => dis.Project)
                             .Include(o => o.Discipline)
                             .ThenInclude(d => d.Type)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<DeliverableDto>(dr);
        }
    }

    public new async Task<ICollection<DeliverableDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Deliverable> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Deliverable>()
                                    .Where(r => !r.IsDeleted)
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Include(o => o.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Deliverable>, List<DeliverableDto>>(drs);
            }


            drs = await _context.Set<Deliverable>()
                                .Where(r => !r.IsDeleted)
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Deliverable>, List<DeliverableDto>>(drs);
        }
    }

    public new async Task<ICollection<DeliverableDto>> GetAll(
        Expression<Func<Deliverable, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    )
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Deliverable> drs;

            if (pageSize == 0 || pageIndex == 0)
            {
                drs = await _context.Set<Deliverable>()
                                    .Where(r => !r.IsDeleted)
                                    .Include(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(d => d.Type)
                                    .Include(d => d.Discipline)
                                    .ThenInclude(dis => dis.Project)
                                    .Where(expresion)
                                    .ToListAsync();

                return Mapping.Mapper.Map<List<Deliverable>, List<DeliverableDto>>(drs);
            }


            drs = await _context.Set<Deliverable>()
                                .Where(r => !r.IsDeleted)
                                .Include(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(d => d.Type)
                                .Include(d => d.Discipline)
                                .ThenInclude(dis => dis.Project)
                                .Where(expresion)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return Mapping.Mapper.Map<List<Deliverable>, List<DeliverableDto>>(drs);
        }
    }

    public async Task<long> GetMenHoursAsync(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context.Set<DailyTime>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(mh => mh.DrawingId == drwaingId)
                                 .Include(mh => mh.TimeSpan)
                                 .Select(mh => mh.TimeSpan.Hours)
                                 .SumAsync();
        }
    }

    public long GetMenHours(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return _context.Set<DailyTime>()
                           .Where(r => !r.IsDeleted)
                           .Where(mh => mh.DrawingId == drwaingId)
                           .Include(mh => mh.TimeSpan)
                           .Select(mh => mh.TimeSpan.Hours)
                           .Sum();
        }
    }

    public async Task UpdateCompleted(int projectId, int disciplineId, int drawId, float completed)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            // Update Current Drawing
            var drawing = await _context.Set<Deliverable>()
                                        .Where(r => !r.IsDeleted)
                                        .FirstOrDefaultAsync(d => d.Id == drawId);
            if (drawing == null)
                throw new NullReferenceException(nameof(drawing));
            drawing.CompletionEstimation += completed;

            // Calculate Parent Discipline Completed
            var discipline = await _context.Set<Discipline>()
                                           .Where(r => !r.IsDeleted)
                                           .Include(d => d.Deliverables)
                                           .FirstOrDefaultAsync(d => d.Id == disciplineId);
            if (discipline == null)
                throw new NullReferenceException(nameof(discipline));
            var allDrawings = discipline.Deliverables;
            var sumComplitionOfDrawings = allDrawings
                                          .Where(r => !r.IsDeleted)
                                          .Select(d => d.CompletionEstimation)
                                          .Sum();
            var drawsCounter = allDrawings.Where(r => !r.IsDeleted).Count();
            discipline.DeclaredCompleted = sumComplitionOfDrawings / drawsCounter;

            // Calculate Parent Project Complition
            var disciplines = await _context.Set<Discipline>()
                                            .Where(r => !r.IsDeleted)
                                            .Where(d => d.ProjectId == projectId)
                                            .Include(d => d.Project)
                                            .ToListAsync();
            var project = discipline.Project;
            var sumCompplitionOfDisciplines = disciplines.Select(d => d.DeclaredCompleted).Sum();
            var disciplinesCounter = disciplines.Count();
            project.DeclaredCompleted = sumCompplitionOfDisciplines / disciplinesCounter;

            await _context.SaveChangesAsync();
        }
    }

    public async Task AddTime(int userId, int projectId, int disciplineId, int drawId, TimeSpan timespan, bool isEditByAdmin = false)
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

    public async Task<ICollection<UserDto>> GetDesigners(int drwaingId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var users = await _context.Set<DeliverableEmployee>()
                                      .Where(r => !r.IsDeleted)
                                      .Where(de => de.DeliverableId == drwaingId)
                                      .Include(de => de.Employee)
                                      .Select(de => de.Employee)
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<UserDto>>(users);
        }
    }

    public async Task AddDesigners(int drawingId, ICollection<UserDto> designers)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach (var d in designers)
            {
                DeliverableEmployee de = new DeliverableEmployee()
                {
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DeliverableId = drawingId,
                    EmployeeId = d.Id
                };

                // Check If Exists
                var exists = await _context.Set<DeliverableEmployee>()
                    .Where(r => !r.IsDeleted)
                    .AnyAsync(de => de.DeliverableId == drawingId && de.EmployeeId == d.Id);
                if (exists) continue;

                await _context.Set<DeliverableEmployee>().AddAsync(de);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task RemoveDesigners(int drawingId, ICollection<int> designersIds)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var designers = await _context.Set<DeliverableEmployee>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(d => designersIds.Contains(d.EmployeeId)
                                                                        && d.DeliverableId == drawingId)
                                          .ToListAsync();

            if (designers == null)
                throw new NullReferenceException(nameof(designers));

            foreach (var designer in designers)
            {
                designer.IsDeleted = true;
                await DeleteDrawingEmployee(designer);
                //_context.Set<DrawingEmployee>().Remove(designer);
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task<DeliverableEmployee> DeleteDrawingEmployee(DeliverableEmployee entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<DeliverableEmployee>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    entry.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                return entry;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception On DrawingRepo.DeleteDrawingEmployee({Mapping.Mapper.Map<DeliverableEmployee>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException.Message}");
            return null;
        }
    }
}