using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class Devoluciones:IDevoluciones
    {
        
        private Application.Enterprise.Data.Devoluciones module;

        public Devoluciones()
        {
            module = new Application.Enterprise.Data.Devoluciones();
        }

        public Devoluciones(string databaseName)
        {
            module = new Application.Enterprise.Data.Devoluciones(databaseName);
        }

        #region Miembros de IDevoluciones

        public List<DevolucionesInfo> ListXNit(string nit)
        {
            return module.ListXNit(nit);
        }

        public List<DevolucionesInfo> ListXNitCampana(string nit, string campana)
        {
            return module.ListXNitCampana(nit, campana);
        }

        public List<DevolucionesInfo> ListXNitNumero(string nit, string numero)
        {
            return module.ListXNitNumero(nit, numero);
        }

        #endregion
    }
}
