namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocatioFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "Media_MediaId", "dbo.Media");
            DropIndex("dbo.Location", new[] { "Media_MediaId" });
            AddColumn("dbo.Media", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Media", "LocationId");
            AddForeignKey("dbo.Media", "LocationId", "dbo.Location", "LocationID", cascadeDelete: true);
            DropColumn("dbo.Location", "Media_MediaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Media_MediaId", c => c.Int());
            DropForeignKey("dbo.Media", "LocationId", "dbo.Location");
            DropIndex("dbo.Media", new[] { "LocationId" });
            DropColumn("dbo.Media", "LocationId");
            CreateIndex("dbo.Location", "Media_MediaId");
            AddForeignKey("dbo.Location", "Media_MediaId", "dbo.Media", "MediaId");
        }
    }
}
