using BusinessObjects;
using DAL;

namespace BUL
{
    public class AccountService : IAccountService
    {
        private IAccountRepo repo;
        public AccountService(IAccountRepo repo)
        {
            this.repo = repo;
        }
        public LionAccount? Login(string email, string password)
        {
            return repo.GetLionAccount(email, password);
        }
    }
}
