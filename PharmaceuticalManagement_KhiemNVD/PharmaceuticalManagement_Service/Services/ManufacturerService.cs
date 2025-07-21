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
    public class ManufacturerService : IManufacturerService
    {
        private readonly ManufacturerRepository _repository;

        public ManufacturerService(ManufacturerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

}
