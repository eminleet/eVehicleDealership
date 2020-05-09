using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class UpdateKubikazaAttributeInVoziloEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Kubikaza",
                table: "Vozila",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kubikaza",
                table: "Vozila",
                type: "decimal(5,1)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
