using System.ComponentModel.DataAnnotations;

namespace P_Galchis_Cristian.Models
{
    public class Stil
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Denumirea este obligatorie.")]
        [StringLength(40, ErrorMessage = "Denumirea nu poate depasi {1} caractere.", MinimumLength = 3)]
        public string Denumire { get; set; }

        [StringLength(500, ErrorMessage = "Descrierea nu poate depasi {1} caractere.")]
        [MinLength(15, ErrorMessage = "Descrierea trebuie sa aiba cel putin {1} caractere.")]
        public string Descriere { get; set; }

        public ICollection<Obiectiv>? Obiective { get; set; }
    }
}
