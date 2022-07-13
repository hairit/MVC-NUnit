using AccountManagerment.Models;

namespace AccountManagerment.Repositories.Interface
{
    public interface IAccountRepository
    {
        Account Register(Account account);

        ResponseAccount GetAccounts();
    }
}
