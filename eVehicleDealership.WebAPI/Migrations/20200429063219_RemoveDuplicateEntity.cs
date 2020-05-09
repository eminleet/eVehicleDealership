using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class RemoveDuplicateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlikeVozila");

            migrationBuilder.DropColumn(
                name: "ImageArray",
                table: "SlikaVozila");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageArray",
                table: "SlikaVozila",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SlikeVozila",
                columns: table => new
                {
                    SlikaVozilaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoziloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikeVozila", x => x.SlikaVozilaId);
                    table.ForeignKey(
                        name: "FK_SlikeVozila_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlikeVozila_VoziloId",
                table: "SlikeVozila",
                column: "VoziloId");
        }
    }
}
