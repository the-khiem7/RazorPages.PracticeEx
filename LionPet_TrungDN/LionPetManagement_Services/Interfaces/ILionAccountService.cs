using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Models;

namespace LionPetManagement_Services_DoanNgocTrung.Interfaces
{
    public interface ILionAccountService
    {
        Task<LionAccount> GetUserAccount(string userName, string password);
    }
}
