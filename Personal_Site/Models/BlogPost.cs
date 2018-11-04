using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Personal_Site.Models
{
    public class BlogPost
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Body { get; set; }
    }
}