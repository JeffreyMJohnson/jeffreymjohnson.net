using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main.Models
{
    public class GithubUser
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public string url { get; set; }
        public string FollowersUrl { get; set; }
        public string repos_url { get; set; }
        public string GistsUrl { get; set; }
        public string Name { get; set; }

    }
}