using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using LionPetManagement_Repositories_DoanNgocTrung.Repositories;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;

namespace LionPetManagement_Services_DoanNgocTrung.Services
{
    public class LionTypeService : ILionTypeService
    {
        private readonly LionTypeRepository _repository;

        public LionTypeService(LionTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LionType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
