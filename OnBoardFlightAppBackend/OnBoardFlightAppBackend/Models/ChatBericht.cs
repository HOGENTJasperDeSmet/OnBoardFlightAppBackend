using System;

namespace On_board_flight_app_backend.Models
{
    public class ChatBericht
    {
        public int Id { get; set; }
        public string Inhoud { get; set; }
        public DateTime DatumVerzonden { get; set; }
        public String Passagier { get; set; }

        public ChatBericht()
        {

        }

        public ChatBericht(Passagier passagier, DateTime datum, string inhoud)
        {
            Passagier = passagier.Voornaam;
            DatumVerzonden = datum;
            Inhoud = inhoud;
        }
    }
}