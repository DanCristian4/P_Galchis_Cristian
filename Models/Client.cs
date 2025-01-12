using System.ComponentModel.DataAnnotations;

namespace P_Galchis_Cristian.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }

        [Display(Name = "Nume Complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public ICollection<Bilet>? Bilete { get; set; }
    }
}
