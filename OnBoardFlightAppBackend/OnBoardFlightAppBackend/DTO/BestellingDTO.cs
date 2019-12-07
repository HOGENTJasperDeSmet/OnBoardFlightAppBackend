using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.DTO
{
    public class BestellingDTO
    {
        [Required]
        public bool Afgehandeld { get; set; }
        [Required]
        public List<BestellingOptie> BestellingOpties { get; set; }
    }
}
