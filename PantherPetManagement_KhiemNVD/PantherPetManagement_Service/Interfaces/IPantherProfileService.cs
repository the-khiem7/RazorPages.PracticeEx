using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Service.Interfaces
{
    public interface IPantherProfileService
    {
        Task<int> CreateAsync(PantherProfile pantherProfile);
        Task<List<PantherProfile>> GetAllAsync();

        Task<PantherProfile?> GetByIdAsync(int id);

        Task UpdateAsync(PantherProfile pantherProfile);

        Task<bool> DeleteAsync(int id);
        Task<List<PantherProfile>> SearchAsync(double? weight, string? pantherTypeName);

    }
}
