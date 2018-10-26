using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Exhibition
    {
        public string ExhibitionID { get; set; }

        public string Detail { get; set; }

        public string Country { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Condition { get; set; }

        public int Quantity { get; set; }
    }
}