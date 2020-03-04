using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Cliente
    /// </summary>
    public interface ICliente
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


        //Lista el estado si ya actulizo los datos un cliente 
        List<ClienteInfo> getClienteactualinfo(string cedula);

        bool actulizarDatosPersonales(string cedula, string celular, string direccion, string  direccionenvio,  string email); 

        /// <summary>
        ///  Realiza el pre-registro de una empresaria
        /// </summary>
        /// <param name="item"></param>
        bool RegistrarEmpresaria(ClienteInfo item);

        /// <summary>
        /// Realiza el registro de una empresaria de peru.
        /// </summary>
        /// <param name="item"></param>
        bool RegistrarEmpresariaPeru(ClienteInfo item);

        /// <summary>
        ///  Realiza la aprobacion de una empresaria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool AprobarEmpresaria(ClienteInfo item);

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
        /// Lista los clientes de una zona especifica con privilegio.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxZonaPrivilegio(string IdZona);       


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
        /// Realiza la actualizacion de una empresaria en Peru.
        /// </summary>
        /// <param name="item"></param>
        bool UpdateClientePeru(ClienteInfo item);

        /// <summary>
        /// Este es igual al Update "A" pero se le agrega vendedor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AprobarEmpresariaConVendedor(ClienteInfo item);

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
        /// Realiza la actualizacion de la aceptacion de terminos y condiciones.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        bool UpdateAceptoTerminosyCondiciones(ClienteInfo objClienteInfo);

        /// <summary>
        /// Realiza la actualizacion del email de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        bool UpdateEmailCliente(ClienteInfo objClienteInfo);

        /// <summary>
        /// Realiza la actualizacion del estado de la asignacion de premio de bienvenida.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        bool UpdateEstadoPremioCliente(string Nit);

        /// <summary>
        /// Realiza la actualizacion de ciudad de despacho una empresaria.
        /// </summary>
        /// <param name="item"></param>
        bool ActualizarCiudadDespacho(ClienteInfo item);

        /// <summary>
        /// Realiza la actualizacion de la red de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdLider"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateModificarRed(string Nit, string IdLider, string Usuario);

        /// <summary>
        /// Realiza la actualizacion de una empresaria si es del plan privilegio o no.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoPrivilegio"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateEstadoPrivilegio(string Nit, bool EstadoPrivilegio, string Usuario);

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
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerenteSimple(string IdVendedor);


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
        /// Lista las empresarias Inactivas de acuerdo a una campaña especifica
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasInactivasXCampana(string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// lista las empresarias prospecto de la zona 9106
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasProspectoVPN();

        /// <summary>
        /// Lista las empresarias Inactivas de acuerdo a una campaña especifica - Para gerentes divisionales
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasInactivasXCampanaDivisional(string Zona, string CodigoRegional, string Campana);

        /// <summary>
        /// Lista si el cliente debe ver los terminos y condiciones de la plataforma.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        ClienteInfo MostrarTerminosyCondiciones(string nit);

        /// <summary>
        /// Lista las empresarias de una gerente que pertenece a una zona maestra.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEmpresariasxGerenteSimpleZonaMaestra(string Zona);

        /// <summary>
        /// Lista todos los estados de los clientes.
        /// </summary>
        /// <returns></returns>
        List<ClienteInfo> ListEstadosEmpresarias();

        /// <summary>
        /// Lista el reporte de estados de las empresarias x campaña.
        /// </summary>
        /// <param name="IdEstado"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<ClienteInfo> ListEstadosEmpresariasxCampana(int IdEstado, string Campana);

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

        #region DESMANTELADORA

        /// <summary>
        /// List cliente que sea demanteladora para cambiar estado del pedido
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        bool BuscaDemanteladora(string Nit, string Zona);

        #endregion

         /// <summary>
        /// consulta informe cartera y estado comercial
        /// </summary>
        /// <param name="item"></param>
        List<ClienteInfo> InformeCarteraComercial(string estado, string campana);

        /// <summary>
        /// Mira el saldo de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ClienteSaldo(string Nit);

        /// <summary>
        /// lista un Cliente de SVDN especifico por nit. de norte para la regla de 50000
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ListClienteNORTE(string Nit);
        
         /// <summary>
        /// lista cliente para mirar su tipo envio
        /// </summary>
        /// <returns></returns>
        ClienteInfo ClienteTipoEnvio(string nit);

        /// Mira el saldo de un cliente 50 mil anticipo
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        ClienteInfo ClienteSaldo50Mil(string Nit);
        
    }
}
