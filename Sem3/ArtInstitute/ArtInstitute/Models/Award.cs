using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Award
    {
        public string AwardID { get; set; }

        public int PriceLevied { get; set; }

        public string CompetitionID { get; set; }

        public int Quantity { get; set; }
    }
}