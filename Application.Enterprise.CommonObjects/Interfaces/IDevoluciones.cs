using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IDevoluciones
    {
        #region "Metodos de Devoluciones"

        List<DevolucionesInfo> ListXNit(string nit);

        List<DevolucionesInfo> ListXNitCampana(string nit, string campana);

        List<DevolucionesInfo> ListXNitNumero(string nit, string numero);

        #endregion
    }
}
