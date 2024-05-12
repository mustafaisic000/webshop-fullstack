namespace WebApplication1.Endpoints.KorpaProdukt
{
    public class KorpaProduktListResponse
    {
        public List<KorpaProduktiResponse> KorpaProdukti { get; set; }
    }
    public class KorpaProduktiResponse
    {
        public int KorpaProduktId { get; set; }
        public int KorisnickiNalogId { get; set; }
        public int ProduktId { get; set; }
    }
}
