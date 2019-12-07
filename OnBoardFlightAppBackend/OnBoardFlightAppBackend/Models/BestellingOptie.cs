using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class BestellingOptie
    {
        public int Id { get; set; }
        public BestellingType Type { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
    }
    public enum BestellingType
    {
        Eten = 1, Drinken = 2
    }
}
