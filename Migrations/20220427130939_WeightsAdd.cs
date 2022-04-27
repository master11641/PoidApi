using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class WeightsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Diets");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "WaterRates",
                newName: "WaterRates",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Units",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "Sports",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SportMuscles",
                newName: "SportMuscles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SportItems",
                newName: "SportItems",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SportGroups",
                newName: "SportGroups",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SleepRates",
                newName: "SleepRates",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SImages",
                newName: "SImages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SicknessFoods",
                newName: "SicknessFoods",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Sicknesses",
                newName: "Sicknesses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SicknessDiet",
                newName: "SicknessDiet",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ServicePackages",
                newName: "ServicePackages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Questions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "QuestionDiets",
                newName: "QuestionDiets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Proteins",
                newName: "Proteins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ProteinDiets",
                newName: "ProteinDiets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PodcastSicknesses",
                newName: "PodcastSicknesses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Podcasts",
                newName: "Podcasts",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PodcastQuestions",
                newName: "PodcastQuestions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PodcastGroups",
                newName: "PodcastGroups",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "Plans",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PlanDetails",
                newName: "PlanDetails",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PlanDates",
                newName: "PlanDates",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Nutrients",
                newName: "Nutrients",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Muscles",
                newName: "Muscles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Meels",
                newName: "Meels",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoices",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Groups",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Genders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FoodUnits",
                newName: "FoodUnits",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Foods",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FoodNutrients",
                newName: "FoodNutrients",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FoodMeels",
                newName: "FoodMeels",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FoodImages",
                newName: "FoodImages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FatParts",
                newName: "FatParts",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FatPartDiets",
                newName: "FatPartDiets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discounts",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Diets",
                newName: "Diets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BadHabits",
                newName: "BadHabits",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BadHabitDiet",
                newName: "BadHabitDiet",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AllergyDiet",
                newName: "AllergyDiet",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Allergies",
                newName: "Allergies",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ActivityRates",
                newName: "ActivityRates",
                newSchema: "dbo");

            migrationBuilder.CreateTable(
                name: "Weights",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserWeight = table.Column<double>(type: "float", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weights_Diets_DietId",
                        column: x => x.DietId,
                        principalSchema: "dbo",
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weights_DietId",
                schema: "dbo",
                table: "Weights",
                column: "DietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weights",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "WaterRates",
                schema: "dbo",
                newName: "WaterRates");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "dbo",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "Units",
                schema: "dbo",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Sports",
                schema: "dbo",
                newName: "Sports");

            migrationBuilder.RenameTable(
                name: "SportMuscles",
                schema: "dbo",
                newName: "SportMuscles");

            migrationBuilder.RenameTable(
                name: "SportItems",
                schema: "dbo",
                newName: "SportItems");

            migrationBuilder.RenameTable(
                name: "SportGroups",
                schema: "dbo",
                newName: "SportGroups");

            migrationBuilder.RenameTable(
                name: "SleepRates",
                schema: "dbo",
                newName: "SleepRates");

            migrationBuilder.RenameTable(
                name: "SImages",
                schema: "dbo",
                newName: "SImages");

            migrationBuilder.RenameTable(
                name: "SicknessFoods",
                schema: "dbo",
                newName: "SicknessFoods");

            migrationBuilder.RenameTable(
                name: "Sicknesses",
                schema: "dbo",
                newName: "Sicknesses");

            migrationBuilder.RenameTable(
                name: "SicknessDiet",
                schema: "dbo",
                newName: "SicknessDiet");

            migrationBuilder.RenameTable(
                name: "ServicePackages",
                schema: "dbo",
                newName: "ServicePackages");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "dbo",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Recipes",
                schema: "dbo",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "Questions",
                schema: "dbo",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "QuestionDiets",
                schema: "dbo",
                newName: "QuestionDiets");

            migrationBuilder.RenameTable(
                name: "Proteins",
                schema: "dbo",
                newName: "Proteins");

            migrationBuilder.RenameTable(
                name: "ProteinDiets",
                schema: "dbo",
                newName: "ProteinDiets");

            migrationBuilder.RenameTable(
                name: "PodcastSicknesses",
                schema: "dbo",
                newName: "PodcastSicknesses");

            migrationBuilder.RenameTable(
                name: "Podcasts",
                schema: "dbo",
                newName: "Podcasts");

            migrationBuilder.RenameTable(
                name: "PodcastQuestions",
                schema: "dbo",
                newName: "PodcastQuestions");

            migrationBuilder.RenameTable(
                name: "PodcastGroups",
                schema: "dbo",
                newName: "PodcastGroups");

            migrationBuilder.RenameTable(
                name: "Plans",
                schema: "dbo",
                newName: "Plans");

            migrationBuilder.RenameTable(
                name: "PlanDetails",
                schema: "dbo",
                newName: "PlanDetails");

            migrationBuilder.RenameTable(
                name: "PlanDates",
                schema: "dbo",
                newName: "PlanDates");

            migrationBuilder.RenameTable(
                name: "Nutrients",
                schema: "dbo",
                newName: "Nutrients");

            migrationBuilder.RenameTable(
                name: "Muscles",
                schema: "dbo",
                newName: "Muscles");

            migrationBuilder.RenameTable(
                name: "Meels",
                schema: "dbo",
                newName: "Meels");

            migrationBuilder.RenameTable(
                name: "Invoices",
                schema: "dbo",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Groups",
                schema: "dbo",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Goals",
                schema: "dbo",
                newName: "Goals");

            migrationBuilder.RenameTable(
                name: "Genders",
                schema: "dbo",
                newName: "Genders");

            migrationBuilder.RenameTable(
                name: "FoodUnits",
                schema: "dbo",
                newName: "FoodUnits");

            migrationBuilder.RenameTable(
                name: "Foods",
                schema: "dbo",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "FoodNutrients",
                schema: "dbo",
                newName: "FoodNutrients");

            migrationBuilder.RenameTable(
                name: "FoodMeels",
                schema: "dbo",
                newName: "FoodMeels");

            migrationBuilder.RenameTable(
                name: "FoodImages",
                schema: "dbo",
                newName: "FoodImages");

            migrationBuilder.RenameTable(
                name: "FatParts",
                schema: "dbo",
                newName: "FatParts");

            migrationBuilder.RenameTable(
                name: "FatPartDiets",
                schema: "dbo",
                newName: "FatPartDiets");

            migrationBuilder.RenameTable(
                name: "Discounts",
                schema: "dbo",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "Diets",
                schema: "dbo",
                newName: "Diets");

            migrationBuilder.RenameTable(
                name: "BadHabits",
                schema: "dbo",
                newName: "BadHabits");

            migrationBuilder.RenameTable(
                name: "BadHabitDiet",
                schema: "dbo",
                newName: "BadHabitDiet");

            migrationBuilder.RenameTable(
                name: "AllergyDiet",
                schema: "dbo",
                newName: "AllergyDiet");

            migrationBuilder.RenameTable(
                name: "Allergies",
                schema: "dbo",
                newName: "Allergies");

            migrationBuilder.RenameTable(
                name: "ActivityRates",
                schema: "dbo",
                newName: "ActivityRates");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Diets",
                type: "float",
                nullable: true);
        }
    }
}
