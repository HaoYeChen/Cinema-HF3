using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class bio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    genreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.genreId);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ratingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ratingId);
                });

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    theaterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    seatings = table.Column<int>(nullable: false),
                    showtime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.theaterId);
                });

            migrationBuilder.CreateTable(
                name: "Zipcode",
                columns: table => new
                {
                    zipcodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipcode = table.Column<int>(nullable: false),
                    city = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zipcode", x => x.zipcodeId);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    showId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    showtime = table.Column<int>(nullable: false),
                    theaterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.showId);
                    table.ForeignKey(
                        name: "FK_Show_Theater_theaterId",
                        column: x => x.theaterId,
                        principalTable: "Theater",
                        principalColumn: "theaterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phonenumber = table.Column<int>(nullable: false),
                    zipcodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customer_Zipcode_zipcodeId",
                        column: x => x.zipcodeId,
                        principalTable: "Zipcode",
                        principalColumn: "zipcodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    movieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    runtime = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    releasedate = table.Column<DateTime>(nullable: false),
                    showId = table.Column<int>(nullable: true),
                    ratingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.movieId);
                    table.ForeignKey(
                        name: "FK_Movie_Rating_ratingId",
                        column: x => x.ratingId,
                        principalTable: "Rating",
                        principalColumn: "ratingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Show_showId",
                        column: x => x.showId,
                        principalTable: "Show",
                        principalColumn: "showId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    seatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    available = table.Column<bool>(nullable: false),
                    seat = table.Column<int>(nullable: false),
                    row = table.Column<int>(nullable: false),
                    showId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.seatId);
                    table.ForeignKey(
                        name: "FK_Seat_Show_showId",
                        column: x => x.showId,
                        principalTable: "Show",
                        principalColumn: "showId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    purchasedtime = table.Column<DateTime>(nullable: false),
                    customerId = table.Column<int>(nullable: true),
                    showId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Show_showId",
                        column: x => x.showId,
                        principalTable: "Show",
                        principalColumn: "showId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    movieId = table.Column<int>(nullable: false),
                    genreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.movieId, x.genreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_genreId",
                        column: x => x.genreId,
                        principalTable: "Genre",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_movieId",
                        column: x => x.movieId,
                        principalTable: "Movie",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_zipcodeId",
                table: "Customer",
                column: "zipcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ratingId",
                table: "Movie",
                column: "ratingId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_showId",
                table: "Movie",
                column: "showId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_genreId",
                table: "MovieGenre",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_customerId",
                table: "Order",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_showId",
                table: "Order",
                column: "showId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_showId",
                table: "Seat",
                column: "showId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_theaterId",
                table: "Show",
                column: "theaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropTable(
                name: "Zipcode");

            migrationBuilder.DropTable(
                name: "Theater");
        }
    }
}
