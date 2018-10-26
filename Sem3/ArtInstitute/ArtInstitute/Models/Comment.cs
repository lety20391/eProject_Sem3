using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class Comment
    {
        public string CommentID { get; set; }

        public string Detail { get; set; }

        public string UserID { get; set; }

        public string MainID { get; set; }
    }
}