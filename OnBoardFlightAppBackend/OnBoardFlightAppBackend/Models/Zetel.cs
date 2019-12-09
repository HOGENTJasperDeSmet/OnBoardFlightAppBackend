namespace On_board_flight_app_backend.Models
{
    public class Zetel
    {
        public int Id { get; set; }
        public int Rij { get; set; }
        public char Stoel { get; set; }
        public string Klasse { get; set; }
        public Passagier Passagier { get; set; }
        public int? PassagierKey { get; set; }


        public Zetel(int rij, char stoel, string klasse)
        {
            this.Rij = rij;
            this.Stoel = stoel;
            this.Klasse = klasse;
        }
        public Zetel() { }
    }

}