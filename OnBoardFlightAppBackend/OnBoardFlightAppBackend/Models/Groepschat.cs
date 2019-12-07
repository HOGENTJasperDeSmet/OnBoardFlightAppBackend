using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class Groepschat
    {
        public int id { get; set; }
        public List<Passagier> passagiers { get; set; }
        public string naam { get; set; }
        public List<ChatBericht> chatberichten { get; set; }

        public Groepschat()
        {
            passagiers = new List<Passagier>();
            chatberichten = new List<ChatBericht>();
        }
        public Groepschat(string naam)
        {
            this.naam = naam;
            passagiers = new List<Passagier>();
            chatberichten = new List<ChatBericht>();
        }
    }
}
