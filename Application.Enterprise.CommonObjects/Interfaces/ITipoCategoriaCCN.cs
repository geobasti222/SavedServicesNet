using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TipoCategoriaCCN
    /// </summary>
    public interface ITipoCategoriaCCN
    {
        #region "Metodos de Tipo Categoria CCN"

        /// <summary>
        /// Lista todos los tipos de categoria para el contactenos de CCN.
        /// </summary>
        /// <returns></returns>
        List<TipoCategoriaCCNInfo> List();

        #endregion
    }
}

