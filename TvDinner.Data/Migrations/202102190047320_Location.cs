namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Continent = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        State_Territory = c.String(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            DropColumn("dbo.Media", "RecipeId");
            DropColumn("dbo.Media", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Media", "RecipeId", c => c.Int(nullable: false));
            DropTable("dbo.Location");
        }
    }
}
