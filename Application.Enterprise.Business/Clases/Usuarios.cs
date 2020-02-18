using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para usuarios
    /// </summary>
    public class Usuarios : IUsuarios
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Usuarios module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Usuarios()
        {
            module = new Application.Enterprise.Data.Usuarios();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Usuarios(string databaseName)
        {
            module = new Application.Enterprise.Data.Usuarios(databaseName);
        }

        #region Miembros de IUsuarios


        /// <summary>
        /// lista todos los Usuarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<UsuariosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un usuario especifico.
        /// </summary>
        /// <param name="Usuario">Usuario (NIT)</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuario(string Usuario)
        {
            return module.ListxUsuario(Usuario);
        }


        /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioSVDN(string Clave)
        {
            string clearText = Clave.Trim();
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);
            //*string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            return module.ListxUsuarioSVDN(cipherText);
        }

        /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioSVDN(string Clave, string Usuario)
        {
            string clearText = Clave.Trim();
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);
            //*string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            return module.ListxUsuarioSVDN(cipherText, Usuario);
        }

        /// <summary>
        /// Lista un usuario especifico del sistema de administracion. JUTA USU Y CLAVE
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioSVDNJUTAUSUYPASS(string Clave, string usu)
        {
            string clearText = Clave.Trim();
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);
            //*string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            return module.ListxUsuarioSVDNJUTAUSUYPASS(cipherText, usu);
        }

        /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public string EncriptarCadena(string Cadena)
        {
            string CadenCipherText = Cadena.Trim();
            //*return Application.Enterprise.CommonObjects.Tools.DecryptCYPHER(CadenCipherText);
            return Application.Enterprise.CommonObjects.Tools.Encrypt(CadenCipherText, true);
        }



        /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public string DesencriptarCadena(string Cadena)
        {
            string CadenCipherText = Cadena.Trim();
            //*return Application.Enterprise.CommonObjects.Tools.DecryptCYPHER(CadenCipherText);
            return Application.Enterprise.CommonObjects.Tools.Decrypt(CadenCipherText, true);
        }

        /// <summary>
        /// Alamacena la información de un usuario.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        public bool Insert(UsuariosInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Crea un usuario para una gerente zonal.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        public bool InsertUsuarioGerenteZonal(UsuariosInfo item)
        {
            try
            {
                return module.InsertUsuarioGerenteZonal(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// GAVL INGRESO DE USUSARIOS ASISTENTES Y NO PUEDEN REINICIAR CLAVE QUEDARA CON EL NUMERO DE CEDULA
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertSinReinciar(UsuariosInfo item, string Usuario)
        {
            try
            {
                return module.InsertSinReinciar(item, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Verifica el password de un usuario.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public bool UpdateUserPasswordEmpresaria(UsuariosInfo m, string oldPassword)
        {
            bool oktransact = false;

            string clearText = oldPassword.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            bool okPassword = this.ValidatePassword(oldPassword);

            if (okPassword)
            {

                bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

                if (!okPasswordNuevo)
                {
                    m.Clave = cipherText;
                    m.ClaveNueva = cipherTextNueva;

                    //m.Clave = cipherText;
                    oktransact = module.UpdatePasswordEmpresaria(m);
                }
            }

            return oktransact;
        }

        /// <summary>
        /// Verifica el password de un usuario.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public bool UpdateUserPassword(UsuariosInfo m, string oldPassword)
        {
            bool oktransact = false;

            string clearText = oldPassword.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            bool okPassword = this.ValidatePassword(oldPassword);

            if (okPassword)
            {

                bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

                if (!okPasswordNuevo)
                {
                    m.Clave = cipherText;
                    m.ClaveNueva = cipherTextNueva;

                    //m.Clave = cipherText;
                    oktransact = module.UpdatePasswordGYG(m);
                }
            }

            return oktransact;
        }



        /// <summary>
        /// Realiza el reinicio de clave de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordReiniciar(UsuariosInfo m, string oldPassword)
        {
            bool oktransact = false;

            string clearText = oldPassword.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            bool okPassword = this.ValidatePassword(oldPassword);

            if (okPassword)
            {

                bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

                if (!okPasswordNuevo)
                {
                    m.Clave = cipherText;
                    m.ClaveNueva = cipherTextNueva;

                    //m.Clave = cipherText;
                    oktransact = module.UpdatePasswordReiniciar(m);
                }
            }

            return oktransact;
        }

        /// <summary>
        /// Realiza el reinicio de clave de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordReiniciarEmpresaria(UsuariosInfo m, string oldPassword)
        {
            bool oktransact = false;

            string clearText = oldPassword.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            bool okPassword = this.ValidatePassword(oldPassword);

            if (okPassword)
            {

                bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

                if (!okPasswordNuevo)
                {
                    m.Clave = cipherText;
                    m.ClaveNueva = cipherTextNueva;

                    //m.Clave = cipherText;
                    oktransact = module.UpdatePasswordReiniciarEmpresaria(m);
                }
            }

            return oktransact;
        }

        /// <summary>
        /// Realiza el reinicio de clave de una empresaria Web  en el sistema x usaurio.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordReiniciarEmpresariaxUsuario(UsuariosInfo m)
        {
            bool oktransact = false;

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

            if (!okPasswordNuevo)
            {
                m.ClaveNueva = cipherTextNueva;
                //m.Clave = cipherText;
                oktransact = module.UpdatePasswordReiniciarEmpresariaxUsuario(m);
            }

            return oktransact;
        }

        /// <summary>
        /// -Realiza la inactivacion de clave de un usuario del sistema en G&G y SVDN
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateInactivarUsuario(UsuariosInfo m, string oldPassword)
        {
            bool oktransact = false;

            string clearText = oldPassword.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            //bool okPassword = this.ValidatePassword(oldPassword);

            //if (okPassword)
            //{

            //    bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

            //    if (!okPasswordNuevo)
            //    {
            //        m.Clave = cipherText;
            //        m.ClaveNueva = cipherTextNueva;

            //        //m.Clave = cipherText;
            //        oktransact = module.UpdateInactivarUsuario(m);
            //    }
            //}

            try
            {
                m.Clave = cipherText;
                m.ClaveNueva = cipherTextNueva;
                oktransact = module.UpdateInactivarUsuario(m);
            }
            catch (Exception)
            {

                throw;
            }

            return oktransact;
        }

        /// <summary>
        /// Realiza el cambio de clave de un usuario del sistema en G&G y SVDN en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordGYG(UsuariosInfo item)
        {
            try
            {
                return module.UpdatePasswordGYG(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza el cambio de clave de un usuario del sistema de una empresarias .
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordEmpresaria(UsuariosInfo m, string oldPassword)
        {
            bool oktransact = false;

            string clearText = oldPassword.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            string clearTextNueva = m.ClaveNueva.Trim();
            //*string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearTextNueva);
            string cipherTextNueva = Application.Enterprise.CommonObjects.Tools.Encrypt(clearTextNueva, true);

            bool okPassword = this.ValidatePassword(oldPassword);

            if (okPassword)
            {

                bool okPasswordNuevo = this.ValidatePassword(clearTextNueva);

                if (!okPasswordNuevo)
                {
                    m.Clave = cipherText;
                    m.ClaveNueva = cipherTextNueva;

                    //m.Clave = cipherText;
                    oktransact = module.UpdatePasswordEmpresaria(m);
                }
            }

            return oktransact;
        }

        /// <summary>
        /// Valida la existencia y acceso al sistema de un usuario.
        /// </summary>
        /// <param name="Usuario">Usuario</param>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public bool ValidateUser(string Usuario, string Clave)
        {
            bool validate = false;

            UsuariosInfo ObjUsuario = new UsuariosInfo();

            if (Usuario != "" && Usuario != null && Clave != "" && Clave != null)
            {
                string clearText = Clave.Trim();
                string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

                ObjUsuario = this.ListxUsuario(Usuario);

                if (ObjUsuario != null)
                {
                    if (cipherText == ObjUsuario.Clave)
                    {
                        validate = true;
                    }
                }
            }
            return validate;
        }





        /// <summary>
        /// Valida la existencia y acceso al sistema de un usuario.
        /// </summary>
        /// <param name="Usuario">Usuario</param>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public bool ValidatePassword(string Clave)
        {
            bool validate = false;


            string clearText = Clave.Trim();
            //string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
            string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

            UsuariosInfo ObjUsuario = this.ListxUsuarioGYG(cipherText);

            if (ObjUsuario != null)
            {
                validate = true;
            }

            return validate;
        }

        /// <summary>
        /// Lista un usuario especifico del sistema de G&G y SVDN
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioGYG(string Clave)
        {
            return module.ListxUsuarioGYG(Clave);
        }

        /// <summary>
        /// Devuelve un usuario de gerente de zona consultado por cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioxCedula(string Cedula)
        {
            return module.ListxUsuarioxCedula(Cedula);
        }

        /// <summary>
        /// Devuelve un usuario de una empresaria web consultado por cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioEmpresariaxCedula(string Cedula)
        {
            return module.ListxUsuarioEmpresariaxCedula(Cedula);
        }


        /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo listUserFaceGoogle(string email)
        {
            return module.ListxUsuarioEmailFaceGoogle(email);
        }

        /// <summary>
        /// Valida la existencia y acceso al sistema de un usuario.
        /// </summary>
        /// <param name="Usuario">Usuario</param>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public bool ValidateUserSVDN(string Usuario, string Clave)
        {
            bool validate = false;

            UsuariosInfo ObjUsuario = new UsuariosInfo();

            if (Usuario != "" && Usuario != null && Clave != "" && Clave != null)
            {
                string clearText = Clave.Trim();
                //*Habilitar para Cypher string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
                string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);

                //*ObjUsuario = this.ListxUsuarioSVDN(Clave);
                //ObjUsuario = this.ListxUsuarioSVDN(Clave);

                //ObjUsuario = this.ListxUsuarioSVDNJUTAUSUYPASS(Clave, Usuario);//COLOMBIA
                ObjUsuario = this.ListxUsuarioSVDN(Clave);//PERU Y ECUADOR

                if (ObjUsuario != null)
                {
                    if (cipherText == ObjUsuario.Clave.Trim())
                    {
                        validate = true;
                    }
                }
            }
            return validate;
        }

        /// <summary>
        /// Valida la existencia y acceso al sistema de un usuario.
        /// </summary>
        /// <param name="Usuario">Usuario</param>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public bool ValidateUserSVDN_SAVED(string Usuario, string Clave)
        {
            bool validate = false;

            UsuariosInfo ObjUsuario = new UsuariosInfo();

            if (Usuario != "" && Usuario != null && Clave != "" && Clave != null)
            {
                string clearText = Clave.Trim();
                //*Habilitar para Cypher string cipherText = Application.Enterprise.CommonObjects.Tools.EncryptCYPHER(clearText);
                string cipherText = Application.Enterprise.CommonObjects.Tools.Encrypt(clearText, true);
                              
                ObjUsuario = this.ListxUsuarioSVDN(Clave, Usuario);//PERU Y ECUADOR

                if (ObjUsuario != null)
                {
                    if (cipherText == ObjUsuario.Clave.Trim())
                    {
                        validate = true;
                    }
                }
            }
            return validate;
        }

        #endregion
    }
}