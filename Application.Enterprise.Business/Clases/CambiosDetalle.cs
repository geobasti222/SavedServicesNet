using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class CambiosDetalle:ICambiosDetalle
    {

        private Application.Enterprise.Data.CambiosDetalle module;

        public CambiosDetalle()
        {
            module = new Application.Enterprise.Data.CambiosDetalle();
        }

        public CambiosDetalle(string databaseName)
        {
            module = new Application.Enterprise.Data.CambiosDetalle(databaseName);
        }

        #region Miembros de ICambios

        public List<CambiosDetalleInfo> ListEntrada(string nit, string numero)
        {
            return module.ListEntrada(nit, numero);
        }

        public List<CambiosDetalleInfo> ListSalida(string nit, string numero)
        {
            return module.ListSalida(nit, numero);
        }

        #endregion
    }
}
