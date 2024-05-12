using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Obavijesti
    {
        [Key]
        public int Id { get; set; }
        public string Poruka { get; set; }
        public DateTime Datum { get; set; }
        public IEnumerable<KorisnikObavijesti> Uposlenik { get; set; }
    }
}
