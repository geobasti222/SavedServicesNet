using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Application.Enterprise.Services.Controllers
{
    
    public class BaseController : ApiController
    {
        public Application.Enterprise.CommonObjects.Error validateAuthenticatedUser(string UserId)
        {
            Application.Enterprise.CommonObjects.Error Response = new Application.Enterprise.CommonObjects.Error();

            /*if (AutenticationUserController.Instance.IsAuthenticated(UserId?.Trim()))
            {
                Response.existError = false;
            }
            else
            {
                Response = new Application.Enterprise.CommonObjects.Error() { existError = true, Code = 10, Description = "Authentication error" };
            }*/

            return Response;
        }

        
        public string GetIpClient()
        {
            string ipAddresClient = string.Empty;

           
                if (((System.Web.Http.ApiController)(this)).Request.Properties.ContainsKey("MS_HttpContext"))
                {
                    HttpContextBase context = (HttpContextBase)((System.Web.Http.ApiController)(this)).Request.Properties["MS_HttpContext"];

                    if (context.Request.ServerVariables["HTTP_VIA"] != null)
                    {
                        if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                            ipAddresClient = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                        else
                            ipAddresClient = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    }
                    else
                        ipAddresClient = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                }

               
          
            return ipAddresClient;
        }

        /// <summary>
        /// /Metodo para obtener usuario
        /// </summary>
        /// <returns>authHeaderValue</returns>
        /// 
        
        public string GetUser()
        {
            string user = string.Empty;
            string pass = string.Empty;

            if (((System.Web.Http.ApiController)(this)).Request.Properties.ContainsKey("MS_HttpContext"))
            {
                HttpContextBase context = (HttpContextBase)((System.Web.Http.ApiController)(this)).Request.Properties["MS_HttpContext"];

                if (context.Request.Headers["Basic"] != null)
                {
                    var authHeaderValue = context.Request.Headers["Basic"].ToString();

                    if (string.IsNullOrEmpty(authHeaderValue))
                        return null;

                    var autentication = authHeaderValue.Split(',');

                    //Se realiza esta validación ya que cuando mostraba mensaje de que usuario ya estaba conectado y se escogía la opción
                    //desconectarlo, arrojaba error porque "authHeaderValue" llegaba con una coma ",". (Solo en la plataforma de escritorio Alianza Valores)
                    if (autentication.Length >= 2)
                        authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(autentication[0]));
                    else
                    authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));

                    return authHeaderValue;
                }
                else
                    return null;
            }
            else
                return null;
        }

        
        public string SelectToken()
        {
            string token = string.Empty;
            
            if (((System.Web.Http.ApiController)(this)).Request.Properties.ContainsKey("MS_HttpContext"))
            {
                HttpContextBase context = (HttpContextBase)((System.Web.Http.ApiController)(this)).Request.Properties["MS_HttpContext"];

                if (context.Request.Headers.AllKeys.Any(x=>x=="Token"))
                {
                    token = context.Request.Headers["Token"].ToString();

                    if (string.IsNullOrEmpty(token))
                        return "";

                    return token;
                    
                }
                else
                    return "";
            }
            else
                return "";
        }
    }
}