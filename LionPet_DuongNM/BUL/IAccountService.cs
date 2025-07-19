using BusinessObjects;

namespace BUL
{
    public interface IAccountService
    {
        LionAccount? Login(string email, string password);
    }
}
