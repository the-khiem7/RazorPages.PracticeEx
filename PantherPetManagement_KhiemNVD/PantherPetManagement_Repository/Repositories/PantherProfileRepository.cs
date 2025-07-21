using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_Repository.Basic;
using PantherPetManagement_Repository.DBContext;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Repository.Repositories
{
    public class PantherProfileRepository : GenericRepository<PantherProfile>
    {
        public PantherProfileRepository() { }

        public PantherProfileRepository(SU25PantherDBContext context) => _context = context;

        public async Task<List<PantherProfile>> GetAllAsync()
        {
            var profile = await _context.PantherProfiles
            .Include(u => u.PantherType)
            .ToListAsync();
            return profile ?? new List<PantherProfile>();
        }

        public async Task<PantherProfile?> GetByIdAsync(int id)
        {
            var profile = await _context.PantherProfiles
                .Include(u => u.PantherType)
                .FirstOrDefaultAsync(m => m.PantherProfileId == id);
            return profile ?? new PantherProfile();
        }
        public async Task<List<PantherProfile>> SearchAsync(double? weight, string? pantherTypeName)
        {
            var query = _context.PantherProfiles
                        .Include(u => u.PantherType).AsQueryable();

            if (weight.HasValue)
            {
                query = query.Where(p => p.Weight == weight.Value);
            }

            if (!string.IsNullOrEmpty(pantherTypeName))
            {
                query = query.Where(p => p.PantherType.PantherTypeName.Contains(pantherTypeName));
            }

            return await query.ToListAsync();
        }
    }
}
