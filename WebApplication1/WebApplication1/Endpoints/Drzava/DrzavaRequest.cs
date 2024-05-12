namespace WebApplication1.Endpoints.Drzava
{
    public class DrzavaRequest
    {
        public int DrzavaId { get; set; }
        public string Naziv { get; set; } = null!;
        public bool Restrikcije { get; set; }
    }
}
