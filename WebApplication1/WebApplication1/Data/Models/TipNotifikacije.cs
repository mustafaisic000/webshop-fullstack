using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public partial class TipNotifikacije
    {
        //public TipNotifikacije()
        //{
        //    Notifikacije = new HashSet<Notifikacija>();
        //}
        [Key]
        public int TipNotifikacijeId { get; set; }
        public string Naziv { get; set; } = null!;
        public bool PosaljiAdminu { get; set; }
        public string Sadrzaj { get; set; }
        public virtual ICollection<Notifikacija> Notifikacije { get; set; }
    }
}
