using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public partial class AdresaZaDostavu
    {
        //public AdresaZaDostavu()
        //{
        //    Korisnici = new HashSet<Korisnik>();
        //}
        [Key]
        public int AdresaZaDostavuId { get; set; }
        public string NazivUlice { get; set; } = null!;
        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public virtual Grad Grad { get; set; } = null!;

        public virtual ICollection<Korisnik> Korisnici { get; set; }

    }
}
