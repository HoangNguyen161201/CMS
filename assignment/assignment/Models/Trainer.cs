//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            this.AssignTopics = new HashSet<AssignTopic>();
        }

        [Display(Name = "Trainer Id")]
        [Required(ErrorMessage = "The Id cannot be left blank")]
        public string TrainerId { get; set; }

        [Required(ErrorMessage = "The Username cannot be left blank")]
        [Display(Name = "Trainer username")]
        public string Trainer_username { get; set; }

        [RegularExpression(
    "^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
    ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)"
    )]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password cannot be left blank")]
        [Display(Name = "Password")]
        public string Trainer_password { get; set; }

        [Required(ErrorMessage = "The Fullname cannot be left blank")]
        [Display(Name = "Fullname")]
        public string Trainer_fullname { get; set; }

        [Display(Name = "Type")]
        public string Trainer_type { get; set; }

        [Display(Name = "Email")]
        public string Trainer_email { get; set; }

        [Display(Name = "Number phone")]
        public string trainer_phone { get; set; }
        public string image { get; set; }

        [Display(Name = "Roll")]
        public string roll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignTopic> AssignTopics { get; set; }
    }
}
