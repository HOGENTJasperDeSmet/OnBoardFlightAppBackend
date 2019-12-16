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
        private readonly DbSet<Zetel> _zetels;

        public FlightRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _flights = dbContext.Flights;
            _zetels = dbContext.Zetels;
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
            var flight = _flights.Include(o => o.Origine).Include(b => b.Bestemming).Include(vlucht => vlucht.Vliegtuig).SingleOrDefault(f => f.Id == id);
            flight.departureTime = DateTime.Now;
            _context.SaveChanges();
            return flight;
        }

        public void Remove(Vlucht flight)
        {
            _flights.Remove(flight);
        }

        public IEnumerable<Zetel> GetZetels()
        {
            return _zetels.Include(z => z.Passagier).OrderBy(z => z.Id).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Zetel GetZetelById(int id)
        {
            return _zetels.Include(z => z.Passagier).ThenInclude(p => p.Groepschat).ThenInclude(s => s.Chatberichten).Include(p=> p.Passagier.Groepschat.Passagiers).Include(p => p.Passagier.Meldingen).SingleOrDefault(z => z.Id == id);
        }
    }
}
