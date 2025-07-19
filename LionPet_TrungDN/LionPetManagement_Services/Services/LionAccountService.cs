using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using LionPetManagement_Repositories_DoanNgocTrung.Repositories;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;

namespace LionPetManagement_Services_DoanNgocTrung.Services
{
    public class LionAccountService : ILionAccountService
    {
        private readonly LionAccountRepository _repository;

        public LionAccountService() => _repository ??= new LionAccountRepository();

        public async Task<LionAccount> GetUserAccount(string userName, string password)
        {
            return await _repository.GetUserAccount(userName, password);
        }
    }
}
