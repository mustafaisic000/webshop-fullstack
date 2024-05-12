

namespace WebApplication1.Endpoints.Grad
{
    public class GradoviResponse
    {
        public List<GradoviResponseGrad> Gradovi { get; set; }
    }
    public class GradoviResponseGrad
    {
        public int GradId { get; set; }
        public string PostanskiBroj { get; set; } = null!;
        public int DrzavaId { get; set; }
        public string ImeGrada { get; set; } = null!;
    }
    }
