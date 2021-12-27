using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment.Models
{
    public class Register
    {

        [Required(ErrorMessage = "The id cannot be left blank")]
        [StringLength(9, ErrorMessage = "Id must be 9 characters")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Username cannot be left blank")]
        [MinLength(10, ErrorMessage = "Username must be more than 10 characters")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "The Fullname cannot be left blank")]
        public string FullName { get; set; }

        [RegularExpression(
            "^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)"
            )]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password cannot be left blank")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match")]
        public string ConfirmPassword { get; set; }
        
        public string Roll { get; set; }
    }
}