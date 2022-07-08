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
        public AccountRepository AccountRepository;
        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")] // pass
        [TestCase("tony.contact@gmail.com", "Tony")] // fail
        [TestCase("stephen.contact@gmail.com", "Stephen")] // fail  
        public void AccountRepository_Register_Success_Test(string email,string fullName){
            //Arrange
            var a = new Mock<AssignmentContext>();
            var b = new Mock<IAccountDatabaseAction>();
            b.Setup(x => x.AddAccountToDatabase(It.IsAny<AssignmentContext>(), It.IsAny<Account>())).Returns(true);
            AccountRepository accountRepository = new AccountRepository(a.Object,b.Object);
            Account expectedResult = new Account()
            {
                Email = "tuonghai.contact@gmail.com",
                Fullname = "Tuong Hai"
            };
            //Act
            Account result = accountRepository.Register(email, fullName);
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
            AccountRepository accountRepository = new AccountRepository(a.Object, b.Object);
            Account expectedResult = null;
            //Act
            Account result = accountRepository.Register(email, fullName);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            
        }
    }
}
