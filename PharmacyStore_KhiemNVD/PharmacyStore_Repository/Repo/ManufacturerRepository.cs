using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyStore_Repository.Basic;
using PharmacyStore_Repository.DBContext;
using PharmacyStore_Repository.Models;

namespace PharmacyStore_Repository.Repo
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>
    {
        public ManufacturerRepository() { }

        public ManufacturerRepository(Fall24PharmaceuticalDBContext context) => _context = context;
        public async Task<List<Manufacturer>> GetAllAsync()
        {
            var manufacturers = await _context.Manufacturers.ToListAsync();
            return manufacturers ?? new List<Manufacturer>();
        }

    }
}
