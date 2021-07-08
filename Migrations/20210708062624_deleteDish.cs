using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRecipeApp.Migrations
{
    public partial class deleteDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Recipe_RecipeId",
                table: "Dish");
            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Recipe_RecipeId",
                table: "Dish",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Recipe_RecipeId",
                table: "Dish");
            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Recipe_RecipeId",
                table: "Dish",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
