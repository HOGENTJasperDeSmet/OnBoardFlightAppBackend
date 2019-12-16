using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using On_board_flight_app_backend.DTO;
using On_board_flight_app_backend.Models;
using OnBoardFlightAppBackend.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController:Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ILocatieRepository _locatieRepository;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly IConfiguration _config;

        public FlightController(IFlightRepository context, ILocatieRepository context2, SignInManager<IdentityUser<int>> signInManager, UserManager<IdentityUser<int>> userManager, IConfiguration config)
        {
            _flightRepository = context;
            _locatieRepository = context2;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }
        /// GET: api/Flight
        /// <summary>
        /// Get all Flight
        /// </summary>
        /// <returns>Array of Flights</returns>
        [HttpGet]
        public IEnumerable<Vlucht> GetFlights()
        {
            return _flightRepository.GetAll();
        }
        // GET: api/Flight/1
        /// <summary>
        /// Get the flight with given id
        /// </summary>
        /// <param name="id">the id of the quiz</param>
        /// <returns>The Flight with the details</returns>
        [HttpGet("{id}")]
        public ActionResult<Vlucht> GetFlight(int id)
        {
            Vlucht flight = _flightRepository.GetbyId(id);
            if (flight == null)
            {
                return NotFound();
            }
            
            return flight;
        }

        [HttpGet]
        [Route("zetels")]
        public IEnumerable<Zetel> GetZetels()
        {
            return _flightRepository.GetZetels();
        }

        [HttpGet]
        [Route("zetels/{id}")]
        public Zetel GetZetel(int id)
        {
            var z = _flightRepository.GetZetelById(id);
            if(z.Passagier != null)
            {
                var x = z.Passagier.Groepschat.Passagiers.Select(p => p.clone()).ToList();
                z.Passagier.Groepschat.Passagiers = x;
            }
            //z.Passagier.Groepschat.Chatberichten.ForEach(c => c.Passagier = c.Passagier.clone());
            return z;
        }

        [HttpPost]
        [Route("veranderzetel")]
        [Authorize]
        public void VeranderZetel(VeranderZetelDTO veranderZetelDTO)
        {
            var zetel1 = _flightRepository.GetZetelById(veranderZetelDTO.Id1);
            var zetel2 = _flightRepository.GetZetelById(veranderZetelDTO.Id2);
            var passagierOpZetel1 = zetel1.Passagier;
            var passagierOpZetel2 = zetel2.Passagier;
            zetel2.Passagier = null;
            _flightRepository.SaveChanges();
            zetel1.Passagier = passagierOpZetel2;
            zetel2.Passagier = passagierOpZetel1;
            _flightRepository.SaveChanges();
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    var roles = await _userManager.GetClaimsAsync(user);
                    string token = GetToken(user);
                    return token;
                }
            }
            return null;
        }

        private String GetToken(IdentityUser<int> user)
        {
            // Create the token
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddYears(1),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
