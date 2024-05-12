using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Helper.Service;
using Microsoft.AspNetCore.Http.Extensions;

namespace WebApplication1.Helper.AutentifikacijaAutorizacija
{
    public class AutorizacijaAtribut : TypeFilterAttribute
    {
        public AutorizacijaAtribut(): base(typeof(MyAuthorizeImpl))
        {
            //Arguments = new object[] { };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authService = context.HttpContext.RequestServices.GetService<MyAuthService>()!;
            var actionLogService = context.HttpContext.RequestServices.GetService<MyActionLogService>()!;

            if (!authService.isLogiran())
            {
                context.Result = new UnauthorizedObjectResult("niste logirani na sistem");
                return;
            }
            MyAuthInfo myAuthInfo = authService.GetAuthInfo();
            if (myAuthInfo.KorisnickiNalog.Is2FActive && !myAuthInfo.autentifikacijaToken.Is2FOtkljucano )
            {
                context.Result = new UnauthorizedObjectResult("niste otkljucali 2f ");
                return;
            }
            await next();
            await actionLogService.Create(context.HttpContext);
        }
    }
}
