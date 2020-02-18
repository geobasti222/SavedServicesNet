namespace Application.Enterprise.CommonObjects.Interfaces
{
    using Application.Enterprise.CommonObjects;
    using System;
    using System.Collections.Generic;

    public interface IDescuentoGlod
    {
        bool Delete(int Id, string Usuario);
        string getGrupoCliente(string nit);
        int Insert(DescuentoInfo item);
        List<DescuentoInfo> List();
        DescuentoInfo ListxId(int Id);
        DescuentoInfo ListxValorPedido(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana);
        DescuentoInfo ListxValorPedidoProdEstrella(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella);
        DescuentoInfo ListxValorPedidoProdEstrellaXGrupoCliente(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella, string grupoCliente);
        bool Update(DescuentoInfo item);
    }
}

