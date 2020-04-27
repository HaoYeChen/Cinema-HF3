using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class movieshow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Show_showId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_showId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "showId",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "movieId",
                table: "Show",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Show_movieId",
                table: "Show",
                column: "movieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_movieId",
                table: "Show",
                column: "movieId",
                principalTable: "Movie",
                principalColumn: "movieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_movieId",
                table: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Show_movieId",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "movieId",
                table: "Show");

            migrationBuilder.AddColumn<int>(
                name: "showId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_showId",
                table: "Movie",
                column: "showId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Show_showId",
                table: "Movie",
                column: "showId",
                principalTable: "Show",
                principalColumn: "showId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
