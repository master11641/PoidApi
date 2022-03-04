using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class plantwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Plan_PlanId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Diets_DietId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDate_Plan_PlanId",
                table: "PlanDate");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_Foods_FoodId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_Meels_MeelId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_PlanDate_PlanDateId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_Units_UnitId",
                table: "PlanDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDetail",
                table: "PlanDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDate",
                table: "PlanDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.RenameTable(
                name: "PlanDetail",
                newName: "PlanDetails");

            migrationBuilder.RenameTable(
                name: "PlanDate",
                newName: "PlanDates");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "Plans");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_UnitId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_MeelId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_MeelId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_FoodId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDate_PlanId",
                table: "PlanDates",
                newName: "IX_PlanDates_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_DietId",
                table: "Plans",
                newName: "IX_Plans_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDetails",
                table: "PlanDetails",
                columns: new[] { "PlanDateId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDates",
                table: "PlanDates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Plans_PlanId",
                table: "Diets",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDates_Plans_PlanId",
                table: "PlanDates",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_Foods_FoodId",
                table: "PlanDetails",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_Meels_MeelId",
                table: "PlanDetails",
                column: "MeelId",
                principalTable: "Meels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_PlanDates_PlanDateId",
                table: "PlanDetails",
                column: "PlanDateId",
                principalTable: "PlanDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_Units_UnitId",
                table: "PlanDetails",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Diets_DietId",
                table: "Plans",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Plans_PlanId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDates_Plans_PlanId",
                table: "PlanDates");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_Foods_FoodId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_Meels_MeelId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_PlanDates_PlanDateId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_Units_UnitId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Diets_DietId",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDetails",
                table: "PlanDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDates",
                table: "PlanDates");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "Plan");

            migrationBuilder.RenameTable(
                name: "PlanDetails",
                newName: "PlanDetail");

            migrationBuilder.RenameTable(
                name: "PlanDates",
                newName: "PlanDate");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_DietId",
                table: "Plan",
                newName: "IX_Plan_DietId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_UnitId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_MeelId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_MeelId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_FoodId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDates_PlanId",
                table: "PlanDate",
                newName: "IX_PlanDate_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDetail",
                table: "PlanDetail",
                columns: new[] { "PlanDateId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDate",
                table: "PlanDate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Plan_PlanId",
                table: "Diets",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Diets_DietId",
                table: "Plan",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDate_Plan_PlanId",
                table: "PlanDate",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_Foods_FoodId",
                table: "PlanDetail",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_Meels_MeelId",
                table: "PlanDetail",
                column: "MeelId",
                principalTable: "Meels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_PlanDate_PlanDateId",
                table: "PlanDetail",
                column: "PlanDateId",
                principalTable: "PlanDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_Units_UnitId",
                table: "PlanDetail",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
