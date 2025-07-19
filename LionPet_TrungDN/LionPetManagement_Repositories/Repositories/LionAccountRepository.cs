using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement_Repositories_DoanNgocTrung.Basic;
using LionPetManagement_Repositories_DoanNgocTrung.DBContext;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using Microsoft.EntityFrameworkCore;

namespace LionPetManagement_Repositories_DoanNgocTrung.Repositories
{
    public class LionAccountRepository : GenericRepository<LionAccount>
    {
        public LionAccountRepository() { }

        public LionAccountRepository(SU25LionDBContext context) => _context = context;

        public async Task<LionAccount> GetUserAccount(string userName, string password)
        {

            //return await _context.LionAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password);
            //return await _context.LionAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password && u.IsActive == true);
            //return await _context.LionAccounts.FirstOrDefaultAsync(u => u.EmployeeCode == userName && u.Password == password && u.IsActive == true);
            return await _context.LionAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password);
        }

    }
}
