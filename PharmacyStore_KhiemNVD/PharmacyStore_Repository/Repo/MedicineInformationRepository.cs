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
    public class MedicineInformationRepository : GenericRepository<MedicineInformation>
    {
        public MedicineInformationRepository() { }

        public MedicineInformationRepository(Fall24PharmaceuticalDBContext context) => _context = context;

        public async Task<List<MedicineInformation>> GetAllAsync()
        {
            var MedicineInformation = await _context.MedicineInformations
            .Include(u => u.Manufacturer)
            .ToListAsync();
            return MedicineInformation ?? new List<MedicineInformation>();
        }

        public async Task<MedicineInformation?> GetByIdAsync(string id)
        {
            var MedicineInformation = await _context.MedicineInformations
                .Include(u => u.Manufacturer)
                .FirstOrDefaultAsync(m => m.MedicineId == id);
            return MedicineInformation ?? new MedicineInformation();
        }
        public async Task<List<MedicineInformation>> SearchAsync(string? manufacturerName, string? activeIngredients)
        {
            var query = _context.MedicineInformations
                        .Include(u => u.Manufacturer).AsQueryable();

            if (!string.IsNullOrEmpty(manufacturerName))
            {
                query = query.Where(p => p.Manufacturer.ManufacturerName.Contains(manufacturerName));
            }

            if (!string.IsNullOrEmpty(activeIngredients))
            {
                query = query.Where(p => p.ActiveIngredients.Contains(activeIngredients));
            }

            return await query.ToListAsync();
        }
    }
}
