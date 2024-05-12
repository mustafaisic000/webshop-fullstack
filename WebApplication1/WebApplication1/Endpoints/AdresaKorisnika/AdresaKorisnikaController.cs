using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;


namespace WebApplication1.Endpoints.AdresaKorisnika
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdresaKorisnikaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AdresaKorisnikaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public ActionResult<AdresaKorisnikResponse> Dodaj([FromBody] AdresaKorisnikaRequest x)
        {

            var noviObj = new Data.Models.AdresaKorisnika
            {

                NazivUlice = x.NazivUlice,
                GradId = x.GradId

            };

            _applicationDbContext.AdresaKorisnika.Add(noviObj);//

            _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."

            return new AdresaKorisnikResponse
            {
                AdresaKorisnikaId = noviObj.AdresaKorisnikaId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<AdreseResponse>>> GetAdreseKorisnika()
        {
            var sveAdrese = await _applicationDbContext
                .AdresaKorisnika
                .Select(x => new AdreseResponse
                {
                     AdresaKorisnikaId= x.AdresaKorisnikaId,
                    NazivUlice = x.NazivUlice,
                    GradId = x.GradId ,
                    
                })
                .ToListAsync();
            return sveAdrese;
        }
        [HttpDelete]
        public async Task<AdresaKorisnikResponse> Obrisi([FromQuery] AdresaKorisnikaObrisiRequest request)
        {
            var adrese = _applicationDbContext.AdresaKorisnika.FirstOrDefault(x => x.AdresaKorisnikaId == request.AdresaKorisnikaId);
            if (adrese == null)
            {
                throw new Exception("nije pronadjen korisnik za id = " + request.AdresaKorisnikaId);
            }
            _applicationDbContext.Remove(adrese);
            await _applicationDbContext.SaveChangesAsync();

            return new AdresaKorisnikResponse
            {

            };
        }
        [HttpPost]
        public ActionResult<AdresaKorisnikaUpdateResponse> UpdateAdreseKorisnika([FromBody] AdresaKorisnikaRequest request)
        {
            var adresaKorisnika = _applicationDbContext.AdresaKorisnika.FirstOrDefault(x => x.AdresaKorisnikaId == request.AdresaKorisnikaId);

            if (adresaKorisnika == null)
            {
                throw new Exception("nije pronadjen ispit za id = " + request.AdresaKorisnikaId);
            }

            adresaKorisnika.NazivUlice = request.NazivUlice;
           
             _applicationDbContext.SaveChangesAsync();//izvrašva se "insert into Ispit value ...."

            return new AdresaKorisnikaUpdateResponse
            {
                AdresaKorisnikaId= adresaKorisnika.AdresaKorisnikaId
            };
        }
    }
}
