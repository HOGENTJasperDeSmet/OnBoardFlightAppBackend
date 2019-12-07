using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Data;
using On_board_flight_app_backend.Models;
using OnBoardFlightAppBackend.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.Data.Repositories
{
    public class GroepsChatRepository : IGroepsChatRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Groepschat> _groepschatten;

        public GroepsChatRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _groepschatten = dbContext.PassagierGroepen;
        }

        public void Add(Groepschat pg)
        {
            _groepschatten.Add(pg);
        }

        public Groepschat GetGroepschatById(Passagier passagier)
        {
            return _groepschatten.Include(s => s.passagiers).Include(b => b.chatberichten).SingleOrDefault(p => p.passagiers.Contains(passagier));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
