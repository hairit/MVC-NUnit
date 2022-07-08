using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagerment.Models
{
    public partial class Account
    {
        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(200, ErrorMessage = "The max of length is 200")]
        public string Fullname { get; set; } = null!;
        [Required(ErrorMessage = "Please enter your email address")]
        [MaxLength(50, ErrorMessage = "The max of length is 200")]
        //[EmailAddress]
        public string Email { get; set; } = null!;
    }
}
