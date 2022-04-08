using Microsoft.EntityFrameworkCore.Migrations;

namespace LeitnerApi.Migrations
{
    public partial class Podcastone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podcasts_podcastGroups_PodcastGroupId",
                table: "Podcasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_podcastGroups",
                table: "podcastGroups");

            migrationBuilder.RenameTable(
                name: "podcastGroups",
                newName: "PodcastGroups");

            migrationBuilder.AddColumn<int>(
                name: "SportGroupId",
                table: "Sports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PodcastGroups",
                table: "PodcastGroups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_SportGroupId",
                table: "Sports",
                column: "SportGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Podcasts_PodcastGroups_PodcastGroupId",
                table: "Podcasts",
                column: "PodcastGroupId",
                principalTable: "PodcastGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_SportGroups_SportGroupId",
                table: "Sports",
                column: "SportGroupId",
                principalTable: "SportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podcasts_PodcastGroups_PodcastGroupId",
                table: "Podcasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_SportGroups_SportGroupId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_SportGroupId",
                table: "Sports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PodcastGroups",
                table: "PodcastGroups");

            migrationBuilder.DropColumn(
                name: "SportGroupId",
                table: "Sports");

            migrationBuilder.RenameTable(
                name: "PodcastGroups",
                newName: "podcastGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_podcastGroups",
                table: "podcastGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Podcasts_podcastGroups_PodcastGroupId",
                table: "Podcasts",
                column: "PodcastGroupId",
                principalTable: "podcastGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
