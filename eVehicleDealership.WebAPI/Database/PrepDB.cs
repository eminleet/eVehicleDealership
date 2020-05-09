using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Database
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<eVehicleDealershipContext>());
            }
        }
        public static void SeedData(eVehicleDealershipContext context)
        {
            context.Database.Migrate();

            if (!context.Drzave.Any())
            {
                context.Drzave.AddRange(
                    new Drzava { DrzavaId = 1, Naziv = "Bosna i Hercegovina" },
                    new Drzava { DrzavaId = 2, Naziv = "Njemačka" },
                    new Drzava { DrzavaId = 3, Naziv = "Italija" },
                    new Drzava { DrzavaId = 4, Naziv = "Sjedinjene Američke Države" },
                    new Drzava { DrzavaId = 5, Naziv = "Hrvatska" }
                );

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Drzave ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Drzave OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Gradovi.Any())
            {
                context.Gradovi.AddRange(
                    new Grad { GradId = 1, DrzavaId = 1, Naziv = "Sarajevo" },
                    new Grad { GradId = 2, DrzavaId = 1, Naziv = "Mostar" },
                    new Grad { GradId = 3, DrzavaId = 1, Naziv = "Tuzla" },
                    new Grad { GradId = 4, DrzavaId = 1, Naziv = "Zenica" },
                    new Grad { GradId = 5, DrzavaId = 1, Naziv = "Bihać" },
                    new Grad { GradId = 6, DrzavaId = 1, Naziv = "Banja Luka" },
                    new Grad { GradId = 7, DrzavaId = 1, Naziv = "Gornji Vakuf - Uskoplje" },
                    new Grad { GradId = 8, DrzavaId = 1, Naziv = "Bugojno" },
                    new Grad { GradId = 9, DrzavaId = 1, Naziv = "Jablanica" },
                    new Grad { GradId = 10, DrzavaId = 1, Naziv = "Prozor" },

                    new Grad { GradId = 11, DrzavaId = 2, Naziv = "Berlin" },
                    new Grad { GradId = 12, DrzavaId = 2, Naziv = "Hamburg" },
                    new Grad { GradId = 13, DrzavaId = 2, Naziv = "Munich" },
                    new Grad { GradId = 14, DrzavaId = 2, Naziv = "Dortmund" },
                    new Grad { GradId = 15, DrzavaId = 2, Naziv = "Frankfurt" },
                    new Grad { GradId = 16, DrzavaId = 2, Naziv = "Stuttgart" },
                    new Grad { GradId = 17, DrzavaId = 2, Naziv = "Essen" },
                    new Grad { GradId = 18, DrzavaId = 2, Naziv = "Dresden" },
                    new Grad { GradId = 19, DrzavaId = 2, Naziv = "Leipzig" },
                    new Grad { GradId = 20, DrzavaId = 2, Naziv = "Hannover" },

                    new Grad { GradId = 21, DrzavaId = 3, Naziv = "Rim" },
                    new Grad { GradId = 22, DrzavaId = 3, Naziv = "Milano" },
                    new Grad { GradId = 23, DrzavaId = 3, Naziv = "Napulj" },
                    new Grad { GradId = 24, DrzavaId = 3, Naziv = "Torino" },
                    new Grad { GradId = 25, DrzavaId = 3, Naziv = "Palermo" },
                    new Grad { GradId = 26, DrzavaId = 3, Naziv = "Genova" },
                    new Grad { GradId = 27, DrzavaId = 3, Naziv = "Bologna" },
                    new Grad { GradId = 28, DrzavaId = 3, Naziv = "Firenca" },
                    new Grad { GradId = 29, DrzavaId = 3, Naziv = "Bari" },
                    new Grad { GradId = 30, DrzavaId = 3, Naziv = "Catania" },

                    new Grad { GradId = 31, DrzavaId = 4, Naziv = "New York" },
                    new Grad { GradId = 32, DrzavaId = 4, Naziv = "Los Angeles" },
                    new Grad { GradId = 33, DrzavaId = 4, Naziv = "Chicago" },
                    new Grad { GradId = 34, DrzavaId = 4, Naziv = "Houston" },
                    new Grad { GradId = 35, DrzavaId = 4, Naziv = "Phoenix" },
                    new Grad { GradId = 36, DrzavaId = 4, Naziv = "Philadelphia" },
                    new Grad { GradId = 37, DrzavaId = 4, Naziv = "San Antonio" },
                    new Grad { GradId = 38, DrzavaId = 4, Naziv = "Dallas" },
                    new Grad { GradId = 39, DrzavaId = 4, Naziv = "San Diego" },
                    new Grad { GradId = 40, DrzavaId = 4, Naziv = "San Jose" },

                    new Grad { GradId = 41, DrzavaId = 5, Naziv = "Zagreb" },
                    new Grad { GradId = 42, DrzavaId = 5, Naziv = "Split" },
                    new Grad { GradId = 43, DrzavaId = 5, Naziv = "Rijeka" },
                    new Grad { GradId = 44, DrzavaId = 5, Naziv = "Osijek" },
                    new Grad { GradId = 45, DrzavaId = 5, Naziv = "Zadar" },
                    new Grad { GradId = 46, DrzavaId = 5, Naziv = "Pula" },
                    new Grad { GradId = 47, DrzavaId = 5, Naziv = "Sesvete" },
                    new Grad { GradId = 48, DrzavaId = 5, Naziv = "Slavonski Brod" },
                    new Grad { GradId = 49, DrzavaId = 5, Naziv = "Dubrovnik" },
                    new Grad { GradId = 50, DrzavaId = 5, Naziv = "Varaždin" }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Gradovi ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Gradovi OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Kategorije.Any())
            {
                context.Kategorije.AddRange(
                    new Kategorija { KategorijaId = 1, Naziv = "Motocikli" },
                    new Kategorija { KategorijaId = 2, Naziv = "Automobili" },
                    new Kategorija { KategorijaId = 3, Naziv = "Teretna vozila" }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Kategorije ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Kategorije OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Korisnici.Any())
            {
                context.Korisnici.AddRange(
                    new Korisnik { KorisnikId = 1, Ime = "Administrator", Prezime = "Korisnik", Email = "admin@admin.com", Telefon = "061222333", LozinkaHash = "7sTUcOmpjnYDJXYHkqMXUDVOcvo=", LozinkaSalt = "zfA2LDlVPNZztwFPDU34FQ==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/adminPicture.jpg")) },
                    new Korisnik { KorisnikId = 2, Ime = "Uposlenik", Prezime = "Korisnik", Email = "uposlenik@uposlenik.com", Telefon = "061333444", LozinkaHash = "4/LX6m/CHq4xtPmI+qbgQcKl6Uk=", LozinkaSalt = "hH7ptlAteK32V0d+xaQBhw==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/uposlenikPicture.png")) },
                    new Korisnik { KorisnikId = 3, Ime = "Mobile", Prezime = "Korisnik", Email = "mobile@mobile.com", Telefon = "061444555", LozinkaHash = "ZCNPEGeVf1fxeu+/KBV3G1IQQjo=", LozinkaSalt = "Glpc8b0SqRrbnou2pGkgaQ==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/mobilePicture.png")) },
                    new Korisnik { KorisnikId = 4, Ime = "Seller", Prezime = "1", Email = "seller1@mobile.com", Telefon = "061555666", LozinkaHash = "VjFXJgjUoFAJPkprKizUgxudWdo=", LozinkaSalt = "dJTe6hiu+zahrHJ9pmWHEw==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller1.jpg")) },
                    new Korisnik { KorisnikId = 5, Ime = "Seller", Prezime = "2", Email = "seller2@mobile.com", Telefon = "061666777", LozinkaHash = "cnjF27dBis+wk7Bz5sx9ytw8sYU=", LozinkaSalt = "K7IgS3vPd9az59hcj+Z9TA==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller2.png")) },
                    new Korisnik { KorisnikId = 6, Ime = "Seller", Prezime = "3", Email = "seller3@mobile.com", Telefon = "061777888", LozinkaHash = "16Ky7zXqMXMxEgq5okh21lsJjRI=", LozinkaSalt = "djahqtiX0t0x9OAZABRyyg==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller3.png")) },
                    new Korisnik { KorisnikId = 7, Ime = "Seller", Prezime = "4", Email = "seller4@mobile.com", Telefon = "061888999", LozinkaHash = "mO5BIRELemuePsxIyn1z3SMqUbM=", LozinkaSalt = "CU4D2Aw8LCx3PKD7QT4byg==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller4.png")) },
                    new Korisnik { KorisnikId = 8, Ime = "Seller", Prezime = "5", Email = "seller5@mobile.com", Telefon = "062333444", LozinkaHash = "mEyuW8pO+eYrC7dsFjBwIIQgRCQ=", LozinkaSalt = "S0KE5tbORzvsWs8PecLSaA==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller5.png")) },
                    new Korisnik { KorisnikId = 9, Ime = "Seller", Prezime = "6", Email = "seller6@mobile.com", Telefon = "062444555", LozinkaHash = "/6+CxBka4e++stcIbKUvbHvcD68=", LozinkaSalt = "OthYZGp6O5C0SNRq4wjSFw==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller6.png")) },
                    new Korisnik { KorisnikId = 10, Ime = "Seller", Prezime = "7", Email = "seller7@mobile.com", Telefon = "062555666", LozinkaHash = "V1Gw6MStZ3cdtm1FF+warjpUte0=", LozinkaSalt = "OLcxDNfw3Wa0bJamJTTo7g==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller7.png")) },
                    new Korisnik { KorisnikId = 11, Ime = "Seller", Prezime = "8", Email = "seller8@mobile.com", Telefon = "062666777", LozinkaHash = "7mYsuxvoMQ6qsKiOejk63l+ajIE=", LozinkaSalt = "dDqKBjJaJrxRI4bK1erLWg==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller8.png")) },
                    new Korisnik { KorisnikId = 12, Ime = "Seller", Prezime = "9", Email = "seller9@mobile.com", Telefon = "062777888", LozinkaHash = "XUhM5Tm9jzo1ci1XXE3I9Yringo=", LozinkaSalt = "VkSdZDbvcNGVqojQwrP7Ug==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller9.jpg")) },
                    new Korisnik { KorisnikId = 13, Ime = "Seller", Prezime = "10", Email = "seller10@mobile.com", Telefon = "062888999", LozinkaHash = "yz2E8NKLWWCRy+YzIPT7bbq3uNk=", LozinkaSalt = "13LqABGjRDZvPJjb6qRS6A==", Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Seller10.jpg")) }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Korisnici ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Korisnici OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Uloge.Any())
            {
                context.Uloge.AddRange(
                    new Uloga { UlogaId = 1, Naziv = "Administrator" },
                    new Uloga { UlogaId = 2, Naziv = "Uposlenik" }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Uloge ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Uloge OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.KorisniciUloge.Any())
            {
                context.KorisniciUloge.AddRange(
                    new KorisnikUloga { KorisnikUlogaId = 1, KorisnikId = 1, UlogaId = 1, DatumIzmjene = new DateTime(2020, 5, 8) },
                    new KorisnikUloga { KorisnikUlogaId = 2, KorisnikId = 2, UlogaId = 2, DatumIzmjene = new DateTime(2020, 5, 8) }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.KorisniciUloge ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.KorisniciUloge OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Proizvodjaci.Any())
            {
                context.Proizvodjaci.AddRange(
                    new Proizvodjac { ProizvodjacId = 1, DrzavaId = 2, Naziv = "Volkswagen", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/VolkswagenLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 2, DrzavaId = 2, Naziv = "Mercedes-Benz", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/MercedesLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 3, DrzavaId = 2, Naziv = "BMW", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/BMWLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 4, DrzavaId = 2, Naziv = "Audi", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/AudiLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 5, DrzavaId = 2, Naziv = "Porsche", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/PorscheLogo.png")) },

                    new Proizvodjac { ProizvodjacId = 6, DrzavaId = 3, Naziv = "Maserati", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/MaseratiLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 7, DrzavaId = 3, Naziv = "Ferrari", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/FerrariLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 8, DrzavaId = 3, Naziv = "Lamborghini", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/LamborghiniLogo.png")) },

                    new Proizvodjac { ProizvodjacId = 9, DrzavaId = 4, Naziv = "Ford", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/FordLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 10, DrzavaId = 4, Naziv = "Tesla", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/TeslaLogo.png")) },
                    new Proizvodjac { ProizvodjacId = 11, DrzavaId = 4, Naziv = "Chevrolet", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/ChevroletLogo.png")) },

                    new Proizvodjac { ProizvodjacId = 12, DrzavaId = 5, Naziv = "Rimac Automobili", Logo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/RimacLogo.jpg")) }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Proizvodjaci ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Proizvodjaci OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Modeli.Any())
            {
                context.Modeli.AddRange(
                    new Model { ModelId = 1, ProizvodjacId = 1, Naziv = "Passat" },
                    new Model { ModelId = 2, ProizvodjacId = 1, Naziv = "Arteon" },
                    new Model { ModelId = 3, ProizvodjacId = 1, Naziv = "Tiguan" },
                    new Model { ModelId = 4, ProizvodjacId = 1, Naziv = "Golf" },
                    new Model { ModelId = 5, ProizvodjacId = 1, Naziv = "Amarok" },

                    new Model { ModelId = 6, ProizvodjacId = 2, Naziv = "Maybach" },
                    new Model { ModelId = 7, ProizvodjacId = 2, Naziv = "S-Class" },
                    new Model { ModelId = 8, ProizvodjacId = 2, Naziv = "G-Class" },
                    new Model { ModelId = 9, ProizvodjacId = 2, Naziv = "AMG GT" },
                    new Model { ModelId = 10, ProizvodjacId = 2, Naziv = "GLC-Class" },

                    new Model { ModelId = 11, ProizvodjacId = 3, Naziv = "i8" },
                    new Model { ModelId = 12, ProizvodjacId = 3, Naziv = "Z4" },
                    new Model { ModelId = 13, ProizvodjacId = 3, Naziv = "X5" },
                    new Model { ModelId = 14, ProizvodjacId = 3, Naziv = "X6" },
                    new Model { ModelId = 15, ProizvodjacId = 3, Naziv = "X7" },

                    new Model { ModelId = 16, ProizvodjacId = 4, Naziv = "R8" },
                    new Model { ModelId = 17, ProizvodjacId = 4, Naziv = "A4" },
                    new Model { ModelId = 18, ProizvodjacId = 4, Naziv = "Q5" },
                    new Model { ModelId = 19, ProizvodjacId = 4, Naziv = "A8" },
                    new Model { ModelId = 20, ProizvodjacId = 4, Naziv = "A7" },

                    new Model { ModelId = 21, ProizvodjacId = 5, Naziv = "911 Carrera" },
                    new Model { ModelId = 22, ProizvodjacId = 5, Naziv = "911 Turbo S" },
                    new Model { ModelId = 23, ProizvodjacId = 5, Naziv = "Panamera" },
                    new Model { ModelId = 24, ProizvodjacId = 5, Naziv = "Macan" },
                    new Model { ModelId = 25, ProizvodjacId = 5, Naziv = "Cayenne" },

                    new Model { ModelId = 26, ProizvodjacId = 6, Naziv = "Alfieri" },
                    new Model { ModelId = 27, ProizvodjacId = 6, Naziv = "Quattroporte" },
                    new Model { ModelId = 28, ProizvodjacId = 6, Naziv = "GranTurismo" },
                    new Model { ModelId = 29, ProizvodjacId = 6, Naziv = "Ghibli" },
                    new Model { ModelId = 30, ProizvodjacId = 6, Naziv = "Levante" },

                    new Model { ModelId = 31, ProizvodjacId = 7, Naziv = "Enzo" },
                    new Model { ModelId = 32, ProizvodjacId = 7, Naziv = "458 Italia" },
                    new Model { ModelId = 33, ProizvodjacId = 7, Naziv = "F12 Berlinetta" },
                    new Model { ModelId = 34, ProizvodjacId = 7, Naziv = "F8 Tributo" },
                    new Model { ModelId = 35, ProizvodjacId = 7, Naziv = "F8 Spider" },

                    new Model { ModelId = 36, ProizvodjacId = 8, Naziv = "Gallardo" },
                    new Model { ModelId = 37, ProizvodjacId = 8, Naziv = "Aventador" },
                    new Model { ModelId = 38, ProizvodjacId = 8, Naziv = "Diablo" },
                    new Model { ModelId = 39, ProizvodjacId = 8, Naziv = "Veneno" },
                    new Model { ModelId = 40, ProizvodjacId = 8, Naziv = "Huracan" },

                    new Model { ModelId = 41, ProizvodjacId = 9, Naziv = "Mustang" },
                    new Model { ModelId = 42, ProizvodjacId = 9, Naziv = "Fiesta" },
                    new Model { ModelId = 43, ProizvodjacId = 9, Naziv = "Focus" },
                    new Model { ModelId = 44, ProizvodjacId = 9, Naziv = "Taurus" },
                    new Model { ModelId = 45, ProizvodjacId = 9, Naziv = "Transit" },

                    new Model { ModelId = 46, ProizvodjacId = 3, Naziv = "S 1000 RR" },
                    new Model { ModelId = 47, ProizvodjacId = 3, Naziv = "R 1250 RS" },
                    new Model { ModelId = 48, ProizvodjacId = 3, Naziv = "K 1600 GT" },
                    new Model { ModelId = 49, ProizvodjacId = 3, Naziv = "S 1000 R" },
                    new Model { ModelId = 50, ProizvodjacId = 3, Naziv = "R 1250 GS" },

                    new Model { ModelId = 51, ProizvodjacId = 10, Naziv = "Model S" },
                    new Model { ModelId = 52, ProizvodjacId = 10, Naziv = "Model 3" },
                    new Model { ModelId = 53, ProizvodjacId = 10, Naziv = "Model X" },
                    new Model { ModelId = 54, ProizvodjacId = 10, Naziv = "Roadster" },
                    new Model { ModelId = 55, ProizvodjacId = 10, Naziv = "Cybertruck" },

                    new Model { ModelId = 56, ProizvodjacId = 11, Naziv = "Camaro" },
                    new Model { ModelId = 57, ProizvodjacId = 11, Naziv = "Corvette" },
                    new Model { ModelId = 58, ProizvodjacId = 11, Naziv = "Impala" },
                    new Model { ModelId = 59, ProizvodjacId = 11, Naziv = "Malibu" },
                    new Model { ModelId = 60, ProizvodjacId = 11, Naziv = "Blazer" },

                    new Model { ModelId = 61, ProizvodjacId = 12, Naziv = "Concept One" },

                    new Model { ModelId = 62, ProizvodjacId = 2, Naziv = "Actros" },
                    new Model { ModelId = 63, ProizvodjacId = 1, Naziv = "Transporter" }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Modeli ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Modeli OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Vozila.Any())
            {
                context.Vozila.AddRange(
                  new Vozilo { VoziloId = 1, ModelId = 1, Naziv = "Passat B8 2.0 TDI PANORAMA", Opis = "REGISTROVANO DO 11/2020 | AUTO U EXTRA STANJU, BEZ IKAKVOG ULAGANJA | DOZVOLJENE SVE PROVJERE ISKLJUČIVO U OVLAŠTENOM SERVISU!", Cijena = 17500, Transmisija = "Manuelni", Gorivo = "Dizel", GodinaProizvodnje = 2015, Boja = "Crna", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now.AddDays(-5), GradId = 2, KorisnikId = 3, KategorijaId = 2, KonjskihSnaga = 190, Kubikaza = "2.0", Istaknuto = true },
                  new Vozilo { VoziloId = 2, ModelId = 6, Naziv = "Mercedes Benz S 550 560 4M Maybach", Opis = "Obsidian crna metalik boja | Exclusive nappa koza, crna-porcelain koža | 9 - stepeni automatski mjenjač | Driving Assistance paket", Cijena = 198000, Transmisija = "Automatik", Gorivo = "Benzin", GodinaProizvodnje = 2019, Boja = "Crna", Stanje = "Novo", DatumPostavljanja = DateTime.Now.AddDays(-10), GradId = 2, KorisnikId = 3, KategorijaId = 2, KonjskihSnaga = 469, Kubikaza = "5.0", Istaknuto = true },
                  new Vozilo { VoziloId = 3, ModelId = 19, Naziv = "AUDI A8 50TDI 330 KS QUATTRO", Opis = "Vozilo u odličnom stanju i prošlo sve dijagnostičke preglede, a u ruke novih vlasnika dolazi uz niz garancija. Nakon kupovine nisu potrebna dodatna ulaganja.", Cijena = 80000, Transmisija = "Automatik", Gorivo = "Dizel", GodinaProizvodnje = 2018, Boja = "Crna", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 2, KorisnikId = 3, KategorijaId = 2, KonjskihSnaga = 330, Kubikaza = "3.0", Istaknuto = false },

                  new Vozilo { VoziloId = 4, ModelId = 63, Naziv = "Volkswagen Transporter T6 2.0 TDI", Opis = "Više informacija o proizvodu možete dobiti pozivom na telefon ili poslati upit na e-mail", Cijena = 17000, Transmisija = "Manuelni", Gorivo = "Dizel", GodinaProizvodnje = 2015, Boja = "Crna", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 5, KorisnikId = 4, KategorijaId = 3, KonjskihSnaga = 102, Kubikaza = "2.0", Istaknuto = false },
                  new Vozilo { VoziloId = 5, ModelId = 14, Naziv = "BMW X6 M", Opis = "Auto u odličnom stanju.", Cijena = 80000, Transmisija = "Automatik", Gorivo = "Benzin", GodinaProizvodnje = 2015, Boja = "Bijela", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 5, KorisnikId = 4, KategorijaId = 2, KonjskihSnaga = 575, Kubikaza = "4.4", Istaknuto = true },

                  new Vozilo { VoziloId = 6, ModelId = 18, Naziv = "Audi Q5 40 TDI quattro S-tronic Sport", Opis = "Kupite svoje vozilo na odgodu uz Leasing. Za više info o uvjetima kupovine na Leasing kontaktirajte nas.", Cijena = 60000, Transmisija = "Automatik", Gorivo = "Dizel", GodinaProizvodnje = 2019, Boja = "Crna", Stanje = "Novo", DatumPostavljanja = DateTime.Now.AddDays(-3), GradId = 17, KorisnikId = 5, KategorijaId = 2, KonjskihSnaga = 190, Kubikaza = "2.0", Istaknuto = true },
                  new Vozilo { VoziloId = 7, ModelId = 46, Naziv = "BMW S1000rr 1000 cm3", Opis = "Prodaje se motocikl bmw s 1000rr u odličnom stanju bez padova, redovno servisiran.", Cijena = 13500, Transmisija = "Manuelni", Gorivo = "Benzin", GodinaProizvodnje = 2015, Boja = "Crvena", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 20, KorisnikId = 5, KategorijaId = 1, KonjskihSnaga = 150, Kubikaza = "1800", Istaknuto = false },

                  new Vozilo { VoziloId = 8, ModelId = 50, Naziv = "BMW R 1250 GS", Opis = "Full oprema.", Cijena = 18300, Transmisija = "Manuelni", Gorivo = "Benzin", GodinaProizvodnje = 2019, Boja = "Crvena", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 30, KorisnikId = 6, KategorijaId = 1, KonjskihSnaga = 110, Kubikaza = "1250", Istaknuto = false },

                  new Vozilo { VoziloId = 9, ModelId = 33, Naziv = "Ferrari 488 GTB Pista F1", Opis = "3 Godine Garancije i 7 godina service", Cijena = 400000, Transmisija = "Automatik", Gorivo = "Benzin", GodinaProizvodnje = 2019, Boja = "Srebrena", Stanje = "Novo", DatumPostavljanja = DateTime.Now, GradId = 40, KorisnikId = 7, KategorijaId = 2, KonjskihSnaga = 721, Kubikaza = "3.9", Istaknuto = true },

                  new Vozilo { VoziloId = 10, ModelId = 56, Naziv = "Chevrolet Camaro ZL1", Opis = "Moze zamjena za stan ili poslovni prostor u Sarajevu.", Cijena = 45000, Transmisija = "Automatik", Gorivo = "Benzin", GodinaProizvodnje = 2017, Boja = "Crna", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now.AddDays(-10), GradId = 1, KorisnikId = 8, KategorijaId = 2, KonjskihSnaga = 620, Kubikaza = "6.2", Istaknuto = false },

                  new Vozilo { VoziloId = 11, ModelId = 43, Naziv = "NOVI Ford Focus 1.0 EcoBoost", Opis = "Za sve dodatne informacije pozovite nas na dolje navedeni brojeve telefona", Cijena = 25000, Transmisija = "Manuelni", Gorivo = "Benzin", GodinaProizvodnje = 2018, Boja = "Plava", Stanje = "Novo", DatumPostavljanja = DateTime.Now.AddDays(-7), GradId = 1, KorisnikId = 9, KategorijaId = 2, KonjskihSnaga = 125, Kubikaza = "1.0", Istaknuto = false },

                  new Vozilo { VoziloId = 12, ModelId = 62, Naziv = "Mercedes-Benz Actros 41-50", Opis = "Prvi vlasnik | Prešao 150 000 km | Srednja kabina-sa krevetom", Cijena = 80000, Transmisija = "Polu-automatik", Gorivo = "Dizel", GodinaProizvodnje = 2007, Boja = "Srebrena", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now.AddDays(-2), GradId = 6, KorisnikId = 10, KategorijaId = 3, KonjskihSnaga = 500, Kubikaza = "6.0", Istaknuto = false },

                  new Vozilo { VoziloId = 13, ModelId = 21, Naziv = "PORSCHE CARRERA 4S", Opis = "PORSCHE GARANCIJA 2 godine", Cijena = 150000, Transmisija = "Automatik", Gorivo = "Benzin", GodinaProizvodnje = 2020, Boja = "Bijela", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 45, KorisnikId = 11, KategorijaId = 2, KonjskihSnaga = 450, Kubikaza = "3.0", Istaknuto = true },

                  new Vozilo { VoziloId = 14, ModelId = 11, Naziv = "BMW i8 Coupe PHEV Range Extender", Opis = "Cijena bez troškova uvoza.", Cijena = 90000, Transmisija = "Automatik", Gorivo = "Hibrid", GodinaProizvodnje = 2017, Boja = "Siva", Stanje = "Korišteno", DatumPostavljanja = DateTime.Now, GradId = 12, KorisnikId = 12, KategorijaId = 2, KonjskihSnaga = 362, Kubikaza = "1.5", Istaknuto = false }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Vozila ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Vozila OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.SlikeVozila.Any())
            {
                context.SlikeVozila.AddRange(
                    new SlikaVozila { SlikaVozilaId = 1, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_1.jpg")) },
                    new SlikaVozila { SlikaVozilaId = 2, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_2.jpg")) },
                    new SlikaVozila { SlikaVozilaId = 3, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_3.jpg")) },
                    new SlikaVozila { SlikaVozilaId = 4, VoziloId = 1, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo1_4.jpg")) },

                    new SlikaVozila { SlikaVozilaId = 5, VoziloId = 2, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo2_1.jpg")) },

                    new SlikaVozila { SlikaVozilaId = 6, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 7, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_2.png")) },
                    new SlikaVozila { SlikaVozilaId = 8, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_3.png")) },
                    new SlikaVozila { SlikaVozilaId = 10, VoziloId = 3, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo3_4.png")) },

                    new SlikaVozila { SlikaVozilaId = 11, VoziloId = 4, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo4_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 12, VoziloId = 4, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo4_2.png")) },

                    new SlikaVozila { SlikaVozilaId = 13, VoziloId = 5, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo5_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 14, VoziloId = 5, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo5_2.png")) },
                    new SlikaVozila { SlikaVozilaId = 15, VoziloId = 5, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo5_3.png")) },

                    new SlikaVozila { SlikaVozilaId = 16, VoziloId = 6, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo6_1.png")) },

                    new SlikaVozila { SlikaVozilaId = 17, VoziloId = 7, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo7_1.jpg")) },
                    new SlikaVozila { SlikaVozilaId = 18, VoziloId = 7, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo7_2.png")) },

                    new SlikaVozila { SlikaVozilaId = 19, VoziloId = 8, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo8_1.jpg")) },

                    new SlikaVozila { SlikaVozilaId = 20, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 21, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_2.png")) },
                    new SlikaVozila { SlikaVozilaId = 22, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_3.png")) },
                    new SlikaVozila { SlikaVozilaId = 23, VoziloId = 9, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo9_4.png")) },

                    new SlikaVozila { SlikaVozilaId = 24, VoziloId = 10, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo10_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 25, VoziloId = 10, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo10_2.png")) },

                    new SlikaVozila { SlikaVozilaId = 26, VoziloId = 11, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo11_1.png")) },

                    new SlikaVozila { SlikaVozilaId = 27, VoziloId = 12, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo12_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 28, VoziloId = 12, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo12_2.png")) },

                    new SlikaVozila { SlikaVozilaId = 29, VoziloId = 13, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo13_1.png")) },
                    new SlikaVozila { SlikaVozilaId = 30, VoziloId = 13, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo13_2.png")) },
                    new SlikaVozila { SlikaVozilaId = 31, VoziloId = 13, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo13_3.png")) },

                    new SlikaVozila { SlikaVozilaId = 32, VoziloId = 14, Slika = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/Vozilo14_1.png")) }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SlikeVozila ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SlikeVozila OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            if (!context.Ocjene.Any())
            {
                context.Ocjene.AddRange(
                    new Ocjena { OcjenaId = 1, KorisnikId = 3, VoziloId = 1, DataOcjena = 5 },
                    new Ocjena { OcjenaId = 2, KorisnikId = 3, VoziloId = 2, DataOcjena = 5 },
                    new Ocjena { OcjenaId = 3, KorisnikId = 3, VoziloId = 4, DataOcjena = 3 },
                    new Ocjena { OcjenaId = 4, KorisnikId = 3, VoziloId = 13, DataOcjena = 5 },

                    new Ocjena { OcjenaId = 5, KorisnikId = 4, VoziloId = 1, DataOcjena = 4 },
                    new Ocjena { OcjenaId = 6, KorisnikId = 4, VoziloId = 2, DataOcjena = 5 },
                    new Ocjena { OcjenaId = 7, KorisnikId = 4, VoziloId = 4, DataOcjena = 3 },
                    new Ocjena { OcjenaId = 8, KorisnikId = 4, VoziloId = 13, DataOcjena = 5 },

                    new Ocjena { OcjenaId = 9, KorisnikId = 5, VoziloId = 3, DataOcjena = 4 },

                    new Ocjena { OcjenaId = 10, KorisnikId = 6, VoziloId = 5, DataOcjena = 4 },

                    new Ocjena { OcjenaId = 11, KorisnikId = 7, VoziloId = 6, DataOcjena = 4 },

                    new Ocjena { OcjenaId = 12, KorisnikId = 8, VoziloId = 12, DataOcjena = 2 }
                );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ocjene ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ocjene OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }
        }
    }
}
