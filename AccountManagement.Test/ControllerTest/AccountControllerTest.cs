using AccountManagement.Test.Moq;
using AccountManagerment.Controllers;
using AccountManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AccountManagement.Test.ControllerTest
{
    [TestFixture]
    public class AccountControllerTest
    {
        [Test]
        public void When_CallRegister2WithValidAccount_ReturnRegisterFail()
        {
            //Arrange
            Account account = new Account()
            {
                Email = null,
                FullName = null
            };
            var mockAccountService = new MockAccountService().MockRegister(account);
            var mockAssignmentContext = new Mock<AssignmentContext>();
            AccountController accountController = new AccountController(mockAssignmentContext.Object);
            accountController._accountService = mockAccountService.Object;
            RedirectToActionResult expected = accountController.RedirectToAction("RegisterFail");
            //Act
            var resultView = accountController.Register2(new Account()
            {
                Email = "test@gmail.com",
                FullName = "Test"
            });
            RedirectToActionResult result = (RedirectToActionResult)resultView;
            //Assert
            Assert.That(result.ActionName,Is.EqualTo(expected.ActionName));
        }
    }
}
