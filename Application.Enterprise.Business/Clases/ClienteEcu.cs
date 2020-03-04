using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para cliente
    /// </summary>
    public class ClienteEcu : IClienteEcu
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ClienteEcu module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ClienteEcu()
        {
            module = new Application.Enterprise.Data.ClienteEcu();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ClienteEcu(string databaseName)
        {
            module = new Application.Enterprise.Data.ClienteEcu(databaseName);
        }

        #region Miembros de ICliente
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista un cliente especifico por nit.
        /// </summary>
        /// <returns></returns>
        public ClienteInfo ListxNIT(string nit)
        {
            return module.ListxNIT(nit);
        }



        /// <summary>
        /// lista un Cliente de SVDN especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteSVDNxNit(string Nit)
        {
            return module.ListClienteSVDNxNit(Nit);
        }

        public bool RegistrarEmpresaria(ClienteInfo item)
        {
            bool okTrans = false;

            try
            {
                okTrans = module.RegistrarEmpresaria(item);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            return okTrans;

        }

        /// <summary>
        /// lista las empresarias con un estado de cliente.
        /// </summary>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListxEstadosCliente(int EstadoCliente)
        {
            return module.ListxEstadosCliente(EstadoCliente);
        }

        /// <summary>
        ///  Realiza la aprobacion de una empresaria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresaria(ClienteInfo item)
        {
            try
            {
                return module.AprobarEmpresaria(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }

        }

        /// <summary>
        /// -Realiza la actualizacion de una empresaria prospecto aprobada por CCN.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresariaProspecto(ClienteInfo item)
        {
            try
            {
                return module.AprobarEmpresariaProspecto(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }

        }

        /// <summary>
        /// Eliminar una Empresaria del sistema.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public bool BorrarEmpresaria(string nit)
        {
            //TODO: Implelementar
            return false;
        }

        /// <summary>
        /// lista todas las empresarias.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListTodasEmpresarias()
        {
            return module.ListTodasEmpresarias();
        }

        /// <summary>
        /// lista un cliente especifico por nit para un encabezado de pedido.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxEncabezadoPedido(string nit)
        {
            return module.ListxNITxEncabezadoPedido(nit);
        }

        /// <summary>
        /// lista las empresarias de una gerente de zona.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerente(string IdVendedor)
        {
            return module.ListEmpresariasxGerente(IdVendedor);
        }

        /// <summary>
        /// Lista la direccion y telefono principal de una empresaria.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListTelefonoDireccionxNIT(string nit)
        {
            return module.ListTelefonoDireccionxNIT(nit);
        }

        /// <summary>
        /// Realiza la actualizacion de direccion y telefono de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarDireccionTelefono(ClienteInfo item)
        {
            try
            {
                return module.ActualizarDireccionTelefono(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de migracion del cliente a produccion en la BD de Nivi y MKT.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateClienteEnProduccion(string Nit, bool EnProduccion)
        {
            try
            {
                return module.UpdateClienteEnProduccion(Nit, EnProduccion);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de la zona de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool UpdateZona(string Nit, string Zona)
        {
            try
            {
                return module.UpdateZona(Nit, Zona);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }
        /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateCliente(ClienteInfo item)
        {
            try
            {
                return module.UpdateCliente(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        public bool UpdateEstadoCliente(string Nit, int EstadoCliente)
        {
            try
            {
                return module.UpdateEstadoCliente(Nit, EstadoCliente);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de Nivi en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDNivi(ClienteInfo item)
        {
            try
            {
                return module.InsertClienteBDNivi(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        
        /// <summary>
        /// Realiza la actualizacion de la red de una empresaria inactiva a posible reingreso.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateEstadoClienteCambioZona(ClienteInfo item)
        {
            try
            {
                return module.UpdateEstadoClienteCambioZona(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de MKT en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDMkt(ClienteInfo item)
        {
            try
            {
                return module.InsertClienteBDMkt(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de SVDN para iniciar el procesamiento.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDSVDN(ClienteInfo item)
        {
            try
            {
                return module.InsertClienteBDSVDN(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// lista todos los Clientes de SVDN existentes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListClientesSVDN()
        {
            return module.ListClientesSVDN();
        }

        /// <summary>
        /// lista un Cliente de nivi especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteNivixNit(string Nit)
        {
            return module.ListClienteNivixNit(Nit);
        }

        /// <summary>
        /// lista un Cliente de MKT especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteMktxNit(string Nit)
        {
            return module.ListClienteMktxNit(Nit);
        }

        /// <summary>
        /// Lista los clientes de una zona especifica.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxZona(string IdZona)
        {
            return module.ListEmpresariasxZona(IdZona);
        }

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimple(string nit)
        {
            return module.ListxNITSimple(nit);
        }

        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado para editar.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimpleEdit(string nit)
        {
            return module.ListxNITSimpleEdit(nit);
        }

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimple(string IdVendedor)
        {
            return module.ListEmpresariasxGerenteSimple(IdVendedor);
        }

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerentexEstado(string IdVendedor, int EstadoCliente)
        {
            return module.ListEmpresariasxGerentexEstado(IdVendedor, EstadoCliente);
        }

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasActivasxGerenteSimple(string IdVendedor)
        {
            return module.ListEmpresariasActivasxGerenteSimple(IdVendedor);
        }

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple edit.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimpleEdit(string IdVendedor)
        {
            return module.ListEmpresariasxGerenteSimpleEdit(IdVendedor);
        }


        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLider(string IdLider)
        {
            return module.ListEmpresariasxLider(IdLider);
        }

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLiderEstado(string IdLider, int EstadoCliente)
        {
            return module.ListEmpresariasxLiderEstado(IdLider, EstadoCliente);
        }

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLiderActivas(string IdLider)
        {
            return module.ListEmpresariasxLiderActivas(IdLider);
        }

        /// <summary>
        /// Lista las empresarias de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteRegional(string CodigoRegional)
        {
            return module.ListEmpresariasxGerenteRegional(CodigoRegional);
        }


        /// <summary>
        /// listado de clientes de bienvenida.
        /// </summary>
        /// <param name="FechaIngreso"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListClienteBienvenida(DateTime FechaIngreso)
        {
            return module.ListClienteBienvenida(FechaIngreso);
        }

        /// <summary>
        /// Lista el listado de clientes por estado egreso.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoEgreso(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoEgreso(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Nuevas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoNuevas(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoNuevas(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresos(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoPosiblesEgresos(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista la consecutividad de campañas de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<string> ListConsecutividadCliente(string Nit)
        {
            return module.ListConsecutividadCliente(Nit);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Activas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoActivas(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoActivas(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista los clientes con estado prospecto
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListClientesProspecto()
        {
            return module.ListClientesProspecto();
        }


        /// <summary>
        /// Lista el listado de clientes por estado egreso para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoEgresoRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoEgresoRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado nuevas para regionales.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoNuevasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoNuevasRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresosRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoPosiblesEgresosRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista el listado de clientes por estado Activas para regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoActivasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            return module.ListEmpresariasxEstadoActivasRegionales(IdVendedor, Zona, CodigoRegional, Campana);
        }

        /// <summary>
        /// Lista todos los nit y estados de las empresarias que no hayan generado pedido en la campaña anterior a la actual
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariaSinPedido()
        {
            return module.ListEmpresariaSinPedido();
        }

        public List<ClienteInfo> ListInformacionEmpresarias(string cedula)
        {
            return module.ListInformacionEmpresarias(cedula);
        }

        /// <summary>
        /// Lista si una empresaria corresponde a un lider.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="idlider"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxLider(string nit, string idlider)
        {
            return module.ListxNITxLider(nit, idlider);
        }


        /// <summary>
        /// Lista el estado de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListEstadoxNit(string Nit)
        {
            return module.ListEstadoxNit(Nit);
        }

        /// <summary>
        /// Lista el estado de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ConsultaClienteNit(string Nit)
        {
            return module.ConsultaClienteNit(Nit);
        }

        #endregion

        #region Metodos del Buscador

        /// <summary>
        ///  Mapeo de los criterios de busqueda seleccionados por el usuario con los campos originales de la base de datos
        /// </summary>
        /// <param name="language">Idioma</param>
        /// <returns>Lista de mapero para el buscador</returns>
        public TableMapping SearchMapping(string language)
        {
            return module.SearchMapping(language);

        }

        /// <summary>
        /// Consulta las empresarias existentes.
        /// </summary>
        /// <param name="lstItem">lista de condiciones a buscar.</param>
        /// <returns>resultado de las empresarias encontrados.</returns>
        public List<ClienteInfo> ListSearch(List<SearchCondition> lstItem)
        {
            string filter = SearchCondition.GetFilterQueryList(lstItem);
            return module.ListSearch(filter);
        }

        #endregion

    }
}
