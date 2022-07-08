using AccountManagerment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Test.Moq;
using AccountManagerment.Models;

namespace AccountManagement.Test
{
    [TestFixture]
    public class AccountServiceTests
    {
        AccountService accountService;
        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")]// pass
        [TestCase("tuonghai.contact@gmail.com", "123")]// fail
        [TestCase("tuonghai.contact@gmail.com", "456")]// fail
        [TestCase("tuonghai.contact@gmail.com", "789")]// fail
        [TestCase("tuonghai.contact@gmail.com", "")]// fail
        public void AccountService_Register_Test(string email,string fullname)
        {
            //Arrange
            var mockAccountRepository = new MockAccountRepository().mockRegister(email, fullname);
            accountService = new AccountService(mockAccountRepository.Object);
            Account expectedAccountValue = new Account()
            {
                Email = "tuonghai.contact@gmail.com",
                Fullname = "Tuong Hai"
            };
            //Act
            Account result = accountService.Register(email, fullname);
            //Assert
            Assert.That(result.Email, Is.EqualTo(expectedAccountValue.Email));
            Assert.That(result.Fullname, Is.EqualTo(expectedAccountValue.Fullname));
        }
    }
}
