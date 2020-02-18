using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Enterprise.Services.OTP
{
    public static class FactoryAutenticationOTP
    {
        public static IAutenticationOTP Get(string TypeAutenticationOTP)
        {
            switch (TypeAutenticationOTP)
            {
                case "COMPANYNAME":
                    return AutenticationOTP.Instance;
                case "RSA":
                    return AutenticationRSA.Instance;
                //case "SAFEWAY":
                //    return AutenticationSafeway.Instance;
                default:
                    return AutenticationOTP.Instance;
            }
        }
    }
}