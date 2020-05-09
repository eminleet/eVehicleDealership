using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class RemoveSlikaFieldFromKorisniciEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Korisnici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
