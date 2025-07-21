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
    public class StoreAccountService : IStoreAccountService
    {
        private readonly StoreAccountRepository _repository;
        public StoreAccountService() => _repository ??= new StoreAccountRepository();
        public async Task<StoreAccount> GetAccount(string userName, string password)
        {
            return await _repository.GetAccount(userName, password);
        }
    }
}
