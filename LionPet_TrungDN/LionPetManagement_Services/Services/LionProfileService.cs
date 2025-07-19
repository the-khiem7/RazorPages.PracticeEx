using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using LionPetManagement_Repositories_DoanNgocTrung.Repositories;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LionPetManagement_Services_DoanNgocTrung.Services
{
    public class LionProfileService : ILionProfileService
    {
        private readonly LionProfileRepository _repository;

        public LionProfileService(LionProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(LionProfile lionProfile)
        {
            return await _repository.CreateAsync(lionProfile);
        }

        public async Task<List<LionProfile>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<LionProfile?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LionProfile lionProfile)
        {
            await _repository.UpdateAsync(lionProfile);
        }

        public async Task<List<LionProfile>> SearchAsync(string? lionTypeName, double? weight)
        {
            return await _repository.SearchAsync(lionTypeName, weight);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lionProfile = await _repository.GetByIdAsync(id);
            if (lionProfile != null)
            {
                return await _repository.RemoveAsync(lionProfile);
            }
            return false;
        }
    }
}
