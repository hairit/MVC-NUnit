using System.Net.Mail;
namespace AccountManagerment.Models.ModelValidate
{
    public class AccountValidate
    {
        public bool valid;
        public List<Error> errors;

        public AccountValidate()
        {
            this.valid = true;
            this.errors = new List<Error>();
        }

        public bool CheckEmpty(string value)
        {
            if(value != null)
            {
                if (value == " ") return true;
                if (value.Length == 0) return true;
                return false;
            }
            return true;
        }

        private bool CheckMaxOfLength(string value,int maxLength = 0)
        {
            if(value != null || maxLength != 0)
            {
                if (value.Length > maxLength) return true;
                return false;
            }
            return true;
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

        public void IsValidateAccount(Account account)
        {
            int maxLengthEmail = 50;
            int maxLengthName = 100;
            if (CheckEmpty(account.Email))
            {
                this.errors.Add(new Error()
                {
                    typeError = "email",
                    messageError = "Your email is empty"
                });
            }else if (!IsValid(account.Email))
            {
                this.errors.Add(new Error()
                {
                    typeError = "email",
                    messageError = "Your email is invalid"
                });
            }else if (CheckMaxOfLength(account.Email, maxLengthEmail))
            {
                this.errors.Add(new Error()
                {
                    typeError = "email",
                    messageError = $"Your email is not allow greater than {maxLengthEmail}"
                });
            }
            if (CheckEmpty(account.FullName))
            {
                this.errors.Add(new Error()
                {
                    typeError = "name",
                    messageError = "Your name is empty"
                });
            }else if (CheckMaxOfLength(account.FullName, maxLengthName))
            {
                this.errors.Add(new Error()
                {
                    typeError = "name",
                    messageError = $"Your name is not allow greater than {maxLengthName}"
                });
            };
            if (this.errors.Count > 0) this.valid = false;
        }
    }
}
