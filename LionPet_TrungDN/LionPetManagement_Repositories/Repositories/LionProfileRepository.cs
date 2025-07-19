using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Basic;
using LionPetManagement_Repositories_DoanNgocTrung.DBContext;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using Microsoft.EntityFrameworkCore;

namespace LionPetManagement_Repositories_DoanNgocTrung.Repositories
{
    public class LionProfileRepository : GenericRepository<LionProfile>
    {
        public LionProfileRepository() { }

        public LionProfileRepository(SU25LionDBContext context) => _context = context;

        public async Task<List<LionProfile>> GetAllAsync()
        {
            var lionProfile = await _context.LionProfiles
            .Include(u => u.LionType)
            .ToListAsync();
            return lionProfile ?? new List<LionProfile>();
        }

        public async Task<LionProfile?> GetByIdAsync(int id)
        {
            var lionProfile = await _context.LionProfiles
                .Include(u => u.LionType)
                .FirstOrDefaultAsync(m => m.LionProfileId == id);
            return lionProfile ?? new LionProfile();
        }
        public async Task<List<LionProfile>> SearchAsync(string? lionTypeName, double? weight)
        {
            var query = _context.LionProfiles
                        .Include(u => u.LionType).AsQueryable();

            if (!string.IsNullOrEmpty(lionTypeName))
            {
                query = query.Where(p => p.LionType.LionTypeName.Contains(lionTypeName));
            }

            if (weight.HasValue)
            {
                query = query.Where(p => p.Weight == weight.Value);
            }

            return await query.ToListAsync();
        }
    }
}
