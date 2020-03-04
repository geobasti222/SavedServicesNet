using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class Notifica : INotifica
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Notifica module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Notifica()
        {
            module = new Application.Enterprise.Data.Notifica();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Notifica(string databaseName)
        {
            module = new Application.Enterprise.Data.Notifica(databaseName);
        }

        #region Miembros de INotifica
        /// <summary>
        /// Lista todas las cuentas por cobrar (Notifica).
        /// </summary>
        /// <returns></returns>
        public List<NotificaInfo> List()
        {
            return module.List();
        }


        /// <summary>
        /// Realiza la actualizacion de correos enviados.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateNotifica(string Nit, int Mt_Id, string Documento)
        {
     
                return module.UpdateNotifica(Nit,Mt_Id,Documento);
         
        }
        #endregion
    }
}
