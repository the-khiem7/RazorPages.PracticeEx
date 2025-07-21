using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherPetManagement_Repository.Models;
using PantherPetManagement_Repository.Repositories;
using PantherPetManagement_Service.Interfaces;

namespace PantherPetManagement_Service.Services
{
    public class PantherAccountService : IPantherAccountService
    {
        private readonly PantherAccountRepository _repository;
        public PantherAccountService() => _repository ??= new PantherAccountRepository();
        public async Task<PantherAccount> GetAccount(string email, string password)
        {
            return await _repository.GetAccount(email, password);
        }
    }
}
