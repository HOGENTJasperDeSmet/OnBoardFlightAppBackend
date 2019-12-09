using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.DTO
{
    public class VeranderZetelDTO
    {
        [Required]
        public int Id1 { get; set; }
        [Required]
        public int Id2 { get; set; }
    }
}
