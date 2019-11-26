using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
   public interface ILocatieRepository
    {   
        IEnumerable<Locatie> GetAll();
        Locatie GetbyId(int id);
        void Add(Locatie locatie);
        void Remove(Locatie locatie);
        void SaveChanges();
    }
}

