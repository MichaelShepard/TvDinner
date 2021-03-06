namespace TvDinner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        UnitOfMeasure = c.String(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        Recipe_RecipeId = c.Int(nullable: false),
                        Ingredient_IngredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeId, t.Ingredient_IngredientId })
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_IngredientId, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.Ingredient_IngredientId);
            
            DropColumn("dbo.Recipe", "RecipeIngredients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipe", "RecipeIngredients", c => c.String(nullable: false));
            DropForeignKey("dbo.RecipeIngredient", "Ingredient_IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.RecipeIngredient", "Recipe_RecipeId", "dbo.Recipe");
            DropIndex("dbo.RecipeIngredient", new[] { "Ingredient_IngredientId" });
            DropIndex("dbo.RecipeIngredient", new[] { "Recipe_RecipeId" });
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.Ingredient");
        }
    }
}
