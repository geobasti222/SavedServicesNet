using Application.Enterprise.Services.Controllers;
using System.Threading;
using System.Web.Http.Controllers;

namespace Application.Enterprise.Services.Filters
{

    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {

        public ApiAuthenticationFilter()
        {
        }


        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }


        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {

            /*if (AutenticationUserController.Instance.IsAuthenticated(username))
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                    basicAuthenticationIdentity.UserId = username;
                return true;
            }*/

            return false;
        }
    }
}
