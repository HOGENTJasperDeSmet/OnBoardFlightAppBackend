using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class Vlucht
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        public Locatie Origine { get; set; }
        public Locatie Bestemming { get; set; }
        public DateTime departureTime { get; set; }
        public Vliegtuig Vliegtuig { get; set; }
        public int DuurInUren { get; set; }
        #endregion


        #region Constructors
        public Vlucht(string naam, Locatie origine, Locatie bestemming, int duurInUren, Vliegtuig vliegtuig)
        {
            Naam = naam;
            Origine = origine;
            Bestemming = bestemming;
            DuurInUren = duurInUren;
            Vliegtuig = vliegtuig;
        }
        public Vlucht()
        {
        }
        #endregion

        #region Methods  

        #endregion
    }
}
