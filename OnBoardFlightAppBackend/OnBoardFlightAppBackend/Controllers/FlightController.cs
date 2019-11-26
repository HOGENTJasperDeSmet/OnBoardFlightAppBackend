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
    public class FlightController:Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ILocatieRepository _locatieRepository;

        public FlightController(IFlightRepository context, ILocatieRepository context2)
        {
            _flightRepository = context;
            _locatieRepository = context2;
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
    }
}
