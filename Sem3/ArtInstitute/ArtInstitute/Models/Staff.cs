using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Staff
    {
        public string StaffID { get; set; }

        public string Name { get; set; }

        public bool Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Class { get; set; }

        public string Subject { get; set; }
    }
}