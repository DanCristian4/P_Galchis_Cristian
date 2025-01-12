namespace P_Galchis_Cristian.Models
{
    public class Stil
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; } 

        public ICollection<Obiectiv>? Obiective { get; set; }
    }
}
