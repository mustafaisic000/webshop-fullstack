using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Endpoints.TransakcijaProdukt
{
    public class TransakcijaProduktListResponse
    {
        public List<TransakcijaProduktiResponse> TransakcijaProduktI { get; set; }
    }
    public class TransakcijaProduktiResponse
    {
        public int TransakcijaProduktId { get; set; }
        public int Kolicina { get; set; }
        public int TransakcijaId { get; set; }
        public int ProduktId { get; set; }
    }
}
