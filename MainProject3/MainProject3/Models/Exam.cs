namespace MainProject3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exam")]
    public partial class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            Customers = new HashSet<Customer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(24)]
        [Key]
        public string ExamID { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }

        [StringLength(100)]
        public string Quotation { get; set; }

        [StringLength(500)]
        public string Story { get; set; }

        [Required]
        [StringLength(27)]
        public string IDStudent { get; set; }

        [StringLength(31)]
        public string IDCompetition { get; set; }

        [StringLength(30)]
        public string IDExhibition { get; set; }

        [StringLength(10)]
        public string Mark { get; set; }

        [StringLength(25)]
        public string IDAward { get; set; }

        [Required]
        [StringLength(100)]
        public string ChangeDescription { get; set; }

        public bool Status { get; set; }

        public bool? MoneyReturn { get; set; }

        public int Price { get; set; }

        public bool? Improvement { get; set; }

        public virtual Award Award { get; set; }

        public virtual Competition Competition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        public virtual Exhibition Exhibition { get; set; }

        public virtual Student Student { get; set; }
    }
}
