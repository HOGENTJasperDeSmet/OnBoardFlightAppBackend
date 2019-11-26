using System;
using System.Collections.Generic;

namespace On_board_flight_app_backend.Models
{
    public class Vliegtuig
    {
        public int Id { get; set; }
        public List<Zetel> Zetels = new List<Zetel>();
        public string Type;

        public Vliegtuig()
        {
            for (int i = 1; i <= 30; i++)
                for (char lett = 'a'; lett <= 'f'; lett++)
                    Zetels.Add(new Zetel(i, lett, "economy"));

                
        }
    }
}