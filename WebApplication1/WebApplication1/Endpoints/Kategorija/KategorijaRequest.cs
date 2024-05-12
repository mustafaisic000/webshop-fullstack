using WebApplication1.Endpoints.AdresaKorisnika;

namespace WebApplication1.Endpoints.Kategorija
{
    public class KategorijaRequest
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
       
    }
   
}
