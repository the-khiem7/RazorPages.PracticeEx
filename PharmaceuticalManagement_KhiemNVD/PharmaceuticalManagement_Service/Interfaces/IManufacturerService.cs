using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement_Repository.Models;

namespace PharmaceuticalManagement_Service.Interfaces
{
    public interface IManufacturerService
    {
        Task<List<Manufacturer>> GetAllAsync();
    }
}
