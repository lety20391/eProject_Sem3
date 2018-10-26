using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Exam
    {
        public string ExamID { get; set; }

        public string Path { get; set; }

        public string Quotation { get; set; }

        public string Story { get; set; }

        public string IDStudent { get; set; }

        public string IDCompetition { get; set; }

        public string IDExhibition { get; set; }

        public string Mark { get; set; }

        public string  IDAward { get; set; }

        public string ChangeDescription { get; set; }

        public bool Status { get; set; }

        public bool MoneyReturn { get; set; }

        public int Price { get; set; }

        public bool Improvement { get; set; }
    }
}