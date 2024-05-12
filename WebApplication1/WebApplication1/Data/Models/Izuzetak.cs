namespace WebApplication1.Data.Models
{
    public partial class Izuzetak
    {
        public int IzuzetakId { get; set; }
        public int Tip { get; set; }
        public string StackTrace { get; set; } = null!;
        public DateTime Vrijeme { get; set; }
        public string Poruka { get; set; } = null!;
        public int OzbiljnostId { get; set; }

        public virtual Ozbiljnost Ozbiljnost { get; set; } = null!;
    }
}
