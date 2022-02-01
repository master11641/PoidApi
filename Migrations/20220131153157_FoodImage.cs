using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class FoodImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodImage_Foods_FoodId",
                table: "FoodImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodImage",
                table: "FoodImage");

            migrationBuilder.RenameTable(
                name: "FoodImage",
                newName: "FoodImages");

            migrationBuilder.RenameIndex(
                name: "IX_FoodImage_FoodId",
                table: "FoodImages",
                newName: "IX_FoodImages_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodImages",
                table: "FoodImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodImages_Foods_FoodId",
                table: "FoodImages",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodImages_Foods_FoodId",
                table: "FoodImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodImages",
                table: "FoodImages");

            migrationBuilder.RenameTable(
                name: "FoodImages",
                newName: "FoodImage");

            migrationBuilder.RenameIndex(
                name: "IX_FoodImages_FoodId",
                table: "FoodImage",
                newName: "IX_FoodImage_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodImage",
                table: "FoodImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodImage_Foods_FoodId",
                table: "FoodImage",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
