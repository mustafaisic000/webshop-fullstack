using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public partial class Produkt
    {
        //public Produkt()
        //{
        //    KorpaProdukti = new HashSet<KorpaProdukt>();
        //    TransakcijaProdukti = new HashSet<TransakcijaProdukt>();
        //}
        [Key]
        public int ProduktId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public decimal Cijena { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Slika { get; set; } = null!;
        [ForeignKey(nameof(Kategorija))]
        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; } = null!;
        public bool JelObrisan { get; set; }
        public int Kolicina { get; set; }
        public bool JelProdan { get; set; }

        public virtual ICollection<KorpaProdukt> KorpaProdukti { get; set; }
        public virtual ICollection<TransakcijaProdukt> TransakcijaProdukti { get; set; }
    }
}
