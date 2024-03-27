using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Repositories.Base;
using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Repositories;

public class DisciplineTypeRepo : Repository<DisciplineTypeDto, DisciplineType>, IDisposable
{
    public DisciplineTypeRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<List<DisciplineTypeDto>> GetDisciplineTypesSelections(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (projectId == 0)
            {
                var noDisciplineTypes = await _context.Set<DisciplineType>()
                                                      .ToListAsync();

                return Mapping.Mapper.Map<List<DisciplineTypeDto>>(noDisciplineTypes);
            }
            else
            {
                var disciplineTypesIds = await _context.Set<Discipline>()
                                                       .Where(d => d.ProjectId == projectId)
                                                       .Select(d => d.TypeId)
                                                       .ToListAsync();

                if (disciplineTypesIds == null)
                    throw new NullReferenceException(nameof(disciplineTypesIds));

                if (disciplineTypesIds.Count() == 0)
                {
                    var allDisciplineTypes = await _context.Set<DisciplineType>()
                                                      .ToListAsync();

                    return Mapping.Mapper.Map<List<DisciplineTypeDto>>(allDisciplineTypes);
                }

                var noDisciplineTypes = await _context.Set<DisciplineType>()
                                                      .Where(t => !disciplineTypesIds.Contains(t.Id))
                                                      .ToListAsync();

                return Mapping.Mapper.Map<List<DisciplineTypeDto>>(noDisciplineTypes);
            }
        }
    }

    public async Task<bool> HasDisciplineTypesSelections(int projectId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (projectId == 0)
                throw new ArgumentNullException(nameof(projectId));

            var disciplineTypesIds = await _context.Set<Discipline>()
                                                   .Where(d => d.ProjectId == projectId)
                                                   .Select(d => d.TypeId)
                                                   .ToListAsync();

            if (disciplineTypesIds == null)
                throw new NullReferenceException(nameof(disciplineTypesIds));

            var result = await _context.Set<DisciplineType>()
                                       .AnyAsync(t => !disciplineTypesIds.Contains(t.Id));

            return result;
        }
    }
}
