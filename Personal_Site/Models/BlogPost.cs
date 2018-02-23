using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal_Site.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
    }
}