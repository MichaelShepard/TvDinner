namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFKLocationID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Media", "LocationId");
            AddForeignKey("dbo.Media", "LocationId", "dbo.Location", "LocationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "LocationId", "dbo.Location");
            DropIndex("dbo.Media", new[] { "LocationId" });
            DropColumn("dbo.Media", "LocationId");
        }
    }
}
