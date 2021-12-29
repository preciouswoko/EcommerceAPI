using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceData.ViewModel
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class UserRequest
    {
        public string ProfilePicture { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
    public class ForgettenPasswordRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        public string Phonenumber { get; set; }

    }
    public class UpdateRequest
    {
        public string ProfilePicture { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

    }
}
