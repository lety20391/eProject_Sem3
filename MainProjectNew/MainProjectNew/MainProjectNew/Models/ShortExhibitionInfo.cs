using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainProjectNew.Models
{
    public class ShortExhibitionInfo
    {
        [StringLength(30)]
        public string ExhibitionID { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Input Detail")]
        public string Detail { get; set; }

        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Input Country")]
        public string Country { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        public string firstImagePath { get; set; }
    }
}