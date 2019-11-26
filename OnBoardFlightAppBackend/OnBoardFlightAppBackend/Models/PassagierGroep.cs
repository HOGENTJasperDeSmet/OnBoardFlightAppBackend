using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public class PassagierGroep
    {
        public int id;
        public List<Passagier> passagiers = new List<Passagier>();
        public string naam;
        public List<ChatBericht> chatberichten = new List<ChatBericht>();
    }
}
