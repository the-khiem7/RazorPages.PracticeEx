using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Models;

namespace LionPetManagement_Services_DoanNgocTrung.Interfaces
{
    public interface ILionProfileService
    {
        Task<int> CreateAsync(LionProfile lionProfile);
        Task<List<LionProfile>> GetAllAsync();

        Task<LionProfile?> GetByIdAsync(int id);

        Task UpdateAsync(LionProfile lionProfile);

        Task<bool> DeleteAsync(int id);
        Task<List<LionProfile>> SearchAsync(string? lionTypeName, double? weight);

    }
}
