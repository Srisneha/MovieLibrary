using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoviesDetails",
                columns: table => new
                {
                    TrackNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieName = table.Column<string>(nullable: false),
                    ReleasedYear = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Availability = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackNumber", x => x.TrackNumber);
                });

            migrationBuilder.CreateTable(
                name: "MoviesRental",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieName = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    ReleasedYear = table.Column<int>(nullable: false),
                    RentalType = table.Column<int>(nullable: false),
                    TrackNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalID", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_MoviesRental_MoviesDetails_TrackNumber",
                        column: x => x.TrackNumber,
                        principalTable: "MoviesDetails",
                        principalColumn: "TrackNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesRental_TrackNumber",
                table: "MoviesRental",
                column: "TrackNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesRental");

            migrationBuilder.DropTable(
                name: "MoviesDetails");
        }
    }
}
