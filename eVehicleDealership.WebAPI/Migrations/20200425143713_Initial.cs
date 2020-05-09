using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    GradId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.GradId);
                    table.ForeignKey(
                        name: "FK_Gradovi_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjaci",
                columns: table => new
                {
                    ProizvodjacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjaci", x => x.ProizvodjacId);
                    table.ForeignKey(
                        name: "FK_Proizvodjaci_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisnikUlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    UlogaId = table.Column<int>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisnikUlogaId);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloge_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modeli",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodjacId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeli", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Modeli_Proizvodjaci_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjaci",
                        principalColumn: "ProizvodjacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozila",
                columns: table => new
                {
                    VoziloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: false),
                    Transmisija = table.Column<string>(nullable: false),
                    Gorivo = table.Column<string>(nullable: false),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    SnagaMotora = table.Column<string>(nullable: false),
                    Boja = table.Column<string>(nullable: false),
                    Stanje = table.Column<string>(nullable: false),
                    DatumPostavljanja = table.Column<DateTime>(nullable: false),
                    GradId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozila", x => x.VoziloId);
                    table.ForeignKey(
                        name: "FK_Vozila_Gradovi_GradId",
                        column: x => x.GradId,
                        principalTable: "Gradovi",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozila_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozila_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozila_Modeli_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Modeli",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DodatnaOprema",
                columns: table => new
                {
                    DodatnaOpremaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false),
                    VoziloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatnaOprema", x => x.DodatnaOpremaId);
                    table.ForeignKey(
                        name: "FK_DodatnaOprema_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjenaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoziloId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    DataOcjena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjenaId);
                    table.ForeignKey(
                        name: "FK_Ocjene_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjene_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DodatnaOprema_VoziloId",
                table: "DodatnaOprema",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi_DrzavaId",
                table: "Gradovi",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikId",
                table: "KorisniciUloge",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaId",
                table: "KorisniciUloge",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Modeli_ProizvodjacId",
                table: "Modeli",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_KorisnikId",
                table: "Ocjene",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_VoziloId",
                table: "Ocjene",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjaci_DrzavaId",
                table: "Proizvodjaci",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozila_GradId",
                table: "Vozila",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozila_KategorijaId",
                table: "Vozila",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozila_KorisnikId",
                table: "Vozila",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozila_ModelId",
                table: "Vozila",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DodatnaOprema");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Vozila");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Modeli");

            migrationBuilder.DropTable(
                name: "Proizvodjaci");

            migrationBuilder.DropTable(
                name: "Drzave");
        }
    }
}
