using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Cliente
    /// </summary>
    public interface IClienteEcu
    {
        #region "Metodos de Cliente"

        /// <summary>
        /// lista todos los clientes existentes.
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> List();

        /// <summary>
        /// lista un cliente especifico por nit.
        /// </summary>
        /// <returns></returns>
        ClienteInfo ListxNIT(string nit);

   


        /// <summary>
        /// lista un Cliente de SVDN especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ListClienteSVDNxNit(string Nit);

        /// <summary>
        /// lista las empresarias con un estado de cliente.
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListxEstadosCliente(int EstadoCliente);

        /// <summary>
        ///  Realiza el pre-registro de una empresaria
        /// </summary>
        /// <param name="item"></param>
        bool RegistrarEmpresaria(ClienteInfo item);

        /// <summary>
        ///  Realiza la aprobacion de una empresaria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool AprobarEmpresaria(ClienteInfo item);

        /// <summary>
        /// -Realiza la actualizacion de una empresaria prospecto aprobada por CCN.
        /// </summary>
        /// <param name="item"></param>
        bool AprobarEmpresariaProspecto(ClienteInfo item);

        /// <summary>
        /// Eliminar una Empresaria del sistema.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        bool BorrarEmpresaria(string nit);

        /// <summary>
        /// lista todas las empresarias.
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListTodasEmpresarias();

        /// <summary>
        /// lista un cliente especifico por nit para un encabezado de pedido.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        ClienteInfo ListxNITxEncabezadoPedido(string nit);

        /// <summary>
        /// lista las empresarias de una gerente de zona.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerente(string IdVendedor);

        /// <summary>
        /// Lista la direccion y telefono principal de una empresaria.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        ClienteInfo ListTelefonoDireccionxNIT(string nit);

        /// <summary>
        /// Lista el listado de clientes por estado egreso.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoEgreso(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista el listado de clientes por estado Nuevas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoNuevas(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresos(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista el listado de clientes por estado Activas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoActivas(string IdVendedor, string Zona, string CodigoRegional, string Campana);


        /// <summary>
        /// Realiza la actualizacion de direccion y telefono de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        bool ActualizarDireccionTelefono(ClienteInfo item);

        /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool UpdateCliente(ClienteInfo item);

        /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool UpdateEmpresariaLider(ClienteInfo item);


        /// <summary>
        /// Realiza la actualizacion del estado de migracion del cliente a produccion en la BD de Nivi y MKT.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        bool UpdateClienteEnProduccion(string Nit, bool EnProduccion);

        /// <summary>
        /// Realiza la actualizacion de la zona de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        bool UpdateZona(string Nit, string Zona);

        /// <summary>
        /// Realiza la actualizacion del estado de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        bool UpdateEstadoCliente(string Nit, int EstadoCliente);

        /// <summary>
        /// Realiza la actualizacion de la red de una empresaria inactiva a posible reingreso.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateEstadoClienteCambioZona(ClienteInfo item);

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de Nivi en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool InsertClienteBDNivi(ClienteInfo item);

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de MKT en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool InsertClienteBDMkt(ClienteInfo item);

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de SVDN para iniciar el procesamiento.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool InsertClienteBDSVDN(ClienteInfo item);


        /// <summary>
        /// lista todos los Clientes de SVDN existentes.
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListClientesSVDN();

        /// <summary>
        /// lista un Cliente de nivi especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ListClienteNivixNit(string Nit);

        /// <summary>
        /// lista un Cliente de MKT especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ListClienteMktxNit(string Nit);

        /// <summary>
        /// Lista los clientes de una zona especifica.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxZona(string IdZona);

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        ClienteInfo ListxNITSimple(string nit);

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado para editar.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        ClienteInfo ListxNITSimpleEdit(string nit);

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerenteSimple(string IdVendedor);

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <param name="EstadoCliente">Id del estado Empresaria.</param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerentexEstado(string IdVendedor, int EstadoCliente);

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasActivasxGerenteSimple(string IdVendedor);

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple edit.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerenteSimpleEdit(string IdVendedor);

        /// <summary>
        /// Lista las empresarias de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerenteRegional(string CodigoRegional);

        /// <summary>
        /// listado de clientes de bienvenida.
        /// </summary>
        /// <param name="FechaIngreso"></param>
        /// <returns></returns>
        List<ClienteInfo> ListClienteBienvenida(DateTime FechaIngreso);

        /// <summary>
        /// Lista la consecutividad de campañas de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<string> ListConsecutividadCliente(string Nit);

        /// <summary>
        /// Lista los clientes con estado prospecto
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListClientesProspecto();


        /// <summary>
        /// Lista el listado de clientes por estado egreso para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoEgresoRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista el listado de clientes por estado nuevas para regionales.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoNuevasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresosRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista el listado de clientes por estado Activas para regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxEstadoActivasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista todos los nit y estados de las empresarias que no hayan generado pedido en la campaña anterior a la actual
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariaSinPedido();

        /// <summary>
        /// Lista todas las empresarias con su informacion de clasificacion por valor y estado
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListInformacionEmpresarias(string cedula);

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxLider(string IdLider);

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxLiderEstado(string IdLider, int EstadoCliente);

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxLiderActivas(string IdLider);

        /// <summary>
        /// Lista si una empresaria corresponde a un lider.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="idlider"></param>
        /// <returns></returns>
        ClienteInfo ListxNITxLider(string nit, string idlider);

        /// <summary>
        /// Lista el estado de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ListEstadoxNit(string Nit);

        /// <summary>
        /// Lista el estado de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ConsultaClienteNit(string Nit);

        #endregion

        #region Metodos del Buscador

        /// <summary>
        /// Obtiene la tabla de mapeo para el buscador.
        /// </summary>
        /// <param name="language">Lenguaje.</param>
        /// <returns>Tabla de mapeo.</returns>
        TableMapping SearchMapping(string language);

        /// <summary>
        /// realiza la busqueda de las empresarias por medio del buscador.
        /// </summary>
        /// <param name="lstItem">Lista de parametros para el filtro de busqueda.</param>
        /// <returns>Lista de empresarias encontradas.</returns>
        List<ClienteInfo> ListSearch(List<SearchCondition> lstItem);

        #endregion
    }
}
