using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PantherPetManagement_Repository.Models;
using PantherPetManagement_Repository.Repositories;
using PantherPetManagement_Service.Interfaces;

namespace PantherPetManagement_Service.Services
{
    public class PantherTypeService : IPantherTypeService
    {
        private readonly PantherTypeRepository _repository;

        public PantherTypeService(PantherTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PantherType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
