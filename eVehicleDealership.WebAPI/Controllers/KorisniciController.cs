using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVehicleDealership.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _korisnikService;

        public KorisniciController(IKorisniciService korisnikService)
        {
            _korisnikService = korisnikService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody]KorisnikInsertRequest request)
        {
            _korisnikService.Insert(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody]AuthenticateModel model)
        {
            var user = _korisnikService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email ili lozinka nisu ispravni!" });

            return Ok(user);
        }

        [Authorize(Roles = "Administrator,Uposlenik")]
        [HttpGet]
        public IList<Modeli.Korisnik> Get([FromQuery]KorisnikSearchRequest request)
        {
            return _korisnikService.Get(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public Modeli.Korisnik GetById(int id)
        {
            return _korisnikService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Modeli.Korisnik Insert(KorisnikInsertRequest request)
        {
            return _korisnikService.Insert(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Modeli.Korisnik Update(int id, KorisnikInsertRequest request)
        {
            return _korisnikService.Update(id, request);
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            _korisnikService.ChangePassword(userEmail, model);
            return Ok("Password uspješno promijenjen!");
        }

        [HttpPost("ChangePhoneNumber")]
        public IActionResult ChangePhoneNumber([FromForm]ChangePhoneNumberModel model)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            _korisnikService.ChangePhoneNumber(userEmail, model);
            return Ok("Broj telefon uspješno promijenjen!");
        }

        [HttpGet("GetPhoneNumber")]
        public IActionResult GetPhoneNumber()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            
            return Ok(_korisnikService.GetPhoneNumber(userEmail));
        }

        [HttpPost("ChangeProfilePicture")]
        public IActionResult ChangeProfilePicture([FromBody]byte[] imageArray)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            var response = _korisnikService.ChangeProfilePicture(userEmail, imageArray);
            if (response == null) return BadRequest("Greška pri uploadu slike!");
            return Ok("Profilna slika uspješno promijenjena!");
        }

        [HttpGet("GetProfilePicture")]
        public IActionResult GetProfilePicture()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            return Ok(_korisnikService.GetProfilePicture(userEmail));
        }
    }
}