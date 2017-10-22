namespace JobExplorer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetUserId_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "AspNetUsersId", c => c.String());
            AddColumn("dbo.Resumes", "Employee_FullName", c => c.String(nullable: false));
            AddColumn("dbo.Resumes", "Employee_UserName", c => c.String(nullable: false));
            AddColumn("dbo.Resumes", "Employee_Email", c => c.String(nullable: false));
            AddColumn("dbo.Resumes", "Employee_Password", c => c.String(nullable: false));
            AddColumn("dbo.Resumes", "Employee_PasswordConfirm", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "Employee_PasswordConfirm");
            DropColumn("dbo.Resumes", "Employee_Password");
            DropColumn("dbo.Resumes", "Employee_Email");
            DropColumn("dbo.Resumes", "Employee_UserName");
            DropColumn("dbo.Resumes", "Employee_FullName");
            DropColumn("dbo.Resumes", "AspNetUsersId");
        }
    }
}
