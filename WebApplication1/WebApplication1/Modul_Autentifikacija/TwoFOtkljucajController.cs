using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Helper;
using WebApplication1.Helper.Service;
using static WebApplication1.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;
using WebApplication1.Modul_Autentifikacija.ViewModels;
using WebApplication1.Helper.AutentifikacijaAutorizacija;

namespace WebApplication1.Modul_Autentifikacija
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[AutorizacijaAtribut]
    public class TwoFOtkljucajController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly MyAuthService _myAuthService;
        public TwoFOtkljucajController(ApplicationDbContext dbContext, MyAuthService myAuthService)
        {
            this._dbContext = dbContext;
            _myAuthService = myAuthService;

        }
        [HttpPost]
        public  ActionResult Otkljucaj([FromBody] AuthTwoFOtkljucaj x)
        {
            if(!_myAuthService.GetAuthInfo().isLogiran)
            {
                    throw new Exception("niste logirani");
             }
            var token = _myAuthService.GetAuthInfo().autentifikacijaToken;
            if (token is null) 
            {
                throw new ArgumentNullException(nameof(token));
            }
            if (x.Kljuc == token.TwoFKey)
            {
                token.Is2FOtkljucano = true;
                 _dbContext.SaveChanges();
            }
            
            return Ok();
        }
    }
}
