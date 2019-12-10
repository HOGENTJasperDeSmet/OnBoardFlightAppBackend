using Microsoft.AspNetCore.Mvc;
using On_board_flight_app_backend.Models;
using OnBoardFlightAppBackend.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroepschatController : Controller
    {
        private readonly IGroepsChatRepository _groepschatRepository;
        private readonly IPassagierRepository _passagierRepository;

        public GroepschatController(IGroepsChatRepository context, IPassagierRepository context2)
        {
            _groepschatRepository = context;
            _passagierRepository = context2;
        }
        [HttpGet]
        [Route("Groepschat/{id}")]
        public Groepschat GetReisgezelschap(int id)
        {
            //Passagier passagier = _passagierRepository.GetbyId(id);
            return _groepschatRepository.GetGroepschatById(id);
        }
    }
}
