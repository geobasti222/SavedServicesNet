using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IDevolucionesDetalle
    {
        #region "Metodos de Detalle de Devoluciones"

        List<DevolucionesDetalleInfo> List(string nit, string numero);

        #endregion
    }
}
