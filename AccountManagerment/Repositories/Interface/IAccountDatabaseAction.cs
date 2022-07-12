using AccountManagerment.Models;

namespace AccountManagerment.Repositories.Interface
{
    public interface IAccountDatabaseAction
    {
        bool InsertAccount(AssignmentContext _context, Account acc);
        List<Account> GetAccounts(AssignmentContext _context);
    }
}
