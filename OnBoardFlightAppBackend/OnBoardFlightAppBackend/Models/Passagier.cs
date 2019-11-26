using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class Passagier
    {
        #region Properties
        public int Id { get; set; }
        public Zetel zetel { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        // public ICollection<Bestelling> Bestellingen { get; set; }
        public ICollection<Passagier> Reisgezelschap { get; set; }
        #endregion

        #region Constructors
        public Passagier()
        {

        }
        public Passagier(int id, string voornaam, string naam)
        {
            this.Id = id;
            this.Voornaam = voornaam;
            this.Naam = naam;
        }
        #endregion
    }
}
