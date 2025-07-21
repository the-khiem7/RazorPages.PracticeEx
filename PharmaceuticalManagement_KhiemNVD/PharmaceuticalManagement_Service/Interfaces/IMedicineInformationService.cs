using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement_Repository.Models;

namespace PharmaceuticalManagement_Service.Interfaces
{
    public interface IMedicineInformationService
    {
        Task<int> CreateAsync(MedicineInformation medicineInformation);
        Task<List<MedicineInformation>> GetAllAsync();

        Task<MedicineInformation?> GetByIdAsync(string id);

        Task UpdateAsync(MedicineInformation medicineInformation);

        Task<bool> DeleteAsync(string id);
        Task<List<MedicineInformation>> SearchAsync(string? medicineInformation, string? expirationDate, string? warningsAndPrecautions);
    }
}
