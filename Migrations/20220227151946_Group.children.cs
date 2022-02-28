using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Groupchildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentId",
                table: "Groups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_ParentId",
                table: "Groups",
                column: "ParentId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_ParentId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ParentId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Groups");
        }
    }
}
