using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IPuntosSaved
    /// </summary>
    public interface IPuntosSaved
    {
        #region "Metodos de IPuntosSaved"
        int ConsultarPuntosEfectivosEmpresaria(string nit);
        bool InsertDetallePuntos(PuntosSavedInfo item);
        bool InsertPuntosTotal(PuntosSavedInfo item);
        bool InsertDetallePuntosAdicionales(PuntosSavedInfo item);



        #endregion
    }
}

