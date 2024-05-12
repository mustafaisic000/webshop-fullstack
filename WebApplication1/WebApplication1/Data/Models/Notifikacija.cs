using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public partial class Notifikacija
    {
        [Key]
        public int NotifikacijaId { get; set; }
        public DateTime DatumSlanja { get; set; }
        public string? Sadrzaj { get; set; }

        [ForeignKey(nameof(TipNotifikacije))]
        public int TipNotifikacijeId { get; set; }
        public virtual TipNotifikacije TipNotifikacije { get; set; } = null!;
    }
}
