using AccountManagerment.Models;
using AccountManagerment.Repositories;

namespace AccountManagerment.Services
{
    public class AccountService
    {
        private IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }
        public Account Register(string email,string fullName)
        {
            return _accountRepository.Register(email,fullName);
        }
    }
}
