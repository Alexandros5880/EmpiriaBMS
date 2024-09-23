using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.ReturnModels;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpiriaBMS.Core.Repositories;

public class ReportsRepo : IDisposable
{
    private bool disposedValue;
    protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    protected readonly Logging.LoggerManager _logger;
    protected readonly ProjectsRepo _projectsRepo;

    public ReportsRepo(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    )
    {
        _dbContextFactory = dbFactory;
        _logger = logger;
        _projectsRepo = new ProjectsRepo(dbFactory, logger);
    }


    public async Task<List<ReportProjectReturnModel>> GetProjectPerEmployeeReport(
        DateTime? start,
        DateTime? end,
        ClientDto client,
        ProjectCategoryDto category,
        ProjectSubCategoryDto subCategory
    )
    {
        try
        {
            using (var _context = _dbContextFactory.CreateDbContext())
            {
                var projects = await _context.Set<Project>()
                .Where(dt => !dt.IsDeleted)
                .Where(p => (start == null || p.CreatedDate >= start) && (end == null || p.CreatedDate <= end))
                .Join(
                    _context.Set<Offer>(),
                    project => project.OfferId,
                    offer => offer.Id,
                    (project, offer) => new { project, offer })
                .Join(
                    _context.Set<Lead>(),
                    offerProject => offerProject.offer.LeadId,
                    lead => lead.Id,
                    (offerProject, lead) => new { offerProject.project, offerProject.offer, lead })
                .Join(
                    _context.Set<Client>(),
                    leadOfferProject => leadOfferProject.lead.ClientId,
                    client => client.Id,
                    (leadOfferProject, client) => new { leadOfferProject.project, leadOfferProject.offer, leadOfferProject.lead, client })
                .Join(
                    _context.Set<ProjectCategory>(),
                    leadOfferClientProject => leadOfferClientProject.offer.CategoryId,
                    cat => cat.Id,
                    (leadOfferClientProject, cat) => new
                    {
                        project = leadOfferClientProject.project,
                        offer = leadOfferClientProject.offer,
                        lead = leadOfferClientProject.lead,
                        client = leadOfferClientProject.client,
                        category = cat
                    })
                .Join(
                    _context.Set<ProjectSubCategory>(),
                    leadOfferClientCatProject => leadOfferClientCatProject.offer.SubCategoryId,
                    subCat => subCat.Id,
                    (leadOfferClientCatProject, subCat) => new ReportProjectReturnModel
                    {
                        Project = leadOfferClientCatProject.project,
                        Offer = leadOfferClientCatProject.offer,
                        Lead = leadOfferClientCatProject.lead,
                        Client = leadOfferClientCatProject.client,
                        Category = leadOfferClientCatProject.category,
                        SubCategory = subCat
                    })
                .Where(p => client == null || p.Client.Id == client.Id)
                .Where(p => category == null || p.Category.Id == category.Id)
                .Where(p => subCategory == null || p.SubCategory.Id == subCategory.Id)
                .ToListAsync();

                // Get Times
                var projectsIds = projects.Select(p => p.Project.Id).ToList();
                var dailyTimes = await _context.Set<DailyTime>()
                    .Include(dt => dt.TimeSpan)
                    .Where(dt => !dt.IsDeleted)
                    .Where(dt => projectsIds.Contains((int)dt.ProjectId))
                    .ToListAsync();

                foreach (var project in projects)
                {
                    var sum = dailyTimes
                        .Where(dt => dt.ProjectId == project.Project.Id)
                        .Select(dt => dt.TimeSpan?.ToTimeSpan().Ticks)
                        .Sum();

                    project.TotalWorkedTime = new TimeSpan((long)sum);
                    project.TotalWorkedSum = await _projectsRepo.GetSumOfPayedFee(project.Project.Id);
                }

                return projects;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ReportsRepo.GetProjectPerEmployeeReport: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return default(List<ReportProjectReturnModel>)!;
        }
    }

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
