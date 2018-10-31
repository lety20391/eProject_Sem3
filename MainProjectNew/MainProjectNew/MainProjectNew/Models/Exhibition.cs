namespace MainProjectNew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exhibition")]
    public partial class Exhibition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exhibition()
        {
            Customers = new HashSet<Customer>();
            Exams = new HashSet<Exam>();
        }

        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int num { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(30)]
        public string ExhibitionID { get; set; }

        
        [Required(ErrorMessage = "Detail cannot be blank")]
        [Display(Name = "Detail")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Input Detail")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "Country cannot be blank")]
        [Display(Name = "Country")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Input Country")]
        public string Country { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Condition cannot be blank")]
        [Display(Name = "Condition")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Input Condition")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Input Amount of Photo")]
        [Range(minimum:1, maximum:1000, ErrorMessage = "Amount between 1 - 1000")]
        public int Quantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
