using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Config;
using AutoMapper;
using EmpiriaBMS.Core.ReturnModels;

namespace EmpiriaBMS.Core.Repositories;
public class ProjectsRepo : Repository<ProjectDto, Project>
{
    public ProjectsRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public new async Task<ProjectDto?> Get(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            return await _context
                             .Set<Project>()
                             .Include(r => r.Customer)
                             .Include(r => r.Invoice)
                             .Select(r => Mapping.Mapper.Map<ProjectDto>(r))
                             .FirstOrDefaultAsync(r => r.Id == id);
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(int pageSize = 0, int pageIndex = 0)
    {
        List<Project> projects;
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>().ToListAsync();
                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects);
            }

            projects =  await _context.Set<Project>()
                                      .Skip((pageIndex - 1) * pageSize)
                                      .Take(pageSize)
                                      .Include(r => r.Customer)
                                      .Include(r => r.Invoice)
                                      .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects);
        }
    }

    public new async Task<ICollection<ProjectDto>> GetAll(
        Expression<Func<Project, bool>> expresion,
        int pageSize = 0,
        int pageIndex = 0
    ) {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            List<Project> projects;
            if (pageSize == 0 || pageIndex == 0)
            {
                projects = await _context.Set<Project>().Where(expresion).ToListAsync();
                return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects);
            }

            projects = await _context.Set<Project>()
                                     .Where(expresion)
                                     .Skip((pageIndex - 1) * pageSize)
                                     .Take(pageSize)
                                     .Include(r => r.Customer)
                                     .Include(r => r.Invoice)
                                     .ToListAsync();

            return Mapping.Mapper.Map<List<Project>, List<ProjectDto>>(projects);
        }
    }

    public new async Task<ICollection<DisciplineDto>> GetDisciplines(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var disciplines =  await _context.Set<Discipline>()
                                             .Where(d => d.ProjectId == id)
                                             .Include(r => r.ProjectManager)
                                             .ToListAsync();

            return Mapping.Mapper.Map<List<Discipline>, List<DisciplineDto>>(disciplines);
        }
    }

    public async Task<int> CountDiscipline(int id)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
            return await _context.Disciplines.Where(d => d.ProjectId == id).CountAsync();
    }

    public async Task<CompletedResult> CalcProjectComplete(ProjectDto project, DrawDto draw)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var estimatedHours = project.EstimatedHours;
            var projectHours = project.ManHours;

            var disciplinesIds = (await GetDisciplines(project.Id)).Select(d => d.Id);
            int disciplinesCount = disciplinesIds.Count();

            // Get Draws Sum Hours
            List<Draw> draws  = await _context
                                    .Set<Draw>()
                                    .Where(d => d.Id != draw.Id)
                                    .Where(d => disciplinesIds.Contains(d.DisciplineId))
                                    .ToListAsync();
            draws.Add(Mapping.Mapper.Map<Draw>(draw));
            var sumDrawsHourse = draws.Select(m => m.ManHours).Sum();

            // Get Docs Sum Hourse
            List<Doc> docs = await _context
                                    .Set<Doc>()
                                    .Where(d => disciplinesIds.Contains(d.DisciplineId))
                                    .ToListAsync();
            var sumDocsHourse = docs.Select(m => m.ManHours).Sum();

            // Some Project Hours
            var sumProjectHours = sumDrawsHourse + sumDocsHourse;

            // Project Completed
            var projectCompleted = Convert.ToInt32((sumProjectHours / estimatedHours) * 100);

            CompletedResult result =  new CompletedResult()
            {
                ProjectCompleted = projectCompleted,
                DisciplineCompleted = projectCompleted / disciplinesCount,
                DrawCompleted = (projectCompleted / 2) / draws.Count,
                DocCompleted = (projectCompleted / 2) / docs.Count
            };

            return result;
        }
    }

    public async Task<CompletedResult> CalcProjectComplete(ProjectDto project, DocDto doc)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            var estimatedHours = project.EstimatedHours;
            var projectHours = project.ManHours;

            var disciplinesIds = (await GetDisciplines(project.Id)).Select(d => d.Id);
            int disciplinesCount = disciplinesIds.Count();

            // Get Draws Sum Hours
            List<Draw> draws = await _context
                                    .Set<Draw>()
                                    .Where(d => disciplinesIds.Contains(d.DisciplineId))
                                    .ToListAsync();
            var sumDrawsHourse = draws.Select(m => m.ManHours).Sum();

            // Get Docs Sum Hourse
            List<Doc> docs = await _context
                                    .Set<Doc>()
                                    .Where(d => d.Id != doc.Id)
                                    .Where(d => disciplinesIds.Contains(d.DisciplineId))
                                    .ToListAsync();
            docs.Add(Mapping.Mapper.Map<Doc>(doc));
            var sumDocsHourse = docs.Select(m => m.ManHours).Sum();

            // Some Project Hours
            var sumProjectHours = sumDrawsHourse + sumDocsHourse;

            // Project Completed
            var projectCompleted = Convert.ToInt32((sumProjectHours / estimatedHours) * 100);

            CompletedResult result = new CompletedResult()
            {
                ProjectCompleted = projectCompleted,
                DisciplineCompleted = projectCompleted / disciplinesCount,
                DrawCompleted = (projectCompleted / 2) / draws.Count,
                DocCompleted = (projectCompleted / 2) / docs.Count
            };

            return result;
        }
    }
}
