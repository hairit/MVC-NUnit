using System.ComponentModel.DataAnnotations;

namespace AccountManagerment.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Please enter your email address")]
        public string EmailAddress { get; set; } = null!;
        [Required(ErrorMessage = "Please enter your subject")]
        public string Subject { get; set; } = null!;
        [Required(ErrorMessage = "Please enter your content")]
        public string Content { get; set; } = null!;
    }
}
