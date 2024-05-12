using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Endpoints.Grad;
using WebApplication1.Endpoints.Transakcija;

namespace WebApplication1.Endpoints.Transakcije
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransakcijaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TransakcijaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public ActionResult<TransakcijaResponse> Dodaj([FromBody] TransakcijaRequest x)
        {


            var noviObj = new Data.Models.Transakcija
            {

                KorisnickiNalogId = x.KorisnickiNalogId,
                UkupnaCijena = x.UkupnaCijena,
                DatumTransakcije = x.DatumTransakcije

            };

            _applicationDbContext.Transakcija.Add(noviObj);//

            _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."

            return new TransakcijaResponse
            {
                 TransakcijaId= noviObj.TransakcijaId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<TransakcijeListaResponse>>> GetSveTransakcije()
        {

            var sveTransakcije = await _applicationDbContext
                .Transakcija
                .Select(x => new TransakcijeListaResponse
                {
                    TransakcijaId = x.TransakcijaId,
                    KorisnickiNalogId = x.KorisnickiNalogId,
                    UkupnaCijena = x.UkupnaCijena,
                    DatumTransakcije = x.DatumTransakcije
                })
                .ToListAsync();

            return sveTransakcije;
        }
    }
}
