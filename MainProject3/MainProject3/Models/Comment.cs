namespace MainProject3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(27)]
        [Key]
        public string CommentID { get; set; }

        [StringLength(200)]
        public string Detail { get; set; }

        [Required]
        [StringLength(24)]
        public string UserID { get; set; }

        [StringLength(40)]
        public string MainID { get; set; }

        public virtual User User { get; set; }
    }
}
