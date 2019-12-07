using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class BestellingTK
    {
        public int BestellingId { get; set; }
        public int BestellingOptieId { get; set; }
        public BestellingOptie BestellingOptie { get; set; }
        public int Aantal { get; set; } = 1;
    }
}
