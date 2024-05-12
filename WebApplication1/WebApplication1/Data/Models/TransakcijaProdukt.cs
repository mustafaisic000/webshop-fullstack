using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public partial class TransakcijaProdukt
    {
        [Key]
        public int TransakcijaProduktId { get; set; }
        public int Kolicina { get; set; }
        [ForeignKey(nameof(Transakcija))]
        public int TransakcijaId { get; set; }
        public virtual Transakcija Transakcija { get; set; } = null!;

        [ForeignKey(nameof(Produkt))]
        public int ProduktId { get; set; }
        public virtual Produkt Produkt { get; set; } = null!;

    }
}
