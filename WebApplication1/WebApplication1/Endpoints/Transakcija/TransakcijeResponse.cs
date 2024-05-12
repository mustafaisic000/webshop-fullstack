using WebApplication1.Endpoints.Grad;

namespace WebApplication1.Endpoints.Transakcija
{
    public class TransakcijeResponse
    {
        public List<TransakcijeListaResponse> Transakcije { get; set; }
    }
    public class TransakcijeListaResponse
    {
        public int TransakcijaId { get; set; }
        public int KorisnickiNalogId { get; set; }
        public decimal UkupnaCijena { get; set; }
        public DateTime DatumTransakcije { get; set; }
    }
}
