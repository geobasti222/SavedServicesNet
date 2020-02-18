using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface ICambios
    {
        #region "Metodos de Cambios"

        List<CambiosInfo> ListXNit(string nit);

        List<CambiosInfo> ListXNitCampana(string nit, string campana);

        List<CambiosInfo> ListXNitNumero(string nit, string numero);

        #endregion
    }
}
