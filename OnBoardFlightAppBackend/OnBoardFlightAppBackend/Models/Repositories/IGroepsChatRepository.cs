using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.Models.Repositories
{
    public interface IGroepsChatRepository
    {
        void Add(Groepschat pg);
        Groepschat GetGroepschatById(int id);
        void SaveChanges();
    }
}
