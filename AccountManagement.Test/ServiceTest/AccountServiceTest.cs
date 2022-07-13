using AccountManagement.Test.Moq;
using AccountManagerment.Models;
using AccountManagerment.Services;
using Newtonsoft.Json;

namespace AccountManagement.Test.ServiceTest
{
    [TestFixture]
    internal class AccountServiceTest
    {
        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")]
        [TestCase("tuong.doan@devsoft.vn", "Tuong Doan")]
        public void When_CallRegisterWithNotNullAccount_ReturnExpectedAccount(string email, string fullName)
        {
            //Arrange
            Account expectedAccount = new Account()
            {
                Email = email,
                FullName = fullName
            };
            Account mockAccount = new Account()
            {
                Email = email,
                FullName = fullName
            };
            var mockAccountRepo = new MockAccountRepository().MockRegister(mockAccount);
            AccountService accountService = new AccountService(mockAccountRepo.Object);
            //Act
            var result = accountService.Register(mockAccount);

            //Assert
            Assert.That(result.FullName, Is.EqualTo(expectedAccount.FullName));
            Assert.That(result.Email, Is.EqualTo(expectedAccount.Email));
        }

        [Test]
        public void When_CallRegisterWithNullAccount_ReturnNull()
        {
            //Arrange
            var mockAccountRepo = new MockAccountRepository().MockRegister(new Account() { Email = null , FullName = null});
            AccountService accountService = new AccountService(mockAccountRepo.Object);
            //Act
            var result = accountService.Register(new Account() { Email = null, FullName = null });
            //Assert
            Assert.That(result.Email, Is.EqualTo(null));
            Assert.That(result.FullName, Is.EqualTo(null));
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithSortedData()
        {
            //Arrange
            ResponseAccount mockResponseAccount = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",FullName = "Le Thanh Hoa"},
                    new Account() { Email = "test",FullName = "Quoc Dat"},
                    new Account() { Email = "test",FullName = "Stephen Dang"},
                    new Account() { Email = "test",FullName = "Nam Nguyen"},
                    new Account() { Email = "test",FullName = "Tuong Hai"},
                    new Account() { Email = "test",FullName = "Anh Thu"},
                },
                message = null
            };
            var expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                     new Account() { Email = "test",FullName = "Anh Thu"},
                     new Account() { Email = "test",FullName = "Le Thanh Hoa"},
                     new Account() { Email = "test",FullName = "Nam Nguyen"},
                     new Account() { Email = "test",FullName = "Quoc Dat"},
                     new Account() { Email = "test",FullName = "Stephen Dang"},
                     new Account() { Email = "test",FullName = "Tuong Hai"},
                },
                message = null
            };
            var mockAccountRepository = new MockAccountRepository().MockGetAccounts(mockResponseAccount);
            AccountService accountService = new AccountService(mockAccountRepository.Object);
            //Act 
            ResponseAccount result = accountService.GetAccounts();
            //Assert
            Assert.That(result.status, Is.EqualTo(expectedResponse.status));
            for (int i = 0; i < result.data.Count; i++)
            {
                Assert.That(result.data[i].Email, Is.EqualTo(expectedResponse.data[i].Email));
                Assert.That(result.data[i].FullName, Is.EqualTo(expectedResponse.data[i].FullName));
            }
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithoutData()
        {
            //Arrange
            ResponseAccount mockResponseAccount = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>(),
                message = null
            };
            var mockAccountRepository = new MockAccountRepository().MockGetAccounts(mockResponseAccount);
            AccountService accountService = new AccountService(mockAccountRepository.Object);
            //Act 
            ResponseAccount result = accountService.GetAccounts();
            //Assert
            Assert.That(result.status, Is.EqualTo("OK"));
            Assert.That(result.data.Count, Is.EqualTo(0));
        }

        [Test]
        public void AccountService_GetAccounts_JsonFormat_Test()
        {
            //Arrange
            ResponseAccount responseAccountTest = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",FullName = "Le Thanh Hoa"},
                    new Account() { Email = "test",FullName = "Quoc Dat"},
                    new Account() { Email = "test",FullName = "Stephen Dang"},
                    new Account() { Email = "test",FullName = "Nam Nguyen"},
                    new Account() { Email = "test",FullName = "Tuong Hai"},
                    new Account() { Email = "test",FullName = "Anh Thu"},
                },
                message = null
            };
            //Act
            var mockAccountRepository = new MockAccountRepository().MockGetAccounts(responseAccountTest);
            AccountService accountService = new AccountService(mockAccountRepository.Object);
            var result = accountService.GetAccounts();
            //Assert
            JsonConvert.SerializeObject(result);
            Assert.Pass();
        }
    }
}
