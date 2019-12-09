using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class Groepschat
    {
        public int Id { get; set; }
        public List<Passagier> Passagiers { get; set; }
        public string Naam { get; set; }
        public List<ChatBericht> Chatberichten { get; set; }

        public Groepschat()
        {
            Passagiers = new List<Passagier>();
            Chatberichten = new List<ChatBericht>();
        }
        public Groepschat(string naam)
        {
            Naam = naam;
            Passagiers = new List<Passagier>();
            Chatberichten = new List<ChatBericht>();
        }
    }
}
