﻿using FluentMigrator;

namespace MyRecipeBook.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_RECIPES, "Create table to save the recipe's informations")]
    public class Version0000002 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Recipes")
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("CookingTime").AsInt32().NotNullable()
                .WithColumn("Difficulty").AsInt32().Nullable()
                .WithColumn("UserId").AsInt64().NotNullable().ForeignKey("FK_Recipe_User_Id", "Users", "Id");

            CreateTable("Ingredients")
                .WithColumn("Item").AsString().NotNullable()
                .WithColumn("RecipeId").AsInt64().NotNullable().ForeignKey("FK_Ingredient_Recipe_Id", "Recipes", "Id")
                .OnDelete(System.Data.Rule.Cascade);

            CreateTable("Instructions")
                .WithColumn("Step").AsInt32().NotNullable()
                .WithColumn("Text").AsString(2000).NotNullable()
                .WithColumn("RecipeId").AsInt64().NotNullable().ForeignKey("FK_Instructions_Recipe_Id", "Recipes", "Id")
                .OnDelete(System.Data.Rule.Cascade);

            CreateTable("DishTypes")
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("RecipeId").AsInt64().NotNullable().ForeignKey("FK_DishTypes_Recipe_Id", "Recipes", "Id")
                .OnDelete(System.Data.Rule.Cascade);
        }
    }
}
