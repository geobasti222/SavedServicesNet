using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.RealTime;
using Application.Enterprise.Activity;
using System.Security.Cryptography;
using System.Text;
using System.Activities;
using System.IO;
using System.Reflection;
using System.Diagnostics;


namespace Application.Enterprise.Services.Models
{
    public class Autentication : IAutentication
    {


        private Dictionary<string, DateTime> _loggedUsers = new Dictionary<string, DateTime>();
        private readonly object _loggedUsersLock = new object();
        /// <summary>
        /// Validar la conexion de la plataforma anterior 
        /// </summary>
        /// <param name="strIdUser">Usuario a logear en la app</param>
        /// <returns>booleano que indica la conexion</returns>
        public bool IsConnectInLegay(string strIdUser)
        {
            try
            {
                //return new WSDisconnect.PlataformaWeb().EstaConectado(strIdUser);
                return false;
            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", err.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Parta registrar en el log 
                /*Infrastructure.Models.Error ErrReturn = new Infrastructure.Models.Error();
                ErrReturn.Description = err.Message;*/
                return false;
            }
        }

        private bool AlreadyLogged(string strIdUser)
        {
            // TODO hay que mandar esto persistente y que soporte WebFarm
            return (_loggedUsers.ContainsKey(strIdUser) || IsConnectInLegay(strIdUser));
        }

        public void RegisterLoggedUser(string strIdUser)
        {
            lock (_loggedUsersLock)
            {
                _loggedUsers[strIdUser.Trim()] = DateTime.Now;
            }
        }

        public void UnRegisterLoggedUser(string strIdUser)
        {
            lock (_loggedUsersLock)
            {
                if (_loggedUsers.Select(u => u.Key == strIdUser).Count() > 1)
                {
                    _loggedUsers.Remove(strIdUser);
                    _loggedUsers[strIdUser] = DateTime.Now;
                }
                else
                {
                    _loggedUsers.Remove(strIdUser);
                }
            }
        }

        private void SendDisconnect(string strIdUser, string strPass)
        {
            /// TODO hay que manejar cuando algo ocurra enviando la peticion al legacy
            ExternalTickerNotifier.NotifyDisconnection(strIdUser);
            //ExternalTickerNotifier.NotifyDisconnectionBroadCast(strIdUser);

            if (IsConnectInLegay(strIdUser))
                DisconnectInLegacy(strIdUser, strPass);

        }

        private void SendDisconnectAdmin(string strIdUser, string strPass)
        {
            /// TODO hay que manejar cuando algo ocurra enviando la peticion al legacy
            ExternalTickerNotifier.NotifyDisconnectionAdmin(strIdUser);
            //ExternalTickerNotifier.NotifyDisconnectionBroadCastAdmin(strIdUser);

            if (IsConnectInLegay(strIdUser))
                DisconnectInLegacy(strIdUser, strPass);

        }


        /// <summary>
        /// Permite la desconexion de la plataforma anterior 
        /// </summary>
        /// <param name="strIdUser">Usuario a logaer </param>
        /// <param name="strPass">pass de lusuario</param>
        /// <returns>booleano identificando la desconexion</returns>
        public bool DisconnectInLegacy(string strIdUser, string strPass)
        {
            try
            {
                //return (new WSDisconnect.PlataformaWeb().Desconexion(strIdUser, strPass).Equals("OK")) ? true : false;
                return false;
            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", err.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Parta registrar en el log 
                //Infrastructure.Models.Error ErrReturn = new Infrastructure.Models.Error();
                //ErrReturn.Description = err.Message;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strToken"></param>
        /// <param name="strAccount"></param>
        /// <param name="strApp"></param>
        /// <returns></returns>
        public bool ValidateToken(string strUserToken, string strToken, string strAccount = null, string strApp = null)
        {
            //return OTP.FactoryAutenticationOTP.Get(System.Configuration.ConfigurationManager.AppSettings["TwoAutenticationFactor"].ToString()).ValidateToken(strUserToken, strToken, "", "3");
            return OTP.FactoryAutenticationOTP.Get(System.Configuration.ConfigurationManager.AppSettings["TwoAutenticationFactor"].ToString()).ValidateToken(strUserToken, strToken, strUserToken, "3");
        }
        
       
         
       
        private string MessageAutentication(string estado)
        {
            /*switch (estado)
            {
                case EstadoAutenticacion.Error:
                    return "Ocurrió  un error autenticando el usuario";
                case EstadoAutenticacion.UsuarioBloqueado:
                    return "El usuario se encuentra bloqueado";
                case EstadoAutenticacion.UsuarioClaveNoValidos:
                    return "Usuario o clave no validos";
                default:
                    return "Ocurrió un error autenticando el usuario";
            }*/
            return "";
        }


               

        public bool IsAuthenticated(string strIdUser)
        {
            bool res = strIdUser != null ? (_loggedUsers.ContainsKey(strIdUser)) : false;
            System.Diagnostics.Trace.WriteLine(string.Format("CorredoresDavivienda ApiWebServices Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", res+" Usr: "+ strIdUser, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

            return strIdUser != null ? (_loggedUsers.ContainsKey(strIdUser)) : false;

           // return true;


        }

        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "SecurityKeycompanyname";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return System.Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        

        public DataTable AuthenticatedUsers(string user)
        {
            var StrConnectedUsers = string.Empty;
            List<string> tmpList = new List<string>();

            foreach (var item in _loggedUsers)
            {
                tmpList.Add(item.Key);
            }

            string[] array = tmpList.ToArray<string>();
            string strConnectedUsers = string.Join(",", array);

            DataTable dtConnectedUsers = null;// Business.Usuario.GetBasicInfoConnectedUser(strConnectedUsers, user);

            return dtConnectedUsers;
        }

        public string NumAuthenticatedUsers(string user)
        {
            var StrConnectedUsers = string.Empty;
            return _loggedUsers.Count.ToString();
        }

        string IAutentication.GetUserbyToken(string token)
        {
            return "";// Business.Usuario.ConsultarToken(token);
        }

    }
}