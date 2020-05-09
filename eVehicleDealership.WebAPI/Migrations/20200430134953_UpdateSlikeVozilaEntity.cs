using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class UpdateSlikeVozilaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SlikeVozila");

            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "SlikeVozila",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "SlikeVozila");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SlikeVozila",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
