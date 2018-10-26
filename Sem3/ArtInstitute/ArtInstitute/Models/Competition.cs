using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Competition
    {
        public string CompetitionID { get; set; }

        public string Detail { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Condition { get; set; }

        public string Award { get; set; }
    }
}