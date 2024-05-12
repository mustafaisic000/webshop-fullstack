using WebApplication1.Endpoints.Grad;

namespace WebApplication1.Endpoints.AdresaKorisnika
{
    public class AdreseKorisnikaResponse
    {
        public List<AdreseResponse> Adrese { get; set; }
    }
    public class AdreseResponse
    {
        public int AdresaKorisnikaId { get; set; }
        public string NazivUlice { get; set; } = null!;
        public int GradId { get; set; }
    }
}
