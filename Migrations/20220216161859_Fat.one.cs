using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Fatone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FatPartDiet_Diets_DietId",
                table: "FatPartDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_FatPartDiet_FatParts_FatPartId",
                table: "FatPartDiet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FatPartDiet",
                table: "FatPartDiet");

            migrationBuilder.RenameTable(
                name: "FatPartDiet",
                newName: "FatPartDiets");

            migrationBuilder.RenameIndex(
                name: "IX_FatPartDiet_DietId",
                table: "FatPartDiets",
                newName: "IX_FatPartDiets_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FatPartDiets",
                table: "FatPartDiets",
                columns: new[] { "FatPartId", "DietId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FatPartDiets_Diets_DietId",
                table: "FatPartDiets",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FatPartDiets_FatParts_FatPartId",
                table: "FatPartDiets",
                column: "FatPartId",
                principalTable: "FatParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FatPartDiets_Diets_DietId",
                table: "FatPartDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_FatPartDiets_FatParts_FatPartId",
                table: "FatPartDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FatPartDiets",
                table: "FatPartDiets");

            migrationBuilder.RenameTable(
                name: "FatPartDiets",
                newName: "FatPartDiet");

            migrationBuilder.RenameIndex(
                name: "IX_FatPartDiets_DietId",
                table: "FatPartDiet",
                newName: "IX_FatPartDiet_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FatPartDiet",
                table: "FatPartDiet",
                columns: new[] { "FatPartId", "DietId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FatPartDiet_Diets_DietId",
                table: "FatPartDiet",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FatPartDiet_FatParts_FatPartId",
                table: "FatPartDiet",
                column: "FatPartId",
                principalTable: "FatParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
