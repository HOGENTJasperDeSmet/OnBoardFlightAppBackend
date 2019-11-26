using Microsoft.AspNetCore.Identity;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data
{
    public class ProjectDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        public ProjectDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Locatie o1 = new Locatie("New York","Avenue 555");
                Locatie b1 = new Locatie("Zaventem","Brussel");
                Vlucht f1 = new Vlucht("UC751",o1,b1, 5,new Vliegtuig());

                Passagier p1 = new Passagier(1, "Jan", "Janssens");
                Passagier p2 = new Passagier(2, "Jef", "Vanvoort");

             
                _dbContext.AddRange(o1, b1,p1,p2);
                _dbContext.Add(f1);
                _dbContext.SaveChanges();
            }
            }
    }
}
