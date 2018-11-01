namespace MainProjectNew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Submit")]
    public partial class Submit
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int num { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(26)]
        public string IDSubmit { get; set; }

        [StringLength(40)]
        public string Entity1ID { get; set; }

        [StringLength(40)]
        public string Entity2ID { get; set; }

        [StringLength(10)]
        public string Type { get; set; }
    }
}
