using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Service.Interfaces
{
    public interface IPantherTypeService
    {
        Task<List<PantherType>> GetAllAsync();
    }
}
