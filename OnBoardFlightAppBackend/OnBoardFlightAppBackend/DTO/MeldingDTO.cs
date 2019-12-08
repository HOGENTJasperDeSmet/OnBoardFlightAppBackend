using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.DTO
{
    public class MeldingDTO
    {
        [Required]
        public string Inhoud { get; set; }
    }
}
