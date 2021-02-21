namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "RecipeIngredients", c => c.String(nullable: false));
            AddColumn("dbo.Recipe", "Instructions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "Instructions");
            DropColumn("dbo.Recipe", "RecipeIngredients");
        }
    }
}
