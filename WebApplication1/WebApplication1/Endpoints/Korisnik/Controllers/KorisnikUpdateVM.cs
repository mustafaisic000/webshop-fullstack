namespace WebApplication1.Endpoints.Korisnik.Controllers
{
    public class KorisnikUpdateVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int? AdresaKorisnikaId { get; set; }
        public int? AdresaZaDostavuId { get; set; }
        public int UlogaId { get; set; }
        public int KontaktInfoId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
