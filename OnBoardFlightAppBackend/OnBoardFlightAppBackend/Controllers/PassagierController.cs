
using Microsoft.AspNetCore.Mvc;
using On_board_flight_app_backend.Models;
using OnBoardFlightAppBackend.DTO;
using OnBoardFlightAppBackend.Models;
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
    public class PassagierController : Controller
    {
        private readonly IPassagierRepository _passengerRepository;

        public PassagierController(IPassagierRepository context)
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

        [HttpGet]
        [Route("melding/{id}")]
        public IEnumerable<Melding> GetMeldingen(int id)
        {
            return _passengerRepository.GetbyId(id).Meldingen;
        }

        [HttpPost]
        [Route("melding/{id}")]
        public void AddMelding(int id, MeldingDTO meldingDTO)
        {
            var passagier = _passengerRepository.GetbyId(id);
            var melding = new Melding() { Inhoud = meldingDTO.Inhoud };
            passagier.Meldingen.Add(melding);
            _passengerRepository.SaveChanges();
        }

        [HttpPost]
        [Route("melding")]
        public void AddMeldingToAll(int id, MeldingDTO meldingDTO)
        {
            foreach(var p in _passengerRepository.GetAll())
            {
                var melding = new Melding() { Inhoud = meldingDTO.Inhoud };
                p.Meldingen.Add(melding);
            }
            _passengerRepository.SaveChanges();
        }

        [HttpPost]
        [Route("chatbericht")]
        public void AddChatBericht(int passagierId,ChatBericht chatbericht)
        {
            Passagier passagier = _passengerRepository.GetbyId(passagierId);
            //passagier.Groepschat.Chatberichten.Add(chatbericht);
            _passengerRepository.SaveChanges();
        }
    }
}
