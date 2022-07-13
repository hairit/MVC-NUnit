using AccountManagerment.Models;
using AccountManagerment.Repositories.Interface;

namespace AccountManagerment.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private AssignmentContext _context;

        public AccountRepository(AssignmentContext context)
        {
            this._context = context;
           
        }

        public ResponseAccount GetAccounts()
        {
            ResponseAccount response = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
            };
            try
            {
                List<Account> accounts = _context.Accounts.ToList();
                if (accounts.Count > 0)
                {
                    response.data = accounts;
                }
                return response;
            }
            catch (Exception e)
            {
                response.status = "ERROR";
                response.message = e.Message;
                return response;
            }
        }

        public Account Register(Account account)
        {
            try
            {
                if (account != null)
                {
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                    return account;
                }
                return new Account()
                {
                    FullName = null,
                    Email = null
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Account()
                {
                    FullName = null,
                    Email = null
                };
            }
        }
    }
}
