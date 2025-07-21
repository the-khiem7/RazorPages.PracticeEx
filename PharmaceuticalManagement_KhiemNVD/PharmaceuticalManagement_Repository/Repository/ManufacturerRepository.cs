using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmaceuticalManagement_Repository.Basic;
using PharmaceuticalManagement_Repository.DBContext;
using PharmaceuticalManagement_Repository.Models;

namespace PharmaceuticalManagement_Repository.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>
    {
        public ManufacturerRepository() { }

        public ManufacturerRepository(Fall24PharmaceuticalDBContext context) => _context = context;
        public async Task<List<Manufacturer>> GetAllAsync()
        {
            var types = await _context.Manufacturers.ToListAsync();
            return types ?? new List<Manufacturer>();
        }
    }

}
