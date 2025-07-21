using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_Repository.Basic;
using PharmaceuticalManagement_Repository.DBContext;
using PharmaceuticalManagement_Repository.Models;

namespace PharmaceuticalManagement_Repository.Repository
{
    public class StoreAccountRepository : GenericRepository<StoreAccount>
    {
        public StoreAccountRepository() { }

        public StoreAccountRepository(Fall24PharmaceuticalDBContext context) => _context = context;

        public async Task<StoreAccount> GetAccount(string userName, string password)
        {
            return await _context.StoreAccounts.FirstOrDefaultAsync(u => u.EmailAddress == userName && u.StoreAccountPassword == password);
        }
    }

}
