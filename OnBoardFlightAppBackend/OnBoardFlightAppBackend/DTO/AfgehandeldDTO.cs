﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.DTO
{
    public class AfgehandeldDTO
    {
        [Required]
        public bool Afgehandeld { get; set; }
    }
}
