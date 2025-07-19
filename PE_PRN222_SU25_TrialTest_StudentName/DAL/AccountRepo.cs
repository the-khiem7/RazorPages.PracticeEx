using BusinessObjects;

namespace DAL
{
    public class AccountRepo : IAccountRepo
    {
        public LionAccount? GetLionAccount(string email, string password)
        {
            var _context = new Su25lionDbContext();
            return _context.LionAccounts
                .FirstOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
