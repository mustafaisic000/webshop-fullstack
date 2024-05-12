namespace WebApplication1.Endpoints.Produkt
{
    public class ProduktRequest
    {
        public int ProduktId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public decimal Cijena { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Slika { get; set; } = null!;
        public int KategorijaId { get; set; }
        public bool JelObrisan { get; set; }
        public int Kolicina { get; set; }
        public bool JelProdan { get; set; }
    }
}
