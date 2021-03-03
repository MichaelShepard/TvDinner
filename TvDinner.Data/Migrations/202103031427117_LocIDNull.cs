namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocIDNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Media", "LocationId", "dbo.Location");
            DropIndex("dbo.Media", new[] { "LocationId" });
            AlterColumn("dbo.Media", "LocationId", c => c.Int());
            CreateIndex("dbo.Media", "LocationId");
            AddForeignKey("dbo.Media", "LocationId", "dbo.Location", "LocationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "LocationId", "dbo.Location");
            DropIndex("dbo.Media", new[] { "LocationId" });
            AlterColumn("dbo.Media", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Media", "LocationId");
            AddForeignKey("dbo.Media", "LocationId", "dbo.Location", "LocationID", cascadeDelete: true);
        }
    }
}
