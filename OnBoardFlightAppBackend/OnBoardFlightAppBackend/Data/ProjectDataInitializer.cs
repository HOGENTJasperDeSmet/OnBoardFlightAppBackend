using Microsoft.AspNetCore.Identity;
using On_board_flight_app_backend.Models;
using OnBoardFlightAppBackend.Models;
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
                Locatie o1 = new Locatie("Brussels", "Avenue 555", 50.900864, 4.484738);
                Locatie b1 = new Locatie("Iceland", "Brussel", 63.978513, -22.635057);
                Vlucht f1 = new Vlucht("UC751", o1, b1, 5, new Vliegtuig());

                Passagier p1 = new Passagier(1, "Jan", "Janssens");
                Passagier p2 = new Passagier(2, "Jef", "Vanvoort");
                Passagier p3 = new Passagier(3,"Sara", "Verbeke");
                Passagier p4 = new Passagier(4,"Celia", "Vermeulen"); 


                p1.Meldingen.Add(new Melding() { Inhoud = "Welkom aan boord!" });
                p2.Meldingen.Add(new Melding() { Inhoud = "Welkom aan boord!" });
                p3.Meldingen.Add(new Melding() { Inhoud = "Welkom aan boord!" });
                p4.Meldingen.Add(new Melding() { Inhoud = "Welkom aan boord!" });

                _dbContext.Passagiers.AddRange(p1, p2, p3, p4);

                Zetel z1 = new Zetel(1, 'A', "Eerste klasse") { Passagier = p1};
                Zetel z2 = new Zetel(1, 'B', "Eerste klasse") { Passagier = p2};
                Zetel z3 = new Zetel(1, 'C', "Eerste klasse") { Passagier = p3 };
                Zetel z4 = new Zetel(2, 'A', "Eerste klasse") { Passagier = p4 };
                Zetel z5 = new Zetel(2, 'B', "Eerste klasse");

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
                _dbContext.Zetels.AddRange(z1, z2, z3, z4, z5);
                _dbContext.Locaties.AddRange(o1, b1);
                _dbContext.Flights.Add(f1);

                Groepschat groepschat1 = new Groepschat("de coole chat");
                groepschat1.Passagiers.Add(p1);
                groepschat1.Passagiers.Add(p2);

                ChatBericht cb1 = new ChatBericht(p1, DateTime.Now, "hallo");
                ChatBericht cb2 = new ChatBericht(p2, DateTime.Now, "dag");

                groepschat1.Chatberichten.Add(cb1);
                groepschat1.Chatberichten.Add(cb2);

                _dbContext.Add(groepschat1);

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
