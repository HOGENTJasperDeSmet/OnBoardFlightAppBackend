using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using On_board_flight_app_backend.DTO;
using On_board_flight_app_backend.Models;
using On_board_flight_app_backend.Models.Repositories;
using OnBoardFlightAppBackend.DTO;

namespace On_board_flight_app_backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BestellingController : Controller
    {
        private readonly IBestellingRepository _bestellingRepository;
        private readonly IPassagierRepository _passagierRepository;
        public BestellingController(IBestellingRepository bestellingRepository, IPassagierRepository passagierRepository)
        {
            _bestellingRepository = bestellingRepository;
            _passagierRepository = passagierRepository;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Bestelling> GetBestellingen()
        {
            return _bestellingRepository.GetAll();
        }

        [HttpPost("{id}")]
        public Bestelling PostBestelling(BestellingDTO bestellingDTO, int id)
        {
            var passagier = _passagierRepository.GetbyId(id);
            var newBestelling = new Bestelling() { Afgehandeld = false, Passagier = passagier };
            _bestellingRepository.Add(newBestelling);
            _bestellingRepository.SaveChanges();

            var grouping = bestellingDTO.BestellingOpties.GroupBy(x => x.Id).Select(x => new { x.Key, Count = x.Count() });

            foreach (var bo in grouping)
            {
                var optie = _bestellingRepository.GetOptieById(bo.Key);

                _bestellingRepository.AddOptieToBestelling(new BestellingTK() { BestellingId = newBestelling.Id, BestellingOptie = optie, Aantal = bo.Count });
            }
            _bestellingRepository.SaveChanges();
            return newBestelling;
        }

        [HttpPut("{id}")]
        [Authorize]
        public Bestelling IsAfgehandeld(int id, AfgehandeldDTO afgehandeldDTO)
        {
            var bestelling = _bestellingRepository.GetById(id);
            bestelling.Afgehandeld = afgehandeldDTO.Afgehandeld;
            _bestellingRepository.Update(bestelling);
            _bestellingRepository.SaveChanges();
            return bestelling;
        }

        [HttpGet]
        [Route("opties")]
        public IEnumerable<BestellingOptie> GetBestellingOpties()
        {
            return _bestellingRepository.GetAllOpties();
        }

        [HttpGet]
        [Route("user/{id}")]
        public IEnumerable<Bestelling> GetBestellingenFromUser(int id)
        {
            return _bestellingRepository.GetAllOf(id);
        }
    }
}