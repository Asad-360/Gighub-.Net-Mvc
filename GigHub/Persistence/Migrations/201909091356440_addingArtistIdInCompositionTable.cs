namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingArtistIdInCompositionTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Compositions", name: "ApplicationUser_Id", newName: "ArtistId");
            RenameIndex(table: "dbo.Compositions", name: "IX_ApplicationUser_Id", newName: "IX_ArtistId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Compositions", name: "IX_ArtistId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Compositions", name: "ArtistId", newName: "ApplicationUser_Id");
        }
    }
}
