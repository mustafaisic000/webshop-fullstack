using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Endpoints.Grad;

namespace WebApplication1.Endpoints.Drzava
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrzavaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DrzavaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public ActionResult<DrzavaResponse> Dodaj([FromBody] DrzavaRequest request)
        {
            var noviObj = new Data.Models.Drzava
            {
                Naziv = request.Naziv,
                Restrikcije = request.Restrikcije,
            };
            _applicationDbContext.Drzava.Add(noviObj);
            _applicationDbContext.SaveChanges();

            return new DrzavaResponse
            {
                DrzavaId = noviObj.DrzavaId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<DrzaveResponse>>> GetSveDrzave()
        {

            var sveDrzave = await _applicationDbContext
                .Drzava
                .Select(x => new DrzaveResponse
                {
                    DrzavaId= x.DrzavaId,   
                    Naziv=x.Naziv ?? "",
                    Restrikcije=x.Restrikcije

                }).ToListAsync();

            return sveDrzave;
        }
        [HttpDelete]
        public async Task<DrzavaResponse> Obrisi([FromQuery] DrzavaObrisiRequest request)
        {
            var drzave = _applicationDbContext.Drzava.FirstOrDefault(x => x.DrzavaId == request.DrzavaId);
            if (drzave == null)
            {
                throw new Exception("nije pronadjen drzava za id = " + request.DrzavaId);
            }
            _applicationDbContext.Remove(drzave);
            await _applicationDbContext.SaveChangesAsync();

            return new DrzavaResponse
            {

            };
        }
    }
}
