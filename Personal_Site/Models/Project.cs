using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal_Site.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime Date { get; set; }  
        public string Implementation { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DetailBody { get; set; }
    }
}