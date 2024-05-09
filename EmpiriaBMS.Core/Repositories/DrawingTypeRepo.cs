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

public class DrawingTypeRepo : Repository<DrawingTypeDto, DrawingType>, IDisposable
{
    public DrawingTypeRepo(IDbContextFactory<AppDbContext> DbFactory) : base(DbFactory) { }

    public async Task<List<DrawingTypeDto>> GetDrawingTypesSelections(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
            {
                var noDrawingTypes = await _context.Set<DrawingType>()
                                                   .Where(r => !r.IsDeleted)
                                                   .ToListAsync();

                return Mapping.Mapper.Map<List<DrawingTypeDto>>(noDrawingTypes);
            }
            else
            {
                var noDrawingTypesIds = await _context.Set<Drawing>()
                                                      .Where(r => !r.IsDeleted)
                                                      .Where(d => d.DisciplineId == disciplineId)
                                                      .Select(d => d.TypeId)
                                                      .ToListAsync();

                if (noDrawingTypesIds == null)
                    throw new NullReferenceException(nameof(noDrawingTypesIds));

                if (noDrawingTypesIds.Count() == 0)
                {
                    var allDrawingTypes = await _context.Set<DrawingType>()
                                                        .Where(r => !r.IsDeleted)
                                                        .ToListAsync();

                    return Mapping.Mapper.Map<List<DrawingTypeDto>>(allDrawingTypes);
                }

                var noDrawingTypes = await _context.Set<DrawingType>()
                                                   .Where(r => !r.IsDeleted)
                                                   .Where(t => !noDrawingTypesIds.Contains(t.Id))
                                                   .ToListAsync();

                return Mapping.Mapper.Map<List<DrawingTypeDto>>(noDrawingTypes);
            }
        }
    }

    public async Task<bool> HasDrawingTypesSelections(int disciplineId)
    {
        using (var _context = _dbContextFactory.CreateDbContext())
        {
            if (disciplineId == 0)
                throw new ArgumentNullException(nameof(disciplineId));

            var noDrawingTypesIds = await _context.Set<Drawing>()
                                                  .Where(r => !r.IsDeleted)
                                                  .Where(d => d.DisciplineId == disciplineId)
                                                  .Select(d => d.TypeId)
                                                  .ToListAsync();

            if (noDrawingTypesIds == null)
                throw new NullReferenceException(nameof(noDrawingTypesIds));

            var result = await _context.Set<DrawingType>()
                                       .Where(r => !r.IsDeleted)
                                       .AnyAsync(t => !noDrawingTypesIds.Contains(t.Id));

            return result;
        }
    }
}

