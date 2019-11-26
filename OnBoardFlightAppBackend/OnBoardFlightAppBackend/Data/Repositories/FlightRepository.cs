using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data.Repositories
{
    public class FlightRepository : IFlightRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Vlucht> _flights;

        public FlightRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _flights = dbContext.Flights;
        }
        public void Add(Vlucht flight)
        {
            _flights.Add(flight);
        }

        public IEnumerable<Vlucht> GetAll()
        {
            return _flights.Include(o => o.Origine).Include(b => b.Bestemming).ToList();
        }

        public Vlucht GetbyId(int id)
        {
            return _flights.Include(o => o.Origine).Include(b => b.Bestemming).Include(vlucht => vlucht.Vliegtuig).SingleOrDefault(f => f.Id == id);
        }

        public void Remove(Vlucht flight)
        {
            _flights.Remove(flight);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
