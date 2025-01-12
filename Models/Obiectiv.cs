using System.ComponentModel.DataAnnotations.Schema;

namespace P_Galchis_Cristian.Models
{
    public class Obiectiv
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Adresa { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public string Orar { get; set; }

        public int? StilID { get; set; }

        public Stil? Stil {  get; set; }

        public ICollection<Bilet>? Bilete { get; set; }

        public ICollection<Review>? Reviews { get; set; }


    }
}