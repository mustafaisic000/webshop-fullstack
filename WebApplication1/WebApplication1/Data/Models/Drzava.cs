using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public partial class Drzava
    {
        //public Drzava()
        //{
        //    Gradovi = new HashSet<Grad>();
        //}
        [Key]
        public int DrzavaId { get; set; }
        public string Naziv { get; set; } = null!;
        public bool Restrikcije { get; set; }

        public virtual ICollection<Grad> Gradovi { get; set; }
    }
}
