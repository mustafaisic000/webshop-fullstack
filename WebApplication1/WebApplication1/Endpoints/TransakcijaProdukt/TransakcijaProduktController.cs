using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Endpoints.AdresaKorisnika;

namespace WebApplication1.Endpoints.TransakcijaProdukt
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransakcijaProduktController: ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TransakcijaProduktController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public ActionResult<TransakcijaProduktResponse> Dodaj([FromBody] TransakcijaProduktRequest request)
        {

            var noviObj = new Data.Models.TransakcijaProdukt
            {
                Kolicina= request.Kolicina,
                TransakcijaId= request.TransakcijaId,
                ProduktId= request.ProduktId,
               

            };

            _applicationDbContext.TransakcijaProdukt.Add(noviObj);//

            _applicationDbContext.SaveChanges();

            return new TransakcijaProduktResponse
            {
                TransakcijaProduktId = noviObj.TransakcijaProduktId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<TransakcijaProduktiResponse>>> GetSveTransakcijaProdukt()
        {
            var sveTransakcijaProdukt = await _applicationDbContext
                .TransakcijaProdukt
                .Select(x => new TransakcijaProduktiResponse
                {
                    TransakcijaProduktId=x.TransakcijaProduktId,
                    Kolicina=x.Kolicina,
                    TransakcijaId=x.TransakcijaId,
                    ProduktId=x.ProduktId

                })
                .ToListAsync();
            return sveTransakcijaProdukt;
        }
        [HttpDelete]
        public async Task<TransakcijaProduktResponse> Obrisi([FromQuery] TransakcijaProduktObrisiRequest request)
        {
            var transakcijaProdukt = _applicationDbContext.TransakcijaProdukt.FirstOrDefault(x => x.TransakcijaProduktId == request.TransakcijaProduktId);
            if (transakcijaProdukt == null)
            {
                throw new Exception("nije pronadjen transakcijaprodukt za id = " + request.TransakcijaProduktId);
            }
            _applicationDbContext.Remove(transakcijaProdukt);
            await _applicationDbContext.SaveChangesAsync();

            return new TransakcijaProduktResponse
            {

            };
        }
    }
}
