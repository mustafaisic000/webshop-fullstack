namespace WebApplication1.Endpoints.Transakcije
{
    public class TransakcijaResponse
    {
        public int TransakcijaId { get; set; }
        public int KorisnickiNalogId { get; set; }
        public decimal UkupnaCijena { get; set; }
        public DateTime DatumTransakcije { get; set; }
    }
}
