using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement_Repository.Models;

namespace PharmaceuticalManagement_Service.Interfaces
{
    public interface IStoreAccountService
    {
        Task<StoreAccount> GetAccount(string userName, string password);
    }
}
