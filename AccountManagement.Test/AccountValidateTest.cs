using AccountManagerment.Models;
using AccountManagerment.Models.ModelValidate;

namespace AccountManagement.Test
{
    [TestFixture]
    public class AccountValidateTest
    {
        [TestCase("","Tuong Hai")]
        public void When_CallIsValidateAccount_WithEmptyEmail_Account(string email,string fullName)
        {
            //Arrange
            AccountValidate expectedAccountValidate = new AccountValidate()
            {
                valid = false,
                errors = new List<Error>()
                {
                   new Error(){typeError = "email",messageError ="Your email is empty"}
                }
            };
            AccountValidate result = new AccountValidate();
            //Act
            result.IsValidateAccount(new Account()
            {
                Email = email,
                FullName = fullName
            });
            //Assert
            Assert.That(result.valid, Is.EqualTo(expectedAccountValidate.valid));
            Assert.That(result.errors.Count, Is.EqualTo(expectedAccountValidate.errors.Count));
            for (int i = 0;i < result.errors.Count; i++)
            {
                Assert.That(result.errors[i].messageError, Is.EqualTo(expectedAccountValidate.errors[i].messageError));
            }
        }

        [TestCase("tuonghai@gmail.com", "")]
        public void When_CallIsValidateAccount_WithEmptyName_Account(string email, string fullName)
        {
            //Arrange
            AccountValidate expectedAccountValidate = new AccountValidate()
            {
                valid = false,
                errors = new List<Error>()
                {
                   new Error(){typeError = "name",messageError ="Your name is empty"}
                }
            };
            AccountValidate result = new AccountValidate();
            //Act
            result.IsValidateAccount(new Account()
            {
                Email = email,
                FullName = fullName
            });
            //Assert
            Assert.That(result.valid, Is.EqualTo(expectedAccountValidate.valid));
            Assert.That(result.errors.Count, Is.EqualTo(expectedAccountValidate.errors.Count));
            for (int i = 0; i < result.errors.Count; i++)
            {
                Assert.That(result.errors[i].typeError, Is.EqualTo(expectedAccountValidate.errors[i].typeError));
                Assert.That(result.errors[i].messageError, Is.EqualTo(expectedAccountValidate.errors[i].messageError));
            }
        }

        [TestCase("tuonghai11111111111111111111111111111111111111111111111@gmail.com", "Tuong Hai")]
        public void When_CallIsValidateAccount_WithInvalidMaxEmail_Account(string email, string fullName)
        {
            //Arrange
            AccountValidate expectedAccountValidate = new AccountValidate()
            {
                valid = false,
                errors = new List<Error>()
                {
                   new Error(){typeError = "email",messageError ="Your email is not allow greater than 50"}
                }
            };
            AccountValidate result = new AccountValidate();
            //Act
            result.IsValidateAccount(new Account()
            {
                Email = email,
                FullName = fullName
            });
            //Assert
            Assert.That(result.valid, Is.EqualTo(expectedAccountValidate.valid));
            Assert.That(result.errors.Count, Is.EqualTo(expectedAccountValidate.errors.Count));
            for (int i = 0; i < result.errors.Count; i++)
            {
                Assert.That(result.errors[i].typeError, Is.EqualTo(expectedAccountValidate.errors[i].typeError));
                Assert.That(result.errors[i].messageError, Is.EqualTo(expectedAccountValidate.errors[i].messageError));
            }
        }

        [TestCase("tuonghai@gmail.com", "Tuong Hai " +
        "                                                                                      "+"" +
        "                                                                                         ")]
        public void When_CallIsValidateAccount_WithInvalidMaxName_Account(string email, string fullName)
        {
            //Arrange
            AccountValidate expectedAccountValidate = new AccountValidate()
            {
                valid = false,
                errors = new List<Error>()
                {
                   new Error(){typeError = "name",messageError ="Your name is not allow greater than 100"}
                }
            };
            AccountValidate result = new AccountValidate();
            //Act
            result.IsValidateAccount(new Account()
            {
                Email = email,
                FullName = fullName
            });
            //Assert
            Assert.That(result.valid, Is.EqualTo(expectedAccountValidate.valid));
            Assert.That(result.errors.Count, Is.EqualTo(expectedAccountValidate.errors.Count));
            for (int i = 0; i < result.errors.Count; i++)
            {
                Assert.That(result.errors[i].typeError, Is.EqualTo(expectedAccountValidate.errors[i].typeError));
                Assert.That(result.errors[i].messageError, Is.EqualTo(expectedAccountValidate.errors[i].messageError));
            }
        }
        
        [TestCase("invalidEmail", "Tuong Hai")]
        public void When_CallIsValidateAccount_WithInvalidEmail_Account(string email, string fullName)
        {
            //Arrange
            AccountValidate expectedAccountValidate = new AccountValidate()
            {
                valid = false,
                errors = new List<Error>()
                {
                   new Error(){typeError = "email",messageError ="Your email is invalid"}
                }
            };
            AccountValidate result = new AccountValidate();
            //Act
            result.IsValidateAccount(new Account()
            {
                Email = email,
                FullName = fullName
            });
            //Assert
            Assert.That(result.valid, Is.EqualTo(expectedAccountValidate.valid));
            Assert.That(result.errors.Count, Is.EqualTo(expectedAccountValidate.errors.Count));
            for (int i = 0; i < result.errors.Count; i++)
            {
                Assert.That(result.errors[i].typeError, Is.EqualTo(expectedAccountValidate.errors[i].typeError));
                Assert.That(result.errors[i].messageError, Is.EqualTo(expectedAccountValidate.errors[i].messageError));
            }
        }
    }
}
