using System.ComponentModel.DataAnnotations;

namespace AccountManagerment.Models
{
    public partial class Account : IComparable<Account>
    {
        //[Required(ErrorMessage = "Please enter your name")]
        //[MaxLength(100, ErrorMessage = "The max of length is 100")]
        public string FullName { get; set; } = null!;
        //[Required(ErrorMessage = "Please enter your email address")]
        //[MaxLength(50, ErrorMessage = "The max of length is 50")]
        //[EmailAddress]
        public string Email { get; set; } = null!;

        public int CompareTo(Account other)
        {
            Decimal a = this.FullName[0];
            Decimal b = other.FullName[0];
            return a.CompareTo(b);
        }
    }
}
