namespace WebApplication1.Endpoints.TransakcijaProdukt
{
    public class TransakcijaProduktRequest
    {
        public int TransakcijaProduktId { get; set; }
        public int Kolicina { get; set; }
        public int TransakcijaId { get; set; }
        public int ProduktId { get; set; }
    }
}
