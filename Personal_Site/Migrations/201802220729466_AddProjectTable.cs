namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Summary = c.String(),
                        Implementation = c.String(),
                        Body = c.String(),
                        ThumbnailUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
