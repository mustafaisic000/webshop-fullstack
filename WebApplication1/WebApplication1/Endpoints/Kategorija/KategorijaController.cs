using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Endpoints.AdresaKorisnika;
using WebApplication1.Endpoints.Produkt;

namespace WebApplication1.Endpoints.Kategorija
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KategorijaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public KategorijaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public ActionResult<KategorijaResponse> Dodaj([FromBody] KategorijaRequest x)
        {

            var noviObj = new Data.Models.Kategorija
            {

                Naziv = x.Naziv,
                Opis = x.Opis

            };

            _applicationDbContext.Kategorija.Add(noviObj);//

            _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."

            return new KategorijaResponse
            {
                KategorijaId = noviObj.KategorijaId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<KategorijeResponse>>> GetSveKategorije()
        {
            var sveKategorije = await _applicationDbContext
                .Kategorija
                .Select(x => new KategorijeResponse
                {
                    KategorijaId = x.KategorijaId,
                    Naziv = x.Naziv,
                    Opis= x.Opis,

                })
                .ToListAsync();
            return sveKategorije;
        }
        [HttpGet]
        public async Task<ActionResult<KategorijaResponse>> PretraziKategorijuPoId([FromQuery] KategorijaPretragaIDResponse request)
        {
            var kategorije = await _applicationDbContext
                .Kategorija
                .Where(x => x.KategorijaId == request.KategorijaId)
                .Select(x => new KategorijaResponse
                {
                    KategorijaId = x.KategorijaId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,

                }).FirstOrDefaultAsync();
            return kategorije;
        }
        [HttpPost]
        public async Task<ActionResult<KategorijaUpdateResponse>> UpdateKategorija([FromBody] KategorijaRequest request)
        {
            var kategorija = await _applicationDbContext.Kategorija.FirstOrDefaultAsync(x => x.KategorijaId == request.KategorijaId);

            if (kategorija == null)
            {
                throw new Exception("Kategorija with ID " + request.KategorijaId + " not found.");
            }

            kategorija.Naziv = request.Naziv;
            kategorija.Opis = request.Opis;

            await _applicationDbContext.SaveChangesAsync();

            return new KategorijaUpdateResponse
            {
                KategorijaId = kategorija.KategorijaId
            };
        }
    }
}
