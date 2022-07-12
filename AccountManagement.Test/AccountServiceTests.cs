using AccountManagerment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Test.Moq;
using AccountManagerment.Models;
using Newtonsoft.Json;

namespace AccountManagement.Test
{
    [TestFixture]
    public class AccountServiceTests
    {
        AccountService _accountService;
        [Test]
        public void AccountService_GetAccounts_Success_Sort_Test()
        {
            //Arrange
            ResponseAccount responseAccountTest = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                    new Account() { Email = "test",Fullname = "Quoc Dat"},
                    new Account() { Email = "test",Fullname = "Stephen Dang"},
                    new Account() { Email = "test",Fullname = "Nam Nguyen"},
                    new Account() { Email = "test",Fullname = "Tuong Hai"},
                    new Account() { Email = "test",Fullname = "Anh Thu"},
                },
                message = null
            };
            var expectedResponse = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                     new Account() { Email = "test",Fullname = "Anh Thu"},
                     new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                     new Account() { Email = "test",Fullname = "Nam Nguyen"},
                     new Account() { Email = "test",Fullname = "Quoc Dat"},
                     new Account() { Email = "test",Fullname = "Stephen Dang"},
                     new Account() { Email = "test",Fullname = "Tuong Hai"},
                    //new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                    //new Account() { Email = "test",Fullname = "Quoc Dat"},
                    //new Account() { Email = "test",Fullname = "Stephen Dang"},
                    //new Account() { Email = "test",Fullname = "Nam Nguyen"},
                    //new Account() { Email = "test",Fullname = "Tuong Hai"},
                    //new Account() { Email = "test",Fullname = "Anh Thu"},
                },
                message = null
            };
            var mockAccountRepository = new MockAccountRepository().mockGetAccounts(responseAccountTest);
            _accountService = new AccountService(mockAccountRepository.Object);
            //Act
            ResponseAccount result = _accountService.getAccounts();
            //Assert
            for (int i = 0; i < result.data.Count; i++)
            {
                Assert.That(result.data[i].Email, Is.EqualTo(expectedResponse.data[i].Email));
                Assert.That(result.data[i].Fullname, Is.EqualTo(expectedResponse.data[i].Fullname));
            }
        }

        [Test]
        public void AccountService_GetAccounts_JsonFormat_Test_Success()
        {
            //Arrange
            ResponseAccount responseAccountTest = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                    new Account() { Email = "test",Fullname = "Quoc Dat"},
                    new Account() { Email = "test",Fullname = "Stephen Dang"},
                    new Account() { Email = "test",Fullname = "Nam Nguyen"},
                    new Account() { Email = "test",Fullname = "Tuong Hai"},
                    new Account() { Email = "test",Fullname = "Anh Thu"},
                },
                message = null
            };
            var mockAccountRepository = new MockAccountRepository().mockGetAccounts(responseAccountTest);
            _accountService = new AccountService(mockAccountRepository.Object);
            ResponseAccount expectedResult = new ResponseAccount()
            {

                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",Fullname = "Anh Thu" },
                    new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                    new Account() { Email = "test",Fullname = "Nam Nguyen"},
                    new Account() { Email = "test",Fullname = "Quoc Dat"},
                    new Account() { Email = "test",Fullname = "Stephen Dang"},
                    new Account() { Email = "test",Fullname = "Tuong Hai"},
                   
                },
                message = null
            };
            string expectedJsonFormatResult = JsonConvert.SerializeObject(expectedResult);
            //Act
            string resultJson = JsonConvert.SerializeObject(_accountService.getAccounts());
            //Assert
            Assert.IsTrue(resultJson == expectedJsonFormatResult);
        }

        [Test]
        public void AccountService_GetAccounts_JsonFormat_Test_Fail()
        {
            //Arrange
            ResponseAccount responseAccountTest = new ResponseAccount()
            {
                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                    new Account() { Email = "test",Fullname = "Quoc Dat"},
                    new Account() { Email = "test",Fullname = "Stephen Dang"},
                    new Account() { Email = "test",Fullname = "Nam Nguyen"},
                    new Account() { Email = "test",Fullname = "Tuong Hai"},
                    new Account() { Email = "test",Fullname = "Anh Thu"},
                },
                message = null
            };
            var mockAccountRepository = new MockAccountRepository().mockGetAccounts(responseAccountTest);
            _accountService = new AccountService(mockAccountRepository.Object);
            ResponseAccount expectedResult = new ResponseAccount()
            {

                status = "OK",
                data = new List<Account>()
                {
                    new Account() { Email = "test",Fullname = "Le Thanh Hoa"},
                    new Account() { Email = "test",Fullname = "Nam Nguyen"},
                    new Account() { Email = "test",Fullname = "Quoc Dat"},
                    new Account() { Email = "test",Fullname = "Stephen Dang"},
                    new Account() { Email = "test",Fullname = "Tuong Hai"},
                    new Account() { Email = "test",Fullname = "Anh Thu" },

                },
                message = null
            };
            string expectedJsonFormatResult = JsonConvert.SerializeObject(expectedResult);
            //Act
            string resultJson = JsonConvert.SerializeObject(_accountService.getAccounts());
            //Assert
            Assert.IsFalse(resultJson == expectedJsonFormatResult);
        }

        [TestCase("tuonghai.contact@gmail.com", "Tuong Hai")]// pass
        [TestCase("tuonghai.contact@gmail.com", "123")]// fail
        [TestCase("tuonghai.contact@gmail.com", "456")]// fail
        [TestCase("tuonghai.contact@gmail.com", "789")]// fail
        [TestCase("tuonghai.contact@gmail.com", "")]// fail
        public void AccountService_Register_Test(string email,string fullname)
        {
            //Arrange
            var mockAccountRepository = new MockAccountRepository().mockRegister(email, fullname);
            _accountService = new AccountService(mockAccountRepository.Object);
            Account expectedAccountValue = new Account()
            {
                Email = "tuonghai.contact@gmail.com",
                Fullname = "Tuong Hai"
            };
            //Act
            Account result = _accountService.Register(email, fullname);
            //Assert
            Assert.That(result.Email, Is.EqualTo(expectedAccountValue.Email));
            Assert.That(result.Fullname, Is.EqualTo(expectedAccountValue.Fullname));
        }
    }
}
