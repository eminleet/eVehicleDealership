using AutoMapper;
using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Database;
using eVehicleDealership.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly eVehicleDealershipContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public KorisniciService(eVehicleDealershipContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public Modeli.Korisnik Authenticate(string email, string password)
        {
            var user = _context.Korisnici.Include("KorisnikUloga.Uloga").FirstOrDefault(x => x.Email == email);

            // return null ako korisnik nije pronađen
            if (user == null)
                return null;

            var newHash = GenerateHash(user.LozinkaSalt, password);
            if (newHash == user.LozinkaHash)
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.KorisnikId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                foreach (var role in user.KorisnikUloga)
                {
                    claims.Append(new Claim(ClaimTypes.Role, role.Uloga.Naziv));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var korisnik = _mapper.Map<Modeli.Korisnik>(user);
                korisnik.Token = tokenString;
                korisnik.Token_Expiration_Time = token.ValidTo;

                return korisnik;
            }

            return null;
        }

        public IList<Modeli.Korisnik> Get(KorisnikSearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            return _mapper.Map<List<Modeli.Korisnik>>(query.ToList());
        }

        public Modeli.Korisnik GetById(int id)
        {
            var user = _context.Korisnici.FirstOrDefault(x => x.KorisnikId == id);
            if (user == null)
            {
                return new Modeli.Korisnik();
            }

            var result = new Modeli.Korisnik
            {
                Ime = user.Ime,
                Prezime = user.Prezime,
                Email = user.Email,
                Slika = user.Slika,
                KorisnikId = user.KorisnikId,
                Telefon = user.Telefon
            };

            var korisnikUloge = _context.KorisniciUloge.Where(x => x.KorisnikId == id);
            if (korisnikUloge.Count() > 0)
            {
                result.Uloge = new List<Modeli.Uloga>();
                foreach (var uloga in korisnikUloge.Include(x => x.Uloga))
                {
                    result.Uloge.Add(new Modeli.Uloga { UlogaId = uloga.UlogaId, Naziv = uloga.Uloga.Naziv });
                }
            }

            return result;
        }

        public Modeli.Korisnik Insert(KorisnikInsertRequest request)
        {
            if (_context.Korisnici.Any(x => x.Email == request.Email))
            {
                throw new UserException("Email \"" + request.Email + "\" je već zauzet!");
            }

            var entity = _mapper.Map<Korisnik>(request);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            if (request.Uloge != null && request.Uloge.Count() > 0 && request.Uloge[0] != 0)
            {
                foreach (var uloga in request.Uloge)
                {
                    _context.KorisniciUloge.Add(new KorisnikUloga
                    {
                        UlogaId = uloga,
                        KorisnikId = entity.KorisnikId,
                        DatumIzmjene = DateTime.Now
                    });
                }
            }
            _context.SaveChanges();

            return _mapper.Map<Modeli.Korisnik>(entity);
        }

        public Modeli.Korisnik Update(int id, KorisnikInsertRequest request)
        {
            var entity = _context.Korisnici.Include(x => x.KorisnikUloga).FirstOrDefault(x => x.KorisnikId == id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);
            _context.SaveChanges();

            var korisnikUloge = _context.KorisniciUloge.Where(x => x.KorisnikId == entity.KorisnikId);
            if (request.Uloge.Count() < korisnikUloge.Count())
            {
                foreach (var uloga in korisnikUloge)
                {
                    if (!request.Uloge.Contains(uloga.UlogaId))
                    {
                        _context.KorisniciUloge.Remove(uloga);
                    }
                }
            }

            if (request.Uloge != null && request.Uloge.Count() > 0 && request.Uloge[0] != 0)
            {
                foreach (var uloga in request.Uloge)
                {
                    if (!_context.KorisniciUloge.Any(x => x.KorisnikId == entity.KorisnikId && x.UlogaId == uloga))
                    {
                        _context.KorisniciUloge.Add(new KorisnikUloga
                        {
                            UlogaId = uloga,
                            KorisnikId = entity.KorisnikId,
                            DatumIzmjene = DateTime.Now
                        });
                    }
                }
            }
            _context.SaveChanges();

            return _mapper.Map<Modeli.Korisnik>(entity);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Modeli.Korisnik ChangePassword(string userEmail, ChangePasswordModel model)
        {
            var user = _context.Korisnici.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }

            var oldHash = GenerateHash(user.LozinkaSalt, model.OldPassword);
            if (oldHash != user.LozinkaHash)
            {
                throw new UserException("Stara lozinka nije ispravna!");
            }

            user.LozinkaHash = GenerateHash(user.LozinkaSalt, model.NewPassword);
            _context.SaveChanges();
            return _mapper.Map<Modeli.Korisnik>(user);
        }

        public Modeli.Korisnik ChangePhoneNumber(string userEmail, ChangePhoneNumberModel model)
        {
            var user = _context.Korisnici.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }

            user.Telefon = model.PhoneNumber;

            _context.SaveChanges();
            return _mapper.Map<Modeli.Korisnik>(user);
        }

        public Modeli.Korisnik ChangeProfilePicture(string userEmail, byte[] imageArray)
        {
            var user = _context.Korisnici.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }

            //var stream = new MemoryStream(imageArray);
            //var guid = Guid.NewGuid().ToString();
            //var file = $"{guid}.jpg";
            //var folder = "wwwroot/ProfileImages";
            //var fullPath = $"{folder}/{file}";
            //var imageFullPath = fullPath.Remove(0, 7);

            //var response = FilesHelper.UploadPhoto(stream, folder, file);
            //if (!response) return null;

            user.Slika = imageArray;
            _context.SaveChanges();
            return _mapper.Map<Modeli.Korisnik>(user);
        }

        public ProfilePictureModel GetProfilePicture(string userEmail)
        {
            var user = _context.Korisnici.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }
            return new ProfilePictureModel { imageArray = user.Slika };
        }

        public string GetPhoneNumber(string userEmail)
        {
            var user = _context.Korisnici.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }
            if (string.IsNullOrWhiteSpace(user.Telefon))
            {
                return "Nije unijet broj telefona.";
            }
            else
            {
                return user.Telefon;
            }
        }
    }
}
