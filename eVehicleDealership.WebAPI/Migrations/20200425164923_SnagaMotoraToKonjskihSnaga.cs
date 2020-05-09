using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class SnagaMotoraToKonjskihSnaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnagaMotora",
                table: "Vozila");

            migrationBuilder.AddColumn<int>(
                name: "KonjskihSnaga",
                table: "Vozila",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KonjskihSnaga",
                table: "Vozila");

            migrationBuilder.AddColumn<string>(
                name: "SnagaMotora",
                table: "Vozila",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
