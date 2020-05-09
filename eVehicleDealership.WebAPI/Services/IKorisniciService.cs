using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVehicleDealership.WebAPI.Services
{
    public interface IKorisniciService
    {
        Modeli.Korisnik Authenticate(string email, string password);
        IList<Modeli.Korisnik> Get(KorisnikSearchRequest request);
        Modeli.Korisnik GetById(int id);
        Modeli.Korisnik Insert(KorisnikInsertRequest request);
        Modeli.Korisnik Update(int id, KorisnikInsertRequest request);
        Modeli.Korisnik ChangePassword(string userEmail, ChangePasswordModel model);
        Modeli.Korisnik ChangePhoneNumber(string userEmail, ChangePhoneNumberModel model);
        string GetPhoneNumber(string userEmail);
        Modeli.Korisnik ChangeProfilePicture(string userEmail, byte[] imageArray);
        Modeli.ProfilePictureModel GetProfilePicture(string userEmail);
    }
}
