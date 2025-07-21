using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherPetManagement_Repository.Models;
using PantherPetManagement_Repository.Repositories;
using PantherPetManagement_Service.Interfaces;

namespace PantherPetManagement_Service.Services
{
    public class PantherProfileService : IPantherProfileService
    {
        private readonly PantherProfileRepository _repository;

        public PantherProfileService(PantherProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(PantherProfile pantherProfile)
        {
            return await _repository.CreateAsync(pantherProfile);
        }

        public async Task<List<PantherProfile>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<PantherProfile?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PantherProfile pantherProfile)
        {
            await _repository.UpdateAsync(pantherProfile);
        }

        public async Task<List<PantherProfile>> SearchAsync(double? weight, string? pantherTypeName)
        {
            return await _repository.SearchAsync(weight, pantherTypeName);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pantherProfile = await _repository.GetByIdAsync(id);
            if (pantherProfile != null)
            {
                return await _repository.RemoveAsync(pantherProfile);
            }
            return false;
        }
    }
}
