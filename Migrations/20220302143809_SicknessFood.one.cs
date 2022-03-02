using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class SicknessFoodone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SicknessFood_Foods_FoodId",
                table: "SicknessFood");

            migrationBuilder.DropForeignKey(
                name: "FK_SicknessFood_Sicknesses_SicknessId",
                table: "SicknessFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SicknessFood",
                table: "SicknessFood");

            migrationBuilder.RenameTable(
                name: "SicknessFood",
                newName: "SicknessFoods");

            migrationBuilder.RenameIndex(
                name: "IX_SicknessFood_FoodId",
                table: "SicknessFoods",
                newName: "IX_SicknessFoods_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SicknessFoods",
                table: "SicknessFoods",
                columns: new[] { "SicknessId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SicknessFoods_Foods_FoodId",
                table: "SicknessFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SicknessFoods_Sicknesses_SicknessId",
                table: "SicknessFoods",
                column: "SicknessId",
                principalTable: "Sicknesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SicknessFoods_Foods_FoodId",
                table: "SicknessFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_SicknessFoods_Sicknesses_SicknessId",
                table: "SicknessFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SicknessFoods",
                table: "SicknessFoods");

            migrationBuilder.RenameTable(
                name: "SicknessFoods",
                newName: "SicknessFood");

            migrationBuilder.RenameIndex(
                name: "IX_SicknessFoods_FoodId",
                table: "SicknessFood",
                newName: "IX_SicknessFood_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SicknessFood",
                table: "SicknessFood",
                columns: new[] { "SicknessId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SicknessFood_Foods_FoodId",
                table: "SicknessFood",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SicknessFood_Sicknesses_SicknessId",
                table: "SicknessFood",
                column: "SicknessId",
                principalTable: "Sicknesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
