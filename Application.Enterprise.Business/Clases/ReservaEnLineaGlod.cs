namespace Application.Enterprise.Business
{
    using Application.Enterprise.CommonObjects.Interfaces;
    using Application.Enterprise.CommonObjects;
    using Application.Enterprise.Data;
    using System;
    using System.Diagnostics;
    using System.Reflection;

    public class ReservaEnLineaGlod : IReservaEnLineaGlod
    {
        private Application.Enterprise.Data.ReservaEnLineaGlod module;

        public ReservaEnLineaGlod()
        {
            this.module = new Application.Enterprise.Data.ReservaEnLineaGlod();
        }

        public ReservaEnLineaGlod(string databaseName)
        {
            this.module = new Application.Enterprise.Data.ReservaEnLineaGlod(databaseName);
        }

        public string RealizarReservaEnLinea(string NumeroPedido)
        {
            try
            {
                return this.module.RealizarReservaEnLinea(NumeroPedido);
            }
            catch (Exception exception1)
            {
                Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                return "";
            }
        }

        public string RealizarReservaEnLineaDifBodega(string NumeroPedido, string bodega, int cobrarFlete)
        {
            try
            {
                return this.module.RealizarReservaEnLineaDifBodega(NumeroPedido, bodega, cobrarFlete);
            }
            catch (Exception exception1)
            {
                Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                return "";
            }
        }
    }
}

