using AccountManagerment.Models;
using AccountManagerment.Repositories;
using AccountManagerment.Repositories.Interface;
using Moq;

namespace AccountManagement.Test.RepositoryTest
{
    [TestFixture]
    internal class AccountRepositoryTest
    {
        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")]
        [TestCase("tuong.doan@devsoft", "Tuong Doan")]
        public void When_CallRegisterWithNotNullAccount_ReturnExpectedAccount(string email,string fullName)
        {
            //Arrange
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.InsertAccount(It.IsAny<AssignmentContext>(),It.IsAny<Account>())).Returns(true);
            AccountRepository accountRepo = new AccountRepository(a.Object,b.Object);
            Account expectedAccount = new Account()
            {
                Email = email,
                FullName = fullName
            };
            //Act
            var result = accountRepo.Register(new Account()
            {
                Email = email,
                FullName = fullName,
            });
            //Assert
            Assert.That(result.FullName, Is.EqualTo(expectedAccount.FullName));
            Assert.That(result.Email, Is.EqualTo(expectedAccount.Email));
        }

        [Test]
        public void When_CallRegisterWithNotNullAccount_ReturnNull()
        {
            //Arrange
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.InsertAccount(It.IsAny<AssignmentContext>(), It.IsAny<Account>())).Returns(false);
            AccountRepository accountRepo = new AccountRepository(a.Object, b.Object);
            //Act
            var result = accountRepo.Register(new Account()
            {
                Email = "test@gmail.com",
                FullName = "Nunit Test"
            });
            //Assert
            Assert.That(result.Email, Is.EqualTo(null));
            Assert.That(result.FullName, Is.EqualTo(null));
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithData()
        {
            //Arrange
            List<Account> mockAccounts = new List<Account>()
            {
                new Account(){Email = "tuonghai.contact@gmail.com",FullName = "Tuong Hai"},
                new Account(){Email = "tuong.doan@devsoft.vn",FullName = "Tuong Doan"},
            };
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.GetAccounts(It.IsAny<AssignmentContext>())).Returns(mockAccounts);
            AccountRepository accountRepo = new AccountRepository(a.Object, b.Object);
            ResponseAccount expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = mockAccounts,
                message = null
            };
            //Act
            var result = accountRepo.GetAccounts();
            //Assert
            Assert.That(result.status, Is.EqualTo(expectedResponse.status));
            for(int i = 0; i < result.data.Count; i++)
            {
                Assert.That(result.data[i], Is.EqualTo(expectedResponse.data[i]));
            }
        }

        [Test]
        public void When_CallGetAccounts_ReturnResponseWithoutData()
        {
            //Arrange
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.GetAccounts(It.IsAny<AssignmentContext>())).Returns(new List<Account>());
            AccountRepository accountRepo = new AccountRepository(a.Object, b.Object);
            //Act
            var result = accountRepo.GetAccounts();
            //Assert
            Assert.That(result.status, Is.EqualTo("OK"));
            Assert.That(result.data.Count, Is.EqualTo(0));
        }
    }
}
