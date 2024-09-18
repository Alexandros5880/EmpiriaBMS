using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
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

    public async new Task<DeliverableDto> Add(DeliverableDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<Deliverable>(entity);
                var result = await _context.Set<Deliverable>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<DeliverableDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DeliverableRepo.Add(Deliverable): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async new Task<DeliverableDto> Update(DeliverableDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await Get(entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Deliverable>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<DeliverableDto>(entry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DeliverableRepo.Update(Deliverable): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
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
        try
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
                        .AnyAsync(de => de.DeliverableId == drawingId && de.EmployeeId == d.Id);
                    
                    if (exists)
                    {
                        var deliverable = await _context.Set<DeliverableEmployee>()
                            .FirstOrDefaultAsync(de => de.DeliverableId == drawingId && de.EmployeeId == d.Id);

                        if (deliverable?.IsDeleted ?? false)
                        {
                            deliverable.IsDeleted = false;
                            await _context.SaveChangesAsync();
                        }

                        continue;
                    }

                    await _context.Set<DeliverableEmployee>().AddAsync(de);
                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DrawingRepo.AddDesigners(int drawingId, ICollection<UserDto> designers): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task RemoveDesigners(int drawingId, ICollection<int> designersIds)
    {
        try
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
                    //_context.Set<DrawingEmployee>().Remove(designer);
                }

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On DrawingRepo.RemoveDesigners(int drawingId, ICollection<int> designersIds): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
}