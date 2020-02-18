using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enterprise.Services.Filters
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
       
        public string Password { get; set; }
       
        public string UserName { get; set; }
       
        public string UserId { get; set; }

        
       
        public BasicAuthenticationIdentity(string userName, string password)
            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }
    }
}
