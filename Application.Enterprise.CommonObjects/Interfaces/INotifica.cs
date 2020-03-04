using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de CxC
    /// </summary>
    public interface INotifica
    {
        #region "Metodos de Notificacion"

        /// <summary>
        /// Lista todas las cuentas por cobrar (CxC).
        /// </summary>
        /// <returns></returns>
        List<NotificaInfo> List();
   /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool UpdateNotifica(string Nit, int Mt_Id, string Documento);


        #endregion
    }
}

