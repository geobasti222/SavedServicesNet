using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Contactenos
    /// </summary>
    public interface IContactenos
    {
        #region "Metodos de Contactenos"
        
        /// <summary>
        ///  Lista todos los contactenos de las empresarias.
        /// </summary>
        /// <returns></returns>
        List<ContactenosInfo> List();
        
        /// <summary>
        /// Lista un contactenos x id.
        /// </summary>
        /// <param name="Id">Id del contactenos.</param>
        /// <returns></returns>
        ContactenosInfo ListxId(int Id);

        /// <summary>
        /// Guarda un mensaje de contactenos de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string Insert(ContactenosInfo item);

        /// <summary>
        /// Realiza la actualizacion del estado de un contactenos existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(ContactenosInfo item);

        #endregion
    }
}

