namespace WebApplication1.Endpoints.Drzava
{
    public class DrzavaListResponse
    {
        public List<DrzaveResponse> Drzave { get; set; }    
    }
    public class DrzaveResponse
    {
        public int DrzavaId { get; set; }
        public string Naziv { get; set; } = null!;
        public bool Restrikcije { get; set; }
    }
}
