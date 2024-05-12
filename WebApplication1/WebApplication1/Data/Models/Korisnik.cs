using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebApplication1.Data.Models
{
    [Table("Korisnik")]
    public partial class Korisnik: KorisnickiNalog
    {
        
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; } = "";
        //public string? BrojTelefona { get; set; }
       

        [ForeignKey(nameof(AdresaKorisnika))]
        public int? AdresaKorisnikaId { get; set; }
        public virtual AdresaKorisnika? AdresaKorisnika { get; set; }

        [ForeignKey(nameof(AdresaZaDostavu))]
        public int? AdresaZaDostavuId { get; set; }
        public virtual AdresaZaDostavu? AdresaZaDostavu { get; set; }

        public virtual ICollection<KorpaProdukt> KorpaProdukti { get; set; }
        public virtual ICollection<Transakcija> Transakcije { get; set; }
        public virtual ICollection<Notifikacija> Notifikacije { get; set; }

    }

}
