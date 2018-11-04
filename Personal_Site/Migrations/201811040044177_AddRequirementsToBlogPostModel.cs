namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequirementsToBlogPostModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Summary", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Body", c => c.String());
            AlterColumn("dbo.BlogPosts", "Summary", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
        }
    }
}
