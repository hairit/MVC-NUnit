using AccountManagerment.Models;
using AccountManagerment.Repositories.Interface;
using AccountManagerment.Services.Interface;

namespace AccountManagerment.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public Account Register(Account account)
        {
            return _accountRepository.Register(account);
        }

        public ResponseAccount GetAccounts()
        {
            ResponseAccount response = _accountRepository.GetAccounts();
            if(response.data.Count > 1)
            {
                List<Account> sortedList = response.data;
                sortedList.Sort();
                response.data = sortedList;
            }
            return response;
        }

    }
}
