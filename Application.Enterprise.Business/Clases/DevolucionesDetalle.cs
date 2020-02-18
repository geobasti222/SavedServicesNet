using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class DevolucionesDetalle:IDevolucionesDetalle
    {

        private Application.Enterprise.Data.DevolucionesDetalle module;

        public DevolucionesDetalle()
        {
            module = new Application.Enterprise.Data.DevolucionesDetalle();
        }

        public DevolucionesDetalle(string databaseName)
        {
            module = new Application.Enterprise.Data.DevolucionesDetalle(databaseName);
        }

        #region Miembros de IDevoluciones

        public List<DevolucionesDetalleInfo> List(string nit, string numero)
        {
            return module.List(nit, numero);
        }

        #endregion
    }
}
