using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Models;
using On_board_flight_app_backend.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data.Repositories
{
    public class BestellingRepository : IBestellingRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Bestelling> _bestellingen;
        private readonly DbSet<BestellingOptie> _bestellingOpties;
        private readonly DbSet<BestellingTK> _bestellingTKs;

        public BestellingRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _bestellingen = dbContext.Bestellingen;
            _bestellingOpties = dbContext.BestellingOpties;
            _bestellingTKs = dbContext.BestellingTKs;
        }

        public void Add(Bestelling bestelling)
        {
            _bestellingen.Add(bestelling);
        }

        public void AddOptieToBestelling(BestellingTK bestelling)
        {
            _bestellingTKs.Add(bestelling);
        }

        public IEnumerable<Bestelling> GetAll()
        {
            return _bestellingen.AsNoTracking().Include(b => b.Passagier).Include(b => b.BestellingTKs).ThenInclude(b => b.BestellingOptie).ToList();
        }

        public IEnumerable<Bestelling> GetAllOf(int id)
        {
            return _bestellingen.Include(b => b.Passagier).Include(b => b.BestellingTKs).ThenInclude(b => b.BestellingOptie).Where(b => b.Passagier.Id == id).ToList();
        }

        public IEnumerable<BestellingOptie> GetAllOpties()
        {
            return _bestellingOpties.AsNoTracking().ToList();
        }

        public Bestelling GetById(int id)
        {
            return _bestellingen.SingleOrDefault(b => b.Id == id);
        }

        public BestellingOptie GetOptieById(int bestellingOptieId)
        {
            return _bestellingOpties.SingleOrDefault(o => o.Id == bestellingOptieId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Bestelling bestelling)
        {
            _bestellingen.Update(bestelling);
        }
    }
}
