using BusinessObjects;

namespace DAL
{
    public interface IAccountRepo
    {
        LionAccount? GetLionAccount(string email, string password);
    }
}
