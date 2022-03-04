using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class plan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "MustBe",
                table: "SicknessFoods",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Diets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    Calorie = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDate_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetail",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    PlanDateId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<double>(type: "float", nullable: false),
                    MeelId = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    FailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => new { x.PlanDateId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_PlanDetail_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Meels_MeelId",
                        column: x => x.MeelId,
                        principalTable: "Meels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDetail_PlanDate_PlanDateId",
                        column: x => x.PlanDateId,
                        principalTable: "PlanDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_PlanId",
                table: "Diets",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_DietId",
                table: "Plan",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDate_PlanId",
                table: "PlanDate",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_FoodId",
                table: "PlanDetail",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_MeelId",
                table: "PlanDetail",
                column: "MeelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_UnitId",
                table: "PlanDetail",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Plan_PlanId",
                table: "Diets",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Plan_PlanId",
                table: "Diets");

            migrationBuilder.DropTable(
                name: "PlanDetail");

            migrationBuilder.DropTable(
                name: "PlanDate");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Diets_PlanId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Diets");

            migrationBuilder.AlterColumn<bool>(
                name: "MustBe",
                table: "SicknessFoods",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
