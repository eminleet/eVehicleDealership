using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class RenameSlikeVozilaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikaVozila_Vozila_VoziloId",
                table: "SlikaVozila");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlikaVozila",
                table: "SlikaVozila");

            migrationBuilder.RenameTable(
                name: "SlikaVozila",
                newName: "SlikeVozila");

            migrationBuilder.RenameIndex(
                name: "IX_SlikaVozila_VoziloId",
                table: "SlikeVozila",
                newName: "IX_SlikeVozila_VoziloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlikeVozila",
                table: "SlikeVozila",
                column: "SlikaVozilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikeVozila_Vozila_VoziloId",
                table: "SlikeVozila",
                column: "VoziloId",
                principalTable: "Vozila",
                principalColumn: "VoziloId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikeVozila_Vozila_VoziloId",
                table: "SlikeVozila");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlikeVozila",
                table: "SlikeVozila");

            migrationBuilder.RenameTable(
                name: "SlikeVozila",
                newName: "SlikaVozila");

            migrationBuilder.RenameIndex(
                name: "IX_SlikeVozila_VoziloId",
                table: "SlikaVozila",
                newName: "IX_SlikaVozila_VoziloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlikaVozila",
                table: "SlikaVozila",
                column: "SlikaVozilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikaVozila_Vozila_VoziloId",
                table: "SlikaVozila",
                column: "VoziloId",
                principalTable: "Vozila",
                principalColumn: "VoziloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
