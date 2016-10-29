using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main.Models
{
    public class GithubRepo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }

        public GithubRepoContent[] contents { get; set; }
        
        public string ReadMe_html { get; set; }

        public bool UseMe { get; set; }


    }
}