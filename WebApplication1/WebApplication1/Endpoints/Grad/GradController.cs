using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using WebApplication1.Data;


namespace WebApplication1.Endpoints.Grad
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GradController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GradController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public ActionResult<GradResponse> Dodaj([FromBody] GradSnimiRequest x)
        {

            var noviObj = new Data.Models.Grad
            {

                PostanskiBroj = x.PostanskiBroj,
                DrzavaId = x.DrzavaId,
                ImeGrada = x.ImeGrada

            };

            _applicationDbContext.Grad.Add(noviObj);//

            _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."

            return new GradResponse
            {
                GradId = noviObj.GradId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<GradoviResponseGrad>>> GetSviGradovi()
        {
           
                var sviGradovi = await _applicationDbContext
                    .Grad
                    .Select(x => new GradoviResponseGrad
                    {
                        GradId = x.GradId,
                        PostanskiBroj = x.PostanskiBroj ?? "", 
                        ImeGrada = x.ImeGrada ?? "", 
                        DrzavaId = x.DrzavaId
                    })
                    .ToListAsync();

                return sviGradovi;
        }
        [HttpDelete]
        public  async Task<GradResponse> Obrisi([FromQuery] GradObrisiRequest request)
        {
            var gradovi = _applicationDbContext.Grad.FirstOrDefault(x => x.GradId == request.GradId);
            if (gradovi == null)
            {
                throw new Exception("nije pronadjen korisnik za id = " + request.GradId);
            }
            _applicationDbContext.Remove(gradovi);
            await _applicationDbContext.SaveChangesAsync();

            return new GradResponse
            {

            };
        }

    }
}
