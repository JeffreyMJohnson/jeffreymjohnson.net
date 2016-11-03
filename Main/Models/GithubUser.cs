using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Main.Models
{
    public class GithubUser
    {
        #region public API
        public GithubRepo[] Repos { get; set; }

        public GithubRepo[] FilteredRepos { get; set; }

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
            foreach (GithubRepo repo in Repos)
            {
                repo.contents = GetContent(repo);
                //set the useme flag once so only have to itterate through contents when refresh
                repo.UseMe = UseMeFlagSetting(repo.contents);

                //get the readme if it exists
                //GET /repos/:owner/:repo/readme
                uri = string.Format("{0}/repos/{1}/{2}/readme", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME, repo.name);
                try
                {
                    string response = GetWebRequest(uri, "application/vnd.github.VERSION.html");
                    repo.ReadMe_html = response;
                }
                catch
                {
                    repo.ReadMe_html = "<div>No ReadMe file in the repo yet. Get on it.</div>";
                }
            }
            File.WriteAllText(_reposDataPath, JsonConvert.SerializeObject(Repos));
        }

        public GithubRepo GetRepo(string name)
        {
            foreach (var repo in FilteredRepos)
            {
                if (repo.name == name)
                {
                    return repo;
                }
            }
            throw new ArgumentException("name not in Filtered Repo list.");
        }

        public void UpdateReadmeDataOnly(bool useFiltered = true)
        {
            GithubRepo[] repos = useFiltered ? FilteredRepos : Repos;
            foreach (var repo in repos)
            {
                string uri = string.Format("{0}/repos/{1}/{2}/readme", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME, repo.name);
                try
                {
                    string response = GetWebRequest(uri, "application/vnd.github.VERSION.html");
                    repo.ReadMe_html = response;
                }
                catch
                {
                    repo.ReadMe_html = "<div>No ReadMe file in the repo yet. Get on it.</div>";
                }

            }
            File.WriteAllText(_reposDataPath, JsonConvert.SerializeObject(Repos));
        }
        #endregion
        #region Constructor
        public GithubUser(string dataPath, bool forceRefresh = false)
        {
            _reposDataPath = dataPath + "repos.json";
            LoadData(forceRefresh);
            //debug
            //UpdateReadmeDataOnly();
        }
        #endregion

        #region private fields/ methods

        private void FilterRepos()
        {
            List<GithubRepo> result = new List<GithubRepo>();
            foreach (var repo in Repos)
            {
                if (repo.UseMe)
                {
                    result.Add(repo);
                }
            }
            FilteredRepos = result.ToArray();
        }

        private bool UseMeFlagSetting(GithubRepoContent[] contents)
        {
            foreach (var content in contents)
            {
                if (content.type == "file" && content.name == ".useme")
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

        private void LoadData(bool forceRefresh = false)
        {
            if (forceRefresh || !File.Exists(_reposDataPath))
            {
                RefreshDataFiles();
            }
            string repos = File.ReadAllText(_reposDataPath);
            Repos = JsonConvert.DeserializeObject<GithubRepo[]>(repos);
            FilterRepos();
        }

        private String GetWebRequest(String uri, string acceptType = "application/json")
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.UserAgent = "Anything";
            request.Headers.Add(HttpRequestHeader.Authorization, "token " + Main.Models.Private.Crypto.GITHUB_PERSONAL_ACCESS_TOKEN);
            request.Accept = acceptType;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string responseString = reader.ReadToEnd();
                        return responseString;
                    }
                }
            }
        }
        private string _reposDataPath;
        #endregion

    }
}