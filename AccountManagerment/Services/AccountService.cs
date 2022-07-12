using AccountManagerment.Controllers;
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
        public ResponseAccount getAccounts()
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
