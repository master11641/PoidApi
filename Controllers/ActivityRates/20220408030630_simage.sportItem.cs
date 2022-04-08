using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class simagesportItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportItemImages");

            migrationBuilder.AddColumn<int>(
                name: "SportItemId",
                table: "SImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SImages_SportItemId",
                table: "SImages",
                column: "SportItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SImages_SportItems_SportItemId",
                table: "SImages",
                column: "SportItemId",
                principalTable: "SportItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SImages_SportItems_SportItemId",
                table: "SImages");

            migrationBuilder.DropIndex(
                name: "IX_SImages_SportItemId",
                table: "SImages");

            migrationBuilder.DropColumn(
                name: "SportItemId",
                table: "SImages");

            migrationBuilder.CreateTable(
                name: "SportItemImages",
                columns: table => new
                {
                    SportItemId = table.Column<int>(type: "int", nullable: false),
                    SImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportItemImages", x => new { x.SportItemId, x.SImageId });
                    table.ForeignKey(
                        name: "FK_SportItemImages_SImages_SImageId",
                        column: x => x.SImageId,
                        principalTable: "SImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportItemImages_SportItems_SportItemId",
                        column: x => x.SportItemId,
                        principalTable: "SportItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportItemImages_SImageId",
                table: "SportItemImages",
                column: "SImageId");
        }
    }
}
