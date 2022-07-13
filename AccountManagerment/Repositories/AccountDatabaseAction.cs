using AccountManagerment.Models;
using AccountManagerment.Repositories.Interface;

namespace AccountManagerment.Repositories
{
    //public interface IAccountDatabaseAction2
    //{
    //    List<Account> GetAccounts(AssignmentContext _context);
    //}

    //public class AccountDatabaseAction2: IAccountDatabaseAction2
    //{
    //    AccountDatabaseAction _accountDatabaseAction;

    //    public AccountDatabaseAction2(AccountDatabaseAction accountDatabaseAction)
    //    {
    //        _accountDatabaseAction = accountDatabaseAction;
    //    }

    //    public List<Account> GetAccounts(AssignmentContext _context)
    //    {
    //        return _accountDatabaseAction.GetAccounts(_context);
    //    }
    //}

    public class AccountDatabaseAction : IAccountDatabaseAction
    {
        public bool InsertAccount(AssignmentContext _context, Account acc)
        {
            try
            {
                _context.Accounts.Add(acc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }
        }

        public List<Account> GetAccounts(AssignmentContext _context)
        {
            return _context.Accounts.ToList();
        }
    }
}
