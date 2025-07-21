using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_Repository.Basic;
using PantherPetManagement_Repository.DBContext;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Repository.Repositories
{
    public class PantherAccountRepository : GenericRepository<PantherAccount>
    {
        public PantherAccountRepository() { }

        public PantherAccountRepository(SU25PantherDBContext context) => _context = context;

        public async Task<PantherAccount> GetAccount(string email, string password)
        {

            return await _context.PantherAccounts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }

}
