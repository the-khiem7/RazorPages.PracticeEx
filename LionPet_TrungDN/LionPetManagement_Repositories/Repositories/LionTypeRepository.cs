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
    public class LionTypeRepository : GenericRepository<LionType>
    {
        public LionTypeRepository() { }

        public LionTypeRepository(SU25LionDBContext context) => _context = context;
        public async Task<List<LionType>> GetAllAsync()
        {
            var liontypes = await _context.LionTypes.ToListAsync();
            return liontypes ?? new List<LionType>();
        }
    }
}
