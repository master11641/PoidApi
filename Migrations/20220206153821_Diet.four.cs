using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Dietfour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_WaterRates_WaterRateRateId",
                table: "Diets");

            migrationBuilder.RenameColumn(
                name: "WaterRateRateId",
                table: "Diets",
                newName: "WaterRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Diets_WaterRateRateId",
                table: "Diets",
                newName: "IX_Diets_WaterRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_WaterRates_WaterRateId",
                table: "Diets",
                column: "WaterRateId",
                principalTable: "WaterRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_WaterRates_WaterRateId",
                table: "Diets");

            migrationBuilder.RenameColumn(
                name: "WaterRateId",
                table: "Diets",
                newName: "WaterRateRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Diets_WaterRateId",
                table: "Diets",
                newName: "IX_Diets_WaterRateRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_WaterRates_WaterRateRateId",
                table: "Diets",
                column: "WaterRateRateId",
                principalTable: "WaterRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
