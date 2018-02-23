namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBodyFromProjects : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "Body");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Body", c => c.String());
        }
    }
}
