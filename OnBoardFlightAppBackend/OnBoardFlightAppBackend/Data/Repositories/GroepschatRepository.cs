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
            _groepschatten = dbContext.Groepschatten;
        }

        public void Add(Groepschat pg)
        {
            _groepschatten.Add(pg);
        }

        public Groepschat GetGroepschatById(int id)
        {
            var chats = _groepschatten.Include(b => b.Chatberichten).ThenInclude(a => a.Passagier).SingleOrDefault(p => p.Id == id);
            //zonder dit krijg je een infinite loop 
            foreach (var chat in chats.Chatberichten)
            {
                chat.Passagier.Groepschat = null;
            }
            return chats;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
