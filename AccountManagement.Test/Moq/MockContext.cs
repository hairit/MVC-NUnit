using AccountManagerment.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AccountManagement.Test.Moq
{
    internal class MockContext : Mock<AssignmentContext>
    {
        public MockContext mockAccounts()
        {
            var mockDbSet = new Mock<DbSet<Account>>();
            Setup(x => x.Accounts).Returns(mockDbSet.Object);
            return this;
        }

        public MockContext mockGetAccounts(List<Account> accounts)
        {
            var data = accounts.AsQueryable();
            var mockDbSet = new Mock<DbSet<Account>>();
            mockDbSet.As<IQueryable<Account>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Account>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Account>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Account>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            Setup(x => x.Accounts).Returns(mockDbSet.Object);
            return this;
        }
    }
}
