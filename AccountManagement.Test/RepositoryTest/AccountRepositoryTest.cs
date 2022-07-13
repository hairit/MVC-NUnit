using AccountManagement.Test.Moq;
using AccountManagerment.Models;
using AccountManagerment.Repositories;

namespace AccountManagement.Test.RepositoryTest
{
    [TestFixture]
    internal class AccountRepositoryTest
    {
        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")]
        public void When_CallRegisterWithValidAccount_ReturnExpectedAccount(string email,string fullName)
        {
            //Arange
            Account account = new Account()
            {
                Email = email,
                FullName = fullName
            };
            var mockContext = new MockContext().mockAccounts();
            Account expectedAccount = new Account()
            {
                Email = email,
                FullName = fullName
            };
            var accountRepository = new AccountRepository(mockContext.Object);
            //Act
            var result = accountRepository.Register(account);
            //Assert
            Assert.That(result.Email,Is.EqualTo(expectedAccount.Email));
            Assert.That(result.FullName, Is.EqualTo(expectedAccount.FullName));
        }

        [Test]
        public void When_CallRegisterWithNullInput_ReturnNullAccount()
        {
            //Arange
            var mockContext = new MockContext().mockAccounts();
            Account expectedAccount = new Account()
            {
                Email = null,
                FullName = null
            };
            var accountRepository = new AccountRepository(mockContext.Object);
            //Act
            var result = accountRepository.Register(null);
            //Assert
            Assert.That(result.Email, Is.EqualTo(expectedAccount.Email));
            Assert.That(result.FullName, Is.EqualTo(expectedAccount.FullName));
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithData()
        {
            //Arange
            ResponseAccount expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                    new Account(){Email = "tuonghai.contact@gmail.com",FullName = "Tuong Hai"},
                    new Account(){Email = "tuong.doan@devsoft.vn",FullName = "Tuong Doan"},
                    new Account(){Email = "nam.nguyen@devsoft.vn",FullName = "Nam nguyen"},
                },
            };
            MockContext mockContext = new MockContext().mockGetAccounts(expectedResponse.data);
            var accountRepository = new AccountRepository(mockContext.Object);
            //Act
            var accounts = accountRepository.GetAccounts();
            //Assert
            Assert.That(accounts.status, Is.EqualTo(expectedResponse.status));
            Assert.That(accounts.data.Count, Is.EqualTo(expectedResponse.data.Count));
            for(int i = 0; i < accounts.data.Count; i++)
            {
                Assert.That(accounts.data[i].FullName, Is.EqualTo(expectedResponse.data[i].FullName));
                Assert.That(accounts.data[i].Email, Is.EqualTo(expectedResponse.data[i].Email));
            }
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithoutData()
        {
            //Arange
            
            MockContext mockContext = new MockContext().mockGetAccounts(new List<Account>());
            var accountRepository = new AccountRepository(mockContext.Object);
            //Act
            var responseResult = accountRepository.GetAccounts();
            //Assert
            Assert.That(responseResult.status, Is.EqualTo("OK"));
            Assert.That(responseResult.data.Count, Is.EqualTo(0));
            Assert.That(responseResult.message, Is.EqualTo(null));
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithError()
        {
            //Arange
            var mockContext = new MockContext().mockAccounts();
            var accountRepository = new AccountRepository(mockContext.Object);
            var expectedResponse = new ResponseAccount()
            {
                status = "ERROR",
                message = "Specified method is not supported."
            };
            //Act
            var responseResult = accountRepository.GetAccounts();
            //Assert
            Assert.That(responseResult.status,Is.EqualTo(expectedResponse.status));
            Assert.That(responseResult.data.Count, Is.EqualTo(0));
            Assert.That(responseResult.message,Is.EqualTo(expectedResponse.message));
        }
    }
}
