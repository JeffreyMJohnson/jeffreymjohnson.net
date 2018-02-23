namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProjectTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Projects] ON
INSERT INTO [dbo].[Projects] ([Id], [Title], [Summary], [Implementation], [Body], [ThumbnailUrl]) VALUES (1, N'JeffreyMJohnson.net', N'This web site', N'MVC', N'<p>blah blah blah</p>', NULL)
INSERT INTO [dbo].[Projects] ([Id], [Title], [Summary], [Implementation], [Body], [ThumbnailUrl]) VALUES (3, N'Magic and Magnums', N'A hands on game that uses a physical sandbox to model a terrain in real time for a tower defense style game to played on top of.
            Shown at a number of conferences and trade shows including GDC 2016.', N'Unity3d, C#', N'<p>
            I implemented the pathfinding of the characters in the game. The terrain and potential paths are weighted by steepness, height 
            and terrain type to calculate an overall cost to travel the edge. A* is then used to calculate a path for each character.
        </p>

        <p>
            I also worked on the tower and character shooting mechanics. This uses a firing radius for each character type for general range, 
            but also utilizes a line of sight calculation to see if terrain or other characters are blocking the firing path.
        </p>
        
        <div class=""embed-responsive embed-responsive-16by9"">
            <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/RQ4DZulNDlM"" allowfullscreen></iframe>
        </div>', NULL)
SET IDENTITY_INSERT [dbo].[Projects] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
