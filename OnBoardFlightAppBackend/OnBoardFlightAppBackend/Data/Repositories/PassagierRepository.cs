using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data.Repositories
{
    public class PassagierRepository : IPassagierRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Passagier> _passagiers;

        public PassagierRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _passagiers = dbContext.Passagiers;
        }

        public void Add(Passagier passagier)
        {
            _passagiers.Add(passagier);
        }

        public IEnumerable<Passagier> GetAll()
        {
            //Bestellingen ook nog includen
            return _passagiers.ToList();
        }

        public Passagier GetbyId(int id)
        {
            return _passagiers.Include(g => g.Groepschat).Include(p => p.Meldingen).SingleOrDefault(s => s.Id == id);
        }

        public void Remove(Passagier passagier)
        {
            _passagiers.Remove(passagier);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Passagier passagier)
        {
            _passagiers.Update(passagier);
        }
    }
}
