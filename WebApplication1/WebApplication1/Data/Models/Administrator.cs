using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    [Table("Administrator")]
    public class Administrator : KorisnickiNalog
    {
        public DateTime DatumKreiranja { get; set; }
    }
}
