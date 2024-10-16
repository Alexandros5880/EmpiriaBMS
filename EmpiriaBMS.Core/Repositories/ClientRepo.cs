using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ClientRepo : Repository<ClientDto, Client>
{
    private readonly OfferRepo _offerRepo;
    private readonly ProjectsRepo _projectRep;
    private readonly InvoiceRepo _invoiceRepo;
    private readonly UsersRepo _userRepo;
    private readonly EmailRepo _emailRepo;

    public ClientRepo(
        IDbContextFactory<AppDbContext> DbFactory,
        Logging.LoggerManager logger
    ) : base(DbFactory, logger)
    {
        _projectRep = new ProjectsRepo(DbFactory, logger);
        _offerRepo = new OfferRepo(DbFactory, logger);
        _invoiceRepo = new InvoiceRepo(DbFactory, logger);
        _userRepo = new UsersRepo(DbFactory, logger);
        _emailRepo = new EmailRepo(DbFactory, logger);
    }

    public async new Task<ClientDto> Add(ClientDto entity, bool update = false)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = update ? DateTime.Now.ToUniversalTime() : entity.CreatedDate;
            entity.LastUpdatedDate = DateTime.Now.ToUniversalTime();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = Mapping.Mapper.Map<Client>(entity);
                var result = await _context.Set<Client>().AddAsync(entry);
                await _context.SaveChangesAsync();

                var id = result.Entity?.Id;
                if (id == null)
                    throw new NullReferenceException(nameof(id));

                var endry = await Get((int)id);

                return Mapping.Mapper.Map<ClientDto>(endry);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.Add(Client): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ClientDto)!;
        }
    }

    public async new Task<ClientDto?> Get(long id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var i = await _context
                             .Set<Client>()
                             .Where(r => !r.IsDeleted)
                             .Include(c => c.Address)
                             .FirstOrDefaultAsync(r => r.Id == id);

            return Mapping.Mapper.Map<ClientDto>(i);
        }
    }

    public async new Task<ICollection<ClientDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Client> items;
            if (pageSize == 0 || pageIndex == 0)
            {
                items = await _context.Set<Client>()
                                      .Where(r => !r.IsDeleted)
                                      .Include(c => c.Address)
                                      .ToListAsync();
                return Mapping.Mapper.Map<List<ClientDto>>(items);
            }

            items = await _context.Set<Client>()
                                  .Where(r => !r.IsDeleted)
                                  .Include(c => c.Address)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return Mapping.Mapper.Map<List<ClientDto>>(items);
        }
    }

    public async Task<ICollection<ClientDto>> GetByResult(ClientResult result = ClientResult.WAITING)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Client> items = await _context.Set<Client>()
                .Where(r => !r.IsDeleted)
                .Where(l => l.Result == result)
                .Include(l => l.Address)
                .ToListAsync();

            return Mapping.Mapper.Map<List<ClientDto>>(items);
        }
    }

    #region Users
    public async Task<ICollection<UserDto>> GetUsers(long clientId)
    {
        try
        {
            if (clientId == 0)
                return new List<UserDto>();

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var users = await _context.Set<User>()
                                     .Where(r => !r.IsDeleted)
                                     .Where(r => r.ClientId == clientId)
                                     .ToListAsync();

                return Mapping.Mapper.Map<List<UserDto>>(users);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.GetUsers(int clientId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(ICollection<UserDto>)!;
        }
    }

    public async Task RemoveUser(long userId)
    {
        try
        {
            if (userId == 0)
                return;

            await _userRepo.Delete(userId);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.RemoveUser(int userId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task AddUser(UserDto user)
    {
        try
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _userRepo.Add(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.AddUser(int userId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }
    #endregion

    #region Emails
    public async Task<ICollection<Email>> GetEmails(long clientId)
    {
        if (clientId == 0)
            return new List<Email>();

        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Set<Email>()
                                 .Where(r => !r.IsDeleted)
                                 .Where(r => r.ClientId == clientId)
                                 .ToListAsync();
    }

    public async Task UpsertEmails(long clientId, List<EmailDto> emails)
    {
        try
        {
            if (clientId == 0)
                return;

            List<Email> prevEmails;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                prevEmails = await _context.Set<Email>()
                        .Where(e => e.ClientId == clientId)
                        .ToListAsync();
            }

            var updatedIds = emails.Select(e => e.Id).ToList();

            // Updated the existed
            foreach (var prevEmail in prevEmails)
            {
                if (!updatedIds.Contains(prevEmail.Id))
                {
                    await DeleteEmail(prevEmail.Id);
                }
                else
                {
                    var updated = emails.FirstOrDefault(e => e.Id == prevEmail.Id);

                    if (updated == null)
                        continue;

                    await _emailRepo.Update(updated);

                    emails.Remove(updated);
                }
            }

            await AddEmailsRange(emails);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.UpdateEmails(int clientId, List<EmailDto> emails): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task RemoveEmailsAll(long clientId, bool definitely = false)
    {
        if (clientId == 0)
            return;

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            try
            {
                var prevEmails = await _context.Set<Email>()
                    .Where(r => !r.IsDeleted)
                    .Where(e => e.ClientId == clientId)
                    .ToListAsync();
                if (definitely)
                {
                    _context.Set<Email>().RemoveRange(prevEmails);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    foreach (var e in prevEmails)
                    {
                        if (e == null)
                            continue;
                        await DeleteEmail(e.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception On ClientRepo.RemoveEmailsAll(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            }
        }
    }

    public async Task AddEmailsRange(IList<EmailDto> emails)
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var data = Mapping.Mapper.Map<List<Email>>(emails);
                await _context.Set<Email>().AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.AddEmailsRange(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
        }
    }

    public async Task<Email> DeleteEmail(long emailId)
    {
        try
        {
            if (emailId == 0)
                throw new ArgumentException(nameof(emailId));

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var entry = await _context.Set<Email>().FirstOrDefaultAsync(x => x.Id == emailId);
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
            _logger.LogError($"Exception On ClientRepo.DeleteEmail(emailId): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(Email)!;
        }
    }
    #endregion

    #region Next Income Functions
    public async Task<List<ClientDto>> GetAllOppen()
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var allClientsIds = await _context.Set<Client>()
                    .Where(l => !l.IsDeleted)
                    .Select(l => l.Id)
                    .ToListAsync();

                if (allClientsIds == null || allClientsIds.Count == 0)
                    return new List<ClientDto>();

                var clients = new List<ClientDto>();

                foreach (var id in allClientsIds)
                {
                    if (id == 0)
                        continue;

                    var isClosed = await IsClosed(id);
                    if (!isClosed)
                    {
                        var client = await Get(id);
                        if (client == null)
                            continue;

                        clients.Add(client);
                    }
                }

                return clients;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.GetAllOppen(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return new List<ClientDto>();
        }
    }

    public async Task<double> GetSumOfAllOppenClientsPotencialFee()
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var allClientsIds = await _context.Set<Client>()
                    .Where(l => !l.IsDeleted)
                    .Select(l => l.Id)
                    .ToListAsync();

                if (allClientsIds == null || allClientsIds.Count == 0)
                    return 0;

                double sumPontecialFee = 0;

                foreach (var id in allClientsIds)
                {
                    if (id == 0)
                        continue;

                    var isClosed = await IsClosed(id);
                    if (!isClosed)
                    {
                        var sum = await GetSumOfPotencialFee(id);
                        sumPontecialFee += sum;
                    }
                }

                return sumPontecialFee;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.GetSumOfAllOppenClientsPotencialFee(): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<double> GetSumOfPayedFee(long clientId)
    {
        try
        {
            if (clientId == 0)
                throw new ArgumentNullException(nameof(clientId));

            List<long> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var offerId = await _context.Set<Offer>()
                    .Where(o => !o.IsDeleted && o.ClientId == clientId)
                    .Select(l => l.Id)
                    .FirstOrDefaultAsync();

                if (offerId == 0)
                    throw new ArgumentNullException(nameof(offerId));

                projectIds = await _context
                                .Set<Project>()
                                .Where(i => !i.IsDeleted && i.OfferId == offerId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (projectIds == null || projectIds.Count == 0)
                return 0;

            double sum = 0;

            foreach (var projectId in projectIds)
            {
                sum += await _projectRep.GetSumOfPayedFee(projectId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.GetSumOfPayedFee({clientId}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<double> GetSumOfPotencialFee(long clientId)
    {
        try
        {
            if (clientId == 0)
                throw new ArgumentNullException(nameof(clientId));

            List<long> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var offerId = await _context.Set<Offer>()
                    .Where(o => !o.IsDeleted && o.ClientId == clientId)
                    .Select(l => l.Id)
                    .FirstOrDefaultAsync();

                if (offerId == 0)
                    return 0;

                projectIds = await _context
                                .Set<Project>()
                                .Where(i => !i.IsDeleted && i.OfferId == offerId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (projectIds == null || projectIds.Count == 0)
                return 0;

            double sum = 0;

            foreach (var projectId in projectIds)
            {
                if (projectId != 0)
                    sum += await _projectRep.GetSumOfPotencialFee(projectId);
            }

            return sum;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.GetSumOfPotencialFee({clientId}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return 0;
        }
    }

    public async Task<bool> IsClosed(long clientId)
    {
        try
        {
            if (clientId == 0)
                throw new ArgumentNullException(nameof(clientId));

            List<long> projectIds;

            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var offerId = await _context.Set<Offer>()
                    .Where(o => !o.IsDeleted && o.ClientId == clientId)
                    .Select(l => l.Id)
                    .FirstOrDefaultAsync();

                if (offerId == 0)
                    return false;

                projectIds = await _context
                                .Set<Project>()
                                .Where(i => !i.IsDeleted && i.OfferId == offerId)
                                .Select(i => i.Id)
                                .ToListAsync();
            }

            if (projectIds == null || projectIds.Count == 0)
                return false;

            List<bool> isClosed = new List<bool>();

            foreach (var projectId in projectIds)
            {
                var closed = await _projectRep.IsClosed(projectId);
                isClosed.Add(closed);
            }

            return isClosed.Count == 0 || isClosed.Any(c => c == false);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ClientRepo.IsClosed({clientId}): {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return false;
        }
    }
    #endregion

    protected override void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _offerRepo?.Dispose();
                _projectRep?.Dispose();
                _invoiceRepo?.Dispose();
                _userRepo?.Dispose();
                _emailRepo?.Dispose();
            }
            disposedValue = true;
        }
    }
}
