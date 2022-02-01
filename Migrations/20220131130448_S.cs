using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class S : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Group_GroupId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodImage_Food_FoodId",
                table: "FoodImage");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMeel_Food_FoodId",
                table: "FoodMeel");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMeel_Meel_MeelId",
                table: "FoodMeel");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodNutrient_Food_FoodId",
                table: "FoodNutrient");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodNutrient_Nutrient_NutrientId",
                table: "FoodNutrient");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodUnit_Food_FoodId",
                table: "FoodUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodUnit_Unit_UnitId",
                table: "FoodUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nutrient",
                table: "Nutrient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meel",
                table: "Meel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodUnit",
                table: "FoodUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodNutrient",
                table: "FoodNutrient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodMeel",
                table: "FoodMeel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Nutrient",
                newName: "Nutrients");

            migrationBuilder.RenameTable(
                name: "Meel",
                newName: "Meels");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "FoodUnit",
                newName: "FoodUnits");

            migrationBuilder.RenameTable(
                name: "FoodNutrient",
                newName: "foodNutrients");

            migrationBuilder.RenameTable(
                name: "FoodMeel",
                newName: "FoodMeels");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameIndex(
                name: "IX_FoodUnit_UnitId",
                table: "FoodUnits",
                newName: "IX_FoodUnits_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodNutrient_NutrientId",
                table: "foodNutrients",
                newName: "IX_foodNutrients_NutrientId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodMeel_MeelId",
                table: "FoodMeels",
                newName: "IX_FoodMeels_MeelId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_GroupId",
                table: "Foods",
                newName: "IX_Foods_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nutrients",
                table: "Nutrients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meels",
                table: "Meels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodUnits",
                table: "FoodUnits",
                columns: new[] { "FoodId", "UnitId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_foodNutrients",
                table: "foodNutrients",
                columns: new[] { "FoodId", "NutrientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodMeels",
                table: "FoodMeels",
                columns: new[] { "FoodId", "MeelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodImage_Foods_FoodId",
                table: "FoodImage",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMeels_Foods_FoodId",
                table: "FoodMeels",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMeels_Meels_MeelId",
                table: "FoodMeels",
                column: "MeelId",
                principalTable: "Meels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Groups_GroupId",
                table: "Foods",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodUnits_Foods_FoodId",
                table: "FoodUnits",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodUnits_Units_UnitId",
                table: "FoodUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodImage_Foods_FoodId",
                table: "FoodImage");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMeels_Foods_FoodId",
                table: "FoodMeels");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMeels_Meels_MeelId",
                table: "FoodMeels");

            migrationBuilder.DropForeignKey(
                name: "FK_foodNutrients_Foods_FoodId",
                table: "foodNutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_foodNutrients_Nutrients_NutrientId",
                table: "foodNutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Groups_GroupId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodUnits_Foods_FoodId",
                table: "FoodUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodUnits_Units_UnitId",
                table: "FoodUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nutrients",
                table: "Nutrients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meels",
                table: "Meels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodUnits",
                table: "FoodUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_foodNutrients",
                table: "foodNutrients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodMeels",
                table: "FoodMeels");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "Nutrients",
                newName: "Nutrient");

            migrationBuilder.RenameTable(
                name: "Meels",
                newName: "Meel");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "FoodUnits",
                newName: "FoodUnit");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "foodNutrients",
                newName: "FoodNutrient");

            migrationBuilder.RenameTable(
                name: "FoodMeels",
                newName: "FoodMeel");

            migrationBuilder.RenameIndex(
                name: "IX_FoodUnits_UnitId",
                table: "FoodUnit",
                newName: "IX_FoodUnit_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_GroupId",
                table: "Food",
                newName: "IX_Food_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_foodNutrients_NutrientId",
                table: "FoodNutrient",
                newName: "IX_FoodNutrient_NutrientId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodMeels_MeelId",
                table: "FoodMeel",
                newName: "IX_FoodMeel_MeelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nutrient",
                table: "Nutrient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meel",
                table: "Meel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodUnit",
                table: "FoodUnit",
                columns: new[] { "FoodId", "UnitId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodNutrient",
                table: "FoodNutrient",
                columns: new[] { "FoodId", "NutrientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodMeel",
                table: "FoodMeel",
                columns: new[] { "FoodId", "MeelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Group_GroupId",
                table: "Food",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodImage_Food_FoodId",
                table: "FoodImage",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMeel_Food_FoodId",
                table: "FoodMeel",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMeel_Meel_MeelId",
                table: "FoodMeel",
                column: "MeelId",
                principalTable: "Meel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodNutrient_Food_FoodId",
                table: "FoodNutrient",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodNutrient_Nutrient_NutrientId",
                table: "FoodNutrient",
                column: "NutrientId",
                principalTable: "Nutrient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodUnit_Food_FoodId",
                table: "FoodUnit",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodUnit_Unit_UnitId",
                table: "FoodUnit",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
