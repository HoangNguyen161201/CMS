
namespace assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CourseCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseCategory()
        {
            this.Courses = new HashSet<Course>();
        }

        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Category name cannot be left blank")]
        [Display(Name = "Category name")]
        public string Category_name { get; set; }

        [Display(Name = "Description")]
        public string Category_description { get; set; }
        public string image { get; set; }
        public List<CourseCategory> cateCollection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
