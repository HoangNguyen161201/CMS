using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment.Models
{
    using System;
    using System.Collections.Generic;
    public class Login
    {

        [Required(ErrorMessage = "The Username cannot be left blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password cannot be left blank")]
        public string Password { get; set; }

        public string Roll { get; set; }
    }
}