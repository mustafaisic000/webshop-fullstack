using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public partial class Kategorija
    {
        //public Kategorija()
        //{
        //    Produkti = new HashSet<Produkt>();
        //}
        [Key]
        public int KategorijaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;

        public virtual ICollection<Produkt> Produkti { get; set; }
    }
}
