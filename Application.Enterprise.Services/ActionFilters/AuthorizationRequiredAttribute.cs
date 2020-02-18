using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using Application.Enterprise.Services.Models;
using System;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Services.ActionFilters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "Token";
        //*ITokenServices TokenServices = new Models.TokenServices();
        String TokenServices = "";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //  Get API key provider
            //var provider = filterContext.ControllerContext.Configuration
            //    .DependencyResolver.GetService(typeof(ITokenServices)) as ITokenServices;
            try {
                if (filterContext.Request.Headers.Contains(Token))
                {
                    var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                    // Validate Token
                    /*if (TokenServices != null && !TokenServices.ValidateToken(tokenValue))
                    {
                        var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                        filterContext.Response = responseMessage;
                    }*/
                }
                else
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception err)
            {
                string s = err.Message;

                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", err.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            base.OnActionExecuting(filterContext);

        }
    }
}
