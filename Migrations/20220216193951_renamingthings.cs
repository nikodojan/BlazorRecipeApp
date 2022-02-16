using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRecipeApp.Migrations
{
    public partial class renamingthings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Menu_MenuId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Meal_MealId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Recipe_RecipeId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Grocery_GroceryCategory_Category",
                table: "Grocery");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryCategory",
                table: "GroceryCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grocery",
                table: "Grocery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "recipe");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "menu");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "meal");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "ingredient");

            migrationBuilder.RenameTable(
                name: "GroceryCategory",
                newName: "grocerycategory");

            migrationBuilder.RenameTable(
                name: "Grocery",
                newName: "grocery");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "dish");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "day");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_DayId",
                table: "meal",
                newName: "IX_meal_DayId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_RecipeId",
                table: "ingredient",
                newName: "IX_ingredient_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Grocery_Category",
                table: "grocery",
                newName: "IX_grocery_Category");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_RecipeId",
                table: "dish",
                newName: "IX_dish_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_MealId",
                table: "dish",
                newName: "IX_dish_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Day_MenuId",
                table: "day",
                newName: "IX_day_MenuId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "varchar(95)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "varchar(95)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "varchar(95)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "varchar(95)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipe",
                table: "recipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menu",
                table: "menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_meal",
                table: "meal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grocerycategory",
                table: "grocerycategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grocery",
                table: "grocery",
                column: "GroceryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dish",
                table: "dish",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_day",
                table: "day",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_day_menu_MenuId",
                table: "day",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dish_meal_MealId",
                table: "dish",
                column: "MealId",
                principalTable: "meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dish_recipe_RecipeId",
                table: "dish",
                column: "RecipeId",
                principalTable: "recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grocery_grocerycategory_Category",
                table: "grocery",
                column: "Category",
                principalTable: "grocerycategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_recipe_RecipeId",
                table: "ingredient",
                column: "RecipeId",
                principalTable: "recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_meal_day_DayId",
                table: "meal",
                column: "DayId",
                principalTable: "day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_day_menu_MenuId",
                table: "day");

            migrationBuilder.DropForeignKey(
                name: "FK_dish_meal_MealId",
                table: "dish");

            migrationBuilder.DropForeignKey(
                name: "FK_dish_recipe_RecipeId",
                table: "dish");

            migrationBuilder.DropForeignKey(
                name: "FK_grocery_grocerycategory_Category",
                table: "grocery");

            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_recipe_RecipeId",
                table: "ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_meal_day_DayId",
                table: "meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recipe",
                table: "recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menu",
                table: "menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meal",
                table: "meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredient",
                table: "ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grocerycategory",
                table: "grocerycategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grocery",
                table: "grocery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dish",
                table: "dish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_day",
                table: "day");

            migrationBuilder.RenameTable(
                name: "recipe",
                newName: "Recipe");

            migrationBuilder.RenameTable(
                name: "menu",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "meal",
                newName: "Meal");

            migrationBuilder.RenameTable(
                name: "ingredient",
                newName: "Ingredient");

            migrationBuilder.RenameTable(
                name: "grocerycategory",
                newName: "GroceryCategory");

            migrationBuilder.RenameTable(
                name: "grocery",
                newName: "Grocery");

            migrationBuilder.RenameTable(
                name: "dish",
                newName: "Dish");

            migrationBuilder.RenameTable(
                name: "day",
                newName: "Day");

            migrationBuilder.RenameIndex(
                name: "IX_meal_DayId",
                table: "Meal",
                newName: "IX_Meal_DayId");

            migrationBuilder.RenameIndex(
                name: "IX_ingredient_RecipeId",
                table: "Ingredient",
                newName: "IX_Ingredient_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_grocery_Category",
                table: "Grocery",
                newName: "IX_Grocery_Category");

            migrationBuilder.RenameIndex(
                name: "IX_dish_RecipeId",
                table: "Dish",
                newName: "IX_Dish_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_dish_MealId",
                table: "Dish",
                newName: "IX_Dish_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_day_MenuId",
                table: "Day",
                newName: "IX_Day_MenuId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(95)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(95)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(95)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(95)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryCategory",
                table: "GroceryCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grocery",
                table: "Grocery",
                column: "GroceryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Menu_MenuId",
                table: "Day",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Meal_MealId",
                table: "Dish",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Recipe_RecipeId",
                table: "Dish",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grocery_GroceryCategory_Category",
                table: "Grocery",
                column: "Category",
                principalTable: "GroceryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
