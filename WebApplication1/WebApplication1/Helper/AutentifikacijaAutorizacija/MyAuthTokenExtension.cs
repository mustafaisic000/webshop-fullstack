using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;
using WebApplication1.Data;
using WebApplication1.Data.Models;




namespace WebApplication1.Helper.AutentifikacijaAutorizacija
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }
            [System.Text.Json.Serialization.JsonIgnore]
            public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }
            public bool isLogiran => korisnickiNalog != null;
            public bool isPermsijaKorisnik => isLogiran && (korisnickiNalog.isKorisnik);
            public bool isPermsijaAdministrator => isLogiran && (korisnickiNalog.isAdministrator);
            //public bool isPermisijaUposlenik => isLogiran && (korisnickiNalog.isUposlenik);
            public bool isPermisijaGost => !isLogiran;

        }
        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            AutentifikacijaToken token = httpContext.GetAuthToken();
            return new LoginInformacije(token);
        }
        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.KorisnickiNalog)
                .SingleOrDefault(x => token != null && x.Vrijednost == token);

            return korisnickiNalog;

        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    }
}
