using System;

namespace On_board_flight_app_backend.Models
{
    public class ChatBericht
    {
        public int id { get; set; }
        public string inhoud { get; set; }
        public DateTime datumVerzonden { get; set; }
        public Passagier passagier { get; set; }

        public ChatBericht()
        {

        }

        public ChatBericht(Passagier passagier, DateTime datum, string inhoud)
        {
            this.passagier = passagier;
            this.datumVerzonden = datum;
            this.inhoud = inhoud;
        }
    }
}