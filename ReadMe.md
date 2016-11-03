# JeffreyMJohnson&#46;net 

## TLDR;
Working web site for learning web development and hopefully help someone out in the future as well.
* The backend uses ASP.NET MVC on Microsoft Internet Information Server (IIS).
* Bootstrap.js is used as mobile friendly style framework.
* Projects page is created by using data from GitHub
* Projects detail page is the README.md file from the project’s repo


## Credits
Programmer / Designer - **Jeffrey M Johnson**

## What
It is running on Microsoft Internet Information Server (IIS) using ASP .NET framework and the
MVC design pattern.
It’s a pretty simple design so far, as I am still learning everything from scratch.  My first layout was an old fashioned static site of old with hard coded pages for each page! 
You can check out my original commits to see if you like.

I decided I would use the GitHub API and my own repository (repo) data to build a dynamic project list for the site to list.  Then I would use the readme from each repo for the detail page of each project. This would remove data and layout copying and was much more scalable for future.

## How
#### Tools / Libraries
* ASP.NET MVC
* C#
* Razor
* Bootstrap.js
* GitHub REST API

#### Interesting Code
* [Main Controller](https://github.com/JeffreyMJohnson/jeffreymjohnson.net/blob/master/Main/Controllers/HomeController.cs)
* [GitHubUser Model](https://github.com/JeffreyMJohnson/jeffreymjohnson.net/blob/master/Main/Models/GithubUser.cs)
* [Project View](https://github.com/JeffreyMJohnson/jeffreymjohnson.net/blob/master/Main/Views/Home/Projects.cshtml)
* [Project Detail View](https://github.com/JeffreyMJohnson/jeffreymjohnson.net/blob/master/Main/Views/Home/ProjectDetail.cshtml)

## Current Status
Focus is on the Project / Project Detail pages. I want a way to incorporate some code samples into the 
detail, but not sure best way to extract. Custom Attribute in the code itself and then parse that?

## To-Do
* Continue adding projects
* Code for parsing the source code for custom attributes
* ?