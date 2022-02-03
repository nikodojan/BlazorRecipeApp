using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRecipeApp.Migrations
{
    public partial class firstNameTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "User",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "FistName");
        }
    }
}
