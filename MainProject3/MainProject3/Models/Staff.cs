namespace MainProject3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(25)]
        [Key]
        public string StaffID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(25)]
        public string ClassID { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        public virtual Class Class { get; set; }
    }
}
