using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }

        public string Name { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string IDExhibition { get; set; }

        public string IDExam { get; set; }


    }
}