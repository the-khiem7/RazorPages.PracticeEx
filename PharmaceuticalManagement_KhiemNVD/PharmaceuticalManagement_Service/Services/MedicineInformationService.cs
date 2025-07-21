using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement_Repository.Models;
using PharmaceuticalManagement_Repository.Repository;
using PharmaceuticalManagement_Service.Interfaces;

namespace PharmaceuticalManagement_Service.Services
{
    public class MedicineInformationService : IMedicineInformationService
    {
        private readonly MedicineInformationRepository _repository;

        public MedicineInformationService(MedicineInformationRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(MedicineInformation profile)
        {
            return await _repository.CreateAsync(profile);
        }

        public async Task<List<MedicineInformation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<MedicineInformation?> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(MedicineInformation profile)
        {
            await _repository.UpdateAsync(profile);
        }

        public async Task<List<MedicineInformation>> SearchAsync(string? medicineInformation, string? expirationDate, string? warningsAndPrecautions)
        {
            return await _repository.SearchAsync(medicineInformation, expirationDate, warningsAndPrecautions);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var profile = await _repository.GetByIdAsync(id);
            if (profile != null)
            {
                return await _repository.RemoveAsync(profile);
            }
            return false;
        }
    }
}
