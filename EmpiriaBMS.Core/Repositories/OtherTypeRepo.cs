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

public class OtherTypeRepo : Repository<OtherTypeDto, OtherType>, IDisposable
{
    public OtherTypeRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<List<OtherTypeDto>> GetOtherTypesSelections(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
            {
                var noOtherTypes = await _context.Set<OtherType>()
                                                   .ToListAsync();

                return Mapping.Mapper.Map<List<OtherTypeDto>>(noOtherTypes);
            }
            else
            {
                var noOtherTypesIds = await _context.Set<Other>()
                                                      .Where(d => d.DisciplineId == disciplineId)
                                                      .Select(d => d.TypeId)
                                                      .ToListAsync();

                if (noOtherTypesIds == null)
                    throw new NullReferenceException(nameof(noOtherTypesIds));

                if (noOtherTypesIds.Count() == 0)
                {
                    var allOtherTypes = await _context.Set<OtherType>()
                                                   .ToListAsync();

                    return Mapping.Mapper.Map<List<OtherTypeDto>>(allOtherTypes);
                }

                var noOtherTypes = await _context.Set<OtherType>()
                                                   .Where(t => !noOtherTypesIds.Contains(t.Id))
                                                   .ToListAsync();

                return Mapping.Mapper.Map<List<OtherTypeDto>>(noOtherTypes);
            }
        }
    }

    public async Task<bool> HasOtherTypesSelections(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
                throw new ArgumentNullException(nameof(disciplineId));

            var noOtherTypesIds = await _context.Set<Other>()
                                                .Where(d => d.DisciplineId == disciplineId)
                                                .Select(d => d.TypeId)
                                                .ToListAsync();

            if (noOtherTypesIds == null)
                throw new NullReferenceException(nameof(noOtherTypesIds));

            var result = await _context.Set<OtherType>()
                                       .AnyAsync(t => !noOtherTypesIds.Contains(t.Id));

            return result;
        }
    }
}
