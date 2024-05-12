namespace WebApplication1.Endpoints.Kategorija
{
    public class KategorijeListaresponse
    {
        public List<KategorijeResponse> Kategorije { get; set; }
    }
    public class KategorijeResponse
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
    }
}
