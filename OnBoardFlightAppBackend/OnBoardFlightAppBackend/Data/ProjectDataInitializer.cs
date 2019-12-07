using Microsoft.AspNetCore.Identity;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data
{
    public class ProjectDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public ProjectDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser<int>> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Locatie o1 = new Locatie("New York", "Avenue 555");
                Locatie b1 = new Locatie("Zaventem", "Brussel");
                Vlucht f1 = new Vlucht("UC751", o1, b1, 5, new Vliegtuig());

                Passagier p1 = new Passagier() { Voornaam = "Jan", Naam = "Janssens" };
                Passagier p2 = new Passagier() { Voornaam = "Jef", Naam = "Vanvoort" };
                Passagier p3 = new Passagier() { Voornaam = "Sara", Naam = "Verbeke" };
                Passagier p4 = new Passagier() { Voornaam = "Celia", Naam = "Vermeulen" };

                _dbContext.Passagiers.AddRange(p1, p2, p3, p4);

                Zetel z1 = new Zetel(1, 'A', "Eerste klasse") { Passagier = p1};
                Zetel z2 = new Zetel(1, 'B', "Eerste klasse") { Passagier = p2};

                BestellingOptie optie1 = new BestellingOptie() { Naam = "Fristi", Type = BestellingType.Drinken, Prijs = 4.50 };
                BestellingOptie optie2 = new BestellingOptie() { Naam = "Water", Type = BestellingType.Drinken, Prijs = 2 };
                BestellingOptie optie3 = new BestellingOptie() { Naam = "Rijstpap", Type = BestellingType.Eten, Prijs = 7.50 };
                BestellingOptie optie4 = new BestellingOptie() { Naam = "Steak Natuur", Type = BestellingType.Eten, Prijs = 25 };

                _dbContext.BestellingOpties.AddRange(optie1, optie2, optie3, optie4);
                _dbContext.SaveChanges();

                Bestelling bestelling1 = new Bestelling() { Afgehandeld = false, Passagier = p1};
                Bestelling bestelling2 = new Bestelling() { Afgehandeld = false, Passagier = p2};
                Bestelling bestelling3 = new Bestelling() { Afgehandeld = false, Passagier = p1};
                Bestelling bestelling4 = new Bestelling() { Afgehandeld = false, Passagier = p2};

                _dbContext.AddRange(bestelling1, bestelling2, bestelling3, bestelling4);
                _dbContext.SaveChanges();

                BestellingTK tk1 = new BestellingTK { BestellingId = bestelling1.Id, BestellingOptie = optie1 };
                BestellingTK tk2 = new BestellingTK { BestellingId = bestelling1.Id, BestellingOptie = optie3 };
                BestellingTK tk3 = new BestellingTK { BestellingId = bestelling2.Id, BestellingOptie = optie2 };
                BestellingTK tk4 = new BestellingTK { BestellingId = bestelling2.Id, BestellingOptie = optie4 };
                BestellingTK tk5 = new BestellingTK { BestellingId = bestelling3.Id, BestellingOptie = optie1 };
                BestellingTK tk6 = new BestellingTK { BestellingId = bestelling4.Id, BestellingOptie = optie2 };

                _dbContext.BestellingTKs.AddRange(tk1, tk2, tk3, tk4, tk5, tk6);
                _dbContext.Zetels.AddRange(z1, z2);
                _dbContext.Locaties.AddRange(o1, b1);
                _dbContext.Flights.Add(f1);

                await CreateUser("personeel@personeel.com", "personeel@personeel.com", "azerty123");

                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string userName, string email, string password)
        {
            var user = new IdentityUser<int> { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
