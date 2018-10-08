namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreAndGigTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Gigs", "Artist_RequireUniqueEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "Artist_RequireUniqueEmail", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropColumn("dbo.Gigs", "Artist_Id");
        }
    }
}
