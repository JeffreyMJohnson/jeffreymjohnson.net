namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJmathToProjects : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Projects (Title, Summary, Implementation, Body, ThumbnailUrl)
VALUES ('JMath', 'Math library focusing on vector and matrix operations implemented in C++ for school assignment.', 'C++, Google Test', '<P>This was one of my first assessments while attending the Academy of Interactive Entertainment for game programming. Creating all the flavors of Windows library binaries (static and dynamic) and implementing full suite of unit tests.</P>
    <p>Great way to get your feet under you when learning to code. Keep it simple UI wise (how about no api?) and focus on the language. </p>
    <p>I noticed when checking on this project here with updated C++, the only issue was the test suite I used from Google Test has deprecated classes in it.  Should probably move to using the built in Visual Studio unit test tools since they have been around long enough and seem to work great.</p>
    <p><b>Implemented With:</b> C++, Google Test</p>
    <p><a href=""https://github.com/JeffreyMJohnson/JMath"">GitHub Repo</a></p>', '/Content/Images/jmath_thumb.png')");
        }
        
        public override void Down()
        {
        }
    }
}
