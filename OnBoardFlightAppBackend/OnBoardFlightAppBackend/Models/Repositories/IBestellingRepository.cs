using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models.Repositories
{
    public interface IBestellingRepository
    {
        void Add(Bestelling bestelling);
        IEnumerable<Bestelling> GetAll();
        void SaveChanges();
        BestellingOptie GetOptieById(int bestellingOptieId);
        Bestelling GetById(int id);
        void Update(Bestelling bestelling);
        IEnumerable<BestellingOptie> GetAllOpties();
        IEnumerable<Bestelling> GetAllOf(int id);
        void AddOptieToBestelling(BestellingTK bestellingTK);
    }
}
