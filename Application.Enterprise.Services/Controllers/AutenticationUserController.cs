using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Enterprise.Services.Controllers
{

    public class AutenticationUserController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        static readonly IConfigurationParameters DbParameters = new Models.ConfigurationParameters();
        //private static ITokenServices _TokenServices = new TokenServices();

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage LogInUserbyToken(AutenticationRequest objUser)
        {
            objUser.strIdUser = AutenticationUserController.Instance.GetUserbyToken(objUser.strIdUser);

            return LogInUser(objUser);

        }


        [HttpPost]
        public HttpResponseMessage Test(AutenticationRequest jsondata)
        {
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("www.google.com");
            return response;
        }


        [HttpGet]
        [HttpPost]
        public HttpResponseMessage LogInUserFromDaviHomeBroker(AutenticationRequest objUser)
        {
            try
            {
                Originator objOriginator = null;
                var token = ""; //_TokenServices.SelectToken(objUser.Token);
                var val = ""; //_TokenServices.ValidateToken(token, true, true);
                var ordenantDoc = "";
                var ordenantDocType = "";
                if (!Equals(token, null))
                {
                    /*var addInfoArr = token.AddInfo.Split(',');

                    clientDocType = addInfoArr[0];
                    ordenantDoc = addInfoArr[1];
                    ordenantDocType = addInfoArr[2];*/
                }

                if (!string.IsNullOrEmpty(val))
                {
                    objOriginator = new Originator()
                    {
                        /*Error = new Error()
                        {
                            Code = 10,
                            Description = val,
                            existError = true
                        }*/
                    };
                    var responseError = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
                    responseError.Headers.Add("Token", objUser.Token);
                    responseError.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
                    responseError.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                    return responseError;
                }


                var ipAddress = GetIpClient();
                var credentials = GetUser()?.Split(':');
                if (credentials != null && credentials.Length >= 2)
                {
                    objUser.strIdUser = credentials[0];
                    objUser.strPassword = credentials[1];
                }
                //objOriginator = Instance.AutenticationUser(token.UserId, "", ipAddress, false, true, objUser.Disclaimer, "",  false);

                /* objOriginator.Id = token.UserId;
                 objOriginator.Name = ordenantDoc;
                 if (objOriginator.Account.Count() > 0)
                     objOriginator.Account.First().Id = token.UserId;

                 //var ordenant = Business.Usuario.ObtenerOrdenantePorCedulaCOEASY(token.UserId, clientDocType, ordenantDoc);

                 //if (ordenant != null)
                 //   objOriginator.NameOrd = ordenant.Nombre;

                 objOriginator.DocumentType = new DocumentType() { Id = clientDocType };*/

                /*
                    Guarda el valor del numero de documento del ORDENANTE que se usa para colocar ordenes cuando se registra como multiordenante
                    si el que se registra no es multiordenante se envian los mismos datos tanto para el cliente como para el ordenante.
                */
                objOriginator.TraderDocument = ordenantDoc;
                objOriginator.TraderDocumentType = ordenantDocType;

                objOriginator.TraderDocumentType = ordenantDocType;

                //------------------------------------------------------------------------------------------------------------------------
                //Guarda el usuario que se conecta en la tabla usuarios.
                // AutenticationUserController.Instance.AdicionarUsuarioOnline(objOriginator.Id, ordenant.Nombre, objUser.Token);
                //------------------------------------------------------------------------------------------------------------------------

                var response = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
                response.Headers.Add("Token", objUser.Token);
                response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
                response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                return response;
            }
            catch (Exception)
            {
                var objOriginator = new Originator
                {
                    /*Error = new Error()
                    {
                        Description = x.Message
                    }*/
                };
                var response = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
                response.Headers.Add("Token", objUser.Token);
                response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
                response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                return response;
            }
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage AdicionarUsuarioOnline(AutenticationRequest objUser)
        {
            Originator objOriginator = new Originator();
            /*var ordenant = Business.Usuario.ObtenerOrdenantePorCedulaCOEASY(objUser.strIdUser , objUser.DocumentType, objUser.strIdUser);

          if (ordenant != null)
              objOriginator.NameOrd = ordenant.Nombre;

          //------------------------------------------------------------------------------------------------------------------------
          //Guarda el usuario que se conecta en la tabla usuarios.
           AutenticationUserController.Instance.AdicionarUsuarioOnline(objUser.strIdUser, ordenant.Nombre, objUser.Token);
          //------------------------------------------------------------------------------------------------------------------------
          */
            var response = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
            return response;
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage LogInUser(AutenticationRequest objUser)
        {
            string IpAddress = GetIpClient();
            var credentials = GetUser().Split(':');
            if (credentials.Length >= 2)
            {
                objUser.strIdUser = credentials[0];
                objUser.strPassword = credentials[1];
            }

            Originator objOriginator = new Originator();// AutenticationUserController.Instance.AutenticationUser(objUser.strIdUser, objUser.strPassword,IpAddress, objUser.ValidateIPAddress, objUser.forceLogin , objUser.Disclaimer, objUser.Token);
            var response = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
            response.Headers.Add("Token", "");
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");

            return response;

            // return Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
            //return objOriginator;
        }

        [HttpGet]
        [HttpPost]
        public Originator ValidateToken(AutenticationRequest objUser)
        {
            Originator initialUser = new Originator();
            //initialUser.Error = new Infrastructure.Models.Error();
            bool ResponseOTP = OTP.FactoryAutenticationOTP.Get(System.Configuration.ConfigurationManager.AppSettings["TwoAutenticationFactor"].ToString()).ValidateToken(objUser.strIdUser, objUser.Token, objUser.strIdUser, "3");

            if (!ResponseOTP)
            {
                /*initialUser.Error.Code = 10;
                initialUser.Error.existError = true;
                initialUser.Error.Description = "Token Invalido";*/
                return initialUser;
            }
            return initialUser;
        }


        [HttpGet]
        [HttpPost]
        public bool UpdateDisclaimerDate(AutenticationRequest obj)
        {
            //return AutenticationUserController.Instance.UpdateDisclaimerDate(obj.strIdUser); ;
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool UpdateShowTutorialDate(AutenticationRequest obj)
        {
            //return AutenticationUserController.Instance.UpdateShowTutorialDate(obj.strIdUser);
            return false; ;
        }





        [HttpGet]
        [HttpPost]
        public bool LogOutUserExternal(string user, string password)
        {
            //return !(AutenticationUserController.Instance.LogOutUser(user, password, true,"",false).existError);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool LogOutUserExternalAdmin(string user)
        {
            //return !(AutenticationUserController.Instance.LogOutUserAdmin(user, true).existError);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool IsAuthenticated(string user)
        {
            //return AutenticationUserController.Instance.IsAuthenticated(user);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool IsAuthenticated(AutenticationRequest obj)
        {
            //return AutenticationUserController.Instance.IsAuthenticated(obj.strIdUser);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public DataTable AuthenticatedUsers(string user)
        {
            //return AutenticationUserController.Instance.AuthenticatedUsers(user);
            return null;
        }

        [HttpGet]
        [HttpPost]
        public string NumAuthenticatedUsers(string user)
        {
            //return AutenticationUserController.Instance.NumAuthenticatedUsers(user);
            return "";
        }

        [HttpGet]
        [HttpPost]
        public string Encrypt(AutenticationRequest obj)
        {
            //return AutenticationUserController.Instance.Encrypt(obj.strIdUser, obj.UseHashing);
            return "";
        }

        [HttpGet]
        [HttpPost]
        public bool RegisterUserIpAddress(AutenticationRequest obj)
        {
            string IpAddress = GetIpClient();
            //return AutenticationUserController.Instance.RegisterUserIpAddress(obj.strIdUser, IpAddress);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool RegisterUserIpAddress(string strUserId)
        {
            string IpAddress = GetIpClient();
            //return AutenticationUserController.Instance.RegisterUserIpAddress(strUserId, IpAddress);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool IsValidIpAddress(string strUserId)
        {
            string IpAddress = GetIpClient();
            //return AutenticationUserController.Instance.IsValidIpAddress(strUserId, IpAddress);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public bool IsValidLocalIpAddress(string strUserId)
        {
            string IpAddress = GetIpClient();
            //return AutenticationUserController.Instance.IsValisLocalIpAddress(strUserId, IpAddress);
            return false;
        }

        [HttpGet]
        [HttpPost]
        public DataTable GetRegisteredIPAddressByUserExternal(string strIdUser)
        {
            //return AutenticationUserController.Instance.GetRegisteredIPAddressByUserExternal(strIdUser);
            return null;
        }



        [HttpGet]
        [HttpPost]
        public bool DeleteRegisteredIPAddressByUserExternal(string strIdUser, string ipAddress)
        {
            //return AutenticationUserController.Instance.DeleteRegisteredIPAddressByUser(strIdUser, ipAddress);
            return false;
        }


        //[HttpGet]
        //[HttpPost]
        //public HttpResponseMessage LogInUserbyDataServer(AutenticationRequest objUser)
        //{
        //    objUser.DataServer = AutenticationUserController.Instance.GetUserbyDataServer(objUser.strIdUser);

        //    //Aqui deberia ir a cambiar la variable issuscription en toda la appa.
        //    return LogInUser(objUser);

        //}


        //Prueba bolsa millonaria
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage LogInUserFromPlay(AutenticationRequest objUser)
        {
            string IpAddress = GetIpClient();



            // objUser.strIdUser = _TokenServices.GetToken(objUser.Token);


            Originator objOriginator = new Originator();// AutenticationUserController.Instance.AutenticationUser(objUser.strIdUser, "", IpAddress, false, true, objUser.Disclaimer,"",false);
            var response = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);
            response.Headers.Add("Token", "");
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");


            return response;

        }

        /*[HttpGet]
        [HttpPost]
        public HttpResponseMessage LoginUserPasword(Usuario objUser)
        {
            string IpAddress = GetIpClient();

            // objUser.strIdUser = _TokenServices.GetToken(objUser.Token);
            Application.Enterprise.Business.Usuarios ObjUsuario = new Application.Enterprise.Business.Usuarios("conexion");

            bool validate = ObjUsuario.ValidateUserSVDN(objUser.UserName.Trim(), objUser.Passwordd.Trim());

            Originator objOriginator = new Originator();// AutenticationUserController.Instance.AutenticationUser(objUser.strIdUser, "", IpAddress, false, true, objUser.Disclaimer,"",false);
            var response = Request.CreateResponse<Originator>(HttpStatusCode.OK, objOriginator);

            if (objUser.UserName == "mao@mail.com" && objUser.UserName == "MTIz")
            {
                response.Headers.Add("Token", "OK Login");
            }
            else
            {
                response.Headers.Add("Token", "Failed!");
            }
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");


            return response;

        }*/


        [HttpGet]
        [HttpPost]
        public HttpResponseMessage LoginUserPasword(Usuario objUser)
        {
            string IpAddress = GetIpClient();

            Application.Enterprise.CommonObjects.UsuariosInfo ObjUsuarioInfo = new Application.Enterprise.CommonObjects.UsuariosInfo();
            Application.Enterprise.Business.Usuarios ObjUsuario = new Application.Enterprise.Business.Usuarios("conexion");

            bool validate = ObjUsuario.ValidateUserSVDN_SAVED(objUser.UserName.Trim(), objUser.Passwordd.Trim());

            SessionUserInfo ObjSessionUserInfo = new SessionUserInfo();

            if (validate)
            {
                ObjUsuarioInfo = ObjUsuario.ListxUsuarioSVDN(objUser.Passwordd.Trim());
                //ObjUsuarioInfo = ObjUsuario.ListxUsuario(txtPwd.Value.Trim());

                if (ObjUsuarioInfo != null)
                {
                    ObjSessionUserInfo.ReiniciarClave = ObjUsuarioInfo.Reiniciar.ToString();

                    #region "GERENTES DE ZONA"

                    if ((ObjUsuarioInfo.IdGrupo == Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.GerentesZona)))
                    {
                        Application.Enterprise.CommonObjects.UsuarioVendedorInfo ObjUsuarioVendedorInfo = new Application.Enterprise.CommonObjects.UsuarioVendedorInfo();
                        Application.Enterprise.Business.UsuarioVendedor ObjUsuarioVendedor = new Application.Enterprise.Business.UsuarioVendedor("conexion");

                        ObjUsuarioVendedorInfo = ObjUsuarioVendedor.ListxClave(Application.Enterprise.CommonObjects.Tools.Encrypt(objUser.Passwordd.Trim(), true));

                        if (ObjUsuarioVendedorInfo != null)
                        {
                            Application.Enterprise.CommonObjects.VendedorInfo ObjVendedorInfo = new Application.Enterprise.CommonObjects.VendedorInfo();
                            Application.Enterprise.Business.Vendedor ObjVendedor = new Application.Enterprise.Business.Vendedor("conexion");

                            ObjVendedorInfo = ObjVendedor.ListxCodVendedor(ObjUsuarioVendedorInfo.IdVendedor);

                            if (ObjVendedorInfo != null)
                            {
                                ObjSessionUserInfo.Cedula = ObjVendedorInfo.Cedula.ToString().Trim();
                                //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                ObjSessionUserInfo.Usuario = ObjUsuarioInfo.Clave.ToString().Trim();
                                ObjSessionUserInfo.IdVendedor = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                ObjSessionUserInfo.IdZona = ObjVendedorInfo.Zona.ToString().Trim();
                                ObjSessionUserInfo.IdZonaMatriz = ObjVendedorInfo.Zona.ToString();
                                ObjSessionUserInfo.NombreUsuario = ObjVendedorInfo.Nombre.ToString().Trim();
                                ObjSessionUserInfo.IdGrupo = Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.GerentesZona);
                                ObjSessionUserInfo.Grupo = ObjUsuarioInfo.NombreGrupo;
                                ObjSessionUserInfo.Email = ObjVendedorInfo.EmailNivi.ToString().Trim();
                                ObjSessionUserInfo.MostrarTermyCond = ObjVendedorInfo.MostrarTerminosyCondiciones.ToString();

                                ObjSessionUserInfo.ClaveUsuario = objUser.Passwordd.Trim();

                                //--------------------------------------------------------------------------------------
                                //Consulta la region
                                Application.Enterprise.Business.RegionxZona moduleRegionxZona = new Application.Enterprise.Business.RegionxZona("conexion");
                                RegionxZonaInfo objRegionxZonaInfo = new RegionxZonaInfo();

                                objRegionxZonaInfo = moduleRegionxZona.ListRegionalxZona(ObjSessionUserInfo.IdZona.ToString());

                                if (objRegionxZonaInfo != null)
                                {
                                    ObjSessionUserInfo.IdRegional = objRegionxZonaInfo.CodigoRegion.ToString();//Se guarda el Id de la region.
                                }

                                //--------------------------------------------------------------------------------------
                                //Se consulta si la zona es de reserva en linea o no.
                                Application.Enterprise.CommonObjects.ZonasReservaEnLineaInfo ObjZonasReservaEnLineaInfo = new Application.Enterprise.CommonObjects.ZonasReservaEnLineaInfo();
                                Application.Enterprise.Business.ZonasReservaEnLinea ObjZonasReservaEnLinea = new Application.Enterprise.Business.ZonasReservaEnLinea("conexion");

                                ObjZonasReservaEnLineaInfo = ObjZonasReservaEnLinea.ListxZona(ObjSessionUserInfo.IdZona);

                                if (ObjZonasReservaEnLineaInfo != null)
                                {
                                    ObjSessionUserInfo.ZonaReservaEnLinea = "true";
                                }
                                //--------------------------------------------------------------------------------------
                            }
                            else
                            {
                                ObjSessionUserInfo.Error = new Error();
                                ObjSessionUserInfo.Error.Id = 1;
                                ObjSessionUserInfo.Error.Descripcion = "No se pudo iniciar sesion.";
                            }
                        }
                        else
                        {
                            /*string radalertscript = "<script language='javascript'>function f(){callAlert('Credenciales Invalidas. <br />No se pudo iniciar sesión en el sistema.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

                            IngresarOK = false; */
                        }
                    }
                    #endregion
                    #region "GERENTES REGIONALES"
                    /*else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.GerentesRegionales))
                    {
                        NIVI.Application.Enterprise.CommonObjects.UsuarioVendedorInfo ObjUsuarioVendedorInfo = new NIVI.Application.Enterprise.CommonObjects.UsuarioVendedorInfo();
                        Application.Enterprise.Business.UsuarioVendedor ObjUsuarioVendedor = new Application.Enterprise.Business.UsuarioVendedor("conexion");

                        ObjUsuarioVendedorInfo = ObjUsuarioVendedor.ListxClave(NIVI.SVDN.Common.Objects.Tools.Encrypt(txtPwd.Value.Trim(), true));

                        if (ObjUsuarioVendedorInfo != null)
                        {
                            NIVI.Application.Enterprise.CommonObjects.VendedorInfo ObjVendedorInfo = new NIVI.Application.Enterprise.CommonObjects.VendedorInfo();
                            Application.Enterprise.Business.Vendedor ObjVendedor = new Application.Enterprise.Business.Vendedor("conexion");

                            ObjVendedorInfo = ObjVendedor.ListxCedula(txtUserName.Value.Trim());

                            if (ObjVendedorInfo != null)
                            {
                                Session["Cedula"] = ObjVendedorInfo.Cedula.ToString().Trim();
                                //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                                Session["IdVendedor"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                Session["IdZona"] = ObjVendedorInfo.Zona.ToString().Trim();
                                Session["NombreUsuario"] = ObjVendedorInfo.Nombre.ToString().Trim();
                                Session["IdGrupo"] = Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.GerentesRegionales);
                                Session["Grupo"] = ObjUsuarioInfo.NombreGrupo;
                                Session["Email"] = ObjVendedorInfo.EmailNivi.ToString().Trim();
                                Session["CedulaRegional"] = ObjVendedorInfo.Cedula.ToString().Trim();
                                Session["CedulaRegionalMatriz"] = ObjVendedorInfo.Cedula.ToString();
                                Session["MostrarTermyCond"] = ObjVendedorInfo.MostrarTerminosyCondiciones.ToString();
                                Session["ClaveUsuario"] = txtPwd.Value.Trim();
                            }
                            else
                            {
                                // lbl_msg.Text = "Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.";

                                //string radalertscript = "<script language='javascript'>function f(){callAlertGenerico('Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

                                RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.');");

                                IngresarOK = false;
                            }
                        }
                        else
                        {
                            string radalertscript = "<script language='javascript'>function f(){callAlert('Credenciales Invalidas. <br />No se pudo iniciar sesión en el sistema.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

                            IngresarOK = false;
                        }
                    }
                    */
                    #endregion
                    #region "ADMINISTRADOR"
                    /*else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.Administrador))
                    {
                        NIVI.Application.Enterprise.CommonObjects.UsuarioVendedorInfo ObjUsuarioVendedorInfo = new NIVI.Application.Enterprise.CommonObjects.UsuarioVendedorInfo();
                        Application.Enterprise.Business.UsuarioVendedor ObjUsuarioVendedor = new Application.Enterprise.Business.UsuarioVendedor("conexion");

                        ObjUsuarioVendedorInfo = ObjUsuarioVendedor.ListxClave(NIVI.SVDN.Common.Objects.Tools.Encrypt(txtPwd.Value.Trim(), true));

                        if (ObjUsuarioVendedorInfo != null)
                        {
                            NIVI.Application.Enterprise.CommonObjects.VendedorInfo ObjVendedorInfo = new NIVI.Application.Enterprise.CommonObjects.VendedorInfo();
                            Application.Enterprise.Business.Vendedor ObjVendedor = new Application.Enterprise.Business.Vendedor("conexion");

                            ObjVendedorInfo = ObjVendedor.ListxCodVendedor(ObjUsuarioVendedorInfo.IdVendedor);

                            if (ObjVendedorInfo != null)
                            {
                                Session["Cedula"] = ObjVendedorInfo.Cedula.ToString().Trim();
                                //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                                Session["IdVendedor"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                Session["IdZona"] = ObjVendedorInfo.Zona.ToString().Trim();
                                Session["NombreUsuario"] = ObjVendedorInfo.Nombre.ToString().Trim();
                                Session["IdGrupo"] = Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.Administrador);
                                Session["Grupo"] = ObjUsuarioInfo.NombreGrupo;
                                Session["Email"] = ObjVendedorInfo.EmailNivi.ToString().Trim();
                                Session["ClaveUsuario"] = txtPwd.Value.Trim();

                                Session["MostrarTermyCond"] = "false";
                            }
                        }
                        else
                        {
                            string radalertscript = "<script language='javascript'>function f(){callAlert('Credenciales Invalidas. <br />No se pudo iniciar sesión en el sistema.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

                            IngresarOK = false;
                        }
                    }
                    */
                    #endregion
                    #region "SERVICIO AL CLIENTE (SAC)"
                    else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.ServicioCliente))
                    {
                        /*
                        Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                        Session["NombreUsuario"] = ObjUsuario.DesencriptarCadena(ObjUsuarioInfo.Descripcion.ToString().Trim());
                        Session["IdGrupo"] = Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.ServicioCliente);
                        Session["Grupo"] = ObjUsuarioInfo.NombreGrupo;
                        Session["Email"] = ObjUsuarioInfo.Email.ToString().Trim();
                        Session["ClaveUsuario"] = txtPwd.Value.Trim();
                        */
                        ObjSessionUserInfo.Cedula = ObjUsuarioInfo.Usuario.ToString().Trim();
                        //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                        ObjSessionUserInfo.Usuario = ObjUsuarioInfo.Clave.ToString().Trim();
                        ObjSessionUserInfo.NombreUsuario = ObjUsuarioInfo.NombreUsuario.ToString().Trim();
                        ObjSessionUserInfo.IdGrupo = Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.ServicioCliente);
                        ObjSessionUserInfo.Grupo = ObjUsuarioInfo.NombreGrupo;
                        ObjSessionUserInfo.Email = ObjUsuarioInfo.Email.ToString().Trim();
                        ObjSessionUserInfo.ClaveUsuario = objUser.Passwordd.Trim();
                        ObjSessionUserInfo.MostrarTermyCond = "false";
                    }
                    
                    #endregion
                    #region "SERVICIO AL CLIENTE ESPECIAL (SAC)"
                    else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.ServicioClienteEspecial))
                    {
                        /*
                                                Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                                                Session["NombreUsuario"] = ObjUsuario.DesencriptarCadena(ObjUsuarioInfo.Descripcion.ToString().Trim());
                                                Session["IdGrupo"] = Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.ServicioClienteEspecial);
                                                Session["Grupo"] = ObjUsuarioInfo.NombreGrupo;
                                                Session["Email"] = ObjUsuarioInfo.Email.ToString().Trim();
                                                Session["ClaveUsuario"] = txtPwd.Value.Trim();
                                                Session["MostrarTermyCond"] = "false";
                                                */
                        ObjSessionUserInfo.Cedula = ObjUsuarioInfo.Usuario.ToString().Trim();
                        //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                        ObjSessionUserInfo.Usuario = ObjUsuarioInfo.Clave.ToString().Trim();
                        ObjSessionUserInfo.NombreUsuario = ObjUsuarioInfo.NombreUsuario.ToString().Trim();
                        ObjSessionUserInfo.IdGrupo = Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.ServicioClienteEspecial);
                        ObjSessionUserInfo.Grupo = ObjUsuarioInfo.NombreGrupo;
                        ObjSessionUserInfo.Email = ObjUsuarioInfo.Email.ToString().Trim();
                        ObjSessionUserInfo.ClaveUsuario = objUser.Passwordd.Trim();
                        ObjSessionUserInfo.MostrarTermyCond = "false";

                    }
                    #endregion
                    #region "SALA DE VENTAS (VPN)"
                    /*else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.SalaVentas))
                    {

                        Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                        Session["NombreUsuario"] = ObjUsuario.DesencriptarCadena(ObjUsuarioInfo.Descripcion.ToString().Trim());
                        Session["IdGrupo"] = Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.SalaVentas);
                        Session["Grupo"] = ObjUsuarioInfo.NombreGrupo;
                        Session["Email"] = ObjUsuarioInfo.Email.ToString().Trim();
                        Session["ClaveUsuario"] = txtPwd.Value.Trim();

                        Session["MostrarTermyCond"] = "false";
                    }
                    */
                    #endregion
                    #region "EMPRESARIAS"
                    else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.EmpresariasWeb))
                    {
                        //Application.Enterprise.CommonObjects.UsuarioVendedorInfo ObjUsuarioVendedorInfo = new Application.Enterprise.CommonObjects.UsuarioVendedorInfo();
                        //Application.Enterprise.Business.UsuarioVendedor ObjUsuarioVendedor = new Application.Enterprise.Business.UsuarioVendedor("conexion");

                        Application.Enterprise.CommonObjects.VendedorInfo ObjVendedorInfo = new Application.Enterprise.CommonObjects.VendedorInfo();
                        Application.Enterprise.Business.Vendedor ObjVendedor = new Application.Enterprise.Business.Vendedor("conexion");


                        //ObjUsuarioVendedorInfo = ObjUsuarioVendedor.ListxClave(Application.Enterprise.CommonObjects.Tools.Encrypt(objUser.Passwordd.Trim(), true));
                        ObjVendedorInfo = ObjVendedor.ListVendedorxNitCliente(objUser.UserName.Trim());

                        if (ObjVendedorInfo != null)
                        {

                            Application.Enterprise.CommonObjects.LiderInfo ObjLiderInfo = new Application.Enterprise.CommonObjects.LiderInfo();
                            Application.Enterprise.Business.Lider ObjLider = new Application.Enterprise.Business.Lider("conexion");

                            ObjLiderInfo = ObjLider.ListxIdLider(ObjVendedorInfo.IdVendedor);

                            if (ObjLiderInfo != null)
                            {

                                ObjSessionUserInfo.Cedula = objUser.UserName.Trim();// ObjVendedorInfo.Cedula.ToString().Trim();
                                //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                ObjSessionUserInfo.Usuario = ObjUsuarioInfo.Clave.ToString().Trim();
                                ObjSessionUserInfo.IdVendedor = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                ObjSessionUserInfo.IdLider = ObjLiderInfo.IdLider.ToString().Trim();
                                ObjSessionUserInfo.IdZona = ObjVendedorInfo.Zona.ToString().Trim();
                                ObjSessionUserInfo.IdZonaMatriz = ObjVendedorInfo.Zona.ToString();
                                ObjSessionUserInfo.NombreUsuario = ObjVendedorInfo.Nombre.ToString().Trim();
                                ObjSessionUserInfo.IdGrupo = Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.EmpresariasWeb);
                                ObjSessionUserInfo.Grupo = ObjUsuarioInfo.NombreGrupo;
                                ObjSessionUserInfo.Email = ObjVendedorInfo.EmailNivi.ToString().Trim();
                                ObjSessionUserInfo.MostrarTermyCond = ObjVendedorInfo.MostrarTerminosyCondiciones.ToString();

                                ObjSessionUserInfo.ClaveUsuario = objUser.Passwordd.Trim();

                            }

                        }
                    }

                    #endregion
                    #region "ASISTENTES "
                    /*else if (ObjUsuarioInfo.IdGrupo == Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.Asistentes))
                    {

                        Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                        Session["Asistente"] = ObjUsuarioInfo.Usuario.ToString().Trim();
                        Session["NombreUsuario"] = ObjUsuario.DesencriptarCadena(ObjUsuarioInfo.Descripcion.ToString().Trim());
                        Session["IdGrupo"] = Convert.ToString((int)NIVI.Application.Enterprise.CommonObjects.GruposUsuariosEnum.Asistentes);
                        Session["Grupo"] = ObjUsuarioInfo.NombreGrupo;
                        Session["Email"] = ObjUsuarioInfo.Email.ToString().Trim();
                        Session["Cedula"] = ObjUsuarioInfo.Usuario.ToString().Trim();
                        Session["IdVendedor"] = ObjUsuarioInfo.Usuario.ToString().Trim(); ;

                        Session["MostrarTermyCond"] = "false";
                    }
                    */
                    #endregion
                    #region "LIDERES"
                    else if ((ObjUsuarioInfo.IdGrupo == Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.Lider)))
                    {

                        //Session["Asistente"] = ""; //GAVL USUARIO PARA MODULO ASISTENTE
                        //Session["AsistentexZona"] = ""; //GAVL USUARIO PARA MODULO ASISTENTE

                        Application.Enterprise.CommonObjects.UsuarioVendedorInfo ObjUsuarioVendedorInfo = new Application.Enterprise.CommonObjects.UsuarioVendedorInfo();
                        Application.Enterprise.Business.UsuarioVendedor ObjUsuarioVendedor = new Application.Enterprise.Business.UsuarioVendedor("conexion");

                        ObjUsuarioVendedorInfo = ObjUsuarioVendedor.ListxClave(Application.Enterprise.CommonObjects.Tools.Encrypt(objUser.Passwordd.Trim(), true));

                        if (ObjUsuarioVendedorInfo != null)
                        {
                            Application.Enterprise.CommonObjects.LiderInfo ObjLiderInfo = new Application.Enterprise.CommonObjects.LiderInfo();
                            Application.Enterprise.Business.Lider ObjLider = new Application.Enterprise.Business.Lider("conexion");

                            ObjLiderInfo = ObjLider.ListxIdLider(ObjUsuarioVendedorInfo.IdVendedor);

                            if (ObjLiderInfo != null)
                            {
                                ObjSessionUserInfo.Cedula = ObjLiderInfo.Cedula.ToString().Trim();
                                //Session["Usuario"] = ObjVendedorInfo.IdVendedor.ToString().Trim();
                                ObjSessionUserInfo.Usuario = ObjUsuarioInfo.Clave.ToString().Trim();
                                ObjSessionUserInfo.IdVendedor = ObjLiderInfo.IdVendedor.ToString().Trim();
                                ObjSessionUserInfo.IdLider = ObjLiderInfo.IdLider.ToString().Trim();
                                ObjSessionUserInfo.IdZona = ObjLiderInfo.Zona.ToString().Trim();
                                ObjSessionUserInfo.IdZonaMatriz = ObjLiderInfo.Zona.ToString();
                                ObjSessionUserInfo.NombreUsuario = ObjLiderInfo.Nombres.ToString().Trim().ToUpper();
                                ObjSessionUserInfo.IdGrupo = Convert.ToString((int)Application.Enterprise.CommonObjects.Enumerations.GruposUsuariosEnum.Lider);
                                ObjSessionUserInfo.Grupo = ObjUsuarioInfo.NombreGrupo;
                                ObjSessionUserInfo.Email = ObjLiderInfo.Nombres.ToString().Trim();
                                ObjSessionUserInfo.MostrarTermyCond = "0"; //no mostrar terminos y condiciones.
                                ObjSessionUserInfo.ClaveUsuario = objUser.Passwordd.Trim();




                                //--------------------------------------------------------------------------------------
                                //Se consulta si la zona es de reserva en linea o no.
                                /*NIVI.Application.Enterprise.CommonObjects.ZonasReservaEnLineaInfo ObjZonasReservaEnLineaInfo = new NIVI.Application.Enterprise.CommonObjects.ZonasReservaEnLineaInfo();
                                Application.Enterprise.Business.ZonasReservaEnLinea ObjZonasReservaEnLinea = new Application.Enterprise.Business.ZonasReservaEnLinea("conexion");

                                ObjZonasReservaEnLineaInfo = ObjZonasReservaEnLinea.ListxZona(Session["IdZona"].ToString());

                                if (ObjZonasReservaEnLineaInfo != null)
                                {
                                    Session["ZonaReservaEnLinea"] = "true";
                                }*/
                                //--------------------------------------------------------------------------------------

                            }
                            else
                            {
                                // lbl_msg.Text = "Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.";

                                //string radalertscript = "<script language='javascript'>function f(){callAlertGenerico('Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);



                                //RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.');");

                                ObjSessionUserInfo.Error = new Error();
                                ObjSessionUserInfo.Error.Id = 1;
                                ObjSessionUserInfo.Error.Descripcion = "Las credenciales no corresponden a una zona de Niviglobal. <br />Por favor comuniquese con el area de comercial para verificar sus datos.";
                            }
                        }
                        else
                        {
                            ObjSessionUserInfo.Error = new Error();
                            ObjSessionUserInfo.Error.Id = 1;
                            ObjSessionUserInfo.Error.Descripcion = "No se pudo iniciar sesion.";
                        }
                    }

                    #endregion
                    /*else
                    {
                        //Session["Usuario"] = ObjUsuarioInfo.Descripcion.ToString().Trim();
                        Session["Usuario"] = ObjUsuarioInfo.Clave.ToString().Trim();
                        Session["NombreUsuario"] = ObjUsuario.DesencriptarCadena(ObjUsuarioInfo.Descripcion.ToString());
                        Session["IdGrupo"] = ObjUsuarioInfo.IdGrupo.ToString();
                        Session["Grupo"] = ObjUsuarioInfo.NombreGrupo.ToString();
                        Session["Email"] = ObjUsuarioInfo.Email.ToString();
                        Session["ClaveUsuario"] = txtPwd.Value.Trim();

                        Session["MostrarTermyCond"] = "false";

                        if (Session["Usuario"].ToString() == "MFCNWtnmVYRzAJ7q5+TLoA==")
                        {
                            Response.Redirect("DefaultAdministrador.aspx");
                        }
                    }
                    */

                    //Consultar si tiene permiso para pedidos de outlet.
                    //ObjParametrosInfo = ObjParametros.ListxId((int)NIVI.Application.Enterprise.CommonObjects.ParametrosEnum.CatalogoOutlet);
                    //Session["PedidosOutlet"] = ObjParametrosInfo.Valor.ToString().Trim().ToLower();

                    /*if (IngresarOK)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    */
                }
            }
            else
            {
                ObjSessionUserInfo.Error = new Error();
                ObjSessionUserInfo.Error.Id = 1;
                ObjSessionUserInfo.Error.Descripcion = "No se pudo iniciar sesion.";

            }

            //TODO MRG: Cambiar esto para que sea lo q viene de BD.

            //--------------------------------------------------------------------------------------------------------
            CampanaInfo objCampanaInfo = new CampanaInfo();
            Campana objCampana = new Campana("conexion");

            objCampanaInfo = objCampana.ListxGetDate();

            if (objCampanaInfo != null)
            {
                ObjSessionUserInfo.Campana = objCampanaInfo.Campana;
                ObjSessionUserInfo.Catalogo = objCampanaInfo.Catalogo;
            }
            else
            {
                ObjSessionUserInfo.Campana = "";
                ObjSessionUserInfo.Catalogo = "";
            }

            //--------------------------------------------------------------------------------------------------------
                       
            var response = Request.CreateResponse<SessionUserInfo>(HttpStatusCode.OK, ObjSessionUserInfo);
            response.Headers.Add("Token", "");
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");


            return response;

        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Prueba()
        {
            SessionUserInfo ObjSessionUserInfo = new SessionUserInfo();

            ObjSessionUserInfo.Campana = "Campana 2019";
            ObjSessionUserInfo.Cedula = "1234567890";
            ObjSessionUserInfo.Usuario = "Usuario";
            ObjSessionUserInfo.IdVendedor = DateTime.Now.ToString();

            var response = Request.CreateResponse<SessionUserInfo>(HttpStatusCode.OK, ObjSessionUserInfo);
            response.Headers.Add("Token", "");
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");


            return response;

        }
    }
}
