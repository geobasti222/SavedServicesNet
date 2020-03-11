using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Threading;
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Pedidos Cliente
    /// </summary>
    public class PedidosCliente : IPedidosCliente
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PedidosCliente module;

        private DateTime _startAsignacionTime;

        public bool ReiniciarInventario;

        public static string CampanaSeleccionada;

        //------------------------------------------------
        public Thread AsignarReglasPedidoThread;
        public Thread AsignarNivelServicioCantidadPedidoThread;
        public Thread AsignarNivelServicioValorPedidoThread;
        public Thread AsignarInventarioPedidoThread;
        public Thread MigrarClientesThread;
        public Thread BloquearPedidoProspectoThread;
        public Thread BloquearPedidoCarteraThread;
        public Thread BloquearPedidoDesmanteladoraThread;
        public Thread BloquearPedidosOtrosCatalogosThread;
        public Thread UnificarPedidosThread;
        public Thread BloquearPedidoNivelServicioThread;
        public Thread ProcesarOtrosCatalogosThread;
        public Thread AsignarPremiosThread;
        public Thread ProcesarPedidosFacturarThread;
        public Thread ProcesarHistoricoClientesThread;

        public event OnPedidoProcesamientoEventHandler OnPedidoEvent; //3) crear evento del tipo del numeral 1)
        public event OnClientesProcesamientoEventHandler OnClienteEvent; //3) crear evento del tipo del numeral 1)

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PedidosCliente()
        {
            module = new Application.Enterprise.Data.PedidosCliente();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PedidosCliente(string databaseName)
        {
            module = new Application.Enterprise.Data.PedidosCliente(databaseName);
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PedidosCliente(string databaseName, string Campana)
        {
            module = new Application.Enterprise.Data.PedidosCliente(databaseName);
            CampanaSeleccionada = Campana;
        }

        public void StartAsignarReglasPedido()
        {
            AsignarReglasPedidoThread = new Thread(new ThreadStart(this.AsignarReglasPedido));
            this.AsignarReglasPedidoThread.Start();
        }

        public void StartAsignarReglasPedidoEcuador()
        {
            AsignarReglasPedidoThread = new Thread(new ThreadStart(this.AsignarReglasPedidoEcuador));
            this.AsignarReglasPedidoThread.Start();
        }

        public void StartAsignarNivelServicioCantidadPedido()
        {
            AsignarNivelServicioCantidadPedidoThread = new Thread(new ThreadStart(this.AsignarNivelServicioCantidad));
            this.AsignarNivelServicioCantidadPedidoThread.Start();
        }

        public void StartAsignarNivelServicioValorPedido()
        {
            AsignarNivelServicioValorPedidoThread = new Thread(new ThreadStart(this.AsignarNivelServicioValorCosto));
            this.AsignarNivelServicioValorPedidoThread.Start();
        }

        public void StartAsignarNivelServicioValorPedidoEcuador()
        {
            AsignarNivelServicioValorPedidoThread = new Thread(new ThreadStart(this.AsignarNivelServicioValorCostoEcuador));
            this.AsignarNivelServicioValorPedidoThread.Start();
        }

        public void StartAsignarInventarioPedido()
        {
            AsignarInventarioPedidoThread = new Thread(new ThreadStart(this.AsignarInventarioPedido));
            this.AsignarInventarioPedidoThread.Start();
        }

        public void StartAsignarInventarioPedidoEcuador()
        {
            AsignarInventarioPedidoThread = new Thread(new ThreadStart(this.AsignarInventarioPedidoEcuador));
            this.AsignarInventarioPedidoThread.Start();
        }

        public void StartMigrarClientes()
        {
            MigrarClientesThread = new Thread(new ThreadStart(this.MigrarClientesNiviMkt));
            this.MigrarClientesThread.Start();
        }

        public void StartMigrarClientesEcuador()
        {
            MigrarClientesThread = new Thread(new ThreadStart(this.MigrarClientesNiviMktEcuador));
            this.MigrarClientesThread.Start();
        }

        public void StartBloquearPedidoCartera()
        {
            BloquearPedidoCarteraThread = new Thread(new ThreadStart(this.BloquearPedidosxCartera));
            this.BloquearPedidoCarteraThread.Start();
        }

        public void StartBloquearPedidoCarteraEcuador()
        {
            BloquearPedidoCarteraThread = new Thread(new ThreadStart(this.BloquearPedidosxCarteraEcuador));
            this.BloquearPedidoCarteraThread.Start();
        }

        public void StartBloquearPedidoProspecto()
        {
            //*BloquearPedidoProspectoThread = new Thread(new ThreadStart(this.BloquearPedidosxProspectos));
            BloquearPedidoProspectoThread = new Thread(new ThreadStart(this.BloquearPedidosxProspectos_Borrar));

            this.BloquearPedidoProspectoThread.Start();
        }

        public void StartBloquearPedidoDesmanteladora()
        {
            BloquearPedidoDesmanteladoraThread = new Thread(new ThreadStart(this.BloquearPedidosxDesmanteladora));
            this.BloquearPedidoDesmanteladoraThread.Start();
        }

        public void StartBloquearPedidosOtrosCatalagos()
        {
            BloquearPedidosOtrosCatalogosThread = new Thread(new ThreadStart(this.BloquearPedidosOtrosCatalogos));
            this.BloquearPedidosOtrosCatalogosThread.Start();
        }

        public void StartUnificarPedidos()
        {
            UnificarPedidosThread = new Thread(new ThreadStart(this.UnificarPedidosCatalogos));
            this.UnificarPedidosThread.Start();
        }

        public void StartBloquearPedidoNivelServicio()
        {
            BloquearPedidoNivelServicioThread = new Thread(new ThreadStart(this.BloquearPedidosxNivelServicioCantidad));
            this.BloquearPedidoNivelServicioThread.Start();
        }

        public void StartAsignarPremios()
        {
            AsignarPremiosThread = new Thread(new ThreadStart(this.AsignarPremiosPedido));
            this.AsignarPremiosThread.Start();
        }

        public void StartProcesarOtrosCatalogos()
        {
            ProcesarOtrosCatalogosThread = new Thread(new ThreadStart(this.AsignarPremiosPedido));
            this.ProcesarOtrosCatalogosThread.Start();
        }


        public void StartProcesarPedidosFacturar()
        {
            ProcesarPedidosFacturarThread = new Thread(new ThreadStart(this.ProcesarPedidosFacturar));
            this.ProcesarPedidosFacturarThread.Start();
        }

        public void StartProcesarPedidosFacturarEcuador()
        {
            ProcesarPedidosFacturarThread = new Thread(new ThreadStart(this.ProcesarPedidosFacturarEcuador));
            this.ProcesarPedidosFacturarThread.Start();
        }

        public void StartProcesarHistoricoClientes()
        {
            ProcesarHistoricoClientesThread = new Thread(new ThreadStart(this.ProcesarHistoricoClientes_Borrar));
            this.ProcesarHistoricoClientesThread.Start();
        }

        #region Miembros de IPedidosCliente

        /// <summary>
        /// lista todos los Pedidos Cliente existentes.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// lista todos los Pedidos de empresaria por una campaña.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresaria(string Nit, string Campana)
        {
            return module.ListxEmpresaria(Nit, Campana);
        }

        /// <summary>
        /// --Lista todos los pedidos de una empresaria por una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaxCampanaxCatalogo(string Nit, string Campana, string Catalogo)
        {
            return module.ListxEmpresariaxCampanaxCatalogo(Nit, Campana, Catalogo);
        }

        /// <summary>
        /// Lista todos los pedidos sin facturar una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoSinFacturar(string Nit, string Campana, string Catalogo)
        {
            return module.ListxPedidoSinFacturar(Nit, Campana, Catalogo);
        }

        /// <summary>
        /// Lista todos los pedidos sin facturar una campaña x catalogo de la reserva y como borrador.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoSinFacturarxReserva(string Nit, string Campana, string Catalogo, string NumeroPedido)
        {
            return module.ListxPedidoSinFacturarxReserva(Nit, Campana, Catalogo, NumeroPedido);
        }

        /// <summary>
        /// Consulta si un cliente realizo un pedido en la campaña.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoxNitxCampana(string Nit, string Campana, string NumeroPedidoCreado)
        {
            return module.ListxPedidoxNitxCampana(Nit, Campana, NumeroPedidoCreado);
        }

        /// <summary>
        /// Lista todos los pedidos sin facturar una campaña x catalogo y como borrador para reservar.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoSinFacturarxParaReservar(string Nit, string Campana, string Catalogo, string NumeroPedido)
        {
            return module.ListxPedidoSinFacturarxParaReservar(Nit, Campana, Catalogo, NumeroPedido);
        }

        /// <summary>
        /// lista todos los Pedidos de una gerente de zona por una campaña.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZona(string zona, string Campana)
        {
            return module.ListxGerenteZona(zona, Campana);
        }

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente.
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservados(string zona, string Campana)
        {
            return module.ListxGerenteZonaReservados(zona, Campana);
        }



        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una lider.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosxLider(string Lider, string Campana)
        {
            return module.ListxGerenteZonaReservadosxLider(Lider, Campana);
        }

        /// <summary>
        /// Lista todos los pedidos en reserva de una empresaria especifica.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaReservados(string Nit, string Campana)
        {
            return module.ListxEmpresariaReservados(Nit, Campana);
        }

        /// <summary>
        /// Lista todos los pedidos en reserva x campaña.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosReservados(string Campana)
        {
            return module.ListxPedidosReservados(Campana);
        }

        /// <summary>
        /// lista todos los Pedidos de una empresaria por una campaña, para el portal de empresarias.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaPortal(string Nit, string Campana)
        {
            return module.ListxEmpresariaPortal(Nit, Campana);
        }

        /// <summary>
        /// lista todos los Pedidos de un lider de zona por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxLider(string IdLider, string Campana)
        {
            return module.ListPedidosxLider(IdLider, Campana);
        }

        /// <summary>
        /// lista todos los Pedidos de una gerente de zona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaFacturados(string Zona, string Campana, string Lider, string Nit)
        {
            return module.ListxGerenteZonaFacturados(Zona, Campana, Lider, Nit);
        }

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxNitFacturadosEmpresarias(string Nit, string Campana)
        {
            return module.ListxNitFacturadosEmpresarias(Nit, Campana);
        }


        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaFacturados(string Nit, string Campana)
        {
            return module.ListxEmpresariaFacturados(Nit, Campana);
        }

        /// <summary>
        /// lista todos los Pedidos de una gerente de zona por una campaña facturados ecuador.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaFacturadosEc(string Vendedor, string Campana)
        {
            return module.ListxGerenteZonaFacturadosEc(Vendedor, Campana);
        }


        /// <summary>
        /// lista todos los Pedidos de un lider x zona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosFacturadosLider(string IdLider, string Campana)
        {
            return module.ListPedidosFacturadosLider(IdLider, Campana);
        }

        /// <summary>
        /// Muestra el resumen de los valores NETO y flete+iva de una campaña y un vendedor de los pedidos facturados y sin facturar.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxResumenTotalPedidos(string Vendedor, string Campana)
        {
            return module.ListxResumenTotalPedidos(Vendedor, Campana);
        }

        /// <summary>
        /// El resumen de pedidos para una gerente regional
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxResumenTotalPedidosGerenteRegional(string CedulaRegional, string Campana)
        {
            return module.ListxResumenTotalPedidosGerenteRegional(CedulaRegional, Campana);
        }


        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresaria(string Nit, string Campana)
        {
            return module.ListPedidosxEmpresaria(Nit, Campana);
        }

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña sin procesar.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresariaSinProcesar(string Nit, string Campana)
        {
            return module.ListPedidosxEmpresariaSinProcesar(Nit, Campana);
        }

        /// <summary>
        /// Lista el encabezado de un pedido especifico.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidoxId(string IdPedido)
        {
            return module.ListPedidoxId(IdPedido);
        }

        /// <summary>
        /// lista un pedido para saber en que mes se encuentra.
        /// </summary>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidoConsultarMes()
        {
            return module.ListPedidoConsultarMes();
        }

        /// <summary>
        ///  lista todos los pedidos de todos los mailgroup x campaña asin bloqueos y sin procesar.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTodosPedidoSinProcesarSinBloqueo()
        {
            return module.ListTodosPedidoSinProcesarSinBloqueo();
        }

        /// <summary>
        /// Lista un pedido de reserva en linea de la campaña actual.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListxGerenteZonaReservadosCPActual(string Nit)
        {
            return module.ListxGerenteZonaReservadosCPActual(Nit);
        }

        /// <summary>
        /// Lista todos los pedidos proximos a vencer para anular en el dia actual.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosProximosAnular()
        {
            return module.ListxPedidosProximosAnular();
        }

        /// <summary>
        /// Lista todos los pedidos proximos a vencer para anular en el dia actual BORRADOR.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosProximosAnularBorrador()
        {
            return module.ListxPedidosProximosAnularBorrador();
        }

        /// <summary>
        /// Lista todos los pedidos para cambio de campaña.
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosCambioCampana(string CampanaActual)
        {
            return module.ListxPedidosCambioCampana(CampanaActual);
        }

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista.
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportista(string zona, string Campana)
        {
            return module.ListxGerenteZonaReservadosSinTransportista(zona, Campana);
        }

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista x Divisional.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportistaxDivisional(string CedulaDivisional, string Campana)
        {
            return module.ListxGerenteZonaReservadosSinTransportistaxDivisional(CedulaDivisional, Campana);
        }

        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public string Insert(PedidosClienteInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente cargado con un XML.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertXML(PedidosClienteInfo item)
        {
            try
            {
                return module.InsertXML(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del registro de un encabezado de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PedidosClienteInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        #endregion

        #region "Procesamiento de Pedidos"

        /// <summary>
        /// Realiza a asignacion de reglas a los pedidos y asigna el orden final para procesar os mismos.
        /// </summary>
        public void AsignarReglasPedido()
        {
            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                //validar si ya existe un pedido procesando
                List<PedidosClienteInfo> list_temp = new List<PedidosClienteInfo>();

                //Consulta si hay pedidos en proceso en la tabla temporal
                list_temp = ListTablaTemporal();

                //Si no hay registros en la temporal se puede hacer el proceso. sino indica que hay pedidos en proceso.
                if (list_temp.Count == 0 || list_temp == null)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE ASIGNACIÓN DE REGLAS. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Captura el tiempo de inicio
                    _startAsignacionTime = DateTime.Now;

                    //---------------------------------------------------------------------------------------------------------------------------------------
                    //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, Y SE GUARDAN EN LA TABLA TEMPORAL PARA SEGUIR CON LA ASIGNACIÓN DE REGLAS.
                    //1. Se valida que no exista otro proceso de pedidos activo.
                    //2. Se preguntan si existen mailgroup para el dia actual.
                    //3. Se obtiene la campaña y zona del mailgroup actual.
                    //4. Se listan los pedidos de la zona y campaña actual para pasar a la asignacion de reglas.

                    //Se obtienen los mailgroup por fecha actual.
                    MailGroup ObjMailGroup = new MailGroup("conexion");
                    List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                    ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                    //se pregunta si existen Mailgroup para ese dia.
                    if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                    {
                        //Se realiza la asignacion de pedidos para cada mailgroup.
                        foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se obtiene la campaña de la fecha actual.
                            Campana ObjCampana = new Campana("conexion");
                            CampanaInfo ObjCampanaInfo = new CampanaInfo();
                            //ObjCampanaInfo = ObjCampana.ListxGetDate();

                            if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                            {
                                ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                            }
                            else
                            {
                                ObjCampanaInfo = ObjCampana.ListxGetDate();
                            }

                            //Se valida que exista una campaña activa.
                            if (ObjCampanaInfo != null)
                            {
                                //Se obtienen las zonas de un mailgroup por fecha actual.
                                Zona ObjZona = new Zona("conexion");
                                List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                //Se valida que existan zonas para el mailgroup actual.
                                if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                {
                                    //Se debe borra la tabla temporal con los pedidos de la zona y campaña actual.
                                    if (!DeleteTemporal())
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ELIMINAR TODOS LOS REGISTROS DE LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIA DE PEDIDOS A TABLA TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //contar cantidad total de pedidos para mostrar en formulario de presentacion.
                                    int totalpedidos = 0;

                                    //Se recorren las zonas y se trasladan los pedidos a la tabla temporal.
                                    foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                    {
                                        List<PedidosClienteInfo> ObjPedidosClienteInfoZonaCampana = new List<PedidosClienteInfo>();
                                        ObjPedidosClienteInfoZonaCampana = ListxZonaxCampana(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                        //NOTA: Se deben insertar todos los pedidos de todas las zonas antes de pasar las reglas
                                        //      por que sino queda filtrado por zona.
                                        //Se valida si existen pedidos de la zona y la campaña actual.
                                        if (ObjPedidosClienteInfoZonaCampana != null && ObjPedidosClienteInfoZonaCampana.Count > 0)
                                        {
                                            //Se insertan los pedidos a la tabla temporal.
                                            foreach (PedidosClienteInfo PedidoItemZona in ObjPedidosClienteInfoZonaCampana)
                                            {
                                                InsertxRegla(PedidoItemZona);
                                                //reiniciar el orden para que no se vaya a repetir.
                                                UpdateOrden(PedidoItemZona.Numero, 0);
                                                totalpedidos = totalpedidos + 1;
                                            }
                                        }
                                    }

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //----------------------------------------------------------------------------------------------------------------------
                                    //AQUI COMIENZA EL PROCESO DE APLICACIÓN DE REGLAS A LOS PEDIDOS DE UNA ZONA Y CAMPAÑA DE LA FECHA ACTUAL POR MAILGROUP
                                    //1. Se realiza e select de los pedidos por mailgroup (zona y campaña) y se copia a la tabla de pedidos temp.
                                    //2. Se realiza la asignacion de reglas a los pedidos del mailgroup.
                                    //3. Se obtiene un conjunto de pedidos listados por reglas y se actualiza el campo orden en la tabla de pedidos.
                                    //4. Cuando se procesa el pedido se organizan por el campo orden y se actualiza el campo Procesado a 1.


                                    //se borra la tabla temporal de pedidos para ir filtrando el orden de los pedidos con la regla aplicada.
                                    if (!DeleteTemporal())
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ELIMINAR TODOS LOS REGISTROS DE LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    Reglas ObjReglas = new Reglas("conexion");
                                    List<ReglasInfo> ObjReglasInfo = new List<ReglasInfo>();

                                    //Obtiene as reglas activas y en orden para los pedidos.
                                    ObjReglasInfo = ObjReglas.ListAsignarPedidos();

                                    List<PedidosClienteInfo> ObjPedidosClienteInfoReglas = new List<PedidosClienteInfo>();

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE REGLAS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    int OrdenTemp = 0;

                                    //Se hace el ciclo de asignacion de reglas a los pedidos.
                                    for (int i = 0; i < ObjReglasInfo.Count; i++)
                                    {

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TOTAL REGLAS:" + ObjReglasInfo.Count, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        ObjReglasInfo[i].Query = ObjReglasInfo[i].Query.ToUpper();

                                        //Se obtiene la lista de pedidos con las reglas siguientes
                                        //ObjReglasInfo[i].Query = ObjReglasInfo[i].Query.Replace("SVDN_PEDIDOSC1_2000", "SVDN_PEDIDOSC1_2000_TEMP");
                                        //ObjReglasInfo[i].Query = ObjReglasInfo[i].Query.Replace("SVDN_PEDIDOSC1_2000", "SVDN_PEDIDOSC1_2000");
                                        //Aqui se envia a ejecutar las regla para los pedidos.
                                        ObjPedidosClienteInfoReglas = ListxRegla(ObjReglasInfo[i].Query);

                                        //Si se obtuvieron pedidos y se aplicaron reglas.
                                        if (ObjPedidosClienteInfoReglas != null && ObjPedidosClienteInfoReglas.Count > 0)
                                        {
                                            //Se insertan los pedidos a la tabla temporal que corresponden a la regla aplicada.
                                            foreach (PedidosClienteInfo PedidoItem in ObjPedidosClienteInfoReglas)
                                            {
                                                OrdenTemp = OrdenTemp + 1;
                                                PedidoItem.Orden = OrdenTemp;
                                                InsertxRegla(PedidoItem);
                                            }
                                        }
                                    }

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE REGLAS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //AQUI LAS REGLAS YA SE APLICARON, SE ACTUALIZA EL CAMPO ORDEN DE PEDIDOS PARA COMENZAR A PROCESAR.
                                    //1. Se obtienen los registros de la tabla temporal con las reglas asignadas.
                                    //2. Se recorren los registros y se actualiza la tabla de pedidos con el orden asignado despues de las reglas.
                                    //3. Se validan los registros que no alcanzaron reglas y se les asigna el orden para el final.
                                    //4. Se borra la tabla temporal para los siguientes procesamientos de pedido.

                                    int OrdenFinal = 0;

                                    //Se consultan los pedidos de la tabla temporal con las reglas asignadas.
                                    List<PedidosClienteInfo> ObjPedidosClienteReglasTemp = new List<PedidosClienteInfo>();
                                    ObjPedidosClienteReglasTemp = ListTemporal();


                                    //Si se obtuvieron pedidos con reglas aplicadas de la tabla temporal.
                                    if (ObjPedidosClienteReglasTemp != null && ObjPedidosClienteReglasTemp.Count > 0)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ACTUALIZACIÓN DE ORDEN A PEDIDOS CON REGLAS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        foreach (PedidosClienteInfo PedidosReglasOrden in ObjPedidosClienteReglasTemp)
                                        {
                                            //Se actualiza el orden del pedido desde la lista temporal con reglas asignadas.
                                            if (UpdateOrden(PedidosReglasOrden.Numero, PedidosReglasOrden.Orden))
                                            {
                                                //se valida para que quede el ultimo orden asignado.
                                                if (PedidosReglasOrden.Orden > OrdenFinal)
                                                {
                                                    OrdenFinal = PedidosReglasOrden.Orden;
                                                }

                                                //Elimina el pedido actualizado de la tabla temporal por id de pedido.
                                                if (!DeletexNumeroPedido(PedidosReglasOrden.Numero))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ELIMINAR EL PEDIDO DE LA TABLA TEMPORAL. PEDIDO No:" + PedidosReglasOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }

                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ASIGNO EL ORDEN CORRECTAMENTE AL PEDIDO No:" + PedidosReglasOrden.Numero + " ORDEN: " + OrdenFinal, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                okProcess = true;

                                                //Contador de pedidos
                                                consecutivo = consecutivo + 1;
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ERROR ACTUALIZANDO EL ORDEN DE LOS PEDIDOS. PEDIDO No:" + PedidosReglasOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ACTUALIZACIÓN DE ORDEN EN PEDIDOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE OBTUVIERON PEDIDOS DE LA TABLA TEMPORAL CON REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    //*****************************************************************************************************************
                                    //AQUI SE PONE EL ORDEN A LOS PEDIDOS QUE NO CUMPLIERON REGLAS PARA QUE TODOS QUEDEN CON UN ORDEN ASIGNADO.
                                    //Consulta los pedidos que no alcanzaron a tener orden y asigna el ultimo orden depues de los pedidos con reglas.

                                    //Se recorren las zonas y se asigna el orden para los pedidos que no alcanzaron regla.
                                    foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                    {
                                        List<PedidosClienteInfo> ObjPedidosClienteSinOrden = new List<PedidosClienteInfo>();
                                        //Se envia la zona, campaña y orden (0) para obtener los pedidos sin reglas.
                                        //Se envia el orden = 0, que significa que no se ha asignado regla.
                                        ObjPedidosClienteSinOrden = ListxZonaxCampanaxOrden(ZonaMailGroup.Zona, ObjCampanaInfo.Campana, 0);

                                        //Se valida si existen pedidos de la zona y la campaña actual.
                                        if (ObjPedidosClienteSinOrden != null && ObjPedidosClienteSinOrden.Count > 0)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS SIN REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                            //Se insertan los pedidos a la tabla temporal.
                                            foreach (PedidosClienteInfo PedidoSinOrden in ObjPedidosClienteSinOrden)
                                            {
                                                //Se incrementa el ultimo orden en que que quedaron los pedidos con reglas y se actualiza.
                                                OrdenFinal = OrdenFinal + 1;

                                                //Se actualiza el orden del pedido que no se le asigno reglas.
                                                if (UpdateOrden(PedidoSinOrden.Numero, OrdenFinal))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ASIGNO EL ORDEN CORRECTAMENTE AL PEDIDO No:" + PedidoSinOrden.Numero + " ORDEN: " + OrdenFinal, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                    //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                    okProcess = true;

                                                    //Contador de pedidos
                                                    consecutivo = consecutivo + 1;

                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ERROR ACTUALIZANDO EL ORDEN DE LOS PEDIDOS SIN REGLA. PEDIDO No:" + PedidoSinOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                            }

                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ACTUALIZACIÓN DE ORDEN DE LOS PEDIDOS SIN REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }

                        //..............................................................................................................................
                        //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                        PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();


                        if (okProcess == false)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR REGLAS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA ASIGNAR REGLAS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //.......................................................................................
                            //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                            if (handler != null)
                            {
                                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                                handler(ObjPedidosClienteProcesadoInfo);
                            }
                            //.......................................................................................
                        }
                        else if (okProcess == true)
                        {

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR REGLAS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //...........................................................................
                            //Dispara el evento de que termino el proceso ok.                                               
                            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                            if (handler != null)
                            {
                                ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                                handler(ObjPedidosClienteProcesadoInfo);
                            }
                            //...........................................................................
                        }
                        //..............................................................................................................................

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE ASIGNACIÓN DE REGLAS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        //Calcula el tiempo que demora en realizar la asignacion de reglas.
                        TimeSpan ts = DateTime.Now - _startAsignacionTime;
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: PROCESO DE ASIGNACIÓN DE REGLAS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                        System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "EXISTE OTRO PROCESO DE PEDIDOS ACTIVO, POR FAVOR VERIFICAR LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //return okProcess;
        }

        /// <summary>
        /// Realiza a asignacion de reglas a los pedidos y asigna el orden final para procesar os mismos.
        /// </summary>
        public void AsignarReglasPedidoEcuador()
        {
            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }



        /// <summary>
        /// Realiza la asignacion de inventario a cada pedido.
        /// </summary>
        /// <returns></returns>
        public void AsignarInventarioPedido()
        {
            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.
            int si_cumpleninventario = 0;
            int no_cumpleninventario = 0;

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE ASIGNACIÓN DE INVENTARIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroup = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                {
                    //Se realiza la asignacion de pedidos para cada mailgroup.
                    foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se obtiene la campaña de la fecha actual.
                        Campana ObjCampana = new Campana("conexion");
                        CampanaInfo ObjCampanaInfo = new CampanaInfo();
                        //ObjCampanaInfo = ObjCampana.ListxGetDate();

                        if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                        {
                            ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                        }
                        else
                        {
                            ObjCampanaInfo = ObjCampana.ListxGetDate();
                        }

                        //Se valida que exista una campaña activa.
                        if (ObjCampanaInfo != null)
                        {

                            //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                            //1. Borrar tabla inventario para solo almacenar lo actual.
                            //2. Consultar saldos bodega.
                            //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                            //4. Consultar pedidos ordenados por orden de procesamiento.
                            //5. Actualizar el campo de cantidad  con respecto al inventario en el detalle del pedido.
                            //6. Restar cantidad actualizada a los saldos de inventario.

                            Inventario ObjInventario = new Inventario("conexion");


                            //----------------------------------------------------------
                            //Se valida si el procesamiento requiere reiniciar el inventario para calcular el nivel de servicio.
                            bool okDeleteInventario = true;

                            if (ReiniciarInventario == true)
                            {
                                if (!ObjInventario.DeleteAll())
                                {
                                    okDeleteInventario = false;
                                }
                            }
                            //----------------------------------------------------------

                            //Borrar la tabla de inventario para copiar el inventario actualizado.
                            //if (ObjInventario.DeleteAll())
                            if (okDeleteInventario)
                            {
                                //Se consulta el inventario del mes actual.
                                List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                                ObjInventarioInfoList = ObjInventario.ListSaldosBodega();

                                if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                                {
                                    //----------------------------------------------------------------------------------
                                    //si se requiere reiniciar el inventario se debe copiar de nuevo este en la tabla.
                                    if (ReiniciarInventario == true)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                                        foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                                        {
                                            //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                            if (!ObjInventario.Insert(ItemInventario))
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    Zona ObjZona = new Zona("conexion");
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                    //Se valida que existan zonas para el mailgroup actual.
                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            List<PedidosClienteInfo> ObjPedidosClienteConOrden = new List<PedidosClienteInfo>();
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosClienteConOrden = ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                            //Se valida si existen pedidos de la zona y la campaña actual.
                                            if (ObjPedidosClienteConOrden != null && ObjPedidosClienteConOrden.Count > 0)
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS CON REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                //Actualiza el estado a no procesado de los pedidos para volverlos a su estado inicial antes de rehacer el proceso.
                                                foreach (PedidosClienteInfo PedidoConOrdenNoProcess in ObjPedidosClienteConOrden)
                                                {
                                                    UpdateProcesado(PedidoConOrdenNoProcess.Numero, false);
                                                }

                                                int ContarAgotado = 0;

                                                //Se insertan los pedidos a la tabla temporal.
                                                foreach (PedidosClienteInfo PedidoConOrden in ObjPedidosClienteConOrden)
                                                {
                                                    bool okInventario = false;

                                                    ContarAgotado = 0;

                                                    //Consultar detalle del pedido.
                                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexId(PedidoConOrden.Numero);

                                                    //Se valida si existen detalles del pedido.
                                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                                    {
                                                        //Recorre el detalle del pedido.
                                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                            //Consulta el inventario del detalle del pedido especifico.
                                                            InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                                            ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostos("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos

                                                            if (ObjInventarioInfoActual != null)
                                                            {
                                                                //Calcula la cantidad disponible en el inventario
                                                                decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                                //actualiza la cantidad del detalle del pedido con la cantidad disponible.
                                                                if (ObjPedidosDetalleCliente.UpdateCantidad(ObjPedidoDetalle.Id, CantidadDisp))
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                                    okInventario = true;

                                                                    okProcess = true;

                                                                    //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                                    if (ObjInventario.UpdateCantidad("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                                        ContarAgotado = ContarAgotado + 1;
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + PedidoConOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //-------------------------------------------------------------------------------
                                                    //Actualiza el estado del pedido a PROCESADO.
                                                    if (okInventario)
                                                    {
                                                        okProcess = true;

                                                        if (UpdateProcesado(PedidoConOrden.Numero, true))
                                                        {
                                                            //Actualiza el estado del pedido a Procesado por que se proceso bien.
                                                            bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoConOrden.Numero, (int)EstadosPedidoEnum.Procesado);

                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. ", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            si_cumpleninventario = si_cumpleninventario + 1;
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL PEDIDO A PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            no_cumpleninventario = no_cumpleninventario + 1;
                                                        }


                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //Preguntar si no se pudo asignar ni 1 solo articulo del inventario, lo qeu siginifica que esta agotado 100%.
                                                    if (ContarAgotado == 0)
                                                    {
                                                        bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoConOrden.Numero, (int)EstadosPedidoEnum.Agotado);

                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR X AGOTADO 100% DEL INVENTARIO: EL PEDIDO HA SIDO RETENIDO POR AGOTADO INVENTARIO = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoConOrden.Numero + " NIT:" + PedidoConOrden.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }

                    //..............................................................................................................................
                    //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                    PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                    if (okProcess == false)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR INVENTARIO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA ASIGNAR INVENTARIO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //.......................................................................................
                        //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //.......................................................................................
                    }
                    else if (okProcess == true)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR INVENTARIO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //......................................................................
                        //Asigna los pedidos con reglas asignadas.                                               
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                            ObjPedidosClienteProcesadoInfo.TotalSiCumplenInventario = si_cumpleninventario;
                            ObjPedidosClienteProcesadoInfo.TotalNoCumplenInventario = ObjPedidosClienteProcesadoInfo.TotalPedidos - ObjPedidosClienteProcesadoInfo.TotalSiCumplenInventario;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //......................................................................
                    }
                    //..............................................................................................................................

                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE INVENTARIO DE LOS PEDIDOS CON REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));

                okProcess = true;
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //*return okProcess;
        }

        /// <summary>
        /// Realiza la asignacion de inventario a cada pedido.
        /// </summary>
        /// <returns></returns>
        public void AsignarInventarioPedidoEcuador()
        {
            //PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            //OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            //if (handler != null)
            //{
            //    ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
            //    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
            //    handler(ObjPedidosClienteProcesadoInfo);
            //}


            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.
            int si_cumpleninventario = 0;
            int no_cumpleninventario = 0;

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE ASIGNACIÓN DE INVENTARIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroup = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                {
                    //Se realiza la asignacion de pedidos para cada mailgroup.
                    foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se obtiene la campaña de la fecha actual.
                        Campana ObjCampana = new Campana("conexion");
                        CampanaInfo ObjCampanaInfo = new CampanaInfo();
                        //ObjCampanaInfo = ObjCampana.ListxGetDate();

                        if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                        {
                            ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                        }
                        else
                        {
                            ObjCampanaInfo = ObjCampana.ListxGetDate();
                        }

                        //Se valida que exista una campaña activa.
                        if (ObjCampanaInfo != null)
                        {

                            //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                            //1. Borrar tabla inventario para solo almacenar lo actual.
                            //2. Consultar saldos bodega.
                            //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                            //4. Consultar pedidos ordenados por orden de procesamiento.
                            //5. Actualizar el campo de cantidad  con respecto al inventario en el detalle del pedido.
                            //6. Restar cantidad actualizada a los saldos de inventario.

                            Inventario ObjInventario = new Inventario("conexion");


                            //----------------------------------------------------------
                            //Se valida si el procesamiento requiere reiniciar el inventario para calcular el nivel de servicio.
                            bool okDeleteInventario = true;

                            //if (ReiniciarInventario == true)
                            //{
                            //    if (!ObjInventario.DeleteAll())
                            //    {
                            //        okDeleteInventario = false;
                            //    }
                            //}
                            //----------------------------------------------------------

                            //Borrar la tabla de inventario para copiar el inventario actualizado.
                            //if (ObjInventario.DeleteAll())
                            if (okDeleteInventario)
                            {
                                //Se consulta el inventario del mes actual.
                                List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                                //ObjInventarioInfoList = ObjInventario.ListSaldosBodega();
                                ObjInventarioInfoList.Add(new InventarioInfo());

                                if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                                {
                                    //----------------------------------------------------------------------------------
                                    //si se requiere reiniciar el inventario se debe copiar de nuevo este en la tabla.
                                    //if (ReiniciarInventario == true)
                                    //{
                                    //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    //    //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                                    //    foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                                    //    {
                                    //        //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                    //        if (!ObjInventario.Insert(ItemInventario))
                                    //        {
                                    //            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    //        }
                                    //    }

                                    //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    //}

                                    Zona ObjZona = new Zona("conexion");
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                    //Se valida que existan zonas para el mailgroup actual.
                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            List<PedidosClienteInfo> ObjPedidosClienteConOrden = new List<PedidosClienteInfo>();
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosClienteConOrden = ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                            //Se valida si existen pedidos de la zona y la campaña actual.
                                            if (ObjPedidosClienteConOrden != null && ObjPedidosClienteConOrden.Count > 0)
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS CON REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                //Actualiza el estado a no procesado de los pedidos para volverlos a su estado inicial antes de rehacer el proceso.
                                                foreach (PedidosClienteInfo PedidoConOrdenNoProcess in ObjPedidosClienteConOrden)
                                                {
                                                    UpdateProcesado(PedidoConOrdenNoProcess.Numero, false);
                                                }

                                                int ContarAgotado = 0;

                                                //Se insertan los pedidos a la tabla temporal.
                                                foreach (PedidosClienteInfo PedidoConOrden in ObjPedidosClienteConOrden)
                                                {
                                                    bool okInventario = false;

                                                    ContarAgotado = 0;

                                                    //Consultar detalle del pedido.
                                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexId(PedidoConOrden.Numero);

                                                    //Se valida si existen detalles del pedido.
                                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                                    {
                                                        //Recorre el detalle del pedido.
                                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                            //////Consulta el inventario del detalle del pedido especifico.
                                                            ////InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                                            ////ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostos("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos

                                                            ////if (ObjInventarioInfoActual != null)
                                                            ////{
                                                            ////    //Calcula la cantidad disponible en el inventario
                                                            ////    decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                            ////    //actualiza la cantidad del detalle del pedido con la cantidad disponible.
                                                            ////    if (ObjPedidosDetalleCliente.UpdateCantidad(ObjPedidoDetalle.Id, CantidadDisp))
                                                            ////    {
                                                            ////        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            //actualiza la cantidad del nivel de servicio del pedido con la cantidad disponible.

                                                            if (ObjPedidosDetalleCliente.UpdateCantidad(ObjPedidoDetalle.Id, ObjPedidoDetalle.Cantidad))
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }

                                                            okInventario = true;

                                                            okProcess = true;

                                                            ////        //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                            ////        if (ObjInventario.UpdateCantidad("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                            ////        {
                                                            ////            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                            ////            ContarAgotado = ContarAgotado + 1;
                                                            ////        }
                                                            ////        else
                                                            ////        {
                                                            ////            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            ////        }
                                                            ////    }
                                                            ////    else
                                                            ////    {
                                                            ////        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            ////    }
                                                            ////}
                                                            ////else
                                                            ////{
                                                            ////    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            ////}


                                                        }
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + PedidoConOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //-------------------------------------------------------------------------------
                                                    //Actualiza el estado del pedido a PROCESADO.
                                                    if (okInventario)
                                                    {
                                                        okProcess = true;

                                                        if (UpdateProcesado(PedidoConOrden.Numero, true))
                                                        {
                                                            //Actualiza el estado del pedido a Procesado por que se proceso bien.
                                                            bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoConOrden.Numero, (int)EstadosPedidoEnum.Procesado);

                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. ", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            si_cumpleninventario = si_cumpleninventario + 1;
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL PEDIDO A PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            no_cumpleninventario = no_cumpleninventario + 1;
                                                        }


                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //Preguntar si no se pudo asignar ni 1 solo articulo del inventario, lo qeu siginifica que esta agotado 100%.
                                                    //if (ContarAgotado == 0)
                                                    //{
                                                    //    bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoConOrden.Numero, (int)EstadosPedidoEnum.Agotado);

                                                    //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR X AGOTADO 100% DEL INVENTARIO: EL PEDIDO HA SIDO RETENIDO POR AGOTADO INVENTARIO = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoConOrden.Numero + " NIT:" + PedidoConOrden.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                    //    //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                    //    okProcess = true;

                                                    //    //Contador de pedidos
                                                    //    consecutivo = consecutivo + 1;
                                                    //}
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }

                    //..............................................................................................................................
                    //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                    PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                    if (okProcess == false)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR INVENTARIO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA ASIGNAR INVENTARIO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //.......................................................................................
                        //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //.......................................................................................
                    }
                    else if (okProcess == true)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR INVENTARIO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //......................................................................
                        //Asigna los pedidos con reglas asignadas.                                               
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                            ObjPedidosClienteProcesadoInfo.TotalSiCumplenInventario = si_cumpleninventario;
                            ObjPedidosClienteProcesadoInfo.TotalNoCumplenInventario = ObjPedidosClienteProcesadoInfo.TotalPedidos - ObjPedidosClienteProcesadoInfo.TotalSiCumplenInventario;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //......................................................................
                    }
                    //..............................................................................................................................

                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE INVENTARIO DE LOS PEDIDOS CON REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));

                okProcess = true;
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Asignar el nivel de servicio del pedido por Cantidad.
        /// </summary>
        /// <returns></returns>
        public void AsignarNivelServicioCantidad()
        {
            bool okProcess = false;

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE NIVEL DE SERVICIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroup = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                {
                    //Se realiza la asignacion de pedidos para cada mailgroup.
                    foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se obtiene la campaña de la fecha actual.
                        Campana ObjCampana = new Campana("conexion");
                        CampanaInfo ObjCampanaInfo = new CampanaInfo();
                        //ObjCampanaInfo = ObjCampana.ListxGetDate();

                        if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                        {
                            ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                        }
                        else
                        {
                            ObjCampanaInfo = ObjCampana.ListxGetDate();
                        }

                        //Se valida que exista una campaña activa.
                        if (ObjCampanaInfo != null)
                        {

                            //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                            //1. Borrar tabla inventario para solo almacenar lo actual.
                            //2. Consultar saldos bodega.
                            //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                            //4. Consultar pedidos ordenados por orden de procesamiento.
                            //5. Actualizar el campo de cantidad pedida con respecto al inventario en el detalle del pedido.
                            //6. Restar cantidad actualizada a los saldos de inventario.

                            Inventario ObjInventario = new Inventario("conexion");


                            //----------------------------------------------------------
                            //Se valida si el procesamiento requiere reiniciar el inventario para calcular el nivel de servicio.
                            bool okDeleteInventario = true;

                            if (ReiniciarInventario == true)
                            {
                                if (!ObjInventario.DeleteAllNivelServicio())
                                {
                                    okDeleteInventario = false;
                                }
                            }
                            //----------------------------------------------------------

                            //Borrar la tabla de inventario para copiar el inventario actualizado.
                            //if (ObjInventario.DeleteAll())
                            if (okDeleteInventario)
                            {
                                //Se consulta el inventario del mes actual.
                                List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                                ObjInventarioInfoList = ObjInventario.ListSaldosBodega();

                                if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                                {
                                    //----------------------------------------------------------------------------------
                                    //si se requiere reiniciar el inventario se debe copiar de nuevo este en la tabla.
                                    if (ReiniciarInventario == true)
                                    {

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                                        foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                                        {
                                            //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                            if (!ObjInventario.InsertNivelServicio(ItemInventario))
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                    //----------------------------------------------------------------------------------

                                    Zona ObjZona = new Zona("conexion");
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                    //Se valida que existan zonas para el mailgroup actual.
                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            List<PedidosClienteInfo> ObjPedidosCliente = new List<PedidosClienteInfo>();
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosCliente = ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                            //Se valida si existen pedidos de la zona y la campaña actual.
                                            if (ObjPedidosCliente != null && ObjPedidosCliente.Count > 0)
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                //99999999999999999999999999999999999
                                                int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.                                               
                                                int si_nivelservicio = 0; //almacena la cantidad que si aplicaron el nivel de servicio.
                                                int no_nivelservicio = 0; //amacena la cantidad que no aplicaron el nivel de servicio.

                                                //Se insertan los pedidos a la tabla temporal.
                                                foreach (PedidosClienteInfo Pedido in ObjPedidosCliente)
                                                {
                                                    bool okInventario = false;

                                                    //Consultar detalle del pedido.
                                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexId(Pedido.Numero);

                                                    //Se valida si existen detalles del pedido.
                                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                                    {
                                                        //Recorre el detalle del pedido.
                                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                            //Consulta el inventario del detalle del pedido especifico.
                                                            InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                                            ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostosNivelServicio("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos
                                                            //ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostosNivelServicio("002", "TM118865", "P008-14618"); //Lote = CCostos

                                                            if (ObjInventarioInfoActual != null)
                                                            {
                                                                //Calcula la cantidad disponible en el inventario
                                                                decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                                //actualiza la cantidad del nivel de servicio del pedido con la cantidad disponible.
                                                                if (ObjPedidosDetalleCliente.UpdateCantidadNivelServicio(ObjPedidoDetalle.Id, CantidadDisp))
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                                    okInventario = true;

                                                                    //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                                    if (ObjInventario.UpdateCantidadNivelServicio("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //-------------------------------------------------------------------------------
                                                    //Actualiza el nivel del servicio y estado de nivel de servicio.
                                                    if (okInventario)
                                                    {
                                                        //Se obtiene el nivel de servicio esperado para el dia.
                                                        Application.Enterprise.Business.NivelServicio ObjNivelServicio = new Application.Enterprise.Business.NivelServicio("conexion");
                                                        Application.Enterprise.CommonObjects.NivelServicioInfo ObjNivelServicioInfo = new Application.Enterprise.CommonObjects.NivelServicioInfo();

                                                        ObjNivelServicioInfo = ObjNivelServicio.ListxFecha();

                                                        decimal NivelServicioEstimado = 100;

                                                        //Si no hay un nivel de servicio para el dia se deja el 100%
                                                        if (ObjNivelServicioInfo != null)
                                                        {
                                                            NivelServicioEstimado = ObjNivelServicioInfo.NivelEstimado;
                                                        }

                                                        //Consultar detalle del pedido para calcular el nivel de servicio.
                                                        PedidosDetalleCliente ObjPedidosDetalleNivelS = new PedidosDetalleCliente("conexion");
                                                        List<PedidosDetalleClienteInfo> ObjPedidosDetalleNivelSInfoList = new List<PedidosDetalleClienteInfo>();
                                                        ObjPedidosDetalleNivelSInfoList = ObjPedidosDetalleNivelS.ListPedidoDetallexId(Pedido.Numero);

                                                        decimal CantidadTotalPedidoRequerida = 0;
                                                        decimal CantidadTotalPedidoExistente = 0;

                                                        if (ObjPedidosDetalleNivelSInfoList != null && ObjPedidosDetalleNivelSInfoList.Count > 0)
                                                        {
                                                            //recorre el detalle del pedido y se suma la cantidad total requerida y la real existente.
                                                            foreach (PedidosDetalleClienteInfo PedidoDetalleTotal in ObjPedidosDetalleNivelSInfoList)
                                                            {
                                                                //CantidadTotalPedidoRequerida = cantidad total que se pidio por el cliente.
                                                                CantidadTotalPedidoRequerida = CantidadTotalPedidoRequerida + PedidoDetalleTotal.Cantidad;
                                                                //CantidadTotalPedidoExistente = cantidad que existe para mirar el nivel de servicio asignada dependiendo el inventario existente.
                                                                CantidadTotalPedidoExistente = CantidadTotalPedidoExistente + PedidoDetalleTotal.CantidadNivelServicio;
                                                            }
                                                        }

                                                        //Se realiza la operacion para saber qeu porcentaje se obtuvo realmente.
                                                        decimal NivelServicioReal = (CantidadTotalPedidoExistente * 100) / CantidadTotalPedidoRequerida;

                                                        //Se realiza la operacion para saber si la cantidad real supera el nivel de servicio esperado.
                                                        if (NivelServicioReal >= NivelServicioEstimado)
                                                        {
                                                            //true si cumple con el nivel de servicio.
                                                            if (UpdateNivelServicio(Pedido.Numero, true, NivelServicioEstimado, NivelServicioReal, "Por Cantidad"))
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CUMPLIO EL NIVEL DE SERVICIO, SE ACTUALIZO ESTADO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                si_nivelservicio = si_nivelservicio + 1;
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //si no cumple con el nivel de servicio el estado es false.
                                                            if (UpdateNivelServicio(Pedido.Numero, false, NivelServicioEstimado, NivelServicioReal, "Por Cantidad"))
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE CUMPLIO NIVEL DE SERVICIO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                        }

                                                        //99999999999999999999999999999999999999999999999999999999999999999999

                                                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                                                        if (handler != null)
                                                        {
                                                            PedidoTotales.Numero = Pedido.Numero;
                                                            PedidoTotales.TotalPedidos = ObjPedidosCliente.Count;
                                                            PedidoTotales.Consecutivo = PedidoTotales.Consecutivo + 1;
                                                            consecutivo = consecutivo + 1;
                                                            if (ObjPedidosCliente.Count == consecutivo)
                                                            {
                                                                PedidoTotales.TotalSiCumplenNivelServicio = si_nivelservicio;
                                                                PedidoTotales.TotalNoCumplenNivelServicio = no_nivelservicio;
                                                                PedidoTotales.TerminoProcess = true;
                                                            }
                                                            handler(PedidoTotales);

                                                        }
                                                        //99999999999999999999999999999999999999999999999999999999999999999999
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                }

                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO NIVEL DE SERVICIO POR CANTIDAD OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                                                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                                                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }

                okProcess = true;
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //* return okProcess;
        }

        /// <summary>
        /// Asignar el nivel de servicio del pedido por valor o costo.
        /// </summary>
        /// <returns></returns>
        public void AsignarNivelServicioValorCosto()
        {
            bool okProcess = false;

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE NIVEL DE SERVICIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroup = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                {
                    //Se realiza la asignacion de pedidos para cada mailgroup.
                    foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se obtiene la campaña de la fecha actual.
                        Campana ObjCampana = new Campana("conexion");
                        CampanaInfo ObjCampanaInfo = new CampanaInfo();
                        //ObjCampanaInfo = ObjCampana.ListxGetDate();

                        if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                        {
                            ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                        }
                        else
                        {
                            ObjCampanaInfo = ObjCampana.ListxGetDate();
                        }

                        //Se valida que exista una campaña activa.
                        if (ObjCampanaInfo != null)
                        {

                            //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                            //1. Borrar tabla inventario para solo almacenar lo actual.
                            //2. Consultar saldos bodega.
                            //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                            //4. Consultar pedidos ordenados por orden de procesamiento.
                            //5. Actualizar el campo de cantidad pedida con respecto al inventario en el detalle del pedido.
                            //6. Restar cantidad actualizada a los saldos de inventario.

                            Inventario ObjInventario = new Inventario("conexion");

                            //----------------------------------------------------------
                            //Se valida si el procesamiento requiere reiniciar el inventario para calcular el nivel de servicio.
                            bool okDeleteInventario = true;

                            if (ReiniciarInventario == true)
                            {
                                if (!ObjInventario.DeleteAllNivelServicio())
                                {
                                    okDeleteInventario = false;
                                }
                            }
                            //----------------------------------------------------------

                            //Borrar la tabla de inventario para copiar el inventario actualizado.
                            //if (ObjInventario.DeleteAll())
                            if (okDeleteInventario)
                            {
                                //Se consulta el inventario del mes actual.
                                List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                                ObjInventarioInfoList = ObjInventario.ListSaldosBodega();

                                if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                                {
                                    //----------------------------------------------------------------------------------
                                    //si se requiere reiniciar el inventario se debe copiar de nuevo este en la tabla.
                                    if (ReiniciarInventario == true)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                                        foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                                        {
                                            //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                            if (!ObjInventario.InsertNivelServicio(ItemInventario))
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                    //----------------------------------------------------------------------------------


                                    Zona ObjZona = new Zona("conexion");
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                    //Se valida que existan zonas para el mailgroup actual.
                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            List<PedidosClienteInfo> ObjPedidosCliente = new List<PedidosClienteInfo>();
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosCliente = ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                            //Se valida si existen pedidos de la zona y la campaña actual.
                                            if (ObjPedidosCliente != null && ObjPedidosCliente.Count > 0)
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                //22222222222222222222222222222222222222
                                                int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.                                               
                                                int si_nivelservicio = 0; //almacena la cantidad que si aplicaron el nivel de servicio.
                                                int no_nivelservicio = 0; //amacena la cantidad que no aplicaron el nivel de servicio.

                                                //Se insertan los pedidos a la tabla temporal.
                                                foreach (PedidosClienteInfo Pedido in ObjPedidosCliente)
                                                {
                                                    bool okInventario = false;

                                                    //Consultar detalle del pedido.
                                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexId(Pedido.Numero);

                                                    //Se valida si existen detalles del pedido.
                                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                                    {
                                                        //Recorre el detalle del pedido.
                                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                            //Consulta el inventario del detalle del pedido especifico.
                                                            InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                                            ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostosNivelServicio("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos

                                                            if (ObjInventarioInfoActual != null)
                                                            {
                                                                //Calcula la cantidad disponible en el inventario
                                                                decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                                //actualiza la cantidad del nivel de servicio del pedido con la cantidad disponible.
                                                                if (ObjPedidosDetalleCliente.UpdateCantidadNivelServicio(ObjPedidoDetalle.Id, CantidadDisp))
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                                    okInventario = true;

                                                                    //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                                    if (ObjInventario.UpdateCantidadNivelServicio("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //-------------------------------------------------------------------------------
                                                    //Actualiza el nivel del servicio y estado de nivel de servicio.
                                                    if (okInventario)
                                                    {
                                                        //********************************************************************************************
                                                        //Se obtiene el nivel de servicio esperado para el dia.
                                                        Application.Enterprise.Business.NivelServicio ObjNivelServicio = new Application.Enterprise.Business.NivelServicio("conexion");
                                                        Application.Enterprise.CommonObjects.NivelServicioInfo ObjNivelServicioInfo = new Application.Enterprise.CommonObjects.NivelServicioInfo();

                                                        ObjNivelServicioInfo = ObjNivelServicio.ListxFecha();

                                                        decimal NivelServicioEstimado = 100;

                                                        //Si no hay un nivel de servicio para el dia se consulta el requerido por los parametros del sistema, sino hay en
                                                        //los parametros se asume el 100%.
                                                        if (ObjNivelServicioInfo != null)
                                                        {
                                                            NivelServicioEstimado = ObjNivelServicioInfo.NivelEstimado;
                                                        }
                                                        else
                                                        {
                                                            ParametrosInfo objParametrosInfo = new ParametrosInfo();
                                                            Parametros objParametros = new Parametros("conexion");

                                                            //Se obtiene el parametro de nivel de servicio.
                                                            objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.NivelServicio);

                                                            if (Convert.ToDecimal(objParametrosInfo.Valor) > 0)
                                                            {
                                                                NivelServicioEstimado = Convert.ToDecimal(objParametrosInfo.Valor);
                                                            }
                                                            else
                                                            {
                                                                NivelServicioEstimado = 100;
                                                            }
                                                        }

                                                        //********************************************************************************************


                                                        //Consultar detalle del pedido para calcular el nivel de servicio.
                                                        PedidosDetalleCliente ObjPedidosDetalleNivelS = new PedidosDetalleCliente("conexion");
                                                        List<PedidosDetalleClienteInfo> ObjPedidosDetalleNivelSInfoList = new List<PedidosDetalleClienteInfo>();
                                                        ObjPedidosDetalleNivelSInfoList = ObjPedidosDetalleNivelS.ListPedidoDetallexId(Pedido.Numero);

                                                        decimal CantidadTotalPedidoRequerida = 0;
                                                        decimal CantidadTotalPedidoExistente = 0;

                                                        decimal ValorTotalRequerido = 0;
                                                        decimal ValorTotalExistente = 0;

                                                        if (ObjPedidosDetalleNivelSInfoList != null && ObjPedidosDetalleNivelSInfoList.Count > 0)
                                                        {
                                                            //recorre el detalle del pedido y se suma la cantidad total requerida y la real existente.
                                                            foreach (PedidosDetalleClienteInfo PedidoDetalleTotal in ObjPedidosDetalleNivelSInfoList)
                                                            {
                                                                //CantidadTotalPedidoRequerida = cantidad total que se pidio por el cliente.
                                                                CantidadTotalPedidoRequerida = CantidadTotalPedidoRequerida + PedidoDetalleTotal.Cantidad;
                                                                //ValorTotalRequerido = valor total que se pidio por el cliente.
                                                                ValorTotalRequerido = ValorTotalRequerido + (PedidoDetalleTotal.Valor * PedidoDetalleTotal.Cantidad);

                                                                //CantidadTotalPedidoExistente = cantidad que existe para mirar el nivel de servicio asignada dependiendo el inventario existente.
                                                                CantidadTotalPedidoExistente = CantidadTotalPedidoExistente + PedidoDetalleTotal.CantidadNivelServicio;
                                                                //ValorTotalExistente = valor que existe realmente para mirar el nivel de servicio asignada dependiendo el inventario existente.
                                                                ValorTotalExistente = ValorTotalExistente + (PedidoDetalleTotal.Valor * PedidoDetalleTotal.CantidadNivelServicio);
                                                            }
                                                        }

                                                        //Se realiza la operacion para saber qeu porcentaje se obtuvo realmente.
                                                        decimal NivelServicioReal = (ValorTotalExistente * 100) / ValorTotalRequerido;

                                                        //Se realiza la operacion para saber si la cantidad real supera el nivel de servicio esperado.
                                                        if (NivelServicioReal >= NivelServicioEstimado)
                                                        {
                                                            //true si cumple con el nivel de servicio.
                                                            if (UpdateNivelServicio(Pedido.Numero, true, NivelServicioEstimado, NivelServicioReal, "Por Valor"))
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CUMPLIO EL NIVEL DE SERVICIO, SE ACTUALIZO ESTADO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                si_nivelservicio = si_nivelservicio + 1;
                                                            }
                                                            else
                                                            {
                                                                bool okTrasnEstadoPed = this.UpdateEstadoPedido(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //si no cumple con el nivel de servicio el estado es false.
                                                            if (UpdateNivelServicio(Pedido.Numero, false, NivelServicioEstimado, NivelServicioReal, "Por Valor"))
                                                            {
                                                                bool okTrasnEstadoPed = this.UpdateEstadoPedido(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE CUMPLIO NIVEL DE SERVICIO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                        }

                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;
                                                    }
                                                    else
                                                    {

                                                        //SI ENTRO AQUI ES POR QUE NO EXISTEN NISIQUIERA UNA UNIDAD DE LOS ARTICULOS REQUERIDOS EN EL DETALLE DEL PEDIDO.

                                                        //SE BLOQUEA POR NIVEL DE SERVICIO.
                                                        bool okTrasnEstadoPed = this.UpdateEstadoPedido(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);

                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: EL PEDIDO HA SIDO RETENIDO POR VALOR = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", Pedido.Numero + " NIT:" + Pedido.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;

                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                }

                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE INVENTARIO DE LOS PEDIDOS CON REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                                                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                                                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }

                    //..............................................................................................................................
                    //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                    PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                    if (okProcess == false)
                    {

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X NIVEL DE SERVICIO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //.......................................................................................
                        //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //.......................................................................................
                    }
                    else if (okProcess == true)
                    {

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //..............................................................................
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            //ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                            //ObjPedidosClienteProcesadoInfo.TotalSiCumplenNivelServicio = si_nivelservicio;
                            //ObjPedidosClienteProcesadoInfo.TotalNoCumplenNivelServicio = no_nivelservicio;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //..............................................................................

                    }

                    //..............................................................................................................................


                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }

                okProcess = true;

                //se debe borrar la tabla temporal para que no se bloqueé el proceso siguiente.
                DeleteTemporal();
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR VALOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //* return okProcess;
        }


        /// <summary>
        /// Asignar el nivel de servicio del pedido por valor o costo.
        /// </summary>
        /// <returns></returns>
        public void AsignarNivelServicioValorCostoEcuador()
        {
            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }

        /// <summary>
        /// Construye la cadena del tipo de query para los premios (Simple, Niveles).
        /// </summary>
        /// <param name="TipoQueryAnterior"></param>
        /// <param name="TipoQueryNuevo"></param>
        /// <returns></returns>
        private string ContruirTipoQuery(string TipoQueryAnterior, string TipoQueryNuevo)
        {
            string TipoQuery = "";

            if (TipoQueryAnterior == "")
            {
                TipoQuery = TipoQueryNuevo;
            }
            else
            {
                TipoQuery = TipoQueryAnterior + "," + TipoQueryNuevo;
            }

            return TipoQuery;
        }

        /// <summary>
        /// Realiza el paso de los clientes capturados por SVDN a la bd de NIVI (tabla clientes) y MKT (tabla clientes).
        /// </summary>
        public void MigrarClientesNiviMkt()
        {
            bool okProcess = false;

            try
            {

                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS MIGRAR CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE MIGRACION DE CLIENTES. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;


                #region "MIGRAR LOS CLIENTES NUEVOS A MKT Y A NIVI"

                //-----------------------------------------------------------------------------------------------------
                //MIGRAR LOS CLIENTES REGISTRADOS POR SVDN A PRODUCCION.
                //1. Obtener los clientes de la tabla de SVDN.
                //2. Copiar los clientes en la bd de MKT
                //3. Copiar los clientes en la tabla de clientes de NIVI.

                List<ClienteInfo> objClienteInfoList = new List<ClienteInfo>();
                Cliente objCliente = new Cliente("conexion");

                //Se obtienen los clientes de SVDN nuevos
                objClienteInfoList = objCliente.ListClientesSVDN();

                if (objClienteInfoList != null && objClienteInfoList.Count > 0)
                {
                    int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

                    foreach (ClienteInfo objClienteInfo in objClienteInfoList)
                    {
                        //-------------------------------------------------------------------------
                        //NOTA: SE COMENTO CUANDO SE ELIMINO LA TABLA DE SVDN_CLIENTES
                        //Verificar que no exista el cliente en nivi, sino existe se crea.
                        //ClienteInfo objClienteNiviCrearInfo = new ClienteInfo();
                        //objClienteNiviCrearInfo = objCliente.ListClienteNivixNit(objClienteInfo.Nit);

                        //if (objClienteNiviCrearInfo == null)
                        //{
                        //    //Se guarda el cliente en la tabla de nivi.
                        //    bool okTransNivi = objCliente.InsertClienteBDNivi(objClienteInfo);
                        //}
                        //-------------------------------------------------------------------------

                        ////Verificar que no exista el cliente en mkt, sino existe se crea.
                        //ClienteInfo objClienteMktCrearInfo = new ClienteInfo();
                        //objClienteMktCrearInfo = objCliente.ListClienteMktxNit(objClienteInfo.Nit);

                        //if (objClienteMktCrearInfo == null)
                        //{
                        //    //Se guarda el cliente en la tabla de MKT.
                        //    bool okTransMkt = objCliente.InsertClienteBDMkt(objClienteInfo);
                        //}

                        ////Se actualiza el estado del cliente EnProduccion = True.
                        //bool okTransUpdate = objCliente.UpdateClienteEnProduccion(objClienteInfo.Nit, true);

                        //System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS MIGRAR CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "Se migro cliente:" + objClienteInfo.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //........................................................................
                        OnClientesProcesamientoEventHandler handler = OnClienteEvent;
                        if (handler != null)
                        {
                            objClienteInfo.TotalClientes = objClienteInfoList.Count;

                            consecutivo = consecutivo + 1;
                            if (objClienteInfoList.Count == consecutivo)
                            {

                                objClienteInfo.TerminoProcess = true;
                            }
                            handler(objClienteInfo);

                        }
                        //........................................................................
                    }

                    okProcess = true;
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS MIGRAR CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO HAY CLIENTES NUEVOS PARA MIGRAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));


                    ClienteInfo objClienteInfo = new ClienteInfo();

                    OnClientesProcesamientoEventHandler handler = OnClienteEvent;
                    if (handler != null)
                    {
                        objClienteInfo.TotalClientes = 1;
                        objClienteInfo.TerminoProcess = true;
                        handler(objClienteInfo);
                    }
                }

                #endregion


                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS MIGRAR CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE MIGRACION DE CLIENTES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS MIGRAR CLIENTES: PROCESO DE MIGRACION DE CLIENTES TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));

            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI ERROR PEDIDOS MIGRAR CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Realiza el paso de los clientes capturados por SVDN a la bd de NIVI (tabla clientes) y MKT (tabla clientes).
        /// </summary>
        public void MigrarClientesNiviMktEcuador()
        {
            ClienteInfo objClienteInfo = new ClienteInfo();

            OnClientesProcesamientoEventHandler handler = OnClienteEvent;
            if (handler != null)
            {
                objClienteInfo.TotalClientes = 1;
                objClienteInfo.TerminoProcess = true;
                handler(objClienteInfo);
            }

        }


        /// <summary>
        /// Eliminar este metodo y habilitar el de abajo para que funcione el
        /// asignar premios pedido.
        /// </summary>
        public void AsignarPremiosPedido()
        {

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }

        }

        /// <summary>
        /// Realiza a asignacion de premios a los pedidos.
        /// </summary>
        public void AsignarPremiosPedidoAGREGARESTESISEREQUIERE()
        {
            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {

                //Se limpian los pedidos que quedan despues del proceso que no pudieron asignar premios.
                DeletePremiosTemporal();

                //validar si ya existe un pedido procesando
                List<PedidosClienteInfo> list_temp = new List<PedidosClienteInfo>();

                //Consulta si hay pedidos con premios en proceso en la tabla temporal
                list_temp = ListTablaPremiosTemporal();

                //Si no hay registros en la temporal se puede hacer el proceso. sino indica que hay pedidos en proceso.
                if (list_temp.Count == 0 || list_temp == null)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE ASIGNACIÓN DE PREMIOS. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Captura el tiempo de inicio
                    _startAsignacionTime = DateTime.Now;

                    #region "IMPORTAR INVENTARIO MKT"

                    InventarioMkt objInventarioMkt = new InventarioMkt("conexion");

                    //Eliminar el inventario de MKT existente.
                    objInventarioMkt.DeleteAll();
                    //Importar el inventario de mkt a las tablas de SVDN.
                    objInventarioMkt.ImportInventarioMKT();

                    #endregion

                    //---------------------------------------------------------------------------------------------------------------------------------------
                    //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, Y SE GUARDAN EN LA TABLA TEMPORAL PARA SEGUIR CON LA ASIGNACIÓN DE REGLAS.
                    //1. Se valida que no exista otro proceso de pedidos activo.
                    //2. Se preguntan si existen mailgroup para el dia actual.
                    //3. Se obtiene la campaña y zona del mailgroup actual.
                    //4. Se listan los pedidos de la zona y campaña actual para pasar a la asignacion de reglas.

                    //Se obtienen los mailgroup por fecha actual.
                    MailGroup ObjMailGroup = new MailGroup("conexion");
                    List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                    ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                    //se pregunta si existen Mailgroup para ese dia.
                    if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                    {
                        //Se realiza la asignacion de pedidos para cada mailgroup.
                        foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO PREMIOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se obtiene la campaña de la fecha actual.
                            Campana ObjCampana = new Campana("conexion");
                            CampanaInfo ObjCampanaInfo = new CampanaInfo();
                            //ObjCampanaInfo = ObjCampana.ListxGetDate();

                            if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                            {
                                ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                            }
                            else
                            {
                                ObjCampanaInfo = ObjCampana.ListxGetDate();
                            }

                            //Se valida que exista una campaña activa.
                            if (ObjCampanaInfo != null)
                            {
                                //Se obtienen las zonas de un mailgroup por fecha actual.
                                Zona ObjZona = new Zona("conexion");
                                List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                //Se valida que existan zonas para el mailgroup actual.
                                if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                {
                                    //Se debe borra la tabla temporal con los pedidos con premios de la zona y campaña actual.
                                    if (!DeletePremiosTemporal())
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI  PREMIOS Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ELIMINAR TODOS LOS REGISTROS DE LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    //----------------------------------------------------------------------------------------------------------------------
                                    //AQUI COMIENZA EL PROCESO DE APLICACIÓN DE REGLAS A LOS PEDIDOS DE UNA ZONA Y CAMPAÑA DE LA FECHA ACTUAL POR MAILGROUP
                                    //1. Se realiza e select de los pedidos por mailgroup (zona y campaña) y se copia a la tabla de pedidos temp.
                                    //2. Se realiza la asignacion de reglas a los pedidos del mailgroup.
                                    //3. Se obtiene un conjunto de pedidos listados por reglas y se actualiza el campo orden en la tabla de pedidos.
                                    //4. Cuando se procesa el pedido se organizan por el campo orden y se actualiza el campo Procesado a 1.

                                    PremiosCondiciones ObjReglasPremios = new PremiosCondiciones("conexion");
                                    List<PremiosCondicionesInfo> ObjReglasPremiosInfo = new List<PremiosCondicionesInfo>();

                                    //Obtiene as reglas de premios activas y en orden para los pedidos.
                                    ObjReglasPremiosInfo = ObjReglasPremios.ListxReglasPremios();

                                    List<PedidosClienteInfo> ObjPedidosClienteInfoReglas = new List<PedidosClienteInfo>();

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE REGLAS DE PREMIOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    int IdPremio = 0;
                                    int IdArticuloPremio = 0;
                                    string TipoQuery = "";



                                    //Se hace el ciclo de asignacion de reglas de premios a los pedidos.
                                    for (int i = 0; i < ObjReglasPremiosInfo.Count; i++)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TOTAL REGLAS PREMIOS:" + ObjReglasPremiosInfo.Count, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        TipoQuery = ObjReglasPremiosInfo[i].NombreConcepto;

                                        ObjReglasPremiosInfo[i].Query = ObjReglasPremiosInfo[i].Query.ToUpper();

                                        //Se obtiene el id del premio para comparar los puntos de los niveles.
                                        //NOTA: ESTE CASO SOLO SIRVE CUANDO EXISTE SOLO UN PREMIO CON NIVELES, POR QUE SI HAY MAS DE UNO SOLO QUEDA ASIGNADO EL IDPREMIO DEL ULTIMO.
                                        if (ObjReglasPremiosInfo[i].NombreConcepto == "NIVELES")
                                        {
                                            IdPremio = ObjReglasPremiosInfo[i].IdPremio;
                                        }

                                        //EJECUTAR LAS REGLAS DE LOS QUERY'S CONSTRUIDOS
                                        //EJECUTAR LAS REGLAS DE LOS QUERY'S CONSTRUIDOS
                                        //Aqui se envia a ejecutar las regla de premios para los pedidos.
                                        ObjPedidosClienteInfoReglas = ListxReglaPremios(ObjReglasPremiosInfo[i].Query);

                                        //Si se obtuvieron pedidos y se aplicaron reglas.
                                        if (ObjPedidosClienteInfoReglas != null && ObjPedidosClienteInfoReglas.Count > 0)
                                        {
                                            int OrdenTemp = 0;

                                            List<PremiosCondicionesInfo> objPremiosCondicionesInfoList = new List<PremiosCondicionesInfo>();
                                            PremiosCondiciones objPremiosCondiciones = new PremiosCondiciones("conexion");
                                            //Se obtiene el id del articulo por el id de condicion. Se asigna a el pedido temporal para despues crear el detalle del premio.
                                            objPremiosCondicionesInfoList = objPremiosCondiciones.ListxIdArticulo(ObjReglasPremiosInfo[i].Id);

                                            if (objPremiosCondicionesInfoList != null && objPremiosCondicionesInfoList.Count > 0)
                                            {
                                                //si devuelve mas de un articulo es por que no es un query simple sino compuesto, ahi se
                                                //descarta el manejo del idarticulo.
                                                IdArticuloPremio = objPremiosCondicionesInfoList[0].IdArticulo;
                                            }

                                            //Se insertan los pedidos a la tabla temporal que corresponden a la regla aplicada.
                                            foreach (PedidosClienteInfo PedidoItem in ObjPedidosClienteInfoReglas)
                                            {
                                                PedidoItem.TipoQuery = TipoQuery;
                                                PedidoItem.IdArticuloPremio = IdArticuloPremio;

                                                OrdenTemp = OrdenTemp + 1;
                                                PedidoItem.Orden = OrdenTemp;

                                                //se consulta si el pedido ya existe en la tabla temporal
                                                PedidosClienteInfo ObjPedidosClienteInfoVerificar = ListTablaPremiosTemporalxNumero(PedidoItem.Numero);

                                                //si no existe se crea.
                                                if (ObjPedidosClienteInfoVerificar == null)
                                                {
                                                    InsertxReglaxPremio(PedidoItem);
                                                }
                                                else
                                                {
                                                    UpdateTipoQuery(PedidoItem.Numero, ContruirTipoQuery(PedidoItem.TipoQuery, ObjPedidosClienteInfoVerificar.TipoQuery));
                                                }
                                            }
                                        }
                                    }

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE REGLAS PREMIOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //------------------------------------------------------------------------------------------------------
                                    //Proceso de filtrado de puntos y asignacion de inventario de premios
                                    //1. SE OBTIENEN LOS CLIENTES CON LOS PUNTOS TOTALES
                                    //2. SE OBTIENEN LAS REGLAS DE LOS PUNTOS ASIGNADAS A LOS NIVELES.
                                    //3. SE VALIDA QUE NO EXISTAN PEDIDOS REPETIDOS PARA ASIGNAR PREMIOS.
                                    //----------------------------------------------------------------
                                    //aqui asignar el pedido como premio y borrar los puntos del cliente.
                                    //asignar el articulo al detalle del pedido como un item adicional
                                    //restar en el inventario de premios el articulo.
                                    //sino hay articulo se debe bloquear el pedido (estado = retenido premios).                                    
                                    //borrar registro de la tabla temporal



                                    #region "ASIGNAR EL INVENTARIO A LOS PEDIDOS Y CREAR DETALLE DE PEDIDO EN MKT"

                                    //------------------------------------------------------------------------------------------------
                                    //EN ESTE PUNTO SE PASARON LOS QUERY'S DE REGLAS A LOS PEDIDOS QUE GANARON PREMIOS.
                                    //SE SINCRONIZARON LOS CLIENTES EN LAS BASES DE DATOS DE MKT Y DE NIVI.
                                    //SE OBTUVO EL INVENTARIO DE PREMIOS DE MKT.
                                    //1. Obtener pedidos de la lista temporal
                                    //2. Verificar que el tipo de query (niveles o simple).
                                    //3. consultar el tipo de articulo que le corresponde al pedido.
                                    //4. realizar la resta del articulo del inventario de mkt.
                                    //5. generar detalle del pedido para guardar en la tabla de pedidos detalle de mkt.
                                    //6. actualizar el eestado del pedido en la BD de Nivi a = Normal Procesado.
                                    //7. Eliminar pedido de la tabla temporal.


                                    List<PedidosxPremioInfo> ListaActualizarBorrarPedidos = new List<PedidosxPremioInfo>();


                                    List<PedidosClienteInfo> objPedidosPremiosTempReglasList = new List<PedidosClienteInfo>();
                                    //Se obtienen los pedidos de premios de la lista temporal para asignarles los articulos del inventario MKT.

                                    objPedidosPremiosTempReglasList = this.ListTablaPremiosTemporal();

                                    if (objPedidosPremiosTempReglasList != null && objPedidosPremiosTempReglasList.Count > 0)
                                    {
                                        bool VerificarPedNiveles = false;

                                        #region "ASIGNACION DE PREMIOS A PEDIDOS SIN NIVELES"

                                        //............................................................................................................
                                        //............................................................................................................
                                        //LOGICA DE NEGOCIO PARA LAS REGLAS SIMPLES.
                                        foreach (PedidosClienteInfo objPedidosPremiosTempRegla in objPedidosPremiosTempReglasList)
                                        {
                                            //Se pregunta si el query del pedido no es de niveles, de lo contrario se debe hacer el proceso de niveles y puntos.
                                            if (objPedidosPremiosTempRegla.TipoQuery != "NIVELES")
                                            {
                                                PremiosArticulosInfo objPremiosArticulosInfoList = new PremiosArticulosInfo();
                                                PremiosArticulos objPremiosArticulos = new PremiosArticulos("conexion");
                                                //traer el detalle del articulo por ID.
                                                objPremiosArticulosInfoList = objPremiosArticulos.ListxId(objPedidosPremiosTempRegla.IdArticuloPremio);

                                                //List<InventarioMktInfo> objInventarioMktInfoList = new List<InventarioMktInfo>();
                                                //objInventarioMktInfoList = objInventarioMkt.ListInventarioDisponible();

                                                InventarioMktInfo objInventarioMktInfo = new InventarioMktInfo();

                                                //Obtener el inventario de MKT.
                                                objInventarioMktInfo = objInventarioMkt.ListxBodegaxRefxCcostos(objPremiosArticulosInfoList.Bodega, objPremiosArticulosInfoList.Referencia, objPremiosArticulosInfoList.Ccostos);

                                                if (objInventarioMktInfo != null)
                                                {
                                                    //Restar la cantidad del articulo del premio con el inventario de mkt.
                                                    int RestaInventario = Convert.ToInt32(objInventarioMktInfo.Saldo) - objPremiosArticulosInfoList.Cantidad;

                                                    //si el inventario es > 0 es por que  existe inventario.
                                                    if (RestaInventario > 0)
                                                    {
                                                        //se actualiza la cantidad del inventario que queda despues de asignar.
                                                        bool okTrans = objInventarioMkt.UpdateCantidad(objPremiosArticulosInfoList.Bodega, objPremiosArticulosInfoList.Referencia, objPremiosArticulosInfoList.Ccostos, RestaInventario);

                                                        //si se pudo actualizar el inventario
                                                        if (okTrans)
                                                        {
                                                            PedidosDetalleClienteInfo PedidoDetallePremio = null;

                                                            //Se construye el detalle del pedido con el premio.
                                                            if (objPremiosArticulosInfoList != null)
                                                            {
                                                                //Construir el detalle del pedido con el premio asignado.
                                                                PedidoDetallePremio = CrearDetallePedido(objPedidosPremiosTempRegla.Numero, objPremiosArticulosInfoList);
                                                            }

                                                            //Se asigna el premio al detalle del pedido de niviglobal, Se guarda el detalle del pedido en SVDN.
                                                            PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                            //Se asigna la cantidad de articulos que se asignar por premio.
                                                            PedidoDetallePremio.Cantidad = objPremiosArticulosInfoList.Cantidad;
                                                            PedidoDetallePremio.CantidadPedida = PedidoDetallePremio.Cantidad;
                                                            //*Habilitar esta linea si se debe asignar el premio a la bd de NIVI(SVDN).
                                                            //*string IdDetallePedido = objPedidosDetalleCliente.Insert(PedidoDetallePremio);
                                                            //*PedidoDetallePremio.Id = IdDetallePedido;

                                                            //NOTA: EL SISTEMA DE G&G REALIZA UN DESCUENTO MASIVO DEL INVENTARIO EN MKT POR CADA DETALLE DEL PEDIDO QUE ENCUENTRE, DEPENDIENDO DEL CAMPO DE CANTIDAD DEL DETALLE DEL PEDIDO.
                                                            //      MKT AUTOMATICAMENTE DESCUENTA DE SU PROPIO INVENTARIO Y REALIZA UNA REMISION CON EL DETALLE DEL PEDIDO PASADO POR SVDN.

                                                            //Se debe guardar el encabezado y detalle del pedido en MKT.
                                                            //Si ya existe el pedido en MKT solo se debe adicionar el detalle, sino se debe crear el encabezado tambien.

                                                            PedidosClienteInfo objPedidoMkt = this.ListPedidosMkt(objPedidosPremiosTempRegla.Numero);

                                                            bool okTransMkt = true;

                                                            //sino existe el encabezado se crea uno nuevo.
                                                            if (objPedidoMkt == null)
                                                            {
                                                                objPedidosPremiosTempRegla.Valor = 0;
                                                                objPedidosPremiosTempRegla.IVA = 0;

                                                                //Se consulta el codigo de numeracion para remisiones en MKT
                                                                Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                                                                Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                                                                ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.CodigoNumeracionMKT);

                                                                objPedidosPremiosTempRegla.CodigoNumeracion = ObjParametrosInfo.Valor.ToString();

                                                                //Se guarda el encabezado del pedido en MKT.
                                                                okTransMkt = this.InsertPremiosMkt(objPedidosPremiosTempRegla);
                                                            }

                                                            if (okTransMkt)
                                                            {
                                                                PremiosPuntosTotal objPremiosPuntosTotal = new PremiosPuntosTotal("conexion");
                                                                List<PremiosPuntosTotalInfo> objListPremiosPuntosTotalInfo = new List<PremiosPuntosTotalInfo>();

                                                                //SOLO SE ASIGNA EL PREMIO A LA BD DE MKT, NO A NIVI POR QUE MKT SON LOS QUE HACEN LAS REMISIONES.
                                                                //Se guarda el detalle del pedido que es premio.
                                                                string okTransDetalle = objPedidosDetalleCliente.InsertPremiosMkt(PedidoDetallePremio);

                                                                if (okTransDetalle != "" && okTransDetalle != null)
                                                                {

                                                                    PedidosxPremioInfo objPedidosxPremioInfo = new PedidosxPremioInfo();

                                                                    objPedidosxPremioInfo.IdPremio = IdPremio;
                                                                    objPedidosxPremioInfo.Numero = objPedidosPremiosTempRegla.Numero;


                                                                    //Se guarda en la lista el pedido que se debe actualizar a estado normal y eliminar de la tabla temporal.
                                                                    ListaActualizarBorrarPedidos.Add(objPedidosxPremioInfo);
                                                                    //Eliminar pedido de la tabla temporal por id de articulo y tipo de query.                                                                   
                                                                    //bool okTransDelete = this.DeletePedidoPremioTemporalSimple(objPedidosPremiosTempRegla.Numero, objPedidosPremiosTempRegla.IdArticuloPremio, objPedidosPremiosTempRegla.TipoQuery);

                                                                    //Actualiza el estado del pedido a Normal por que se proceso bien.
                                                                    //bool okTrasnEstadoPed = this.UpdateEstadoPedido(objPedidosPremiosTempRegla.Numero, (int)EstadosPedidoEnum.Normal);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Actualiza el estado del pedido a Retenido Premiso por que no hay existencias del articulo para ese pedido.
                                                        bool okTrasnEstadoPed = this.UpdateEstadoPedido(objPedidosPremiosTempRegla.Numero, (int)EstadosPedidoEnum.RetenidoPremios);

                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SIN NIVELES: EL PEDIDO HA SIDO RETENIDO POR FALTA DE INVENTARIO DE ARTICULOS = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", objPedidosPremiosTempRegla.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SIN NIVELES: {0}, NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO DE MKT DISPONIBLE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }

                                            }
                                            else
                                            {
                                                VerificarPedNiveles = true;
                                            }

                                        }
                                        //............................................................................................................
                                        //............................................................................................................
                                        #endregion

                                        #region "NIVELES"

                                        //Si asignando los pedidos se detecta que hay reglas de nivles debe hacer el siguiente procedimiento.
                                        if (VerificarPedNiveles)
                                        {

                                            #region "REGLAS CON NIVELES"

                                            //*****************************************************************************************************
                                            //*****************************************************************************************************
                                            //LOGICA DE NEGOCIO PARA LAS REGLAS CON NIVELES

                                            //1. Se obtienen los niveles de 1 premio.
                                            PremiosNiveles objPremiosNiveles = new PremiosNiveles("conexion");
                                            List<PremiosNivelesInfo> objListPremiosNivelesInfo = new List<PremiosNivelesInfo>();

                                            //2.Se obtiene la configuracion de los puntos ordenados para comparar si recibe premio, los puntos mayor al menor se comparan.
                                            objListPremiosNivelesInfo = objPremiosNiveles.ListxPremio(IdPremio);

                                            if (objListPremiosNivelesInfo.Count > 0)
                                            {
                                                foreach (PremiosNivelesInfo objPremiosNivelesInfo in objListPremiosNivelesInfo)
                                                {
                                                    if (objPremiosNivelesInfo.TipoPuntos == "RANGO")
                                                    {
                                                        #region "NIVELES DE RANGOS"

                                                        PremiosPuntosTotal objPremiosPuntosTotal = new PremiosPuntosTotal("conexion");
                                                        List<PremiosPuntosTotalInfo> objListPremiosPuntosTotalInfo = new List<PremiosPuntosTotalInfo>();

                                                        //a. se obtienen los clientes con los puntos totales.
                                                        objListPremiosPuntosTotalInfo = objPremiosPuntosTotal.ListxPremio(IdPremio);

                                                        if (objListPremiosPuntosTotalInfo.Count > 0)
                                                        {
                                                            foreach (PremiosPuntosTotalInfo objPremiosPuntosTotalInfo in objListPremiosPuntosTotalInfo)
                                                            {
                                                                //SI LOS PUNTOS TOTALES DEL CLIENTE SON MAYORES QUE LOS PUNTOS DE CONFIGURACION ES POR QUE TIENE PREMIO.
                                                                //Se asigna el mismo premio a los pedidos del cliente que supero los puntos.
                                                                if (objPremiosPuntosTotalInfo.PuntosTotal >= objPremiosNivelesInfo.Puntos)
                                                                {
                                                                    List<PedidosClienteInfo> objListPedidosClienteInfo = new List<PedidosClienteInfo>();

                                                                    objListPedidosClienteInfo = this.ListTablaPremiosTemporalxNit(objPremiosPuntosTotalInfo.Nit);


                                                                    //Si el cliente tiene pedidos asignados para agregar el premio.
                                                                    if (objListPedidosClienteInfo != null && objListPedidosClienteInfo.Count > 0)
                                                                    {
                                                                        bool okBorraPuntos = false;

                                                                        foreach (PedidosClienteInfo objPedidosClienteInfo in objListPedidosClienteInfo)
                                                                        {
                                                                            PremiosArticulosInfo objPremiosArticulosInfoList = new PremiosArticulosInfo();
                                                                            PremiosArticulos objPremiosArticulos = new PremiosArticulos("conexion");
                                                                            //traer el detalle del articulo por ID.
                                                                            objPremiosArticulosInfoList = objPremiosArticulos.ListxId(objPremiosNivelesInfo.IdArticulo);

                                                                            //List<InventarioMktInfo> objInventarioMktInfoList = new List<InventarioMktInfo>();
                                                                            //objInventarioMktInfoList = objInventarioMkt.ListInventarioDisponible();

                                                                            InventarioMktInfo objInventarioMktInfo = new InventarioMktInfo();

                                                                            //Obtener el inventario de MKT.
                                                                            objInventarioMktInfo = objInventarioMkt.ListxBodegaxRefxCcostos(objPremiosArticulosInfoList.Bodega, objPremiosArticulosInfoList.Referencia, objPremiosArticulosInfoList.Ccostos);

                                                                            if (objInventarioMktInfo != null)
                                                                            {
                                                                                //Restar la cantidad del articulo del premio con el inventario de mkt.
                                                                                int RestaInventario = Convert.ToInt32(objInventarioMktInfo.Saldo) - objPremiosArticulosInfoList.Cantidad;

                                                                                //si el inventario es > 0 es por que  existe inventario.
                                                                                if (RestaInventario > 0)
                                                                                {
                                                                                    //se actualiza la cantidad del inventario que queda despues de asignar.
                                                                                    bool okTrans = objInventarioMkt.UpdateCantidad(objPremiosArticulosInfoList.Bodega, objPremiosArticulosInfoList.Referencia, objPremiosArticulosInfoList.Ccostos, RestaInventario);

                                                                                    //si se pudo actualizar el inventario
                                                                                    if (okTrans)
                                                                                    {
                                                                                        PedidosDetalleClienteInfo PedidoDetallePremio = null;

                                                                                        //Se construye el detalle del pedido con el premio.
                                                                                        if (objPremiosArticulosInfoList != null)
                                                                                        {
                                                                                            //Construir el detalle del pedido con el premio asignado.
                                                                                            PedidoDetallePremio = CrearDetallePedido(objPedidosClienteInfo.Numero, objPremiosArticulosInfoList);
                                                                                        }

                                                                                        //Se asigna el premio al detalle del pedido de niviglobal, Se guarda el detalle del pedido en SVDN.
                                                                                        PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                                                        //Se asigna la cantidad de articulos que se asignar por premio.
                                                                                        PedidoDetallePremio.Cantidad = objPremiosArticulosInfoList.Cantidad;
                                                                                        PedidoDetallePremio.CantidadPedida = PedidoDetallePremio.Cantidad;
                                                                                        //*Habilitar esta linea si se debe asignar el premio a la bd de NIVI(SVDN).
                                                                                        //*string IdDetallePedido = objPedidosDetalleCliente.Insert(PedidoDetallePremio);
                                                                                        //*PedidoDetallePremio.Id = IdDetallePedido;

                                                                                        //NOTA: EL SISTEMA DE G&G REALIZA UN DESCUENTO MASIVO DEL INVENTARIO EN MKT POR CADA DETALLE DEL PEDIDO QUE ENCUENTRE, DEPENDIENDO DEL CAMPO DE CANTIDAD DEL DETALLE DEL PEDIDO.
                                                                                        //      MKT AUTOMATICAMENTE DESCUENTA DE SU PROPIO INVENTARIO Y REALIZA UNA REMISION CON EL DETALLE DEL PEDIDO PASADO POR SVDN.

                                                                                        //Se debe guardar el encabezado y detalle del pedido en MKT.
                                                                                        //Si ya existe el pedido en MKT solo se debe adicionar el detalle, sino se debe crear el encabezado tambien.

                                                                                        PedidosClienteInfo objPedidoMkt = this.ListPedidosMkt(objPedidosClienteInfo.Numero);

                                                                                        bool okTransMkt = true;

                                                                                        //sino existe el encabezado se crea uno nuevo.
                                                                                        if (objPedidoMkt == null)
                                                                                        {
                                                                                            objPedidosClienteInfo.Valor = 0;
                                                                                            objPedidosClienteInfo.IVA = 0;

                                                                                            //Se consulta el codigo de numeracion para remisiones en MKT
                                                                                            Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                                                                                            Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                                                                                            ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.CodigoNumeracionMKT);

                                                                                            objPedidosClienteInfo.CodigoNumeracion = ObjParametrosInfo.Valor.ToString();

                                                                                            //Se guarda el encabezado del pedido en MKT.
                                                                                            okTransMkt = this.InsertPremiosMkt(objPedidosClienteInfo);
                                                                                        }

                                                                                        if (okTransMkt)
                                                                                        {
                                                                                            //SOLO SE ASIGNA EL PREMIO A LA BD DE MKT, NO A NIVI POR QUE MKT SON LOS QUE HACEN LAS REMISIONES.
                                                                                            //Se guarda el detalle del pedido que es premio.
                                                                                            string okTransDetalle = objPedidosDetalleCliente.InsertPremiosMkt(PedidoDetallePremio);

                                                                                            if (okTransDetalle != "" && okTransDetalle != null)
                                                                                            {

                                                                                                PedidosxPremioInfo objPedidosxPremioInfo = new PedidosxPremioInfo();

                                                                                                objPedidosxPremioInfo.IdPremio = IdPremio;
                                                                                                objPedidosxPremioInfo.Numero = objPedidosClienteInfo.Numero;


                                                                                                //Se guarda en la lista el pedido que se debe actualizar a estado normal y eliminar de la tabla temporal.
                                                                                                ListaActualizarBorrarPedidos.Add(objPedidosxPremioInfo);

                                                                                                //Eliminar pedido de la tabla temporal.
                                                                                                //bool okTransDelete = this.DeletePedidoPremioTemporal(objPedidosClienteInfo.Numero);

                                                                                                //Actualiza el estado del pedido a Normal por que se proceso bien.
                                                                                                //bool okTrasnEstadoPed = this.UpdateEstadoPedido(objPedidosClienteInfo.Numero, (int)EstadosPedidoEnum.Normal);

                                                                                                okBorraPuntos = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PREMIOS RANGO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR DETALLE PREMIO EN MKT: PEDIDO No: " + objPedidosClienteInfo.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PREMIOS RANGO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR PREMIO EN MKT: PEDIDO No: " + objPedidosClienteInfo.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    //Actualiza el estado del pedido a Retenido Premiso por que no hay existencias del articulo para ese pedido.
                                                                                    bool okTrasnEstadoPed = this.UpdateEstadoPedido(objListPedidosClienteInfo[0].Numero, (int)EstadosPedidoEnum.RetenidoPremios);

                                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS RANGO: EL PEDIDO HA SIDO RETENIDO POR FALTA DE INVENTARIO DE ARTICULOS = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", objListPedidosClienteInfo[0].Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS RANGO: {0}, NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO DE MKT DISPONIBLE." + " Bodega: " + objPremiosArticulosInfoList.Bodega + " Referencia: " + objPremiosArticulosInfoList.Referencia + " CCostos: " + objPremiosArticulosInfoList.Ccostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                            }
                                                                        }

                                                                        //aqui borrar puntos del cliente por que ya se le asignaron premios a los pedidos.
                                                                        if (okBorraPuntos)
                                                                        {
                                                                            //Actualiza los puntos del cliente a 0, por que ya se asigno el premio.
                                                                            bool okTranPunTotal = objPremiosPuntosTotal.UpdatePuntos(objPremiosPuntosTotalInfo.Nit);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS RANGO: EL CLIENTE NO TIENE PEDIDOS PARA ASIGNAR PREMIOS. CLIENTE = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", objPremiosPuntosTotalInfo.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }

                                                                    //break por que se asigno el premio, se debe salir del bucle de asignacion y seguir con el siguiente cliente.
                                                                    //break;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS RANGO: {0}, NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN PUNTOS TOTALES PARA LOS NIVELES POR RANGO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }

                                                        #endregion
                                                    }
                                                    else if (objPremiosNivelesInfo.TipoPuntos == "SEPARADO")
                                                    {
                                                        #region "NIVELES SEPARADOS"

                                                        PremiosPuntosTotalSep objPremiosPuntosTotalSep = new PremiosPuntosTotalSep("conexion");
                                                        List<PremiosPuntosTotalSepInfo> objListNitPremiosPuntosTotalSepInfo = new List<PremiosPuntosTotalSepInfo>();

                                                        //Se obtienen los nit que tienen puntos en general.
                                                        objListNitPremiosPuntosTotalSepInfo = objPremiosPuntosTotalSep.ListNitPuntosxPremio(IdPremio);

                                                        if (objListNitPremiosPuntosTotalSepInfo.Count > 0)
                                                        {
                                                            foreach (PremiosPuntosTotalSepInfo objNitPremiosPuntosTotalInfo in objListNitPremiosPuntosTotalSepInfo)
                                                            {
                                                                //se consulta cada nit para saber si tienen mas de 2 campañas por nivel, si es asi se deben comparar los puntos del cliente contra el nivel.
                                                                List<PremiosPuntosTotalSepInfo> objListPuntosNitNivelSepInfo = new List<PremiosPuntosTotalSepInfo>();
                                                                objListPuntosNitNivelSepInfo = objPremiosPuntosTotalSep.ListPuntosxNitxNivel(objNitPremiosPuntosTotalInfo.Nit, objPremiosNivelesInfo.IdNivel);

                                                                if (objListPuntosNitNivelSepInfo.Count >= 2)
                                                                {
                                                                    //Se obitnen los puntos para comparar del nivel actual
                                                                    int PuntosNivelCampana1 = objPremiosNivelesInfo.Puntos;
                                                                    int PuntosNivelCampana2 = objPremiosNivelesInfo.PuntosCampana2;

                                                                    int PuntosClienteCampana1 = 0;
                                                                    int PuntosClienteCampana2 = 0;

                                                                    //Se asignan los puntos por nivel y por campaña
                                                                    for (int i = 0; i < objListPuntosNitNivelSepInfo.Count; i++)
                                                                    {
                                                                        if (i == 0)
                                                                        {
                                                                            PuntosClienteCampana1 = objListPuntosNitNivelSepInfo[i].PuntosTotal;
                                                                        }
                                                                        else if (i == 1)
                                                                        {
                                                                            PuntosClienteCampana2 = objListPuntosNitNivelSepInfo[i].PuntosTotal;
                                                                        }
                                                                    }

                                                                    //Con esta condicion se compara si los puntos por campaña cumplen con la condicion del nivel.
                                                                    //Si cumple la condicion es por que tiene premio.
                                                                    //Se asigna el mismo premio a los pedidos del cliente que supero los puntos.
                                                                    if (PuntosClienteCampana1 >= PuntosNivelCampana1 && PuntosClienteCampana2 >= PuntosNivelCampana2)
                                                                    {

                                                                        //Se buscan los pedidos del cliente que supero los puntos.
                                                                        List<PedidosClienteInfo> objListPedidosClienteInfo = new List<PedidosClienteInfo>();

                                                                        objListPedidosClienteInfo = this.ListTablaPremiosTemporalxNit(objNitPremiosPuntosTotalInfo.Nit);


                                                                        //Si el cliente tiene pedidos asignados para agregar el premio.
                                                                        if (objListPedidosClienteInfo != null && objListPedidosClienteInfo.Count > 0)
                                                                        {
                                                                            bool okBorraPuntos = false;

                                                                            foreach (PedidosClienteInfo objPedidosClienteInfo in objListPedidosClienteInfo)
                                                                            {
                                                                                PremiosArticulosInfo objPremiosArticulosInfoList = new PremiosArticulosInfo();
                                                                                PremiosArticulos objPremiosArticulos = new PremiosArticulos("conexion");
                                                                                //traer el detalle del articulo por ID.
                                                                                objPremiosArticulosInfoList = objPremiosArticulos.ListxId(objPremiosNivelesInfo.IdArticulo);

                                                                                //List<InventarioMktInfo> objInventarioMktInfoList = new List<InventarioMktInfo>();
                                                                                //objInventarioMktInfoList = objInventarioMkt.ListInventarioDisponible();

                                                                                InventarioMktInfo objInventarioMktInfo = new InventarioMktInfo();

                                                                                //Obtener el inventario de MKT.
                                                                                objInventarioMktInfo = objInventarioMkt.ListxBodegaxRefxCcostos(objPremiosArticulosInfoList.Bodega, objPremiosArticulosInfoList.Referencia, objPremiosArticulosInfoList.Ccostos);

                                                                                if (objInventarioMktInfo != null)
                                                                                {
                                                                                    //Restar la cantidad del articulo del premio con el inventario de mkt.
                                                                                    int RestaInventario = Convert.ToInt32(objInventarioMktInfo.Saldo) - objPremiosArticulosInfoList.Cantidad;

                                                                                    //si el inventario es > 0 es por que  existe inventario.
                                                                                    if (RestaInventario > 0)
                                                                                    {
                                                                                        //se actualiza la cantidad del inventario que queda despues de asignar.
                                                                                        bool okTrans = objInventarioMkt.UpdateCantidad(objPremiosArticulosInfoList.Bodega, objPremiosArticulosInfoList.Referencia, objPremiosArticulosInfoList.Ccostos, RestaInventario);

                                                                                        //si se pudo actualizar el inventario
                                                                                        if (okTrans)
                                                                                        {
                                                                                            PedidosDetalleClienteInfo PedidoDetallePremio = null;

                                                                                            //Se construye el detalle del pedido con el premio.
                                                                                            if (objPremiosArticulosInfoList != null)
                                                                                            {
                                                                                                //Construir el detalle del pedido con el premio asignado.
                                                                                                PedidoDetallePremio = CrearDetallePedido(objPedidosClienteInfo.Numero, objPremiosArticulosInfoList);
                                                                                            }

                                                                                            //Se asigna el premio al detalle del pedido de niviglobal, Se guarda el detalle del pedido en SVDN.
                                                                                            PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                                                            //Se asigna la cantidad de articulos que se asignar por premio.
                                                                                            PedidoDetallePremio.Cantidad = objPremiosArticulosInfoList.Cantidad;
                                                                                            PedidoDetallePremio.CantidadPedida = PedidoDetallePremio.Cantidad;
                                                                                            //*Habilitar esta linea si se debe asignar el premio a la bd de NIVI(SVDN).
                                                                                            //*string IdDetallePedido = objPedidosDetalleCliente.Insert(PedidoDetallePremio);
                                                                                            //*PedidoDetallePremio.Id = IdDetallePedido;

                                                                                            //NOTA: EL SISTEMA DE G&G REALIZA UN DESCUENTO MASIVO DEL INVENTARIO EN MKT POR CADA DETALLE DEL PEDIDO QUE ENCUENTRE, DEPENDIENDO DEL CAMPO DE CANTIDAD DEL DETALLE DEL PEDIDO.
                                                                                            //      MKT AUTOMATICAMENTE DESCUENTA DE SU PROPIO INVENTARIO Y REALIZA UNA REMISION CON EL DETALLE DEL PEDIDO PASADO POR SVDN.

                                                                                            //Se debe guardar el encabezado y detalle del pedido en MKT.
                                                                                            //Si ya existe el pedido en MKT solo se debe adicionar el detalle, sino se debe crear el encabezado tambien.

                                                                                            PedidosClienteInfo objPedidoMkt = this.ListPedidosMkt(objPedidosClienteInfo.Numero);

                                                                                            bool okTransMkt = true;

                                                                                            //sino existe el encabezado se crea uno nuevo.
                                                                                            if (objPedidoMkt == null)
                                                                                            {
                                                                                                objPedidosClienteInfo.Valor = 0;
                                                                                                objPedidosClienteInfo.IVA = 0;

                                                                                                //Se consulta el codigo de numeracion para remisiones en MKT
                                                                                                Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                                                                                                Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                                                                                                ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.CodigoNumeracionMKT);

                                                                                                objPedidosClienteInfo.CodigoNumeracion = ObjParametrosInfo.Valor.ToString();

                                                                                                //Se guarda el encabezado del pedido en MKT.
                                                                                                okTransMkt = this.InsertPremiosMkt(objPedidosClienteInfo);
                                                                                            }

                                                                                            if (okTransMkt)
                                                                                            {
                                                                                                //SOLO SE ASIGNA EL PREMIO A LA BD DE MKT, NO A NIVI POR QUE MKT SON LOS QUE HACEN LAS REMISIONES.
                                                                                                //Se guarda el detalle del pedido que es premio.
                                                                                                string okTransDetalle = objPedidosDetalleCliente.InsertPremiosMkt(PedidoDetallePremio);

                                                                                                if (okTransDetalle != "" && okTransDetalle != null)
                                                                                                {
                                                                                                    PedidosxPremioInfo objPedidosxPremioInfo = new PedidosxPremioInfo();

                                                                                                    objPedidosxPremioInfo.IdPremio = IdPremio;
                                                                                                    objPedidosxPremioInfo.Numero = objPedidosClienteInfo.Numero;


                                                                                                    //Se guarda en la lista el pedido que se debe actualizar a estado normal y eliminar de la tabla temporal.
                                                                                                    ListaActualizarBorrarPedidos.Add(objPedidosxPremioInfo);

                                                                                                    //Eliminar pedido de la tabla temporal.
                                                                                                    //bool okTransDelete = this.DeletePedidoPremioTemporal(objPedidosClienteInfo.Numero);

                                                                                                    //Actualiza el estado del pedido a Normal por que se proceso bien.
                                                                                                    //bool okTrasnEstadoPed = this.UpdateEstadoPedido(objPedidosClienteInfo.Numero, (int)EstadosPedidoEnum.Normal);

                                                                                                    okBorraPuntos = true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PREMIOS SEPARADO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR DETALLE PREMIO EN MKT: PEDIDO No: " + objPedidosClienteInfo.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PREMIOS SEPARADO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR PREMIO EN MKT: PEDIDO No: " + objPedidosClienteInfo.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        //Actualiza el estado del pedido a Retenido Premios por que no hay existencias del articulo para ese pedido.
                                                                                        bool okTrasnEstadoPed = this.UpdateEstadoPedido(objListPedidosClienteInfo[0].Numero, (int)EstadosPedidoEnum.RetenidoPremios);

                                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SEPARADO: EL PEDIDO HA SIDO RETENIDO POR FALTA DE INVENTARIO DE ARTICULOS = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", objListPedidosClienteInfo[0].Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SEPARADO: {0}, NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO DE MKT DISPONIBLE." + " Bodega: " + objPremiosArticulosInfoList.Bodega + " Referencia: " + objPremiosArticulosInfoList.Referencia + " CCostos: " + objPremiosArticulosInfoList.Ccostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                                }
                                                                            }

                                                                            //aqui borrar puntos del cliente por que ya se le asignaron premios a los pedidos.
                                                                            if (okBorraPuntos)
                                                                            {
                                                                                //Actualiza los puntos del cliente a 0, por que ya se asigno el premio.
                                                                                bool okTranPunTotal = objPremiosPuntosTotalSep.UpdatePuntos(objNitPremiosPuntosTotalInfo.Nit, objPremiosNivelesInfo.IdNivel);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SEPARADO: EL CLIENTE NO TIENE PEDIDOS PARA ASIGNAR PREMIOS. CLIENTE = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", objNitPremiosPuntosTotalInfo.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                        }

                                                                        //break por que se asigno el premio, se debe salir del bucle de asignacion y seguir con el siguiente cliente.
                                                                        //break;

                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SEPARADO:NO EXISTEN PUNTOS PARA CLIENTE: {0}, NIVEL:{1}, NameSpace: {2}, Clase: {3}, Metodo: {4} ", objNitPremiosPuntosTotalInfo.Nit, objPremiosNivelesInfo.IdNivel, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS SEPARADO: {0}, NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CLIENTES CON PUNTOS PARA PREMIOS SEPARADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                        #endregion
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0}, NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN NIVELES DE PREMIOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }

                                            #endregion
                                        }

                                        #endregion
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN PEDIDOS DE PREMIOS TEMPORAL PARA ASIGNAR ARTICULOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    #endregion


                                    PedidosxPremio objPedidosxPremio = new PedidosxPremio();


                                    //Hacer ciclo de borrado y actualizacion de pedidos procesados.
                                    foreach (PedidosxPremioInfo itemPedidosxPremio in ListaActualizarBorrarPedidos)
                                    {
                                        //Eliminar pedido de la tabla temporal.
                                        bool okTransDelete = this.DeletePedidoPremioTemporal(itemPedidosxPremio.Numero);

                                        //Actualiza el estado del pedido a Procesado por que se proceso bien.
                                        bool okTrasnEstadoPed = this.UpdateEstadoPedido(itemPedidosxPremio.Numero, (int)EstadosPedidoEnum.Procesado);

                                        //Guarda en la tabla de pedidos x premio para no volver a repetir los pedidos al momento de reprocesar los premios.
                                        bool okTransPedidoxPremio = objPedidosxPremio.Insert(itemPedidosxPremio);

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;
                                    }


                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }


                        //..............................................................................................................................
                        //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                        PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                        if (okProcess == false)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA PEDIDOS X PREMIOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //.......................................................................................
                            //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                            if (handler != null)
                            {
                                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                                handler(ObjPedidosClienteProcesadoInfo);
                            }
                            //.......................................................................................
                        }
                        else if (okProcess == true)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se limpian los pedidos que quedan despues del proceso que no pudieron asignar premios.
                            DeletePremiosTemporal();

                            //...........................................................................
                            //Dispara el evento de que termino el proceso ok.                                               
                            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                            if (handler != null)
                            {
                                ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                                handler(ObjPedidosClienteProcesadoInfo);
                            }
                            //...........................................................................
                        }
                        //..............................................................................................................................


                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE ASIGNACIÓN DE PREMIOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        //Calcula el tiempo que demora en realizar la asignacion de reglas.
                        TimeSpan ts = DateTime.Now - _startAsignacionTime;
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                        System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "EXISTE OTRO PROCESO DE PREMIOS ACTIVO, POR FAVOR VERIFICAR LA TABLA DE PEDIDOS PREMIOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI  PREMIOS Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //return okProcess;
        }

        /// <summary>
        /// Crea el detalle de un pedido.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="objPremiosArticulosInfo"></param>
        /// <returns></returns>
        private PedidosDetalleClienteInfo CrearDetallePedido(string IdPedido, PremiosArticulosInfo objPremiosArticulosInfo)
        {
            PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

            objPedidosDetalleClienteInfo.Numero = IdPedido;
            //objPedidosDetalleClienteInfo.Id = IdPedido;
            objPedidosDetalleClienteInfo.Referencia = objPremiosArticulosInfo.Referencia;
            objPedidosDetalleClienteInfo.Descripcion = objPremiosArticulosInfo.Nombre; //articulo + color + talla
            objPedidosDetalleClienteInfo.Valor = 0; //0 por que es un premio.
            //*objPedidosDetalleClienteInfo.Cantidad = Cantidad; //unidades pedidas del articulo
            objPedidosDetalleClienteInfo.Cantidad = objPremiosArticulosInfo.Cantidad;
            objPedidosDetalleClienteInfo.Descuento = 0;
            objPedidosDetalleClienteInfo.Anulado = 0;
            objPedidosDetalleClienteInfo.TarifaIVA = 0; //Tarifa iva = 0 por que es un premio.
            objPedidosDetalleClienteInfo.Lote = objPremiosArticulosInfo.Ccostos;
            objPedidosDetalleClienteInfo.Ensamblado = 0;
            //*objPedidosDetalleClienteInfo.CantidadPedida = Cantidad; //unidades pedidas del articulo                   
            //objPedidosDetalleClienteInfo.CantidadPedida = PedidoDetalleListTemp[i].Cantidad;
            objPedidosDetalleClienteInfo.CantidadPedida = 0; //Se envia cero para el arreglo del inventario.
            objPedidosDetalleClienteInfo.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CodigoUbicacion = "P" + objPremiosArticulosInfo.Bodega;
            objPedidosDetalleClienteInfo.PLU = 0;
            objPedidosDetalleClienteInfo.NumeroEnvio = 0;
            objPedidosDetalleClienteInfo.ConceptoContable = objPremiosArticulosInfo.Ccostos;
            objPedidosDetalleClienteInfo.CentroCostos = objPremiosArticulosInfo.Ccostos;
            objPedidosDetalleClienteInfo.Grupo = "";
            objPedidosDetalleClienteInfo.Imagen = "Premio Asignado desde SVDN. Fecha: " + DateTime.Now.ToString();

            return objPedidosDetalleClienteInfo;
        }

        /// <summary>
        /// Crea el detalle de un pedido.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="objPremiosArticulosInfo"></param>
        /// <returns></returns>
        private PedidosDetalleClienteInfo CrearFleteDetallePedido(string IdPedido, decimal ValorFlete, string Zona, int Excluido)
        {
            Parametros objParametros = new Parametros("conexion");

            PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

            objPedidosDetalleClienteInfo.Numero = IdPedido;
            //objPedidosDetalleClienteInfo.Id = IdPedido;
            objPedidosDetalleClienteInfo.Referencia = "FL000001";
            objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - ZONA: " + Zona;
            objPedidosDetalleClienteInfo.Valor = ValorFlete;
            //*objPedidosDetalleClienteInfo.Cantidad = Cantidad; //unidades pedidas del articulo
            objPedidosDetalleClienteInfo.Cantidad = 1;
            objPedidosDetalleClienteInfo.Descuento = 0;
            objPedidosDetalleClienteInfo.Anulado = 0;

            if (Excluido == 1)
            {
                objPedidosDetalleClienteInfo.TarifaIVA = 0;
            }
            else
            {
                objPedidosDetalleClienteInfo.TarifaIVA = Convert.ToDecimal(objParametros.ListxId((int)ParametrosEnum.ValorIVACOP).Valor);
            }

            objPedidosDetalleClienteInfo.Lote = "01";
            objPedidosDetalleClienteInfo.Ensamblado = 0;
            //*objPedidosDetalleClienteInfo.CantidadPedida = Cantidad; //unidades pedidas del articulo                   
            //objPedidosDetalleClienteInfo.CantidadPedida = PedidoDetalleListTemp[i].Cantidad;
            objPedidosDetalleClienteInfo.CantidadPedida = 1; //Se envia cero para el arreglo del inventario.
            objPedidosDetalleClienteInfo.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CodigoUbicacion = "01"; //Bodega = 002
            objPedidosDetalleClienteInfo.PLU = 48332;
            objPedidosDetalleClienteInfo.NumeroEnvio = 0;
            objPedidosDetalleClienteInfo.ConceptoContable = "02";
            objPedidosDetalleClienteInfo.CentroCostos = Zona;
            objPedidosDetalleClienteInfo.Grupo = "";
            objPedidosDetalleClienteInfo.Imagen = "Flete Asignado desde SVDN. Fecha: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CantidadNivelServicio = 0;
            objPedidosDetalleClienteInfo.ValorPrecioCatalogo = 0;
            objPedidosDetalleClienteInfo.IVAPrecioCatalogo = 0;
            objPedidosDetalleClienteInfo.Catalogo = "N/A";
            objPedidosDetalleClienteInfo.NumeroPedidoPadre = IdPedido;

            objPedidosDetalleClienteInfo.IdCodigoCorto = "FL00";
            objPedidosDetalleClienteInfo.FechaCreacion = DateTime.Now;
            objPedidosDetalleClienteInfo.CatalogoReal = objPedidosDetalleClienteInfo.CatalogoReal;

            KardexInfo objKardexInfo = new KardexInfo();
            Kardex objKardex = new Kardex("conexion");

            objKardexInfo = objKardex.ListxArticuloxPLU(48332);

            //Sino existe en detalle se agrega desde cero.
            if (objKardexInfo != null)
            {
                objPedidosDetalleClienteInfo.UnidadNegocio = objKardexInfo.UnidadNegocio;
                objPedidosDetalleClienteInfo.CatalogoReal = objKardexInfo.Catalogo;
            }

            objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = objPedidosDetalleClienteInfo.Valor;
            objPedidosDetalleClienteInfo.PorcentajeDescuento = 0;

            return objPedidosDetalleClienteInfo;
        }

        /// <summary>
        /// Crea el detalle de un pedido x ciudad.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="objPremiosArticulosInfo"></param>
        /// <returns></returns>
        private PedidosDetalleClienteInfo CrearFleteDetallePedidoxCiudad(string IdPedido, decimal ValorFlete, string Zona, int Excluido, string CodCiudad, decimal PorcentajeIVA, decimal ValorFleteFull, bool TipoFlete)
        {
            Parametros objParametros = new Parametros("conexion");

            PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

            objPedidosDetalleClienteInfo.Numero = IdPedido;
            //objPedidosDetalleClienteInfo.Id = IdPedido;
            objPedidosDetalleClienteInfo.Referencia = "FL000001";
            //objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - ZONA: " + Zona;
            objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - CIUDAD: " + CodCiudad;
            //objPedidosDetalleClienteInfo.Valor = ValorFlete;

            //si el tipo flete es true es por que es flete normal.
            if (TipoFlete)
            {
                objPedidosDetalleClienteInfo.Valor = ValorFlete;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFlete;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFlete;
            }
            else
            {
                objPedidosDetalleClienteInfo.Valor = ValorFleteFull;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteFull;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteFull;
            }

            //*objPedidosDetalleClienteInfo.Cantidad = Cantidad; //unidades pedidas del articulo
            objPedidosDetalleClienteInfo.Cantidad = 1;
            objPedidosDetalleClienteInfo.Descuento = 0;
            objPedidosDetalleClienteInfo.Anulado = 0;

            if (Excluido == 1)
            {
                objPedidosDetalleClienteInfo.TarifaIVA = 0;
            }
            else
            {
                //objPedidosDetalleClienteInfo.TarifaIVA = Convert.ToDecimal(objParametros.ListxId((int)ParametrosEnum.ValorIVACOP).Valor);
                objPedidosDetalleClienteInfo.TarifaIVA = PorcentajeIVA;
            }

            objPedidosDetalleClienteInfo.Lote = "01";
            objPedidosDetalleClienteInfo.Ensamblado = 0;
            //*objPedidosDetalleClienteInfo.CantidadPedida = Cantidad; //unidades pedidas del articulo                   
            //objPedidosDetalleClienteInfo.CantidadPedida = PedidoDetalleListTemp[i].Cantidad;
            objPedidosDetalleClienteInfo.CantidadPedida = 1; //Se envia cero para el arreglo del inventario.
            objPedidosDetalleClienteInfo.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CodigoUbicacion = "01"; //Bodega = 002
            objPedidosDetalleClienteInfo.PLU = 48332;
            objPedidosDetalleClienteInfo.NumeroEnvio = 0;
            objPedidosDetalleClienteInfo.ConceptoContable = "02";
            objPedidosDetalleClienteInfo.CentroCostos = Zona;
            objPedidosDetalleClienteInfo.Grupo = "";
            objPedidosDetalleClienteInfo.Imagen = "Flete Asignado desde SVDN. Fecha: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CantidadNivelServicio = 0;
            //objPedidosDetalleClienteInfo.ValorPrecioCatalogo = 0;

            //si el tipo flete es true es por que es flete normal.
            if (TipoFlete)
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFlete;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFlete;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFlete;
            }
            else
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFleteFull;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteFull;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteFull;
            }

            //objPedidosDetalleClienteInfo.IVAPrecioCatalogo = 0;
            objPedidosDetalleClienteInfo.IVAPrecioCatalogo = objPedidosDetalleClienteInfo.TarifaIVA;
            objPedidosDetalleClienteInfo.Catalogo = "N/A";
            objPedidosDetalleClienteInfo.NumeroPedidoPadre = IdPedido;

            objPedidosDetalleClienteInfo.IdCodigoCorto = "FL00";
            objPedidosDetalleClienteInfo.FechaCreacion = DateTime.Now;
            objPedidosDetalleClienteInfo.CatalogoReal = objPedidosDetalleClienteInfo.CatalogoReal;

            objPedidosDetalleClienteInfo.UnidadNegocio = "01";

            KardexInfo objKardexInfo = new KardexInfo();
            Kardex objKardex = new Kardex("conexion");

            objKardexInfo = objKardex.ListxArticuloxPLU(48332);

            //Sino existe en detalle se agrega desde cero.
            if (objKardexInfo != null)
            {
                objPedidosDetalleClienteInfo.UnidadNegocio = objKardexInfo.UnidadNegocio;
                objPedidosDetalleClienteInfo.CatalogoReal = objKardexInfo.Catalogo;
            }

            objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = objPedidosDetalleClienteInfo.Valor;
            objPedidosDetalleClienteInfo.PorcentajeDescuento = 0;

            objPedidosDetalleClienteInfo.Lote = "P000-3357";
            objPedidosDetalleClienteInfo.Ensamblado = 0;
            //*objPedidosDetalleClienteInfo.CantidadPedida = Cantidad; //unidades pedidas del articulo                   
            //objPedidosDetalleClienteInfo.CantidadPedida = PedidoDetalleListTemp[i].Cantidad;
            objPedidosDetalleClienteInfo.CantidadPedida = 1; //Se envia cero para el arreglo del inventario.
            objPedidosDetalleClienteInfo.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CodigoUbicacion = "P000"; //Bodega = 002
            objPedidosDetalleClienteInfo.PLU = 3357;
            objPedidosDetalleClienteInfo.NumeroEnvio = 0;
            objPedidosDetalleClienteInfo.ConceptoContable = "005";
            objPedidosDetalleClienteInfo.CentroCostos = "P000";
            objPedidosDetalleClienteInfo.Grupo = "FT0001";

            return objPedidosDetalleClienteInfo;
        }

        /// <summary>
        /// Crea el detalle de un pedido x ciudad.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="objPremiosArticulosInfo"></param>
        /// <returns></returns>
        private PedidosDetalleClienteInfo CrearFleteDetallePedidoxCiudadEcu(string IdPedido, decimal ValorFleteZona, string Zona, int Excluido, string CodCiudad, decimal PorcentajeIVA, decimal ValorFleteCiudad, bool TipoFlete, int TipoEnvioFlete)
        {
            Parametros objParametros = new Parametros("conexion");

            PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

            objPedidosDetalleClienteInfo.Numero = IdPedido;
            //objPedidosDetalleClienteInfo.Id = IdPedido;
            objPedidosDetalleClienteInfo.Referencia = "FT0001";
            //objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - ZONA: " + Zona;

            //objPedidosDetalleClienteInfo.Valor = ValorFlete;

            objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - SIN TIPO, CIUDAD: " + CodCiudad;

            if (TipoEnvioFlete == (int)TipoEnvioEnum.CasaEmpresaria)
            {
                objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - CIUDAD EMP: " + CodCiudad;
                objPedidosDetalleClienteInfo.Valor = ValorFleteCiudad;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteCiudad;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteCiudad;
            }
            else if (TipoEnvioFlete == (int)TipoEnvioEnum.ADirector)
            {
                objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - ZONA DIRECTOR: " + Zona;
                objPedidosDetalleClienteInfo.Valor = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteZona;
            }
            else if (TipoEnvioFlete == (int)TipoEnvioEnum.ALider)
            {
                objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - ZONA LIDER: " + Zona;
                objPedidosDetalleClienteInfo.Valor = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteZona;
            }

            //si el tipo flete es true es por que es flete normal.
            //if (TipoFlete)
            //{
            //    objPedidosDetalleClienteInfo.Valor = ValorFlete;
            //    objPedidosDetalleClienteInfo.ValorUnitario = ValorFlete;
            //    objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFlete;
            //}
            //else
            //{
            //    objPedidosDetalleClienteInfo.Valor = ValorFleteFull;
            //    objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteFull;
            //    objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteFull;
            //}

            //*objPedidosDetalleClienteInfo.Cantidad = Cantidad; //unidades pedidas del articulo
            objPedidosDetalleClienteInfo.Cantidad = 1;
            objPedidosDetalleClienteInfo.Descuento = 0;
            objPedidosDetalleClienteInfo.Anulado = 0;

            if (Excluido == 1)
            {
                objPedidosDetalleClienteInfo.TarifaIVA = 0;
            }
            else
            {
                //objPedidosDetalleClienteInfo.TarifaIVA = Convert.ToDecimal(objParametros.ListxId((int)ParametrosEnum.ValorIVACOP).Valor);
                objPedidosDetalleClienteInfo.TarifaIVA = PorcentajeIVA;
            }

            objPedidosDetalleClienteInfo.Lote = "P000-3357";
            objPedidosDetalleClienteInfo.Ensamblado = 0;
            //*objPedidosDetalleClienteInfo.CantidadPedida = Cantidad; //unidades pedidas del articulo                   
            //objPedidosDetalleClienteInfo.CantidadPedida = PedidoDetalleListTemp[i].Cantidad;
            objPedidosDetalleClienteInfo.CantidadPedida = 1; //Se envia cero para el arreglo del inventario.
            objPedidosDetalleClienteInfo.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CodigoUbicacion = "P000"; //Bodega = 002
            objPedidosDetalleClienteInfo.PLU = 3357;
            objPedidosDetalleClienteInfo.NumeroEnvio = 0;
            objPedidosDetalleClienteInfo.ConceptoContable = "005";
            objPedidosDetalleClienteInfo.CentroCostos = "P000";
            objPedidosDetalleClienteInfo.Grupo = "FT0001";
            objPedidosDetalleClienteInfo.Imagen = "Flete Asignado desde SVDN. Fecha: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CantidadNivelServicio = 0;
            //objPedidosDetalleClienteInfo.ValorPrecioCatalogo = 0;

            //si el tipo flete es true es por que es flete normal.
            //if (TipoFlete)
            //{
            //    objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFlete;
            //    objPedidosDetalleClienteInfo.ValorUnitario = ValorFlete;
            //    objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFlete;
            //}
            //else
            //{
            //    objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFleteFull;
            //    objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteFull;
            //    objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteFull;
            //}

            if (TipoEnvioFlete == (int)TipoEnvioEnum.CasaEmpresaria)
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFleteCiudad;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteCiudad;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteCiudad;
            }
            else if (TipoEnvioFlete == (int)TipoEnvioEnum.ADirector)
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteZona;
            }
            else if (TipoEnvioFlete == (int)TipoEnvioEnum.ALider)
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteZona;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteZona;
            }

            //objPedidosDetalleClienteInfo.IVAPrecioCatalogo = 0;
            objPedidosDetalleClienteInfo.IVAPrecioCatalogo = objPedidosDetalleClienteInfo.TarifaIVA;
            objPedidosDetalleClienteInfo.Catalogo = "N/A";
            objPedidosDetalleClienteInfo.NumeroPedidoPadre = IdPedido;

            objPedidosDetalleClienteInfo.IdCodigoCorto = "FL00";
            objPedidosDetalleClienteInfo.FechaCreacion = DateTime.Now;
            objPedidosDetalleClienteInfo.CatalogoReal = objPedidosDetalleClienteInfo.CatalogoReal;

            objPedidosDetalleClienteInfo.UnidadNegocio = "01";

            KardexInfo objKardexInfo = new KardexInfo();
            Kardex objKardex = new Kardex("conexion");

            objKardexInfo = objKardex.ListxArticuloxPLU(3357);

            //Sino existe en detalle se agrega desde cero.
            if (objKardexInfo != null)
            {
                objPedidosDetalleClienteInfo.UnidadNegocio = objKardexInfo.UnidadNegocio;
                objPedidosDetalleClienteInfo.CatalogoReal = objKardexInfo.Catalogo;
            }

            objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = objPedidosDetalleClienteInfo.Valor;
            objPedidosDetalleClienteInfo.PorcentajeDescuento = 0;

            return objPedidosDetalleClienteInfo;
        }


        /// <summary>
        /// Bloquea todos los pedidos a los cuales las empresarias tiene el estado en prospecto.
        /// Si no se ha aprobado la empresaria se debe bloquear el pedido.
        /// </summary>
        public void BloquearPedidosxProspectos_Borrar()
        {

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }

        /// <summary>
        /// Bloquea todos los pedidos a los cuales las empresarias tiene el estado en prospecto.
        /// Si no se ha aprobado la empresaria se debe bloquear el pedido.
        /// </summary>
        public void ProcesarHistoricoClientes_Borrar()
        {

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }

        /// <summary>
        /// Bloquea todos los pedidos a los cuales las empresarias tiene el estado en prospecto.
        /// Si no se ha aprobado la empresaria se debe bloquear el pedido.
        /// </summary>
        public void BloquearPedidosxProspectos()
        {
            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE MIGRACION DE CLIENTES. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;


                #region "BLOQUEAR PEDIDOS PROSPECTOS"

                //-----------------------------------------------------------------------------------------------------
                //BLOQUEAR LOS PEDIDOS DE EMPRESARIAS PROSPECTO
                //1. Obtener los clientes prospecto
                //2. bloquear los pedidos de los clientes prospecto

                //Se obtiene la campaña de la fecha actual.
                Campana ObjCampana = new Campana("conexion");
                CampanaInfo ObjCampanaInfo = new CampanaInfo();
                //ObjCampanaInfo = ObjCampana.ListxGetDate();

                if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                {
                    ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                }
                else
                {
                    ObjCampanaInfo = ObjCampana.ListxGetDate();
                }

                //Se valida que exista una campaña activa.
                if (ObjCampanaInfo != null)
                {
                    List<PedidosClienteInfo> objPedidosClienteInfoList = new List<PedidosClienteInfo>();

                    List<ClienteInfo> objClienteInfoList = new List<ClienteInfo>();
                    Cliente objCliente = new Cliente("conexion");

                    //Se obtienen los clientes de SVDN prospecto.
                    objClienteInfoList = objCliente.ListClientesProspecto();

                    if (objClienteInfoList != null && objClienteInfoList.Count > 0)
                    {
                        foreach (ClienteInfo objClienteInfo in objClienteInfoList)
                        {
                            objPedidosClienteInfoList = ListPedidosxNitxCampana(objClienteInfo.Nit, ObjCampanaInfo.Campana);

                            foreach (PedidosClienteInfo PedidoBloquear in objPedidosClienteInfoList)
                            {
                                if (PedidoBloquear.IdEstado == 0 && PedidoBloquear.Anulado == 0 && PedidoBloquear.Procesado == false)
                                {
                                    //Se bloquea el pedido de esa empresaria.
                                    bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoBloquear.Numero, (int)EstadosPedidoEnum.SinAprobarEmpresariaProspecto);

                                    if (okTrasnEstadoPed)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "Se Bloqueo pedido de empresaria:" + objClienteInfo.Nit + " Pedido Numero: " + PedidoBloquear.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI ERROR PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "No se pudo bloquear pedido de empresaria:" + objClienteInfo.Nit + " Pedido Numero: " + PedidoBloquear.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }
                            }
                        }

                        okProcess = true;

                        consecutivo = consecutivo + 1;
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO HAY CLIENTES NUEVOS PARA MIGRAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        okProcess = false;
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR POR EMPRESARIAS PROSPECTO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR POR EMPRESARIAS PROSPECTO OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //...........................................................................
                    //Dispara el evento de que termino el proceso ok.                                               
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //...........................................................................
                }
                //..............................................................................................................................

                #endregion


                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE MIGRACION DE CLIENTES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR EMPRESARIAS PROSPECTO: PROCESO DE MIGRACION DE CLIENTES TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));


            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI ERROR BLOQUEAR POR EMPRESARIAS PROSPECTO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Bloquear los pedidos de un cliente con saldo de cartera positivo. 
        /// (El saldo de cartera negativo es bueno para la empresaria por que significa que el cliente tiene dinero a favor. 
        /// Si el saldo es mayor al parametro de valor cartera significa que el cliente tiene deuda con niviglobal)
        /// </summary>
        public void BloquearPedidosxCartera()
        {

            //*UnificarPedidosCatalogos();

            //NOTA: ESTE PROCESO SE DEBE CORRER ANTES DE COMENZAR CON LA ASIGNACION INVENTARIO, Y ANTES DE REALIZARLO SE DEBEN COPIAR LOS CLIENTES DE SVDN A NIVI.

            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.


            string MesFormato = DateTime.Today.Month.ToString();
            //Para anteponer el 0 en el mes por que la tabla recibe: ej: 201203
            if (Convert.ToInt32(MesFormato) < 10)
            {
                MesFormato = "0" + MesFormato;
            }

            string Mes = DateTime.Today.Year.ToString() + MesFormato;

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene saldo en cartera se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            MailGroup ObjMailGroup = new MailGroup("conexion");
            List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            {
                //Se realiza la asignacion de pedidos para cada mailgroup.
                foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        Zona ObjZona = new Zona("conexion");
                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        //Se valida que existan zonas para el mailgroup actual.
                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE BLOQUEAR POR CARTERA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();

                                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                                ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaNoBloqueado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                                {

                                    CxCInfo objCxCInfo = new CxCInfo();
                                    CxC objCxC = new CxC("conexion");

                                    //Se bloquean los pedidos de clientes que tengan saldo de cartera > valorcartera.
                                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                                    {
                                        //Se obtiene el saldo de cartera del cliente del pedido.
                                        objCxCInfo = objCxC.ListxNitxMes(PedidoNoBloqueado.Nit, Mes);

                                        if (objCxCInfo != null)
                                        {
                                            ParametrosInfo objParametrosInfo = new ParametrosInfo();
                                            Parametros objParametros = new Parametros("conexion");

                                            //Se obtiene el parametro de cartera para comparar si supera la cartera.
                                            objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.ValorCartera);

                                            //Si el saldo del cliente supera la cartera se bloquea el pedido.
                                            if (objCxCInfo.SaldoTotal >= Convert.ToDecimal(objParametrosInfo.Valor))
                                            {
                                                bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoNoBloqueado.Numero, (int)EstadosPedidoEnum.Cartera);

                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: EL PEDIDO HA SIDO RETENIDO POR SALDO EN CARTERA = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoNoBloqueado.Numero + " NIT:" + PedidoNoBloqueado.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;
                                    }
                                }
                            }

                            //System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X CARTERA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //...........................................................................
                    //Dispara el evento de que termino el proceso ok.                                               
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //...........................................................................
                }
                //..............................................................................................................................


                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE ASIGNACIÓN DE BLOQUEAR POR CARTERA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Bloquear los pedidos de un cliente con saldo de cartera positivo. 
        /// (El saldo de cartera negativo es bueno para la empresaria por que significa que el cliente tiene dinero a favor. 
        /// Si el saldo es mayor al parametro de valor cartera significa que el cliente tiene deuda con niviglobal)
        /// </summary>
        public void BloquearPedidosxCarteraEcuador()
        {
            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }


        /// <summary>
        /// Eliminar este metodo y habilitar el de abajo para que funcione el
        /// bloqueo de desmanteladoras.
        /// </summary>
        public void BloquearPedidosxDesmanteladora()
        {

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }

        /// <summary>
        /// Bloquear los pedidos de un cliente cuando es desmanteladora. 
        /// Solo a los clientes con semaforo verde se les procesa el pedido.
        /// </summary>
        public void BloquearPedidosxDesmanteladoraACTIVARESTEMETODOPARADESMATELADORAS()
        {
            //NOTA: ESTE PROCESO SE DEBE CORRER ANTES DE COMENZAR CON LA ASIGNACION INVENTARIO, Y ANTES DE REALIZARLO SE DEBEN COPIAR LOS CLIENTES DE SVDN A NIVI.

            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.


            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE SEMAFORO DIFERENTE DE VERDE Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE.
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene semaforo diferente de verde y se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            MailGroup ObjMailGroup = new MailGroup("conexion");
            List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            {
                //Se realiza la asignacion de pedidos para cada mailgroup.
                foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        Zona ObjZona = new Zona("conexion");
                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        //Se valida que existan zonas para el mailgroup actual.
                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE BLOQUEAR POR CARTERA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //contar cantidad total de pedidos para mostrar en formulario de presentacion.
                            int totalpedidos = 0;


                            //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();

                                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                                ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaNoBloqueado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                                {

                                    ClienteInfo objClienteInfo = new ClienteInfo();
                                    Cliente objCliente = new Cliente("conexion");

                                    //Se bloquean los pedidos de clientes que tengan saldo de cartera > valorcartera.
                                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                                    {
                                        objClienteInfo = objCliente.ListClienteNivixNit(PedidoNoBloqueado.Nit);

                                        if (objClienteInfo != null)
                                        {
                                            //Si el cliente no tiene estado 0 ó 1 ó 2 es por que es desmantelador.
                                            if (objClienteInfo.Desmantelados > 2)
                                            {
                                                bool okTrasnEstadoPed = this.UpdateEstadoPedido(PedidoNoBloqueado.Numero, (int)EstadosPedidoEnum.Desmanteladora);

                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: EL PEDIDO HA SIDO RETENIDO POR DESMANTELADORA = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoNoBloqueado.Numero + " NIT:" + PedidoNoBloqueado.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;

                                    }
                                }
                            }


                            ///System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X DESMANTELADORA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //...........................................................................
                    //Ejecuta el evento cada que se ejecuta un ciclo.                                               
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //...........................................................................

                }
                //..............................................................................................................................


                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR DESMANTELADORA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: PROCESO DE BLOQUEAR DESMANTELADORA TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Bloquea los pedidos por el nivel de servicio del pedido por Cantidad.
        /// </summary>
        /// <returns></returns>
        public void BloquearPedidosxNivelServicioCantidad()
        {
            bool okProcess = false;


            //99999999999999999999999999999999999
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.                                               
            int si_nivelservicio = 0; //almacena la cantidad que si aplicaron el nivel de servicio.
            int no_nivelservicio = 0; //amacena la cantidad que no aplicaron el nivel de servicio.

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE NIVEL DE SERVICIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroup = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                {
                    //Se realiza la asignacion de pedidos para cada mailgroup.
                    foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se obtiene la campaña de la fecha actual.
                        Campana ObjCampana = new Campana("conexion");
                        CampanaInfo ObjCampanaInfo = new CampanaInfo();
                        //ObjCampanaInfo = ObjCampana.ListxGetDate();

                        if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                        {
                            ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                        }
                        else
                        {
                            ObjCampanaInfo = ObjCampana.ListxGetDate();
                        }

                        //Se valida que exista una campaña activa.
                        if (ObjCampanaInfo != null)
                        {

                            //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                            //1. Borrar tabla inventario para solo almacenar lo actual.
                            //2. Consultar saldos bodega.
                            //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                            //4. Consultar pedidos ordenados por orden de procesamiento.
                            //5. Actualizar el campo de cantidad pedida con respecto al inventario en el detalle del pedido.
                            //6. Restar cantidad actualizada a los saldos de inventario.

                            Inventario ObjInventario = new Inventario("conexion");

                            //Borrar la tabla de inventario para copiar el inventario actualizado.
                            if (ObjInventario.DeleteAll())
                            {
                                //Se consulta el inventario del mes actual.
                                List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                                ObjInventarioInfoList = ObjInventario.ListSaldosBodega();

                                if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                                    foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                                    {
                                        //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                        if (!ObjInventario.Insert(ItemInventario))
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                    }

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    Zona ObjZona = new Zona("conexion");
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                                    //Se valida que existan zonas para el mailgroup actual.
                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            List<PedidosClienteInfo> ObjPedidosCliente = new List<PedidosClienteInfo>();
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosCliente = ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                            //Se valida si existen pedidos de la zona y la campaña actual.
                                            if (ObjPedidosCliente != null && ObjPedidosCliente.Count > 0)
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));


                                                //Se insertan los pedidos a la tabla temporal.
                                                foreach (PedidosClienteInfo Pedido in ObjPedidosCliente)
                                                {
                                                    bool okInventario = false;

                                                    //Consultar detalle del pedido.
                                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexId(Pedido.Numero);

                                                    //Se valida si existen detalles del pedido.
                                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                                    {
                                                        //Recorre el detalle del pedido.
                                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                            //Consulta el inventario del detalle del pedido especifico.
                                                            InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                                            ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostos("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos
                                                            // ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostos("002", "TM118865", "P008-14618"); //Lote = CCostos


                                                            //BORRAR CANTIDADES DE NIVEL DE SERVICIO.
                                                            ObjPedidosDetalleCliente.UpdateCantidadNivelServicio(ObjPedidoDetalle.Id, 0);

                                                            if (ObjInventarioInfoActual != null)
                                                            {
                                                                //Calcula la cantidad disponible en el inventario
                                                                decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                                //actualiza la cantidad del nivel de servicio del pedido con la cantidad disponible.
                                                                if (ObjPedidosDetalleCliente.UpdateCantidadNivelServicio(ObjPedidoDetalle.Id, CantidadDisp))
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                                    okInventario = true;

                                                                    //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                                    if (ObjInventario.UpdateCantidad("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    //-------------------------------------------------------------------------------
                                                    //Actualiza el nivel del servicio y estado de nivel de servicio.
                                                    if (okInventario)
                                                    {
                                                        //Se obtiene el nivel de servicio esperado para el dia.
                                                        Application.Enterprise.Business.NivelServicio ObjNivelServicio = new Application.Enterprise.Business.NivelServicio("conexion");
                                                        Application.Enterprise.CommonObjects.NivelServicioInfo ObjNivelServicioInfo = new Application.Enterprise.CommonObjects.NivelServicioInfo();

                                                        ObjNivelServicioInfo = ObjNivelServicio.ListxFecha();

                                                        decimal NivelServicioEstimado = 100;

                                                        //Si no hay un nivel de servicio para el dia se consulta el requerido por los parametros del sistema, sino hay en
                                                        //los parametros se asume el 100%.
                                                        if (ObjNivelServicioInfo != null)
                                                        {
                                                            NivelServicioEstimado = ObjNivelServicioInfo.NivelEstimado;
                                                        }
                                                        else
                                                        {
                                                            ParametrosInfo objParametrosInfo = new ParametrosInfo();
                                                            Parametros objParametros = new Parametros("conexion");

                                                            //Se obtiene el parametro de nivel de servicio.
                                                            objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.NivelServicio);

                                                            if (Convert.ToDecimal(objParametrosInfo.Valor) > 0)
                                                            {
                                                                NivelServicioEstimado = Convert.ToDecimal(objParametrosInfo.Valor);
                                                            }
                                                            else
                                                            {
                                                                NivelServicioEstimado = 100;
                                                            }
                                                        }

                                                        //Consultar detalle del pedido para calcular el nivel de servicio.
                                                        PedidosDetalleCliente ObjPedidosDetalleNivelS = new PedidosDetalleCliente("conexion");
                                                        List<PedidosDetalleClienteInfo> ObjPedidosDetalleNivelSInfoList = new List<PedidosDetalleClienteInfo>();
                                                        ObjPedidosDetalleNivelSInfoList = ObjPedidosDetalleNivelS.ListPedidoDetallexId(Pedido.Numero);

                                                        decimal CantidadTotalPedidoRequerida = 0;
                                                        decimal CantidadTotalPedidoExistente = 0;

                                                        if (ObjPedidosDetalleNivelSInfoList != null && ObjPedidosDetalleNivelSInfoList.Count > 0)
                                                        {
                                                            //recorre el detalle del pedido y se suma la cantidad total requerida y la real existente.
                                                            foreach (PedidosDetalleClienteInfo PedidoDetalleTotal in ObjPedidosDetalleNivelSInfoList)
                                                            {
                                                                //CantidadTotalPedidoRequerida = cantidad total que se pidio por el cliente.
                                                                CantidadTotalPedidoRequerida = CantidadTotalPedidoRequerida + PedidoDetalleTotal.Cantidad;
                                                                //CantidadTotalPedidoExistente = cantidad que existe para mirar el nivel de servicio asignada dependiendo el inventario existente.
                                                                CantidadTotalPedidoExistente = CantidadTotalPedidoExistente + PedidoDetalleTotal.CantidadNivelServicio;
                                                            }
                                                        }

                                                        //Se realiza la operacion para saber que porcentaje se obtuvo realmente.
                                                        decimal NivelServicioReal = (CantidadTotalPedidoExistente * 100) / CantidadTotalPedidoRequerida;

                                                        //Se realiza la operacion para saber si la cantidad real supera el nivel de servicio esperado.
                                                        if (NivelServicioReal >= NivelServicioEstimado)
                                                        {
                                                            //true si cumple con el nivel de servicio.
                                                            if (UpdateNivelServicio(Pedido.Numero, true, NivelServicioEstimado, NivelServicioReal, "Por Cantidad"))
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CUMPLIO EL NIVEL DE SERVICIO, SE ACTUALIZO ESTADO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                si_nivelservicio = si_nivelservicio + 1;
                                                            }
                                                            else
                                                            {
                                                                bool okTrasnEstadoPed = this.UpdateEstadoPedido(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //si no cumple con el nivel de servicio el estado es false.
                                                            if (UpdateNivelServicio(Pedido.Numero, false, NivelServicioEstimado, NivelServicioReal, "Por Cantidad"))
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE CUMPLIO NIVEL DE SERVICIO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                                bool okTrasnEstadoPed = this.UpdateEstadoPedido(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);

                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR X NIVEL DE SERVICIO POR CANTIDAD: EL PEDIDO HA SIDO RETENIDO POR NIVEL DE SERVCIO POR CANTIDAD = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", Pedido.Numero + " NIT:" + Pedido.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));


                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                no_nivelservicio = no_nivelservicio + 1;
                                                            }
                                                        }

                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;
                                                    }
                                                    else
                                                    {
                                                        //SI ENTRO AQUI ES POR QUE NO EXISTEN NISIQUIERA UNA UNIDAD DE LOS ARTICULOS REQUERIDOS EN EL DETALLE DEL PEDIDO.

                                                        //SE BLOQUEA POR NIVEL DE SERVICIO.
                                                        bool okTrasnEstadoPed = this.UpdateEstadoPedido(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);

                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR X NIVEL DE SERVICIO POR CANTIDAD: EL PEDIDO HA SIDO RETENIDO POR NIVEL DE SERVCIO POR CANTIDAD = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", Pedido.Numero + " NIT:" + Pedido.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                                        okProcess = true;

                                                        //Contador de pedidos
                                                        consecutivo = consecutivo + 1;

                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                }

                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO NIVEL DE SERVICIO POR CANTIDAD OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                                                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                                                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                            else
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }

                    //..............................................................................................................................
                    //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                    PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                    if (okProcess == false)
                    {

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X NIVEL DE SERVICIO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //.......................................................................................
                        //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //.......................................................................................
                    }
                    else if (okProcess == true)
                    {

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //..............................................................................
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                            ObjPedidosClienteProcesadoInfo.TotalSiCumplenNivelServicio = si_nivelservicio;
                            ObjPedidosClienteProcesadoInfo.TotalNoCumplenNivelServicio = no_nivelservicio;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //..............................................................................

                    }

                    //..............................................................................................................................
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }

                okProcess = true;

                //se debe borrar la tabla temporal para que no se bloqueé el proceso siguiente.
                DeleteTemporal();
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //* return okProcess;
        }

        /// <summary>
        /// Este metodo copia los pedidos procesados en la base de datos de nivi (pedidosc1_2000 y pedidosc2_2000).
        /// Los pedidos copiados no tienen ningun bloqueo y contienen los premios y fletes asignados.
        /// </summary>
        public void ProcesarPedidosFacturar()
        {
            //NOTA: ESTE PROCESO ANTES DE REALIZARLO SE DEBEN COPIAR LOS CLIENTES DE SVDN A NIVI.

            bool okProcess = false;
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            List<PedidosClienteInfo> ObjListPedidosHistoricoClientes = new List<PedidosClienteInfo>();

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene saldo en cartera se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            MailGroup ObjMailGroup = new MailGroup("conexion");
            List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            {
                //Se realiza la asignacion de pedidos para cada mailgroup.
                foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        Zona ObjZona = new Zona("conexion");
                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        //Se valida que existan zonas para el mailgroup actual.
                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESAR PARA FACTURAR  .", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla de nivi (pedidosc1_2000).
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosFacturarZonaCampana = new List<PedidosClienteInfo>();

                                //Se obtienen los pedidos de las zonas y campañas que estan listos para facturar.
                                ObjListPedidosFacturarZonaCampana = ListPedidoFacturar(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosFacturarZonaCampana != null && ObjListPedidosFacturarZonaCampana.Count > 0)
                                {
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    foreach (PedidosClienteInfo PedidoFacturar in ObjListPedidosFacturarZonaCampana)
                                    {
                                        if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
                                        {
                                            PedidoFacturar.Mes = DateTime.Now.Year.ToString() + "0" + DateTime.Now.Month.ToString();
                                        }
                                        else
                                        {
                                            PedidoFacturar.Mes = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
                                        }

                                        PedidoFacturar.IdLider = PedidoFacturar.Vendedor;

                                        if (InsertFacturar(PedidoFacturar))
                                        {
                                            bool okUpdateProd = UpdateEnProduccion(PedidoFacturar.Numero, true);

                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE INGRESO ENCABEZADO DE PEDIDO OK No: " + PedidoFacturar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                            //Se guarda en la lista para el historial de estados de los clientes.
                                            ObjListPedidosHistoricoClientes.Add(PedidoFacturar);

                                            List<PedidosDetalleClienteInfo> objPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();

                                            //Se consulta el detalle de un pedido 
                                            objPedidosDetalleClienteInfoList = objPedidosDetalleCliente.ListDetallePedidoxNumeroProcesamientoExportar(PedidoFacturar.Numero);

                                            if (objPedidosDetalleClienteInfoList != null && objPedidosDetalleClienteInfoList.Count > 0)
                                            {
                                                int contadorDetalle = 0;

                                                decimal Valor = 0;
                                                decimal Iva = 0;

                                                foreach (PedidosDetalleClienteInfo objPedidosDetalleClienteInfo in objPedidosDetalleClienteInfoList)
                                                {
                                                    #region "Crear Centro de Costos"
                                                    //-------------------------------------------------------------------------------------
                                                    //Crear Centro de Costos.
                                                    CentroCostosInfo objCentroCostosInfo = new CentroCostosInfo();
                                                    CentroCostos objCentroCostos = new CentroCostos("conexion");

                                                    //Seconsulta el ccostos, si existe se crea uno nuevo, sino 
                                                    objCentroCostosInfo = objCentroCostos.ListxCCostos(objPedidosDetalleClienteInfo.Lote);

                                                    if (objCentroCostosInfo == null)
                                                    {
                                                        CentroCostosInfo objCentroCostosInsertInfo = new CentroCostosInfo();

                                                        objCentroCostosInsertInfo.CCostos = objPedidosDetalleClienteInfo.Lote;
                                                        objCentroCostosInsertInfo.Descripcion = "Lote Nro:" + objPedidosDetalleClienteInfo.Lote + ", Creado Por:SVDN";
                                                        objCentroCostosInsertInfo.Fecha = DateTime.Now;
                                                        objCentroCostosInsertInfo.CuentaAjusteinventarios = "";
                                                        objCentroCostosInsertInfo.CuentaAjusteCMV = "";
                                                        objCentroCostosInsertInfo.CentroCostos = "";

                                                        char[] delimiterChars = { '-' };
                                                        string[] CCostosArray = objPedidosDetalleClienteInfo.Lote.Split(delimiterChars);

                                                        objCentroCostosInsertInfo.CodUbicacion = CCostosArray[0];
                                                        objCentroCostosInsertInfo.PLU = Convert.ToDecimal(CCostosArray[1]);

                                                        if (!objCentroCostos.Insert(objCentroCostosInsertInfo))
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GRABAR EL CENTRO DE COSTOS: " + objPedidosDetalleClienteInfo.Lote, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                    //-------------------------------------------------------------------------------------
                                                    #endregion

                                                    //Dividir el valor del articulo entre las cantidades para quie G&G fature y haga el proceso de articulo * cantidad.
                                                    //*se cambio por le nuevo modelo de reserva
                                                    //objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.Valor / objPedidosDetalleClienteInfo.Cantidad;
                                                    //*objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.ValorUnitario; //--se quito la linea anterior por la cantidad.

                                                    objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.Valor / objPedidosDetalleClienteInfo.Cantidad; //--se quito la linea anterior por que aqui ya viene el valor con el desucento aplicado.

                                                    //Se resta el valor del articulo si la cantidad es cero.
                                                    if (objPedidosDetalleClienteInfo.CantidadPedida == 0)
                                                    {
                                                        Valor = Valor - (objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.CantidadPedida);
                                                        Iva = Iva - ((objPedidosDetalleClienteInfo.Valor * (objPedidosDetalleClienteInfo.TarifaIVA / 100)) * objPedidosDetalleClienteInfo.CantidadPedida);
                                                    }

                                                    //Se inserta el detalle del pedido en produccion.
                                                    if (objPedidosDetalleCliente.InsertDetalleFacturar(objPedidosDetalleClienteInfo))
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE INGRESO DETALLE DE PEDIDO OK No: " + PedidoFacturar + " ID DET: " + objPedidosDetalleClienteInfo.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        okProcess = true;
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR EL DETALLE PEDIDO EN LA BD DE NIVI. No: " + PedidoFacturar.Numero + "ID DET: " + objPedidosDetalleClienteInfo.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    Valor = Valor + (objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.CantidadPedida);
                                                    Iva = Iva + ((objPedidosDetalleClienteInfo.Valor * (objPedidosDetalleClienteInfo.TarifaIVA / 100) * objPedidosDetalleClienteInfo.CantidadPedida));

                                                    //--------------------------------------------
                                                    //Proceso de actualizacion del valor del pedido con las sumas y restas de las cantidades 0.

                                                    if (contadorDetalle >= (objPedidosDetalleClienteInfoList.Count - 1))
                                                    {
                                                        if (this.UpdateValorPedido(PedidoFacturar.Numero, Valor, Iva))
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO VALOR DE PEDIDO POR CANTIDAD 0 OK No: " + PedidoFacturar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO VALOR DE PEDIDO POR CANTIDAD 0 No: " + PedidoFacturar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        contadorDetalle++;
                                                    }

                                                    //--------------------------------------------
                                                }
                                            }
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR EL ENCABEZADO EN LA BD DE NIVI DEL PEDIDO: " + PedidoFacturar, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }


                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;

                                    }
                                }
                            }



                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //AQUI SE ASIGNAN LOS FLETES.
                            //ESTE PROCEDIMIENTO SE DEBE REALIZAR DESPUES DE ASIGNAR LOS PREMIOS POR QUE AQUI SE SUMAN EL FLETE Y EL IVA AL PEDIDO PARA PASAR A PRODUCCION.
                            #region "ASIGNACION DE FLETES"

                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                            Ciudad ObjCiudad = new Ciudad("conexion");

                            Application.Enterprise.Business.Cliente objCliente = new Application.Enterprise.Business.Cliente("conexion");

                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACION DE FLETES.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();
                                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                                ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaSumarFlete(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben insertar todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                                {
                                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();
                                    List<PedidosDetalleClienteInfo> objPedidoFleteInfo = new List<PedidosDetalleClienteInfo>();
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    //Se inserta el flete en el detalle del pedido.
                                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                                    {
                                        //Validar si el pedido es un anexo no debe llevar flete. si anexo = 0 SI lleva flete.
                                        if (PedidoNoBloqueado.Anexo == 0)
                                        {
                                            //se consulta si ese pedido ya tiene asignado un flete.
                                            objPedidoFleteInfo = objPedidosDetalleCliente.ListPedidoFlete(PedidoNoBloqueado.Numero);

                                            //sino tiene asignado un flete se crea el detalle del pedido y se inserta.
                                            if (objPedidoFleteInfo.Count == 0 || objPedidoFleteInfo == null)
                                            {
                                                //Valida que si es un segundo o tercer pedido no se cobra el flete.
                                                List<PedidosClienteInfo> ObjListPedidosNitCampanaConFlete = new List<PedidosClienteInfo>();
                                                //*Habilitar esta linea para quitar el flete al seguno o tercer pedido = ObjListPedidosNitCampanaConFlete = this.ListxNitxCampanaPedidosGYG(PedidoNoBloqueado.Nit, PedidoNoBloqueado.Campana);

                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                                CiudadInfo ObjCiudadInfo = new CiudadInfo();
                                                Application.Enterprise.CommonObjects.ClienteInfo objClienteInfo = new Application.Enterprise.CommonObjects.ClienteInfo();

                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                                                //si no tiene mas de un pedido entonces hay que ponerle flete, si hay mas de uno no se asigna flete a los siguientes.
                                                if (ObjListPedidosNitCampanaConFlete.Count == 0 || ObjListPedidosNitCampanaConFlete == null)
                                                {
                                                    //Crear el detalle del flete para el pedido.
                                                    //objPedidosDetalleClienteInfo = CrearFleteDetallePedido(PedidoNoBloqueado.Numero, ZonaMailGroup.ValorFlete, ZonaMailGroup.Zona, ZonaMailGroup.Excluido);

                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                                                    string CodCiudadCliente = "";
                                                    int TipoPedidoMinimo = 0;

                                                    //Se obtiene el codigo de la ciudad para el flete.
                                                    objClienteInfo = objCliente.ListClienteSVDNxNit(PedidoNoBloqueado.Nit);

                                                    if (objClienteInfo != null)
                                                    {
                                                        CodCiudadCliente = objClienteInfo.CodCiudad;
                                                        TipoPedidoMinimo = objClienteInfo.TipoPedidoMinimo;
                                                    }
                                                    //se obtiene la info de la ciudad del cliente.
                                                    ObjCiudadInfo = ObjCiudad.ListCiudadxId(CodCiudadCliente);

                                                    string okTrans = "";

                                                    if (ObjCiudadInfo != null)
                                                    {
                                                        //aqui validar si es flete normal o flete full

                                                        List<PedidosDetalleClienteInfo> objDetPedido = new List<PedidosDetalleClienteInfo>();
                                                        objDetPedido = objPedidosDetalleCliente.ListDetallePedidoxNumero(PedidoNoBloqueado.Numero);

                                                        //Se valida que tipo de flete se debe asignar al pedido. Si es true es flete normal.
                                                        bool TipoFlete = ValidarPedidoMinimoxTipoParaFlete(TipoPedidoMinimo, PedidoNoBloqueado.ValorPrecioCat, objDetPedido);

                                                        objPedidosDetalleClienteInfo = CrearFleteDetallePedidoxCiudad(PedidoNoBloqueado.Numero, ObjCiudadInfo.ValorFlete, ZonaMailGroup.Zona, ObjCiudadInfo.ExcluidoIVA, CodCiudadCliente, ObjCiudadInfo.IVA, ObjCiudadInfo.ValorFleteFull, TipoFlete);

                                                        //Inserta el flete en G&G
                                                        okTrans = objPedidosDetalleCliente.InsertFlete(objPedidosDetalleClienteInfo);

                                                        //Inserta el flete en SVDN
                                                        string IdPedidoDetalleSVDN = objPedidosDetalleCliente.Insert(objPedidosDetalleClienteInfo);
                                                    }
                                                    else
                                                    {
                                                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();
                                                        Auditoria objAuditoria = new Auditoria("conexion");

                                                        objAuditoriaInfo.Proceso = "No se creo el flete para el Pedido: " + PedidoNoBloqueado.Numero + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente por parte de IDN.";
                                                        objAuditoriaInfo.Usuario = PedidoNoBloqueado.ClaveUsuario + " + Procesamiento SVDN.";
                                                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                                                        objAuditoria.Insert(objAuditoriaInfo);

                                                    }

                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                                    if (okTrans == "" || okTrans == null)
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PREMIOS - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO CREAR FLETE PARA PEDIDO: " + okTrans, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                    else
                                                    {
                                                        //decimal ValorPedConFlete = PedidoNoBloqueado.Valor + objPedidosDetalleClienteInfo.Valor;

                                                        decimal ValorPedConFlete = PedidoNoBloqueado.Valor + objPedidosDetalleClienteInfo.Valor;

                                                        decimal ValorPedIvaConFlete = 0;

                                                        //Verifica si la zona esta excluida de iva para no cobrarla.
                                                        //if (ZonaMailGroup.Excluido == 1)
                                                        //{
                                                        //    ValorPedIvaConFlete = PedidoNoBloqueado.IVA;
                                                        //}
                                                        //else
                                                        //{
                                                        //    ValorPedIvaConFlete = PedidoNoBloqueado.IVAPrecioCat + (objPedidosDetalleClienteInfo.Valor * (objPedidosDetalleClienteInfo.TarifaIVA / 100));
                                                        //}


                                                        if (ObjCiudadInfo != null)
                                                        {
                                                            if (ObjCiudadInfo.ExcluidoIVA == 1)
                                                            {
                                                                ValorPedIvaConFlete = PedidoNoBloqueado.IVA;
                                                            }
                                                            else
                                                            {
                                                                ValorPedIvaConFlete = PedidoNoBloqueado.IVA + (objPedidosDetalleClienteInfo.Valor * (ObjCiudadInfo.IVA / 100));
                                                            }
                                                        }

                                                        decimal ValorPedFleteCat = PedidoNoBloqueado.ValorPrecioCat + (objPedidosDetalleClienteInfo.Valor);
                                                        decimal IvaPedFleteCat = PedidoNoBloqueado.IVAPrecioCat + ((objPedidosDetalleClienteInfo.Valor) * (ObjCiudadInfo.IVA / 100));

                                                        //Actualiza el valor del flete en la tabla de nivi
                                                        bool UpdateValorFlete = this.UpdateValorPedido(PedidoNoBloqueado.Numero, ValorPedConFlete, ValorPedIvaConFlete);

                                                        if (UpdateValorFlete)
                                                        {
                                                            //Actualiza el valor del flete en la tabla de svdn
                                                            bool UpdateValorFleteSVDN = this.UpdateValorPedidoSVDN(PedidoNoBloqueado.Numero, ValorPedConFlete, ValorPedIvaConFlete);

                                                            if (UpdateValorFleteSVDN)
                                                            {
                                                                //Actualiza el valor precio catalogo despues de agregar el valor del premio.
                                                                UpdateValoresPrecioCatalogo(PedidoNoBloqueado.Numero, ValorPedFleteCat, IvaPedFleteCat);

                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS  - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CREO EL FLETE CORRECTAMENTE PARA EL PEDIDO: " + PedidoNoBloqueado.Numero + " VALOR: " + ZonaMailGroup.ValorFlete + " ZONA: " + ZonaMailGroup.Zona, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL FLETE AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL FLETE AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "EL PEDIDO YA TIENE ASIGNADO UN FLETE. PEDIDO No: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }
                                    }
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS : {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNACION DE FLETES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            #endregion

                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-


                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]

                            //AQUI SE ASIGNAN LOS PREMIOS DE BIENVENIDA.
                            //ESTE PROCEDIMIENTO SE DEBE REALIZAR DESPUES DE ASIGNAR LOS PREMIOS DE BIENVENIDA.
                            #region "ASIGNACION DE PREMIO DE BIENVENIDA"


                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACION DE FLETES.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();
                                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                                ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaSumarFlete(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben insertar todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                                {
                                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();
                                    List<PedidosDetalleClienteInfo> objPedidoFleteInfo = new List<PedidosDetalleClienteInfo>();
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    //Se inserta el flete en el detalle del pedido.
                                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                                    {

                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                        Application.Enterprise.CommonObjects.ClienteInfo objClienteInfo = new Application.Enterprise.CommonObjects.ClienteInfo();

                                        int PremioBienvenida = 0;
                                        int TipoPedidoMinimo = 0;

                                        //Se obtiene el codigo de la ciudad para el flete.
                                        objClienteInfo = objCliente.ListClienteSVDNxNit(PedidoNoBloqueado.Nit);

                                        if (objClienteInfo != null)
                                        {
                                            PremioBienvenida = objClienteInfo.Premio;
                                            TipoPedidoMinimo = objClienteInfo.TipoPedidoMinimo;
                                        }


                                        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                                        //Si el cliente no ha recibido premio de bienvenido se adiciona en el detalle.
                                        if (PremioBienvenida == 0)
                                        {
                                            decimal ValorPrecioCatPremio = 0;
                                            decimal IVAPrecioCatPremio = 0;

                                            List<PedidosDetalleClienteInfo> objDetPedido = new List<PedidosDetalleClienteInfo>();
                                            objDetPedido = objPedidosDetalleCliente.ListDetallePedidoxNumero(PedidoNoBloqueado.Numero);

                                            foreach (PedidosDetalleClienteInfo item in objDetPedido)
                                            {
                                                //Se suma el valor del pre
                                                if (!item.IdCodigoCorto.StartsWith("FL"))
                                                {
                                                    //Se valida que no sean productos ni outlet nivi, outlet pisame, hogar.
                                                    if (!item.CatalogoReal.StartsWith("T") && !item.CatalogoReal.StartsWith("L") && !item.CatalogoReal.StartsWith("H"))
                                                    {
                                                        ValorPrecioCatPremio = ValorPrecioCatPremio + (item.ValorPrecioCatalogoUnitario * item.Cantidad);
                                                        IVAPrecioCatPremio = IVAPrecioCatPremio + ((item.ValorPrecioCatalogoUnitario * item.Cantidad) * (item.TarifaIVA / 100));
                                                    }
                                                }
                                            }

                                            Application.Enterprise.Business.Parametros objParametros = new Application.Enterprise.Business.Parametros("conexion");
                                            Application.Enterprise.CommonObjects.ParametrosInfo objParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();

                                            objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.ValorPedidoPremioBienvenida);

                                            if (objParametrosInfo != null)
                                            {
                                                decimal ValorPrecionCatSinFlete = (ValorPrecioCatPremio + IVAPrecioCatPremio);

                                                //Si el pedido cumple con el valor minimo para asignar el premio. 
                                                if (ValorPrecionCatSinFlete >= Convert.ToDecimal(objParametrosInfo.Valor))
                                                {
                                                    //se consultan los premios de bienvenida activos por unidad de negocio.
                                                    List<PedidosDetalleClienteInfo> objPedidosDetallePremiosInfo = objPedidosDetalleCliente.ListPremiosBienvenidaActivos(("0" + TipoPedidoMinimo.ToString()));

                                                    if (objPedidosDetallePremiosInfo != null && objPedidosDetallePremiosInfo.Count > 0)
                                                    {
                                                        foreach (PedidosDetalleClienteInfo Premio in objPedidosDetallePremiosInfo)
                                                        {
                                                            string fecha = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                                                            Premio.Id = PedidoNoBloqueado.Numero + "_PRE_" + fecha;
                                                            Premio.Numero = PedidoNoBloqueado.Numero;
                                                            Premio.NumeroPedidoPadre = PedidoNoBloqueado.Numero;
                                                            Premio.IdDocumentoFuente = DateTime.Now.ToString();
                                                            Premio.Catalogo = PedidoNoBloqueado.Codigo;
                                                            Premio.CatalogoReal = Premio.Catalogo;
                                                            Premio.IdCodigoCorto = "PRE00";
                                                            Premio.PorcentajeDescuento = 0;
                                                            Premio.CentroCostos = PedidoNoBloqueado.Zona;
                                                            Premio.Lote = Premio.CodigoUbicacion + "-" + Premio.PLU;

                                                            PedidosClienteInfo PedidoEnc = ListPedidoxId(PedidoNoBloqueado.Numero);

                                                            decimal ValorPedPremio = PedidoEnc.Valor + (Premio.Valor * Premio.Cantidad);
                                                            decimal IvaPedPremio = PedidoEnc.IVA + ((Premio.Valor * Premio.Cantidad) * (Premio.TarifaIVA / 100));

                                                            decimal ValorPedPremioCat = PedidoEnc.ValorPrecioCat + (Premio.ValorPrecioCatalogoUnitario * Premio.Cantidad);
                                                            decimal IvaPedPremioCat = PedidoEnc.IVAPrecioCat + ((Premio.ValorPrecioCatalogoUnitario * Premio.Cantidad) * (Premio.TarifaIVA / 100));

                                                            //inserta el premio en SVDN.
                                                            string IdPedidoDetallePremio = objPedidosDetalleCliente.Insert(Premio);

                                                            if (IdPedidoDetallePremio != "" && IdPedidoDetallePremio != null)
                                                            {
                                                                //Inserta el premio en G&G
                                                                bool okTrans = objPedidosDetalleCliente.InsertDetalleFacturar(Premio);

                                                                //Actualiza el valor del premio en el encabezado del pedido.
                                                                bool UpdateValorPremio = this.UpdateValorPedido(PedidoNoBloqueado.Numero, ValorPedPremio, IvaPedPremio);

                                                                if (UpdateValorPremio)
                                                                {
                                                                    //Actualiza el valor del premio en el encabezado del pedido en la tabla de svdn
                                                                    bool UpdateValorFleteSVDN = this.UpdateValorPedidoSVDN(PedidoNoBloqueado.Numero, ValorPedPremio, IvaPedPremio);

                                                                    if (UpdateValorFleteSVDN)
                                                                    {
                                                                        //Actualiza el valor precio catalogo despues de agregar el valor del premio.
                                                                        UpdateValoresPrecioCatalogo(PedidoNoBloqueado.Numero, ValorPedPremioCat, IvaPedPremioCat);

                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS  - ASIGNAR PREMIO BIENVENIDA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CREO EL PREMIO CORRECTAMENTE PARA EL PEDIDO: " + PedidoNoBloqueado.Numero + " VALOR: " + ZonaMailGroup.ValorFlete + " ZONA: " + ZonaMailGroup.Zona, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS ASIGNAR  PREMIO BIENVENIDA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL PREMIO DE BIENVENIDA AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS - ASIGNAR  PREMIO BIENVENIDA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL PREMIO DE BIENVENIDA AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }



                                                            }
                                                        }
                                                    }
                                                }

                                                //Se actualiza el estado de premio entregado en el cliente. Siempre se debe actualizar asi se entregue o no el premio.
                                                bool okTransEstadoPremio = objCliente.UpdateEstadoPremioCliente(PedidoNoBloqueado.Nit);

                                                if (!okTransEstadoPremio)
                                                {
                                                    Auditoria objAuditoria = new Auditoria("conexion");
                                                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                                                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                                                    objAuditoriaInfo.Proceso = "No se pudo actualizar estado premio de bienvenida al cliente con pedido: " + PedidoNoBloqueado.Numero;
                                                    objAuditoriaInfo.Usuario = PedidoNoBloqueado.ClaveUsuario.Trim();

                                                    objAuditoria.Insert(objAuditoriaInfo);
                                                }
                                            }
                                        }
                                        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                    }
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS : {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNACION DE FLETES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            #endregion

                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]


                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }

                #region "BLOQUEAR MAILPLAN POR MAILGROUP"
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroupBloquear = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfoBloquear = new List<MailGroupInfo>();

                ObjMailGroupInfoBloquear = ObjMailGroupBloquear.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfoBloquear != null && ObjMailGroupInfoBloquear.Count > 0)
                {
                    //Se realiza la actualizacion de mailplan por cada mailgroup.
                    foreach (MailGroupInfo MailGroupActualBloquear in ObjMailGroupInfoBloquear)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "BLOQUEANDO MAILGROUP:" + MailGroupActualBloquear.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se actualiza el estado del mailgroup procesado.
                        if (ObjMailGroupBloquear.Update(MailGroupActualBloquear))
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE BLOQUEO MAILGROUP:" + MailGroupActualBloquear.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO BLOQUEAR MAILGROUP:" + MailGroupActualBloquear.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                }
                #endregion
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //###################################################################################################################################
                //Realiza el procesamiento del historico de los clientes para los pedidos procesados.

                //ProcesarHistoricoClientes(ObjListPedidosHistoricoClientes);

                //###################################################################################################################################

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA PROCESAR PARA FACTURAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR PARA FACTURAR POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //..............................................................................
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //..............................................................................
                }

                //..............................................................................................................................

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR PARA FACTURAR OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Este metodo copia los pedidos procesados en la base de datos de nivi (pedidosc1_2000 y pedidosc2_2000).
        /// Los pedidos copiados no tienen ningun bloqueo y contienen los premios y fletes asignados.
        /// </summary>
        public void ProcesarPedidosFacturarEcuador()
        {
            //NOTA: ESTE PROCESO ANTES DE REALIZARLO SE DEBEN COPIAR LOS CLIENTES DE SVDN A NIVI.

            bool okProcess = false;
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            List<PedidosClienteInfo> ObjListPedidosHistoricoClientes = new List<PedidosClienteInfo>();

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene saldo en cartera se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            MailGroup ObjMailGroup = new MailGroup("conexion");
            List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            {
                //Se realiza la asignacion de pedidos para cada mailgroup.
                foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        Zona ObjZona = new Zona("conexion");
                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        //Se valida que existan zonas para el mailgroup actual.
                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESAR PARA FACTURAR  .", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla de nivi (pedidosc1_2000).
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosFacturarZonaCampana = new List<PedidosClienteInfo>();

                                //Se obtienen los pedidos de las zonas y campañas que estan listos para facturar.
                                ObjListPedidosFacturarZonaCampana = ListPedidoFacturar(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosFacturarZonaCampana != null && ObjListPedidosFacturarZonaCampana.Count > 0)
                                {
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    foreach (PedidosClienteInfo PedidoFacturar in ObjListPedidosFacturarZonaCampana)
                                    {
                                        if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
                                        {
                                            PedidoFacturar.Mes = DateTime.Now.Year.ToString() + "0" + DateTime.Now.Month.ToString();
                                        }
                                        else
                                        {
                                            PedidoFacturar.Mes = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
                                        }

                                        if (InsertFacturar(PedidoFacturar))
                                        {
                                            bool okUpdateProd = UpdateEnProduccion(PedidoFacturar.Numero, true);

                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE INGRESO ENCABEZADO DE PEDIDO OK No: " + PedidoFacturar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                            //Se guarda en la lista para el historial de estados de los clientes.
                                            ObjListPedidosHistoricoClientes.Add(PedidoFacturar);

                                            List<PedidosDetalleClienteInfo> objPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();

                                            //Se consulta el detalle de un pedido 
                                            objPedidosDetalleClienteInfoList = objPedidosDetalleCliente.ListDetallePedidoxNumeroProcesamientoExportar(PedidoFacturar.Numero);

                                            if (objPedidosDetalleClienteInfoList != null && objPedidosDetalleClienteInfoList.Count > 0)
                                            {
                                                int contadorDetalle = 0;

                                                decimal Valor = 0;
                                                decimal Iva = 0;

                                                foreach (PedidosDetalleClienteInfo objPedidosDetalleClienteInfo in objPedidosDetalleClienteInfoList)
                                                {
                                                    #region "Crear Centro de Costos"
                                                    //-------------------------------------------------------------------------------------
                                                    //Crear Centro de Costos.
                                                    CentroCostosInfo objCentroCostosInfo = new CentroCostosInfo();
                                                    CentroCostos objCentroCostos = new CentroCostos("conexion");

                                                    //Seconsulta el ccostos, si existe se crea uno nuevo, sino 
                                                    objCentroCostosInfo = objCentroCostos.ListxCCostos(objPedidosDetalleClienteInfo.Lote);

                                                    if (objCentroCostosInfo == null)
                                                    {
                                                        CentroCostosInfo objCentroCostosInsertInfo = new CentroCostosInfo();

                                                        objCentroCostosInsertInfo.CCostos = objPedidosDetalleClienteInfo.Lote;
                                                        objCentroCostosInsertInfo.Descripcion = "Lote Nro:" + objPedidosDetalleClienteInfo.Lote + ", Creado Por:SVDN";
                                                        objCentroCostosInsertInfo.Fecha = DateTime.Now;
                                                        objCentroCostosInsertInfo.CuentaAjusteinventarios = "";
                                                        objCentroCostosInsertInfo.CuentaAjusteCMV = "";
                                                        objCentroCostosInsertInfo.CentroCostos = "";

                                                        char[] delimiterChars = { '-' };
                                                        string[] CCostosArray = objPedidosDetalleClienteInfo.Lote.Split(delimiterChars);

                                                        objCentroCostosInsertInfo.CodUbicacion = CCostosArray[0];
                                                        objCentroCostosInsertInfo.PLU = Convert.ToDecimal(CCostosArray[1]);

                                                        if (!objCentroCostos.Insert(objCentroCostosInsertInfo))
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GRABAR EL CENTRO DE COSTOS: " + objPedidosDetalleClienteInfo.Lote, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                    //-------------------------------------------------------------------------------------
                                                    #endregion

                                                    //Dividir el valor del articulo entre las cantidades para quie G&G fature y haga el proceso de articulo * cantidad.
                                                    //*se cambio por le nuevo modelo de reserva
                                                    //objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.Valor / objPedidosDetalleClienteInfo.Cantidad;
                                                    //*objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.ValorUnitario; //--se quito la linea anterior por la cantidad.

                                                    objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.Valor / objPedidosDetalleClienteInfo.Cantidad; //--se quito la linea anterior por que aqui ya viene el valor con el desucento aplicado.

                                                    //Se resta el valor del articulo si la cantidad es cero.
                                                    if (objPedidosDetalleClienteInfo.CantidadPedida == 0)
                                                    {
                                                        Valor = Valor - (objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.CantidadPedida);
                                                        Iva = Iva - ((objPedidosDetalleClienteInfo.Valor * (objPedidosDetalleClienteInfo.TarifaIVA / 100)) * objPedidosDetalleClienteInfo.CantidadPedida);
                                                    }

                                                    //Se inserta el detalle del pedido en produccion.
                                                    if (objPedidosDetalleCliente.InsertDetalleFacturar(objPedidosDetalleClienteInfo))
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE INGRESO DETALLE DE PEDIDO OK No: " + PedidoFacturar + " ID DET: " + objPedidosDetalleClienteInfo.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        okProcess = true;
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR EL DETALLE PEDIDO EN LA BD DE NIVI. No: " + PedidoFacturar.Numero + "ID DET: " + objPedidosDetalleClienteInfo.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    Valor = Valor + (objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.CantidadPedida);
                                                    Iva = Iva + ((objPedidosDetalleClienteInfo.Valor * (objPedidosDetalleClienteInfo.TarifaIVA / 100) * objPedidosDetalleClienteInfo.CantidadPedida));

                                                    //--------------------------------------------
                                                    //Proceso de actualizacion del valor del pedido con las sumas y restas de las cantidades 0.

                                                    if (contadorDetalle >= (objPedidosDetalleClienteInfoList.Count - 1))
                                                    {
                                                        if (this.UpdateValorPedido(PedidoFacturar.Numero, Valor, Iva))
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO VALOR DE PEDIDO POR CANTIDAD 0 OK No: " + PedidoFacturar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO VALOR DE PEDIDO POR CANTIDAD 0 No: " + PedidoFacturar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        contadorDetalle++;
                                                    }

                                                    //--------------------------------------------
                                                }
                                            }
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR EL ENCABEZADO EN LA BD DE NIVI DEL PEDIDO: " + PedidoFacturar, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }


                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;

                                    }
                                }
                            }



                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //AQUI SE ASIGNAN LOS FLETES.
                            //ESTE PROCEDIMIENTO SE DEBE REALIZAR DESPUES DE ASIGNAR LOS PREMIOS POR QUE AQUI SE SUMAN EL FLETE Y EL IVA AL PEDIDO PARA PASAR A PRODUCCION.
                            #region "ASIGNACION DE FLETES"

                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                            Ciudad ObjCiudad = new Ciudad("conexion");

                            Application.Enterprise.Business.Cliente objCliente = new Application.Enterprise.Business.Cliente("conexion");

                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                            //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACION DE FLETES.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();
                                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                                ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaSumarFlete(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben insertar todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                                {
                                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();
                                    List<PedidosDetalleClienteInfo> objPedidoFleteInfo = new List<PedidosDetalleClienteInfo>();
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    //Se inserta el flete en el detalle del pedido.
                                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                                    {
                                        //Validar si el pedido es un anexo no debe llevar flete. si anexo = 0 SI lleva flete.
                                        if (PedidoNoBloqueado.Anexo == 0)
                                        {
                                            //se consulta si ese pedido ya tiene asignado un flete.
                                            objPedidoFleteInfo = objPedidosDetalleCliente.ListPedidoFlete(PedidoNoBloqueado.Numero);

                                            //sino tiene asignado un flete se crea el detalle del pedido y se inserta.
                                            if (objPedidoFleteInfo.Count == 0 || objPedidoFleteInfo == null)
                                            {
                                                //Valida que si es un segundo o tercer pedido no se cobra el flete.
                                                List<PedidosClienteInfo> ObjListPedidosNitCampanaConFlete = new List<PedidosClienteInfo>();
                                                //*Habilitar esta linea para quitar el flete al seguno o tercer pedido = ObjListPedidosNitCampanaConFlete = this.ListxNitxCampanaPedidosGYG(PedidoNoBloqueado.Nit, PedidoNoBloqueado.Campana);

                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                                CiudadInfo ObjCiudadInfo = new CiudadInfo();
                                                Application.Enterprise.CommonObjects.ClienteInfo objClienteInfo = new Application.Enterprise.CommonObjects.ClienteInfo();

                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                                                //si no tiene mas de un pedido entonces hay que ponerle flete, si hay mas de uno no se asigna flete a los siguientes.
                                                if (ObjListPedidosNitCampanaConFlete.Count == 0 || ObjListPedidosNitCampanaConFlete == null)
                                                {
                                                    //Crear el detalle del flete para el pedido.
                                                    //objPedidosDetalleClienteInfo = CrearFleteDetallePedido(PedidoNoBloqueado.Numero, ZonaMailGroup.ValorFlete, ZonaMailGroup.Zona, ZonaMailGroup.Excluido);

                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                                                    string CodCiudadCliente = "";
                                                    int TipoPedidoMinimo = 0;

                                                    //Se obtiene el codigo de la ciudad para el flete.
                                                    objClienteInfo = objCliente.ListClienteSVDNxNit(PedidoNoBloqueado.Nit);

                                                    if (objClienteInfo != null)
                                                    {
                                                        CodCiudadCliente = objClienteInfo.CodCiudad;
                                                        TipoPedidoMinimo = objClienteInfo.TipoPedidoMinimo;
                                                    }
                                                    //se obtiene la info de la ciudad del cliente.
                                                    ObjCiudadInfo = ObjCiudad.ListCiudadxId(CodCiudadCliente);

                                                    string okTrans = "";

                                                    if (ObjCiudadInfo != null)
                                                    {
                                                        //aqui validar si es flete normal o flete full

                                                        List<PedidosDetalleClienteInfo> objDetPedido = new List<PedidosDetalleClienteInfo>();
                                                        objDetPedido = objPedidosDetalleCliente.ListDetallePedidoxNumero(PedidoNoBloqueado.Numero);

                                                        //Se valida que tipo de flete se debe asignar al pedido. Si es true es flete normal.
                                                        bool TipoFlete = ValidarPedidoMinimoxTipoParaFlete(TipoPedidoMinimo, PedidoNoBloqueado.ValorPrecioCat, objDetPedido);

                                                        int TipoEnvioFlete = 0; // Siempre a director, a no ser que la empresaria haya elegido a la casa.
                                                        decimal PorcentajeIvaFlete = 0;

                                                        //Si el pedido no tiene tipo de envio se asigna el director por defecto.
                                                        if (PedidoNoBloqueado.TipoEnvio == 0)
                                                        {
                                                            TipoEnvioFlete = 2; // Siempre a director, a no ser que la empresaria haya elegido a la casa.
                                                            PedidoNoBloqueado.TipoEnvio = (int)TipoEnvioEnum.ADirector;
                                                        }

                                                        //Si la empresaria desea que el pedido llegue a la casa se cobra el flete x ciudad, sino se cobra el flete x zona.
                                                        if (PedidoNoBloqueado.TipoEnvio == (int)TipoEnvioEnum.CasaEmpresaria)
                                                        {
                                                            TipoEnvioFlete = (int)TipoEnvioEnum.CasaEmpresaria;
                                                            PorcentajeIvaFlete = ObjCiudadInfo.IVA;
                                                        }
                                                        else if (PedidoNoBloqueado.TipoEnvio == (int)TipoEnvioEnum.ADirector)
                                                        {
                                                            Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                                                            Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                                                            ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.ValorIVACOP);
                                                            PorcentajeIvaFlete = Convert.ToDecimal(ObjParametrosInfo.Valor.ToString());

                                                            TipoEnvioFlete = (int)TipoEnvioEnum.ADirector;

                                                        }
                                                        else if (PedidoNoBloqueado.TipoEnvio == (int)TipoEnvioEnum.ALider)
                                                        {
                                                            Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                                                            Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                                                            ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.ValorIVACOP);
                                                            PorcentajeIvaFlete = Convert.ToDecimal(ObjParametrosInfo.Valor.ToString());

                                                            TipoEnvioFlete = (int)TipoEnvioEnum.ALider;

                                                        }

                                                        //objPedidosDetalleClienteInfo = CrearFleteDetallePedidoxCiudad(PedidoNoBloqueado.Numero, ZonaMailGroup.ValorFlete, ZonaMailGroup.Zona, ObjCiudadInfo.ExcluidoIVA, CodCiudadCliente, ObjCiudadInfo.IVA, ObjCiudadInfo.ValorFleteFull, TipoFlete);

                                                        objPedidosDetalleClienteInfo = CrearFleteDetallePedidoxCiudadEcu(PedidoNoBloqueado.Numero, ZonaMailGroup.ValorFlete, ZonaMailGroup.Zona, ObjCiudadInfo.ExcluidoIVA, CodCiudadCliente, PorcentajeIvaFlete, ObjCiudadInfo.ValorFlete, TipoFlete, TipoEnvioFlete);

                                                        objPedidosDetalleClienteInfo.Referencia = "FT0001";
                                                        objPedidosDetalleClienteInfo.Grupo = "FT0001";
                                                        objPedidosDetalleClienteInfo.ConceptoContable = "005";
                                                        objPedidosDetalleClienteInfo.Lote = "P000-3357";
                                                        objPedidosDetalleClienteInfo.IdCodigoCorto = "FL00";
                                                        objPedidosDetalleClienteInfo.Catalogo = PedidoNoBloqueado.Codigo;
                                                        objPedidosDetalleClienteInfo.CatalogoReal = PedidoNoBloqueado.Codigo;
                                                        objPedidosDetalleClienteInfo.CodigoUbicacion = "P000";

                                                        //Inserta el flete en G&G
                                                        okTrans = objPedidosDetalleCliente.InsertFlete(objPedidosDetalleClienteInfo);

                                                        //Inserta el flete en SVDN
                                                        string IdPedidoDetalleSVDN = objPedidosDetalleCliente.Insert(objPedidosDetalleClienteInfo);
                                                    }
                                                    else
                                                    {
                                                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();
                                                        Auditoria objAuditoria = new Auditoria("conexion");

                                                        objAuditoriaInfo.Proceso = "No se creo el flete para el Pedido: " + PedidoNoBloqueado.Numero + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente por parte de IDN.";
                                                        objAuditoriaInfo.Usuario = PedidoNoBloqueado.ClaveUsuario + " + Procesamiento SVDN.";
                                                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                                                        objAuditoria.Insert(objAuditoriaInfo);

                                                    }

                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                                    if (okTrans == "" || okTrans == null)
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PREMIOS - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO CREAR FLETE PARA PEDIDO: " + okTrans, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                    else
                                                    {
                                                        //decimal ValorPedConFlete = PedidoNoBloqueado.Valor + objPedidosDetalleClienteInfo.Valor;

                                                        decimal ValorPedConFlete = PedidoNoBloqueado.Valor + objPedidosDetalleClienteInfo.Valor;

                                                        decimal ValorPedIvaConFlete = 0;

                                                        //Verifica si la zona esta excluida de iva para no cobrarla.
                                                        //if (ZonaMailGroup.Excluido == 1)
                                                        //{
                                                        //    ValorPedIvaConFlete = PedidoNoBloqueado.IVA;
                                                        //}
                                                        //else
                                                        //{
                                                        //    ValorPedIvaConFlete = PedidoNoBloqueado.IVAPrecioCat + (objPedidosDetalleClienteInfo.Valor * (objPedidosDetalleClienteInfo.TarifaIVA / 100));
                                                        //}


                                                        if (ObjCiudadInfo != null)
                                                        {
                                                            if (ObjCiudadInfo.ExcluidoIVA == 1)
                                                            {
                                                                ValorPedIvaConFlete = PedidoNoBloqueado.IVA;
                                                            }
                                                            else
                                                            {
                                                                ValorPedIvaConFlete = PedidoNoBloqueado.IVA + (objPedidosDetalleClienteInfo.Valor * (ObjCiudadInfo.IVA / 100));
                                                            }
                                                        }

                                                        decimal ValorPedFleteCat = PedidoNoBloqueado.ValorPrecioCat + (objPedidosDetalleClienteInfo.Valor);
                                                        decimal IvaPedFleteCat = PedidoNoBloqueado.IVAPrecioCat + ((objPedidosDetalleClienteInfo.Valor) * (ObjCiudadInfo.IVA / 100));

                                                        //Actualiza el valor del flete en la tabla de nivi
                                                        bool UpdateValorFlete = this.UpdateValorPedido(PedidoNoBloqueado.Numero, ValorPedConFlete, ValorPedIvaConFlete);

                                                        if (UpdateValorFlete)
                                                        {
                                                            //Actualiza el valor del flete en la tabla de svdn
                                                            bool UpdateValorFleteSVDN = this.UpdateValorPedidoSVDN(PedidoNoBloqueado.Numero, ValorPedConFlete, ValorPedIvaConFlete);

                                                            if (UpdateValorFleteSVDN)
                                                            {
                                                                //Actualiza el valor precio catalogo despues de agregar el valor del premio.
                                                                UpdateValoresPrecioCatalogo(PedidoNoBloqueado.Numero, ValorPedFleteCat, IvaPedFleteCat);

                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS  - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CREO EL FLETE CORRECTAMENTE PARA EL PEDIDO: " + PedidoNoBloqueado.Numero + " VALOR: " + ZonaMailGroup.ValorFlete + " ZONA: " + ZonaMailGroup.Zona, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                            else
                                                            {
                                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL FLETE AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL FLETE AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS - ASIGNAR FLETE: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "EL PEDIDO YA TIENE ASIGNADO UN FLETE. PEDIDO No: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }
                                    }
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS : {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNACION DE FLETES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            #endregion

                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
                            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-


                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]

                            //AQUI SE ASIGNAN LOS PREMIOS DE BIENVENIDA.
                            //ESTE PROCEDIMIENTO SE DEBE REALIZAR DESPUES DE ASIGNAR LOS PREMIOS DE BIENVENIDA.
                            #region "ASIGNACION DE PREMIO DE BIENVENIDA"


                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PREMIOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACION DE FLETES.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();
                                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                                ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaSumarFlete(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben insertar todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                                {
                                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();
                                    List<PedidosDetalleClienteInfo> objPedidoFleteInfo = new List<PedidosDetalleClienteInfo>();
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    //Se inserta el flete en el detalle del pedido.
                                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                                    {

                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                        Application.Enterprise.CommonObjects.ClienteInfo objClienteInfo = new Application.Enterprise.CommonObjects.ClienteInfo();

                                        int PremioBienvenida = 0;
                                        int TipoPedidoMinimo = 0;

                                        //Se obtiene el codigo de la ciudad para el flete.
                                        objClienteInfo = objCliente.ListClienteSVDNxNit(PedidoNoBloqueado.Nit);

                                        if (objClienteInfo != null)
                                        {
                                            PremioBienvenida = objClienteInfo.Premio;
                                            TipoPedidoMinimo = objClienteInfo.TipoPedidoMinimo;
                                        }


                                        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                                        //Si el cliente no ha recibido premio de bienvenido se adiciona en el detalle.
                                        if (PremioBienvenida == 0)
                                        {
                                            decimal ValorPrecioCatPremio = 0;
                                            decimal IVAPrecioCatPremio = 0;

                                            List<PedidosDetalleClienteInfo> objDetPedido = new List<PedidosDetalleClienteInfo>();
                                            objDetPedido = objPedidosDetalleCliente.ListDetallePedidoxNumero(PedidoNoBloqueado.Numero);

                                            foreach (PedidosDetalleClienteInfo item in objDetPedido)
                                            {
                                                //Se suma el valor del pre
                                                if (!item.IdCodigoCorto.StartsWith("FL"))
                                                {
                                                    //Se valida que no sean productos ni outlet nivi, outlet pisame, hogar.
                                                    if (!item.CatalogoReal.StartsWith("T") && !item.CatalogoReal.StartsWith("L") && !item.CatalogoReal.StartsWith("H"))
                                                    {
                                                        ValorPrecioCatPremio = ValorPrecioCatPremio + (item.ValorPrecioCatalogoUnitario * item.Cantidad);
                                                        IVAPrecioCatPremio = IVAPrecioCatPremio + ((item.ValorPrecioCatalogoUnitario * item.Cantidad) * (item.TarifaIVA / 100));
                                                    }
                                                }
                                            }

                                            Application.Enterprise.Business.Parametros objParametros = new Application.Enterprise.Business.Parametros("conexion");
                                            Application.Enterprise.CommonObjects.ParametrosInfo objParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();

                                            objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.ValorPedidoPremioBienvenida);

                                            if (objParametrosInfo != null)
                                            {
                                                decimal ValorPrecionCatSinFlete = (ValorPrecioCatPremio + IVAPrecioCatPremio);

                                                //Si el pedido cumple con el valor minimo para asignar el premio. 
                                                if (ValorPrecionCatSinFlete >= Convert.ToDecimal(objParametrosInfo.Valor))
                                                {
                                                    //se consultan los premios de bienvenida activos por unidad de negocio.
                                                    List<PedidosDetalleClienteInfo> objPedidosDetallePremiosInfo = objPedidosDetalleCliente.ListPremiosBienvenidaActivos(("0" + TipoPedidoMinimo.ToString()));

                                                    if (objPedidosDetallePremiosInfo != null && objPedidosDetallePremiosInfo.Count > 0)
                                                    {
                                                        foreach (PedidosDetalleClienteInfo Premio in objPedidosDetallePremiosInfo)
                                                        {
                                                            string fecha = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                                                            Premio.Id = PedidoNoBloqueado.Numero + "_PRE_" + fecha;
                                                            Premio.Numero = PedidoNoBloqueado.Numero;
                                                            Premio.NumeroPedidoPadre = PedidoNoBloqueado.Numero;
                                                            Premio.IdDocumentoFuente = DateTime.Now.ToString();
                                                            Premio.Catalogo = PedidoNoBloqueado.Codigo;
                                                            Premio.CatalogoReal = Premio.Catalogo;
                                                            Premio.IdCodigoCorto = "PRE00";
                                                            Premio.PorcentajeDescuento = 0;
                                                            Premio.CentroCostos = PedidoNoBloqueado.Zona;
                                                            Premio.Lote = Premio.CodigoUbicacion + "-" + Premio.PLU;

                                                            PedidosClienteInfo PedidoEnc = ListPedidoxId(PedidoNoBloqueado.Numero);

                                                            decimal ValorPedPremio = PedidoEnc.Valor + (Premio.Valor * Premio.Cantidad);
                                                            decimal IvaPedPremio = PedidoEnc.IVA + ((Premio.Valor * Premio.Cantidad) * (Premio.TarifaIVA / 100));

                                                            decimal ValorPedPremioCat = PedidoEnc.ValorPrecioCat + (Premio.ValorPrecioCatalogoUnitario * Premio.Cantidad);
                                                            decimal IvaPedPremioCat = PedidoEnc.IVAPrecioCat + ((Premio.ValorPrecioCatalogoUnitario * Premio.Cantidad) * (Premio.TarifaIVA / 100));

                                                            //inserta el premio en SVDN.
                                                            string IdPedidoDetallePremio = objPedidosDetalleCliente.Insert(Premio);

                                                            if (IdPedidoDetallePremio != "" && IdPedidoDetallePremio != null)
                                                            {
                                                                //Inserta el premio en G&G
                                                                bool okTrans = objPedidosDetalleCliente.InsertDetalleFacturar(Premio);

                                                                //Actualiza el valor del premio en el encabezado del pedido.
                                                                bool UpdateValorPremio = this.UpdateValorPedido(PedidoNoBloqueado.Numero, ValorPedPremio, IvaPedPremio);

                                                                if (UpdateValorPremio)
                                                                {
                                                                    //Actualiza el valor del premio en el encabezado del pedido en la tabla de svdn
                                                                    bool UpdateValorFleteSVDN = this.UpdateValorPedidoSVDN(PedidoNoBloqueado.Numero, ValorPedPremio, IvaPedPremio);

                                                                    if (UpdateValorFleteSVDN)
                                                                    {
                                                                        //Actualiza el valor precio catalogo despues de agregar el valor del premio.
                                                                        UpdateValoresPrecioCatalogo(PedidoNoBloqueado.Numero, ValorPedPremioCat, IvaPedPremioCat);

                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS  - ASIGNAR PREMIO BIENVENIDA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CREO EL PREMIO CORRECTAMENTE PARA EL PEDIDO: " + PedidoNoBloqueado.Numero + " VALOR: " + ZonaMailGroup.ValorFlete + " ZONA: " + ZonaMailGroup.Zona, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS ASIGNAR  PREMIO BIENVENIDA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL PREMIO DE BIENVENIDA AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS - ASIGNAR  PREMIO BIENVENIDA: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO SUMAR EL VALOR DEL PREMIO DE BIENVENIDA AL PEDIDO NIVI: " + PedidoNoBloqueado.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                                }



                                                            }
                                                        }
                                                    }
                                                }

                                                //Se actualiza el estado de premio entregado en el cliente. Siempre se debe actualizar asi se entregue o no el premio.
                                                bool okTransEstadoPremio = objCliente.UpdateEstadoPremioCliente(PedidoNoBloqueado.Nit);

                                                if (!okTransEstadoPremio)
                                                {
                                                    Auditoria objAuditoria = new Auditoria("conexion");
                                                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                                                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                                                    objAuditoriaInfo.Proceso = "No se pudo actualizar estado premio de bienvenida al cliente con pedido: " + PedidoNoBloqueado.Numero;
                                                    objAuditoriaInfo.Usuario = PedidoNoBloqueado.ClaveUsuario.Trim();

                                                    objAuditoria.Insert(objAuditoriaInfo);
                                                }
                                            }
                                        }
                                        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                    }
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS : {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNACION DE FLETES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            #endregion

                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                            //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]


                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }

                #region "BLOQUEAR MAILPLAN POR MAILGROUP"
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //Se obtienen los mailgroup por fecha actual.
                MailGroup ObjMailGroupBloquear = new MailGroup("conexion");
                List<MailGroupInfo> ObjMailGroupInfoBloquear = new List<MailGroupInfo>();

                ObjMailGroupInfoBloquear = ObjMailGroupBloquear.ListxFechaActualFacturacion();

                //se pregunta si existen Mailgroup para ese dia.
                if (ObjMailGroupInfoBloquear != null && ObjMailGroupInfoBloquear.Count > 0)
                {
                    //Se realiza la actualizacion de mailplan por cada mailgroup.
                    foreach (MailGroupInfo MailGroupActualBloquear in ObjMailGroupInfoBloquear)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "BLOQUEANDO MAILGROUP:" + MailGroupActualBloquear.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se actualiza el estado del mailgroup procesado.
                        if (ObjMailGroupBloquear.Update(MailGroupActualBloquear))
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE BLOQUEO MAILGROUP:" + MailGroupActualBloquear.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO BLOQUEAR MAILGROUP:" + MailGroupActualBloquear.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                }
                #endregion
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //###################################################################################################################################
                //Realiza el procesamiento del historico de los clientes para los pedidos procesados.

                //ProcesarHistoricoClientes(ObjListPedidosHistoricoClientes);

                //###################################################################################################################################

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA PROCESAR PARA FACTURAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR PARA FACTURAR POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //..............................................................................
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //..............................................................................
                }

                //..............................................................................................................................

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR PARA FACTURAR OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR PARA FACTURAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }


        /// <summary>
        /// Valida si cumplio con el valor de pedido minimo de catalogo para asignar el flete o fletefull, si es true es flete normal, si es false es flete full.
        /// El valor no cuenta articulos outlets ni hogar, ni articulos no disponibles.
        /// Retorna true para indicar que es flete normal. false para flete full.
        /// </summary>
        /// <returns></returns>
        private bool ValidarPedidoMinimoxTipoParaFlete(int TipoPedidoMinimo, decimal ValorPrecioCatIVA, List<PedidosDetalleClienteInfo> DetPedido)
        {
            bool Permiso = false;

            //----------------------------------------------------------------------------------------------------------
            //Consultar si cumple el valor minimo de  pedidos para pedir del outlet.
            //Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
            //Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

            //ObjParametrosInfo = ObjParametros.ListxId((int)Application.Enterprise.CommonObjects.ParametrosEnum.ValorPedidoNivi);
            //decimal ValorParaPedido = Convert.ToDecimal(ObjParametrosInfo.Valor.ToString());

            Application.Enterprise.CommonObjects.TipoPedidoMinimoInfo ObjTipoPedidoMinimoInfo = new Application.Enterprise.CommonObjects.TipoPedidoMinimoInfo();
            Application.Enterprise.Business.TipoPedidoMinimo ObjTipoPedidoMinimo = new Application.Enterprise.Business.TipoPedidoMinimo("conexion");

            ObjTipoPedidoMinimoInfo = ObjTipoPedidoMinimo.ListxId(TipoPedidoMinimo); // se envia el tipo de la empresaria.

            if (ObjTipoPedidoMinimoInfo != null)
            {
                decimal ValorParaPedido = ObjTipoPedidoMinimoInfo.Valor;

                decimal TotalPrecioCatalogo = ValorPrecioCatIVA;

                //Se resta el valor de los articulos que no estan disponibles, menos el valos de los articulos de outlet y hogar.
                //TotalPrecioCatalogo = TotalPrecioCatalogo - TotalArtNoDiponibles - ValorCatalogoOutlet - ValorCatalogoHogar;

                if (TipoPedidoMinimo == (int)TipoPedidoMinimoEnum.Nivi)
                {
                    decimal TotalPrecio = 0;

                    foreach (PedidosDetalleClienteInfo item in DetPedido)
                    {
                        //Si la cantidad es > 0 es por que el articulo es disponible.
                        if (item.Cantidad > 0)
                        {
                            //Sino es el flete ni un premio.
                            if (!item.IdCodigoCorto.StartsWith("FL") && !item.IdCodigoCorto.StartsWith("PRE"))
                            {
                                //Si el articulo es nivi, suma al valor del pedido.
                                if (item.UnidadNegocio == "01")
                                {
                                    //Se valida que no sean productos ni outlet nivi, outlet pisame, hogar.
                                    if (!item.CatalogoReal.StartsWith("T") && !item.CatalogoReal.StartsWith("L") && !item.CatalogoReal.StartsWith("H"))
                                    {
                                        TotalPrecio = TotalPrecio + ((item.ValorPrecioCatalogoUnitario * item.Cantidad) + ((item.ValorPrecioCatalogoUnitario * (item.TarifaIVA / 100)) * item.Cantidad));
                                    }
                                }
                            }
                        }
                    }

                    //Se calcula el precio catalogo sin la suma de los outlet y articulos no disponibles.
                    TotalPrecioCatalogo = TotalPrecio;
                }
                else if (TipoPedidoMinimo == (int)TipoPedidoMinimoEnum.Pisame)
                {
                    decimal TotalPrecio = 0;

                    foreach (PedidosDetalleClienteInfo item in DetPedido)
                    {
                        //Si la cantidad es > 0 es por que el articulo es disponible.
                        if (item.Cantidad > 0)
                        {
                            //Sino es el flete ni un premio.
                            if (!item.IdCodigoCorto.StartsWith("FL") && !item.IdCodigoCorto.StartsWith("PRE"))
                            {
                                //Si el articulo es pisame, suma al valor del pedido.
                                if (item.UnidadNegocio == "02")
                                {
                                    //Se valida que no sean productos ni outlet nivi, outlet pisame, hogar.
                                    if (!item.CatalogoReal.StartsWith("T") && !item.CatalogoReal.StartsWith("L") && !item.CatalogoReal.StartsWith("H"))
                                    {
                                        TotalPrecio = TotalPrecio + ((item.ValorPrecioCatalogoUnitario * item.Cantidad) + ((item.ValorPrecioCatalogoUnitario * (item.TarifaIVA / 100)) * item.Cantidad));
                                    }
                                }
                            }
                        }
                    }

                    //Se calcula el precio catalogo sin la suma de los outlet y articulos no disponibles.
                    TotalPrecioCatalogo = TotalPrecio;
                }
                else if (TipoPedidoMinimo == (int)TipoPedidoMinimoEnum.Mezcla)
                {
                    decimal TotalPrecio = 0;

                    foreach (PedidosDetalleClienteInfo item in DetPedido)
                    {
                        //Si la cantidad es > 0 es por que el articulo es disponible.
                        if (item.Cantidad > 0)
                        {
                            //Sino es el flete ni un premio.
                            if (!item.IdCodigoCorto.StartsWith("FL") && !item.IdCodigoCorto.StartsWith("PRE"))
                            {
                                //Si el articulo es mixto, suma al valor del pedido.
                                //if (item.UnidadNegocio == "01")
                                //{
                                //Se valida que no sean productos ni outlet nivi, outlet pisame, hogar.
                                if (!item.CatalogoReal.StartsWith("T") && !item.CatalogoReal.StartsWith("L") && !item.CatalogoReal.StartsWith("H"))
                                {
                                    TotalPrecio = TotalPrecio + ((item.ValorPrecioCatalogoUnitario * item.Cantidad) + ((item.ValorPrecioCatalogoUnitario * (item.TarifaIVA / 100)) * item.Cantidad));
                                }
                                //}
                            }
                        }
                    }

                    //Se calcula el precio catalogo sin la suma de los outlet y articulos no disponibles.
                    TotalPrecioCatalogo = TotalPrecio;
                }

                //Se asgina el valor globla menos el valor de outlet, hogar y articulos no disponibles para comparar valor minimo de los otros catalogos.
                //TotalPrecioCatalogoGlobal = TotalPrecioCatalogo;

                //Si el valor del precio catalogo es mayor que el precio requerido para el pedido se puede realizar pedido de nivi.
                if ((TotalPrecioCatalogo) >= ValorParaPedido)
                {
                    Permiso = true;
                }
                else
                {
                    Permiso = false;

                    //Mesaje de Advertencia.              
                    //RadWindowManager1.RadAlert("La empresaria debe cumplir un pedido con un valor precio catalogo minimo de <b> $" + ValorParaPedido + " </b> pesos para poder realizar un pedido.<br /><font color=darkviolet>NO se suma el valor de los articulos No disponibles, ni valor de articulos outlet/hogar.</font><br /><font color=red><b>NO SE GUARDO EL PEDIDO.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    //SE MUESTRA EL MENSAJE CON 200.000 pero se valida el valor de lo que hay en la tabla de parametros.
                    //RadWindowManager1.RadAlert("La empresaria debe cumplir con un pedido de valor precio catalogo minimo de <b>" + String.Format("{0:C}", ObjTipoPedidoMinimoInfo.TextoAMostrar) + " </b> pesos para poder realizar un pedido.<br /><font color=darkviolet>NO se suma el valor de los articulos No disponibles, ni valor de articulos outlet.</font><br /><font color=red><b>NO SE GUARDO EL PEDIDO.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
            else
            {
                Permiso = false;
                //Mesaje de Advertencia.              
                //RadWindowManager1.RadAlert("No se puede crear el pedido por que el cliente no tiene configurado el tipo de pedido minimo.<br />Por favor comuniquese con Inteligencia Comercial - IDN.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }

            return Permiso;
        }


        /// <summary>
        /// Eliminar este metodo y habilitar el de abajo para que funcione el
        /// unificar pedidos de otros catalogos.
        /// </summary>
        public void UnificarPedidosCatalogos()
        {

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }

        }


        /// <summary>
        /// Este metodo unifica los pedidos de los catalogos nivi, outlet y hogar en uno solo para el procesamiento.
        /// </summary>
        public void UnificarPedidosCatalogosACTIVARESTESISEREQUIERE()
        {
            bool okProcess = false;
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. se unifican los pedidos de oulet y hogar
            //6. se actualizan los valores y se suman
            //7. se bloquean los pedidos de oulet y de hogar.

            //Se obtienen los mailgroup por fecha actual.
            MailGroup ObjMailGroup = new MailGroup("conexion");
            List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            {
                //Se realiza la asignacion de pedidos para cada mailgroup.
                foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        Zona ObjZona = new Zona("conexion");
                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        //Se valida que existan zonas para el mailgroup actual.
                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESAR PARA FACTURAR  .", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla de nivi (pedidosc1_2000).
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosProcesarZonaCampana = new List<PedidosClienteInfo>();

                                //Se obtienen los pedidos de las zonas y campañas que estan listos para procesar del catalogo nivi .
                                ObjListPedidosProcesarZonaCampana = ListPedidosProcesarNivi(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosProcesarZonaCampana != null && ObjListPedidosProcesarZonaCampana.Count > 0)
                                {
                                    //para consultar el detalle de los pedidos outlet y hogar
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    foreach (PedidosClienteInfo PedidoProcesar in ObjListPedidosProcesarZonaCampana)
                                    {
                                        decimal ValorSumatoria = PedidoProcesar.Valor;
                                        decimal IVASumatoria = PedidoProcesar.IVA;

                                        List<PedidosClienteInfo> ObjListPedidosTodosCatalogosList = new List<PedidosClienteInfo>();

                                        //Consultar todos los pedidos (catalogo  hogar y outlet) de la empresaria procesados sin bloqueos para agruparlos en un solo pedido y pasarlos a facturacion.
                                        ObjListPedidosTodosCatalogosList = this.ListPedidosxEmpresariaOuletHogar(PedidoProcesar.Nit, PedidoProcesar.Campana);

                                        //si trae los pedidos de catalogo  hogar y outlet sigue el proceso.
                                        if (ObjListPedidosTodosCatalogosList != null && ObjListPedidosTodosCatalogosList.Count > 0)
                                        {
                                            foreach (PedidosClienteInfo PedidoParaUnificar in ObjListPedidosTodosCatalogosList)
                                            {
                                                List<PedidosDetalleClienteInfo> objPedidosDetalleClienteInfo = new List<PedidosDetalleClienteInfo>();

                                                //Se obtiene el detalle del pedido outlet u hogar.
                                                objPedidosDetalleClienteInfo = objPedidosDetalleCliente.ListDetallePedidoxNumeroProcesamiento(PedidoParaUnificar.Numero);

                                                if (objPedidosDetalleClienteInfo != null && objPedidosDetalleClienteInfo.Count > 0)
                                                {
                                                    foreach (PedidosDetalleClienteInfo PedidoDetalleOuletHogar in objPedidosDetalleClienteInfo)
                                                    {
                                                        PedidoDetalleOuletHogar.NumeroPedidoPadre = PedidoParaUnificar.Numero;
                                                        PedidoDetalleOuletHogar.Numero = PedidoProcesar.Numero;
                                                        PedidoDetalleOuletHogar.Catalogo = PedidoParaUnificar.Codigo;

                                                        string okTrans = objPedidosDetalleCliente.Insert(PedidoDetalleOuletHogar);

                                                        if (okTrans == "" || okTrans == null)
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO CREAR DETALLE PARA PEDIDO PADRE: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                        else
                                                        {
                                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "CREO DETALLE PARA PEDIDO PADRE OK: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                        }
                                                    }
                                                }

                                                //Se suman los valores del pedido nivi oulet/hogar
                                                ValorSumatoria = ValorSumatoria + PedidoParaUnificar.Valor;
                                                IVASumatoria = IVASumatoria + PedidoParaUnificar.IVA;

                                                //se suman los valores de los pedidos unificados.
                                                if (UpdateValorPedidoSVDN(PedidoProcesar.Numero, ValorSumatoria, IVASumatoria))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO EL VALOR DEL PEDIDO OK: " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL VALOR DEL PEDIDO: " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }

                                                //se actualiza el estado del pedido a unificado para que no se tenga mas en cuenta en el procesamiento.
                                                if (UpdateEstadoPedido(PedidoParaUnificar.Numero, (int)EstadosPedidoEnum.Unificado))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO ESTADO DEL PEDIDO A UNIFICADO OK: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO ESTADO DEL PEDIDO A UNIFICADO: " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }

                                                //se actualiza el estado del pedido en produccion para que no se tenga mas cuenta en el procesamiento.
                                                if (UpdateEnProduccion(PedidoParaUnificar.Numero, true))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO PEDIDO A PRODUCCION OK: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO  PEDIDO A PRODUCCION : " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN PEDIDOS PARA EL NIT:" + PedidoProcesar.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;

                                    }
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA PROCESAR PARA FACTURAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE UNIFICAR PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //..............................................................................
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //..............................................................................
                }

                //..............................................................................................................................

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE UNIFICAR PEDIDOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }


        /// <summary>
        /// Eliminar este metodo y habilitar el de abajo para que funcione el
        /// bloqueo de de pedidos de otros catalogos.
        /// </summary>
        public void BloquearPedidosOtrosCatalogos()
        {

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                handler(ObjPedidosClienteProcesadoInfo);
            }
        }

        /// <summary>
        /// Bloquear Pedidos de otros catalogos (Outlet y Hogar).
        /// </summary>
        /// <returns></returns>
        private void BloquearPedidosOtrosCatalogosACTIVARESTESISEVUELVEAREQUERIR()
        {
            bool okProcess = false;
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene saldo en cartera se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            MailGroup ObjMailGroup = new MailGroup("conexion");
            List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            {
                //Se realiza la asignacion de pedidos para cada mailgroup.
                foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        Zona ObjZona = new Zona("conexion");
                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        //Se valida que existan zonas para el mailgroup actual.
                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO BLOQUEAR PEDIDOS OTROS CATALOGOS .", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se recorren las zonas y se trasladan los pedidos a la tabla de nivi (pedidosc1_2000).
                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            {
                                List<PedidosClienteInfo> ObjListPedidosBloqueadosZonaCampana = new List<PedidosClienteInfo>();

                                //Se obtienen los pedidos de las zonas y campañas que estan bloqueados .
                                ObjListPedidosBloqueadosZonaCampana = ListPedidosBloqueados(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                                //      por que sino queda filtrado por zona.
                                //Se valida si existen pedidos de la zona y la campaña actual.
                                if (ObjListPedidosBloqueadosZonaCampana != null && ObjListPedidosBloqueadosZonaCampana.Count > 0)
                                {
                                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                                    foreach (PedidosClienteInfo PedidoBloqueado in ObjListPedidosBloqueadosZonaCampana)
                                    {
                                        List<PedidosClienteInfo> ObjListPedidosxNit = new List<PedidosClienteInfo>();

                                        //Consulta los pedidos de outlet y hogar
                                        ObjListPedidosxNit = this.ListPedidosxNitxCampana(PedidoBloqueado.Nit, ObjCampanaInfo.Campana);

                                        //si trae los pedidos de catalogo nivi, hogar, outlet sigue el proceso.
                                        if (ObjListPedidosxNit != null && ObjListPedidosxNit.Count > 0)
                                        {
                                            foreach (PedidosClienteInfo PedidoBloquear in ObjListPedidosxNit)
                                            {
                                                if (this.UpdateEstadoPedido(PedidoBloquear.Numero, PedidoBloqueado.IdEstado))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE BLOQUEO OK EL PEDIDO :" + PedidoBloquear.Numero + " CATALOGO: " + PedidoBloquear.Codigo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO BLOQUEAR EL PEDIDO :" + PedidoBloquear.Numero + " CATALOGO: " + PedidoBloquear.Codigo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN PEDIDOS PARA EL NIT:" + PedidoBloqueado.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;
                                    }
                                }
                                else
                                {
                                    //sino hay pedidos opara bloquear debe ssalir del metodo.

                                    //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                    okProcess = true;

                                    //Contador de pedidos
                                    consecutivo = consecutivo + 1;
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR DE OTROS CATALOGOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR PEDIDOS OTROS CATALOGOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //..............................................................................
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //..............................................................................
                }
                //..............................................................................................................................

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR PEDIDOS OTROS CATALOGOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS:  PROCESO DE BLOQUEAR PEDIDOS OTROS CATALOGOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //return okProcess;
        }


        /// <summary>
        /// Procesa los estados de los clientes para guardar el historico.
        /// </summary>
        private void ProcesarHistoricoClientes(List<PedidosClienteInfo> ListaPedidos)
        {
            bool okProcess = false;

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE PROCESAR HISTORICO CLIENTES. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                #region "PROCESO DE HISTORICO DE CLIENTES"

                if (ListaPedidos != null && ListaPedidos.Count > 0)
                {
                    int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

                    Cliente ObjCliente = new Cliente("conexion");

                    HistoricoCliente ObjHistoricoCliente = new HistoricoCliente("conexion");

                    foreach (PedidosClienteInfo objPedidosClienteInfo in ListaPedidos)
                    {
                        ClienteInfo ObjClienteInfo = ObjCliente.ListxNITSimple(objPedidosClienteInfo.Nit);

                        switch (ObjClienteInfo.IdEstadosCliente)
                        {
                            case (int)EstadosClienteEnum.Prospecto:

                                HistoricoClienteInfo objHistoricoClienteInfo = new HistoricoClienteInfo();

                                //Se actualiza el estado de activo 1 a 0 para el paso de prospecto a nueva.
                                objHistoricoClienteInfo.Activo = 0;
                                objHistoricoClienteInfo.Campana = objPedidosClienteInfo.Campana;
                                objHistoricoClienteInfo.Nit = objPedidosClienteInfo.Nit;
                                objHistoricoClienteInfo.EstadoCliente = (int)EstadosClienteEnum.Prospecto;

                                bool okTransUp = ObjHistoricoCliente.UpdateEstadoActivo(objHistoricoClienteInfo);

                                if (okTransUp)
                                {
                                    //Se realiza el insert del estado de la empresaria como nuevo por que realizo un pedido.

                                    objHistoricoClienteInfo.Campana = objPedidosClienteInfo.Campana;
                                    objHistoricoClienteInfo.Nit = objPedidosClienteInfo.Nit;
                                    objHistoricoClienteInfo.Fecha = DateTime.Now;
                                    objHistoricoClienteInfo.EstadoCliente = (int)EstadosClienteEnum.Nuevo;
                                    objHistoricoClienteInfo.Proceso = (int)ProcesoClienteEnum.ProcesamientoSVDN;
                                    objHistoricoClienteInfo.Activo = 1;

                                    bool okTransIn = ObjHistoricoCliente.Insert(objHistoricoClienteInfo);

                                    if (okTransIn)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE GUARDO OK HISTORICO DE CLIENTES DE NIT:" + objHistoricoClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Nuevo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        //Se actualiza el estado final en el que debe quedar el cliente.
                                        bool okTransUpEs = ObjCliente.UpdateEstadoCliente(objPedidosClienteInfo.Nit, (int)EstadosClienteEnum.Nuevo);

                                        if (okTransUpEs)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Nuevo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Nuevo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Nuevo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR HISTORICO DE CLIENTES DE NIT:" + objHistoricoClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Prospecto, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }

                                break;
                            case (int)EstadosClienteEnum.PosibleEgreso:

                                HistoricoClienteInfo objHistoricoClienteInfoPE = new HistoricoClienteInfo();

                                objHistoricoClienteInfoPE.Campana = objPedidosClienteInfo.Campana;
                                objHistoricoClienteInfoPE.Nit = objPedidosClienteInfo.Nit;
                                objHistoricoClienteInfoPE.Fecha = DateTime.Now;
                                objHistoricoClienteInfoPE.EstadoCliente = (int)EstadosClienteEnum.Activo;
                                objHistoricoClienteInfoPE.Proceso = (int)ProcesoClienteEnum.ProcesamientoSVDN;
                                objHistoricoClienteInfoPE.Activo = 1;

                                bool okTransInPE = ObjHistoricoCliente.Insert(objHistoricoClienteInfoPE);

                                if (okTransInPE)
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE GUARDO OK HISTORICO DE CLIENTES DE NIT:" + objHistoricoClienteInfoPE.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //Se actualiza el estado final en el que debe quedar el cliente.
                                    bool okTransUpEs = ObjCliente.UpdateEstadoCliente(objPedidosClienteInfo.Nit, (int)EstadosClienteEnum.Activo);

                                    if (okTransUpEs)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfoPE.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }

                                break;
                            case (int)EstadosClienteEnum.Egreso:

                                HistoricoClienteInfo objHistoricoClienteInfoE = new HistoricoClienteInfo();

                                objHistoricoClienteInfoE.Campana = objPedidosClienteInfo.Campana;
                                objHistoricoClienteInfoE.Nit = objPedidosClienteInfo.Nit;
                                objHistoricoClienteInfoE.Fecha = DateTime.Now;
                                objHistoricoClienteInfoE.EstadoCliente = (int)EstadosClienteEnum.Activo;
                                objHistoricoClienteInfoE.Proceso = (int)ProcesoClienteEnum.ProcesamientoSVDN;
                                objHistoricoClienteInfoE.Activo = 1;

                                bool okTransInE = ObjHistoricoCliente.Insert(objHistoricoClienteInfoE);

                                if (okTransInE)
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE GUARDO OK HISTORICO DE CLIENTES DE NIT:" + objHistoricoClienteInfoE.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //Se actualiza el estado final en el que debe quedar el cliente.
                                    bool okTransUpEs = ObjCliente.UpdateEstadoCliente(objPedidosClienteInfo.Nit, (int)EstadosClienteEnum.Activo);

                                    if (okTransUpEs)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfoE.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }

                                break;
                            case (int)EstadosClienteEnum.Inactivo:

                                //Si la consecutividad es true es por que lleva mas de 6 campañas sin realizar pedido y debe volverse una empresaria nueva.
                                //Si la consecutividad es false es por que lleva menos de 6 campañas sin realizar pedido y debe volverse una empresaria activa.
                                if (CalcularConsecutividadInactividadCliente(objPedidosClienteInfo.Nit))
                                {
                                    //Se guarda como nuevo por que cumplio 6 campañas de inactividad.

                                    HistoricoClienteInfo objHistoricoClienteInfoC = new HistoricoClienteInfo();

                                    objHistoricoClienteInfoC.Campana = objPedidosClienteInfo.Campana;
                                    objHistoricoClienteInfoC.Nit = objPedidosClienteInfo.Nit;
                                    objHistoricoClienteInfoC.Fecha = DateTime.Now;
                                    objHistoricoClienteInfoC.EstadoCliente = (int)EstadosClienteEnum.Nuevo;
                                    objHistoricoClienteInfoC.Proceso = (int)ProcesoClienteEnum.ProcesamientoSVDN;
                                    objHistoricoClienteInfoC.Activo = 1;

                                    bool okTransInC = ObjHistoricoCliente.Insert(objHistoricoClienteInfoC);

                                    if (okTransInC)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE GUARDO OK HISTORICO DE CLIENTES DE NIT:" + objHistoricoClienteInfoC.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        //Se actualiza el estado final en el que debe quedar el cliente.
                                        bool okTransUpEsC = ObjCliente.UpdateEstadoCliente(objPedidosClienteInfo.Nit, (int)EstadosClienteEnum.Nuevo);

                                        if (okTransUpEsC)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfoC.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }
                                else
                                {
                                    //Se guarda como activo por que no cumplio 6 campañas de inactividad.

                                    HistoricoClienteInfo objHistoricoClienteInfoD = new HistoricoClienteInfo();

                                    objHistoricoClienteInfoD.Campana = objPedidosClienteInfo.Campana;
                                    objHistoricoClienteInfoD.Nit = objPedidosClienteInfo.Nit;
                                    objHistoricoClienteInfoD.Fecha = DateTime.Now;
                                    objHistoricoClienteInfoD.EstadoCliente = (int)EstadosClienteEnum.Activo;
                                    objHistoricoClienteInfoD.Proceso = (int)ProcesoClienteEnum.ProcesamientoSVDN;
                                    objHistoricoClienteInfoD.Activo = 1;

                                    bool okTransInD = ObjHistoricoCliente.Insert(objHistoricoClienteInfoD);

                                    if (okTransInD)
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE GUARDO OK HISTORICO DE CLIENTES DE NIT:" + objHistoricoClienteInfoD.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        //Se actualiza el estado final en el que debe quedar el cliente.
                                        bool okTransUpEsC = ObjCliente.UpdateEstadoCliente(objPedidosClienteInfo.Nit, (int)EstadosClienteEnum.Nuevo);

                                        if (okTransUpEsC)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfoD.Nit + " Estado:" + (int)EstadosClienteEnum.Activo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }

                                break;
                            default: //sino se evaluo el estado del cliente por que no esta en el switch.
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES POR QUE EL ESTADO DEL CLIENTE FUE:" + ObjClienteInfo.IdEstadosCliente.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                break;
                        }


                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "Se guardo el historico de cliente: " + objPedidosClienteInfo.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }

                    okProcess = true;
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO HAY CLIENTES NUEVOS PARA MIGRAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));


                    ClienteInfo objClienteInfo = new ClienteInfo();

                    OnClientesProcesamientoEventHandler handler = OnClienteEvent;
                    if (handler != null)
                    {
                        objClienteInfo.TotalClientes = 1;
                        objClienteInfo.TerminoProcess = true;
                        handler(objClienteInfo);
                    }
                }

                #endregion

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR HISTORICO CLIENTES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: PROCESO DE PROCESAR HISTORICO CLIENTES TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));

            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI ERROR PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

        }


        ///// <summary>
        ///// Construye un objeto HistoricoCliente
        ///// </summary>
        ///// <param name="campana"></param>
        ///// <param name="nit"></param>
        ///// <param name="estadocliente"></param>
        ///// <param name="zona"></param>
        ///// <param name="codregional"></param>
        ///// <param name="vendedor"></param>
        ///// <param name="activo"></param>
        ///// <param name="proceso"></param>
        ///// <returns></returns>
        //private HistoricoClienteInfo CrearObjetoHistoricoCliente(string campana, string nit, int estadocliente, string zona, string codregional, string vendedor, int activo = -1, int proceso = -1)
        //{
        //    HistoricoClienteInfo objHistoricoClienteInfo = new HistoricoClienteInfo();

        //    objHistoricoClienteInfo.Campana = campana;
        //    objHistoricoClienteInfo.Nit = nit;
        //    objHistoricoClienteInfo.Fecha = DateTime.Now;
        //    objHistoricoClienteInfo.EstadoCliente = estadocliente;
        //    if (proceso != -1)
        //        objHistoricoClienteInfo.Proceso = proceso;
        //    if (activo != -1)
        //        objHistoricoClienteInfo.Activo = activo;
        //    objHistoricoClienteInfo.Zona = zona;
        //    objHistoricoClienteInfo.CodigoRegional = codregional;
        //    objHistoricoClienteInfo.Vendedor = vendedor;

        //    return objHistoricoClienteInfo;
        //}


        /// <summary>
        /// Cambia los estados de las empresarias que realizaron pedidos en las tablas (SVDN_PEDIDOSC1_2000, SVDN_CLIENTES_HISTORICO y clientes)
        /// </summary>
        /// <param name="ListaPedidos"></param>
        //public void ProcesarHistoricoClientesActivacion(List<PedidosClienteInfo> ListaPedidos)
        //{
        //    try
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE PROCESAR HISTORICO CLIENTES. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //        //Captura el tiempo de inicio
        //        _startAsignacionTime = DateTime.Now;
        //        //bool okTransUpAc = false; //bool Actualizacion Activo
        //        bool okTransIn = false; //bool Insercion
        //        bool okTransUpEs = false; //bool Actualizacion Estado
        //        List<int> lstEstadosCliente; //Se almacenan todos los estados de clientes

        //        if (ListaPedidos != null && ListaPedidos.Count > 0)
        //        {
        //            Cliente ObjCliente = new Cliente("conexion");
        //            HistoricoCliente ObjHistoricoCliente = new HistoricoCliente("conexion");
        //            foreach (PedidosClienteInfo objPedidosClienteInfo in ListaPedidos) // Obtengo cada objeto de la ListaPedidos
        //            {
        //                lstEstadosCliente = new List<int>();
        //                ClienteInfo ObjClienteInfo = ObjCliente.ListxNITSimple(objPedidosClienteInfo.Nit); //Convierto un Objeto ListaPedidos en un Pedido Cliente
        //                HistoricoClienteInfo objHistoricoClienteInfo = new HistoricoClienteInfo();

        //                //PREGUNTAR A MAURO, ESTO SOLO ES PARA PASAR DE PROSPECTO A NUEVO
        //                ////En cada caso se va a modificar el historico y el cliente
        //                //objHistoricoClienteInfo = CrearObjetoHistoricoCliente(objPedidosClienteInfo.Campana, objPedidosClienteInfo.Nit, (int)EstadosClienteEnum.Prospecto, 1);
        //                //okTransUpAc = ObjHistoricoCliente.UpdateEstadoActivo(objHistoricoClienteInfo); //ACTUALIZO en SVDN_CLIENTES_HISTORICO la variable "activo" de ese usuario a True 


        //                switch (ObjClienteInfo.IdEstadosCliente)
        //                {
        //                    case (int)EstadosClienteEnum.Prospecto:
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Nuevo);
        //                        break;

        //                    case (int)EstadosClienteEnum.Nuevo:
        //                        //Por el momento coloco manualmente esta duracion del estado nuevo a 2 ¬
        //                        if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, 2) == 1) //Verifico si solo hay estados en "Nuevo" durante el periodo de duracion de estado
        //                            lstEstadosCliente.Add((int)EstadosClienteEnum.Activo);
        //                        break;

        //                    case (int)EstadosClienteEnum.PosibleEgreso:
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Activo);
        //                        break;

        //                    case (int)EstadosClienteEnum.Egreso:
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Activo);
        //                        break;

        //                    case (int)EstadosClienteEnum.Inactivo:
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Reingreso);
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Activo);
        //                        break;

        //                    case (int)EstadosClienteEnum.Retirado:
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Nuevo);
        //                        lstEstadosCliente.Add((int)EstadosClienteEnum.Activo);
        //                        break;
        //                    default:
        //                        break;
        //                }

        //                foreach (int EstadoCliente in lstEstadosCliente)
        //                {
        //                    HistoricoClienteInfo objHistoricoClienteEmprGerenInfo = new HistoricoClienteInfo();
        //                    objHistoricoClienteEmprGerenInfo = ObjHistoricoCliente.EmpresariaGerente(objPedidosClienteInfo.Nit);

        //                    objHistoricoClienteInfo = CrearObjetoHistoricoCliente(objPedidosClienteInfo.Campana, objPedidosClienteInfo.Nit,
        //                                                                            EstadoCliente, objHistoricoClienteEmprGerenInfo.Zona,
        //                                                                            objHistoricoClienteEmprGerenInfo.CodigoRegional,
        //                                                                            objHistoricoClienteEmprGerenInfo.Vendedor, 1,
        //                                                                            (int)ProcesoClienteEnum.ProcesamientoSVDN);
        //                    okTransIn = ObjHistoricoCliente.FullInsert(objHistoricoClienteInfo); //INSERTO en "SVDN_CLIENTES_HISTORICO" un registro con el estado "esc_id" = NUEVO = 1 o ACTIVO = 2
        //                    if (okTransIn)
        //                    {
        //                        okTransUpEs = ObjCliente.UpdateEstadoCliente(objPedidosClienteInfo.Nit, EstadoCliente); //ACTUALIZO en la tabla "clientes" el estado "esc_id" = NUEVO = 1 o ACTIVO = 2
        //                        if (okTransUpEs)
        //                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + EstadoCliente, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                        else
        //                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objPedidosClienteInfo.Nit + " Estado:" + EstadoCliente, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                    }
        //                    else
        //                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfo.Nit + " Estado:" + EstadoCliente, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                }

        //                bool okTransUpCliHis;
        //                PedidosCliente ObjPedidosCliente = new PedidosCliente("conexion");
        //                okTransUpCliHis = ObjPedidosCliente.UpdateProcesadoClienteHistorico(objPedidosClienteInfo.Numero, objPedidosClienteInfo.Nit);

        //                if (okTransUpCliHis)
        //                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PEDIDOS CLIENTE HISTORICO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO A TRUE PROCESADO EN CLIENTE HISTORICO:" + objPedidosClienteInfo.Nit + " procesado_cliente_historico: True", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                else
        //                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PEDIDOS CLIENTE HISTORICO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR PROCESADO EN CLIENTE HISTORICO:" + objPedidosClienteInfo.Nit + " procesado_cliente_historico: ", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //            }
        //        }
        //        else
        //        {
        //            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO HAY CLIENTES NUEVOS PARA MIGRAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

        //            ClienteInfo objClienteInfo = new ClienteInfo();
        //            OnClientesProcesamientoEventHandler handler = OnClienteEvent;
        //            if (handler != null)
        //            {
        //                objClienteInfo.TotalClientes = 1;
        //                objClienteInfo.TerminoProcess = true;
        //                handler(objClienteInfo);
        //            }
        //        }

        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR HISTORICO CLIENTES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //        //Calcula el tiempo que demora en realizar la asignacion de reglas.
        //        TimeSpan ts = DateTime.Now - _startAsignacionTime;
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: PROCESO DE PROCESAR HISTORICO CLIENTES TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
        //        System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI ERROR PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //    }
        //}


        /// <summary>
        /// Cambia los estados de las empresarias que no realizaron pedidos en las tablas (SVDN_PEDIDOSC1_2000, SVDN_CLIENTES_HISTORICO y clientes)
        /// </summary>
        /// <param name="ListaSinPedidosXCampana"></param>
        //public void ProcesarHistoricoClientesInactivacion(List<ClienteInfo> ListaSinPedidosXCampana)
        //{
        //    try
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE PROCESAR HISTORICO CLIENTES. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //        //Captura el tiempo de inicio
        //        _startAsignacionTime = DateTime.Now;
        //        bool okTransIn = false; //bool Insercion
        //        bool okTransUpEs = false; //bool Actualizacion Estado
        //        int Activo = 1;
        //        List<int> lstEstadosCliente; //Se almacenan todos los estados de clientes


        //        List<ClienteInfo> lstClientesSinPedidos;
        //        Application.Enterprise.Business.Cliente moduleCliSinPed = new Application.Enterprise.Business.Cliente("conexion");
        //        lstClientesSinPedidos = moduleCliSinPed.ListEmpresariaSinPedido();


        //        string CampanaActual;
        //        List<CampanaInfo> ListUltimasCampanas;
        //        Application.Enterprise.Business.Campana moduleCamp = new Application.Enterprise.Business.Campana("conexion");
        //        ListUltimasCampanas = moduleCamp.ListUltimasCampanas();
        //        CampanaActual = ListUltimasCampanas[0].Campana.ToString();


        //        if (ListaSinPedidosXCampana != null && ListaSinPedidosXCampana.Count > 0)
        //        {
        //            Cliente ObjCliente = new Cliente("conexion");
        //            HistoricoCliente ObjHistoricoCliente = new HistoricoCliente("conexion");
        //            foreach (ClienteInfo objClienteInfo in ListaSinPedidosXCampana) // Obtengo cada objeto de la ListaPedidos
        //            {
        //                Activo = 1;
        //                lstEstadosCliente = new List<int>();
        //                ClienteInfo ObjClienteInfo = ObjCliente.ListxNITSimple(objClienteInfo.Nit); //Convierto un Objeto ListaPedidos en un Pedido Cliente
        //                HistoricoClienteInfo objHistoricoClienteInfo = new HistoricoClienteInfo();

        //                List<HistoricoClienteInfo> lstHistoricoCliente = new List<HistoricoClienteInfo>();
        //                lstHistoricoCliente = ObjHistoricoCliente.HistoricoHoyxNit(objClienteInfo.Nit);

        //                if (lstHistoricoCliente.Count == 0) //Consulto si ya existe un registro de la fecha de hoy y en caso de que no, se procesa una nueva
        //                {
        //                    switch (ObjClienteInfo.IdEstadosCliente)
        //                    {
        //                        case (int)EstadosClienteEnum.Prospecto:
        //                            //PREGUNTAR
        //                            if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, (int)DuracionEstadosSinPedidoxCampanaClienteEnum.Prospecto) == 0) //Verifico si solo hay estados en "Prospecto" durante el periodo de duracion de estado
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.PosibleEgreso);
        //                            else
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Prospecto);
        //                            break;

        //                        case (int)EstadosClienteEnum.Nuevo:
        //                            if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, (int)DuracionEstadosSinPedidoxCampanaClienteEnum.Nuevo) == 0) //Verifico si solo hay estados en "Nuevo" durante el periodo de duracion de estado
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.PosibleEgreso);
        //                            else
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Nuevo);
        //                            break;

        //                        case (int)EstadosClienteEnum.Activo:
        //                            if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, (int)DuracionEstadosSinPedidoxCampanaClienteEnum.Activo) == 0) //Verifico si solo hay estados en "Activo" durante el periodo de duracion de estado
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.PosibleEgreso);
        //                            else
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Activo);
        //                            break;

        //                        case (int)EstadosClienteEnum.PosibleEgreso:
        //                            if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, (int)DuracionEstadosSinPedidoxCampanaClienteEnum.PosibleEgreso) == 0) //Verifico si solo hay estados en "Activo" durante el periodo de duracion de estado
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Egreso);
        //                            else
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.PosibleEgreso);
        //                            break;

        //                        case (int)EstadosClienteEnum.Egreso:
        //                            if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, (int)DuracionEstadosSinPedidoxCampanaClienteEnum.Egreso) == 0) //Verifico si solo hay estados en "Activo" durante el periodo de duracion de estado
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Inactivo);
        //                            else
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Egreso);
        //                            break;

        //                        case (int)EstadosClienteEnum.Inactivo:
        //                            Activo = 0;
        //                            if (ObjHistoricoCliente.CantidadTransicionesxNit(ObjClienteInfo.Nit, (int)DuracionEstadosSinPedidoxCampanaClienteEnum.Inactivo) == 0) //Verifico si solo hay estados en "Activo" durante el periodo de duracion de estado
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Retirado);
        //                            else
        //                                lstEstadosCliente.Add((int)EstadosClienteEnum.Inactivo);
        //                            break;
        //                        default:
        //                            break;
        //                    }

        //                    foreach (int EstadoCliente in lstEstadosCliente)
        //                    {
        //                        HistoricoClienteInfo objHistoricoClienteEmprGerenInfo = new HistoricoClienteInfo();
        //                        objHistoricoClienteEmprGerenInfo = ObjHistoricoCliente.EmpresariaGerente(objClienteInfo.Nit);

        //                        objHistoricoClienteInfo = CrearObjetoHistoricoCliente(CampanaActual, objClienteInfo.Nit,
        //                                                                                EstadoCliente, objHistoricoClienteEmprGerenInfo.Zona,
        //                                                                                objHistoricoClienteEmprGerenInfo.CodigoRegional,
        //                                                                                objHistoricoClienteEmprGerenInfo.Vendedor, Activo,
        //                                                                                (int)ProcesoClienteEnum.ProcesamientoSVDN); //Preguntar Procesamiento SVDN

        //                        okTransIn = ObjHistoricoCliente.FullInsert(objHistoricoClienteInfo); //INSERTO en "SVDN_CLIENTES_HISTORICO" un registro con el estado "esc_id" = NUEVO = 1 o ACTIVO = 2
        //                        if (okTransIn)
        //                        {
        //                            okTransUpEs = ObjCliente.UpdateEstadoCliente(objClienteInfo.Nit, EstadoCliente); //ACTUALIZO en la tabla "clientes" el estado "esc_id" = NUEVO = 1 o ACTIVO = 2
        //                            if (okTransUpEs)
        //                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO OK ESTADO DE CLIENTE DE NIT:" + objClienteInfo.Nit + " Estado:" + EstadoCliente, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                            else
        //                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR ESTADO DE CLIENTE NIT:" + objClienteInfo.Nit + " Estado:" + EstadoCliente, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                        }
        //                        else
        //                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO GUARDAR HISTORICO DE CLIENTES ESTADO NUEVO DE NIT:" + objHistoricoClienteInfo.Nit + " Estado:" + EstadoCliente, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO HAY CLIENTES NUEVOS PARA MIGRAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

        //            ClienteInfo objClienteInfo = new ClienteInfo();
        //            OnClientesProcesamientoEventHandler handler = OnClienteEvent;
        //            if (handler != null)
        //            {
        //                objClienteInfo.TotalClientes = 1;
        //                objClienteInfo.TerminoProcess = true;
        //                handler(objClienteInfo);
        //            }
        //        }

        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PROCESAR HISTORICO CLIENTES OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //        //Calcula el tiempo que demora en realizar la asignacion de reglas.
        //        TimeSpan ts = DateTime.Now - _startAsignacionTime;
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS PROCESAR HISTORICO CLIENTES: PROCESO DE PROCESAR HISTORICO CLIENTES TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
        //        System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));


        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI ERROR PROCESAR HISTORICO CLIENTES: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
        //    }

        //}

        #endregion

        /// <summary>
        /// Calcula la consecutividad de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool CalcularConsecutividadCampanasCliente(string Nit)
        {
            bool Consecutividad = false;

            Cliente ObjCliente = new Cliente("conexion");

            List<string> CampanasList = new List<string>();

            CampanasList = ObjCliente.ListConsecutividadCliente(Nit);

            if (CampanasList != null)
            {
                Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                Application.Enterprise.Business.Campana ObjCampana = new Application.Enterprise.Business.Campana("conexion");
                Application.Enterprise.CommonObjects.CampanaInfo ObjCampanaInfo = new Application.Enterprise.CommonObjects.CampanaInfo();

                int[] CampanasListArrayInt = new int[24];

                for (int i = 0; i < CampanasList.Count; i++)
                {
                    CampanasListArrayInt[i] = Convert.ToInt32(CampanasList[i]);
                }

                //Ordenar campañas de mayor a menor
                CampanasList.Clear();
                CampanasList = OrdenarBurbuja(CampanasListArrayInt);
                CampanasList.Reverse();

                int CampanasConsecutivas = 0;

                ObjCampanaInfo = ObjCampana.ListxCampanaFinal(DateTime.Now.Year.ToString());

                for (int i = 0; i < CampanasList.Count; i++)
                {
                    if (CampanasList.Count > (i + 1))
                    {
                        int CampanaSiguiente = Convert.ToInt32(CampanasList[i]);
                        int CampanaAnterior = Convert.ToInt32(CampanasList[i + 1]);

                        string CampanaFinal = ObjCampanaInfo.Campana.Substring(2, 2) + ObjCampanaInfo.Campana.Substring(0, 2);

                        //Si es igual a la campana final se debe contar como sensecutivo por que puede pasar de año de camp 12 pasar a la camp 01.
                        if (Convert.ToInt32(CampanaFinal) != CampanaAnterior)
                        {
                            if ((CampanaSiguiente - 1) == CampanaAnterior)
                            {
                                CampanasConsecutivas = CampanasConsecutivas + 1;
                            }
                            else
                            {
                                CampanasConsecutivas = 0;
                            }
                        }
                        else
                        {
                            CampanasConsecutivas = CampanasConsecutivas + 1;
                        }

                        //Si la consecutividad es igual a la de los parametros, es por que la empresaria pasaria a ser nueva.
                        if (CampanasConsecutivas >= Convert.ToInt32(ObjParametros.ListxId((int)ParametrosEnum.CampanasConsecutivas).Valor))
                        {
                            Consecutividad = true;
                            break;
                        }
                    }
                }
            }

            return Consecutividad;
        }


        /// <summary>
        /// Calcula la consecutividad de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool CalcularConsecutividadInactividadCliente(string Nit)
        {
            bool Consecutividad = false;
            int CantidadInactividad = 0;

            Cliente ObjCliente = new Cliente("conexion");

            List<string> CampanasList = new List<string>();

            CampanasList = ObjCliente.ListConsecutividadCliente(Nit);

            if (CampanasList != null)
            {
                Application.Enterprise.CommonObjects.ParametrosInfo ObjParametrosInfo = new Application.Enterprise.CommonObjects.ParametrosInfo();
                Application.Enterprise.Business.Parametros ObjParametros = new Application.Enterprise.Business.Parametros("conexion");

                Application.Enterprise.Business.Campana ObjCampana = new Application.Enterprise.Business.Campana("conexion");
                Application.Enterprise.CommonObjects.CampanaInfo ObjCampanaInfo = new Application.Enterprise.CommonObjects.CampanaInfo();

                Application.Enterprise.CommonObjects.CampanaInfo ObjCampanaActualInfo = new Application.Enterprise.CommonObjects.CampanaInfo();

                // ObjCampanaActualInfo = ObjCampana.ListxGetDate();

                if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                {
                    ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                }
                else
                {
                    ObjCampanaInfo = ObjCampana.ListxGetDate();
                }

                //Se adiciona la campana actual a la lista para poder comparar con las campanas anteriores de pedidos.
                CampanasList = AdicionarCampanaActual((ObjCampanaActualInfo.Campana.Substring(2, 2) + ObjCampanaActualInfo.Campana.Substring(0, 2)), CampanasList);

                int[] CampanasListArrayInt = new int[24];

                for (int i = 0; i < CampanasList.Count; i++)
                {
                    CampanasListArrayInt[i] = Convert.ToInt32(CampanasList[i]);
                }

                //Ordenar campañas de mayor a menor
                CampanasList.Clear();
                CampanasList = OrdenarBurbuja(CampanasListArrayInt);
                CampanasList.Reverse();

                int CampanasConsecutivas = 0;

                ObjCampanaInfo = ObjCampana.ListxCampanaFinal(DateTime.Now.Year.ToString());

                for (int i = 0; i < CampanasList.Count; i++)
                {
                    if (CampanasList.Count > (i + 1))
                    {
                        int CampanaSiguiente = Convert.ToInt32(CampanasList[i]);
                        int CampanaAnterior = Convert.ToInt32(CampanasList[i + 1]);

                        string CampanaFinal = ObjCampanaInfo.Campana.Substring(2, 2) + ObjCampanaInfo.Campana.Substring(0, 2);

                        //Si es igual a la campana final se debe contar como sensecutivo por que puede pasar de año de camp 12 pasar a la camp 01.
                        if (Convert.ToInt32(CampanaFinal) != CampanaAnterior)
                        {
                            CantidadInactividad = CampanaSiguiente - CampanaAnterior;

                            //si la diferencia es igual a 1 es por que puede tener campañas consecutivas.
                            if (CantidadInactividad == 1)
                            {
                                if ((CampanaSiguiente - 1) == CampanaAnterior)
                                {
                                    CampanasConsecutivas = CampanasConsecutivas + 1;
                                }
                                else
                                {
                                    CampanasConsecutivas = 0;
                                    break;
                                }
                            }
                            else
                            {
                                //Si la consecutividad es igual a la de los parametros, es por que la empresaria pasaria a ser nueva.
                                if (CantidadInactividad >= Convert.ToInt32(ObjParametros.ListxId((int)ParametrosEnum.CampanasConsecutivas).Valor))
                                {
                                    Consecutividad = true;
                                    break;
                                }
                                break;
                            }
                        }
                        else
                        {
                            CampanasConsecutivas = CampanasConsecutivas + 1;
                        }
                    }
                }
            }

            return Consecutividad;
        }

        // ordenar elementos de un arreglo con el metodo burbuja 
        public List<string> OrdenarBurbuja(int[] vNumeros)
        {
            int j, i, temp;
            List<string> ListaRetornada = new List<string>();

            /* Ordenamos los números del vector vNumeros por el método de burbuja */
            for (i = 0; i < (vNumeros.Length - 1); i++)
            {
                for (j = i + 1; j < vNumeros.Length; j++)
                {
                    if (vNumeros[j] < vNumeros[i])
                    {
                        temp = vNumeros[j];
                        vNumeros[j] = vNumeros[i];
                        vNumeros[i] = temp;
                    }
                }
            }

            for (int z = 0; z < vNumeros.Length; z++)
            {
                if (vNumeros[z] > 0)
                {
                    ListaRetornada.Add(vNumeros[z].ToString());
                }
            }

            return ListaRetornada;
        }


        /// <summary>
        /// Pregunta si la campana actual existe en la lista, sino se agrega
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <param name="Lista"></param>
        /// <returns></returns>
        private List<string> AdicionarCampanaActual(string CampanaActual, List<string> Lista)
        {
            bool ExisteCamp = false;

            foreach (string CampanaList in Lista)
            {
                if (CampanaList == CampanaActual)
                {
                    ExisteCamp = true;
                }
            }

            if (!ExisteCamp)
            {
                Lista.Add(CampanaActual);
            }

            return Lista;
        }

        /// <summary>
        /// Valida si existe un pedido duplicado.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="objListPedidosClienteInfo"></param>
        /// <returns></returns>
        private bool ValidarExisteRegistroDuplicado(string NumeroPedido, List<PedidosClienteInfo> objListPedidosClienteInfo)
        {
            bool Existe = false;
            int contador = 0;

            foreach (PedidosClienteInfo item in objListPedidosClienteInfo)
            {
                if (NumeroPedido == item.Numero)
                {
                    contador = contador + 1;

                    if (contador >= 2)
                    {
                        Existe = true;
                        break;
                    }
                }
            }
            return Existe;
        }

        /// <summary>
        /// Calcula la cantidad disponible en el inventario.
        /// </summary>
        /// <param name="CantidadPedida"></param>
        /// <param name="CantidadEnInventario"></param>
        /// <returns></returns>
        private Decimal CantidadDisponible(decimal CantidadPedida, decimal CantidadEnInventario)
        {
            decimal CantidadDisp = 0;
            //Si el inventario es mayor que la cantidad pedida es por que si hay items en el inventario disponibles.
            if ((CantidadEnInventario - CantidadPedida) >= 0)
            {
                CantidadDisp = CantidadPedida;
            }
            else
            {
                CantidadDisp = CantidadEnInventario;
            }

            return CantidadDisp;
        }

        /// <summary>
        /// Retona el valor del saldo resultado de
        /// </summary>
        /// <param name="CantidadDisponible"></param>
        /// <param name="CantidadEnInventario"></param>
        /// <returns></returns>
        private decimal CantidadSaldo(decimal CantidadDisponible, decimal CantidadEnInventario)
        {
            decimal Saldo = 0;

            Saldo = CantidadEnInventario - CantidadDisponible;

            if (Saldo <= 0)
            {
                Saldo = 0;
            }

            return Saldo;
        }

        /// <summary>
        /// Selecciona de la tabla temporal los registros filtrados por la regla.
        /// </summary>
        /// <param name="QueryRegla"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxRegla(string QueryRegla)
        {
            return module.ListxRegla(QueryRegla);
        }

        /// <summary>
        /// Selecciona de la tabla temporal los registros filtrados por la regla para PREMIOS.
        /// </summary>
        /// <param name="QueryReglaPremios"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxReglaPremios(string QueryReglaPremios)
        {
            return module.ListxReglaPremios(QueryReglaPremios);
        }

        /// <summary>
        /// lista todos los Pedidos Cliente existentes en la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTablaTemporal()
        {
            return module.ListTablaTemporal();
        }

        /// <summary>
        ///  lista todos los Pedidos Cliente con premios existentes en la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTablaPremiosTemporal()
        {
            return module.ListTablaPremiosTemporal();
        }

        /// <summary>
        /// Lista el Pedido de un Cliente para asignar premio en la tabla temporal.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTablaPremiosTemporalxNit(string Nit)
        {
            return module.ListTablaPremiosTemporalxNit(Nit);
        }

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampana(string Zona, string Campana)
        {
            return module.ListxZonaxCampana(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos no bloqueados que corresponden a una zona y una campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueado(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaNoBloqueado(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos no bloqueados que deben contener un premio.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueadoPremio(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaNoBloqueadoPremio(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos procesados con premios y flete listos para facturar.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidoFacturar(string Zona, string Campana)
        {
            return module.ListPedidoFacturar(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos y sus estados depues de procesados.
        /// </summary>
        /// <param name="Mailgroup"></param>
        /// <param name="Zona"></param>
        /// <param name="IdEstado"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosProcesados(string Mailgroup, string Zona, int IdEstado)
        {
            return module.ListPedidosProcesados(Mailgroup, Zona, IdEstado);
        }

        /// <summary>
        /// Lista el encabezado de un pedido por numero.
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListEncabezadoPedidoxNumero(string Numero)
        {
            return module.ListEncabezadoPedidoxNumero(Numero);
        }

        /// <summary>
        /// Lista los pedidos disponibles para anular sin estado en produccion.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnular()
        {
            return module.ListPedidosAnular();
        }

        /// <summary>
        /// Lista los pedidos del catalogo nivi para procesar por zona y campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosProcesarNivi(string Zona, string Campana)
        {
            return module.ListPedidosProcesarNivi(Zona, Campana);
        }

        /// <summary>
        /// lista todos los Pedidos de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteRegional(string codvendedor, string Campana)
        {
            return module.ListxGerenteRegional(codvendedor, Campana);
        }



        /// <summary>
        /// lista todos los Pedidos Facturados de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteRegionalFacturados(string CedulaRegional, string Campana)
        {
            return module.ListxGerenteRegionalFacturados(CedulaRegional, Campana);
        }

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaSimulador(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaSimulador(Zona, Campana);
        }

        /// <summary>
        /// Trae los pedidos de los mailgroups activos para facturar
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosActivosFacturar()
        {
            return module.ListxPedidosActivosFacturar();
        }

        /// <summary>
        ///  Consulta el nivel de servicio resultado del procesamiento
        /// </summary>
        /// <returns></returns>
        public PedidosClienteInfo ListxTotalNivelServicio()
        {
            return module.ListxTotalNivelServicio();
        }

        /// <summary>
        /// Consulta las empresarias que ganaron premio de bienvenida
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxTotalEmpresariasNuevas()
        {
            return module.ListxTotalEmpresariasNuevas();
        }

        /// <summary>
        ///  Consulta la cantidad de fletes asignados despues del procesamiento
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxTotalFletesAsignados()
        {
            return module.ListxTotalFletesAsignados();
        }

        /// <summary>
        /// lista el total de pedidos sin facturar
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxTotalPedidosProcesados()
        {
            return module.ListxTotalPedidosProcesados();
        }

        /// <summary>
        ///  lista los pedidos detallados para exportar a excel o pdf
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosExportar(string Vendedor)
        {
            return module.ListxPedidosExportar(Vendedor);
        }

        /// <summary>
        /// lista los pedidos detallados de una empresaria para exportar a excel o pdf
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosExportarxNit(string Nit)
        {
            return module.ListxPedidosExportarxNit(Nit);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidos(string Campana, string zona)
        {
            return module.ListPedidosRetenidos(Campana, zona);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una empresaria.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosxEmpresariaPortal(string Campana, string Nit)
        {
            return module.ListPedidosRetenidosxEmpresariaPortal(Campana, Nit);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana de un lider.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosLider(string Campana, string IdLider)
        {
            return module.ListPedidosRetenidosLider(Campana, IdLider);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana x Empresaria
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosxEmpresaria(string Campana, string Nit)
        {
            return module.ListPedidosRetenidosxEmpresaria(Campana, Nit);
        }

        /// <summary>
        /// Lista los pedidos anulados
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnulados(string Campana, string zona)
        {
            return module.ListPedidosAnulados(Campana, zona);
        }

        /// <summary>
        /// Lista todos los pedidos anulados categorizados.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTodosPedidosAnulados()
        {
            return module.ListTodosPedidosAnulados();
        }

        /// <summary>
        /// Lista los pedidos anulados de un lider.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosLider(string Campana, string IdLider)
        {
            return module.ListPedidosAnuladosLider(Campana, IdLider);
        }

        /// <summary>
        /// Lista los pedidos anulados de una empresaria.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosxNit(string Campana, string Nit)
        {
            return module.ListPedidosAnuladosxNit(Campana, Nit);
        }

        /// <summary>
        ///  Lista los pedidos anulados de una empresaria del portal.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosxEmpresariaPortal(string Campana, string Nit)
        {
            return module.ListPedidosAnuladosxEmpresariaPortal(Campana, Nit);
        }

        /// <summary>
        /// Lista la informacion de los pedidos para el modulo de SAC.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosSAC(string Nit, string NumeroPedido)
        {
            return module.ListPedidosSAC(Nit, NumeroPedido);
        }

        /// <summary>
        /// GAVL  Sobrecarga para buscar los pedidos  con parametro de zona
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosSAC(string Nit, string NumeroPedido, string Zona)
        {
            return module.ListPedidosSAC(Nit, NumeroPedido, Zona);
        }


        /// <summary>
        /// Lista los pedidos que se encuentran en un estado que no esten bloqueados de una campaña.
        /// </summary>
        /// <param name="EstadoPedido"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEstadoPedido(int EstadoPedido, string Campana)
        {
            return module.ListxEstadoPedido(EstadoPedido, Campana);
        }

        /// <summary>
        /// Reporte de pedidos digitados por servicio al cliente.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxReportePedidosCCN()
        {
            return module.ListxReportePedidosCCN();
        }

        /// <summary>
        /// lista todos los Pedidos de una zona maestra por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaMaestra(string ZonaMaestra, string Campana)
        {
            return module.ListxZonaMaestra(ZonaMaestra, Campana);
        }

        /// <summary>
        /// Lista todos los pedidos de una gerente de zona por una campaña facturados en G&G para Zona Maestra.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaFacturadosZonaMaestra(string ZonaMaestra, string Campana)
        {
            return module.ListxGerenteZonaFacturadosZonaMaestra(ZonaMaestra, Campana);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora para Zona Maestra.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="ZonaMaestra"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosZonaMaestra(string Campana, string ZonaMaestra)
        {
            return module.ListPedidosRetenidosZonaMaestra(Campana, ZonaMaestra);
        }

        /// <summary>
        /// Lista los pedidos anulados para Zona Maestra.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="ZonaMaestra"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosZonaMaestra(string Campana, string ZonaMaestra)
        {
            return module.ListPedidosAnuladosZonaMaestra(Campana, ZonaMaestra);
        }

        /// <summary>
        /// Lista la informacion de los pedidos para el modulo de SAC para una Zona Maestra.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <param name="ZonaMestra"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosSACZonaMaestra(string Nit, string NumeroPedido, string ZonaMestra)
        {
            return module.ListPedidosSACZonaMaestra(Nit, NumeroPedido, ZonaMestra);
        }

        /// <summary>
        /// Lista todos los pedidos en reserva guardados por una gerente para Zona Maestra.
        /// </summary>
        /// <param name="ZonaMaestra"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosZonaMaestra(string ZonaMaestra, string Campana)
        {
            return module.ListxGerenteZonaReservadosZonaMaestra(ZonaMaestra, Campana);
        }


        /// <summary>
        /// Guarda los registros filtrados por una regla en la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public void InsertxRegla(PedidosClienteInfo item)
        {
            try
            {
                module.InsertxRegla(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Guarda los pedidos que fueron seleccionados para asignar premio en la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public void InsertxReglaxPremio(PedidosClienteInfo item)
        {
            try
            {
                module.InsertxReglaxPremio(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente en las tablas de SIMULACION.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertSimulador()
        {
            try
            {
                return module.InsertSimulador();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los encabezados de pedidos en MKT que tienen premio.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertPremiosMkt(PedidosClienteInfo item)
        {
            try
            {
                return module.InsertPremiosMkt(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda los encabezados de pedidos en Nivi listos para facturar.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertFacturar(PedidosClienteInfo item)
        {
            try
            {
                return module.InsertFacturar(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los pedidos de la tabla temporal
        /// </summary>
        /// <returns></returns>
        public bool DeleteTemporal()
        {
            try
            {
                return module.DeleteTemporal();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los pedidos con premios de la tabla temporal
        /// </summary>
        /// <returns></returns>
        public bool DeletePremiosTemporal()
        {
            try
            {
                return module.DeletePremiosTemporal();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los pedidos de la tabla temporal de una campaña y una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public bool DeleteTemporalxZonaxCampana(string Zona, string Campana)
        {
            try
            {
                return module.DeleteTemporalxZonaxCampana(Zona, Campana);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Lista todos los pedidos de la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTemporal()
        {
            return module.ListTemporal();
        }

        /// <summary>
        /// Realiza la actualizacion del orden  de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public bool UpdateOrden(string NumeroPedido, int Orden)
        {
            try
            {
                return module.UpdateOrden(NumeroPedido, Orden);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del orden  de un pedido para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public bool UpdateOrdenSimulador(string NumeroPedido, int Orden)
        {
            try
            {
                return module.UpdateOrdenSimulador(NumeroPedido, Orden);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }
        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña y por orden asignado.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrden(string Zona, string Campana, int Orden)
        {
            return module.ListxZonaxCampanaxOrden(Zona, Campana, Orden);
        }

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña y por orden asignado para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrdenSimulador(string Zona, string Campana, int Orden)
        {
            return module.ListxZonaxCampanaxOrdenSimulador(Zona, Campana, Orden);
        }


        /// <summary>
        /// GAVL 10/04/2013 BUSQUEDA DE PEDIDOS INTERBLOQUEADOS
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosInterbloqueados()
        {
            return module.ListPedidosInterbloqueados();
        }

        /// <summary>
        /// GAVL 11/04/2014 LIBERA LOS PEDIDOS QUE ESTEN INTERBLOQUEADOS 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateLiberarPedidosInterbloqueados(string Usuario)
        {
            try
            {
                return module.UpdateLiberarPedidosInterbloqueados(Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Actualiza la ciudad de despacho de un pedido.
        /// </summary>
        /// <param name="CiudadDespacho"></param>
        /// <returns></returns>
        public bool UpdateCiudadDespacho(string CiudadDespacho)
        {
            try
            {
                return module.UpdateCiudadDespacho(CiudadDespacho);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// SIESA: actualiza datos del pedido despues de enviado a siesa.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdatePedidoEnSiesa(string NumeroPedido)
        {
            try
            {
                return module.UpdatePedidoEnSiesa(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina un pedido especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletexNumeroPedido(string NumeroPedido)
        {
            try
            {
                return module.DeletexNumeroPedido(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina un pedido de premio temporal especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletePedidoPremioTemporal(string NumeroPedido)
        {
            try
            {
                return module.DeletePedidoPremioTemporal(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina un pedido de premio temporal especifico por numero, tipo query y id articulo.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="IdArticulo"></param>
        /// <param name="TipoQuery"></param>
        /// <returns></returns>
        public bool DeletePedidoPremioTemporalSimple(string NumeroPedido, int IdArticulo, string TipoQuery)
        {
            try
            {
                return module.DeletePedidoPremioTemporalSimple(NumeroPedido, IdArticulo, TipoQuery);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña ordenados por las reglas asignadas.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        /// //
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrdenProcesado(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaxOrdenProcesado(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña ordenados por las reglas asignadas para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrdenProcesadoSimulador(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaxOrdenProcesadoSimulador(Zona, Campana);
        }

        /// <summary>
        /// Lista si existe un pedido especifico en MKT.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidosMkt(string NumeroPedido)
        {
            return module.ListPedidosMkt(NumeroPedido);
        }

        /// <summary>
        /// lista un Pedido por numero de la tabla temporal de premios .
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListTablaPremiosTemporalxNumero(string NumeroPedido)
        {
            return module.ListTablaPremiosTemporalxNumero(NumeroPedido);
        }

        /// <summary>
        /// Lista un pedido especifico de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListxNitxCampana(string Nit, string Campana)
        {
            return module.ListxNitxCampana(Nit, Campana);
        }

        /// <summary>
        /// --Lista un pedido especifico de un cliente x camapana x catalogo
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListxNitxCampanaxCatalogo(string Nit, string Campana, string Catalogo)
        {
            return module.ListxNitxCampanaxCatalogo(Nit, Campana, Catalogo);
        }

        /// <summary>
        /// Lista los pedidos para sumarle el valor del felte luego que estan en produccion
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaSumarFlete(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaSumarFlete(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos bloqueados de algun tipo de catalogo nivi.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosBloqueados(string Zona, string Campana)
        {
            return module.ListPedidosBloqueados(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos bloqueados de algun tipo de catalogo nivi para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosBloqueadosSimulador(string Zona, string Campana)
        {
            return module.ListPedidosBloqueadosSimulador(Zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos especificos de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxNitxCampana(string Nit, string Campana)
        {
            return module.ListPedidosxNitxCampana(Nit, Campana);
        }

        /// <summary>
        /// Lista los pedidos especificos de un cliente para el simulador
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxNitxCampanaSimulador(string Nit, string Campana)
        {
            return module.ListPedidosxNitxCampanaSimulador(Nit, Campana);
        }

        /// <summary>
        /// Lista los pedidos de una empresaria por una campaña del catalogo outlet y de hogar.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresariaOuletHogar(string Nit, string Campana)
        {
            return module.ListPedidosxEmpresariaOuletHogar(Nit, Campana);
        }

        /// <summary>
        /// Lista los pedidos de una empresaria por una campaña del catalogo outlet y de hogar para el simulador.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresariaOuletHogarSimulador(string Nit, string Campana)
        {
            return module.ListPedidosxEmpresariaOuletHogarSimulador(Nit, Campana);
        }

        /// <summary>
        /// Lista los pedidos no bloqueados que corresponden a una zona y una campaña para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueadoSimulador(string Zona, string Campana)
        {
            return module.ListxZonaxCampanaNoBloqueadoSimulador(Zona, Campana);
        }

        /// <summary>
        /// lista los pedidos de un cliente facturados para saber si se cobra flete
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxNitxCampanaPedidosGYG(string Nit, string Campana)
        {
            return module.ListxNitxCampanaPedidosGYG(Nit, Campana);
        }


        //public List<PedidosClienteInfo> PedidosProcesadosClienteHistorico()
        //{
        //    return module.PedidosProcesadosClienteHistorico();
        //}

        /// <summary>
        /// Lista todos los pedidos de una empresaria de zona por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxNitFacturados(string Nit, string Campana)
        {
            return module.ListxNitFacturados(Nit, Campana);
        }


        /// <summary>
        /// Lista la fecha de cierre de un pedido para la devolucion en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListFechaCierreDevolucion(string NumeroPedido)
        {
            return module.ListFechaCierreDevolucion(NumeroPedido);
        }



        /// <summary>
        /// Realiza la actualizacion del estado procesado del pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateProcesado(string NumeroPedido, bool Procesado)
        {
            try
            {
                return module.UpdateProcesado(NumeroPedido, Procesado);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado procesado del pedido para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateProcesadoSimulador(string NumeroPedido, bool Procesado)
        {
            try
            {
                return module.UpdateProcesadoSimulador(NumeroPedido, Procesado);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del nivel de servicio y estado.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="NivelServicioEstado"></param>
        /// <param name="NivelServicioEstimado"></param>
        /// <param name="NivelServicioReal"></param>
        /// <param name="NivelServicioTipo"></param>
        /// <returns></returns>
        public bool UpdateNivelServicio(string NumeroPedido, bool NivelServicioEstado, decimal NivelServicioEstimado, decimal NivelServicioReal, string NivelServicioTipo)
        {
            try
            {
                return module.UpdateNivelServicio(NumeroPedido, NivelServicioEstado, NivelServicioEstimado, NivelServicioReal, NivelServicioTipo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EstadoPedido">0 =	Sin Estado, 1 =	Normal, 2 =	Agotado, 3 = Retenido Premios, 4 = Nivel Servicio, 5 =	Cartera, 6 = Desmanteladora</param>
        /// <returns></returns>
        public bool UpdateEstadoPedido(string NumeroPedido, int EstadoPedido)
        {
            try
            {
                return module.UpdateEstadoPedido(NumeroPedido, EstadoPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la anulacion de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateAnularPedido(string NumeroPedido)
        {
            try
            {
                return module.UpdateAnularPedido(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la anulacion de un pedido de reserva en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateAnularPedidoReserva(string NumeroPedido, string motivo, string codmotivo, string Usuario)
        {
            try
            {
                return module.UpdateAnularPedidoReserva(NumeroPedido, motivo, codmotivo, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la anulacion de un pedido en Borrador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateAnularPedidoBorrador(string NumeroPedido, string motivo, string codmotivo, string Usuario)
        {
            try
            {
                return module.UpdateAnularPedidoBorrador(NumeroPedido, motivo, codmotivo, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la des-anulacion de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateDesAnularPedido(string NumeroPedido)
        {
            try
            {
                return module.UpdateDesAnularPedido(NumeroPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// Realiza la actualizacion del tipo query de un pedido temporal para verificar en la asignacion de premios.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="TipoQuery"></param>
        /// <returns></returns>
        public bool UpdateTipoQuery(string NumeroPedido, string TipoQuery)
        {
            try
            {
                return module.UpdateTipoQuery(NumeroPedido, TipoQuery);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de los pedidos que se encuentran bloqueados por nivel de servicio y por desmanteladora por camapaña actual.
        /// </summary>
        /// <returns></returns>
        public bool UpdateBloqueadosNivelServicio()
        {
            try
            {
                return module.UpdateBloqueadosNivelServicio();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de los pedidos que se encuentran excluidos del procesamiento por camapaña actual.
        /// </summary>
        /// <returns></returns>
        public bool UpdateBloqueadosExcluidos()
        {
            try
            {
                return module.UpdateBloqueadosExcluidos();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de los pedidos que se encuentran bloqueados por cartera.
        /// </summary>
        /// <returns></returns>
        public bool UpdateBloqueadosCartera()
        {
            try
            {
                return module.UpdateBloqueadosCartera();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del mes de un pedido
        /// </summary>
        /// <param name="Numero"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool UpdateMes(string Numero, string Mes)
        {
            try
            {
                return module.UpdateMes(Numero, Mes);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado en produccion, para que en los premios no repita los pedidos de las tablas de nivi y las svdn.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateEnProduccion(string NumeroPedido, bool EnProduccion)
        {
            try
            {
                return module.UpdateEnProduccion(NumeroPedido, EnProduccion);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        ///  Realiza la actualizacion del valor de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        public bool UpdateValorPedido(string NumeroPedido, decimal Valor, decimal IVA)
        {
            try
            {
                return module.UpdateValorPedido(NumeroPedido, Valor, IVA);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        ///  Realiza la actualizacion del valor de un pedido en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        public bool UpdateValorPedidoSVDN(string NumeroPedido, decimal Valor, decimal IVA)
        {
            try
            {
                return module.UpdateValorPedidoSVDN(NumeroPedido, Valor, IVA);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        ///  Realiza la actualizacion del valor de un pedido en SVDN simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        public bool UpdateValorPedidoSVDNSimulador(string NumeroPedido, decimal Valor, decimal IVA)
        {
            try
            {
                return module.UpdateValorPedidoSVDNSimulador(NumeroPedido, Valor, IVA);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de un pedido en el simulador
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EstadoPedido">0 =	Sin Estado, 1 =	Normal, 2 =	Agotado, 3 = Retenido Premios, 4 = Nivel Servicio, 5 =	Cartera, 6 = Desmanteladora</param>
        /// <returns></returns>
        public bool UpdateEstadoPedidoSimulador(string NumeroPedido, int EstadoPedido)
        {
            try
            {
                return module.UpdateEstadoPedidoSimulador(NumeroPedido, EstadoPedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado en produccion, para que en los premios no repita los pedidos de las tablas de nivi y las svdn en el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateEnProduccionSimulador(string NumeroPedido, bool EnProduccion)
        {
            try
            {
                return module.UpdateEnProduccionSimulador(NumeroPedido, EnProduccion);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del nivel de servicio y estado simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="NivelServicioEstado"></param>
        /// <param name="NivelServicioEstimado"></param>
        /// <param name="NivelServicioReal"></param>
        /// <param name="NivelServicioTipo"></param>
        /// <returns></returns>
        public bool UpdateNivelServicioSimulador(string NumeroPedido, bool NivelServicioEstado, decimal NivelServicioEstimado, decimal NivelServicioReal, string NivelServicioTipo)
        {
            try
            {
                return module.UpdateNivelServicioSimulador(NumeroPedido, NivelServicioEstado, NivelServicioEstimado, NivelServicioReal, NivelServicioTipo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// /Realiza la actualizacion del valor precio catalogo de un pedido en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="ValorPreCatalogo"></param>
        /// <param name="IVAPreCatalogo"></param>
        /// <returns></returns>
        public bool UpdateValorPrecioCatalogoPedidoSVDN(string NumeroPedido, decimal ValorPreCatalogo, decimal IVAPreCatalogo)
        {
            try
            {
                return module.UpdateValorPrecioCatalogoPedidoSVDN(NumeroPedido, ValorPreCatalogo, IVAPreCatalogo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de la variable "procesado_cliente_historico	" a True
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateValorClienteHistorico(DateTime fecha)
        {
            try
            {
                return module.UpdateValorClienteHistorico(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la suma de un dia adicional a un pedido que se encuentra por anular.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateDiaAdicionalPedido(string NumeroPedido, string Usuario)
        {
            try
            {
                return module.UpdateDiaAdicionalPedido(NumeroPedido, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del valor precio catalogo de un pedido en G&G y en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="IVA"></param>
        /// <returns></returns>
        public bool UpdateValoresPrecioCatalogo(string NumeroPedido, decimal Valor, decimal IVA)
        {
            try
            {
                return module.UpdateValoresPrecioCatalogo(NumeroPedido, Valor, IVA);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la liberacion de pedidos por zona seleccionada de facturacion semanal.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool UpdateLiberarZonasPedidosFactSemanal(string Campana, string Zona)
        {
            try
            {
                return module.UpdateLiberarZonasPedidosFactSemanal(Campana, Zona);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        ///  Realiza el bloqueo temporal de los pedidos de un mailgroup por campaña
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Pedido"></param>
        /// <returns></returns>
        public bool BloquearPedidosxMailgroupSVDN(string Campana, string Pedido)
        {
            try
            {
                return module.BloquearPedidosxMailgroupSVDN(Campana, Pedido);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }



        public bool UpdateProcesadoClienteHistorico(string NumeroPedido, string Nit)
        {
            try
            {
                return module.UpdateProcesadoClienteHistorico(NumeroPedido, Nit);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        #region "METODOS DE SIMULADOR"
        //----------------------------------------------------------------------------------

        /// <summary>
        /// Asignar el nivel de servicio del pedido por valor o costo.
        /// </summary>
        /// <returns></returns>
        public void AsignarNivelServicioValorCostoSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento, decimal NivelServicio)
        {
            bool okProcess = false;

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE NIVEL DE SERVICIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                //MailGroup ObjMailGroup = new MailGroup("conexion");
                //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
                //se pregunta si existen Mailgroup para ese dia.
                //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                //{
                //Se realiza la asignacion de pedidos para cada mailgroup.
                //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                //{
                //  System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Se obtiene la campaña de la fecha actual.
                Campana ObjCampana = new Campana("conexion");
                CampanaInfo ObjCampanaInfo = new CampanaInfo();
                //ObjCampanaInfo = ObjCampana.ListxGetDate();

                if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                {
                    ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                }
                else
                {
                    ObjCampanaInfo = ObjCampana.ListxGetDate();
                }

                //Se valida que exista una campaña activa.
                if (ObjCampanaInfo != null)
                {

                    //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                    //1. Borrar tabla inventario para solo almacenar lo actual.
                    //2. Consultar saldos bodega.
                    //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                    //4. Consultar pedidos ordenados por orden de procesamiento.
                    //5. Actualizar el campo de cantidad pedida con respecto al inventario en el detalle del pedido.
                    //6. Restar cantidad actualizada a los saldos de inventario.

                    Inventario ObjInventario = new Inventario("conexion");

                    //Borrar la tabla de inventario para copiar el inventario actualizado.
                    if (ObjInventario.DeleteAll())
                    {
                        //Se consulta el inventario del mes actual.
                        List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                        ObjInventarioInfoList = ObjInventario.ListSaldosBodega();

                        if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                            foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                            {
                                //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                if (!ObjInventario.Insert(ItemInventario))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Zona ObjZona = new Zona("conexion");
                            //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                            //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                            ////Se valida que existan zonas para el mailgroup actual.
                            //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                            //{
                            //    //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                            //    foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            //    {
                            //    }
                            //}

                            List<PedidosClienteInfo> ObjPedidosCliente = new List<PedidosClienteInfo>();

                            switch (TipoProcesamiento)
                            {
                                case "xMailgroup":
                                    foreach (string Mailgroup in ListadoProcesamiento)
                                    {
                                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                                        Zona ObjZona = new Zona("conexion");

                                        ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                        {
                                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                            {
                                                //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                                /// //cambiar mauricio ObjPedidosCliente.AddRange(ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                            }
                                        }
                                    }

                                    break;
                                case "xZona":

                                    foreach (string zona in ListadoProcesamiento)
                                    {
                                        /// //cambiar mauricio ObjPedidosCliente.AddRange(ListxZonaxCampanaxOrdenProcesado(zona, ObjCampanaInfo.Campana));
                                    }
                                    break;
                                case "xCedula":
                                    foreach (string Cedula in ListadoProcesamiento)
                                    {
                                        ObjPedidosCliente.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                                    }
                                    break;
                                default:
                                    break;
                                //return ToString(o);
                            }

                            //Se valida si existen pedidos de la zona y la campaña actual.
                            if (ObjPedidosCliente != null && ObjPedidosCliente.Count > 0)
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                //22222222222222222222222222222222222222
                                int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.                                               
                                int si_nivelservicio = 0; //almacena la cantidad que si aplicaron el nivel de servicio.
                                int no_nivelservicio = 0; //amacena la cantidad que no aplicaron el nivel de servicio.

                                //Se insertan los pedidos a la tabla temporal.
                                foreach (PedidosClienteInfo Pedido in ObjPedidosCliente)
                                {
                                    bool okInventario = false;

                                    //Consultar detalle del pedido.
                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexId(Pedido.Numero);

                                    //Se valida si existen detalles del pedido.
                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                    {
                                        //Recorre el detalle del pedido.
                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                            //Consulta el inventario del detalle del pedido especifico.
                                            InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                            ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostos("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos

                                            if (ObjInventarioInfoActual != null)
                                            {
                                                //Calcula la cantidad disponible en el inventario
                                                decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                //actualiza la cantidad del nivel de servicio del pedido con la cantidad disponible.
                                                if (ObjPedidosDetalleCliente.UpdateCantidadNivelServicioSimulador(ObjPedidoDetalle.Id, CantidadDisp))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                    okInventario = true;

                                                    //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                    if (ObjInventario.UpdateCantidad("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    //-------------------------------------------------------------------------------
                                    //Actualiza el nivel del servicio y estado de nivel de servicio.
                                    if (okInventario)
                                    {
                                        //********************************************************************************************
                                        //Se obtiene el nivel de servicio esperado para el dia.
                                        //Application.Enterprise.Business.NivelServicio ObjNivelServicio = new Application.Enterprise.Business.NivelServicio("conexion");
                                        //Application.Enterprise.CommonObjects.NivelServicioInfo ObjNivelServicioInfo = new Application.Enterprise.CommonObjects.NivelServicioInfo();

                                        //ObjNivelServicioInfo = ObjNivelServicio.ListxFecha();

                                        decimal NivelServicioEstimado = 100;

                                        ////Si no hay un nivel de servicio para el dia se consulta el requerido por los parametros del sistema, sino hay en
                                        ////los parametros se asume el 100%.
                                        //if (ObjNivelServicioInfo != null)
                                        //{
                                        //    NivelServicioEstimado = ObjNivelServicioInfo.NivelEstimado;
                                        //}
                                        //else
                                        //{
                                        //    ParametrosInfo objParametrosInfo = new ParametrosInfo();
                                        //    Parametros objParametros = new Parametros("conexion");

                                        //    //Se obtiene el parametro de nivel de servicio.
                                        //    objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.NivelServicio);

                                        //    if (Convert.ToDecimal(objParametrosInfo.Valor) > 0)
                                        //    {
                                        //        NivelServicioEstimado = Convert.ToDecimal(objParametrosInfo.Valor);
                                        //    }
                                        //    else
                                        //    {
                                        //        NivelServicioEstimado = 100;
                                        //    }
                                        //}

                                        NivelServicioEstimado = NivelServicio;

                                        //********************************************************************************************


                                        //Consultar detalle del pedido para calcular el nivel de servicio.
                                        PedidosDetalleCliente ObjPedidosDetalleNivelS = new PedidosDetalleCliente("conexion");
                                        List<PedidosDetalleClienteInfo> ObjPedidosDetalleNivelSInfoList = new List<PedidosDetalleClienteInfo>();
                                        ObjPedidosDetalleNivelSInfoList = ObjPedidosDetalleNivelS.ListPedidoDetallexIdSimulador(Pedido.Numero);

                                        decimal CantidadTotalPedidoRequerida = 0;
                                        decimal CantidadTotalPedidoExistente = 0;

                                        decimal ValorTotalRequerido = 0;
                                        decimal ValorTotalExistente = 0;

                                        if (ObjPedidosDetalleNivelSInfoList != null && ObjPedidosDetalleNivelSInfoList.Count > 0)
                                        {
                                            //recorre el detalle del pedido y se suma la cantidad total requerida y la real existente.
                                            foreach (PedidosDetalleClienteInfo PedidoDetalleTotal in ObjPedidosDetalleNivelSInfoList)
                                            {
                                                //CantidadTotalPedidoRequerida = cantidad total que se pidio por el cliente.
                                                CantidadTotalPedidoRequerida = CantidadTotalPedidoRequerida + PedidoDetalleTotal.Cantidad;
                                                //ValorTotalRequerido = valor total que se pidio por el cliente.
                                                ValorTotalRequerido = ValorTotalRequerido + (PedidoDetalleTotal.Valor * PedidoDetalleTotal.Cantidad);

                                                //CantidadTotalPedidoExistente = cantidad que existe para mirar el nivel de servicio asignada dependiendo el inventario existente.
                                                CantidadTotalPedidoExistente = CantidadTotalPedidoExistente + PedidoDetalleTotal.CantidadNivelServicio;
                                                //ValorTotalExistente = valor que existe realmente para mirar el nivel de servicio asignada dependiendo el inventario existente.
                                                ValorTotalExistente = ValorTotalExistente + (PedidoDetalleTotal.Valor * PedidoDetalleTotal.CantidadNivelServicio);
                                            }
                                        }

                                        //Se realiza la operacion para saber qeu porcentaje se obtuvo realmente.
                                        decimal NivelServicioReal = (ValorTotalExistente * 100) / ValorTotalRequerido;

                                        //Se realiza la operacion para saber si la cantidad real supera el nivel de servicio esperado.
                                        if (NivelServicioReal >= NivelServicioEstimado)
                                        {
                                            //true si cumple con el nivel de servicio.
                                            if (UpdateNivelServicioSimulador(Pedido.Numero, true, NivelServicioEstimado, NivelServicioReal, "Por Valor"))
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE CUMPLIO EL NIVEL DE SERVICIO, SE ACTUALIZO ESTADO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                si_nivelservicio = si_nivelservicio + 1;
                                            }
                                            else
                                            {
                                                bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                no_nivelservicio = no_nivelservicio + 1;
                                            }
                                        }
                                        else
                                        {
                                            //si no cumple con el nivel de servicio el estado es false.
                                            if (UpdateNivelServicioSimulador(Pedido.Numero, false, NivelServicioEstimado, NivelServicioReal, "Por Valor"))
                                            {
                                                bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE CUMPLIO NIVEL DE SERVICIO PARA PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                no_nivelservicio = no_nivelservicio + 1;
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ACTUALIZAR NIVEL DE SERVICIO DEL PEDIDO:" + Pedido.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                no_nivelservicio = no_nivelservicio + 1;
                                            }
                                        }

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;
                                    }
                                    else
                                    {

                                        //SI ENTRO AQUI ES POR QUE NO EXISTEN NISIQUIERA UNA UNIDAD DE LOS ARTICULOS REQUERIDOS EN EL DETALLE DEL PEDIDO.

                                        //SE BLOQUEA POR NIVEL DE SERVICIO.
                                        bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(Pedido.Numero, (int)EstadosPedidoEnum.NivelServicio);

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: EL PEDIDO HA SIDO RETENIDO POR VALOR = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", Pedido.Numero + " NIT:" + Pedido.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }
                                }

                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE INVENTARIO DE LOS PEDIDOS CON REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                            }
                            //}
                            //}
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }
                // }

                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X NIVEL DE SERVICIO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR CANTIDAD: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //..............................................................................
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        //ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        //ObjPedidosClienteProcesadoInfo.TotalSiCumplenNivelServicio = si_nivelservicio;
                        //ObjPedidosClienteProcesadoInfo.TotalNoCumplenNivelServicio = no_nivelservicio;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //..............................................................................

                }

                //..............................................................................................................................


                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}

                okProcess = true;

                //se debe borrar la tabla temporal para que no se bloqueé el proceso siguiente.
                DeleteTemporal();
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error NIVEL DE SERVICIO POR VALOR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            //* return okProcess;
        }


        /// <summary>
        /// Este metodo unifica los pedidos de los catalogos nivi, outlet y hogar en uno solo para el procesamiento.
        /// </summary>
        public void UnificarPedidosCatalogosSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento, decimal NivelServicio)
        {
            bool okProcess = false;
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. se unifican los pedidos de oulet y hogar
            //6. se actualizan los valores y se suman
            //7. se bloquean los pedidos de oulet y de hogar.

            //Se obtienen los mailgroup por fecha actual.
            //MailGroup ObjMailGroup = new MailGroup("conexion");
            //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            //se pregunta si existen Mailgroup para ese dia.
            //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            //{
            //Se realiza la asignacion de pedidos para cada mailgroup.
            //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
            //{
            //System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

            //Se obtiene la campaña de la fecha actual.
            Campana ObjCampana = new Campana("conexion");
            CampanaInfo ObjCampanaInfo = new CampanaInfo();
            //ObjCampanaInfo = ObjCampana.ListxGetDate();

            if (CampanaSeleccionada != null && CampanaSeleccionada != "")
            {
                ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
            }
            else
            {
                ObjCampanaInfo = ObjCampana.ListxGetDate();
            }

            //Se valida que exista una campaña activa.
            if (ObjCampanaInfo != null)
            {
                //Se obtienen las zonas de un mailgroup por fecha actual.
                //Zona ObjZona = new Zona("conexion");
                //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                ////Se valida que existan zonas para el mailgroup actual.
                //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESAR PARA FACTURAR  .", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Se recorren las zonas y se trasladan los pedidos a la tabla de nivi (pedidosc1_2000).
                //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                //{
                List<PedidosClienteInfo> ObjListPedidosProcesarZonaCampana = new List<PedidosClienteInfo>();

                switch (TipoProcesamiento)
                {
                    case "xMailgroup":
                        foreach (string Mailgroup in ListadoProcesamiento)
                        {
                            List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                            Zona ObjZona = new Zona("conexion");

                            ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                            if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                            {
                                foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                {
                                    //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                    ObjListPedidosProcesarZonaCampana.AddRange(ListPedidosProcesarNivi(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                }
                            }
                        }

                        break;
                    case "xZona":

                        foreach (string zona in ListadoProcesamiento)
                        {
                            ObjListPedidosProcesarZonaCampana.AddRange(ListPedidosProcesarNivi(zona, ObjCampanaInfo.Campana));
                        }
                        break;
                    case "xCedula":
                        foreach (string Cedula in ListadoProcesamiento)
                        {
                            ObjListPedidosProcesarZonaCampana.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                        }
                        break;
                    default:
                        break;
                    //return ToString(o);
                }


                //Se obtienen los pedidos de las zonas y campañas que estan listos para procesar del catalogo nivi .
                //ObjListPedidosProcesarZonaCampana = ListPedidosProcesarNivi(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                //      por que sino queda filtrado por zona.
                //Se valida si existen pedidos de la zona y la campaña actual.
                if (ObjListPedidosProcesarZonaCampana != null && ObjListPedidosProcesarZonaCampana.Count > 0)
                {
                    //para consultar el detalle de los pedidos outlet y hogar
                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                    foreach (PedidosClienteInfo PedidoProcesar in ObjListPedidosProcesarZonaCampana)
                    {
                        decimal ValorSumatoria = PedidoProcesar.Valor;
                        decimal IVASumatoria = PedidoProcesar.IVA;

                        List<PedidosClienteInfo> ObjListPedidosTodosCatalogosList = new List<PedidosClienteInfo>();

                        //Consultar todos los pedidos (catalogo  hogar y outlet) de la empresaria procesados sin bloqueos para agruparlos en un solo pedido y pasarlos a facturacion.
                        ObjListPedidosTodosCatalogosList = this.ListPedidosxEmpresariaOuletHogarSimulador(PedidoProcesar.Nit, PedidoProcesar.Campana);

                        //si trae los pedidos de catalogo  hogar y outlet sigue el proceso.
                        if (ObjListPedidosTodosCatalogosList != null && ObjListPedidosTodosCatalogosList.Count > 0)
                        {
                            foreach (PedidosClienteInfo PedidoParaUnificar in ObjListPedidosTodosCatalogosList)
                            {
                                List<PedidosDetalleClienteInfo> objPedidosDetalleClienteInfo = new List<PedidosDetalleClienteInfo>();

                                //Se obtiene el detalle del pedido outlet u hogar.
                                objPedidosDetalleClienteInfo = objPedidosDetalleCliente.ListDetallePedidoxNumeroSimulador(PedidoParaUnificar.Numero);

                                if (objPedidosDetalleClienteInfo != null && objPedidosDetalleClienteInfo.Count > 0)
                                {
                                    foreach (PedidosDetalleClienteInfo PedidoDetalleOuletHogar in objPedidosDetalleClienteInfo)
                                    {
                                        PedidoDetalleOuletHogar.NumeroPedidoPadre = PedidoParaUnificar.Numero;
                                        PedidoDetalleOuletHogar.Numero = PedidoProcesar.Numero;
                                        PedidoDetalleOuletHogar.Catalogo = PedidoParaUnificar.Codigo;

                                        string okTrans = objPedidosDetalleCliente.InsertDetalleSimulador(PedidoDetalleOuletHogar);

                                        if (okTrans == "" || okTrans == null)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO CREAR DETALLE PARA PEDIDO PADRE: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "CREO DETALLE PARA PEDIDO PADRE OK: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                        }
                                    }
                                }

                                //Se suman los valores del pedido nivi oulet/hogar
                                ValorSumatoria = ValorSumatoria + PedidoParaUnificar.Valor;
                                IVASumatoria = IVASumatoria + PedidoParaUnificar.IVA;

                                //se suman los valores de los pedidos unificados.
                                if (UpdateValorPedidoSVDNSimulador(PedidoProcesar.Numero, ValorSumatoria, IVASumatoria))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO EL VALOR DEL PEDIDO OK: " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL VALOR DEL PEDIDO: " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }

                                //se actualiza el estado del pedido a unificado para que no se tenga mas en cuenta en el procesamiento.
                                if (UpdateEstadoPedidoSimulador(PedidoParaUnificar.Numero, (int)EstadosPedidoEnum.Unificado))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO ESTADO DEL PEDIDO A UNIFICADO OK: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO ESTADO DEL PEDIDO A UNIFICADO: " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }

                                //se actualiza el estado del pedido en produccion para que no se tenga mas cuenta en el procesamiento.
                                if (UpdateEnProduccionSimulador(PedidoParaUnificar.Numero, true))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO PEDIDO A PRODUCCION OK: " + PedidoParaUnificar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO  PEDIDO A PRODUCCION : " + PedidoProcesar.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN PEDIDOS PARA EL NIT:" + PedidoProcesar.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }

                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                        okProcess = true;

                        //Contador de pedidos
                        consecutivo = consecutivo + 1;

                    }
                }
                //}

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
            //}

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //..............................................................................................................................
            //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            if (okProcess == false)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA PROCESAR PARA FACTURAR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //.......................................................................................
                //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //.......................................................................................
            }
            else if (okProcess == true)
            {

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE UNIFICAR PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //..............................................................................
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //..............................................................................
            }

            //..............................................................................................................................

            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE UNIFICAR PEDIDOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //Calcula el tiempo que demora en realizar la asignacion de reglas.
            TimeSpan ts = DateTime.Now - _startAsignacionTime;
            System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
            System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            //}
            //else
            //{
            //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI UNIFICAR PEDIDOS OUTLET HOGAR SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //}

        }



        /// <summary>
        /// Bloquear los pedidos de un cliente con saldo de cartera positivo. 
        /// (El saldo de cartera negativo es bueno para la empresaria por que significa que el cliente tiene dinero a favor. 
        /// Si el saldo es mayor al parametro de valor cartera significa que el cliente tiene deuda con niviglobal)
        /// </summary>
        public List<string> BloquearPedidosxCarteraSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento)
        {

            List<string> ListaBloqueados = new List<string>();


            //*UnificarPedidosCatalogos();

            //NOTA: ESTE PROCESO SE DEBE CORRER ANTES DE COMENZAR CON LA ASIGNACION INVENTARIO, Y ANTES DE REALIZARLO SE DEBEN COPIAR LOS CLIENTES DE SVDN A NIVI.

            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.


            string MesFormato = DateTime.Today.Month.ToString();
            //Para anteponer el 0 en el mes por que la tabla recibe: ej: 201203
            if (Convert.ToInt32(MesFormato) < 10)
            {
                MesFormato = "0" + MesFormato;
            }

            string Mes = DateTime.Today.Year.ToString() + MesFormato;

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene saldo en cartera se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            //MailGroup ObjMailGroup = new MailGroup("conexion");
            //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            ////se pregunta si existen Mailgroup para ese dia.
            //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            //{
            //Se realiza la asignacion de pedidos para cada mailgroup.
            //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
            //{
            //System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

            //Se obtiene la campaña de la fecha actual.
            Campana ObjCampana = new Campana("conexion");
            CampanaInfo ObjCampanaInfo = new CampanaInfo();
            //ObjCampanaInfo = ObjCampana.ListxGetDate();

            if (CampanaSeleccionada != null && CampanaSeleccionada != "")
            {
                ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
            }
            else
            {
                ObjCampanaInfo = ObjCampana.ListxGetDate();
            }

            //Se valida que exista una campaña activa.
            if (ObjCampanaInfo != null)
            {
                //Se obtienen las zonas de un mailgroup por fecha actual.
                //Zona ObjZona = new Zona("conexion");
                //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                ////Se valida que existan zonas para el mailgroup actual.
                //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                //{
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE BLOQUEAR POR CARTERA SIMULADOR.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                //{
                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();


                switch (TipoProcesamiento)
                {
                    case "xMailgroup":
                        foreach (string Mailgroup in ListadoProcesamiento)
                        {
                            List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                            Zona ObjZona = new Zona("conexion");

                            ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                            if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                            {
                                foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                {
                                    //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                    ObjListPedidosNoBloqueadosZonaCampana.AddRange(ListxZonaxCampanaNoBloqueadoSimulador(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                }
                            }
                        }

                        break;
                    case "xZona":

                        foreach (string zona in ListadoProcesamiento)
                        {
                            ObjListPedidosNoBloqueadosZonaCampana.AddRange(ListxZonaxCampanaNoBloqueadoSimulador(zona, ObjCampanaInfo.Campana));
                        }
                        break;
                    case "xCedula":
                        foreach (string Cedula in ListadoProcesamiento)
                        {
                            ObjListPedidosNoBloqueadosZonaCampana.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                        }
                        break;
                    default:
                        break;
                    //return ToString(o);
                }


                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                //ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaNoBloqueado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                //      por que sino queda filtrado por zona.
                //Se valida si existen pedidos de la zona y la campaña actual.
                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                {

                    CxCInfo objCxCInfo = new CxCInfo();
                    CxC objCxC = new CxC("conexion");

                    //Se bloquean los pedidos de clientes que tengan saldo de cartera > valorcartera.
                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                    {
                        //Se obtiene el saldo de cartera del cliente del pedido.
                        objCxCInfo = objCxC.ListxNitxMes(PedidoNoBloqueado.Nit, Mes);

                        if (objCxCInfo != null)
                        {
                            ParametrosInfo objParametrosInfo = new ParametrosInfo();
                            Parametros objParametros = new Parametros("conexion");

                            //Se obtiene el parametro de cartera para comparar si supera la cartera.
                            objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.ValorCartera);

                            //Si el saldo del cliente supera la cartera se bloquea el pedido.
                            if (objCxCInfo.SaldoTotal >= Convert.ToDecimal(objParametrosInfo.Valor))
                            {
                                bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(PedidoNoBloqueado.Numero, (int)EstadosPedidoEnum.Cartera);

                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: EL PEDIDO HA SIDO RETENIDO POR SALDO EN CARTERA = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoNoBloqueado.Numero + " NIT:" + PedidoNoBloqueado.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                ListaBloqueados.Add(PedidoNoBloqueado.Numero);

                            }
                        }

                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                        okProcess = true;

                        //Contador de pedidos
                        consecutivo = consecutivo + 1;
                    }
                }
                //}

                //System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
            //}

            //..............................................................................................................................
            //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            if (okProcess == false)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X CARTERA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //.......................................................................................
                //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //.......................................................................................
            }
            else if (okProcess == true)
            {

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //...........................................................................
                //Dispara el evento de que termino el proceso ok.                                               
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //...........................................................................
            }
            //..............................................................................................................................


            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE ASIGNACIÓN DE BLOQUEAR POR CARTERA SIMULADOR OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //Calcula el tiempo que demora en realizar la asignacion de reglas.
            TimeSpan ts = DateTime.Now - _startAsignacionTime;
            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: PROCESO DE ASIGNACIÓN DE PREMIOS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
            System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            //}
            //else
            //{
            //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR CARTERA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //}


            return ListaBloqueados;

        }


        /// <summary>
        /// Bloquear los pedidos de un cliente cuando es desmanteladora. 
        /// Solo a los clientes con semaforo verde se les procesa el pedido.
        /// </summary>
        public List<string> BloquearPedidosxDesmanteladoraSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento)
        {

            List<string> ListaBloqueados = new List<string>();

            //NOTA: ESTE PROCESO SE DEBE CORRER ANTES DE COMENZAR CON LA ASIGNACION INVENTARIO, Y ANTES DE REALIZARLO SE DEBEN COPIAR LOS CLIENTES DE SVDN A NIVI.

            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.


            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE SEMAFORO DIFERENTE DE VERDE Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE.
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene semaforo diferente de verde y se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            //MailGroup ObjMailGroup = new MailGroup("conexion");
            //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            ////se pregunta si existen Mailgroup para ese dia.
            //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            //{
            //Se realiza la asignacion de pedidos para cada mailgroup.
            //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
            //{
            //System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

            //Se obtiene la campaña de la fecha actual.
            Campana ObjCampana = new Campana("conexion");
            CampanaInfo ObjCampanaInfo = new CampanaInfo();
            //ObjCampanaInfo = ObjCampana.ListxGetDate();

            if (CampanaSeleccionada != null && CampanaSeleccionada != "")
            {
                ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
            }
            else
            {
                ObjCampanaInfo = ObjCampana.ListxGetDate();
            }

            //Se valida que exista una campaña activa.
            if (ObjCampanaInfo != null)
            {
                //Se obtienen las zonas de un mailgroup por fecha actual.
                //Zona ObjZona = new Zona("conexion");
                //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                ////Se valida que existan zonas para el mailgroup actual.
                //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                //{
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE BLOQUEAR POR CARTERA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //contar cantidad total de pedidos para mostrar en formulario de presentacion.
                int totalpedidos = 0;


                //Se recorren las zonas y se trasladan los pedidos a la tabla temporal de premios.
                //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                //{
                List<PedidosClienteInfo> ObjListPedidosNoBloqueadosZonaCampana = new List<PedidosClienteInfo>();

                switch (TipoProcesamiento)
                {
                    case "xMailgroup":
                        foreach (string Mailgroup in ListadoProcesamiento)
                        {
                            List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                            Zona ObjZona = new Zona("conexion");

                            ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                            if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                            {
                                foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                {
                                    //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                    ObjListPedidosNoBloqueadosZonaCampana.AddRange(ListxZonaxCampanaNoBloqueadoSimulador(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                }
                            }
                        }

                        break;
                    case "xZona":

                        foreach (string zona in ListadoProcesamiento)
                        {
                            ObjListPedidosNoBloqueadosZonaCampana.AddRange(ListxZonaxCampanaNoBloqueadoSimulador(zona, ObjCampanaInfo.Campana));
                        }
                        break;
                    case "xCedula":
                        foreach (string Cedula in ListadoProcesamiento)
                        {
                            ObjListPedidosNoBloqueadosZonaCampana.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                        }
                        break;
                    default:
                        break;
                    //return ToString(o);
                }


                //Se obtienen los pedidos de las zonas y campañas que no tengan ningun bloqueo.
                //ObjListPedidosNoBloqueadosZonaCampana = ListxZonaxCampanaNoBloqueado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                //      por que sino queda filtrado por zona.
                //Se valida si existen pedidos de la zona y la campaña actual.
                if (ObjListPedidosNoBloqueadosZonaCampana != null && ObjListPedidosNoBloqueadosZonaCampana.Count > 0)
                {

                    ClienteInfo objClienteInfo = new ClienteInfo();
                    Cliente objCliente = new Cliente("conexion");

                    //Se bloquean los pedidos de clientes que tengan saldo de cartera > valorcartera.
                    foreach (PedidosClienteInfo PedidoNoBloqueado in ObjListPedidosNoBloqueadosZonaCampana)
                    {
                        objClienteInfo = objCliente.ListClienteNivixNit(PedidoNoBloqueado.Numero);

                        if (objClienteInfo != null)
                        {
                            //Si el cliente no tiene estado 0 ó 1 es por que es desmantelador.
                            if (objClienteInfo.Desmantelados > 1)
                            {
                                bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(PedidoNoBloqueado.Numero, (int)EstadosPedidoEnum.Desmanteladora);

                                ListaBloqueados.Add(PedidoNoBloqueado.Numero);

                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: EL PEDIDO HA SIDO RETENIDO POR DESMANTELADORA = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoNoBloqueado.Numero + " NIT:" + PedidoNoBloqueado.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            }
                        }

                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                        okProcess = true;

                        //Contador de pedidos
                        consecutivo = consecutivo + 1;

                    }
                }
                //}


                ///System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
            //}

            //..............................................................................................................................
            //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            if (okProcess == false)
            {

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR X DESMANTELADORA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //.......................................................................................
                //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //.......................................................................................
            }
            else if (okProcess == true)
            {

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //...........................................................................
                //Ejecuta el evento cada que se ejecuta un ciclo.                                               
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //...........................................................................

            }
            //..............................................................................................................................


            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR DESMANTELADORA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //Calcula el tiempo que demora en realizar la asignacion de reglas.
            TimeSpan ts = DateTime.Now - _startAsignacionTime;
            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: PROCESO DE BLOQUEAR DESMANTELADORA TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
            System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            //}
            //else
            //{
            //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR POR DESMANTELADORA SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //}

            return ListaBloqueados;

        }


        /// <summary>
        /// Bloquear Pedidos de otros catalogos (Outlet y Hogar) para el simuladro.
        /// </summary>
        /// <returns></returns>
        public List<string> BloquearPedidosOtrosCatalogosSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento)
        {

            List<string> ListaBloqueados = new List<string>();

            bool okProcess = false;
            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            //---------------------------------------------------------------------------------------------------------------------------------------
            //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, SE PREGUNTA SI UN CLIENTE TIENE DEUDA DE CARTERA Y SE BLOQUEAN LOS PEDIDOS DE ESE CIENTE..
            //1. Se valida que no exista otro proceso de pedidos activo.
            //2. Se preguntan si existen mailgroup para el dia actual.
            //3. Se obtiene la campaña y zona del mailgroup actual.
            //4. Se listan los pedidos de la zona y campaña actual.
            //5. Se pregunta si el cliente tiene saldo en cartera se bloquean todos los pedidos de ese cliente.

            //Se obtienen los mailgroup por fecha actual.
            //MailGroup ObjMailGroup = new MailGroup("conexion");
            //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

            //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

            ////se pregunta si existen Mailgroup para ese dia.
            //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
            //{
            //Se realiza la asignacion de pedidos para cada mailgroup.
            //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
            //{
            //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "VERIFICANDO PEDIDOS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

            //Se obtiene la campaña de la fecha actual.
            Campana ObjCampana = new Campana("conexion");
            CampanaInfo ObjCampanaInfo = new CampanaInfo();
            //ObjCampanaInfo = ObjCampana.ListxGetDate();

            if (CampanaSeleccionada != null && CampanaSeleccionada != "")
            {
                ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
            }
            else
            {
                ObjCampanaInfo = ObjCampana.ListxGetDate();
            }

            //Se valida que exista una campaña activa.
            if (ObjCampanaInfo != null)
            {
                //Se obtienen las zonas de un mailgroup por fecha actual.
                //Zona ObjZona = new Zona("conexion");
                //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                ////Se valida que existan zonas para el mailgroup actual.
                //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                //{
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR .", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Se recorren las zonas y se trasladan los pedidos a la tabla de nivi (pedidosc1_2000).
                //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                //{
                List<PedidosClienteInfo> ObjListPedidosBloqueadosZonaCampana = new List<PedidosClienteInfo>();

                switch (TipoProcesamiento)
                {
                    case "xMailgroup":
                        foreach (string Mailgroup in ListadoProcesamiento)
                        {
                            List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                            Zona ObjZona = new Zona("conexion");

                            ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                            if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                            {
                                foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                {
                                    //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                    ObjListPedidosBloqueadosZonaCampana.AddRange(ListPedidosBloqueadosSimulador(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                }
                            }
                        }

                        break;
                    case "xZona":

                        foreach (string zona in ListadoProcesamiento)
                        {
                            ObjListPedidosBloqueadosZonaCampana.AddRange(ListPedidosBloqueadosSimulador(zona, ObjCampanaInfo.Campana));
                        }
                        break;
                    case "xCedula":
                        foreach (string Cedula in ListadoProcesamiento)
                        {
                            ObjListPedidosBloqueadosZonaCampana.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                        }
                        break;
                    default:
                        break;
                    //return ToString(o);
                }



                //Se obtienen los pedidos de las zonas y campañas que estan bloqueados .
                //ObjListPedidosBloqueadosZonaCampana = ListPedidosBloqueados(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                //NOTA: Se deben listan todos los pedidos de todas las zonas 
                //      por que sino queda filtrado por zona.
                //Se valida si existen pedidos de la zona y la campaña actual.
                if (ObjListPedidosBloqueadosZonaCampana != null && ObjListPedidosBloqueadosZonaCampana.Count > 0)
                {
                    PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                    foreach (PedidosClienteInfo PedidoBloqueado in ObjListPedidosBloqueadosZonaCampana)
                    {
                        List<PedidosClienteInfo> ObjListPedidosxNit = new List<PedidosClienteInfo>();

                        //Consulta los pedidos de outlet y hogar
                        ObjListPedidosxNit = this.ListPedidosxNitxCampanaSimulador(PedidoBloqueado.Nit, ObjCampanaInfo.Campana);

                        //si trae los pedidos de catalogo nivi, hogar, outlet sigue el proceso.
                        if (ObjListPedidosxNit != null && ObjListPedidosxNit.Count > 0)
                        {
                            foreach (PedidosClienteInfo PedidoBloquear in ObjListPedidosxNit)
                            {
                                if (this.UpdateEstadoPedidoSimulador(PedidoBloquear.Numero, PedidoBloqueado.IdEstado))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE BLOQUEO OK EL PEDIDO :" + PedidoBloquear.Numero + " CATALOGO: " + PedidoBloquear.Codigo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    ListaBloqueados.Add(PedidoBloquear.Numero);
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO BLOQUEAR EL PEDIDO :" + PedidoBloquear.Numero + " CATALOGO: " + PedidoBloquear.Codigo, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN PEDIDOS PARA EL NIT:" + PedidoBloqueado.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }

                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                        okProcess = true;

                        //Contador de pedidos
                        consecutivo = consecutivo + 1;
                    }
                }
                else
                {
                    //sino hay pedidos opara bloquear debe ssalir del metodo.

                    //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                    okProcess = true;

                    //Contador de pedidos
                    consecutivo = consecutivo + 1;
                }
                //}

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
            //}

            //..............................................................................................................................
            //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION

            PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

            if (okProcess == false)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA BLOQUEAR DE OTROS CATALOGOS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //.......................................................................................
                //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //.......................................................................................
            }
            else if (okProcess == true)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //..............................................................................
                OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                if (handler != null)
                {
                    ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                    ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                    handler(ObjPedidosClienteProcesadoInfo);
                }
                //..............................................................................
            }
            //..............................................................................................................................

            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //Calcula el tiempo que demora en realizar la asignacion de reglas.
            TimeSpan ts = DateTime.Now - _startAsignacionTime;
            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR:  PROCESO DE BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
            System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
            //}
            //else
            //{
            //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR PEDIDOS OTROS CATALOGOS SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            //}

            //return okProcess;

            return ListaBloqueados;
        }




        /// <summary>
        /// Realiza a asignacion de reglas a los pedidos y asigna el orden final para procesar os mismos.
        /// </summary>
        public string AsignarReglasPedidoSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento)
        {

            string okTransac = "NO se puedo asignar el orden a los pedidos.";

            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                //validar si ya existe un pedido procesando
                List<PedidosClienteInfo> list_temp = new List<PedidosClienteInfo>();

                //Consulta si hay pedidos en proceso en la tabla temporal
                list_temp = ListTablaTemporal();

                //Si no hay registros en la temporal se puede hacer el proceso. sino indica que hay pedidos en proceso.
                if (list_temp.Count == 0 || list_temp == null)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE ASIGNACIÓN DE REGLAS. HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Captura el tiempo de inicio
                    _startAsignacionTime = DateTime.Now;

                    //---------------------------------------------------------------------------------------------------------------------------------------
                    //SE CONSULTAN LOS PEDIDOS DE UN MAILGROUP POR ZONA Y CAMPAÑA, Y SE GUARDAN EN LA TABLA TEMPORAL PARA SEGUIR CON LA ASIGNACIÓN DE REGLAS.
                    //1. Se valida que no exista otro proceso de pedidos activo.
                    //2. Se preguntan si existen mailgroup para el dia actual.
                    //3. Se obtiene la campaña y zona del mailgroup actual.
                    //4. Se listan los pedidos de la zona y campaña actual para pasar a la asignacion de reglas.

                    //Se obtienen los mailgroup por fecha actual.
                    //MailGroup ObjMailGroup = new MailGroup("conexion");
                    //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                    //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                    ////se pregunta si existen Mailgroup para ese dia.
                    //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                    //{
                    //Se realiza la asignacion de pedidos para cada mailgroup.
                    //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                    //{
                    //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //Se obtiene la campaña de la fecha actual.
                    Campana ObjCampana = new Campana("conexion");
                    CampanaInfo ObjCampanaInfo = new CampanaInfo();
                    //ObjCampanaInfo = ObjCampana.ListxGetDate();

                    if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                    {
                        ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                    }
                    else
                    {
                        ObjCampanaInfo = ObjCampana.ListxGetDate();
                    }

                    //Se valida que exista una campaña activa.
                    if (ObjCampanaInfo != null)
                    {
                        //Se obtienen las zonas de un mailgroup por fecha actual.
                        //Zona ObjZona = new Zona("conexion");
                        //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                        //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                        ////Se valida que existan zonas para el mailgroup actual.
                        //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                        //{
                        //Se debe borra la tabla temporal con los pedidos de la zona y campaña actual.
                        if (!DeleteTemporal())
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ELIMINAR TODOS LOS REGISTROS DE LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIA DE PEDIDOS A TABLA TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //contar cantidad total de pedidos para mostrar en formulario de presentacion.
                        int totalpedidos = 0;

                        //Se recorren las zonas y se trasladan los pedidos a la tabla temporal.
                        //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                        //{
                        List<PedidosClienteInfo> ObjPedidosClienteInfoZonaCampana = new List<PedidosClienteInfo>();

                        switch (TipoProcesamiento)
                        {
                            case "xMailgroup":
                                foreach (string Mailgroup in ListadoProcesamiento)
                                {
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                                    Zona ObjZona = new Zona("conexion");

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosClienteInfoZonaCampana.AddRange(ListxZonaxCampanaSimulador(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                        }
                                    }
                                }

                                break;
                            case "xZona":

                                foreach (string zona in ListadoProcesamiento)
                                {
                                    ObjPedidosClienteInfoZonaCampana.AddRange(ListxZonaxCampanaSimulador(zona, ObjCampanaInfo.Campana));
                                }
                                break;
                            case "xCedula":
                                foreach (string Cedula in ListadoProcesamiento)
                                {
                                    ObjPedidosClienteInfoZonaCampana.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                                }
                                break;
                            default:
                                break;
                            //return ToString(o);
                        }


                        //ObjPedidosClienteInfoZonaCampana = ListxZonaxCampana(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                        //NOTA: Se deben insertar todos los pedidos de todas las zonas antes de pasar las reglas
                        //      por que sino queda filtrado por zona.
                        //Se valida si existen pedidos de la zona y la campaña actual.
                        if (ObjPedidosClienteInfoZonaCampana != null && ObjPedidosClienteInfoZonaCampana.Count > 0)
                        {
                            //Se insertan los pedidos a la tabla temporal.
                            foreach (PedidosClienteInfo PedidoItemZona in ObjPedidosClienteInfoZonaCampana)
                            {
                                InsertxRegla(PedidoItemZona);
                                //reiniciar el orden para que no se vaya a repetir.
                                UpdateOrdenSimulador(PedidoItemZona.Numero, 0);
                                totalpedidos = totalpedidos + 1;
                            }
                        }
                        //}

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE REALIZÓ COPIA DE PEDIDOS ACTIVOS A TEMPORAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //----------------------------------------------------------------------------------------------------------------------
                        //AQUI COMIENZA EL PROCESO DE APLICACIÓN DE REGLAS A LOS PEDIDOS DE UNA ZONA Y CAMPAÑA DE LA FECHA ACTUAL POR MAILGROUP
                        //1. Se realiza e select de los pedidos por mailgroup (zona y campaña) y se copia a la tabla de pedidos temp.
                        //2. Se realiza la asignacion de reglas a los pedidos del mailgroup.
                        //3. Se obtiene un conjunto de pedidos listados por reglas y se actualiza el campo orden en la tabla de pedidos.
                        //4. Cuando se procesa el pedido se organizan por el campo orden y se actualiza el campo Procesado a 1.

                        Reglas ObjReglas = new Reglas("conexion");
                        List<ReglasInfo> ObjReglasInfo = new List<ReglasInfo>();

                        //Obtiene as reglas activas y en orden para los pedidos.
                        ObjReglasInfo = ObjReglas.ListAsignarPedidos();

                        List<PedidosClienteInfo> ObjPedidosClienteInfoReglas = new List<PedidosClienteInfo>();

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE REGLAS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //Se hace el ciclo de asignacion de reglas a los pedidos.
                        for (int i = 0; i < ObjReglasInfo.Count; i++)
                        {

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TOTAL REGLAS:" + ObjReglasInfo.Count, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            ObjReglasInfo[i].Query = ObjReglasInfo[i].Query.ToUpper();

                            //Se obtiene la lista de pedidos con las reglas siguientes
                            ObjReglasInfo[i].Query = ObjReglasInfo[i].Query.Replace("SVDN_PEDIDOSC1_2000", "SVDN_PEDIDOSC1_2000_TEMP");
                            //Aqui se envia a ejecutar las regla para los pedidos.
                            ObjPedidosClienteInfoReglas = ListxRegla(ObjReglasInfo[i].Query);

                            //Si se obtuvieron pedidos y se aplicaron reglas.
                            if (ObjPedidosClienteInfoReglas != null && ObjPedidosClienteInfoReglas.Count > 0)
                            {
                                //se debe borra la tabla temporal para que queden solo los pedidos con la regla aplicada.
                                if (DeleteTemporal())
                                {
                                    int OrdenTemp = 0;

                                    //Se insertan los pedidos a la tabla temporal que corresponden a la regla aplicada.
                                    foreach (PedidosClienteInfo PedidoItem in ObjPedidosClienteInfoReglas)
                                    {
                                        OrdenTemp = OrdenTemp + 1;
                                        PedidoItem.Orden = OrdenTemp;
                                        InsertxRegla(PedidoItem);
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ELIMINAR TODOS LOS REGISTROS DE LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }
                        }

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE REGLAS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //AQUI LAS REGLAS YA SE APLICARON, SE ACTUALIZA EL CAMPO ORDEN DE PEDIDOS PARA COMENZAR A PROCESAR.
                        //1. Se obtienen los registros de la tabla temporal con las reglas asignadas.
                        //2. Se recorren los registros y se actualiza la tabla de pedidos con el orden asignado despues de las reglas.
                        //3. Se validan los registros que no alcanzaron reglas y se les asigna el orden para el final.
                        //4. Se borra la tabla temporal para los siguientes procesamientos de pedido.

                        int OrdenFinal = 0;

                        //Se consultan los pedidos de la tabla temporal con las reglas asignadas.
                        List<PedidosClienteInfo> ObjPedidosClienteReglasTemp = new List<PedidosClienteInfo>();
                        ObjPedidosClienteReglasTemp = ListTemporal();


                        //Si se obtuvieron pedidos con reglas aplicadas de la tabla temporal.
                        if (ObjPedidosClienteReglasTemp != null && ObjPedidosClienteReglasTemp.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ACTUALIZACIÓN DE ORDEN A PEDIDOS CON REGLAS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            foreach (PedidosClienteInfo PedidosReglasOrden in ObjPedidosClienteReglasTemp)
                            {
                                //Se actualiza el orden del pedido desde la lista temporal con reglas asignadas.
                                if (UpdateOrdenSimulador(PedidosReglasOrden.Numero, PedidosReglasOrden.Orden))
                                {
                                    //se valida para que quede el ultimo orden asignado.
                                    if (PedidosReglasOrden.Orden > OrdenFinal)
                                    {
                                        OrdenFinal = PedidosReglasOrden.Orden;
                                    }

                                    //Elimina el pedido actualizado de la tabla temporal por id de pedido.
                                    if (!DeletexNumeroPedido(PedidosReglasOrden.Numero))
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUEDE ELIMINAR EL PEDIDO DE LA TABLA TEMPORAL. PEDIDO No:" + PedidosReglasOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ASIGNO EL ORDEN CORRECTAMENTE AL PEDIDO No:" + PedidosReglasOrden.Numero + " ORDEN: " + OrdenFinal, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                    okProcess = true;

                                    //Contador de pedidos
                                    consecutivo = consecutivo + 1;

                                    okTransac = "OK, se asigno orden correctamente.";
                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ERROR ACTUALIZANDO EL ORDEN DE LOS PEDIDOS. PEDIDO No:" + PedidosReglasOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ACTUALIZACIÓN DE ORDEN EN PEDIDOS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE OBTUVIERON PEDIDOS DE LA TABLA TEMPORAL CON REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }

                        //*****************************************************************************************************************
                        //AQUI SE PONE EL ORDEN A LOS PEDIDOS QUE NO CUMPLIERON REGLAS PARA QUE TODOS QUEDEN CON UN ORDEN ASIGNADO.
                        //Consulta los pedidos que no alcanzaron a tener orden y asigna el ultimo orden depues de los pedidos con reglas.

                        //Se recorren las zonas y se asigna el orden para los pedidos que no alcanzaron regla.
                        //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                        //{
                        List<PedidosClienteInfo> ObjPedidosClienteSinOrden = new List<PedidosClienteInfo>();


                        switch (TipoProcesamiento)
                        {
                            case "xMailgroup":
                                foreach (string Mailgroup in ListadoProcesamiento)
                                {
                                    List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                                    Zona ObjZona = new Zona("conexion");

                                    ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                                    if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                    {
                                        foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                        {
                                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                            ObjPedidosClienteSinOrden.AddRange(ListxZonaxCampanaxOrdenSimulador(ZonaMailGroup.Zona, ObjCampanaInfo.Campana, 0));
                                        }
                                    }
                                }

                                break;
                            case "xZona":

                                foreach (string zona in ListadoProcesamiento)
                                {
                                    ObjPedidosClienteSinOrden.AddRange(ListxZonaxCampanaxOrdenSimulador(zona, ObjCampanaInfo.Campana, 0));
                                }
                                break;
                            case "xCedula":
                                foreach (string Cedula in ListadoProcesamiento)
                                {
                                    ObjPedidosClienteSinOrden.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                                }
                                break;
                            default:
                                break;
                            //return ToString(o);
                        }


                        //Se envia la zona, campaña y orden (0) para obtener los pedidos sin reglas.
                        //Se envia el orden = 0, que significa que no se ha asignado regla.
                        //ObjPedidosClienteSinOrden = ListxZonaxCampanaxOrden(ZonaMailGroup.Zona, ObjCampanaInfo.Campana, 0);

                        //Se valida si existen pedidos de la zona y la campaña actual.
                        if (ObjPedidosClienteSinOrden != null && ObjPedidosClienteSinOrden.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS SIN REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Se insertan los pedidos a la tabla temporal.
                            foreach (PedidosClienteInfo PedidoSinOrden in ObjPedidosClienteSinOrden)
                            {
                                //Se incrementa el ultimo orden en que que quedaron los pedidos con reglas y se actualiza.
                                OrdenFinal = OrdenFinal + 1;

                                //Se actualiza el orden del pedido que no se le asigno reglas.
                                if (UpdateOrdenSimulador(PedidoSinOrden.Numero, OrdenFinal))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ASIGNO EL ORDEN CORRECTAMENTE AL PEDIDO No:" + PedidoSinOrden.Numero + " ORDEN: " + OrdenFinal, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                    //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                    okProcess = true;

                                    //Contador de pedidos
                                    consecutivo = consecutivo + 1;

                                    okTransac = "OK, se asigno orden correctamente.";

                                }
                                else
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ERROR ACTUALIZANDO EL ORDEN DE LOS PEDIDOS SIN REGLA. PEDIDO No:" + PedidoSinOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ACTUALIZACIÓN DE ORDEN DE LOS PEDIDOS SIN REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                        //}
                        //}
                        //else
                        //{
                        //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN ZONAS PARA EL MAIL GROUP ACTUAL. MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        //}
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                    //}

                    //..............................................................................................................................
                    //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                    PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();


                    if (okProcess == false)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR REGLAS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA ASIGNAR REGLAS.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //.......................................................................................
                        //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //.......................................................................................
                    }
                    else if (okProcess == true)
                    {

                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR REGLAS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                        //...........................................................................
                        //Dispara el evento de que termino el proceso ok.                                               
                        OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                        if (handler != null)
                        {
                            ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                            ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                            handler(ObjPedidosClienteProcesadoInfo);
                        }
                        //...........................................................................
                    }
                    //..............................................................................................................................

                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE ASIGNACIÓN DE REGLAS OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    //Calcula el tiempo que demora en realizar la asignacion de reglas.
                    TimeSpan ts = DateTime.Now - _startAsignacionTime;
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: PROCESO DE ASIGNACIÓN DE REGLAS TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                    System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                    //}
                    //else
                    //{
                    //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    //}
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR ORDEN SIMULADOR: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "EXISTE OTRO PROCESO DE PEDIDOS ACTIVO, POR FAVOR VERIFICAR LA TABLA DE PEDIDOS TEMPORAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }


            return okTransac;
            //return okProcess;
        }


        /// <summary>
        /// Realiza la asignacion de inventario a cada pedido.
        /// </summary>
        /// <returns></returns>
        public string AsignarInventarioPedidoSimulador(List<string> ListadoProcesamiento, string TipoProcesamiento)
        {
            string okTransac = "NO se pudo asignar inventario a los pedidos.";

            bool okProcess = false;

            int consecutivo = 0; //consecutivo que cuenta los pedidos para saber cuando llega al ultimo.
            int si_cumpleninventario = 0;
            int no_cumpleninventario = 0;

            PedidosClienteInfo PedidoTotales = new PedidosClienteInfo();

            try
            {
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO PROCESO DE ASIGNACIÓN DE INVENTARIO HORA: " + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Captura el tiempo de inicio
                _startAsignacionTime = DateTime.Now;

                //Se obtienen los mailgroup por fecha actual.
                //MailGroup ObjMailGroup = new MailGroup("conexion");
                //List<MailGroupInfo> ObjMailGroupInfo = new List<MailGroupInfo>();

                //ObjMailGroupInfo = ObjMailGroup.ListxFechaActualFacturacion();

                ////se pregunta si existen Mailgroup para ese dia.
                //if (ObjMailGroupInfo != null && ObjMailGroupInfo.Count > 0)
                //{
                //Se realiza la asignacion de pedidos para cada mailgroup.
                //foreach (MailGroupInfo MailGroupActual in ObjMailGroupInfo)
                //{
                //System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "ASIGNANDO REGLAS PARA MAILGROUP:" + MailGroupActual.MailGroup.ToString(), MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //Se obtiene la campaña de la fecha actual.
                Campana ObjCampana = new Campana("conexion");
                CampanaInfo ObjCampanaInfo = new CampanaInfo();
                //ObjCampanaInfo = ObjCampana.ListxGetDate();

                if (CampanaSeleccionada != null && CampanaSeleccionada != "")
                {
                    ObjCampanaInfo = ObjCampana.ListxCampana(CampanaSeleccionada);
                }
                else
                {
                    ObjCampanaInfo = ObjCampana.ListxGetDate();
                }

                //Se valida que exista una campaña activa.
                if (ObjCampanaInfo != null)
                {

                    //REALIZA LA ASIGNACIÓN DE ARTICULOS A LOS PEDIDOS DEPENDIENDO DEL INVENTARIO ACTUAL
                    //1. Borrar tabla inventario para solo almacenar lo actual.
                    //2. Consultar saldos bodega.
                    //3. Copiar saldos de bodega del mes actual en la tabla de inventario.
                    //4. Consultar pedidos ordenados por orden de procesamiento.
                    //5. Actualizar el campo de cantidad  con respecto al inventario en el detalle del pedido.
                    //6. Restar cantidad actualizada a los saldos de inventario.

                    Inventario ObjInventario = new Inventario("conexion");

                    //Borrar la tabla de inventario para copiar el inventario actualizado.
                    if (ObjInventario.DeleteAll())
                    {
                        //Se consulta el inventario del mes actual.
                        List<InventarioInfo> ObjInventarioInfoList = new List<InventarioInfo>();
                        ObjInventarioInfoList = ObjInventario.ListSaldosBodega();

                        if (ObjInventarioInfoList != null && ObjInventarioInfoList.Count > 0)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO COPIAR INVENTARIO ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                            //Recorre los saldos de bodega (inventario mes actual) y los guarda en la tabla de inventario.
                            foreach (InventarioInfo ItemInventario in ObjInventarioInfoList)
                            {
                                //Copiar saldos de bodega del mes actual en la tabla de inventario.
                                if (!ObjInventario.Insert(ItemInventario))
                                {
                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO INGRESAR EL INVENTARIO. REF-CCOSTOS:" + ItemInventario.Referencia + ItemInventario.CCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                }
                            }

                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO COPIAR INVENTARIO ACTUAL OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                            //Zona ObjZona = new Zona("conexion");
                            //List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();

                            //ObjZonaInfoList = ObjZona.ListxMailGroup(MailGroupActual.MailGroup.ToString());

                            ////Se valida que existan zonas para el mailgroup actual.
                            //if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                            //{
                            //Se recorren las zonas y se consultan los pedidos por zona y campaña.
                            //foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                            //{
                            List<PedidosClienteInfo> ObjPedidosClienteConOrden = new List<PedidosClienteInfo>();


                            switch (TipoProcesamiento)
                            {
                                case "xMailgroup":
                                    foreach (string Mailgroup in ListadoProcesamiento)
                                    {
                                        List<ZonaInfo> ObjZonaInfoList = new List<ZonaInfo>();
                                        Zona ObjZona = new Zona("conexion");

                                        ObjZonaInfoList = ObjZona.ListxMailGroup(Mailgroup);

                                        if (ObjZonaInfoList != null && ObjZonaInfoList.Count > 0)
                                        {
                                            foreach (ZonaInfo ZonaMailGroup in ObjZonaInfoList)
                                            {
                                                //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                                                ObjPedidosClienteConOrden.AddRange(ListxZonaxCampanaxOrdenProcesadoSimulador(ZonaMailGroup.Zona, ObjCampanaInfo.Campana));
                                            }
                                        }
                                    }
                                    break;
                                case "xZona":

                                    foreach (string zona in ListadoProcesamiento)
                                    {
                                        ObjPedidosClienteConOrden.AddRange(ListxZonaxCampanaxOrdenProcesadoSimulador(zona, ObjCampanaInfo.Campana));
                                    }
                                    break;
                                case "xCedula":
                                    foreach (string Cedula in ListadoProcesamiento)
                                    {
                                        ObjPedidosClienteConOrden.Add(this.ListxNitxCampana(Cedula, ObjCampanaInfo.Campana));
                                    }
                                    break;
                                default:
                                    break;
                                //return ToString(o);
                            }

                            //Se envia la zona, campaña, el orderby orden para obtener los pedidos con reglas.
                            //ObjPedidosClienteConOrden = ListxZonaxCampanaxOrdenProcesado(ZonaMailGroup.Zona, ObjCampanaInfo.Campana);

                            //Se valida si existen pedidos de la zona y la campaña actual.
                            if (ObjPedidosClienteConOrden != null && ObjPedidosClienteConOrden.Count > 0)
                            {
                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE ORDEN A PEDIDOS CON REGLA.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                //Actualiza el estado a no procesado de los pedidos para volverlos a su estado inicial antes de rehacer el proceso.
                                foreach (PedidosClienteInfo PedidoConOrdenNoProcess in ObjPedidosClienteConOrden)
                                {
                                    UpdateProcesadoSimulador(PedidoConOrdenNoProcess.Numero, false);
                                }

                                int ContarAgotado = 0;

                                //Se insertan los pedidos a la tabla temporal.
                                foreach (PedidosClienteInfo PedidoConOrden in ObjPedidosClienteConOrden)
                                {
                                    bool okInventario = false;

                                    ContarAgotado = 0;

                                    //Consultar detalle del pedido.
                                    PedidosDetalleCliente ObjPedidosDetalleCliente = new PedidosDetalleCliente("conexion");
                                    List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoList = new List<PedidosDetalleClienteInfo>();
                                    ObjPedidosDetalleClienteInfoList = ObjPedidosDetalleCliente.ListPedidoDetallexIdSimulador(PedidoConOrden.Numero);

                                    //Se valida si existen detalles del pedido.
                                    if (ObjPedidosDetalleClienteInfoList != null && ObjPedidosDetalleClienteInfoList.Count > 0)
                                    {
                                        //Recorre el detalle del pedido.
                                        foreach (PedidosDetalleClienteInfo ObjPedidoDetalle in ObjPedidosDetalleClienteInfoList)
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "INICIO ASIGNACIÓN DE INVENTARIO PARA ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                            //Consulta el inventario del detalle del pedido especifico.
                                            InventarioInfo ObjInventarioInfoActual = new InventarioInfo();
                                            ObjInventarioInfoActual = ObjInventario.ListxBodegaxRefxCcostos("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote); //Lote = CCostos

                                            if (ObjInventarioInfoActual != null)
                                            {
                                                //Calcula la cantidad disponible en el inventario
                                                decimal CantidadDisp = CantidadDisponible(ObjPedidoDetalle.Cantidad, ObjInventarioInfoActual.Saldo);

                                                //actualiza la cantidad del detalle del pedido con la cantidad disponible.
                                                if (ObjPedidosDetalleCliente.UpdateCantidadSimulador(ObjPedidoDetalle.Id, CantidadDisp))
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO LA CANTIDAD DEL DETALLE DEL PEDIDO OK. ID DETALLE PEDIDO: " + ObjPedidoDetalle.Id, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                    okInventario = true;

                                                    okProcess = true;

                                                    //Actualiza la cantidad del saldo que quedo despues de asignar al pedido.
                                                    if (ObjInventario.UpdateCantidad("002", ObjPedidoDetalle.Referencia, ObjPedidoDetalle.Lote, CantidadSaldo(CantidadDisp, ObjInventarioInfoActual.Saldo)))
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                                        ContarAgotado = ContarAgotado + 1;
                                                    }
                                                    else
                                                    {
                                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL SALDO DEL LA REFERENCIA:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                    }

                                                    okTransac = "OK, se asigno inventario correctamente.";
                                                }
                                                else
                                                {
                                                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR LA CANTIDAD CON EL INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                                }
                                            }
                                            else
                                            {
                                                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO PARA DETALLE DE PEDIDO:" + ObjPedidoDetalle.Referencia + " - CCOSTOS:" + ObjPedidoDetalle.CentroCostos, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE DETALLE DEL PEDIDO:" + PedidoConOrden.Numero, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    //-------------------------------------------------------------------------------
                                    //Actualiza el estado del pedido a PROCESADO.
                                    if (okInventario)
                                    {
                                        okProcess = true;

                                        if (UpdateProcesadoSimulador(PedidoConOrden.Numero, true))
                                        {
                                            //Actualiza el estado del pedido a Procesado por que se proceso bien.
                                            bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(PedidoConOrden.Numero, (int)EstadosPedidoEnum.Procesado);

                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "SE ACTUALIZO SALDO DE INVENTARIO RESTANTE OK. ", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            si_cumpleninventario = si_cumpleninventario + 1;
                                        }
                                        else
                                        {
                                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE PUDO ACTUALIZAR EL PEDIDO A PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                            no_cumpleninventario = no_cumpleninventario + 1;
                                        }


                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ACTUALIZO LA CANTIDAD DEL PEDIDO, NO SE ACTUALIZO EL PEDIDO A ESTADO PROCESADO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                                    }

                                    //Preguntar si no se pudo asignar ni 1 solo articulo del inventario, lo qeu siginifica que esta agotado 100%.
                                    if (ContarAgotado == 0)
                                    {
                                        bool okTrasnEstadoPed = this.UpdateEstadoPedidoSimulador(PedidoConOrden.Numero, (int)EstadosPedidoEnum.Agotado);

                                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS BLOQUEAR X AGOTADO 100% DEL INVENTARIO: EL PEDIDO HA SIDO RETENIDO POR AGOTADO INVENTARIO = {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", PedidoConOrden.Numero + " NIT:" + PedidoConOrden.Nit, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                                        //Confirma que si se realizo el proceso por lo menos a 1 pedido.
                                        okProcess = true;

                                        //Contador de pedidos
                                        consecutivo = consecutivo + 1;
                                    }
                                }
                            }
                            //}
                            //}
                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE INVENTARIO EN SALDOS BODEGA PARA EL AÑO Y MES VIGENTE.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        }
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE BORRAR LA TABLA DE INVENTARIO, ABORTO EL PROCESO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTEN CAMPAÑAS ACTIVAS PARA LA FECHA ACTUAL.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }
                //}

                //..............................................................................................................................
                //EJECUTA EL METODO DE TERMINACION DEL PROCESO A LA CAPA DE PRESENTACION
                PedidosClienteInfo ObjPedidosClienteProcesadoInfo = new PedidosClienteInfo();

                if (okProcess == false)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR INVENTARIO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO SE ENCONTRARON PEDIDOS PARA ASIGNAR INVENTARIO.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //.......................................................................................
                    //Dispara el evento de terminar proceso sino se ejecuta ningun pedido.                                           
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = 1;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;
                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //.......................................................................................
                }
                else if (okProcess == true)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS ASIGNAR INVENTARIO: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO PROCESO DE PEDIDOS POR MAILGROUP X ZONA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    //......................................................................
                    //Asigna los pedidos con reglas asignadas.                                               
                    OnPedidoProcesamientoEventHandler handler = OnPedidoEvent;
                    if (handler != null)
                    {
                        ObjPedidosClienteProcesadoInfo.TotalPedidos = consecutivo;
                        ObjPedidosClienteProcesadoInfo.TotalSiCumplenInventario = si_cumpleninventario;
                        ObjPedidosClienteProcesadoInfo.TotalNoCumplenInventario = ObjPedidosClienteProcesadoInfo.TotalPedidos - ObjPedidosClienteProcesadoInfo.TotalSiCumplenInventario;
                        ObjPedidosClienteProcesadoInfo.TerminoProcess = true;

                        handler(ObjPedidosClienteProcesadoInfo);
                    }
                    //......................................................................
                }
                //..............................................................................................................................

                //}
                //else
                //{
                //    System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "NO EXISTE MAILGROUP PARA LA FECHA ACTUAL. FECHA:" + DateTime.Now, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //}

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "TERMINO ASIGNACIÓN DE INVENTARIO DE LOS PEDIDOS CON REGLA OK.", MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                //Calcula el tiempo que demora en realizar la asignacion de reglas.
                TimeSpan ts = DateTime.Now - _startAsignacionTime;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI PEDIDOS: PROCESO DE ASIGNACIÓN DE INVENTARIO TERMINADO DURACIÓN: {0}seg. Hora:{1}", ts.TotalSeconds, DateTime.Now));
                System.Diagnostics.Trace.WriteLine(string.Format("---------------------------------------------------------------------------------------------------------------------------------------"));

                okProcess = true;
            }
            catch (Exception ex)
            {
                okProcess = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            return okTransac;
        }



        #endregion


        #region "METODOS DE RESERVA EN LINEA"

        /// <summary>
        /// Lista todos los pedidos en reserva en linea sin facturar una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoEnReservaxCampanaxCatalogo(string Nit, string Campana, string Catalogo)
        {
            return module.ListxPedidoEnReservaxCampanaxCatalogo(Nit, Campana, Catalogo);
        }

        /// <summary>
        /// Valida si existe un pedido borrador en SVDN.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoBorradorSVDN(string Nit, string Campana)
        {
            return module.ListxPedidoBorradorSVDN(Nit, Campana);
        }

        #endregion

        #region DESMANTELADORA

        /// <summary>
        /// Realiza Actualizacion de los pedido con Empresaria estado Desmantelada
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateEstadoDesmanteladoPedido(string NumeroPedido, string Nit, string Zona, string Usuario)
        {
            try
            {
                return module.UpdateEstadoDesmanteladoPedido(NumeroPedido, Nit, Zona, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        ///  Realiza liberacion del pedido con Empresaria estado Desmantelada
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool LiberaEstadoDesmanteladoPedido(string NumeroPedido, string Zona, string Usuario)
        {
            try
            {
                return module.LiberaEstadoDesmanteladoPedido(NumeroPedido, Zona, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// GAVL 31/03/2013 PEDIDOS RESERVARDOS  CON BLOQUEO DE DESMANTELADORAS
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosDesmanteladora(string Campana)
        {
            return module.ListxGerenteZonaReservadosDesmanteladora(Campana);
        }
        #endregion

        #region Anula todos los pedidos Borrador


        /// <summary>
        ///  Anula todos los pedidos borrador a la fecha-hora Actual
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateAnulaTodosPedidosBo(string Usuario)
        {
            string motivo;
            try
            {
                motivo = "Anulacion Masiva: Se anula pedido borrador por vencimiento de fecha.";
                return module.UpdateAnulaTodosPedidosBo(Usuario, motivo, "19");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }
        #endregion

        #region Busca Pedidos por Mes para anular
        /// <summary>
        /// Lista todos los pedidos proximos a vencer para anular en el dia actual.
        /// </summary>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidosXMesAnular(string numeroPedido)
        {
            return module.ListPedidosxMesAnular(numeroPedido);
        }
        #endregion

        #region Asistentes


        /// <summary>
        /// GAVL Lista todos los pedidos en reserva guardados por los ASISTENTES
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxAsistenteFacturados(string CedulaRegional, string Campana)
        {
            return module.ListxAsistenteFacturados(CedulaRegional, Campana);
        }

        /// <summary>
        /// lista todos los Pedidos Facturados de un Asistente por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxAsistente(string CedulaRegional, string Campana)
        {
            return module.ListPedidosxAsistente(CedulaRegional, Campana);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora por Asistentes
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosxAsistentes(string Campana, string IdVendedor)
        {
            return module.ListPedidosRetenidosxAsistentes(Campana, IdVendedor);
        }

        /// <summary>
        /// --Lista los pedidos anulados X ASISTENTE
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosXAsistente(string Campana, string IdVendedor)
        {
            return module.ListPedidosAnuladosXAsistente(Campana, IdVendedor);
        }
        #endregion



        /// <summary>
       /// obtiene un pedido de los pedidos de siesa por el numero
       /// </summary>
       /// <param name="NumeroPedido"></param>
       /// <returns></returns>
        public PedidosClienteInfo ObtenerunPedidoSiesa(string NumeroPedido)
        {
            return module.ObtenerunPedidoSiesa(NumeroPedido);
        }

        /// <summary>
        /// obtiene un detalle pedido de los pedidos de siesa por el numero
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosDetallesSIESA_SVDNinfo ObtenerunPedidoDetalleSiesa(string NumeroPedido)
        {
            return module.ObtenerunPedidoDetalleSiesa(NumeroPedido);
        }



        #region siesa subzonas
        /// <summary>
        /// lista todos los Pedidos de una gerente de subzona por una campaña.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteSubZona(string Zona, string Campana)
        {
            return module.ListxGerenteSubZona(Zona, Campana);
        }

        /// <summary>
        /// lista todos los Pedidos de una gerente de subzona por una campaña facturados.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteSubZonaFacturados(string zona, string Campana)
        {
            return module.ListxGerenteSubZonaFacturados(zona, Campana);
        }

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, por subzona, desmanteladora de una campana
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosSubzona(string Campana, string zona)
        {
            return module.ListPedidosRetenidosSubzona(Campana, zona);
        }

        /// <summary>
        /// Lista los pedidos anulados por subzona
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosSubzona(string Campana, string zona)
        {
            return module.ListPedidosAnuladosSubzona(Campana, zona);
        }


         /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente subzona.
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteSubZonaReservados(string zona, string Campana)
        {
            return module.ListxGerenteSubZonaReservados(zona, Campana);
        }

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista. por subzona
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportistasubzona(string zona, string Campana)
        {
            return module.ListxGerenteZonaReservadosSinTransportistasubzona( zona,  Campana);
        }
        #endregion
        
        //--siesa subzonas
        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente. dependiendo de la bodega asigna el prefijo
        /// </summary>
        /// <param name="item"></param>
        public string InsertBODEGAPREFIJO(PedidosClienteInfo item,string bodega)
        {
            try{
                return module.InsertBODEGAPREFIJO(item, bodega);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }


         /// JUTA
        /// 
        /// <summary>
        /// Lista pedido preventa
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>      
        /// <returns></returns>
        public PedidosClienteInfo ListxPedidoPreventa(string Nit, string Campana)
        {
            return module.ListxPedidoPreventa(Nit, Campana);
        }


        /// <summary>
        /// Lista los pedidos borrador para reserva masiva
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosMasivo( string Campana)
        {
            return module.ListPedidosMasivo( Campana);
        }
       
    }
}
