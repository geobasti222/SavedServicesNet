namespace Application.Enterprise.Business
{
    using Application.Enterprise.CommonObjects.Interfaces;
    using Application.Enterprise.CommonObjects;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    public class DescuentoGlod : IDescuentoGlod
    {
        private Application.Enterprise.Data.DescuentoGlod module;

        public DescuentoGlod()
        {
            this.module = new Application.Enterprise.Data.DescuentoGlod();
        }

        public DescuentoGlod(string databaseName)
        {
            this.module = new Application.Enterprise.Data.DescuentoGlod(databaseName);
        }

        public bool Delete(int Id, string Usuario)
        {
            try
            {
                return this.module.Delete(Id, Usuario);
            }
            catch (Exception exception1)
            {
                Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                return false;
            }
        }

        public string getGrupoCliente(string nit) => 
            this.module.getGrupoCliente(nit);

        public int Insert(DescuentoInfo item)
        {
            try
            {
                return this.module.Insert(item);
            }
            catch (Exception exception1)
            {
                Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                return 0;
            }
        }

        public List<DescuentoInfo> List() => 
            this.module.List();

        public DescuentoInfo ListxId(int Id) => 
            this.module.ListxId(Id);

        public DescuentoInfo ListxValorPedido(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana) => 
            this.module.ListxValorPedido(ValorPedido, UnidadNegocio, GrupoProducto, Campana);

        public DescuentoInfo ListxValorPedidoProdEstrella(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella) => 
            this.module.ListxValorPedidoProdEstrella(ValorPedido, UnidadNegocio, GrupoProducto, Campana, ProdEstrella);

        public DescuentoInfo ListxValorPedidoProdEstrellaXGrupoCliente(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella, string grupoCliente) => 
            this.module.ListxValorPedidoProdEstrellaXGrupoCliente(ValorPedido, UnidadNegocio, GrupoProducto, Campana, ProdEstrella, grupoCliente);

        public bool Update(DescuentoInfo item)
        {
            try
            {
                return this.module.Update(item);
            }
            catch (Exception exception1)
            {
                Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                return false;
            }
        }
    }
}

