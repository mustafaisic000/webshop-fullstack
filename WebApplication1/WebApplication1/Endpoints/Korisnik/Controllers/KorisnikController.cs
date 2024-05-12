
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Endpoints.Korisnik.Controllers;
using WebApplication1.Helper.AutentifikacijaAutorizacija;
using WebApplication5.KorisnikModul.ViewModels;


namespace WebApplication5.KorisnikModul.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class KorisnikController:ControllerBase
  {
    private ApplicationDbContext _dbContext;
    public KorisnikController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    [HttpPost]
    public ActionResult Add([FromBody]RegistracijaVM registracijaVM)
    {
      var noviKorisnik = new Korisnik()
      {
        Ime = registracijaVM.Ime,
        Prezime = registracijaVM.Prezime,
        Email = registracijaVM.Email,
          AdresaKorisnikaId = registracijaVM.AdresaKorisnikaId,
          AdresaZaDostavuId = registracijaVM.AdresaZaDostavuId,
        KorisnickoIme = registracijaVM.Username,
        Lozinka = registracijaVM.Password,
          
      };
      _dbContext.Korisnik.Add(noviKorisnik);
      _dbContext.SaveChanges();
      return Ok(noviKorisnik.Id);
    }


        //    [HttpPost("{id}")]
        //    public ActionResult AddProfileImage(int id, [FromForm] KorisnikAddSlikaVM x)
        //    {
        //        Korisnik korisnik = _dbContext.Korisnik.FirstOrDefault(s => s.Id == id);

        //        if (korisnik == null)
        //            return BadRequest("neispravan korisnik ID");
        //        if (x.slika.Length > 300 * 1000)
        //            return BadRequest("max velicina fajla je 300 KB");

        //        string ekstenzija = Path.GetExtension(x.slika.FileName);

        //        var filename = $"{Guid.NewGuid()}{ekstenzija}";

        //        x.slika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
        //        korisnik.Slika = Config.SlikeURL + filename;
        //        _dbContext.SaveChanges();

        //        return Ok(korisnik);

        //    }

        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        //        return BadRequest("nije logiran");

        //    Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;
        //    List<OnlineNarudzba> trenutneNarudzbe = _dbContext.OnlineNarudzba.Where(n => n.KorisnikID == korisnik.Id && n.StatusNarudzbeID != 1 && n.Zakljucena).ToList();
        //    if (trenutneNarudzbe != null && trenutneNarudzbe?.Count != 0)
        //        return BadRequest("Trenutno ne mozete deaktivirati profil jer su Vase narudzbe u izradi");

        //    List<OnlineNarudzba> narudzbe = _dbContext.OnlineNarudzba.Where(n => n.KorisnikID == korisnik.Id).ToList();
        //    List<NarudzbaStavka> stavkeNarudzbi = new List<NarudzbaStavka>();
        //    foreach (OnlineNarudzba narudzba in narudzbe)
        //    {
        //        stavkeNarudzbi.AddRange(_dbContext.NarudzbaStavka.Where(sn => sn.OnlineNarudzbaId == narudzba.ID).ToList());
        //    }
        //    //List<Rezervacija> rezervacije = _dbContext.Rezervacija.Where(r => r.KorisnikId == korisnik.Id).ToList();
        //    List<AutentifikacijaToken> logovi = _dbContext.AutentifikacijaToken.Where(at => at.KorisnickiNalogId == korisnik.Id).ToList();

        //    _dbContext.NarudzbaStavka.RemoveRange(stavkeNarudzbi);
        //    _dbContext.OnlineNarudzba.RemoveRange(narudzbe);
        //    //_dbContext.Rezervacija.RemoveRange(rezervacije);
        //    _dbContext.AutentifikacijaToken.RemoveRange(logovi);
        //    _dbContext.Korisnik.Remove(korisnik);
        //    _dbContext.KorisnickiNalog.Remove(korisnik);
        //    _dbContext.SaveChanges();

        //    return Ok();
        //}
        [HttpGet]
        public List<Korisnik> GetAll()
        {
            return _dbContext.Korisnik.ToList();
        }

        //[HttpPost]
        //public ActionResult UpdateSlika([FromForm] KorisnikAddSlikaVM korisnikAddSlikaVM)
        //{

        //    if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        //        return BadRequest("nije logiran");

        //    Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

        //        if (korisnikAddSlikaVM.slikaKorisnika != null && korisnik != null)
        //        {
        //            if (korisnikAddSlikaVM.slikaKorisnika.Length > 250 * 1000)
        //                return BadRequest("max velicina fajla je 250 KB");

        //            string ekstenzija = Path.GetExtension(korisnikAddSlikaVM.slikaKorisnika.FileName);

        //            var filename = $"{Guid.NewGuid()}{ekstenzija}";

        //            korisnikAddSlikaVM.slikaKorisnika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
        //            korisnik.Adresa = Config.SlikeURL + filename;
        //            _dbContext.SaveChanges();
        //        }

        //        return Ok(korisnik);

        //}


        [HttpPost]
        public ActionResult Update([FromBody] KorisnikUpdateVM korisnikUpdateVM)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            korisnik.Ime = korisnikUpdateVM.Ime;
            korisnik.Prezime = korisnikUpdateVM.Prezime;
            korisnik.Email = korisnikUpdateVM.Email;
            korisnik.AdresaKorisnikaId = korisnikUpdateVM.AdresaKorisnikaId;
            korisnik.AdresaZaDostavuId = korisnikUpdateVM.AdresaZaDostavuId;
            korisnik.KorisnickoIme = korisnikUpdateVM.KorisnickoIme;
            korisnik.Lozinka = korisnikUpdateVM.Lozinka;
            

            _dbContext.SaveChanges();
            return Ok(korisnik);
        }
    }
}
