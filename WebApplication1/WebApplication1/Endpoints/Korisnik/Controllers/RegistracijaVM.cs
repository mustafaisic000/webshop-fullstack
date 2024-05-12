namespace WebApplication5.KorisnikModul.ViewModels
{
    public class RegistracijaVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? AdresaKorisnikaId { get; set; }
        public int? AdresaZaDostavuId { get; set; }
       /// <summary>
       /// public int UlogaId { get; set; }
       /// </summary>
       // public int KontaktInfoId { get; set; }

    }
}
