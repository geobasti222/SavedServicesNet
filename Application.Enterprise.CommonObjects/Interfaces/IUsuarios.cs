using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Usuarios
    /// </summary>
    public interface IUsuarios
    {
        #region "Metodos de Usuarios"

        /// <summary>
        /// lista todos los Usuarios existentes.
        /// </summary>
        /// <returns></returns>
        List<UsuariosInfo> List();

        /// <summary>
        /// Lista un usuario especifico.
        /// </summary>
        /// <param name="Usuario">Usuario (NIT)</param>
        /// <returns></returns>
        UsuariosInfo ListxUsuario(string Usuario);

        /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        UsuariosInfo ListxUsuarioSVDN(string Clave);

        /// <summary>
        /// Alamacena la información de un usuario.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        bool Insert(UsuariosInfo item);

        /// <summary>
        /// Crea un usuario para una gerente zonal.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        bool InsertUsuarioGerenteZonal(UsuariosInfo item);

        /// <summary>
        /// GAVL INGRESO DE USUSARIOS ASISTENTES Y NO PUEDEN REINICIAR CLAVE QUEDARA CON EL NUMERO DE CEDULA
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool InsertSinReinciar(UsuariosInfo item, string Usuario);

        /// <summary>
        /// Verifica el password de un usuario.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        bool UpdateUserPassword(UsuariosInfo m, string oldPassword);

        /// <summary>
        /// -Realiza la inactivacion de clave de un usuario del sistema en G&G y SVDN
        /// </summary>
        /// <param name="item"></param>
        bool UpdateInactivarUsuario(UsuariosInfo m, string oldPassword);

        /// <summary>
        /// Realiza el cambio de clave de un usuario del sistema en G&G y SVDN en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool UpdatePasswordGYG(UsuariosInfo item);

        /// <summary>
        /// Realiza el cambio de clave de un usuario del sistema de una empresarias .
        /// </summary>
        /// <param name="item"></param>
        bool UpdatePasswordEmpresaria(UsuariosInfo m, string oldPassword);

        /// <summary>
        /// Realiza el reinicio de clave de una empresaria Web  en el sistema x usaurio.
        /// </summary>
        /// <param name="item"></param>
        bool UpdatePasswordReiniciarEmpresariaxUsuario(UsuariosInfo m);

        /// <summary>
        /// Lista un usuario especifico del sistema de G&G y SVDN
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        UsuariosInfo ListxUsuarioGYG(string Clave);

        /// <summary>
        /// Devuelve un usuario de gerente de zona consultado por cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        UsuariosInfo ListxUsuarioxCedula(string Cedula);

        /// <summary>
        /// Devuelve un usuario de una empresaria web consultado por cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        UsuariosInfo ListxUsuarioEmpresariaxCedula(string Cedula);

        /// <summary>
        /// Lista un usuario especifico del sistema de administracion. JUTA USU Y PASS
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
       /// <summary>
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        UsuariosInfo listUserFaceGoogle(string email);
        
        


        #endregion
    }
}

