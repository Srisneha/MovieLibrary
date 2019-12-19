using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary.Migrations
{
    public partial class SecondStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RentAmount",
                table: "MoviesDetails",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "BuyAmount",
                table: "MoviesDetails",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RentAmount",
                table: "MoviesDetails",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "BuyAmount",
                table: "MoviesDetails",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
