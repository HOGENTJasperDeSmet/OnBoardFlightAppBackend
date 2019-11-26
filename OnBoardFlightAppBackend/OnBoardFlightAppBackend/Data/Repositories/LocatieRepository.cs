using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data.Repositories
{
    public class LocatieRepository : ILocatieRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Locatie> _locaties;

        public void Add(Locatie locatie)
        {
            _locaties.Add(locatie);
        }

        public IEnumerable<Locatie> GetAll()
        {
            return _locaties.ToList();
        }

        public Locatie GetbyId(int id)
        {
            return _locaties.SingleOrDefault(l => l.Id == id);
        }

        public void Remove(Locatie locatie)
        {
            _locaties.Remove(locatie);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
