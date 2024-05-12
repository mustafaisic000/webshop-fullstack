namespace WebApplication1.Endpoints.Kategorija
{
    public class KategorijaResponse
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
    }
}
