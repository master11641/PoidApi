using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Diet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SleepRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    ActivityRateId = table.Column<int>(type: "int", nullable: false),
                    WaterRateRateId = table.Column<int>(type: "int", nullable: false),
                    SleepRateId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    SicknessDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllergyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityRateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakingMedicationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_ActivityRates_ActivityRateId",
                        column: x => x.ActivityRateId,
                        principalTable: "ActivityRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_SleepRates_SleepRateId",
                        column: x => x.SleepRateId,
                        principalTable: "SleepRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_WaterRates_WaterRateRateId",
                        column: x => x.WaterRateRateId,
                        principalTable: "WaterRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergyDiet",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyDiet", x => new { x.AllergyId, x.DietId });
                    table.ForeignKey(
                        name: "FK_AllergyDiet_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyDiet_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadHabitDiet",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    BadHabitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadHabitDiet", x => new { x.BadHabitId, x.DietId });
                    table.ForeignKey(
                        name: "FK_BadHabitDiet_BadHabits_BadHabitId",
                        column: x => x.BadHabitId,
                        principalTable: "BadHabits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BadHabitDiet_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FatPartDiet",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    FatPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FatPartDiet", x => new { x.FatPartId, x.DietId });
                    table.ForeignKey(
                        name: "FK_FatPartDiet_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FatPartDiet_FatParts_FatPartId",
                        column: x => x.FatPartId,
                        principalTable: "FatParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProteinDiets",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    ProteinId = table.Column<int>(type: "int", nullable: false),
                    ResponseValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinDiets", x => new { x.ProteinId, x.DietId });
                    table.ForeignKey(
                        name: "FK_ProteinDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProteinDiets_Proteins_ProteinId",
                        column: x => x.ProteinId,
                        principalTable: "Proteins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDiets",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ResponseValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDiets", x => new { x.QuestionId, x.DietId });
                    table.ForeignKey(
                        name: "FK_QuestionDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionDiets_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SicknessDiet",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    SicknessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicknessDiet", x => new { x.SicknessId, x.DietId });
                    table.ForeignKey(
                        name: "FK_SicknessDiet_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SicknessDiet_Sicknesses_SicknessId",
                        column: x => x.SicknessId,
                        principalTable: "Sicknesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyDiet_DietId",
                table: "AllergyDiet",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_BadHabitDiet_DietId",
                table: "BadHabitDiet",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_ActivityRateId",
                table: "Diets",
                column: "ActivityRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_GenderId",
                table: "Diets",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_GoalId",
                table: "Diets",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_SleepRateId",
                table: "Diets",
                column: "SleepRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_WaterRateRateId",
                table: "Diets",
                column: "WaterRateRateId");

            migrationBuilder.CreateIndex(
                name: "IX_FatPartDiet_DietId",
                table: "FatPartDiet",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinDiets_DietId",
                table: "ProteinDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDiets_DietId",
                table: "QuestionDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_SicknessDiet_DietId",
                table: "SicknessDiet",
                column: "DietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergyDiet");

            migrationBuilder.DropTable(
                name: "BadHabitDiet");

            migrationBuilder.DropTable(
                name: "FatPartDiet");

            migrationBuilder.DropTable(
                name: "ProteinDiets");

            migrationBuilder.DropTable(
                name: "QuestionDiets");

            migrationBuilder.DropTable(
                name: "SicknessDiet");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "SleepRates");

            migrationBuilder.DropTable(
                name: "WaterRates");
        }
    }
}
