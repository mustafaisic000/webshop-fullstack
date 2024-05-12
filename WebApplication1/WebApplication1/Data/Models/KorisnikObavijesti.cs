using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Models
{
    public class KorisnikObavijesti
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("KorisnikId")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }
        public Obavijesti Obavijesti { get; set; }
        [ForeignKey("ObavijestiId")]
        public int ObavijestiId { get; set; }


    }
}
