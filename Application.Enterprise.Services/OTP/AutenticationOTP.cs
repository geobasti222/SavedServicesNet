using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Services.OTP
{
    public class AutenticationOTP : IAutenticationOTP
    {
        private static volatile AutenticationOTP instance;
        private static object syncRoot = new Object();

        public static AutenticationOTP Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AutenticationOTP();
                    }
                }
                return instance;
            }
        }

        public class TokenInfo
        {
            public int application { get; set; }
            public string username { get; set; }
            public string otp { get; set; }
            public string account { get; set; }
        }

        public class Result
        {
            public bool isOK { get; set; }
            public string error { get; set; }
        }

        public Result PostRequest(TokenInfo RequestObject, Result ResponseObject)
        {
            try
            {
                //string strUrl = "http://alianzavalorweb.cloudapp.net/AlianzaAdminToken/api/Token/ValidateToken";
                string strUrl = ConfigurationManager.AppSettings["UrlOtpcompanyname"].ToString();
                WebClient proxy = new WebClient();
                Uri serviceUri = new Uri(strUrl);

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(RequestObject.GetType());
                MemoryStream mem = new MemoryStream();
                serializer.WriteObject(mem, RequestObject);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                string[] a = proxy.Headers.AllKeys;
                proxy.Headers["Content-type"] = "application/json";
                proxy.Encoding = Encoding.UTF8;
                var response = proxy.UploadString(serviceUri, data);
                byte[] byteArray = Encoding.UTF8.GetBytes(response);
                MemoryStream responseStream = new MemoryStream(byteArray);

                serializer = new DataContractJsonSerializer(ResponseObject.GetType());
                ResponseObject = (Result)serializer.ReadObject(responseStream);
                

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Data.Error.Adicionar(DateTime.Now, "ValidateOTP", "","Error " + ex.Message + ", stack " + ex.StackTrace);
            }
            return ResponseObject;
        
           
        }

        public bool ValidateToken(string strUser, string strToken, string strAccount = null, string strApp = null)
        {
            Result result = new Result();
            result = PostRequest(new TokenInfo { username = strUser, account = strAccount, application = Convert.ToInt32(strApp), otp = strToken }, result);

            if (result.isOK)
                return true;
            else

                return false;

        }
    }
}