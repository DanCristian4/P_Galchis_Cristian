namespace P_Galchis_Cristian.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string Continut { get; set; }
        public int Rating { get; set; }

        public int? ObiectivID { get; set; }

        public Obiectiv? Obiectiv { get; set; }
    }
}
