using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Estado
    /// </summary>
    public interface IEstado
    {
        #region "Metodos de Estado"

        /// <summary>
        /// lista todos los Estados existentes.
        /// </summary>
        /// <returns></returns>
        List<EstadoInfo> List();

        /// <summary>
        /// lista todos los Estados existentes por codigo de pais.
        /// </summary>
        /// <returns></returns>
        List<EstadoInfo> ListByPais(string CodPais);

        /// <summary>
        ///Lista todos los departamentos de una zona especifica.
        /// </summary>
        /// <returns></returns>
        List<EstadoInfo> ListDepartamentosxZona(string IdZona);

        /// <summary>
        /// GAVL Lista Estados por Estado
        /// </summary>
        /// <param name="codestado"></param>
        /// <returns></returns>
        EstadoInfo ListXEstado(string codestado);

        /// <summary>
        /// Lista los departamentos x ciudad
        /// </summary>
        /// <param name="codestado"></param>
        /// <returns></returns>
        EstadoInfo ListDeptoxCiudad(string codestado);

        #endregion
    }
}
