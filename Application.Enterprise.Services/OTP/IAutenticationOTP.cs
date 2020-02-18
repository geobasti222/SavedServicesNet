using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Enterprise.Services.OTP
{
    public interface IAutenticationOTP
    {
        bool ValidateToken(string strUser ,string strToken ,string strAccount = null, string strApp = null);
    }
}