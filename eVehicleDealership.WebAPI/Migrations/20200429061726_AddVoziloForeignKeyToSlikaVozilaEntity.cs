using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class AddVoziloForeignKeyToSlikaVozilaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlikaVozila",
                columns: table => new
                {
                    SlikaVozilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    VoziloId = table.Column<int>(nullable: false),
                    ImageArray = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikaVozila", x => x.SlikaVozilaId);
                    table.ForeignKey(
                        name: "FK_SlikaVozila_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlikeVozila_VoziloId",
                table: "SlikeVozila",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikaVozila_VoziloId",
                table: "SlikaVozila",
                column: "VoziloId");

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

            migrationBuilder.DropTable(
                name: "SlikaVozila");

            migrationBuilder.DropIndex(
                name: "IX_SlikeVozila_VoziloId",
                table: "SlikeVozila");
        }
    }
}
