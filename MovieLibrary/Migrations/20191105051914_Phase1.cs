using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary.Migrations
{
    public partial class Phase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "MoviesDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "MoviesDetails");
        }
    }
}
