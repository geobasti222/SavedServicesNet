using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Application.Enterprise.CommonObjects.Enumerations;
using System.Web.Http.Cors;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Application.Enterprise.Services.Controllers
{

    public class PedidoController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public PedidosClienteInfo GuardarEncabezadoPedido(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {
            //TODO: MRG: Lo que esta comentado hay que evaluarlo si aplica y hacerlo.
            //TODO: MRG: Lo que esta comentado hay que evaluarlo si aplica y hacerlo.
            //TODO: MRG: Lo que esta comentado hay que evaluarlo si aplica y hacerlo.
            //TODO: MRG: Lo que esta comentado hay que evaluarlo si aplica y hacerlo.
            //TODO: MRG: Lo que esta comentado hay que evaluarlo si aplica y hacerlo.

            #region "Insertar Encabezado del Pedido"

            //********************************************************************************************************************
            //Parametros de encabezado de pedido.
            PedidosClienteInfo objPedidosClienteInfo = new PedidosClienteInfo();
            PedidosCliente objPedidosCliente = new PedidosCliente("conexion");

            string Mes = "00";

            if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
            {
                Mes = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                Mes = DateTime.Now.Month.ToString();
            }


            //string IdVendedor = "";
            // string IdZona = "";
            //string IdAsistente = ""; //GAVL  NUMERO DEL ASISTENTE

            // -----------------------------------------------------------------------------------------------------
            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona) || Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                IdVendedor = Session["IdVendedor"].ToString().Trim();
                IdZona = Session["IdZona"].ToString().Trim();

                //INICIO GAVL  NUMERO DEL ASISTENTE
                if (Session["Asistente"].ToString().Trim() != "")
                {
                    IdAsistente = Session["Asistente"].ToString().Trim();
                }
                //FIN GAVL
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                Cliente objCliente = new Cliente("conexion");
                ClienteInfo objClienteInfo = new ClienteInfo();

                objClienteInfo = objCliente.ListClienteNivixNit(txt_nodocumento.Text);

                IdVendedor = objClienteInfo.Vendedor.Trim();
                IdZona = objClienteInfo.Zona.Trim();
            }

            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Asistentes))
            {
                Cliente objCliente = new Cliente("conexion");
                ClienteInfo objClienteInfo = new ClienteInfo();

                objClienteInfo = objCliente.ListClienteNivixNit(txt_nodocumento.Text);

                IdVendedor = objClienteInfo.Vendedor.Trim();
                IdZona = objClienteInfo.Zona.Trim();

                //INICIO GAVL  NUMERO DEL ASISTENTE
                if (Session["Asistente"].ToString().Trim() != "")
                {
                    IdAsistente = Session["Asistente"].ToString().Trim();
                }
                //FIN GAVL  

            }*/
            //------------------------------------------------------------------------------------------------------

            objPedidosClienteInfo.Mes = DateTime.Now.Year.ToString() + Mes;
            objPedidosClienteInfo.Fecha = DateTime.Now;
            objPedidosClienteInfo.Anulado = 0;
            objPedidosClienteInfo.Espera = 0;
            objPedidosClienteInfo.Despacho = DateTime.Now;
            objPedidosClienteInfo.Nit = ObjPedidosClienteInfoRequest.Nit.Trim();
            objPedidosClienteInfo.Vendedor = ObjPedidosClienteInfoRequest.IdVendedor.Trim();
            objPedidosClienteInfo.IVA = ObjPedidosClienteInfoRequest.IVA; //valor del pedido * iva (16%). Solo para encabezado de pedido.
            objPedidosClienteInfo.Valor = ObjPedidosClienteInfoRequest.Valor; //valor total con iva incuido. Solo para encabezado de pedido.
            objPedidosClienteInfo.Descuento = 0;
            objPedidosClienteInfo.FechaCreacion = DateTime.Now;
            objPedidosClienteInfo.ClaveUsuario = ObjPedidosClienteInfoRequest.ClaveUsuario.Trim();
            objPedidosClienteInfo.Zona = ObjPedidosClienteInfoRequest.Zona.Trim();
            objPedidosClienteInfo.CodigoNumeracion = "PEW"; //002 tipo de documento requerido por G&G 
            objPedidosClienteInfo.Transmitido = 0;
            //*- objPedidosClienteInfo.Campana = txt_campana.Text;
            objPedidosClienteInfo.Campana = ObjPedidosClienteInfoRequest.Campana.Trim();
            objPedidosClienteInfo.NumeroEnvio = "";
            objPedidosClienteInfo.NoFacturado = 0;
            objPedidosClienteInfo.Facturar = 0;
            objPedidosClienteInfo.CodTipo = "004"; // Codigo 01 significa facturacion masiva, asi se necesita para el sistema de G&G
            objPedidosClienteInfo.Devol = "";
            objPedidosClienteInfo.Factura = "";
            objPedidosClienteInfo.Orden = 0;
            objPedidosClienteInfo.Procesado = false;
            objPedidosClienteInfo.GeneraPremios = true;

            objPedidosClienteInfo.ExcentoIVA = ObjPedidosClienteInfoRequest.ExcentoIVA;
            objPedidosClienteInfo.CodCiudadCliente = ObjPedidosClienteInfoRequest.CodCiudadCliente;
            objPedidosClienteInfo.PuntosUsar = ObjPedidosClienteInfoRequest.PuntosUsar;

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Precio Catalogo
            objPedidosClienteInfo.IVAPrecioCat = ObjPedidosClienteInfoRequest.IVAPrecioCat; //valor precio catalogo del pedido * iva (16%). Solo para encabezado de pedido.
            objPedidosClienteInfo.ValorPrecioCat = ObjPedidosClienteInfoRequest.ValorPrecioCat; //valor precio catalogo total con iva incuido. Solo para encabezado de pedido.
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            objPedidosClienteInfo.Codigo = ObjPedidosClienteInfoRequest.Codigo.Trim();//rcb_catalogo.SelectedValue;

            //Activar guardar auditoria si el perfil es de un usuario interno de nivi y no una gerente
            /*if (Session["MostrarNombreGerente"] != null)
            {
                if (Session["MostrarNombreGerente"].ToString() == "true")
                {
                    objPedidosClienteInfo.GuardarAuditoria = true;
                    objPedidosClienteInfo.Usuario = Session["NombreUsuario"].ToString();
                }
            }*/

            objPedidosClienteInfo.IdLider = "N/A";

            objPedidosClienteInfo.Reserva = true; // si el pedido se creo por reserva en linea es true.
            objPedidosClienteInfo.Borrador = true; // si el pedido es borrador es por que es por reserva en linea.

            ZonaInfo objZonaInfo = new ZonaInfo();
            Zona objZona = new Zona("conexion");

            objZonaInfo = objZona.CargarVariablesZona(ObjPedidosClienteInfoRequest.Zona.Trim());

            objPedidosClienteInfo.FechaCierreBorrador = DateTime.Now.AddDays((objZonaInfo.DiasBorrador));

            //strFechaCierreBorrador = objPedidosClienteInfo.FechaCierreBorrador.ToString();

            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                objPedidosClienteInfo.Portal = "GERENTE DE ZONA";
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                objPedidosClienteInfo.Portal = "GERENTE DIVISIONAL";
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                objPedidosClienteInfo.Portal = "LIDER";
            }*/

            objPedidosClienteInfo.Portal = "SAVED";

            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            //para guardar el lider.
            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                ClienteInfo objClienteInfo = new ClienteInfo();
                NIVI.SVDN.Business.Rules.Cliente objClienteEcu = new NIVI.SVDN.Business.Rules.Cliente("conexion");

                objClienteInfo = objClienteEcu.ListxNITSimpleEdit(objPedidosClienteInfo.Nit);

                if (objClienteInfo == null)
                {
                    objPedidosClienteInfo.IdLider = Session["IdVendedor"].ToString();
                }
                else
                {
                    objPedidosClienteInfo.IdLider = objClienteInfo.Lider;
                }
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                if (Session["IdLider"] != null)
                {
                    objPedidosClienteInfo.IdLider = Session["IdLider"].ToString();
                }
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                ClienteInfo objClienteInfo = new ClienteInfo();
                NIVI.SVDN.Business.Rules.Cliente objClienteEcu = new NIVI.SVDN.Business.Rules.Cliente("conexion");

                objClienteInfo = objClienteEcu.ListxNITSimpleEdit(objPedidosClienteInfo.Nit);

                if (objClienteInfo == null)
                {
                    objPedidosClienteInfo.IdLider = Session["IdVendedor"].ToString();
                }
                else
                {
                    objPedidosClienteInfo.IdLider = objClienteInfo.Lider.Trim();
                }
            }*/

            objPedidosClienteInfo.IdLider = ObjPedidosClienteInfoRequest.IdLider.Trim();
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


            //?????????????????????????????????????????????????????????????????????????????????????????????
            //Tipo Envio de pedido
            /*if (Session["vstipoenviopedido"] != null)
            {
                if (Session["vstipoenviopedido"].ToString() != "0" && Session["vstipoenviopedido"].ToString() != "")
                {
                    objPedidosClienteInfo.TipoEnvio = Convert.ToInt32(Session["vstipoenviopedido"].ToString());
                }
                else
                {
                    if (TipoEnvioCliente != 0)
                    {
                        objPedidosClienteInfo.TipoEnvio = TipoEnvioCliente; // si no se selecciona el tipo de envio, siempre va para la casa.
                    }
                    else
                    {
                        objPedidosClienteInfo.TipoEnvio = (int)TipoEnvioEnum.CasaEmpresaria; // si no se selecciona el tipo de envio, siempre va para la casa.
                    }
                }
            }
            else
            {
                if (TipoEnvioCliente != 0)
                {
                    objPedidosClienteInfo.TipoEnvio = TipoEnvioCliente; // si no se selecciona el tipo de envio, siempre va para la casa.
                }
                else
                {
                    objPedidosClienteInfo.TipoEnvio = (int)TipoEnvioEnum.CasaEmpresaria; // si no se selecciona el tipo de envio, siempre va para la casa.
                }

            }*/

            //TODO MRG: Este valor (TipoEnvio+CiudadDespacho) debe activar el comentado anterior y se debe guardar el que se elija en los datos de envio de la app.
            objPedidosClienteInfo.TipoEnvio = ObjPedidosClienteInfoRequest.TipoEnvio;
            objPedidosClienteInfo.CiudadDespacho = ObjPedidosClienteInfoRequest.CiudadDespacho;
            //?????????????????????????????????????????????????????????????????????????????????????????????

            //*objPedidosClienteInfo.CiudadDespacho = CodCiudadDespacho;
            objPedidosClienteInfo.Asistente = ObjPedidosClienteInfoRequest.Asistente; //IdAsistente.Trim(); //GAVL NUMERO DEL ASISTENTE


            string IdPedido = objPedidosCliente.Insert(objPedidosClienteInfo);



            if (IdPedido != null && IdPedido != "")
            {
                objPedidosClienteInfo.Numero = IdPedido;
                objPedidosClienteInfo.okTransEncabezadoPedido = true;
            }

            else
            {
                string msg = "No se pudo guardar encabezado de pedido. Nit: " + ObjPedidosClienteInfoRequest.Nit + ", Fecha: " + DateTime.Now.ToString();

                objPedidosClienteInfo.Numero = "-1";

                objPedidosClienteInfo.Error = new Error();
                objPedidosClienteInfo.Error.Id = -1;
                objPedidosClienteInfo.Error.Descripcion = msg;

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", msg, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            #endregion



            return objPedidosClienteInfo;
        }


        [HttpGet]
        [HttpPost]
        public PedidosClienteInfo GuardarDetallePedido(List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoRequest)
        {

            PedidosClienteInfo objPedidosClienteInfo = new PedidosClienteInfo();
            bool ExcentoIVA = false;
            string CodCiudadCliente = "";
            string IdPedido = "";
            string IdZona = "";
            string Campana = "";
            string Catalogo = "";
            bool okGuardar = false;
            bool AdicionarFlete = false;
            string CodCiudadDespacho = "";
            string TipoEnvio = "";
            string Usuario = "";
            string IdLider = "";
            bool PagarFletePuntos = false;

            if (ObjPedidosDetalleClienteInfoRequest.Count > 0)
            {
                objPedidosClienteInfo = ObjPedidosDetalleClienteInfoRequest[0].PedidosClienteInfo;
                ExcentoIVA = objPedidosClienteInfo.ExcentoIVA;
                CodCiudadCliente = objPedidosClienteInfo.CodCiudadCliente;

                IdZona = objPedidosClienteInfo.Zona;
                Campana = objPedidosClienteInfo.Campana;
                Catalogo = objPedidosClienteInfo.Codigo;
                CodCiudadDespacho = objPedidosClienteInfo.CiudadDespacho;
                TipoEnvio = objPedidosClienteInfo.TipoEnvio.ToString();
                Usuario = objPedidosClienteInfo.Usuario;
                IdLider = objPedidosClienteInfo.IdLider; //MRG: Verificar que si se cargue el id cuando se elige lider.
                PagarFletePuntos = objPedidosClienteInfo.PagarFletePuntos;
            }


            #region "Insertar Detalle del Pedido"
            if (objPedidosClienteInfo.Numero != "" && objPedidosClienteInfo.Numero != null)
            {

                IdPedido = objPedidosClienteInfo.Numero;


                //********************************************************************************************************************
                //Parametros de detalle de pedido.

                //Se copia la lista de articulos en sesion para poder contar los articulos repetidos.

                PedidosDetalleCliente objPedidosDetalleCliente = new PedidosDetalleCliente("conexion");

                //SubTotalPrecioCat = 0;
                //IVAPrecioCat = 0;

                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //Se obtienen los parametros de descuento
                //-----------------------------------------------------------------------------------------
                Descuento objDescuento = new Descuento("conexion");
                DescuentoInfo objDescuentoInfo = new DescuentoInfo();


                decimal decSubTotal = 0;
                decimal decIVA = 0;
                decimal decSubTotalPrecioCat = 0;
                decimal decIVAPrecioCat = 0;


                ArtExcentosxCiudad objArtExcentosxCiudad = new ArtExcentosxCiudad("conexion");
                ArtExcentosxCiudadInfo objArtExcentosxCiudadInfo = new ArtExcentosxCiudadInfo();
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                foreach (PedidosDetalleClienteInfo item in ObjPedidosDetalleClienteInfoRequest)
                {
                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = AdicionarDetallePedido(Convert.ToInt32(item.PLU), Convert.ToDecimal(item.Cantidad), (item.CodigoRapidoSustituto == "&NBSP;" || item.CodigoRapidoSustituto == "&nbsp;") ? "" : item.CodigoRapidoSustituto, Convert.ToInt32(item.PLUSustituto), IdZona, CodCiudadCliente);

                    if (ExcentoIVA)
                    {
                        objPedidosDetalleClienteInfo.TarifaIVA = 0; // si es excento debe ser 0% el IVA.
                    }
                    else
                    {
                        objPedidosDetalleClienteInfo.TarifaIVA = ConsultarIVA(objPedidosDetalleClienteInfo.Grupo); //Tarifa iva = 16% ej.
                    }

                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //Se valida si el articulo se encuentra excento de iva en la ciudad del cliente.

                    if (!ExcentoIVA)
                    {
                        objArtExcentosxCiudadInfo = objArtExcentosxCiudad.ListxCiudadxPlu(CodCiudadCliente, Convert.ToInt32(objPedidosDetalleClienteInfo.PLU));

                        //Si se encuentra exento el iva debe ser 0.
                        if (objArtExcentosxCiudadInfo != null)
                        {
                            objPedidosDetalleClienteInfo.TarifaIVA = 0;
                        }
                    }
                    else
                    {
                        objPedidosDetalleClienteInfo.TarifaIVA = 0;
                    }

                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                    //obtiene la cantidad del articulo
                    //*int Cantidad = CantidadArticulos(PedidoDetalleListTemp[i].Referencia);

                    objPedidosDetalleClienteInfo.Numero = IdPedido;
                    objPedidosDetalleClienteInfo.Referencia = objPedidosDetalleClienteInfo.Referencia;
                    objPedidosDetalleClienteInfo.Descripcion = objPedidosDetalleClienteInfo.Descripcion.Replace("<b>", "").Replace("</b>", ""); //articulo + color + talla
                    objPedidosDetalleClienteInfo.Valor = item.Valor; //valor de 1 solo articulo sin iva
                    objPedidosDetalleClienteInfo.Cantidad = objPedidosDetalleClienteInfo.Cantidad;
                    objPedidosDetalleClienteInfo.Descuento = 0;
                    objPedidosDetalleClienteInfo.Anulado = 0;

                    objPedidosDetalleClienteInfo.PuntosGanados = item.PuntosGanados;
                    objPedidosDetalleClienteInfo.PorcentajeDescuentoPuntos = item.PorcentajeDescuentoPuntos;

                    objPedidosDetalleClienteInfo.Lote = objPedidosDetalleClienteInfo.CentroCostos;
                    objPedidosDetalleClienteInfo.Ensamblado = 0;
                    objPedidosDetalleClienteInfo.CantidadPedida = 0; //Se envia cero para el arreglo del inventario.
                    objPedidosDetalleClienteInfo.IdDocumentoFuente = "";
                    objPedidosDetalleClienteInfo.CodigoUbicacion = objPedidosDetalleClienteInfo.CodigoUbicacion;
                    objPedidosDetalleClienteInfo.PLU = objPedidosDetalleClienteInfo.PLU;
                    objPedidosDetalleClienteInfo.NumeroEnvio = 0;
                    objPedidosDetalleClienteInfo.ConceptoContable = objPedidosDetalleClienteInfo.ConceptoContable;//campo ccostos del kardex
                    objPedidosDetalleClienteInfo.CentroCostos = IdZona;
                    objPedidosDetalleClienteInfo.Grupo = objPedidosDetalleClienteInfo.Grupo;
                    objPedidosDetalleClienteInfo.Imagen = objPedidosDetalleClienteInfo.Imagen;

                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    //Precio Catalogo
                    objPedidosDetalleClienteInfo.ValorPrecioCatalogo = objPedidosDetalleClienteInfo.ValorPrecioCatalogo;


                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                    if (!ExcentoIVA)
                    {
                        //Si se encuentra exento el iva debe ser 0.
                        if (objArtExcentosxCiudadInfo != null)
                        {
                            objPedidosDetalleClienteInfo.IVAPrecioCatalogo = 0;
                        }
                        else
                        {
                            objPedidosDetalleClienteInfo.IVAPrecioCatalogo = ((objPedidosDetalleClienteInfo.ValorPrecioCatalogo) * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100));
                        }
                    }
                    else
                    {
                        objPedidosDetalleClienteInfo.IVAPrecioCatalogo = 0;
                    }

                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()



                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    objPedidosDetalleClienteInfo.Catalogo = Catalogo;
                    objPedidosDetalleClienteInfo.NumeroPedidoPadre = IdPedido;

                    if (item.Cantidad > 0)
                    {
                        objPedidosDetalleClienteInfo.ValorUnitario = (item.Valor) / item.Cantidad;
                    }
                    objPedidosDetalleClienteInfo.IdCodigoCorto = item.IdCodigoCorto;
                    objPedidosDetalleClienteInfo.CatalogoReal = Catalogo;// "691"; //MRG: corregir a catalogo REAL desde BD
                    ///item.CatalogoReal;

                    objPedidosDetalleClienteInfo.UnidadNegocio = objPedidosDetalleClienteInfo.UnidadNegocio;


                    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    //-----------------------------------------------------------------------------------------
                    //Se obtienen los parametros de descuento
                    //-----------------------------------------------------------------------------------------
                    //Se guarda el valor precio catalogo menos el descuento asignado por valor del pedido.

                    //se consula el tipo de descuento a aplicar con el valor precio catalogo sin articulos no disponibles, ni valores de outlet nivi/pisame.

                    if (objPedidosDetalleClienteInfo.UnidadNegocio == "02")
                    {
                        //MRG: Validar si aun aplican esas reglas de descuento de pisame, etc.
                        //*objDescuentoInfo = objDescuento.ListxValorPedido(ValorTotalParaDescuentoPisame, objPedidosDetalleClienteInfo.UnidadNegocio, objPedidosDetalleClienteInfo.GrupoProducto, Campana);
                        objDescuentoInfo = objDescuento.ListxValorPedido(0, objPedidosDetalleClienteInfo.UnidadNegocio, objPedidosDetalleClienteInfo.GrupoProducto, Campana);
                    }
                    else
                    {
                        //*objDescuentoInfo = objDescuento.ListxValorPedido(ValorTotalParaDescuento, objPedidosDetalleClienteInfo.UnidadNegocio, objPedidosDetalleClienteInfo.GrupoProducto, Campana);
                        objDescuentoInfo = objDescuento.ListxValorPedido(0, objPedidosDetalleClienteInfo.UnidadNegocio, objPedidosDetalleClienteInfo.GrupoProducto, Campana);
                    }

                    //poner validacion de catalgo hogar
                    decimal dcPorcentaje = 0;

                    if (objDescuentoInfo != null)
                    {
                        //Se validan los porcentajes
                        if (objPedidosDetalleClienteInfo.CatalogoReal.Trim().ToUpper().StartsWith("H"))
                        {
                            dcPorcentaje = objDescuentoInfo.PorcentajeHogar;
                        }
                        else
                        {
                            //Si es outlet nivi/pisame el descuento es 0%, de lo contrario es lo que venga.
                            if (objPedidosDetalleClienteInfo.CatalogoReal.Trim().ToUpper().StartsWith("T"))
                            {
                                dcPorcentaje = 0;
                            }
                            else if (objPedidosDetalleClienteInfo.CatalogoReal.ToUpper().StartsWith("L"))
                            {
                                dcPorcentaje = 0;
                            }
                            else
                            {
                                dcPorcentaje = objDescuentoInfo.Porcentaje;
                            }
                        }
                    }
                    else
                    {

                        //Mensaje de error                 
                        //RadWindowManager1.RadAlert("No se pudo guardar el pedido. Motivo: ausencia rango descuento. <br>Por favor comuniquese con Inteligencia Comercial para almacenar su pedido.", 350, 140, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");

                        dcPorcentaje = 0; // sino se encuentra un descuento definido se pone por defecto el 0.

                    }

                    if (item.Cantidad > 0)
                    {
                        objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = item.ValorPrecioCatalogo / item.Cantidad; //valor unitario precio cat SIN IVA
                    }

                    //objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario - (objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario * (dcPorcentaje / 100)); //valor del descuento de 1 solo articulo.

                    //objPedidosDetalleClienteInfo.PorcentajeDescuento = dcPorcentaje; 
                    objPedidosDetalleClienteInfo.PorcentajeDescuento = item.PorcentajeDescuento;


                    decSubTotal = decSubTotal + (objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.Cantidad);
                    decIVA = decIVA + ((objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.Cantidad) * (objPedidosDetalleClienteInfo.TarifaIVA / 100));

                    decSubTotalPrecioCat = decSubTotalPrecioCat + (objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario * objPedidosDetalleClienteInfo.Cantidad);
                    decIVAPrecioCat = decIVAPrecioCat + ((objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario * objPedidosDetalleClienteInfo.Cantidad) * (objPedidosDetalleClienteInfo.TarifaIVA / 100));
                    //------------------------------------------------------------------------------------------------
                    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //Este trozo valida si no se desea guardar esta linea del detalle del pedido.
                    // Si la variable InsertarRegistro es false no se ingresa el registro.
                    bool InsertarRegistro = true;


                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                    string IdPedidoDetalle = "";

                    //GAVL INICIO SE AGREGA VALIDACION DE CAMPOS SUSTITUTOS PARA QUE NO DAÑE LA LIDER FLETES
                    if (objPedidosDetalleClienteInfo.PLUSustituto == null || objPedidosDetalleClienteInfo.PLUSustituto == 0 || objPedidosDetalleClienteInfo.CodigoRapidoSustituto == null || objPedidosDetalleClienteInfo.CodigoRapidoSustituto == "")
                    {
                        objPedidosDetalleClienteInfo.PLUSustituto = 0;
                        objPedidosDetalleClienteInfo.CodigoRapidoSustituto = "";
                    }
                    //GAVL FIN

                    if (InsertarRegistro)
                    {
                        IdPedidoDetalle = objPedidosDetalleCliente.Insert(objPedidosDetalleClienteInfo);
                        objPedidosClienteInfo.okTransDetallePedido = true;
                        AdicionarFlete = true;
                    }

                    okGuardar = true;
                }

                //===============================================================================================
                //Agregar flete x ciudad.
                PedidosDetalleClienteInfo objPedidosDetalleClienteInfoFlete = new PedidosDetalleClienteInfo();
                bool InsertarFlete = true;

                if (AdicionarFlete)
                {
                    if (CodCiudadDespacho != null)
                    {

                        //Sino tiene ciudad de despacho se asigna el flete x zona.
                        if (CodCiudadDespacho != "")
                        {
                            objPedidosDetalleClienteInfoFlete = AdicionarFletePedidoConCiudad(true, IdPedido, CodCiudadDespacho, IdZona, ExcentoIVA, Usuario, Catalogo, PagarFletePuntos);
                        }
                        else
                        {
                            //GAVL DETALLE FLETE LIDER Y POR ZONA
                            if (TipoEnvio == "2")
                            {
                                objPedidosDetalleClienteInfoFlete = AdicionarFletePedidoConZona(true, IdPedido, CodCiudadCliente, IdZona, ExcentoIVA, Usuario, Catalogo, PagarFletePuntos);
                            }
                            else if (TipoEnvio == "3")
                            {
                                objPedidosDetalleClienteInfoFlete = AdicionarFletePedidoConLider(true, IdPedido, CodCiudadCliente, IdZona, ExcentoIVA, Usuario, IdLider, Catalogo, PagarFletePuntos);
                            }
                            else if (TipoEnvio == "4") //Punto de venta. NO DEBE ADICIONA FLETE
                            {
                                InsertarFlete = false;
                            }
                        }
                    }
                    else
                    {
                        objPedidosDetalleClienteInfoFlete = AdicionarFletePedidoConCiudad(true, IdPedido, CodCiudadDespacho, IdZona, ExcentoIVA, Usuario, Catalogo, PagarFletePuntos);
                    }

                    //MRG: Aqui se inserta el flete x empresaria, x lider, x zona
                    if (InsertarFlete)
                    {
                        string IdPedidoDetalle = objPedidosDetalleCliente.Insert(objPedidosDetalleClienteInfoFlete);

                        AdicionarFlete = false;
                    }

                }
                //===============================================================================================
                //MRG: Revisar codigo de aqui para abajo para ver si aplican las reglas de premios de bienvenida y catalogos. Actualizar los totales del pedido.
                /*

                //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                //Agregar flete x ciudad.

                if (AdicionarFleteYPremios)
                {
                    bool TipoFlete = ValidarPedidoMinimoxTipoParaFlete();

                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

                    //si tipo flete es true se asigna el flete normal. sino se asigna el flete full.
                    //if (TipoFlete)
                    //{

                    //}

                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                    //Este trozo valida si se eligio una ciudad de una empresaria para enviar el pedido.
                    if (CodCiudadDespacho != null)
                    {

                        //Sino tiene ciudad de despacho se asigna el flete x zona.
                        if (CodCiudadDespacho != "")
                        {
                            CodCiudadCliente = CodCiudadDespacho;

                            objPedidosDetalleClienteInfo = AdicionarFletePedidoConCiudad(TipoFlete, this.IdPedido);
                        }
                        else
                        {
                            //GAVL DETALLE FLETE LIDER Y POR ZONA
                            if (Session["vstipoenviopedido"].ToString() != "3")
                            {
                                objPedidosDetalleClienteInfo = CrearDetalleFletePedidoParaZona();
                            }
                            else
                            {
                                objPedidosDetalleClienteInfo = CrearDetalleFletePedidoParaLider();
                            }
                        }
                    }
                    else
                    {
                        objPedidosDetalleClienteInfo = AdicionarFletePedidoConCiudad(TipoFlete, this.IdPedido);
                    }
                    //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()



                    if (ExcentoIVA)
                    {
                        objPedidosDetalleClienteInfo.TarifaIVA = 0; // si es excento debe ser 0% el IVA.
                    }
                    else
                    {
                        //Este trozo de codigo se debe quedar aqui.
                        if (objPedidosDetalleClienteInfo.IdCodigoCorto == "FL00")
                        {
                            objPedidosDetalleClienteInfo.Grupo = "FT0001"; // Grupo del flete en colombia para flete.
                        }

                        objPedidosDetalleClienteInfo.TarifaIVA = ConsultarIVA(objPedidosDetalleClienteInfo.Grupo); //Tarifa iva = 16% ej.
                    }

                    //Este trozo de codigo se debe quedar aqui.
                    if (objPedidosDetalleClienteInfo.IdCodigoCorto == "FL00")
                    {
                        objPedidosDetalleClienteInfo.Referencia = "FT0001";                       
                        objPedidosDetalleClienteInfo.Grupo = "FT0001"; // Grupo del flete en colombia para flete.
                        objPedidosDetalleClienteInfo.CentroCostos = objPedidosClienteInfo.Zona;
                        objPedidosDetalleClienteInfo.ConceptoContable = "005";                        
                        objPedidosDetalleClienteInfo.CodigoUbicacion = "P000"; //para flete en colombia.                        
                        objPedidosDetalleClienteInfo.Cantidad = 1;
                        objPedidosDetalleClienteInfo.PLU = 3357;

                        objPedidosDetalleClienteInfo.CantidadPedida = 1;
                        objPedidosDetalleClienteInfo.CatalogoReal = rcb_catalogo.SelectedValue;

                        objPedidosDetalleClienteInfo.ValorPrecioCatalogo = objPedidosDetalleClienteInfo.ValorUnitario;
                        objPedidosDetalleClienteInfo.IVAPrecioCatalogo = ((objPedidosDetalleClienteInfo.ValorPrecioCatalogo) * (objPedidosDetalleClienteInfo.TarifaIVA / 100));

                        //GAVL SE AGREGA  CAMPOS DE SUSTITUTOS PARA EL FUNCIONAMIENTO DEL FLETES
                        objPedidosDetalleClienteInfo.PLUSustituto = 0;
                        objPedidosDetalleClienteInfo.CodigoRapidoSustituto = "";
                        //FIN GAVL
                    }

                    //GAVL SE AGREGA  CAMPOS DE SUSTITUTOS PARA EL FUNCIONAMIENTO DEL FLETES
                    if (objPedidosDetalleClienteInfo.PLUSustituto == null || objPedidosDetalleClienteInfo.PLUSustituto == 0 || objPedidosDetalleClienteInfo.CodigoRapidoSustituto == null || objPedidosDetalleClienteInfo.CodigoRapidoSustituto == "")
                    {
                        objPedidosDetalleClienteInfo.PLUSustituto = 0;
                        objPedidosDetalleClienteInfo.CodigoRapidoSustituto = "";
                    }
                    //FIN GAVL 

                    decSubTotal = decSubTotal + (objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.Cantidad);
                    decIVA = decIVA + ((objPedidosDetalleClienteInfo.Valor * objPedidosDetalleClienteInfo.Cantidad) * (objPedidosDetalleClienteInfo.TarifaIVA / 100));

                    decSubTotalPrecioCat = decSubTotalPrecioCat + (objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario * objPedidosDetalleClienteInfo.Cantidad);
                    decIVAPrecioCat = decIVAPrecioCat + ((objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario * objPedidosDetalleClienteInfo.Cantidad) * (objPedidosDetalleClienteInfo.TarifaIVA / 100));

                    string IdPedidoDetalle = objPedidosDetalleCliente.Insert(objPedidosDetalleClienteInfo);

                    //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                    //Si el cliente no ha recibido premio de bienvenido se adiciona en el detalle.
                    if (PremioBienvenida == 0)
                    {
                        NIVI.SVDN.Business.Rules.Parametros objParametros = new NIVI.SVDN.Business.Rules.Parametros("conexion");
                        NIVI.SVDN.Common.Entities.ParametrosInfo objParametrosInfo = new NIVI.SVDN.Common.Entities.ParametrosInfo();

                        objParametrosInfo = objParametros.ListxId((int)ParametrosEnum.ValorPedidoPremioBienvenida);

                        if (objParametrosInfo != null)
                        {
                            //decimal ValorPrecionCatSinFlete = (ValorPrecioCatPremio + IVAPrecioCatPremio);

                            //Si el pedido cumple con el valor minimo para asignar el premio. 
                            if (TotalPrecioCatalogoGlobal >= Convert.ToDecimal(objParametrosInfo.Valor))
                            {
                                //se consultan los premios de bienvenida activos por unidad de negocio.
                                List<PedidosDetalleClienteInfo> objPedidosDetallePremiosInfo = objPedidosDetalleCliente.ListPremiosBienvenidaActivos(("0" + TipoPedidoMinimo.ToString()));

                                if (objPedidosDetallePremiosInfo != null && objPedidosDetallePremiosInfo.Count > 0)
                                {
                                    foreach (PedidosDetalleClienteInfo Premio in objPedidosDetallePremiosInfo)
                                    {
                                        string fecha = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                                        Premio.Id = this.IdPedido + "_PRE_" + fecha;
                                        Premio.Numero = this.IdPedido;
                                        Premio.NumeroPedidoPadre = this.IdPedido;
                                        Premio.IdDocumentoFuente = DateTime.Now.ToString();
                                        Premio.Catalogo = rcb_catalogo.SelectedValue;
                                        Premio.CatalogoReal = Premio.Catalogo;
                                        Premio.IdCodigoCorto = "PRE00";
                                        Premio.PorcentajeDescuento = 0;
                                        Premio.CentroCostos = Session["IdZona"].ToString().Trim();

                                        decSubTotal = decSubTotal + (Premio.Valor * Premio.Cantidad);
                                        decIVA = decIVA + ((Premio.Valor * Premio.Cantidad) * (Premio.TarifaIVA / 100));

                                        decSubTotalPrecioCat = decSubTotalPrecioCat + (Premio.ValorPrecioCatalogoUnitario * Premio.Cantidad);
                                        decIVAPrecioCat = decIVAPrecioCat + ((Premio.ValorPrecioCatalogoUnitario * Premio.Cantidad) * (Premio.TarifaIVA / 100));

                                        Premio.PLUSustituto = 0;
                                        Premio.CodigoRapidoSustituto = "";

                                        string IdPedidoDetallePremio = objPedidosDetalleCliente.Insert(Premio);

                                        if (IdPedidoDetallePremio == "" || IdPedidoDetallePremio == null)
                                        {
                                            Auditoria objAuditoria = new Auditoria("conexion");
                                            AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                                            objAuditoriaInfo.FechaSistema = DateTime.Now;
                                            objAuditoriaInfo.Proceso = "No se pudo adicionar premio de bienvenida al pedido: " + this.IdPedido;
                                            objAuditoriaInfo.Usuario = Session["Usuario"].ToString().Trim();

                                            objAuditoria.Insert(objAuditoriaInfo);
                                        }
                                    }
                                }
                            }

                            //Siempre se debe actualizar el estado del premio entregado asi no lo haya ganado.
                            Cliente objCliente = new Cliente("conexion");

                            bool okTransEstadoPremio = objCliente.UpdateEstadoPremioCliente(txt_nodocumento.Text);

                            if (!okTransEstadoPremio)
                            {
                                Auditoria objAuditoria = new Auditoria("conexion");
                                AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                                objAuditoriaInfo.FechaSistema = DateTime.Now;
                                objAuditoriaInfo.Proceso = "No se pudo actualizar estado de premio de bienvenida al cliente con pedido: " + this.IdPedido;
                                objAuditoriaInfo.Usuario = Session["Usuario"].ToString().Trim();

                                objAuditoria.Insert(objAuditoriaInfo);
                            }
                        }
                    }
                    //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


                    //???????????????????????????????????????????????????????????????????????????????????????????????????????
                    //Asigna un catalogo al pedido si no se ha enviado a la empresaria y es su primer pedido, segun la
                    //configuracion de catalagos siguientes a enviar.

                    bool ExistePedidoCampana = TienePedidoCampanaActual();

                    //Sino existe un pedido en la campaña se asiga el catalogo siguiente segun la configuracion.
                    if (!ExistePedidoCampana)
                    {
                        //se consultan los catalogos siguientes activos para enviar en el pedido.
                        List<PedidosDetalleClienteInfo> objPedidosDetalleCatalogosInfo = objPedidosDetalleCliente.ListCatalogosSiguientes(rcb_campana.SelectedItem.Value.Trim());

                        if (objPedidosDetalleCatalogosInfo != null && objPedidosDetalleCatalogosInfo.Count > 0)
                        {
                            foreach (PedidosDetalleClienteInfo CatalogoInfo in objPedidosDetalleCatalogosInfo)
                            {
                                string fecha = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                                CatalogoInfo.Id = this.IdPedido + "_CAT_" + fecha;
                                CatalogoInfo.Numero = this.IdPedido;
                                CatalogoInfo.NumeroPedidoPadre = this.IdPedido;
                                CatalogoInfo.IdDocumentoFuente = DateTime.Now.ToString();
                                CatalogoInfo.Catalogo = rcb_catalogo.SelectedValue;
                                CatalogoInfo.CatalogoReal = CatalogoInfo.Catalogo;
                                CatalogoInfo.IdCodigoCorto = "CAT00";
                                CatalogoInfo.PorcentajeDescuento = 0;
                                CatalogoInfo.CentroCostos = Session["IdZona"].ToString().Trim();

                                decSubTotal = decSubTotal + (CatalogoInfo.Valor * CatalogoInfo.Cantidad);
                                decIVA = decIVA + ((CatalogoInfo.Valor * CatalogoInfo.Cantidad) * (CatalogoInfo.TarifaIVA / 100));

                                decSubTotalPrecioCat = decSubTotalPrecioCat + (CatalogoInfo.ValorPrecioCatalogoUnitario * CatalogoInfo.Cantidad);
                                decIVAPrecioCat = decIVAPrecioCat + ((CatalogoInfo.ValorPrecioCatalogoUnitario * CatalogoInfo.Cantidad) * (CatalogoInfo.TarifaIVA / 100));

                                CatalogoInfo.PLUSustituto = 0;
                                CatalogoInfo.CodigoRapidoSustituto = "";

                                string IdPedidoDetallePremio = objPedidosDetalleCliente.Insert(CatalogoInfo);

                                if (IdPedidoDetallePremio == "" || IdPedidoDetallePremio == null)
                                {
                                    Auditoria objAuditoria = new Auditoria("conexion");
                                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                                    objAuditoriaInfo.Proceso = "No se pudo adicionar catalogo siguiente al pedido: " + this.IdPedido;
                                    objAuditoriaInfo.Usuario = Session["Usuario"].ToString().Trim();

                                    objAuditoria.Insert(objAuditoriaInfo);
                                }
                            }
                        }
                    }

                    //???????????????????????????????????????????????????????????????????????????????????????????????????????

                    AdicionarFleteYPremios = false;
                }

                //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
                //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]

                //se actualizan los valores del total del pedido
                bool okValoresPedido = objPedidosCliente.UpdateValorPedidoSVDN(IdPedido, decSubTotal, decIVA);

                //se actualizan los valores precio catalogo del total del pedido
                bool okValoresPedidoPrecioCat = objPedidosCliente.UpdateValorPrecioCatalogoPedidoSVDN(IdPedido, decSubTotalPrecioCat, decIVAPrecioCat);

                */

            }

            #endregion

            return objPedidosClienteInfo;

        }

        private PedidosDetalleClienteInfo AdicionarDetallePedido(int inPLU, decimal Cantidad, string CodigoRapidoSustituto, int PLUSustituto, string IdZona, string CodCiudadCliente)
        {
            PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

            KardexInfo objKardexInfo = new KardexInfo();
            Kardex objKardex = new Kardex("conexion");

            //Consultar si la Zona tiene IVA
            Zona objZona = new Zona("conexion");
            ZonaInfo objZonaInfo = new ZonaInfo();

            objKardexInfo = objKardex.ListxArticuloxPLU(inPLU);

            //Sino existe en detalle se agrega desde cero.
            if (objKardexInfo != null)
            {
                objPedidosDetalleClienteInfo.CodigoRapidoSustituto = CodigoRapidoSustituto;
                objPedidosDetalleClienteInfo.PLUSustituto = PLUSustituto;

                objPedidosDetalleClienteInfo.Cantidad = Cantidad;

                objPedidosDetalleClienteInfo.Imagen = objKardexInfo.Imagen;
                objPedidosDetalleClienteInfo.Referencia = objKardexInfo.Referencia;
                objPedidosDetalleClienteInfo.Descripcion = objKardexInfo.NombreProducto.Trim() + ", <b>COLOR: </b>" + objKardexInfo.DescripcionColor.Trim() + ", <b>TALLA: </b>" + objKardexInfo.CodigoTalla.Trim();
                //*objPedidosDetalleClienteInfo.Valor = objKardexInfo[0].PrecioUno;
                objPedidosDetalleClienteInfo.Valor = objKardexInfo.PrecioUno * objPedidosDetalleClienteInfo.Cantidad;
                objPedidosDetalleClienteInfo.Grupo = objKardexInfo.Grupo;

                //objPedidosDetalleClienteInfo.CodigoUbicacion = objKardexInfo.Posicion;
                objPedidosDetalleClienteInfo.CodigoUbicacion = "P000";
                objPedidosDetalleClienteInfo.PLU = Convert.ToDecimal(objKardexInfo.PLU);
                //objPedidosDetalleClienteInfo.CentroCostos = objKardexInfo.Posicion + "-" + objKardexInfo.PLU.ToString();
                objPedidosDetalleClienteInfo.CentroCostos = "P000" + "-" + objKardexInfo.PLU.ToString();

                objPedidosDetalleClienteInfo.Grupo = objKardexInfo.Grupo;
                objPedidosDetalleClienteInfo.ConceptoContable = objKardexInfo.ConceptoContable;

                //MRG: Cometar este y hacer el codigo de abajo q sigues despues de esta linea.
                objZonaInfo = objZona.ListxIdZona(IdZona);


                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                ArtExcentosxCiudad objArtExcentosxCiudad = new ArtExcentosxCiudad("conexion");
                ArtExcentosxCiudadInfo objArtExcentosxCiudadInfo = new ArtExcentosxCiudadInfo();
                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                decimal iva_subtotal = 0;

                decimal iva_subtotalPrecioCatalogo = 0;

                decimal iva_preciocatalogo_articulo = 0;

                if (objZonaInfo != null)
                {
                    //Si excluido es 1 es por que no hay iva para toda la zona.
                    if (objZonaInfo.Excluido != 1)
                    {
                        //Si el iva es 0 no se debe cambiar el subtotal.
                        if (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) != 0)
                        {
                            //Si es flete debe traer el valor de la tabla zonas.
                            if (objKardexInfo.PLU == 3357) // 3357 PLU de flete nivi colombia. 
                            {
                                //decimal iva_subtotal_cal = Math.Round(((objZonaInfo.ValorFlete * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100))));

                                decimal iva_subtotal_cal = 0;

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //Se valida si el articulo se encuentra excento de iva en la ciudad del cliente.
                                objArtExcentosxCiudadInfo = objArtExcentosxCiudad.ListxCiudadxPlu(CodCiudadCliente, objKardexInfo.PLU);

                                //Si se encuentra exento el iva debe ser 0.
                                if (objArtExcentosxCiudadInfo != null)
                                {
                                    iva_subtotal_cal = 0;
                                }
                                else
                                {
                                    iva_subtotal_cal = ((objZonaInfo.ValorFlete * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100)));
                                }

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                                //*iva_subtotal = IVA + iva_subtotal_cal;

                                //*lbl_iva.Text = String.Format("{0:C}", iva_subtotal);
                                //*lbl_total.Text = String.Format("{0:C}", SubTotal + iva_subtotal);

                                //*IVA = iva_subtotal;

                                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                                //Precio Catalogo

                                decimal iva_subtotal_calPrecioCat = 0;

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //Se valida si el articulo se encuentra excento de iva en la ciudad del cliente.

                                //Si se encuentra exento el iva debe ser 0.
                                if (objArtExcentosxCiudadInfo != null)
                                {
                                    iva_subtotal_calPrecioCat = 0;
                                }
                                else
                                {
                                    iva_subtotal_calPrecioCat = ((objZonaInfo.ValorFlete) * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100));
                                }

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                //*iva_subtotalPrecioCatalogo = IVAPrecioCat + iva_subtotal_calPrecioCat;
                                iva_preciocatalogo_articulo = iva_subtotal_calPrecioCat;
                                //*IVAPrecioCat = iva_subtotalPrecioCatalogo;
                                //*lbl_totalcatalogo.Text = String.Format("{0:C}", SubTotalPrecioCat + iva_subtotalPrecioCatalogo);
                                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            }
                            else
                            {
                                //decimal iva_subtotal_cal = Math.Round(((objKardexInfo.PrecioUno * objPedidosDetalleClienteInfo.Cantidad) * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100)));

                                decimal iva_subtotal_cal = 0;

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //Se valida si el articulo se encuentra excento de iva en la ciudad del cliente.
                                objArtExcentosxCiudadInfo = objArtExcentosxCiudad.ListxCiudadxPlu(CodCiudadCliente, objKardexInfo.PLU);

                                //Si se encuentra exento el iva debe ser 0.
                                if (objArtExcentosxCiudadInfo != null)
                                {
                                    iva_subtotal_cal = 0;
                                }
                                else
                                {
                                    iva_subtotal_cal = ((objKardexInfo.PrecioUno * objPedidosDetalleClienteInfo.Cantidad) * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100));
                                }

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                                //*iva_subtotal = IVA + iva_subtotal_cal;

                                //*lbl_iva.Text = String.Format("{0:C}", iva_subtotal);
                                //*lbl_total.Text = String.Format("{0:C}", SubTotal + iva_subtotal);

                                //*IVA = iva_subtotal;

                                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                                //Precio Catalogo

                                decimal iva_subtotal_calPrecioCat = 0;

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //Se valida si el articulo se encuentra excento de iva en la ciudad del cliente.

                                //Si se encuentra exento el iva debe ser 0.
                                if (objArtExcentosxCiudadInfo != null)
                                {
                                    iva_subtotal_calPrecioCat = 0;
                                }
                                else
                                {
                                    iva_subtotal_calPrecioCat = ((objKardexInfo.PrecioBaseVenta * objPedidosDetalleClienteInfo.Cantidad) * (ConsultarIVA(objPedidosDetalleClienteInfo.Grupo) / 100));
                                }

                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                                //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()


                                //*iva_subtotalPrecioCatalogo = IVAPrecioCat + iva_subtotal_calPrecioCat;
                                iva_preciocatalogo_articulo = iva_subtotal_calPrecioCat;
                                //*IVAPrecioCat = iva_subtotalPrecioCatalogo;
                                //*lbl_totalcatalogo.Text = String.Format("{0:C}", SubTotalPrecioCat + iva_subtotalPrecioCatalogo);
                                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            }
                        }
                        else
                        {
                            //*iva_subtotal = IVA;

                            //*lbl_iva.Text = String.Format("{0:C}", iva_subtotal);
                            //*lbl_total.Text = String.Format("{0:C}", SubTotal + iva_subtotal);

                            //*IVA = iva_subtotal;

                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            //Precio Catalogo
                            //*iva_subtotalPrecioCatalogo = IVAPrecioCat;
                            //*IVAPrecioCat = iva_subtotalPrecioCatalogo;
                            //*lbl_totalcatalogo.Text = String.Format("{0:C}", SubTotalPrecioCat + iva_subtotalPrecioCatalogo);
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        }
                    }


                }
                else
                {
                    //---------------------------------------------------------------------------------------------------------------
                    //Mensaje de error
                    /*LiteralControl ltr = new LiteralControl();
                    ltr.Text = "<style type=\"text/css\" rel=\"stylesheet\">" + @".radalert { background-image: url(../images/error.png) !important; } </style> ";
                    this.Page.Header.Controls.Add(ltr);

                    string radalertscript = "<script language='javascript'>function f(){callAlertGenerico('No se puede obtener informacion de IVA de la zona. Por favor comuniquese con Niviglobal.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
                    */
                }

                //*Total = SubTotal + iva_subtotal;

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //Precio Catalogo
                //* TotalPrecioCat = SubTotalPrecioCat + iva_subtotalPrecioCatalogo;
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                //*rcb_catalogo.Enabled = false;
                //*txt_nodocumento.ReadOnly = true;

                //Guarda los valores de precio catalogo
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = objKardexInfo.PrecioBaseVenta * objPedidosDetalleClienteInfo.Cantidad;
                objPedidosDetalleClienteInfo.IVAPrecioCatalogo = iva_preciocatalogo_articulo;

                objPedidosDetalleClienteInfo.UnidadNegocio = objKardexInfo.UnidadNegocio;
                objPedidosDetalleClienteInfo.GrupoProducto = objKardexInfo.GrupoProducto;
            }

            return objPedidosDetalleClienteInfo;
        }

        private decimal ConsultarIVA(string grupo)
        {
            GruposInfo objGruposInfo = new GruposInfo();
            Grupos objGrupos = new Grupos("conexion");

            objGruposInfo = objGrupos.ListxId(grupo);

            TarifaIVAInfo objTarifaIVAInfo = new TarifaIVAInfo();
            TarifaIVA objTarifaIVA = new TarifaIVA("conexion");
            objTarifaIVAInfo = objTarifaIVA.ListxId(objGruposInfo.IdTarifaIVA);

            return objTarifaIVAInfo.Porcentaje;
        }

        [HttpGet]
        [HttpPost]
        public List<PedidosClienteInfo> PedidosList(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {

            List<PedidosClienteInfo> lista = new List<PedidosClienteInfo>(); ;
            PedidosCliente module = new PedidosCliente("conexion");

            //--------------------------------------------------------------------------------------------------------
            CampanaInfo objCampanaInfo = new CampanaInfo();
            Campana objCampana = new Campana("conexion");

            if (ObjPedidosClienteInfoRequest.Campana != null && ObjPedidosClienteInfoRequest.Campana != "")
            {
                //objCampanaInfo = objCampana.ListxCampana(ObjPedidosClienteInfoRequest.Campana);
                objCampanaInfo = objCampana.ListxGetDate();
            }
            else
            {
                objCampanaInfo = objCampana.ListxGetDate();
            }
            //--------------------------------------------------------------------------------------------------------
            lista = module.ListxGerenteZona(ObjPedidosClienteInfoRequest.IdVendedor, objCampanaInfo.Campana);
            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                lista = module.ListxGerenteZona(Session["IdVendedor"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                lista = module.ListxGerenteRegional(Session["CedulaRegional"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                lista = module.ListPedidosxLider(Session["IdLider"].ToString(), objCampanaInfo.Campana);
            }
            //INICIO GAVL ASISTENTES
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Asistentes))
            {
                lista = module.ListPedidosxAsistente(Session["Asistente"].ToString(), objCampanaInfo.Campana);
            }
            //FIN GAVL 
            */

            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<PedidosClienteInfo>();
            }


            return lista;


        }


        [HttpGet]
        [HttpPost]
        public List<PedidosClienteInfo> PedidosListEmpresaria(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {

            List<PedidosClienteInfo> lista = new List<PedidosClienteInfo>(); ;
            PedidosCliente module = new PedidosCliente("conexion");

            //--------------------------------------------------------------------------------------------------------
            CampanaInfo objCampanaInfo = new CampanaInfo();
            Campana objCampana = new Campana("conexion");

            if (ObjPedidosClienteInfoRequest.Campana != null && ObjPedidosClienteInfoRequest.Campana != "")
            {
                //objCampanaInfo = objCampana.ListxCampana(ObjPedidosClienteInfoRequest.Campana);
                objCampanaInfo = objCampana.ListxGetDate();
            }
            else
            {
                objCampanaInfo = objCampana.ListxGetDate();
            }
            //--------------------------------------------------------------------------------------------------------
            lista = module.ListxEmpresaria(ObjPedidosClienteInfoRequest.Nit, objCampanaInfo.Campana);
            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                lista = module.ListxGerenteZona(Session["IdVendedor"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                lista = module.ListxGerenteRegional(Session["CedulaRegional"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                lista = module.ListPedidosxLider(Session["IdLider"].ToString(), objCampanaInfo.Campana);
            }
            //INICIO GAVL ASISTENTES
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Asistentes))
            {
                lista = module.ListPedidosxAsistente(Session["Asistente"].ToString(), objCampanaInfo.Campana);
            }
            //FIN GAVL 
            */

            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<PedidosClienteInfo>();
            }


            return lista;


        }

        [HttpGet]
        [HttpPost]
        public List<PedidosClienteInfo> PedidosListLider(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {

            List<PedidosClienteInfo> lista = new List<PedidosClienteInfo>(); ;
            PedidosCliente module = new PedidosCliente("conexion");

            //--------------------------------------------------------------------------------------------------------
            CampanaInfo objCampanaInfo = new CampanaInfo();
            Campana objCampana = new Campana("conexion");

            if (ObjPedidosClienteInfoRequest.Campana != null && ObjPedidosClienteInfoRequest.Campana != "")
            {
                //objCampanaInfo = objCampana.ListxCampana(ObjPedidosClienteInfoRequest.Campana);
                objCampanaInfo = objCampana.ListxGetDate();
            }
            else
            {
                objCampanaInfo = objCampana.ListxGetDate();
            }
            //--------------------------------------------------------------------------------------------------------
            lista = module.ListPedidosxLider(ObjPedidosClienteInfoRequest.IdLider, objCampanaInfo.Campana);
            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                lista = module.ListxGerenteZona(Session["IdVendedor"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                lista = module.ListxGerenteRegional(Session["CedulaRegional"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                lista = module.ListPedidosxLider(Session["IdLider"].ToString(), objCampanaInfo.Campana);
            }
            //INICIO GAVL ASISTENTES
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Asistentes))
            {
                lista = module.ListPedidosxAsistente(Session["Asistente"].ToString(), objCampanaInfo.Campana);
            }
            //FIN GAVL 
            */

            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<PedidosClienteInfo>();
            }


            return lista;


        }

        [HttpGet]
        [HttpPost]
        public List<PedidosClienteInfo> ListxGerenteZonaFacturados(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {

            List<PedidosClienteInfo> lista = new List<PedidosClienteInfo>(); ;
            PedidosCliente module = new PedidosCliente("conexion");

            //--------------------------------------------------------------------------------------------------------
            CampanaInfo objCampanaInfo = new CampanaInfo();
            Campana objCampana = new Campana("conexion");

            if (ObjPedidosClienteInfoRequest.Campana != null && ObjPedidosClienteInfoRequest.Campana != "")
            {
                objCampanaInfo = objCampana.ListxCampana(ObjPedidosClienteInfoRequest.Campana);
            }
            else
            {
                objCampanaInfo = objCampana.ListxGetDate();
            }
            //--------------------------------------------------------------------------------------------------------
            lista = module.ListxGerenteZonaFacturados(ObjPedidosClienteInfoRequest.IdVendedor, objCampanaInfo.Campana);
            /*if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesZona))
            {
                lista = module.ListxGerenteZona(Session["IdVendedor"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.GerentesRegionales))
            {
                lista = module.ListxGerenteRegional(Session["CedulaRegional"].ToString(), objCampanaInfo.Campana);
            }
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Lider))
            {
                lista = module.ListPedidosxLider(Session["IdLider"].ToString(), objCampanaInfo.Campana);
            }
            //INICIO GAVL ASISTENTES
            else if (Session["IdGrupo"].ToString() == Convert.ToString((int)GruposUsuariosEnum.Asistentes))
            {
                lista = module.ListPedidosxAsistente(Session["Asistente"].ToString(), objCampanaInfo.Campana);
            }
            //FIN GAVL 
            */

            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<PedidosClienteInfo>();
            }


            return lista;


        }


        [HttpGet]
        [HttpPost]
        public PedidosClienteInfo ValidarPedidoReserva(List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoRequest)
        {
            PedidosClienteInfo objPedidosClienteInfo = new PedidosClienteInfo();
            string NumeroDocumento = "";
            string Catalogo = "";
            string NumeroPedido = "";
            string TipoEnvio = "";
            int PuntosUsar = 0;
            string strUsuario = "";


            if (ObjPedidosDetalleClienteInfoRequest.Count > 0)
            {
                objPedidosClienteInfo = ObjPedidosDetalleClienteInfoRequest[0].PedidosClienteInfo;
                NumeroDocumento = objPedidosClienteInfo.Nit;
                Catalogo = objPedidosClienteInfo.Codigo;
                NumeroPedido = objPedidosClienteInfo.Numero;
                TipoEnvio = objPedidosClienteInfo.TipoEnvio.ToString();
                PuntosUsar = objPedidosClienteInfo.PuntosUsar;
                strUsuario = objPedidosClienteInfo.ClaveUsuario;
            }

            if (this.ValidarPedidoSinFacturar(NumeroDocumento, Catalogo, NumeroPedido, false))
            {
                string str = "";
                str = new PuntosBo("conexion").getPedidoActivo(NumeroDocumento.Trim());
                //base.Response.Redirect("ErrorReserva.aspx?IdPedido=" + str + "&Nit=" + this.txt_nodocumento.Text);
            }
            else
            {

                //PedidosClienteInfo objGuardarEncabezadoPedidoOk = GuardarEncabezadoPedido(objPedidosClienteInfo);
                PedidosClienteInfo objGuardarEncabezadoPedidoOk = objPedidosClienteInfo;

                if (objGuardarEncabezadoPedidoOk != null)
                {
                    if (objGuardarEncabezadoPedidoOk.okTransEncabezadoPedido)
                    {
                        //PedidosClienteInfo objGuardarDetallePedidoOk = GuardarDetallePedido(ObjPedidosDetalleClienteInfoRequest);
                        PedidosClienteInfo objGuardarDetallePedidoOk = objPedidosClienteInfo;

                        if (objGuardarDetallePedidoOk != null)
                        {

                            if (objGuardarDetallePedidoOk.okTransDetallePedido)
                            {
                                bool recogertienda = false;
                                if (objPedidosClienteInfo.TipoEnvio == 1)
                                {
                                    recogertienda = true;
                                }

                                if (GuardarPedidoReservaEnLinea(NumeroPedido, "370", recogertienda, objPedidosClienteInfo.Nit, PuntosUsar, objPedidosClienteInfo.TotalPuntosPedido, objPedidosClienteInfo.Zona, objPedidosClienteInfo.Usuario, TipoEnvio, ObjPedidosDetalleClienteInfoRequest, strUsuario))
                                {
                                    EnviarCorreo(objPedidosClienteInfo.Nit, objPedidosClienteInfo.IdVendedor, objPedidosClienteInfo.Numero, objPedidosClienteInfo.TotalPrecioCatalogo.ToString());
                                    //this.RealizoReserva = true;
                                    //base.Response.Redirect("ValidarPedidoEnviadoEmpresaria.aspx?IdPedido=" + this.IdPedido + "&Nit=" + this.txt_nodocumento.Text);
                                    //this.RadToolbar1.Items[0].Enabled = false;
                                    //this.RadToolbar1.Items[1].Enabled = false;
                                    //this.BtnEnviar.Enabled = false;
                                    //this.BtnGuardarBorrador.Enabled = false;
                                }
                                else
                                {
                                    //this.RadWindowManager1.RadAlert("<font color=red><b>Su reserva NO pudo ser almacenada, por favor comuniquese con el area de CCN de Niviglobal y verifique su pedido para evitar inconvenientes de envio.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                                    //this.RadToolbar1.Items[0].Enabled = false;
                                    //this.RadToolbar1.Items[1].Enabled = false;
                                    //this.BtnEnviar.Enabled = false;
                                    //this.BtnGuardarBorrador.Enabled = false;
                                    //this.RealizoReserva = true;
                                }
                            }

                        }

                    }
                }
            }

            return objPedidosClienteInfo;
        }

        public bool GuardarPedidoReservaEnLinea(string NumeroPedido, string bodegaEmpresaria, bool recogePedidoTienda, string NumeroDocumento, int PuntosUsar, decimal totalPedidoPuntosIn, string IdZona, string NombreUsuario, string TipoEnvio, List<PedidosDetalleClienteInfo> ObjPedidosDetalleClienteInfoRequest, string Usuario)
        {
            bool okTrans = false;
            try
            {

                int cobraTipoEnviorFlete = 1;

                ReservaEnLineaGlod glod = new ReservaEnLineaGlod("conexion");
                PedidosCliente cliente = new PedidosCliente("conexion");
                PuntosSaved objPuntosSaved = new PuntosSaved("conexion");
                PuntosSavedInfo objPuntosSavedInfo = new PuntosSavedInfo();

                //TipoEnvio = 4, no cobrar flete
                if (TipoEnvio == "4")
                {
                    cobraTipoEnviorFlete = 0;
                }

                if (glod.RealizarReservaEnLineaDifBodega(NumeroPedido, bodegaEmpresaria, cobraTipoEnviorFlete) != "")
                {
                    okTrans = true;

                    decimal CantidadAprox = 0;

                    foreach (PedidosDetalleClienteInfo item in ObjPedidosDetalleClienteInfoRequest)
                    {
                        CantidadAprox = CantidadAprox + ((item.PuntosGanados - (item.PuntosGanados * (item.PorcentajeDescuentoPuntos / 100))));
                    }

                    objPuntosSavedInfo.Cantidad = (int)Math.Floor(CantidadAprox);

                    //Inserta el detalle de puntos por concepto de reserva en linea. Si se cumple con el pedido minimo.
                    if (objPuntosSavedInfo.Cantidad > 0)
                    {
                        objPuntosSavedInfo.NumeroPedido = NumeroPedido;
                        objPuntosSavedInfo.Nit = NumeroDocumento;
                        objPuntosSavedInfo.Tipo = "+";
                        objPuntosSavedInfo.Cantidad = objPuntosSavedInfo.Cantidad;
                        objPuntosSavedInfo.Movimiento = ((int)PuntosConceptoEnum.ReservaLinea).ToString();
                        objPuntosSavedInfo.Procesado = 0;
                        objPuntosSavedInfo.Usuario = Usuario;
                        okTrans = objPuntosSaved.InsertDetallePuntos(objPuntosSavedInfo);

                        //Inserta puntos por conceptos adicionales
                        objPuntosSavedInfo.NumeroPedido = NumeroPedido;
                        objPuntosSavedInfo.Nit = NumeroDocumento;
                        okTrans = objPuntosSaved.InsertDetallePuntosAdicionales(objPuntosSavedInfo);
                    }

                    //Inserta el detalle de puntos por concepto de puntos compra.
                    if (PuntosUsar > 0)
                    {
                        objPuntosSavedInfo.NumeroPedido = NumeroPedido;
                        objPuntosSavedInfo.Nit = NumeroDocumento;
                        objPuntosSavedInfo.Tipo = "-";
                        objPuntosSavedInfo.Cantidad = PuntosUsar;
                        objPuntosSavedInfo.Movimiento = ((int)PuntosConceptoEnum.GastoCompra).ToString();
                        objPuntosSavedInfo.Procesado = 1;
                        objPuntosSavedInfo.Usuario = Usuario;
                        okTrans = objPuntosSaved.InsertDetallePuntos(objPuntosSavedInfo);
                    }


                }


                #region  "VERIFICA DESMANTELADORA"


                bool Desmanteladora;
                bool result;

                ParametrosInfo ObjParametrosInfo = new ParametrosInfo();
                Parametros ObjParametros = new Parametros("conexion");

                ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.BloquearPedidosDesmantelados);


                if (ObjParametrosInfo.Valor == "SI")
                {
                    Cliente module = new Cliente("conexion");


                    Desmanteladora = module.BuscaDemanteladora(NumeroDocumento, IdZona);

                    if (Desmanteladora == true)
                    {
                        //Se Actualiza El estado del pedido debido a que la empresaria tiene un estado de desmanteladora
                        result = cliente.UpdateEstadoDesmanteladoPedido(NumeroPedido, NumeroDocumento, IdZona, NombreUsuario);
                        if (result == false)
                        {
                            //RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('No se pudo actualizar el estado del pedido " + IdPedido + " a desmateladora, Porfavor contacte a soporte de Informatica Niviglobal.');");
                        }

                    }

                }
                #endregion



            }
            catch (Exception)
            {
                return false;
            }

            return okTrans;
        }

        /// <summary>
        /// Valida si existe un pedido de una empresaria para obligar a seleccionarlo por la lista de pedidos.
        /// </summary>
        /// <returns></returns>
        private bool ValidarPedidoSinFacturar(string NumeroDocumento, string Catalogo, string NumeroPedido, bool ZonaMultiPedidos)
        {
            bool ExistePedido = false;
            string Campana = "";

            List<PedidosClienteInfo> objPedidosClienteInfo = new List<PedidosClienteInfo>();
            Business.PedidosCliente objPedidosCliente = new Business.PedidosCliente("conexion");

            CampanaInfo objCampanaInfo = new CampanaInfo();
            Business.Campana objCampana = new Business.Campana("conexion");

            if (Campana != "")
            {
                objCampanaInfo = objCampana.ListxCampana(Campana);
            }
            else
            {
                objCampanaInfo = objCampana.ListxGetDate();
            }

            //Validar si existe un pedido sin facturar de esa empresaria.
            objPedidosClienteInfo = objPedidosCliente.ListxPedidoSinFacturarxParaReservar(NumeroDocumento, objCampanaInfo.Campana, Catalogo, NumeroPedido);

            //Si existe el pedido se asigna el id del pedido.
            if (objPedidosClienteInfo != null && objPedidosClienteInfo.Count > 0)
            {
                //1212121212121212121212121212121212121212121212121212121212121212121212121212121212121212121212
                //Valida si la zona no es multipedidos se debe mostrar mensaje.
                if (ZonaMultiPedidos == false)
                {
                    ////////// PREVENTA JUTA
                    if (objCampanaInfo != null)
                    {
                        PedidosClienteInfo objPedidosClienteInfo1 = new PedidosClienteInfo();
                        objPedidosClienteInfo1 = objPedidosCliente.ListxPedidoPreventa(NumeroDocumento, objCampanaInfo.Campana);
                        if (objPedidosClienteInfo1 != null)
                        {
                            if (objPedidosClienteInfo1.Numero.Trim() != "")
                            {
                                //RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + objPedidosClienteInfo1.Numero + "</b></font> del <b>" + rcb_catalogo.Text.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                                ExistePedido = true;
                            }
                            else
                            {
                                ExistePedido = false;
                            }
                        }
                        else
                        {
                            ExistePedido = false;
                        }
                        //---------------------------------------------------------------------------------------------------------------
                    }
                    else
                    {
                        //Mesaje de Advertencia.              
                        //RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + objPedidosClienteInfo[0].Numero + "</b></font> del <b>" + Catalogo.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");

                        ExistePedido = true;
                    }


                    /// CODIGO ANTERIOR
                    ///  //Mesaje de Advertencia.              
                    ///RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + objPedidosClienteInfo[0].Numero + "</b></font> del <b>" + rcb_catalogo.Text.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    ///ExistePedido = true;
                }
                else
                {
                    if (objCampanaInfo != null)
                    {
                        PedidosClienteInfo objPedidosClienteInfo1 = new PedidosClienteInfo();
                        objPedidosClienteInfo1 = objPedidosCliente.ListxPedidoPreventa(NumeroDocumento, objCampanaInfo.Campana);
                        if (objPedidosClienteInfo1 != null)
                        {
                            if (objPedidosClienteInfo1.Numero.Trim() != "")
                            {
                                //RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + objPedidosClienteInfo1.Numero + "</b></font> del <b>" + rcb_catalogo.Text.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                                ExistePedido = true;
                            }
                            else
                            {
                                ExistePedido = false;
                            }
                        }
                        else
                        {
                            ExistePedido = false;
                        }
                        //---------------------------------------------------------------------------------------------------------------
                    }
                    else
                    {
                        ExistePedido = false;
                    }
                }
                //1212121212121212121212121212121212121212121212121212121212121212121212121212121212121212121212
            }
            else
            {
                PedidosClienteInfo info2 = new PedidosClienteInfo();
                info2 = objPedidosCliente.ListxPedidoPreventa(NumeroDocumento, objCampanaInfo.Campana);
                if (ReferenceEquals(info2, null))
                {
                    ExistePedido = false;
                }
                else if (info2.Numero.Trim() == "")
                {
                    ExistePedido = false;
                }
                else
                {
                    //this.RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + info2.Numero + "</b></font> del <b>" + this.rcb_catalogo.Text.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    ExistePedido = true;
                }
            }

            return ExistePedido;
        }

        /// <summary>
        /// Envia el correo electronico a la empresaria y a la gerente de zona.
        /// </summary>
        private void EnviarCorreo(string NumeroDocumento, string IdVendedor, string NumeroPedido, string TotalPedido)
        {
            //INICIO GAVL 16/04/2014 PARAMETRO PARA ENVIA INFORMACION DEL PEDIDO A EMPRESARIA
            ParametrosInfo ObjParametrosInfo = new ParametrosInfo();
            Business.Parametros ObjParametros = new Business.Parametros("conexion");
            //FIN GAVL 

            ////si esta en alguna zona de ximena martinez envie correo
            //if (Session["IdZona"].ToString() == "1101" || Session["IdZona"].ToString() == "1102" || Session["IdZona"].ToString() == "1103" || Session["IdZona"].ToString() == "1201" || Session["IdZona"].ToString() == "1202" || Session["IdZona"].ToString() == "1203" || Session["IdZona"].ToString() == "1204" || Session["IdZona"].ToString() == "1301" || Session["IdZona"].ToString() == "1302" || Session["IdZona"].ToString() == "1303" || Session["IdZona"].ToString() == "1304" || Session["IdZona"].ToString() == "1401" || Session["IdZona"].ToString() == "1402" || Session["IdZona"].ToString() == "1403" || Session["IdZona"].ToString() == "1404" || Session["IdZona"].ToString() == "1405" || Session["IdZona"].ToString() == "1406")
            //{
            //--------------------------------------------------------------------------------------------------------------
            //Enviar Correo electronico
            bool vsemailOk = false;

            Business.Cliente ObjCliente = new Business.Cliente("conexion");
            ClienteInfo ObjClienteInfo = ObjCliente.ListxNIT(NumeroDocumento);

            string NombreEmpresaria = "";
            string EmailEmpresaria = "";

            if (ObjClienteInfo != null)
            {
                NombreEmpresaria = ObjClienteInfo.Nombre1 + " " + ObjClienteInfo.Nombre2 + " " + ObjClienteInfo.Apellido1 + " " + ObjClienteInfo.Apellido2;
                //EmailEmpresaria = ObjClienteInfo.Email;
                //INICIO GAVL 16/04/2014 PARAMETRO PARA ENVIA INFORMACIÓN DEL PEDIDO A EMPRESARIA
                ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.EnviaCorroEmpresaria);

                if (ObjParametrosInfo.Valor == "SI")
                {
                    if (ValidaCorreo(ObjClienteInfo.Email.Trim()) == true)
                    {
                        EmailEmpresaria = ObjClienteInfo.Email;

                    }

                }

                //FIN GAVL
            }

            string EmailGerente = "";

            if (IdVendedor != null && IdVendedor != "")
            {
                Business.Vendedor ObjVendedor = new Business.Vendedor("conexion");
                VendedorInfo ObjVendedorInfo = ObjVendedor.ListxIdVendedor(IdVendedor);

                //EmailGerente = ObjVendedorInfo.EmailNivi;
                EmailGerente = "ramosgilmauricio@gmail.com";//TODO: comentar esta linea cuando se ponga en produccion.
            }

            string EmailsPara = "";

            if (EmailGerente != "" && EmailEmpresaria != "")
            {
                EmailsPara = EmailGerente + "," + EmailEmpresaria;
            }
            else if (EmailGerente == "" && EmailEmpresaria != "")
            {
                EmailsPara = EmailEmpresaria;
            }
            else if (EmailGerente != "" && EmailEmpresaria == "")
            {
                EmailsPara = EmailGerente;
            }

            EmailsPara = "ramosgilmauricio@gmail.com"; //TODO: comentar esta linea cuando se ponga en produccion.

            Mail objSmtpMail = new Mail("conexion");
            SmtpMailInfo objSmtpMailInfo = new SmtpMailInfo();
            //Configurar parametros para enviar correo.
            objSmtpMailInfo = objSmtpMail.ConfigurarParametros((int)TipoMailEnum.Pedido, EmailsPara, "", "", NombreEmpresaria, NumeroPedido, TotalPedido);
            //Enviar E-Mail
            vsemailOk = objSmtpMail.SendMail(objSmtpMailInfo);

            //SE HABILITRA SI SE REQUEIRE MOSTRAR EL ERROR DE FALLO DE ENVIO DE CORREO.
            //if (!vsemailOk)
            //{
            //    //---------------------------------------------------------------------------------------------------------------
            //    //Mensaje de error
            //    LiteralControl ltr = new LiteralControl();
            //    ltr.Text = "<style type=\"text/css\" rel=\"stylesheet\">" + @".radalert { background-image: url(../images/error.png) !important; } </style> ";
            //    this.Page.Header.Controls.Add(ltr);

            //    RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('No se pudo enviar E-Mail con información de pago, por favor intente guardar de nuevo el pedido.');");
            //}
            //--------------------------------------------------------------------------------------------------------------
            //}

        }

        /// <summary>
        /// GAVL Validar  Correo
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public bool ValidaCorreo(string Correo)
        {
            bool oktrans = false;

            Regex r = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (r.IsMatch(Correo))
            {
                oktrans = true;
            }

            return oktrans;

        }


        //----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------
        //Metodo de Flete      

        private PedidosDetalleClienteInfo CrearFleteDetallePedido(string IdPedido, decimal ValorFlete, string IdZona, int Excluido, string CodCiudad, decimal PorcentajeIVA, decimal ValorFleteFull, bool TipoFlete, string LocalizacionFlete, bool PagarFletePuntos)
        {

            PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();

            objPedidosDetalleClienteInfo.Numero = IdPedido;
            //objPedidosDetalleClienteInfo.Id = IdPedido;
            objPedidosDetalleClienteInfo.Referencia = "FT0001";
            objPedidosDetalleClienteInfo.Descripcion = "MANEJO LOGISTICO - " + LocalizacionFlete + ": " + CodCiudad;


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
            objPedidosDetalleClienteInfo.PLU = 3357; // PLU en colombia de costo logistico FL000001                          
            objPedidosDetalleClienteInfo.NumeroEnvio = 0;
            objPedidosDetalleClienteInfo.ConceptoContable = "005";
            objPedidosDetalleClienteInfo.CentroCostos = IdZona;
            objPedidosDetalleClienteInfo.Grupo = "FT0001"; // Grupo del flete.
            objPedidosDetalleClienteInfo.Imagen = "Flete Asignado desde SAVED. Fecha: " + DateTime.Now.ToString();
            objPedidosDetalleClienteInfo.CantidadNivelServicio = 0;


            //si el tipo flete es true es por que es flete normal.
            if (TipoFlete)
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFlete;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFlete;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFlete;
                objPedidosDetalleClienteInfo.Valor = ValorFlete;
            }
            else
            {
                objPedidosDetalleClienteInfo.ValorPrecioCatalogo = ValorFleteFull;
                objPedidosDetalleClienteInfo.ValorUnitario = ValorFleteFull;
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = ValorFleteFull;
                objPedidosDetalleClienteInfo.Valor = ValorFleteFull;
            }

            objPedidosDetalleClienteInfo.IVAPrecioCatalogo = objPedidosDetalleClienteInfo.TarifaIVA;
            objPedidosDetalleClienteInfo.Catalogo = "N/A";
            objPedidosDetalleClienteInfo.NumeroPedidoPadre = IdPedido;

            objPedidosDetalleClienteInfo.IdCodigoCorto = "FL00";
            objPedidosDetalleClienteInfo.UnidadNegocio = "01";

            if (PagarFletePuntos)
            {
                objPedidosDetalleClienteInfo.PorcentajeDescuento = 100; // Solo 100% para flete.
                objPedidosDetalleClienteInfo.PorcentajeDescuentoPuntos = 100; // Solo 100% para flete.
                objPedidosDetalleClienteInfo.Valor = 0;
            }
            else
            {
                objPedidosDetalleClienteInfo.PorcentajeDescuento = 0;
                objPedidosDetalleClienteInfo.PorcentajeDescuentoPuntos = 0;
            }

            return objPedidosDetalleClienteInfo;
        }

        private PedidosDetalleClienteInfo AdicionarFletePedidoConCiudad(bool TipoFlete, string NumeroPedido, string CodCiudadDespacho, string IdZona, bool ExcentoIVA, string Usuario, string CatalogoReal, bool PagarFletePuntos)
        {
            Ciudad ObjCiudad = new Ciudad("conexion");
            CiudadInfo ObjCiudadInfo = new CiudadInfo();

            ObjCiudadInfo = ObjCiudad.ListCiudadxId(CodCiudadDespacho);

            if (ObjCiudadInfo != null)
            {
                //Crear el detalle del flete para el pedido.
                PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = CrearFleteDetallePedido(NumeroPedido, ObjCiudadInfo.ValorFlete, IdZona, ObjCiudadInfo.ExcluidoIVA, CodCiudadDespacho, ObjCiudadInfo.IVA, ObjCiudadInfo.ValorFleteFull, TipoFlete, "CIUDAD", PagarFletePuntos);

                PLUInfo objPLU = new PLUInfo();

                //objPLU.PLU = Convert.ToInt32(rcb_codigorapido.SelectedItem.Value);
                objPLU.PLU = Convert.ToInt32(objPedidosDetalleClienteInfo.PLU);
                objPLU.CodigoRapido = "FL00";
                objPLU.FechaCreacion = DateTime.Now;
                objPLU.CatalogoReal = CatalogoReal;
                objPedidosDetalleClienteInfo.CatalogoReal = CatalogoReal;

                if (ExcentoIVA == true)
                {
                    objPedidosDetalleClienteInfo.TarifaIVA = 0;
                }

                objPLU.NombreProducto = objPedidosDetalleClienteInfo.Descripcion;
                objPLU.PrecioConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + (Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * objPedidosDetalleClienteInfo.TarifaIVA / 100);
                objPLU.PrecioTotalConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + (Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * objPedidosDetalleClienteInfo.TarifaIVA / 100);
                objPLU.Cantidad = 1;

                objPLU.IVAPrecioCatalogo = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor);
                objPLU.PrecioCatalogoSinIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor);

                objPLU.PrecioCatalogoTotalConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * (Convert.ToDecimal(objPedidosDetalleClienteInfo.TarifaIVA) / 100);

                return objPedidosDetalleClienteInfo;
            }
            else
            {
                AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();
                Auditoria objAuditoria = new Auditoria("conexion");

                objAuditoriaInfo.Proceso = "No se creo el flete para el Pedido: " + NumeroPedido + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente.";
                objAuditoriaInfo.Usuario = Usuario.Trim();
                objAuditoriaInfo.FechaSistema = DateTime.Now;
                objAuditoria.Insert(objAuditoriaInfo);
                //Mesaje de Advertencia.              
                //RadWindowManager1.RadAlert("No se puede crear flete para esta ciudad ya que no se encuentra configurado.<br />Por favor comuniquese con Inteligencia Comercial - IDN Niviglobal.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                return null;
            }
        }

        private PedidosDetalleClienteInfo AdicionarFletePedidoConZona(bool TipoFlete, string NumeroPedido, string CodCiudadCliente, string IdZona, bool ExcentoIVA, string Usuario, string CatalogoReal, bool PagarFletePuntos)
        {
            ParametrosInfo ObjParametrosInfo = new ParametrosInfo();
            Parametros ObjParametros = new Parametros("conexion");
            ZonaInfo objZonaInfo = new ZonaInfo();
            Zona objZona = new Zona("conexion");
            decimal FleteIva;



            ObjParametrosInfo = ObjParametros.ListxId((int)ParametrosEnum.ValorIVACOP);
            FleteIva = Convert.ToDecimal(ObjParametrosInfo.Valor.ToString());
            objZonaInfo = objZona.ListxIdZona(IdZona);

            if (objZonaInfo != null)
            {
                //Crear el detalle del flete para el pedido.
                PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = CrearFleteDetallePedido(NumeroPedido, objZonaInfo.ValorFlete, IdZona, objZonaInfo.Excluido, CodCiudadCliente, FleteIva, 0, TipoFlete, "ZONA", PagarFletePuntos);

                PLUInfo objPLU = new PLUInfo();

                //objPLU.PLU = Convert.ToInt32(rcb_codigorapido.SelectedItem.Value);
                objPLU.PLU = Convert.ToInt32(objPedidosDetalleClienteInfo.PLU);
                objPLU.CodigoRapido = "FL00";
                objPLU.FechaCreacion = DateTime.Now;
                objPLU.CatalogoReal = CatalogoReal;
                objPedidosDetalleClienteInfo.CatalogoReal = CatalogoReal;

                if (ExcentoIVA == true)
                {
                    objPedidosDetalleClienteInfo.TarifaIVA = 0;
                }

                objPLU.NombreProducto = objPedidosDetalleClienteInfo.Descripcion;
                objPLU.PrecioConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + (Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * objPedidosDetalleClienteInfo.TarifaIVA / 100);
                objPLU.PrecioTotalConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + (Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * objPedidosDetalleClienteInfo.TarifaIVA / 100);
                objPLU.Cantidad = 1;

                objPLU.IVAPrecioCatalogo = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor);
                objPLU.PrecioCatalogoSinIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor);

                objPLU.PrecioCatalogoTotalConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * (Convert.ToDecimal(objPedidosDetalleClienteInfo.TarifaIVA) / 100);


                return objPedidosDetalleClienteInfo;
            }
            else
            {
                AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();
                Auditoria objAuditoria = new Auditoria("conexion");

                objAuditoriaInfo.Proceso = "No se creo el flete para el Pedido: " + NumeroPedido + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente.";
                objAuditoriaInfo.Usuario = Usuario;
                objAuditoriaInfo.FechaSistema = DateTime.Now;
                objAuditoria.Insert(objAuditoriaInfo);
                //Mesaje de Advertencia.              
                //RadWindowManager1.RadAlert("No se puede crear flete para esta ciudad ya que no se encuentra configurado.<br />Por favor comuniquese con Inteligencia Comercial - IDN Niviglobal.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                return null;
            }
        }

        private PedidosDetalleClienteInfo AdicionarFletePedidoConLider(bool TipoFlete, string NumeroPedido, string CodCiudadCliente, string IdZona, bool ExcentoIVA, string Usuario, string IdLider, string CatalogoReal, bool PagarFletePuntos)
        {
            FleteLider ObjFleteLider = new FleteLider("conexion");
            FleteLiderInfo ObjFleteliderInfo = new FleteLiderInfo();

            ObjFleteliderInfo = ObjFleteLider.List(IdLider);

            if (ObjFleteliderInfo != null)
            {
                //Crear el detalle del flete para el pedido.
                PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = CrearFleteDetallePedido(NumeroPedido, ObjFleteliderInfo.Valor, IdZona, ObjFleteliderInfo.Excluido, CodCiudadCliente, ObjFleteliderInfo.Iva, ObjFleteliderInfo.ValorFleteFull, TipoFlete, "LIDER", PagarFletePuntos);

                PLUInfo objPLU = new PLUInfo();

                //objPLU.PLU = Convert.ToInt32(rcb_codigorapido.SelectedItem.Value);
                objPLU.PLU = Convert.ToInt32(objPedidosDetalleClienteInfo.PLU);
                objPLU.CodigoRapido = "FL00";
                objPLU.FechaCreacion = DateTime.Now;
                objPLU.CatalogoReal = CatalogoReal;
                objPedidosDetalleClienteInfo.CatalogoReal = CatalogoReal;

                if (ExcentoIVA == true)
                {
                    objPedidosDetalleClienteInfo.TarifaIVA = 0;
                }

                objPLU.NombreProducto = objPedidosDetalleClienteInfo.Descripcion;
                objPLU.PrecioConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + (Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * objPedidosDetalleClienteInfo.TarifaIVA / 100);
                objPLU.PrecioTotalConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + (Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * objPedidosDetalleClienteInfo.TarifaIVA / 100);
                objPLU.Cantidad = 1;

                objPLU.IVAPrecioCatalogo = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor);
                objPLU.PrecioCatalogoSinIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor);

                objPLU.PrecioCatalogoTotalConIVA = Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) + Convert.ToDecimal(objPedidosDetalleClienteInfo.Valor) * (Convert.ToDecimal(objPedidosDetalleClienteInfo.TarifaIVA) / 100);

                return objPedidosDetalleClienteInfo;
            }
            else
            {
                AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();
                Auditoria objAuditoria = new Auditoria("conexion");

                objAuditoriaInfo.Proceso = "No se creo el flete para el Pedido: " + NumeroPedido + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente.";
                objAuditoriaInfo.Usuario = Usuario;
                objAuditoriaInfo.FechaSistema = DateTime.Now;
                objAuditoria.Insert(objAuditoriaInfo);
                //Mesaje de Advertencia.              
                //RadWindowManager1.RadAlert("No se puede crear flete para esta ciudad ya que no se encuentra configurado.<br />Por favor comuniquese con Inteligencia Comercial - IDN Niviglobal.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                return null;
            }
        }

        //----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------



        [HttpGet]
        [HttpPost]
        public List<PedidosDetalleClienteInfo> ListDetallePedidoReservaGYG(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {
            List<PedidosDetalleClienteInfo> lista = new List<PedidosDetalleClienteInfo>(); ;
            PedidosDetalleCliente module = new PedidosDetalleCliente("conexion");
                      
            lista = module.ListDetallePedidoReservaGYG(ObjPedidosClienteInfoRequest.Numero);         

            return lista;
        }


        [HttpGet]
        [HttpPost]
        public PedidosClienteInfo ConsultarSaldoAPagarxNit(PedidosClienteInfo ObjPedidosClienteInfoRequest)
        {
            PedidosClienteInfo objPedidosClienteInfo = new PedidosClienteInfo();
            PedidosCliente module = new PedidosCliente("conexion");

            if (ObjPedidosClienteInfoRequest.Nit != "" && ObjPedidosClienteInfoRequest.Nit!=null)
            {
                objPedidosClienteInfo = module.ListxGerenteZonaReservadosCPActual(ObjPedidosClienteInfoRequest.Nit);
            }
            else
            {
                objPedidosClienteInfo.Saldo = -100; 
            }

            return objPedidosClienteInfo;
        }
    }
}
