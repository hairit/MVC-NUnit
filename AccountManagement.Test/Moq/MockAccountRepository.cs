using AccountManagerment.Models;
using AccountManagerment.Repositories.Interface;
using Moq;

namespace AccountManagement.Test.Moq
{
    public class MockAccountRepository : Mock<IAccountRepository>
    {
        public MockAccountRepository MockRegister(Account account)
        {
            Setup(x => x.Register(It.IsAny<Account>())).Returns(account);
            return this;
        }

        public MockAccountRepository MockGetAccounts(ResponseAccount response)
        {
            Setup(x => x.GetAccounts()).Returns(response);
            return this;
        }
    }
}
