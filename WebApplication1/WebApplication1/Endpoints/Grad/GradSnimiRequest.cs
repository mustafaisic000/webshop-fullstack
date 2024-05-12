using WebApplication1.Data.Models;

namespace WebApplication1.Endpoints.Grad
{
    public class GradSnimiRequest
    {
        public int GradId { get; set; }
        public string PostanskiBroj { get; set; } = null!;
        public int DrzavaId { get; set; }
        public string ImeGrada { get; set; } = null!;
    }
}
