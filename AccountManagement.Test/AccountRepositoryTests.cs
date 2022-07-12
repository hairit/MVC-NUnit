using AccountManagerment.Models;
using AccountManagerment.Repositories;
using AccountManagerment.Repositories.Interface;
using Moq;

namespace AccountManagement.Test
{
    public class AccountRepositoryTests
    {
        public AccountRepository _accountRepository;
        [Test]
        public void AccountRepository_GetAccounts_Success_Test()
        {
            //Arrange
            List<Account> accountsMockResult = new List<Account>()
            {
                new Account() { Email = "tuonghai.contact@gmail.com",FullName = "Tuong Hai"},
                new Account() { Email = "tuongminh.pham@gmail.com",FullName = "Tuong Minh"},
                new Account() { Email = "huynhtrang.pham@gmail.com",FullName = "Huynh Trang"},
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.GetAccounts(It.IsAny<AssignmentContext>())).Returns(accountsMockResult);
            ResponseAccount expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                   {
                        new Account() { Email = "tuonghai.contact@gmail.com",FullName = "Tuong Hai"},
                        new Account() { Email = "tuongminh.pham@gmail.com",FullName = "Tuong Minh"},
                        new Account() { Email = "huynhtrang.pham@gmail.com",FullName = "Huynh Trang"},
                   },
                message = null
            };
            _accountRepository = new AccountRepository(a.Object, b.Object);
            //Act
            var result = _accountRepository.GetAccounts();
            //Assert
            Assert.That(result.status, Is.EqualTo(expectedResponse.status));
            Assert.That(result.message, Is.EqualTo(expectedResponse.message));
            for (int i = 0; i < result.data.Count; i++)
            {
                Assert.That(result.data[i].Email, Is.EqualTo(expectedResponse.data[i].Email));
                Assert.That(result.data[i].FullName, Is.EqualTo(expectedResponse.data[i].FullName));
            }
        }

        [Test]
        public void AccountRepository_GetAccounts_Fail_Test()
        {
            //Arrange
            List<Account> accountsMockResult = new List<Account>()
            {
                new Account() { Email = "fail.contact@gmail.com",FullName = "Tuong Hai"},
                new Account() { Email = "tuongminh.pham@gmail.com",FullName = "Tuong Minh"},
                new Account() { Email = "huynhtrang.pham@gmail.com",FullName = "Huynh Trang"},
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.GetAccounts(It.IsAny<AssignmentContext>())).Returns(accountsMockResult);
            ResponseAccount expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                   {
                         new Account() { Email = "tuonghai.contact@gmail.com",FullName = "Tuong Hai"},
                         new Account() { Email = "tuongminh.pham@gmail.com",FullName = "Tuong Minh"},
                         new Account() { Email = "huynhtrang.pham@gmail.com",FullName = "Huynh Trang"},
                   },
                message = null
            };
            _accountRepository = new AccountRepository(a.Object, b.Object);
            //Act
            var result = _accountRepository.GetAccounts();
            //Assert
            for (int i = 0; i < result.data.Count; i++)
            {
                Assert.That(result.data[i].Email, Is.EqualTo(expectedResponse.data[i].Email));
                Assert.That(result.data[i].FullName, Is.EqualTo(expectedResponse.data[i].FullName));
            }
        }

        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")] // pass
        [TestCase("tony.contact@gmail.com", "Tony")] // fail
        [TestCase("stephen.contact@gmail.com", "Stephen")] // fail
        [TestCase("tuongminh.contact@gmail.com", "Stephen")] // fail
        [TestCase("tuongminh.contact@gmail.com", "Stephen")] // fail
        public void AccountRepository_Register_Success_Test(string email, string fullName)
        {
            //Arrange
            Account accountMock = new Account()
            {
                FullName =fullName,
                Email = email
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.InsertAccount(It.IsAny<AssignmentContext>(), It.IsAny<Account>())).Returns(true);
            _accountRepository = new AccountRepository(a.Object, b.Object);
            Account expectedResult = new Account()
            {
                Email = "tuonghai.contact@gmail.com",
                FullName = "Tuong Hai"
            };
            //Act
            Account result = _accountRepository.Register(accountMock);
            //Assert
            Assert.That(result.Email, Is.EqualTo(expectedResult.Email));
            Assert.That(result.FullName, Is.EqualTo(expectedResult.FullName));
        }

        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")] // pass
        public void AccountRepository_Register_Fail_Test(string email, string fullName)
        {
            //Arrange
            Account accountMock = new Account()
            {
                FullName = fullName,
                Email = email
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.InsertAccount(It.IsAny<AssignmentContext>(), It.IsAny<Account>())).Returns(false);
            _accountRepository = new AccountRepository(a.Object, b.Object);
            Account expectedResult = null;
            //Act
            Account result = _accountRepository.Register(accountMock);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }
}
