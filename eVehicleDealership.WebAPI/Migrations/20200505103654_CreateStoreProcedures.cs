using Microsoft.EntityFrameworkCore.Migrations;

namespace eVehicleDealership.WebAPI.Migrations
{
    public partial class CreateStoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure1 = @"CREATE PROCEDURE OglasiByDate
                             (
                             @FromDate DATETIME,
                             @ToDate DATETIME
                             )
                             AS
                             BEGIN
                             SELECT Vozila.Naziv, Proizvodjaci.Naziv AS Proizvođač, Modeli.Naziv AS Model, Kategorije.Naziv AS Kategorija, Vozila.GodinaProizvodnje AS Godište, CONVERT(INT, Vozila.Cijena) AS Cijena, Korisnici.Ime + ' ' + Korisnici.Prezime AS Korisnik, Gradovi.Naziv AS Lokacija, FORMAT(DatumPostavljanja, 'dd/MM/yyyy') AS DatumPostavljanja
                             FROM Korisnici INNER JOIN
                             Gradovi INNER JOIN
                             Proizvodjaci INNER JOIN
                             Modeli ON Proizvodjaci.ProizvodjacId = Modeli.ProizvodjacId INNER JOIN
                             Vozila ON Modeli.ModelId = Vozila.ModelId ON Gradovi.GradId = Vozila.GradId ON Korisnici.KorisnikId = Vozila.KorisnikId INNER JOIN
                             Kategorije ON Vozila.KategorijaId = Kategorije.KategorijaId
                             WHERE DatumPostavljanja BETWEEN @FromDate AND @ToDate
                             ORDER BY DatumPostavljanja ASC
                             END";

            var procedure2 = @"CREATE PROCEDURE NajskupljaVozila
                             (
                             @Kategorija NVARCHAR(MAX)=null
                             )
                             AS
                             BEGIN
                             SELECT TOP 10 WITH TIES Proizvodjaci.Naziv AS Proizvođač, Modeli.Naziv AS Model, Kategorije.Naziv AS Kategorija, Vozila.GodinaProizvodnje AS Godište, CONVERT(INT, Vozila.Cijena) AS Cijena, Vozila.Gorivo, Vozila.Kubikaza AS Kubikaža, Vozila.KonjskihSnaga, Vozila.Boja, Korisnici.Ime + ' '  + Korisnici.Prezime AS Korisnik, Gradovi.Naziv AS Lokacija
                             FROM Korisnici INNER JOIN
                             Gradovi INNER JOIN
                             Proizvodjaci INNER JOIN
                             Modeli ON Proizvodjaci.ProizvodjacId = Modeli.ProizvodjacId INNER JOIN
                             Vozila ON Modeli.ModelId = Vozila.ModelId ON Gradovi.GradId = Vozila.GradId ON Korisnici.KorisnikId = Vozila.KorisnikId INNER JOIN
                             Kategorije ON Vozila.KategorijaId = Kategorije.KategorijaId
					         WHERE (Kategorije.Naziv = @Kategorija OR @Kategorija IS NULL)
                             ORDER BY Vozila.Cijena DESC
                             END";

            var procedure3 = @"CREATE PROCEDURE KorisniciSaNajviseOglasa
                             AS
                             BEGIN
                             SELECT TOP 10 WITH TIES Korisnici.Ime + ' ' + Korisnici.Prezime AS Korisnik, Korisnici.Email, Korisnici.Telefon, COUNT(Vozila.KorisnikId) AS BrojOglasa
                             FROM Korisnici INNER JOIN Vozila ON Korisnici.KorisnikId = Vozila.KorisnikId
                             GROUP BY Korisnici.Ime + ' ' + Korisnici.Prezime, Korisnici.Email, Korisnici.Telefon
                             ORDER BY BrojOglasa DESC
                             END";

            migrationBuilder.Sql(procedure1);
            migrationBuilder.Sql(procedure2);
            migrationBuilder.Sql(procedure3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
