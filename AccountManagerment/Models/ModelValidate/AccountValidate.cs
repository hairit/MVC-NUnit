using System.Net.Mail;
using System.Collections.Generic;
namespace AccountManagerment.Models.ModelValidate
{
    public class AccountValidate
    {
        public bool valid;
        public List<string> errors;
        public AccountValidate()
        {
            this.valid = true;
            this.errors = new List<string>();
        }
        public bool checkEmailEmpty(string email)
        {
            if (email.Length == 0) return true;
            else return false;
        }
        public bool checkNameEmpty(string fullName)
        {
            if (fullName.Length == 0) return true;
            else return false;
        }
        public bool IsValid(string email)
        {
            var valid = true;
            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
        public bool lengthOfEmailIsValid(string email)
        {
            if (email.Length > 50) return false;
            else return true;
        }
        public bool lengthOfNameIsValid(string fullName)
        {
            if (fullName.Length > 100) return false;
            else return true;
        }
        public void isValidateAccount(string email,string fullName)
        {
            if (checkEmailEmpty(email))
            {
                this.valid = false;
                this.errors.Add("Please enter your email address");
            }
            if (checkNameEmpty(fullName))
            {
                this.valid = false;
                this.errors.Add("Please enter your name");
            };
            if (!lengthOfEmailIsValid(email))
            {
                this.valid = false;
                this.errors.Add("Length of email is not allow greater than 50");
            }
            if (!lengthOfNameIsValid(fullName))
            {
                this.valid = false;
                this.errors.Add("Length of name is not allow greater than 200");
            }
            if (!IsValid(email))
            {
                this.valid = false;
                this.errors.Add("Email is invalid");
            };
        }
    }
}
