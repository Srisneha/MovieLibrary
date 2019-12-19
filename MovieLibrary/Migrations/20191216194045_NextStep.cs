using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary.Migrations
{
    public partial class NextStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "MoviesRental",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BuyAmount",
                table: "MoviesDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RentAmount",
                table: "MoviesDetails",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MoviesRental");

            migrationBuilder.DropColumn(
                name: "BuyAmount",
                table: "MoviesDetails");

            migrationBuilder.DropColumn(
                name: "RentAmount",
                table: "MoviesDetails");
        }
    }
}
