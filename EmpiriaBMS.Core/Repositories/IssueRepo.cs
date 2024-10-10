using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using Document = EmpiriaBMS.Models.Models.Document;

namespace EmpiriaBMS.Core.Repositories;

public class IssueRepo : Repository<IssueDto, Issue>
{
    public IssueRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger) { }

    public async Task<IssueDto?> Get(int id)
    {
        if (id == 0)
            return null;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context.Set<Issue>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(i => i.Project)
                                  .Include(i => i.DisplayedRole)
                                  .Include(i => i.Creator)
                                  .Include(i => i.Documents)
                                  .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<IssueDto>(i);
        }
    }

    public async new Task<ICollection<IssueDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Issue> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Issue>()
                                      .Where(r => !r.IsDeleted)
                                      .Include(i => i.Project)
                                      .Include(i => i.DisplayedRole)
                                      .Include(i => i.Creator)
                                      .Include(i => i.Documents)
                                      .ToListAsync();
                return Mapping.Mapper.Map<List<IssueDto>>(items);
            }

            items = await _context.Set<Issue>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(i => i.Project)
                                  .Include(i => i.DisplayedRole)
                                  .Include(i => i.Creator)
                                  .Include(i => i.Documents)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return Mapping.Mapper.Map<List<IssueDto>>(items);
        }
    }

    public async Task<IssueDto> Add(IssueDto entity, List<DocumentDto> documents)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = DateTime.Now.ToUniversalTime();
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            List<Document> docs = Mapping.Mapper.Map<List<Document>>(documents);

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                Issue issue = Mapping.Mapper.Map<Issue>(entity);
                issue.DisplayedRole = null;
                issue.Project = null;
                issue.Creator = null;
                var result = await _context.Set<Issue>().AddAsync(issue);

                await _context.SaveChangesAsync();

                foreach (var doc in docs)
                {
                    doc.IssueId = result.Entity.Id;
                    await _context.Set<Document>().AddAsync(doc);
                }

                await _context.SaveChangesAsync();

                return Mapping.Mapper.Map<IssueDto>(result.Entity);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On IssueRepo.Add(IssueDto entity): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            throw;
        }
    }

    public async Task<IssueDto> Update(IssueDto entity, List<DocumentDto> documents)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            List<Document> docs = Mapping.Mapper.Map<List<Document>>(documents);

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Issue>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Issue>(entity));
                    await _context.SaveChangesAsync();

                    foreach (var doc in docs)
                    {
                        doc.IssueId = entity.Id;

                        var exists = _context.Set<Document>().Any(d => d.Id == doc.Id);
                        if (exists)
                        {
                            var oldDoc = await _context.Set<Document>().FirstOrDefaultAsync(d => d.Id == doc.Id);
                            if (oldDoc != null)
                            {
                                _context.Entry(oldDoc).CurrentValues.SetValues(doc);
                            }
                        }
                        else
                            await _context.Set<Document>().AddAsync(doc);
                    }

                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<IssueDto>(entry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On IssueRepo.Update(IssueDto entity, List<DocumentDto> documents): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            throw;
        }
    }

    public async new Task<IssueDto> Update(IssueDto entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Issue>().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Issue>(entity));
                    await _context.SaveChangesAsync();
                }

                return Mapping.Mapper.Map<IssueDto>(entry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On IssueRepo.Update(IssueDto entity): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            throw;
        }
    }

    public async new Task<IssueDto> Add(IssueDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<Issue>(entity);
                entry.Project = null;
                entry.DisplayedRole = null;
                entry.Creator = null;
                var result = await _context.Set<Issue>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<IssueDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On Repository.Add(Issue): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

    public async Task UpdateAll(List<IssueDto> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        if (entities.Count == 0)
            throw new Exception($"Exception: Length List<IssueDto> entities == 0.");

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach (var i in entities)
            {
                var entry = await _context.Set<Issue>().Where(r => !r.IsDeleted).FirstOrDefaultAsync(x => x.Id == i.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(Mapping.Mapper.Map<Issue>(i));
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

    public async Task<ICollection<DocumentDto>> GetMyDocuments(int issuesId)
    {
        if (issuesId == 0)
            return new List<DocumentDto>();

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var documents = await _context.Set<Document>()
                                          .Where(r => !r.IsDeleted)
                                          .Where(d => d.IssueId == issuesId)
                                          .ToListAsync();

            return Mapping.Mapper.Map<List<DocumentDto>>(documents);
        }
    }

    public async Task DeleteDocuments(List<DocumentDto> documents)
    {
        if (documents == null || documents.Count == 0)
            return;

        var docs = Mapping.Mapper.Map<List<Document>>(documents);

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            foreach (var document in docs)
            {
                await DeleteDocument(document);
            }
            //_context.Set<Document>().RemoveRange(docs);
        }
    }

    public void DeleteDocument(DocumentDto document)
    {
        if (document == null || document.Id == 0)
            return;

        var doc = Mapping.Mapper.Map<Document>(document);

        using (var _context = _dbContextFactory.CreateDbContext())
            _context.Set<Document>().Remove(doc);
    }

    public async Task AddDocument(DocumentDto document)
    {
        if (document == null || document.Id == 0)
            return;

        var doc = Mapping.Mapper.Map<Document>(document);

        using (var _context = _dbContextFactory.CreateDbContext())
            await _context.Set<Document>().AddAsync(doc);
    }

    public async Task<Document> DeleteDocument(Document entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Document>().FirstOrDefaultAsync(x => x.Id == entity.Id);
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
            _logger.LogError($"Exception On IssueRepo.DeleteDocument({Mapping.Mapper.Map<Document>(entity).GetType()}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
        }
    }

}
