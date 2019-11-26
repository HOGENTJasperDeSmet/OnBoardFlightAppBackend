﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public interface IFlightRepository
    {
        IEnumerable<Vlucht> GetAll();
        Vlucht GetbyId(int id);
        void Add(Vlucht flight);
        void Remove(Vlucht flight);
        void SaveChanges();
    }
}