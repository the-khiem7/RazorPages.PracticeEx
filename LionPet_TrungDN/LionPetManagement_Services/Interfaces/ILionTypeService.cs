using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Models;

namespace LionPetManagement_Services_DoanNgocTrung.Interfaces
{
    public interface ILionTypeService
    {
        Task<List<LionType>> GetAllAsync();
    }
}
