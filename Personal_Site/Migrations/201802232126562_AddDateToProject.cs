namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Date");
        }
    }
}
