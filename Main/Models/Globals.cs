using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main.Models
{
    public static class Globals
    {
        public static List<Project> Projects { get; set; } = 
            new List<Project>()
            {
                new Project()
                {
                    JobTitle = "Programmer",
                    Title = "JeffreyMJohnson.net",
                    Path = "HomeWebSite"
                },
                new Project()
                {
                    JobTitle = "Programmer",
                    Title = "Magic and Magnums Torch Edition",
                    Path = "MagicandMagnums"
                },
                new Project()
                {
                    JobTitle = "Lead programmer and Technical Director",
                    Title = "Gacha Town",
                    Path = "GachaTown"
                },
                new Project()
                {
                    JobTitle = "Programmer",
                    Title = "Versi World",
                    Path = "VersiWorld"
                },
                new Project()
                {
                    JobTitle = "Programmer",
                    Title = "Don't Question It",
                    Path = "DontQuestionIt"
                },
                new Project()
                {
                    JobTitle = "Programmer",
                    Title = "JMath - Linear Algebra Library",
                    Path = "JMath"
                }
            };


    }
}