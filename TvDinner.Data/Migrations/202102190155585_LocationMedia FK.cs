namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationMediaFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Media", "LocationId", "dbo.Location");
            DropIndex("dbo.Media", new[] { "LocationId" });
            AddColumn("dbo.Location", "Media_MediaId", c => c.Int());
            CreateIndex("dbo.Location", "Media_MediaId");
            AddForeignKey("dbo.Location", "Media_MediaId", "dbo.Media", "MediaId");
            DropColumn("dbo.Media", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Location", "Media_MediaId", "dbo.Media");
            DropIndex("dbo.Location", new[] { "Media_MediaId" });
            DropColumn("dbo.Location", "Media_MediaId");
            CreateIndex("dbo.Media", "LocationId");
            AddForeignKey("dbo.Media", "LocationId", "dbo.Location", "LocationID", cascadeDelete: true);
        }
    }
}
