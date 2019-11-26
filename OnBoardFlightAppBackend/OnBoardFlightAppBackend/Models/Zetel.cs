namespace On_board_flight_app_backend.Models
{
    public class Zetel
    {
        public int Id { get; set; }
        public int Rij;
        public char Stoel;
        public string Klasse;
        public Passagier Passagier;

        public Zetel(int rij, char stoel, string klasse)
        {
            this.Rij = rij;
            this.Stoel = stoel;
            this.Klasse = klasse;
        }
        public Zetel() { }
    }

}