using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class DietFIVE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Calorie",
                table: "FoodUnits",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "Calcium",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrate",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Iron",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Magnesium",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Phosphor",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Potassium",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Sfa",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Sodium",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Sugar",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Tfa",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Umfa",
                table: "FoodUnits",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Upfa",
                table: "FoodUnits",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calcium",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Carbohydrate",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Iron",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Phosphor",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Potassium",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Sfa",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Sodium",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Sugar",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Tfa",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Umfa",
                table: "FoodUnits");

            migrationBuilder.DropColumn(
                name: "Upfa",
                table: "FoodUnits");

            migrationBuilder.AlterColumn<double>(
                name: "Calorie",
                table: "FoodUnits",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
