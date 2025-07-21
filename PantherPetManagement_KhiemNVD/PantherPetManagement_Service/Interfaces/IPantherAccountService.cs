using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Service.Interfaces
{
    public interface IPantherAccountService
    {
        Task<PantherAccount> GetAccount(string email, string password);
    }
}
