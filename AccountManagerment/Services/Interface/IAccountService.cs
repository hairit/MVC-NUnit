using AccountManagerment.Models;

namespace AccountManagerment.Services.Interface
{
    public interface IAccountService
    {
        Account Register(Account account);
        ResponseAccount GetAccounts();
    }
}
