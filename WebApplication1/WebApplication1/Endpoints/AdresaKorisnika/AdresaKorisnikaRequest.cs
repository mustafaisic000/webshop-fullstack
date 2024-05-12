namespace WebApplication1.Endpoints.AdresaKorisnika
{
    public class AdresaKorisnikaRequest
    {
        public int AdresaKorisnikaId { get; set; }
        public string NazivUlice { get; set; } = null!;
        public int GradId { get; set; }
    }
}
