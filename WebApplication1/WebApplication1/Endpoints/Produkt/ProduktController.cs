using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Endpoints.AdresaKorisnika;
using WebApplication1.Helper.Service;


namespace WebApplication1.Endpoints.Produkt
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProduktController: ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;
        public ProduktController(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }
        [HttpPost]
        public ActionResult<ProduktResponse> Dodaj([FromBody] ProduktRequest request)
        {

            var noviObj = new Data.Models.Produkt
            {

                Naziv=request.Naziv,
                Opis=request.Opis,
                Cijena=request.Cijena,
                DatumObjave=request.DatumObjave,
                Slika=request.Slika,
                KategorijaId=request.KategorijaId,
                JelObrisan=request.JelObrisan,
                Kolicina=request.Kolicina,
                JelProdan=request.JelProdan,

            };

            _applicationDbContext.Produkt.Add(noviObj);//

            _applicationDbContext.SaveChanges();

            return new ProduktResponse
            {
                ProduktId = noviObj.ProduktId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<ProduktiResponse>>> GetSveProdukte()
        {
            var sveProdukte = await _applicationDbContext
                .Produkt
                .Select(x => new ProduktiResponse
                {
                   ProduktId= x.ProduktId,
                   Naziv= x.Naziv,
                   Opis= x.Opis,
                   Cijena= x.Cijena,
                   DatumObjave= x.DatumObjave,
                   Slika= x.Slika,
                   KategorijaId= x.KategorijaId,
                   JelObrisan= x.JelObrisan,
                   Kolicina= x.Kolicina,
                   JelProdan= x.JelProdan,

                })
                .ToListAsync();
            return sveProdukte;
        }

        [HttpGet]
        public async Task<ProduktListResponse> PretraziProduktPoNazivu([FromQuery] ProduktPretragaRequest request)
        {
            var produkti = await _applicationDbContext
                .Produkt
                .Where(x => request.Naziv == null || x.Naziv.ToLower().Contains(request.Naziv.ToLower()))
                .Select(x => new ProduktiResponse
                {
                    ProduktId = x.ProduktId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Cijena = x.Cijena,
                    DatumObjave = x.DatumObjave,
                    Slika = x.Slika,
                    KategorijaId = x.KategorijaId,
                    JelObrisan = x.JelObrisan,
                    Kolicina = x.Kolicina,
                    JelProdan = x.JelProdan,
                })
                .ToListAsync();

            return new ProduktListResponse
            {
                Produkti = produkti
            };
        }

        [HttpGet]
        public async Task<ActionResult<ProduktiResponse>> PretraziProduktPoId([FromQuery] ProductPretragaPoIdRequest request)
        {
            if (!_authService.isLogiran())
                throw new Exception("Nije logiran");
            KorisnickiNalog korisnickiNalog = _authService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isKorisnik || korisnickiNalog.isAdministrator))
            {
                throw new Exception("Nema pravo pristupa");
            }
            var produkti = await _applicationDbContext
                .Produkt
                .Where(x => x.ProduktId==request.ProduktId)
                .Select(x => new ProduktiResponse
                {
                    ProduktId = x.ProduktId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Cijena = x.Cijena,
                    DatumObjave = x.DatumObjave,
                    Slika = x.Slika,
                    KategorijaId = x.KategorijaId,
                    JelObrisan = x.JelObrisan,
                    Kolicina = x.Kolicina,
                    JelProdan = x.JelProdan,

                }).FirstOrDefaultAsync();
            return produkti;
        }

        [HttpDelete]
        public async Task<ProduktResponse> Obrisi([FromQuery] ProduktObrisiRequest request)
        {
            var produkti = _applicationDbContext.Produkt.FirstOrDefault(x => x.ProduktId == request.ProduktId);
            if (produkti == null)
            {
                throw new Exception("nije pronadjen Produkt za id = " + request.ProduktId);
            }
            _applicationDbContext.Remove(produkti);
            await _applicationDbContext.SaveChangesAsync();

            return new ProduktResponse
            {

            };
        }
        [HttpPost]
        public async Task<ActionResult<ProduktUpdateResponse>> Update([FromBody] ProduktRequest request)
        {
            var produkt =  _applicationDbContext.Produkt.FirstOrDefault(x => x.ProduktId == request.ProduktId);

            if (produkt == null)
            {
                throw new Exception("nije pronadjen produkt za id = " + request.ProduktId);
            }

            produkt.Naziv = request.Naziv;
            produkt.Opis = request.Opis;
            produkt.Cijena = request.Cijena;
            produkt.Slika = request.Slika;
            produkt.KategorijaId = request.KategorijaId;
            produkt.JelObrisan = request.JelObrisan;
            produkt.Kolicina = request.Kolicina;
            produkt.JelProdan = request.JelObrisan;


            await _applicationDbContext.SaveChangesAsync();//izvrašva se "insert into Ispit value ...."

            return new ProduktUpdateResponse
            {
                ProduktId = produkt.ProduktId
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<ProduktiResponse>>> GetProduktPoKategorijaId(int categoryId)
        {
            var products = await _applicationDbContext
                .Produkt
                .Where(p => p.KategorijaId == categoryId)
                .Select(p => new ProduktiResponse
                {
                    ProduktId = p.ProduktId,
                    Naziv = p.Naziv,
                    Opis = p.Opis,
                    Cijena = p.Cijena,
                    DatumObjave = p.DatumObjave,
                    Slika = p.Slika,
                    KategorijaId = p.KategorijaId,
                    JelObrisan = p.JelObrisan,
                    Kolicina = p.Kolicina,
                    JelProdan = p.JelProdan,
                })
                .ToListAsync();

            return products;
        }
    }
}

