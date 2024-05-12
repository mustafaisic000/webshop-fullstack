using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public partial class Transakcija
    {
        public Transakcija()
        {
            TransakcijaProdukti = new HashSet<TransakcijaProdukt>();
        }
        [Key]
        public int TransakcijaId { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public virtual KorisnickiNalog KorisnickiNalog { get; set; } = null!;
        public decimal UkupnaCijena { get; set; }
        public DateTime DatumTransakcije { get; set; }

        public virtual ICollection<TransakcijaProdukt> TransakcijaProdukti { get; set; }
    }
}
