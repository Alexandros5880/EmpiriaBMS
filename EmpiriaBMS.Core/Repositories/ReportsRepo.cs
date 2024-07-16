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

    public ReportsRepo(
        IDbContextFactory<AppDbContext> dbFactory,
        Logging.LoggerManager logger
    )
    {
        _dbContextFactory = dbFactory;
        _logger = logger;
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
                var projectsReports = await _context.Set<Project>()
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
                        (leadOfferProject, client) => new
                        {
                            Project = leadOfferProject.project,
                            Offer = leadOfferProject.offer,
                            Lead = leadOfferProject.lead,
                            Client = client
                        })
                    .Join(
                        _context.Set<ProjectCategory>(),
                        leadOfferClientProject => leadOfferClientProject.Offer.CategoryId,
                        cat => cat.Id,
                        (leadOfferClientProject, cat) => new
                        {
                            Project = leadOfferClientProject.Project,
                            Offer = leadOfferClientProject.Offer,
                            Lead = leadOfferClientProject.Lead,
                            Client = leadOfferClientProject.Client,
                            Category = cat
                        })
                    .Join(
                        _context.Set<ProjectSubCategory>(),
                        leadOfferClientCatProject => leadOfferClientCatProject.Offer.SubCategoryId,
                        cat => cat.Id,
                        (leadOfferClientProject, cat) => new ReportProjectReturnModel()
                        {
                            Project = leadOfferClientProject.Project,
                            Offer = leadOfferClientProject.Offer,
                            Lead = leadOfferClientProject.Lead,
                            Client = leadOfferClientProject.Client,
                            Category = leadOfferClientProject.Category,
                            SubCategory = cat
                        })
                    .Where(p => (
                        (start == null || p.Project.CreatedDate >= start) &&
                        (end == null || p.Project.CreatedDate >= end) &&
                        (category == null || p.Category.Id == category.Id) &&
                        (subCategory == null || p.SubCategory.Id == subCategory.Id) &&
                        (client == null || p.Client.Id == client.Id)
                    ))
                    .ToListAsync();

                return projectsReports;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception On ReportsRepo.GetProjectPerEmployeeReport: {ex.Message}, \nInner: {ex.InnerException?.Message}");
            return null;
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
