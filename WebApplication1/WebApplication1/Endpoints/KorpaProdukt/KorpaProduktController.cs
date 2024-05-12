using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Endpoints.AdresaKorisnika;
using WebApplication1.Endpoints.Kategorija;
using WebApplication1.Helper.AutentifikacijaAutorizacija;
using WebApplication1.Helper.Service;


namespace WebApplication1.Endpoints.KorpaProdukt
{
    [ApiController]
   // [AutorizacijaAtribut(false,true)]
    [Route("[controller]/[action]")]
    [AutorizacijaAtribut]
    public class KorpaProduktController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;
        public KorpaProduktController(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]
        public ActionResult<KorpaProduktResponse> Dodaj([FromBody] KorpaProduktRequest request)
        {
            var noviObj = new Data.Models.KorpaProdukt
            {
                KorisnickiNalogId = request.KorisnickiNalogId,
                ProduktId = request.ProduktId,
            };

            _applicationDbContext.KorpaProdukt.Add(noviObj);
            _applicationDbContext.SaveChanges();

            return new KorpaProduktResponse
            {
                KorpaProduktId = noviObj.KorpaProduktId
            };
        }
     
        [HttpGet]
        public async Task<ActionResult<List<KorpaProduktiResponse>>> GetSveKorpaProdukt()
        {
            KorisnickiNalog korisnickiNalog = _authService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isKorisnik || korisnickiNalog.isAdministrator))
            {
                throw new Exception("Nema pravo pristupa");
            }
                
            var sveKorpaProdukt = await _applicationDbContext
                .KorpaProdukt
                .Select(x => new KorpaProduktiResponse
                {
                    KorpaProduktId= x.KorpaProduktId,
                    KorisnickiNalogId = x.KorisnickiNalogId,
                    ProduktId=x.ProduktId,

                })
                .ToListAsync();
            return sveKorpaProdukt;
        }
        [HttpDelete]
        public async Task<KorpaProduktResponse> Obrisi([FromQuery] KorpaProduktObrisiRequest request)
        {
            KorisnickiNalog korisnickiNalog = _authService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isKorisnik || korisnickiNalog.isAdministrator))
            {
                throw new Exception("Nema pravo pristupa");
            }
            var korpaProdukt  = _applicationDbContext.KorpaProdukt.FirstOrDefault(x => x.KorpaProduktId == request.KorpaProduktId);
            if (korpaProdukt == null)
            {
                throw new Exception("nije pronadjen KorpaProdukt za id = " + request.KorpaProduktId);
            }
            _applicationDbContext.Remove(korpaProdukt);
            await _applicationDbContext.SaveChangesAsync();

            return new KorpaProduktResponse
            {

            };
        }
    }
}
