
using Microsoft.AspNetCore.Mvc;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PasssagierController : Controller
    {
        private readonly IPassagierRepository _passengerRepository;

        public PasssagierController(IPassagierRepository context)
        {
            _passengerRepository = context;
        }

        /// GET: api/Passagiers
        /// <summary>
        /// Get all Passengers
        /// </summary>
        /// <returns>Array of Passengers</returns>
        [HttpGet]
        public IEnumerable<Passagier> GetPassagiers()
        {
            return _passengerRepository.GetAll();
        }
        /// GET: api/Reisgezelschap/id
        /// <summary>
        /// Get all Reisgezelschap
        /// </summary>
        /// <returns>Array of Passengers</returns>
        [HttpGet]
        [Route("Reisgezelschap/{id}")]
        public IEnumerable<Passagier> GetReisgezelschap(int id)
        {
            return _passengerRepository.getReisgezelschap(id);
        }
    }
}
