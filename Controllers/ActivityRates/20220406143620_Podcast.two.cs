using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Podcasttwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PodcastQuestions",
                columns: table => new
                {
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastQuestions", x => new { x.PodcastId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_PodcastQuestions_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastSicknesses",
                columns: table => new
                {
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    SicknessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastSicknesses", x => new { x.PodcastId, x.SicknessId });
                    table.ForeignKey(
                        name: "FK_PodcastSicknesses_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastSicknesses_Sicknesses_SicknessId",
                        column: x => x.SicknessId,
                        principalTable: "Sicknesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PodcastQuestions_QuestionId",
                table: "PodcastQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastSicknesses_SicknessId",
                table: "PodcastSicknesses",
                column: "SicknessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastQuestions");

            migrationBuilder.DropTable(
                name: "PodcastSicknesses");
        }
    }
}
