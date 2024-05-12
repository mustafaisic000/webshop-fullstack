using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public partial class KorpaProdukt
    {
        [Key]
        public int KorpaProduktId { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public virtual KorisnickiNalog KorisnickiNalog { get; set; } = null!;

        [ForeignKey(nameof(Produkt))]
        public int ProduktId { get; set; }
        public virtual Produkt Produkt { get; set; } = null!;

    }
}
