namespace JobExplorer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBUserChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SurName", c => c.String());
            DropColumn("dbo.Resumes", "FirstName");
            DropColumn("dbo.Resumes", "SurName");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.Resumes", "SurName", c => c.String());
            AddColumn("dbo.Resumes", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "SurName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
