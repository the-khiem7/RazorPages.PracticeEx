using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_Repository.Basic;
using PharmaceuticalManagement_Repository.DBContext;
using PharmaceuticalManagement_Repository.Models;

namespace PharmaceuticalManagement_Repository.Repository
{
    public class MedicineInformationRepository : GenericRepository<MedicineInformation>
    {
        public MedicineInformationRepository() { }

        public MedicineInformationRepository(Fall24PharmaceuticalDBContext context) => _context = context;

        public async Task<List<MedicineInformation>> GetAllAsync()
        {
            var profile = await _context.MedicineInformations
            .Include(u => u.Manufacturer)
            .ToListAsync();
            return profile ?? new List<MedicineInformation>();
        }

        public async Task<MedicineInformation?> GetByIdAsync(string id)
        {
            var profile = await _context.MedicineInformations
                .Include(u => u.Manufacturer)
                .FirstOrDefaultAsync(m => m.MedicineId == id);
            return profile ?? new MedicineInformation();
        }
        public async Task<List<MedicineInformation>> SearchAsync(string? MedicineInformation, string? ExpirationDate, string? WarningsAndPrecautions)
        {
            var query = _context.MedicineInformations
                        .Include(u => u.Manufacturer).AsQueryable();

            if (!string.IsNullOrEmpty(MedicineInformation))
            {
                query = query.Where(p => p.Manufacturer.ManufacturerName.Contains(MedicineInformation));
            }

            if (!string.IsNullOrEmpty(ExpirationDate))
            {
                query = query.Where(p => p.ExpirationDate.Contains(ExpirationDate));
            }

            if (!string.IsNullOrEmpty(WarningsAndPrecautions))
            {
                query = query.Where(p => p.WarningsAndPrecautions.Contains(WarningsAndPrecautions));
            }

            return await query.ToListAsync();
        }
    }


}
