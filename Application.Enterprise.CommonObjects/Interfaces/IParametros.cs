using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Parametros
    /// </summary>
    public interface IParametros
    {
        #region "Metodos de Parametros"

        /// <summary>
        /// Lista todos los parametros del sistema
        /// </summary>
        /// <returns></returns>
        List<ParametrosInfo> List();

        /// <summary>
        /// Lista un parametro especifico del sistema
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ParametrosInfo ListxId(int Id);

        /// <summary>
        /// Realiza la actualizacion de un parametro del sistema.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(ParametrosInfo item);



        #endregion
    }
}

