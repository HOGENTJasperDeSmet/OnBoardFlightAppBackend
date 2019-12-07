using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class Bestelling
    {
        public int Id { get; set; }
        public bool Afgehandeld { get; set; }
        public Passagier Passagier { get; set; }
        public ICollection<BestellingTK> BestellingTKs { get; set; }

        public Bestelling()
        {
            BestellingTKs = new List<BestellingTK>();
        }
    }
}
