using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface ICambiosDetalle
    {
        #region "Metodos de Detalle de Cambios"

        List<CambiosDetalleInfo> ListEntrada(string nit, string numero);

        List<CambiosDetalleInfo> ListSalida(string nit, string numero);

        #endregion
    }
}
