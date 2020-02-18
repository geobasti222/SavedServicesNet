using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Services.OTP
{
    public class AutenticationSafeway : IAutenticationOTP
    {
        private static volatile AutenticationSafeway instance;
        private static object syncRoot = new Object();

        public static AutenticationSafeway Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AutenticationSafeway();
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
                string system = string.Empty;
                string clientSystemPassword = string.Empty;
                string commonName = string.Empty;
                string applicationName = string.Empty;
                string password = strToken;
                string otpInfo = string.Empty;
                string domainType = string.Empty;

                //SafewayAdapterService.OTPSoapClient proxy = new SafewayAdapterService.OTPSoapClient();
                //string respuesta = proxy.validateOTP(system, clientSystemPassword, commonName, applicationName, password, otpInfo, domainType);

                //otp_result result = Deserialize<otp_result>(respuesta);

                //return result.return_code.Equals("0");
                return false;

            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", err.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
               // Data.Error.Adicionar(DateTime.Now, "ygz", "123", err.Message.ToString());
            }
            return response;
        }

        public static T Deserialize<T>(string xmlText)
        {
            if (String.IsNullOrWhiteSpace(xmlText)) return default(T);

            using (StringReader stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }

    }

    public class otp_result
    {
        public string return_code;
        public string error_description;
        public string system;
        public string common_name;

    }
}