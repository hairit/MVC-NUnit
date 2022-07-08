

using AccountManagerment.Models;
using AccountManagerment.Models.ModelValidate;

namespace AccountManagement.Test
{
    public class AccountValidateTests
    {
        AccountValidate accountValidate;
        [SetUp]
        public void Setup()
        {
            accountValidate = new AccountValidate();
        }

        [TestCase("tuonghai.contact@gmail.com")] //pass
        [TestCase("ethan@gmail.com")] //pass
        [TestCase("stephen@outlook@.com")] //fail
        [TestCase("tony.nguyenoutlook.com")] //fail
        public void checkEmailValid_Test(string email)
        {
            //Arrange
            bool expectedValue = true;
            //Act
            bool result = accountValidate.IsValid(email);
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
        [TestCase("tuonghai.contact@gmail.com")] //fail
        [TestCase("")] // pass
        public void checkEmailEmpty_Test(string email)
        {
            //Arrange
            bool expectedValue = true;
            //Act
            bool result = accountValidate.checkEmailEmpty(email);
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
        [TestCase("name")] //fail
        [TestCase("")] //pass
        public void checkNameEmpty_Test(string name)
        {
            //Arrange
            bool expectedValue = true;
            //Act
            bool result = accountValidate.checkNameEmpty(name);
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
        [TestCase("tuonghai.aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@gmail.com")] //fail
        [TestCase("tuonghai.contact@gmail.com")] //pass
        public void checkLengthOfEmail(string email)
        {
            //Arrange
            bool expectedValue = true;
            //Act
            bool result = accountValidate.lengthOfEmailIsValid(email);
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
        [TestCase("Tuong Hai")] // pass
        [TestCase("Tuong Haiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")] // fail
        public void checkLengthOfName(string fullName)
        {
            //Arrange
            bool expectedValue = true;
            //Act
            bool result = accountValidate.lengthOfNameIsValid(fullName);
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
        //Check Validate Account
        [TestCase("tuonghai.contact@gmail.com","Tuong Hai")] // fail
        [TestCase("tony.nguyen@gmail.com", "Tony Nguyen")] // fail
        [TestCase("tuonghai.contact111111111111111111111111111111111111", "")] // pass
        [TestCase("tony.nguyen11111111111111111111111111111111111111111", "")] // pass
        public void checkAccountIsValidate_False(string email,string name)
        {
            //Arrange
            AccountValidate expectedResult = new AccountValidate()
            {
                valid = false,
                errors = new List<string>()
                {
                    "Please enter your name",
                    "Length of email is not allow greater than 50",
                    "Email is invalid"
                }
            };
            //Act
            accountValidate.isValidateAccount(email, name);
            //Assert
            Assert.That(accountValidate.valid,Is.EqualTo(expectedResult.valid));
            for(int i = 0; i< accountValidate.errors.Count; i++)
            {
                Assert.That(accountValidate.errors[i], Is.EqualTo(expectedResult.errors[i]));
            }
        }
    }
}