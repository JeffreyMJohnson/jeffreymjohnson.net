using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public GithubRepo[] Repos { get; set; }

        public GithubRepo[] FilteredRepos { get; set; }

        public GithubUser(string dataPath)
        {
            _reposDataPath = dataPath + "repos.json";
            LoadData();
            FilterRepos();
        }
        public void RefreshDataFiles()
        {
            //get the repos
            //todo this is hack assuming there are less than or equal to 100 repos, should verify count received with total and paginate if needed.
            //paginate to 100 
            string uri = string.Format("{0}/users/{1}/repos?per_page=100", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME);
            string repos = GetWebRequest(uri);
            
            //update the cache
            Repos = JsonConvert.DeserializeObject<GithubRepo[]>(repos);
            //load contents
            foreach(GithubRepo repo in Repos)
            {
                repo.contents = GetContent(repo);
                //set the useme flag once so only have to itterate through contents when refresh
                repo.UseMe = UseMeFlagSetting(repo.contents);
            }

            File.WriteAllText(_reposDataPath, JsonConvert.SerializeObject(Repos));
        }

        private void FilterRepos()
        {
            List<GithubRepo> result = new List<GithubRepo>();
            foreach(var repo in Repos)
            {
                if(repo.UseMe)
                {
                    result.Add(repo);
                }
            }
            FilteredRepos = result.ToArray();
        }

        private bool UseMeFlagSetting(GithubRepoContent[] contents)
        {
            foreach(var content in contents)
            {
                if(content.type == "file" && content.name == ".useme")
                {
                    return true;
                }
            }
            return false;
        }

        private GithubRepoContent[] GetContent(GithubRepo repo)
        {
            string uri = string.Format("{0}/repos/{1}/{2}/contents", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME, repo.name);
            string contents = GetWebRequest(uri);
            return JsonConvert.DeserializeObject<GithubRepoContent[]>(contents);
        }

        private void LoadData()
        {
            if (!File.Exists(_reposDataPath))
            {
                RefreshDataFiles();
            }
            string repos = File.ReadAllText(_reposDataPath);
            Repos = JsonConvert.DeserializeObject<GithubRepo[]>(repos);
        }

        private String GetWebRequest(String uri)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.UserAgent = "Anything";
            request.Headers.Add(HttpRequestHeader.Authorization, "token 46516dde38ffbd905b382da5ccb98ef5f092a08f");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseString = reader.ReadToEnd();
            response.Close();
            stream.Close();
            reader.Close();
            return responseString;
        }
        private string _reposDataPath;


    }
}