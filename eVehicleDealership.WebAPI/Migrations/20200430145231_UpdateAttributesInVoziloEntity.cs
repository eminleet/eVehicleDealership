using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class UpdateAttributesInVoziloEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kubikaza",
                table: "Vozila",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Kubikaza",
                table: "Vozila",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
