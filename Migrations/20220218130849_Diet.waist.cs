using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Dietwaist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Waist",
                table: "Diets",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Wrist",
                table: "Diets",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Waist",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Wrist",
                table: "Diets");
        }
    }
}
