using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtInstitute.Models
{
    public class User
    {
        public string IDUser { get; set; }

        public string UserNick { get; set; }

        public string UserPass { get; set; }

        public string Real_ID { get; set; }

        public string Role { get; set; }

        public string SessionCode { get; set; }

        public DateTime TimeExpire { get; set; }
    }
}