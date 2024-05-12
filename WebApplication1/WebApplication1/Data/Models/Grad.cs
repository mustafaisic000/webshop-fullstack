using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace WebApplication1.Data.Models
{
    public partial class Grad
    {
        //public Grad()
        //{
        //    AdreseKorisnika = new HashSet<AdresaKorisnika>();
        //    AdresaZaDostavu = new HashSet<AdresaZaDostavu>();
        //}
        [Key]
        public int GradId { get; set; }
        public string PostanskiBroj { get; set; } = null!;
        public string ImeGrada { get; set; } = null!;
        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
        public virtual Drzava Drzava { get; set; } = null!;

        public virtual ICollection<AdresaKorisnika> AdreseKorisnika { get; set; }
        public virtual ICollection<AdresaZaDostavu> AdresaZaDostavu { get; set; }
    }
}
