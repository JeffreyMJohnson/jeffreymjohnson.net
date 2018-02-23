namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBlogPostsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[BlogPosts] ON
INSERT INTO [dbo].[BlogPosts] ([Id], [Title], [Date], [Summary], [Body]) VALUES (1, N'My First Post.', N'2018-02-20 00:00:00', N'Introduction, getting my feet wet and testing out my new implementation of homemade blog / content management system for this site.', N'<p>Hi there, I知 Jeffrey Johnson a programmer living in Seattle area and this is my first post here on my revamped site. I知 learning MVC so using this site as a test bed seemed like a great way to show what I知 up to and maybe even help someone else along the way.

        <p>I知 currently about half way through a Udemy course, and supplement with anything else I can find on internet (Microsoft does have great documentation). I have liked Udemy courses (I致e taken a few now) because of their focus on having you do exercises and taking quizzes to reinforce the material. It really has helped me a lot.</p>

        <p>My career has been focused in gaming, using c++ and Unreal Engine so getting back to C#, SQL, entity framework on top of the new MVC stuff has been a stretch on the mind for sure. I致e decided to change course and focus on a .NET job so diving in to this seemed like the logical choice.</p>

        <p>Not sure how I知 going to go with this blogging. Teaching new stuff as I learn them to help others (and reinforce with me) or more of a thoughts and opinions kind of thing. No reason couldn''t be both!</p>

        <p>Until we meet again, so long and thanks for all the fish.</p>')
SET IDENTITY_INSERT [dbo].[BlogPosts] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
