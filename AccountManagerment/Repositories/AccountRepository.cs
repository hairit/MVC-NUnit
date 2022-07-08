using AccountManagerment.Models;

namespace AccountManagerment.Repositories
{
    public interface IAccountDatabaseAction
    {
        bool AddAccountToDatabase(AssignmentContext _context, Account acc);
    }
    public class AccountDatabaseAction : IAccountDatabaseAction
    {
        public bool AddAccountToDatabase(AssignmentContext _context, Account acc)
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
    }
    public interface IAccountRepository
    {
        Account Register(string email, string fullName);
       
    }
    public class AccountRepository : IAccountRepository
    {
        private AssignmentContext _context;
        private IAccountDatabaseAction _action;
        public AccountRepository(AssignmentContext context,IAccountDatabaseAction action)
        {
            this._context = context;
            this._action = action;
        }
        public Account Register(string email, string fullName)
        {
            Account newAcc = new Account()
            {
                Email = email,
                Fullname = fullName
            };
            if (_action.AddAccountToDatabase(_context, newAcc)) return newAcc;
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
    }
}
