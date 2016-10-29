using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Main.Models;
using System.Net;
using System.Runtime;
using System.IO;
using Newtonsoft.Json;

namespace Main.Models
{
    public class ProjectList
    {
        string _dataPath;
        Repo[] _repos = null;

        //personal access token
        //46516dde38ffbd905b382da5ccb98ef5f092a08f
        public List<Project> Projects { get; set; }
        public ProjectList(string serverPath)
        {
            _dataPath = serverPath + "\\App_Data\\repos.json";


            //load data from file and set cache
            if (!File.Exists(_dataPath))
            {
                RefreshDataFiles();
            }
            string repos = File.ReadAllText(_dataPath);
            
            //List<Repo> repos = new List<Repo>(JsonConvert.DeserializeObject<Repo[]>(response));
            //RemoveUnwantedProjects(ref repos);
        }

        private Repo[] FilterRepos(string repos)
        {
            List<Repo> results = new List<Repo>();
            Repo[] reposList = JsonConvert.DeserializeObject<Repo[]>(repos);

            for (int i = 0; i < reposList.Length; ++i)
            {
                string uri = string.Format("{0}/repos/{1}/{2}/contents", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME, reposList[i].Name);
                string response = GetWebRequest(uri);
                RepoContent[] contents = JsonConvert.DeserializeObject<RepoContent[]>(response);
                foreach (RepoContent content in contents)
                {
                    if (content.IsWantedProject)
                    {
                        //todo here is where you will add content data to the repo object if needed in future.
                        results.Add(reposList[i]);
                        break;
                    }
                }
            }
            return results.ToArray();
        }

        [Obsolete]
        private void RemoveUnwantedProjects(ref List<Repo> repos)
        {
            List<Repo> wanted = new List<Repo>();
            for (int i = 0; i < repos.Count; ++i)
            {
                string uri = string.Format("{0}/repos/{1}/{2}/contents", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME, repos[i].Name);
                string response = GetWebRequest(uri);
                RepoContent[] contents = JsonConvert.DeserializeObject<RepoContent[]>(response);
                foreach (RepoContent content in contents)
                {
                    if (content.IsWantedProject)
                    {
                        wanted.Add(repos[i]);
                        break;
                    }
                }
            }
            repos = wanted;
        }

        private void RefreshDataFiles()
        {
            //get the repos
            //todo this is hack assuming there are less than or equal to 100 repos, should verify count received with total and paginate if needed.
            //paginate to 100 
            string uri = string.Format("{0}/users/{1}/repos?per_page=100", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME);
            string repos = GetWebRequest(uri);

            //update the cache
            _repos = JsonConvert.DeserializeObject<Repo[]>(repos);

            File.WriteAllText(_dataPath, JsonConvert.SerializeObject(_repos));
        }

        private String GetRepos()
        {
            string uri = string.Format("{0}/users/{1}/repos", Globals.GITHUB_API_URI, Globals.GITHUB_USERNAME);
            return GetWebRequest(uri);


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

        class Repo
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        class RepoContent
        {
            public string Type { get; set; }
            public string Name { get; set; }

            public bool IsWantedProject
            {
                get
                {
                    return Type == "file" && Name == ".useme";
                }
            }
        }
    }
}