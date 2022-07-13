using AccountManagerment.Models;
using AccountManagerment.Services.Interface;
using Moq;

namespace AccountManagement.Test.Moq
{
    public class MockAccountService : Mock<IAccountService>
    {
        public MockAccountService MockRegister(Account account)
        {
            Setup(x => x.Register(It.IsAny<Account>())).Returns(account);
            return this;
        }

        public MockAccountService MockGetAccounts(ResponseAccount response)
        {
            Setup(x => x.GetAccounts()).Returns(response);
            return this;
        }
    }
}
