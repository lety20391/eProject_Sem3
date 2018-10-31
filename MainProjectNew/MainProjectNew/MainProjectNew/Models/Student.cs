namespace MainProjectNew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Exams = new HashSet<Exam>();
        }
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int num { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(27)]
        public string StudentID { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name max 50 characters")]
        public string Name { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Phone cannot be blank")]
        [Display(Name = "Phone")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Phone No. 10 - 11 characters")]
        [RegularExpression("^[0-9]{9,11}$", ErrorMessage = "Only Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address cannot be blank")]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Address max 50 characters")]
        public string Address { get; set; }

        [Display(Name = "Class")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Class max 25 characters")]
        public string ClassID { get; set; }

        [Display(Name = "Class")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Class max 25 characters")]
        public string Admission { get; set; }

        public bool Status { get; set; }

        public virtual Class Class { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
