using System.ComponentModel.DataAnnotations;

namespace P_Galchis_Cristian.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ObiectivID { get; set; }
        public Obiectiv? Obiectiv { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
