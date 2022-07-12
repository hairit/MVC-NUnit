using AccountManagerment.Models;
using AccountManagerment.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new Account() { Email = "tuonghai.contact@gmail.com",Fullname = "Tuong Hai"},
                new Account() { Email = "tuongminh.pham@gmail.com",Fullname = "Tuong Minh"},
                new Account() { Email = "huynhtrang.pham@gmail.com",Fullname = "Huynh Trang"},
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.GetAccounts(It.IsAny<AssignmentContext>())).Returns(accountsMockResult);
            ResponseAccount expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                   {
                        new Account() { Email = "tuonghai.contact@gmail.com",Fullname = "Tuong Hai"},
                        new Account() { Email = "tuongminh.pham@gmail.com",Fullname = "Tuong Minh"},
                        new Account() { Email = "huynhtrang.pham@gmail.com",Fullname = "Huynh Trang"},
                   },
                message = null
            };
            _accountRepository = new AccountRepository(a.Object,b.Object);
            //Act
            var result = _accountRepository.GetAccounts();
            //Assert
            Assert.That(result.status, Is.EqualTo(expectedResponse.status));
            Assert.That(result.message, Is.EqualTo(expectedResponse.message));
            for(int i = 0; i < result.data.Count; i++)
            {
                Assert.That(result.data[i].Email, Is.EqualTo(expectedResponse.data[i].Email));
                Assert.That(result.data[i].Fullname, Is.EqualTo(expectedResponse.data[i].Fullname));
            }
        }
        public void AccountRepository_GetAccounts_Fail_Test()
        {
            //Arrange
            List<Account> accountsMockResult = new List<Account>()
            {
                new Account() { Email = "tuonghai.contact@gmail.com",Fullname = "Tuong Hai"},
                new Account() { Email = "tuongminh.pham@gmail.com",Fullname = "Tuong Minh"},
                new Account() { Email = "huynhtrang.pham@gmail.com",Fullname = "Huynh Trang"},
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.GetAccounts(It.IsAny<AssignmentContext>())).Returns(accountsMockResult);
            ResponseAccount expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                   {
                        new Account() { Email = "fail.contact@gmail.com",Fullname = "Tuong Hai"},
                        new Account() { Email = "fail.pham@gmail.com",Fullname = "Tuong Minh"},
                        new Account() { Email = "fail.pham@gmail.com",Fullname = "Fail"},
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
                Assert.That(result.data[i].Fullname, Is.EqualTo(expectedResponse.data[i].Fullname));
            }
        }

        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")] // pass
        [TestCase("tony.contact@gmail.com", "Tony")] // fail
        [TestCase("stephen.contact@gmail.com", "Stephen")] // fail
        [TestCase("tuongminh.contact@gmail.com", "Stephen")] // fail
        [TestCase("tuongminh.contact@gmail.com", "Stephen")] // fail
        public void AccountRepository_Register_Success_Test(string email,string fullName){
            //Arrange
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.AddAccountToDatabase(It.IsAny<AssignmentContext>(), It.IsAny<Account>())).Returns(true);
            _accountRepository = new AccountRepository(a.Object,b.Object);
            Account expectedResult = new Account()
            {
                Email = "tuonghai.contact@gmail.com",
                Fullname = "Tuong Hai"
            };
            //Act
            Account result = _accountRepository.Register(email, fullName);
            //Assert
            Assert.That(result.Email, Is.EqualTo(expectedResult.Email));
            Assert.That(result.Fullname, Is.EqualTo(expectedResult.Fullname));
        }

        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")] // pass
        public void AccountRepository_Register_Fail_Test(string email, string fullName)
        {
            //Arrange
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.AddAccountToDatabase(It.IsAny<AssignmentContext>(), It.IsAny<Account>())).Returns(false);
            _accountRepository = new AccountRepository(a.Object, b.Object);
            Account expectedResult = null;
            //Act
            Account result = _accountRepository.Register(email, fullName);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            
        }
    }
}
