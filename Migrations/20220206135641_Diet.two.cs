using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Diettwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_ActivityRates_ActivityRateId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Genders_GenderId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_SleepRates_SleepRateId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_WaterRates_WaterRateRateId",
                table: "Diets");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Diets",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "WaterRateRateId",
                table: "Diets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SleepRateId",
                table: "Diets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "RequestComplete",
                table: "Diets",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Diets",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Diets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Age",
                table: "Diets",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityRateId",
                table: "Diets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_ActivityRates_ActivityRateId",
                table: "Diets",
                column: "ActivityRateId",
                principalTable: "ActivityRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Genders_GenderId",
                table: "Diets",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_SleepRates_SleepRateId",
                table: "Diets",
                column: "SleepRateId",
                principalTable: "SleepRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_WaterRates_WaterRateRateId",
                table: "Diets",
                column: "WaterRateRateId",
                principalTable: "WaterRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_ActivityRates_ActivityRateId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Genders_GenderId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_SleepRates_SleepRateId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_WaterRates_WaterRateRateId",
                table: "Diets");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Diets",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WaterRateRateId",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SleepRateId",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequestComplete",
                table: "Diets",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Diets",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Age",
                table: "Diets",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityRateId",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_ActivityRates_ActivityRateId",
                table: "Diets",
                column: "ActivityRateId",
                principalTable: "ActivityRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Genders_GenderId",
                table: "Diets",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_SleepRates_SleepRateId",
                table: "Diets",
                column: "SleepRateId",
                principalTable: "SleepRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_WaterRates_WaterRateRateId",
                table: "Diets",
                column: "WaterRateRateId",
                principalTable: "WaterRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
