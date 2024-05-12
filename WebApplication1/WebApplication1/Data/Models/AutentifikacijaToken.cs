using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Models
{
  public class AutentifikacijaToken
  {
    [Key]
    public int Id { get; set; }
    public string Vrijednost { get; set; }
    [ForeignKey(nameof(KorisnickiNalog))]
    public int KorisnickiNalogId {get;set;}
    public KorisnickiNalog KorisnickiNalog { get; set; }
    public DateTime vrijemeEvidentiranja { get; set; }
    public string IpAdresa { get; set; }
    [JsonIgnore]
    public string? TwoFKey { get;  set; }
    public bool Is2FOtkljucano { get;  set; }
    }
}
