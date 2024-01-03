namespace Personal_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailBodyColumnToProjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "DetailBody", c => c.String());
            Sql(@"UPDATE Projects
SET DetailBody='_MagicAndMagnums'
WHERE Id=3");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "DetailBody");
        }
    }
}
