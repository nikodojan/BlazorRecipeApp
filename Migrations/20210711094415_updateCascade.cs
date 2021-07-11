using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRecipeApp.Migrations
{
    public partial class updateCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Menu_MenuId",
                table: "Day");
            migrationBuilder.AddForeignKey(
                name: "FK_Day_Menu_MenuId",
                table: "Day",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal");
            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Meal_MealId",
                table: "Dish");
            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Meal_MealId",
                table: "Dish",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Menu_MenuId",
                table: "Day");
            migrationBuilder.AddForeignKey(
                name: "FK_Day_Menu_MenuId",
                table: "Day",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal");
            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Meal_MealId",
                table: "Dish");
            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Meal_MealId",
                table: "Dish",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
