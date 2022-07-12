using AccountManagerment.Models;
using AccountManagerment.Repositories.Interface;

namespace AccountManagerment.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private AssignmentContext _context;
        private IAccountDatabaseAction _action;

        public AccountRepository(AssignmentContext context,IAccountDatabaseAction action)
        {
            this._context = context;
            this._action = action;
        }

        public Account Register(Account account)
        {
            if (_action.InsertAccount(_context, account)) return account;
            else return null;
        }

        //public Account Register(string email, string fullName)
        //{
        //    Account newAcc = new Account()
        //    {
        //        Email = email,
        //        Fullname = fullName
        //    };
        //    try
        //    {
        //        _context.Accounts.Add(newAcc);
        //        _context.SaveChanges();
        //        return newAcc;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}

        public ResponseAccount GetAccounts()
        {
            ResponseAccount response = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
            };
            try
            {
                List<Account> accounts = _action.GetAccounts(_context);
                if(accounts.Count > 0)
                {
                    response.data = accounts;
                }
                return response;
            }catch(Exception e)
            {
                response.status = "ERROR";
                response.message = e.Message;
                return response;
            }
        }
    }
}
