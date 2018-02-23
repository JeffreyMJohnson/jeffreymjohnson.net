namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBabyKaijuToProjects : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Projects (Title, Summary, Implementation, Body, ThumbnailUrl)
VALUES ('Baby Kaiju', 'A virtual reality pet simulator prototype done while working for Kaio Interactive using Unity and the Oculus.', 'Unity, C#, Oculus, Newton VR', '<p><div class=""embed-responsive embed-responsive-16by9""><iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/m3nuudeGaxY?rel=0""></iframe></div></p>
    <p>A cute little game prototype that was my first chance to program for the Oculus.  Set in a city park, you would go through the life cycles of your kaiju (a giant monster common in Japanese science fiction films, like Godzilla or Gamera) from hatching from its egg to toddler to full grown building-sized monster! During the time you care for and play with your pet by interacting in the environment using the motion controllers.</p>
    <p>A fun feature to implement was fetching objects.  Using a third-party library to help with the physics (Newton VR) I was able to get a fun game of tossing a stick around the park and watching your animated buddy running around and returning it to you.</p>
    <p>Locomotion was implemented using teleport. I am by no means a fan of this technique but after playing around with different movement techniques, it really was the least nauseating to most users.</p>
    <P><b>Implemented with:</b> Unity, C#, Oculus, Newton VR</P>', '/Content/Images/Baby_Kaiju/kaiju_thumb.png')");
        }
        
        public override void Down()
        {
        }
    }
}
