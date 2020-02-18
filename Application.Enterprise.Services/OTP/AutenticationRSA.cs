using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Services.OTP
{
    public  class AutenticationRSA : IAutenticationOTP
    {
        private static volatile AutenticationRSA instance;
        private static object syncRoot = new Object();

        public static AutenticationRSA Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AutenticationRSA();
                    }
                }
                return instance;
            }
        }


        public bool ValidateToken(string strUser, string strToken, string strAccount = null, string strApp = null)
        {
            bool response = false;
            try
            {
                //RSAAdapterService.RSAAdapterServiceClient proxy = new RSAAdapterService.RSAAdapterServiceClient();
                //RSAAdapterService.Response respuesta = proxy.ValidateToken(new RSAAdapterService.User { Name = strUser, Token = strToken });
                response = false;//respuesta.IsAuthenticated;

                //response = false;
            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", err.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Data.Error.Adicionar(DateTime.Now, "ygz", "123", err.Message.ToString());
            }

            return response;
        }
    }
}