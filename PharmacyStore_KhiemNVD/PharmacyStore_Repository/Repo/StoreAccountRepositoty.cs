using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyStore_Repository.Basic;
using PharmacyStore_Repository.DBContext;
using PharmacyStore_Repository.Models;

namespace PharmacyStore_Repository.Repo
{
    public class StoreAccountRepositoty : GenericRepository<StoreAccount>
    {
        public StoreAccountRepositoty() { }

        public StoreAccountRepositoty(Fall24PharmaceuticalDBContext context) => _context = context;

        public async Task<StoreAccount> GetUserAccount(string userName, string password)
        {

            return await _context.StoreAccounts.FirstOrDefaultAsync(u => u.EmailAddress == userName && u.StoreAccountPassword == password);
        }
    }
}
