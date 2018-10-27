namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OrignalDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OrganizationDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OrganizationDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OrignalDateTime");
        }
    }
}
