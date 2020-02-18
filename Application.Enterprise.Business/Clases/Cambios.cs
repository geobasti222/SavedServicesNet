using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class Cambios:ICambios
    {
        
        private Application.Enterprise.Data.Cambios module;

        public Cambios()
        {
            module = new Application.Enterprise.Data.Cambios();
        }

        public Cambios(string databaseName)
        {
            module = new Application.Enterprise.Data.Cambios(databaseName);
        }

        #region Miembros de ICambios

        public List<CambiosInfo> ListXNit(string nit)
        {
            return module.ListXNit(nit);
        }

        public List<CambiosInfo> ListXNitCampana(string nit, string campana)
        {
            return module.ListXNitCampana(nit, campana);
        }

        public List<CambiosInfo> ListXNitNumero(string nit, string numero)
        {
            return module.ListXNitNumero(nit, numero);
        }

        #endregion
    }
}
