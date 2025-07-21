using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PantherPetManagement_Repository.Basic;
using PantherPetManagement_Repository.DBContext;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Repository.Repositories
{
    public class PantherTypeRepository : GenericRepository<PantherType>
    {
        public PantherTypeRepository() { }

        public PantherTypeRepository(SU25PantherDBContext context) => _context = context;
        public async Task<List<PantherType>> GetAllAsync()
        {
            var types = await _context.PantherTypes.ToListAsync();
            return types ?? new List<PantherType>();
        }
    }
}
