using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de SustitutosDetalle
    /// </summary>
    public interface ISustitutos
    {
        #region "Metodos de SustitutosDetalle"

        List<SustitutosInfo> Lista(string Referencia, string Catalogo);

        #endregion
    }
}

