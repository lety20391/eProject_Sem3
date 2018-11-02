using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainProjectNew.Models
{
    public class ShortComment
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Detail { get; set; }
    }
}