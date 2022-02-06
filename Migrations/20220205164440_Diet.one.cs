using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Dietone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foodNutrients_Foods_FoodId",
                table: "foodNutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_foodNutrients_Nutrients_NutrientId",
                table: "foodNutrients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_foodNutrients",
                table: "foodNutrients");

            migrationBuilder.RenameTable(
                name: "foodNutrients",
                newName: "FoodNutrients");

            migrationBuilder.RenameIndex(
                name: "IX_foodNutrients_NutrientId",
                table: "FoodNutrients",
                newName: "IX_FoodNutrients_NutrientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodNutrients",
                table: "FoodNutrients",
                columns: new[] { "FoodId", "NutrientId" });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_FoodId",
                table: "Recipes",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodNutrients_Foods_FoodId",
                table: "FoodNutrients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodNutrients_Nutrients_NutrientId",
                table: "FoodNutrients",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodNutrients_Foods_FoodId",
                table: "FoodNutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodNutrients_Nutrients_NutrientId",
                table: "FoodNutrients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodNutrients",
                table: "FoodNutrients");

            migrationBuilder.RenameTable(
                name: "FoodNutrients",
                newName: "foodNutrients");

            migrationBuilder.RenameIndex(
                name: "IX_FoodNutrients_NutrientId",
                table: "foodNutrients",
                newName: "IX_foodNutrients_NutrientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_foodNutrients",
                table: "foodNutrients",
                columns: new[] { "FoodId", "NutrientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_foodNutrients_Foods_FoodId",
                table: "foodNutrients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_foodNutrients_Nutrients_NutrientId",
                table: "foodNutrients",
                column: "NutrientId",
                principalTable: "Nutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
