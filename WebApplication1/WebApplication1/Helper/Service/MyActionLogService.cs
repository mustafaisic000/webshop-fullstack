using Microsoft.AspNetCore.Http;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using Microsoft.AspNetCore.Http.Extensions;

namespace WebApplication1.Helper.Service
{
    public class MyActionLogService
    {
        public async Task Create(HttpContext httpContext)
        {
            var authService = httpContext.RequestServices.GetService<MyAuthService>()!;
            var request = httpContext.Request;

            var queryString = request.Query;

            //if (queryString.Count == 0 && !request.HasFormContentType)
            //    return 0;

            //IHttpRequestFeature feature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            string detalji = "";
            if (request.HasFormContentType)
            {
                foreach (string key in request.Form.Keys)
                {
                    detalji += " | " + key + "=" + request.Form[key];
                }
            }
            StreamReader reader = new StreamReader(request.Body);
            string bodyText= await reader.ReadToEndAsync();

            var x = new LogKretanjePoSistemu
            {
                korisnik = authService.GetAuthInfo().KorisnickiNalog!,
                Vrijeme = DateTime.Now,
                QueryPath = request.GetEncodedPathAndQuery(),
                PostData = detalji + "" + bodyText,
                IpAdresa = request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                ExceptionMessage="",
            };

            //if (exceptionMessage != null)
            //{
            //    x.isException = true;
            //    x.ExceptionMessage = exceptionMessage.Error.Message + " |" + exceptionMessage.Error.InnerException;
            //}

            ApplicationDbContext db = request.HttpContext.RequestServices.GetService<ApplicationDbContext>();

            db.Add(x);
           await db.SaveChangesAsync();
        }
    }
}
