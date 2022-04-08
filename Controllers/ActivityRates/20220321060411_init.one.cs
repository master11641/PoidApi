using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class initone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeafult",
                table: "FoodUnits",
                newName: "IsDefault");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "FoodUnits",
                newName: "IsDeafult");
        }
    }
}
