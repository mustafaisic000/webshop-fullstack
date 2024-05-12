namespace WebApplication1.Data.Models
{
    public partial class Ozbiljnost
    {
        public Ozbiljnost()
        {
            Izuzetci = new HashSet<Izuzetak>();
        }

        public int OzbiljnostId { get; set; }
        public string Naziv { get; set; } = null!;

        public virtual ICollection<Izuzetak> Izuzetci { get; set; }
    }
}
