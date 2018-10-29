namespace MainProject3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Submit")]
    public partial class Submit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(26)]
        public string IDSubmit { get; set; }

        [StringLength(40)]
        public string Entity1ID { get; set; }

        [StringLength(4)]
        public string Entity2ID { get; set; }

        [StringLength(10)]
        public string Type { get; set; }
    }
}
