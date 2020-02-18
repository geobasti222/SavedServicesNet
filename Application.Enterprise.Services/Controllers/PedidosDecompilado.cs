/*namespace NIVI.SVDN.Web.Console.Administracion.Glod.Pages
{
    using NIVI.SVDN.Business.Rules;
    using NIVI.SVDN.Common.Entities;
    using NIVI.SVDN.Common.Objects;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Telerik.Web.UI;

    public class PedidosRapidoCodRes : Page
    {
        protected RadToolBar RadToolbar1;
        protected RadTabStrip RadTabStrip1;
        protected RadTab Tab1;
        protected RadTab Tab2;
        protected RadTab Tab3;
        protected RadTab Tab4;
        protected RadTab Tab5;
        protected RadTab Tab6;
        protected RadTab Tab7;
        protected RadTab Tab8;
        protected RadTab Tab12;
        protected RadTab Tab9;
        protected RadTab Tab10;
        protected RadTab Tab11;
        protected RadTab Tab13;
        protected RadTab Tab14;
        protected RadTab Tab15;
        protected RadTab Tab16;
        protected RadTab Tab17;
        protected RadTab Tab18;
        protected RadTab Tab19;
        protected RadCodeBlock RadCodeBlock1;
        protected Label lblProyecto;
        protected Button Button1;
        protected Label Label9;
        protected Label Label13;
        protected RadComboBox rcb_catalogo;
        protected Label lbl_nombreempresaria;
        protected Label Label6;
        protected RadComboBox rcb_campana;
        protected Label Label3;
        protected RadComboBox rcb_gerentezona;
        protected Label Label5;
        protected RadTextBox txt_nodocumento;
        protected Label Label10bodeInventario;
        protected RadComboBox RadComboBox1SelectBodega;
        protected Label Label7;
        protected Label lbl_numeropedido;
        protected Label Label11;
        protected ImageButton ImageButton3;
        protected Label Label12;
        protected Label Label1;
        protected HiddenField hdf_plu;
        protected RadComboBox rcb_zona;
        protected Label Label4;
        protected RadComboBox rcb_formapago;
        protected RadMultiPage RadMultiPage1;
        protected RadPageView RadPageView1;
        protected Label Label10;
        protected RadComboBox rcb_codigorapido;
        protected RadComboBox rcb_codigorapido_loc;
        protected RadComboBox rcb_nombrearticulo;
        protected RadComboBox rcb_preciounitario;
        protected RadComboBox rcb_cantidad;
        protected RadNumericTextBox txt_cantidad;
        protected ImageButton img_otracantidad;
        protected LinkButton lkb_otracantidad;
        protected RadComboBox rcb_preciototal;
        protected RadComboBox RadComboBoxPrecioPuntos;
        protected ImageButton img_adicionar;
        protected LinkButton LblTextoAdicionar;
        protected Label lblTitle;
        protected Panel Panel1;
        protected RadGrid grdData;
        protected RadPageView RadPageView2;
        protected Panel Panel2;
        protected RadGrid Amarres;
        protected Label LabelPrecioPuntosConFlete;
        protected Label Label8;
        protected System.Web.UI.WebControls.Image Image4;
        protected Label Labeltuspuntos;
        protected RadComboBox RadComboBoxSaldoPuntos;
        protected Label LabelValoraPagar;
        protected RadComboBox RadComboBox1SaldoPagar;
        protected Label LabelPuntosaUsar;
        protected TextBox RadNumericPuntosUsar;
        protected Label LabelTotalPagarDespuesPuntos;
        protected RadComboBox RadComboBoxTotalpagardespuesPuntos;
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton2;
        protected Button BtnEnviar;
        protected Button BtnGuardarBorrador;
        protected Label LabelAcumuladoPedidos;
        protected System.Web.UI.WebControls.Image ImageGanoPremio;
        protected Label LabelMayor;
        protected RadScriptManager ScriptManager1;
        protected RadContextMenu RadContextMenu1;
        protected RadMenuItem RadMenuEdit;
        protected RadMenuItem RadMenuVerDescuento;
        protected RadAjaxManager RadAjaxManager1;
        protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;
        protected System.Web.UI.WebControls.Image Image1;
        protected RadAjaxLoadingPanel RadAjaxLoadingPanel2;
        protected System.Web.UI.WebControls.Image Image2;
        protected RadWindowManager RadWindowManager1;
        protected RadWindow RadWindow1;
        protected RadWindow RadWindow2;
        protected RadWindowManager RadWindowManager2;
        protected RadWindow RadWindow3;
        protected RadWindowManager RadWindowManager3;
        protected RadWindow RadWindow4;

        public void actualizarEncabezadoPuntosxCedula(string cedula)
        {
            new PuntosBo().actualizarEncabezadoPuntosCliente(cedula);
        }

        public void actualizarTotalpagermenospuntos()
        {
            Inventario inventario = new Inventario("conexion");
            InventarioInfo objA = new InventarioInfo();
            int num = 0;
            int num2 = 0;
            decimal d = 0M;
            int num4 = new PuntosBo().getPuntosEfectivoEmpresaria(this.txt_nodocumento.Text);
            string bodega = "";
            if (this.Session["bodegaEmpresaria"] != null)
            {
                bodega = (string)this.Session["bodegaEmpresaria"];
            }
            int num6 = 0;
            while (true)
            {
                if (num6 >= this.PLUList.Count)
                {
                    int num1;
                    if (this.Session["totalPagarEmprep"] != null)
                    {
                        d = (decimal)this.Session["totalPagarEmprep"];
                    }
                    if ((this.RadNumericPuntosUsar.Text != null) && (this.RadNumericPuntosUsar.Text != ""))
                    {
                        num2 = Convert.ToInt32(this.RadNumericPuntosUsar.Text);
                        if (Convert.ToInt32(this.RadNumericPuntosUsar.Text) > num4)
                        {
                            this.LabelPuntosaUsar.ForeColor = System.Drawing.Color.Tomato;
                            this.LabelPuntosaUsar.Text = "<strong>Ingresa una cantidad menor a los puntos efectivos : " + num4 + "</strong>";
                            this.RadNumericPuntosUsar.Text = "0";
                        }
                        if (Convert.ToInt32(this.RadNumericPuntosUsar.Text) > num)
                        {
                            this.LabelPuntosaUsar.ForeColor = System.Drawing.Color.Tomato;
                            this.LabelPuntosaUsar.Text = "<strong>Ingresa una cantidad menor al valor del pedido en puntos: " + num + "</strong>";
                            this.RadNumericPuntosUsar.Text = "0";
                            d = Math.Round(d, 0);
                            this.RadComboBoxTotalpagardespuesPuntos.Items.Insert(0, new RadComboBoxItem("$ " + d, "1"));
                            this.RadComboBoxTotalpagardespuesPuntos.SelectedIndex = 0;
                        }
                    }
                    if (num4 == 0)
                    {
                        this.LabelPuntosaUsar.ForeColor = System.Drawing.Color.Tomato;
                        this.LabelPuntosaUsar.Text = "<strong>No tienes puntos efectivos</strong>";
                        this.RadNumericPuntosUsar.Text = "0";
                        d = Math.Round(d, 0);
                        this.RadComboBoxTotalpagardespuesPuntos.Items.Insert(0, new RadComboBoxItem("$ " + d, "1"));
                        this.RadComboBoxTotalpagardespuesPuntos.SelectedIndex = 0;
                    }
                    if (((num4 <= 0) || (num2 > num)) || (d <= 0M))
                    {
                        num1 = 1;
                    }
                    else
                    {
                        num1 = (int)(num <= 0);
                    }
                    if (num1 == 0)
                    {
                        this.LabelPuntosaUsar.Text = "\x00bfCuantos Puntos Usaras?";
                        d = Math.Round((decimal)(d - ((d / num) * num2)), 0);
                        this.RadComboBoxTotalpagardespuesPuntos.Text = "";
                        this.RadComboBoxTotalpagardespuesPuntos.Items.Clear();
                        this.RadComboBoxTotalpagardespuesPuntos.ClearSelection();
                        this.RadComboBoxTotalpagardespuesPuntos.Items.Insert(0, new RadComboBoxItem("$ " + d, "1"));
                        this.RadComboBoxTotalpagardespuesPuntos.SelectedIndex = 0;
                    }
                    this.Session["totalPedidoPuntos"] = num;
                    return;
                }
                objA = inventario.ListSaldosBodegaxPLUxEmpresaria(bodega, this.PLUList[num6].PLU);
                if (!ReferenceEquals(objA, null) && (objA.Saldo > 0M))
                {
                    num += Convert.ToInt32(this.PLUList[num6].Pagopuntos);
                }
                num6++;
            }
        }

        public void acumularPremio(string nit, string valorPedido, string IdPedido, string user)
        {
            new PremiosNiveles().acumularPremio(nit, valorPedido, IdPedido, user);
        }

        public void acumularPuntosxEstado(decimal totalPedidoPuntos, decimal totalDescuentoPuntos, decimal bonopuntosganar, decimal descuentoporpuntos, string cedula)
        {
            if (this.Session["cumpleminimoparapuntos"] == null)
            {
                this.Session["puntosGanadosPedido"] = 0;
            }
            else if (((int)this.Session["cumpleminimoparapuntos"]) != 1)
            {
                this.Session["puntosGanadosPedido"] = 0;
            }
            else
            {
                PuntosBo bo = new PuntosBo();
                try
                {
                    if (this.Session["IdGrupoLogin"] == null)
                    {
                        bo.insertarDetalleGananciaPuntos(this.IdPedido, cedula, 0, 0M, 1);
                    }
                    else if (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(50))
                    {
                        bo.insertarDetalleGananciaPuntos(this.IdPedido, cedula, 0, 0M, 2);
                    }
                    else
                    {
                        bo.insertarDetalleGananciaPuntos(this.IdPedido, cedula, 0, 0M, 1);
                    }
                }
                catch
                {
                }
            }
        }

        protected void AdicionarArticulo()
        {
            decimal num = 0M;
            this.Session["totalPagarEmprep"] = num;
            this.Session["totalPedidoenPuntos"] = num;
            this.rcb_campana.Visible = true;
            this.Label6.Visible = true;
            if (this.Session["espedidoPreventa"] != null)
            {
                this.rcb_campana.SelectedIndex = (((int)this.Session["espedidoPreventa"]) != 1) ? 0 : 1;
            }
            if ((this.txt_nodocumento.Text == "") || (this.lbl_nombreempresaria.Text == "NO EXISTE LA EMPRESARIA,<BR />POR FAVOR REALICE EL REGISTRO."))
            {
                this.RadWindowManager1.RadAlert("Debe ingresar una empresaria valida para adicionar articulos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else if (this.CantidadSeleccionada <= 0)
            {
                this.RadWindowManager1.RadAlert("la cantidad debe ser mayor que 0.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else
            {
                this.TotalArtNoDiponibles = 0M;
                this.PLUNoDisponibleList = null;
                this.ValorCatalogoHogar = 0M;
                this.ValorCatalogoOutlet = 0M;
                this.TotalPrecioCatalogoGlobal = 0M;
                this.ValorCatalogoPisame = 0M;
                this.ValorCatalogoOutletPisame = 0M;
                this.ValorCatalogoNivi = 0M;
                this.ValorTotalParaDescuento = 0M;
                this.ValorTotalParaDescuentoPisame = 0M;
                Vendedor vendedor = new Vendedor("conexion");
                VendedorInfo info = new VendedorInfo();
                bool flag = false;
                if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x34))
                {
                    if (!ReferenceEquals(vendedor.ListxCedulaxNit(this.Session["Cedula"].ToString(), this.txt_nodocumento.Text), null))
                    {
                        flag = true;
                    }
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                {
                    if (!ReferenceEquals(vendedor.ListxCedulaxNitxRegional(this.Session["CedulaRegional"].ToString(), this.txt_nodocumento.Text), null))
                    {
                        flag = true;
                    }
                }
                else if (this.Session["IdGrupo"].ToString() != Convert.ToString(60))
                {
                    if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x3b)) && !ReferenceEquals(vendedor.ListxCedulaxNitxAsistente(this.Session["Asistente"].ToString(), this.txt_nodocumento.Text), null))
                    {
                        flag = true;
                    }
                }
                else
                {
                    ClienteInfo info2 = new ClienteInfo();
                    if (!ReferenceEquals(new Cliente("conexion").ListxNITxLider(this.txt_nodocumento.Text, this.Session["IdLider"].ToString()), null))
                    {
                        flag = true;
                    }
                }
                if (this.Session["IdGrupoLogin"] != null)
                {
                    string str = Convert.ToString(this.Session["IdGrupoLogin"]);
                    if (str == Convert.ToString(0x61))
                    {
                        flag = true;
                    }
                    if (str == Convert.ToString(50))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    this.RadWindowManager1.RadAlert("La empresaria ingresada no corresponde a la zona actual.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
                else
                {
                    PLUInfo item = new PLUInfo();
                    DescuentoGlod glod = new DescuentoGlod();
                    item.PLU = this.intPLU;
                    item.CodigoRapido = this.strCodigoRapido;
                    item.FechaCreacion = DateTime.Now;
                    item.CatalogoReal = this.strCatalogoReal;
                    item.Grupo = "";
                    if (item.PLUSustituto == 0)
                    {
                        item.CodigoRapidoSustituto = "";
                    }
                    if (!this.ExistePLU(item.PLU))
                    {
                        item.NombreProducto = this.rcb_nombrearticulo.SelectedItem.Text;
                        item.PrecioPuntos = Convert.ToInt32(this.RadComboBoxPrecioPuntos.SelectedItem.Text);
                        item.PrecioConIVA = Convert.ToDecimal(this.rcb_preciounitario.SelectedItem.Text.Replace("$", "").Replace(" ", ""));
                        item.PrecioTotalConIVA = item.PrecioConIVA * this.CantidadSeleccionada;
                        item.Cantidad = this.CantidadSeleccionada;
                        item.IVAPrecioCatalogo = this.IVAPrecioCat * this.CantidadSeleccionada;
                        item.PrecioCatalogoSinIVA = this.PrecioCat * this.CantidadSeleccionada;
                        item.PrecioCatalogoTotalConIVA = item.PrecioCatalogoSinIVA + item.IVAPrecioCatalogo;
                        this.PLUList.Add(item);
                    }
                    else
                    {
                        string codigoRapidoSustituto = string.Empty;
                        int pLUSustituto = 0;
                        int num3 = 0;
                        while (true)
                        {
                            if (num3 < this.PLUList.Count)
                            {
                                if (this.PLUList[num3].PLU != item.PLU)
                                {
                                    num3++;
                                    continue;
                                }
                                codigoRapidoSustituto = this.PLUList[num3].CodigoRapidoSustituto;
                                pLUSustituto = this.PLUList[num3].PLUSustituto;
                            }
                            if (codigoRapidoSustituto != "")
                            {
                                this.RadWindowManager1.RadAlert("La referencia del articulo que desea agregar ya tiene un articulo sustituto, por favor verifique.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                            }
                            else
                            {
                                int num4 = this.EliminarPLU(item.PLU);
                                item.NombreProducto = this.rcb_nombrearticulo.SelectedItem.Text;
                                item.PrecioConIVA = Convert.ToDecimal(this.rcb_preciounitario.SelectedItem.Text.Replace("$", "").Replace(" ", ""));
                                item.PrecioTotalConIVA = item.PrecioConIVA * (this.CantidadSeleccionada + num4);
                                item.Cantidad = this.CantidadSeleccionada + num4;
                                item.IVAPrecioCatalogo = this.IVAPrecioCat * (this.CantidadSeleccionada + num4);
                                item.PrecioCatalogoSinIVA = this.PrecioCat * (this.CantidadSeleccionada + num4);
                                item.PrecioCatalogoTotalConIVA = item.PrecioCatalogoSinIVA + item.IVAPrecioCatalogo;
                                this.PLUList.Add(item);
                            }
                            break;
                        }
                    }
                    this.grdData.Rebind();
                    this.txt_cantidad.Visible = false;
                    this.img_otracantidad.Visible = false;
                    this.img_adicionar.Visible = false;
                    this.LblTextoAdicionar.Visible = false;
                    this.rcb_cantidad.Visible = true;
                    this.rcb_cantidad.Enabled = false;
                    this.txt_nodocumento.Enabled = false;
                    this.lkb_otracantidad.Visible = true;
                    this.LimpiarReferencia();
                }
                this.rcb_codigorapido_loc.Focus();
            }
            this.RadComboBoxPrecioPuntos.Text = "";
            this.RadComboBoxPrecioPuntos.Items.Clear();
            this.RadComboBoxPrecioPuntos.ClearSelection();
        }

        public PedidosDetalleClienteInfo AdicionarDetallePedido(int inPLU, decimal Cantidad, string CodigoRapidoSustituto, int PLUSustituto)
        {
            PedidosDetalleClienteInfo info = new PedidosDetalleClienteInfo();
            KardexInfo objA = new KardexInfo();
            Zona zona = new Zona("conexion");
            ZonaInfo info3 = new ZonaInfo();
            objA = new Kardex("conexion").ListxArticuloxPLU(inPLU);
            if (!ReferenceEquals(objA, null))
            {
                info.CodigoRapidoSustituto = CodigoRapidoSustituto;
                info.PLUSustituto = PLUSustituto;
                info.Cantidad = Cantidad;
                info.Imagen = objA.Imagen;
                info.Referencia = objA.Referencia;
                string[] strArray = new string[] { objA.NombreProducto.Trim(), ", <b>COLOR: </b>", objA.DescripcionColor.Trim(), ", <b>TALLA: </b>", objA.CodigoTalla.Trim() };
                info.Descripcion = string.Concat(strArray);
                info.Valor = objA.PrecioUno * info.Cantidad;
                info.Grupo = objA.Grupo;
                info.CodigoUbicacion = "P000";
                info.PLU = Convert.ToDecimal(objA.PLU);
                info.CentroCostos = "P000-" + objA.PLU.ToString();
                info.Grupo = objA.Grupo;
                info.ConceptoContable = objA.ConceptoContable;
                if (objA.PLU != 0xd1d)
                {
                    this.SubTotal += objA.PrecioUno * info.Cantidad;
                    this.SubTotalPrecioCat += objA.PrecioBaseVenta * info.Cantidad;
                }
                else
                {
                    info3 = zona.ListxIdZona(this.Session["IdZona"].ToString());
                    if (!ReferenceEquals(info3, null))
                    {
                        this.SubTotal += info3.ValorFlete;
                        this.SubTotalPrecioCat += info3.ValorFlete;
                    }
                }
                if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x34)) || (this.Session["IdGrupo"].ToString() == Convert.ToString(60)))
                {
                    info3 = zona.ListxIdZona(this.Session["IdZona"].ToString());
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                {
                    ClienteInfo info4 = new ClienteInfo();
                    info4 = new Cliente("conexion").ListClienteSVDNxNit(this.txt_nodocumento.Text);
                    if (ReferenceEquals(info4, null))
                    {
                        this.RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('No se pudo asignar la zona, Porfavor contacte a soporte de Informatica Niviglobal.');");
                    }
                    else
                    {
                        this.Session["IdZona"] = info4.Zona;
                        info3 = zona.ListxIdZona(this.Session["IdZona"].ToString());
                    }
                }
                ArtExcentosxCiudad ciudad = new ArtExcentosxCiudad("conexion");
                ArtExcentosxCiudadInfo info5 = new ArtExcentosxCiudadInfo();
                decimal iVA = 0M;
                decimal iVAPrecioCat = 0M;
                decimal num3 = 0M;
                if (ReferenceEquals(info3, null))
                {
                    LiteralControl child = new LiteralControl
                    {
                        Text = "<style type=\"text/css\" rel=\"stylesheet\">.radalert { background-image: url(../images/error.png) !important; } </style> "
                    };
                    this.Page.Header.Controls.Add(child);
                    string script = "<script language='javascript'>function f(){callAlertGenerico('No se puede obtener informacion de IVA de la zona. Por favor comuniquese con Niviglobal.'); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", script);
                }
                else if (info3.Excluido != 1)
                {
                    if (!(this.ConsultarIVA(info.Grupo) != 0M))
                    {
                        iVA = this.IVA;
                        this.IVA = iVA;
                        iVAPrecioCat = this.IVAPrecioCat;
                        this.IVAPrecioCat = iVAPrecioCat;
                    }
                    else
                    {
                        decimal num4;
                        decimal num5;
                        if (objA.PLU == 0xd1d)
                        {
                            num4 = 0M;
                            info5 = ciudad.ListxCiudadxPlu(this.CodCiudadCliente, objA.PLU);
                            num4 = ReferenceEquals(info5, null) ? (info3.ValorFlete * (this.ConsultarIVA(info.Grupo) / 100M)) : 0M;
                            iVA = this.IVA + num4;
                            this.IVA = iVA;
                            num5 = 0M;
                            num5 = ReferenceEquals(info5, null) ? (info3.ValorFlete * (this.ConsultarIVA(info.Grupo) / 100M)) : 0M;
                            iVAPrecioCat = this.IVAPrecioCat + num5;
                            num3 = num5;
                            this.IVAPrecioCat = iVAPrecioCat;
                        }
                        else
                        {
                            num4 = 0M;
                            info5 = ciudad.ListxCiudadxPlu(this.CodCiudadCliente, objA.PLU);
                            num4 = ReferenceEquals(info5, null) ? ((objA.PrecioUno * info.Cantidad) * (this.ConsultarIVA(info.Grupo) / 100M)) : 0M;
                            iVA = this.IVA + num4;
                            this.IVA = iVA;
                            num5 = 0M;
                            num5 = ReferenceEquals(info5, null) ? ((objA.PrecioBaseVenta * info.Cantidad) * (this.ConsultarIVA(info.Grupo) / 100M)) : 0M;
                            iVAPrecioCat = this.IVAPrecioCat + num5;
                            num3 = num5;
                            this.IVAPrecioCat = iVAPrecioCat;
                        }
                    }
                }
                this.Total = this.SubTotal + iVA;
                this.TotalPrecioCat = this.SubTotalPrecioCat + iVAPrecioCat;
                this.rcb_catalogo.Enabled = false;
                this.txt_nodocumento.ReadOnly = true;
                info.ValorPrecioCatalogo = objA.PrecioBaseVenta * info.Cantidad;
                info.IVAPrecioCatalogo = num3;
                info.UnidadNegocio = objA.UnidadNegocio;
                info.GrupoProducto = objA.GrupoProducto;
            }
            return info;
        }

        private void AdicionarFletePedido()
        {
            ZonaInfo objA = new ZonaInfo();
            objA = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
            if (!ReferenceEquals(objA, null))
            {
                PedidosDetalleClienteInfo info2 = this.CrearFleteDetallePedido("PEWFT0001", objA.ValorFlete, objA.Zona, objA.Excluido, 0);
                PLUInfo item = new PLUInfo
                {
                    PLU = Convert.ToInt32(info2.PLU),
                    CodigoRapido = "FL00",
                    FechaCreacion = DateTime.Now,
                    CatalogoReal = info2.CatalogoReal,
                    NombreProducto = info2.Descripcion,
                    PrecioConIVA = Convert.ToDecimal(info2.Valor) + ((Convert.ToDecimal(info2.Valor) * info2.TarifaIVA) / 100M),
                    PrecioTotalConIVA = Convert.ToDecimal(info2.Valor) + ((Convert.ToDecimal(info2.Valor) * info2.TarifaIVA) / 100M),
                    Cantidad = 1,
                    IVAPrecioCatalogo = Convert.ToDecimal(info2.Valor),
                    PrecioCatalogoSinIVA = Convert.ToDecimal(info2.Valor),
                    PrecioCatalogoTotalConIVA = Convert.ToDecimal(info2.Valor) + (Convert.ToDecimal(info2.Valor) * (Convert.ToDecimal(info2.TarifaIVA) / 100M))
                };
                this.PLUList.Add(item);
                this.grdData.Rebind();
            }
        }

        private PedidosDetalleClienteInfo AdicionarFletePedidoConCiudad(bool TipoFlete, string NumeroPedidoCiudad)
        {
            PedidosDetalleClienteInfo info5;
            CiudadInfo objA = new CiudadInfo();
            objA = new Ciudad("conexion").ListCiudadxId(this.CodCiudadCliente);
            if (ReferenceEquals(objA, null))
            {
                AuditoriaInfo item = new AuditoriaInfo();
                Auditoria auditoria = new Auditoria("conexion");
                item.Proceso = "No se creo el flete para el Pedido: " + NumeroPedidoCiudad + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente.";
                item.Usuario = this.Session["Usuario"].ToString().Trim();
                item.FechaSistema = DateTime.Now;
                auditoria.Insert(item);
                info5 = null;
            }
            else
            {
                PedidosDetalleClienteInfo info2 = this.CrearFleteDetallePedidoConCiudad(NumeroPedidoCiudad, objA.ValorFlete, this.Session["IdZona"].ToString(), objA.ExcluidoIVA, this.CodCiudadCliente, objA.IVA, objA.ValorFleteFull, TipoFlete);
                PLUInfo item = new PLUInfo
                {
                    PLU = Convert.ToInt32(info2.PLU),
                    CodigoRapido = "FL00",
                    FechaCreacion = DateTime.Now,
                    CatalogoReal = info2.CatalogoReal
                };
                if (this.ExcentoIVA)
                {
                    info2.TarifaIVA = 0M;
                }
                item.NombreProducto = info2.Descripcion;
                item.PrecioConIVA = Convert.ToDecimal(info2.Valor) + ((Convert.ToDecimal(info2.Valor) * info2.TarifaIVA) / 100M);
                item.PrecioTotalConIVA = Convert.ToDecimal(info2.Valor) + ((Convert.ToDecimal(info2.Valor) * info2.TarifaIVA) / 100M);
                item.Cantidad = 1;
                item.IVAPrecioCatalogo = Convert.ToDecimal(info2.Valor);
                item.PrecioCatalogoSinIVA = Convert.ToDecimal(info2.Valor);
                item.PrecioCatalogoTotalConIVA = Convert.ToDecimal(info2.Valor) + (Convert.ToDecimal(info2.Valor) * (Convert.ToDecimal(info2.TarifaIVA) / 100M));
                this.PLUList.Add(item);
                info5 = info2;
            }
            return info5;
        }

        private PedidosDetalleClienteInfo AdicionarFletePedidoConLider(bool TipoFlete, string NumeroPedidoCiudad)
        {
            PedidosDetalleClienteInfo info5;
            FleteLiderInfo objA = new FleteLiderInfo();
            objA = new FleteLider("conexion").List(this.Empresaria_Lider);
            if (ReferenceEquals(objA, null))
            {
                AuditoriaInfo item = new AuditoriaInfo();
                Auditoria auditoria = new Auditoria("conexion");
                item.Proceso = "No se creo el flete para el Pedido: " + NumeroPedidoCiudad + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente.";
                item.Usuario = this.Session["Usuario"].ToString().Trim();
                item.FechaSistema = DateTime.Now;
                auditoria.Insert(item);
                info5 = null;
            }
            else
            {
                PedidosDetalleClienteInfo info2 = this.CrearFleteDetallePedidoConCiudad(NumeroPedidoCiudad, objA.Valor, this.Session["IdZona"].ToString(), objA.Excluido, this.CodCiudadCliente, objA.Iva, objA.ValorFleteFull, TipoFlete);
                PLUInfo item = new PLUInfo
                {
                    PLU = Convert.ToInt32(info2.PLU),
                    CodigoRapido = "FL00",
                    FechaCreacion = DateTime.Now,
                    CatalogoReal = info2.CatalogoReal
                };
                if (this.ExcentoIVA)
                {
                    info2.TarifaIVA = 0M;
                }
                item.NombreProducto = info2.Descripcion;
                item.PrecioConIVA = Convert.ToDecimal(info2.Valor) + ((Convert.ToDecimal(info2.Valor) * info2.TarifaIVA) / 100M);
                item.PrecioTotalConIVA = Convert.ToDecimal(info2.Valor) + ((Convert.ToDecimal(info2.Valor) * info2.TarifaIVA) / 100M);
                item.Cantidad = 1;
                item.IVAPrecioCatalogo = Convert.ToDecimal(info2.Valor);
                item.PrecioCatalogoSinIVA = Convert.ToDecimal(info2.Valor);
                item.PrecioCatalogoTotalConIVA = Convert.ToDecimal(info2.Valor) + (Convert.ToDecimal(info2.Valor) * (Convert.ToDecimal(info2.TarifaIVA) / 100M));
                this.PLUList.Add(item);
                info5 = info2;
            }
            return info5;
        }

        private PedidosDetalleClienteInfo AdicionarFletePedidoConZona(bool TipoFlete, string NumeroPedidoCiudad)
        {
            PedidosDetalleClienteInfo info6;
            ParametrosInfo info = new ParametrosInfo();
            ZonaInfo objA = new ZonaInfo();
            decimal porcentajeIVA = Convert.ToDecimal(new Parametros("conexion").ListxId(6).Valor.ToString());
            objA = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
            if (ReferenceEquals(objA, null))
            {
                AuditoriaInfo item = new AuditoriaInfo();
                Auditoria auditoria = new Auditoria("conexion");
                item.Proceso = "No se creo el flete para el Pedido: " + NumeroPedidoCiudad + " , Debido a que no se encuentran los parametros de la ciudad configurados correctamente.";
                item.Usuario = this.Session["Usuario"].ToString().Trim();
                item.FechaSistema = DateTime.Now;
                auditoria.Insert(item);
                info6 = null;
            }
            else
            {
                PedidosDetalleClienteInfo info3 = this.CrearFleteDetallePedidoConCiudad(NumeroPedidoCiudad, objA.ValorFlete, this.Session["IdZona"].ToString(), objA.Excluido, this.CodCiudadCliente, porcentajeIVA, 0M, TipoFlete);
                PLUInfo item = new PLUInfo
                {
                    PLU = Convert.ToInt32(info3.PLU),
                    CodigoRapido = "FL00",
                    FechaCreacion = DateTime.Now,
                    CatalogoReal = info3.CatalogoReal
                };
                if (this.ExcentoIVA)
                {
                    info3.TarifaIVA = 0M;
                }
                item.NombreProducto = info3.Descripcion;
                item.PrecioConIVA = Convert.ToDecimal(info3.Valor) + ((Convert.ToDecimal(info3.Valor) * info3.TarifaIVA) / 100M);
                item.PrecioTotalConIVA = Convert.ToDecimal(info3.Valor) + ((Convert.ToDecimal(info3.Valor) * info3.TarifaIVA) / 100M);
                item.Cantidad = 1;
                item.IVAPrecioCatalogo = Convert.ToDecimal(info3.Valor);
                item.PrecioCatalogoSinIVA = Convert.ToDecimal(info3.Valor);
                item.PrecioCatalogoTotalConIVA = Convert.ToDecimal(info3.Valor) + (Convert.ToDecimal(info3.Valor) * (Convert.ToDecimal(info3.TarifaIVA) / 100M));
                this.PLUList.Add(item);
                info6 = info3;
            }
            return info6;
        }

        public void agregarDescuentoPuntos(decimal valorPuntos, int totalPedidoPuntos, int totalDescuentoPuntos)
        {
            PuntosBo bo = new PuntosBo();
            try
            {
                if (totalDescuentoPuntos != totalPedidoPuntos)
                {
                    decimal num = valorPuntos * totalDescuentoPuntos;
                    bo.agregarDescuentoPuntos(this.IdPedido, num);
                }
                else if (totalPedidoPuntos > 0)
                {
                    bo.agregarDescuento100(this.IdPedido);
                }
            }
            catch
            {
            }
        }

        public PedidosDetalleClienteInfo agregarDetallePremio(PedidosDetalleClienteInfo objPedidosDetalleClienteInfo, int plu)
        {
            KardexInfo objA = new KardexInfo();
            Zona zona = new Zona("conexion");
            ZonaInfo info2 = new ZonaInfo();
            objA = new Kardex("conexion").ListxArticuloxPLU(plu);
            if (!ReferenceEquals(objA, null))
            {
                objPedidosDetalleClienteInfo.CodigoRapidoSustituto = "";
                objPedidosDetalleClienteInfo.Cantidad = 1M;
                objPedidosDetalleClienteInfo.Imagen = objA.Imagen;
                objPedidosDetalleClienteInfo.Referencia = objA.Referencia;
                string[] strArray = new string[] { objA.NombreProducto.Trim(), ", <b>COLOR: </b>", objA.DescripcionColor, ", <b>TALLA: </b>", objA.CodigoTalla };
                objPedidosDetalleClienteInfo.Descripcion = string.Concat(strArray);
                objPedidosDetalleClienteInfo.Valor = objA.PrecioUno * objPedidosDetalleClienteInfo.Cantidad;
                objPedidosDetalleClienteInfo.Grupo = objA.Grupo;
                objPedidosDetalleClienteInfo.CodigoUbicacion = "P000";
                objPedidosDetalleClienteInfo.PLU = Convert.ToDecimal(objA.PLU);
                objPedidosDetalleClienteInfo.CentroCostos = "P000-" + objA.PLU.ToString();
                objPedidosDetalleClienteInfo.Grupo = objA.Grupo;
                objPedidosDetalleClienteInfo.ConceptoContable = objA.ConceptoContable;
                objPedidosDetalleClienteInfo.UnidadNegocio = objA.UnidadNegocio.Trim();
                objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = objA.PrecioBaseVenta;
                if (objA.PLU == 0x14c90)
                {
                    info2 = zona.ListxIdZona(this.Session["IdZona"].ToString());
                    if (!ReferenceEquals(info2, null))
                    {
                        this.SubTotal += info2.ValorFlete;
                        this.SubTotalPrecioCat += info2.ValorFlete;
                    }
                }
            }
            return objPedidosDetalleClienteInfo;
        }

        protected void Amarres_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                ((CheckBox)((GridDataItem)e.Item)["Llevar"].Controls[0]).Enabled = true;
            }
        }

        protected void Amarres_ItemDataBound(object sender, GridItemEventArgs e)
        {
        }

        protected void Amarres_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.Amarres.DataSource = this.Amarre;
            }
            catch (Exception)
            {
                this.Amarres.DataSource = new List<PLUInfo>();
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (this.RealizoReserva)
            {
                this.RadWindowManager1.RadAlert("No puede guardar el pedido por que ya se envio como reserva.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else if (this.grdData.Items.Count <= 0)
            {
                this.RadWindowManager1.RadAlert("Debe ingresar al menos 1 articulo para enviar el pedido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else
            {
                bool flag = false;
                ParametrosInfo info = new ParametrosInfo();
                string str = new Parametros("conexion").ListxId(0x13).Valor.ToString();
                if ("NO".ToUpper() == "SI")
                {
                    flag = this.ValidarPedidoMinimoxTipo();
                }
                else
                {
                    flag = true;
                    this.CalcularValoresPrecioCatalogo();
                }
                if (flag && (this.ValidarPedidoMinimoOutlet() && this.ValidarPedidoMinimoOutletPisame()))
                {
                    this.vsclickreserva = true;
                    this.ValidarGuardarReserva();
                }
            }
        }

        protected void BtnGuardarBorrador_Click(object sender, EventArgs e)
        {
            if (this.RealizoReserva)
            {
                this.RadWindowManager1.RadAlert("No puede reservar el pedido mas de una vez.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else if (this.grdData.Items.Count <= 0)
            {
                this.RadWindowManager1.RadAlert("Debe ingresar al menos 1 articulo para guardar el pedido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else
            {
                this.vsclickreserva = false;
                bool flag = false;
                ParametrosInfo info = new ParametrosInfo();
                string str = new Parametros("conexion").ListxId(0x13).Valor.ToString();
                flag = ("NO".ToUpper() != "SI") || this.ValidarPedidoMinimoxTipo();
                flag = true;
                this.CalcularValoresPrecioCatalogo();
                this.ValidarPedido();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("PedidosRapidoCodResDirecto.aspx");
        }

        private decimal CalcularDescuentoPrivilegioProdEstrella(string UnidadNegocio, string ArtGrupoProducto, string strCampana, string CatalogoReal, bool ProdEstrella)
        {
            DescuentoGlod glod = new DescuentoGlod("conexion");
            DescuentoInfo objA = new DescuentoInfo();
            DescuentoPrivilegio privilegio = new DescuentoPrivilegio("conexion");
            DescuentoPrivilegioInfo info2 = new DescuentoPrivilegioInfo();
            decimal porcentajeHogar = 0M;
            string grupoCliente = "";
            if (this.Session["grupoCliente"] != null)
            {
                grupoCliente = (string)this.Session["grupoCliente"];
            }
            if (this.Session["Privilegio"] == "0")
            {
                if (UnidadNegocio == "02")
                {
                    objA = glod.ListxValorPedidoProdEstrellaXGrupoCliente((decimal)this.Session["ValorTotalParaDescuentoPisame"], UnidadNegocio, ArtGrupoProducto, strCampana, false, grupoCliente);
                }
                else
                {
                    objA = ProdEstrella ? glod.ListxValorPedidoProdEstrellaXGrupoCliente((decimal)this.Session["ValorTotalParaProdEstrella"], UnidadNegocio, ArtGrupoProducto, strCampana, true, grupoCliente) : glod.ListxValorPedidoProdEstrellaXGrupoCliente((decimal)this.Session["ValorTotalParaDescuento"], UnidadNegocio, ArtGrupoProducto, strCampana, false, grupoCliente);
                }
                if (ReferenceEquals(objA, null))
                {
                    porcentajeHogar = 0M;
                }
                else if (CatalogoReal.Trim().ToUpper().StartsWith("H"))
                {
                    porcentajeHogar = objA.PorcentajeHogar;
                }
                else if (CatalogoReal.Trim().ToUpper().StartsWith("T"))
                {
                    porcentajeHogar = 0M;
                }
                else
                {
                    porcentajeHogar = !CatalogoReal.ToUpper().StartsWith("L") ? objA.Porcentaje : 0M;
                }
            }
            else if (this.Session["Privilegio"] == "1")
            {
                if (UnidadNegocio == "02")
                {
                    info2 = privilegio.ListxValorPedidoPrivilegio((decimal)this.Session["ValorTotalParaDescuentoPisame"], UnidadNegocio, ArtGrupoProducto, strCampana, false);
                }
                else
                {
                    info2 = ProdEstrella ? privilegio.ListxValorPedidoPrivilegio((decimal)this.Session["ValorTotalParaProdEstrella"], UnidadNegocio, ArtGrupoProducto, strCampana, true) : privilegio.ListxValorPedidoPrivilegio((decimal)this.Session["ValorTotalParaDescuento"], UnidadNegocio, ArtGrupoProducto, strCampana, false);
                }
                if (ReferenceEquals(info2, null))
                {
                    porcentajeHogar = 0M;
                }
                else if (CatalogoReal.Trim().ToUpper().StartsWith("H"))
                {
                    porcentajeHogar = info2.PorcentajeHogar;
                }
                else if (CatalogoReal.Trim().ToUpper().StartsWith("T"))
                {
                    porcentajeHogar = 0M;
                }
                else
                {
                    porcentajeHogar = !CatalogoReal.ToUpper().StartsWith("L") ? info2.Porcentaje : 0M;
                }
            }
            return porcentajeHogar;
        }

        private void CalcularValoresPrecioCatalogo()
        {
            decimal num = Convert.ToDecimal(((GridFooterItem)this.grdData.MasterTableView.GetItems(new GridItemType[] { 3 })[0]).Cells[10].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""));
            if (this.TipoPedidoMinimo == 1)
            {
                num = (((num - this.ValorCatalogoPisame) - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
            }
            else if (this.TipoPedidoMinimo == 2)
            {
                num = (((num - this.ValorCatalogoNivi) - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
            }
            else if (this.TipoPedidoMinimo == 3)
            {
                num = ((num - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
            }
            this.TotalPrecioCatalogoGlobal = num;
        }

        protected void cantidad_TextChanged(object sender, EventArgs e)
        {
            if (!ReferenceEquals(sender as TextBox, null))
            {
            }
        }

        public int CantidadPremiosMayoresGanados(List<PremiosNivelesInfo> listNiveles, decimal acumulado, int cantMayores)
        {
            int num = 0;
            decimal num2 = 0M;
            decimal num3 = 0M;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            while (true)
            {
                if (num6 >= listNiveles.Count)
                {
                    if (acumulado < num2)
                    {
                        num5 = cantMayores;
                    }
                    else
                    {
                        cantMayores++;
                        num5 = this.CantidadPremiosMayoresGanados(listNiveles, acumulado - num2, cantMayores);
                    }
                    return num5;
                }
                if (Convert.ToDecimal(listNiveles[num6].ValorMinimo.Replace(".", ",")) >= num2)
                {
                    num2 = Convert.ToDecimal(listNiveles[num6].ValorMinimo.Replace(".", ","));
                }
                if (acumulado >= Convert.ToDecimal(listNiveles[num6].ValorMinimo.Replace(".", ",")))
                {
                    num++;
                    if (Convert.ToDecimal(listNiveles[num6].ValorMinimo.Replace(".", ",")) > num3)
                    {
                        num3 = Convert.ToDecimal(listNiveles[num6].ValorMinimo.Replace(".", ","));
                        num4 = num6;
                    }
                }
                num6++;
            }
        }

        protected void CargarArticulo()
        {
            this.rcb_codigorapido_loc.Text = this.Session["CodigoRapidoSustituto"].ToString();
            this.rcb_cantidad.SelectedValue = this.Session["Cantidad"].ToString();
            this.rcb_cantidad.Enabled = true;
            this.txt_nodocumento.Enabled = false;
            this.rcb_nombrearticulo.Text = "";
            this.rcb_nombrearticulo.Items.Clear();
            this.rcb_nombrearticulo.ClearSelection();
            this.rcb_preciounitario.Text = "";
            this.rcb_preciounitario.Items.Clear();
            this.rcb_preciounitario.ClearSelection();
            this.rcb_preciototal.Text = "";
            this.rcb_preciototal.Items.Clear();
            this.rcb_preciototal.ClearSelection();
            PLUInfo objA = new PLUInfo();
            PLU plu = new PLU("conexion");
            PLUInfo info2 = new PLUInfo();
            CatalogoPluInfo info3 = new CatalogoPluInfo();
            info3 = new CatalogoPlu("conexion").ListxCodigoRapidoSinCatalogo(this.rcb_codigorapido_loc.Text.ToUpper());
            if (ReferenceEquals(info3, null))
            {
                this.intPLU = -1;
                this.rcb_nombrearticulo.Text = "";
                this.rcb_nombrearticulo.EmptyMessage = "No se encontraron resultados. Por favor verifique.";
                this.rcb_preciounitario.Text = "";
                this.rcb_preciounitario.EmptyMessage = "$ 0.0";
                this.rcb_preciototal.Text = "";
                this.rcb_preciototal.EmptyMessage = "$ 0.0";
            }
            else
            {
                objA = plu.ListxArticulosxPLUxTipoPrecio(info3.PLU, 2.ToString());
                if (!ReferenceEquals(objA, null))
                {
                    this.intPLU = objA.PLU;
                    this.Session["PLUSustituto"] = this.intPLU;
                    this.strCodigoRapido = this.rcb_codigorapido_loc.Text.ToUpper();
                    this.strCatalogoReal = info3.CatalogoReal;
                    this.rcb_nombrearticulo.Items.Insert(0, new RadComboBoxItem(objA.NombreProducto, objA.PLU.ToString()));
                    this.rcb_nombrearticulo.SelectedIndex = 0;
                    info2 = plu.ListxArticulosxPLUxTipoPrecio(info3.PLU, 1.ToString());
                    if (this.ExcentoIVA)
                    {
                        this.PrecioCat = info2.PrecioSinIVA;
                        this.IVAPrecioCat = 0M;
                        this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{objA.PrecioSinIVA:C}", objA.PLU.ToString()));
                        this.rcb_preciounitario.SelectedIndex = 0;
                        this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{objA.PrecioSinIVA:C}", objA.PLU.ToString()));
                        this.rcb_preciototal.SelectedIndex = 0;
                    }
                    else
                    {
                        ArtExcentosxCiudadInfo info4 = new ArtExcentosxCiudadInfo();
                        if (!ReferenceEquals(new ArtExcentosxCiudad("conexion").ListxCiudadxPlu(this.CodCiudadCliente, objA.PLU), null))
                        {
                            this.PrecioCat = info2.PrecioSinIVA;
                            this.IVAPrecioCat = 0M;
                            this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioSinIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciounitario.SelectedIndex = 0;
                            this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioSinIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciototal.SelectedIndex = 0;
                        }
                        else
                        {
                            this.PrecioCat = info2.PrecioSinIVA;
                            this.IVAPrecioCat = info2.IVA;
                            this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioConIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciounitario.SelectedIndex = 0;
                            this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioConIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciototal.SelectedIndex = 0;
                        }
                    }
                    this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
                }
                this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
                this.img_adicionar.Focus();
            }
        }

        public void CargarEncabezadoPedidoEnBlanco()
        {
            CampanaInfo objA = new CampanaInfo();
            Campana campana = new Campana("conexion");
            objA = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            if (ReferenceEquals(objA, null))
            {
                this.RadWindowManager1.RadAlert("No se pueden crear pedidos en este periodo.<br>La campa\x00f1a no ha sido habilitada.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");
            }
            else
            {
                this.lbl_nombreempresaria.Text = "Por favor digite el documento <br /> de la empresaria.";
                this.lbl_nombreempresaria.ForeColor = System.Drawing.Color.Crimson;
                this.lbl_numeropedido.Text = "Por favor guarde su pedido.";
                this.lbl_numeropedido.ForeColor = System.Drawing.Color.Crimson;
                this.txt_nodocumento.Text = "";
                this.LoadCatalogos();
                this.LoadCampanas();
            }
        }

        public void cargarSessionClienterapido()
        {
            ZonaInfo objA = new ZonaInfo();
            objA = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
            if (!ReferenceEquals(objA, null))
            {
                this.Session["DiasCierrePedidoBorrador"] = objA.DiasBorrador;
                this.Session["DiasCierrePedidoReservado"] = objA.DiasReserva;
                this.Session["DiasDeGracia"] = objA.DiasDeGracia;
                this.Session["UniNegZona"] = objA.UnidadNegocio;
            }
        }

        private void CargarValoresIniciales()
        {
            int num1;
            this.img_adicionar.Visible = false;
            this.img_adicionar.Enabled = false;
            this.LblTextoAdicionar.Visible = false;
            this.PLUList = null;
            this.intPLU = -1;
            this.PrecioCat = 0M;
            this.CantidadSeleccionada = 0;
            this.strCodigoRapido = "";
            this.SubTotalPrecioCat = 0M;
            this.IVAPrecioCat = 0M;
            this.IVA = 0M;
            this.SubTotal = 0M;
            this.RadWindowManager1.IconUrl = "../images/favicon.ico";
            if (this.Session["NombreUsuario"] != null)
            {
                this.rcb_gerentezona.Items.Insert(0, new RadComboBoxItem(this.Session["NombreUsuario"].ToString()));
            }
            if (this.Session["IdZona"] != null)
            {
                this.rcb_zona.Items.Insert(0, new RadComboBoxItem(this.Session["IdZona"].ToString()));
            }
            if ((this.IdPedido == "0") || (this.IdPedido == null))
            {
                num1 = 1;
            }
            else
            {
                num1 = (int)(this.IdPedido == "");
            }
            if (num1 == 0)
            {
                this.ListPedidoxId(this.IdPedido);
            }
            else
            {
                this.CargarEncabezadoPedidoEnBlanco();
                ParametrosInfo info = new ParametrosInfo();
                if (new Parametros("conexion").ListxId(40).Valor == "1")
                {
                    this.rcb_campana.Enabled = false;
                    List<CampanaInfo> list = new List<CampanaInfo>();
                    list = new Campana("conexion").Listxidpreventa(this.rcb_campana.SelectedItem.Value);
                    if ((list == null) || (list.Count <= 0))
                    {
                        this.rcb_campana.Text = "";
                        this.rcb_campana.SelectedValue = "";
                        this.rcb_campana.ClearSelection();
                        this.rcb_campana.Items.Clear();
                    }
                    else
                    {
                        this.rcb_campana.DataTextField = "Campana";
                        this.rcb_campana.DataValueField = "Campana";
                        this.rcb_campana.DataSource = list;
                        this.rcb_campana.DataBind();
                        if (this.rcb_campana.Items.Count > 1)
                        {
                            this.rcb_campana.Items[0].Text = this.rcb_campana.Items[0].Text + " (Campa\x00f1a Actual)";
                            this.rcb_campana.Items[0].Font.Bold = true;
                            this.rcb_campana.Items[0].ForeColor = System.Drawing.Color.DarkBlue;
                            this.rcb_campana.Items[1].Text = this.rcb_campana.Items[1].Text + " (PREVENTA)";
                            this.rcb_campana.Items[1].Font.Bold = true;
                            this.rcb_campana.Items[1].ForeColor = System.Drawing.Color.Tomato;
                        }
                    }
                }
            }
        }

        private void ConfigCombos()
        {
            this.rcb_codigorapido_loc.AllowCustomText = true;
            this.rcb_codigorapido_loc.MarkFirstMatch = true;
            this.rcb_codigorapido_loc.AutoCompleteSeparator = "|";
        }

        private decimal ConsultarIVA(string grupo)
        {
            GruposInfo info = new GruposInfo();
            TarifaIVAInfo info2 = new TarifaIVAInfo();
            return new TarifaIVA("conexion").ListxId(new Grupos("conexion").ListxId(grupo).IdTarifaIVA).Porcentaje;
        }

        private void ConsultarZonaMultiPedidos()
        {
            bool flag = this.Session["IdGrupoLogin"] == null;
            if (!flag)
            {
                flag = Convert.ToString(this.Session["IdGrupoLogin"]) != Convert.ToString(0x61);
                if (!flag)
                {
                    this.ZonaMultiPedidos = true;
                }
            }
            try
            {
                ZonasMultiPedidosInfo info = new ZonasMultiPedidosInfo();
                this.ZonaMultiPedidos = !ReferenceEquals(new ZonasMultiPedidos("conexion").ListxZona(this.Session["IdZona"].ToString().Trim()), null);
            }
            catch
            {
            }
        }

        private PedidosDetalleClienteInfo CrearDetalleFletePedidoParaLider()
        {
            PedidosDetalleClienteInfo info = new PedidosDetalleClienteInfo();
            FleteLiderInfo objA = new FleteLiderInfo();
            objA = new FleteLider("conexion").List(this.Empresaria_Lider);
            if (!ReferenceEquals(objA, null))
            {
                info = this.CrearFleteDetallePedido(this.IdPedido, objA.Valor, this.Session["IdZona"].ToString(), objA.Excluido, objA.Iva);
            }
            return info;
        }

        private PedidosDetalleClienteInfo CrearDetalleFletePedidoParaZona()
        {
            PedidosDetalleClienteInfo info = new PedidosDetalleClienteInfo();
            ZonaInfo objA = new ZonaInfo();
            objA = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
            if (!ReferenceEquals(objA, null))
            {
                info = this.CrearFleteDetallePedido(this.IdPedido, objA.ValorFlete, objA.Zona, objA.Excluido, 0);
            }
            return info;
        }

        private PedidosDetalleClienteInfo CrearFleteDetallePedido(string IdPedido, decimal ValorFlete, string Zona, int Excluido, int ivaLider = 0)
        {
            Parametros parametros = new Parametros("conexion");
            PedidosDetalleClienteInfo info = new PedidosDetalleClienteInfo
            {
                Numero = IdPedido,
                Referencia = "FT0001",
                Descripcion = "MANEJO LOGISTICO - ZONA: " + Zona,
                Valor = ValorFlete,
                Cantidad = 1M,
                Descuento = 0M,
                Anulado = 0
            };
            if (Excluido == 1)
            {
                info.TarifaIVA = 0M;
            }
            else
            {
                info.TarifaIVA = (ivaLider != 0) ? Convert.ToDecimal(ivaLider) : Convert.ToDecimal(parametros.ListxId(6).Valor);
            }
            info.Lote = "P000-3357";
            info.Ensamblado = 0;
            info.CantidadPedida = 1M;
            info.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            info.CodigoUbicacion = "P000";
            info.PLU = 3357M;
            info.NumeroEnvio = 0M;
            info.ConceptoContable = "005";
            info.CentroCostos = Zona;
            info.Grupo = "FT0001";
            info.Imagen = "Flete Asignado desde SVDN. Fecha: " + DateTime.Now.ToString();
            info.CantidadNivelServicio = 0M;
            info.ValorPrecioCatalogo = ValorFlete;
            info.IVAPrecioCatalogo = info.TarifaIVA;
            info.Catalogo = this.rcb_catalogo.SelectedValue;
            info.NumeroPedidoPadre = IdPedido;
            info.PLU = Convert.ToInt32(info.PLU);
            info.IdCodigoCorto = "FL00";
            info.FechaCreacion = DateTime.Now;
            info.CatalogoReal = info.Catalogo;
            info.UnidadNegocio = "0" + 1;
            info.PorcentajeDescuento = 0M;
            info.ValorPrecioCatalogoUnitario = info.Valor;
            return info;
        }

        private PedidosDetalleClienteInfo CrearFleteDetallePedidoConCiudad(string IdPedido, decimal ValorFlete, string IdZona, int Excluido, string CodCiudad, decimal PorcentajeIVA, decimal ValorFleteFull, bool TipoFlete)
        {
            Parametros parametros = new Parametros("conexion");
            PedidosDetalleClienteInfo info = new PedidosDetalleClienteInfo
            {
                Numero = IdPedido,
                Referencia = "FT0001",
                Descripcion = "MANEJO LOGISTICO - CIUDAD: " + CodCiudad
            };
            if (TipoFlete)
            {
                info.Valor = ValorFlete;
                info.ValorUnitario = ValorFlete;
                info.ValorPrecioCatalogoUnitario = ValorFlete;
            }
            else
            {
                info.Valor = ValorFleteFull;
                info.ValorUnitario = ValorFleteFull;
                info.ValorPrecioCatalogoUnitario = ValorFleteFull;
            }
            info.Cantidad = 1M;
            info.Descuento = 0M;
            info.Anulado = 0;
            info.TarifaIVA = (Excluido != 1) ? PorcentajeIVA : 0M;
            info.Lote = "P000-3357";
            info.Ensamblado = 0;
            info.CantidadPedida = 1M;
            info.IdDocumentoFuente = "Fec: " + DateTime.Now.ToString();
            info.CodigoUbicacion = "P000";
            info.PLU = 3357M;
            info.NumeroEnvio = 0M;
            info.ConceptoContable = "005";
            info.CentroCostos = IdZona;
            info.Grupo = "FT0001";
            info.Imagen = "Flete Asignado desde SVDN. Fecha: " + DateTime.Now.ToString();
            info.CantidadNivelServicio = 0M;
            if (TipoFlete)
            {
                info.ValorPrecioCatalogo = ValorFlete;
                info.ValorUnitario = ValorFlete;
                info.ValorPrecioCatalogoUnitario = ValorFlete;
            }
            else
            {
                info.ValorPrecioCatalogo = ValorFleteFull;
                info.ValorUnitario = ValorFleteFull;
                info.ValorPrecioCatalogoUnitario = ValorFleteFull;
            }
            info.IVAPrecioCatalogo = info.TarifaIVA;
            info.Catalogo = "N/A";
            info.NumeroPedidoPadre = IdPedido;
            info.IdCodigoCorto = "FL00";
            info.UnidadNegocio = "01";
            return info;
        }

        private void DeshabilitarControles()
        {
            this.RadToolbar1.Items[0].Enabled = false;
            this.RadToolbar1.Items[1].Enabled = false;
            this.RadToolbar1.Items[2].Enabled = false;
            this.txt_nodocumento.Enabled = false;
            this.rcb_codigorapido.Enabled = false;
            this.rcb_campana.Enabled = false;
            this.rcb_catalogo.Enabled = false;
            this.rcb_formapago.Enabled = false;
            this.rcb_cantidad.Enabled = false;
            this.lkb_otracantidad.Enabled = false;
            this.img_adicionar.Enabled = false;
            this.txt_cantidad.Enabled = false;
        }

        public void documentochangeempresaria()
        {
            this.lbl_nombreempresaria.Text = this.ValidaExisteEmpresariaNombre(this.txt_nodocumento.Text);
            PremiosNiveles niveles = new PremiosNiveles();
            this.LabelAcumuladoPedidos.Text = "Acumulado Pedidos: $." + niveles.getAcumuladoEmpresaria(this.txt_nodocumento.Text);
            int num = new PuntosBo().getPuntosEfectivoEmpresaria(this.txt_nodocumento.Text);
            this.Session["bodegaEmpresaria"] = new BodegaGlod().getbodegaEmpresaria(this.txt_nodocumento.Text);
            this.Session["grupoCliente"] = new DescuentoGlod().getGrupoCliente(this.txt_nodocumento.Text);
            if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(0x61)))
            {
                ClienteInfo info = new Cliente().ListClienteSVDNxNit(this.txt_nodocumento.Text);
                this.Session["IdZona"] = info.Zona;
                ZonaInfo objA = new ZonaInfo();
                objA = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
                if (!ReferenceEquals(objA, null))
                {
                    this.Session["DiasCierrePedidoBorrador"] = objA.DiasBorrador;
                    this.Session["DiasCierrePedidoReservado"] = objA.DiasReserva;
                    this.Session["DiasDeGracia"] = objA.DiasDeGracia;
                    this.Session["UniNegZona"] = objA.UnidadNegocio;
                }
            }
            this.RadComboBoxSaldoPuntos.Items.Insert(0, new RadComboBoxItem(num, num.ToString()));
            this.RadComboBoxSaldoPuntos.SelectedIndex = 0;
            this.LabelPuntosaUsar.Text = "\x00bfCuantos Puntos Usaras?";
            this.RadNumericPuntosUsar.Text = "0";
            if ((this.lbl_nombreempresaria.Text.ToUpper() != "NO EXISTE LA EMPRESARIA,<BR />POR FAVOR REALICE EL REGISTRO.") && (this.lbl_nombreempresaria.Text != ""))
            {
                ParametrosInfo info3 = new ParametrosInfo();
                if (new Parametros("conexion").ListxId(0x19).Valor.ToString().ToUpper() == "SI")
                {
                    this.RadAjaxManager1.ResponseScripts.Add("ValidarDireccionTelefono('" + this.txt_nodocumento.Text + "');");
                }
            }
        }

        public bool EditarPedido()
        {
            PedidosDetalleCliente cliente2;
            decimal num;
            decimal num2;
            decimal num3;
            decimal num4;
            string str2;
            string str3;
            Auditoria auditoria;
            AuditoriaInfo info7;
            bool flag8;
            bool flag11;
            List<PedidosDetalleClienteInfo>.Enumerator enumerator2;
            bool flag = false;
            PedidosClienteInfo info = new PedidosClienteInfo();
            PedidosCliente cliente = new PedidosCliente("conexion");
            info.Numero = this.IdPedido;
            info.Fecha = DateTime.Now;
            info.IVA = this.IVA;
            info.Valor = this.SubTotal;
            info.ClaveUsuario = this.Session["ClaveUsuario"].ToString().Trim();
            info.IVAPrecioCat = this.IVAPrecioCat;
            info.ValorPrecioCat = this.SubTotalPrecioCat;
            info.TipoEnvio = Convert.ToInt32(this.Session["vstipoenviopedido"].ToString());
            if ((this.Session["MostrarNombreGerente"] != null) && (this.Session["MostrarNombreGerente"].ToString() == "true"))
            {
                info.GuardarAuditoria = true;
                info.Usuario = this.Session["NombreUsuario"].ToString();
            }
            if (!cliente.Update(info))
            {
                goto TR_0003;
            }
            else
            {
                cliente2 = new PedidosDetalleCliente("conexion");
                flag11 = !cliente2.DeleteArticulos(this.IdPedido);
                if (flag11)
                {
                    goto TR_0003;
                }
                else
                {
                    PedidosDetalleClienteInfo info4;
                    string str;
                    this.IdPedido = this.IdPedido;
                    this.IdPedidoRes = this.IdPedido;
                    this.SubTotalPrecioCat = 0M;
                    this.IVAPrecioCat = 0M;
                    DescuentoGlod glod = new DescuentoGlod("conexion");
                    DescuentoInfo objA = new DescuentoInfo();
                    num = 0M;
                    num2 = 0M;
                    num3 = 0M;
                    num4 = 0M;
                    ArtExcentosxCiudad ciudad = new ArtExcentosxCiudad("conexion");
                    ArtExcentosxCiudadInfo info3 = new ArtExcentosxCiudadInfo();
                    IEnumerator enumerator = this.grdData.Items.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            string text;
                            int num1;
                            flag11 = enumerator.MoveNext();
                            if (!flag11)
                            {
                                break;
                            }
                            GridDataItem current = (GridDataItem)enumerator.Current;
                            if ((current["CodigoRapidoSustituto"].Text == "&NBSP;") || (current["CodigoRapidoSustituto"].Text == "&nbsp;"))
                            {
                                text = "";
                            }
                            else
                            {
                                text = current["CodigoRapidoSustituto"].Text;
                            }
                            info4 = this.AdicionarDetallePedido(Convert.ToInt32(current["PLU"].Text), Convert.ToDecimal(current["Cantidad"].Text), text, Convert.ToInt32(current["PLUSustituto"].Text));
                            if (this.ExcentoIVA)
                            {
                                info4.TarifaIVA = 0M;
                            }
                            else
                            {
                                if (current["CodigoRapido"].Text == "FL00")
                                {
                                    info4.Grupo = "FT0001";
                                }
                                info4.TarifaIVA = this.ConsultarIVA(info4.Grupo);
                            }
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                info4.Referencia = "FT0001";
                                info4.Descripcion = "MANEJO LOGISTICO - CIUDAD: " + this.CodCiudadCliente;
                                info4.Grupo = "FT0001";
                                info4.CentroCostos = this.Session["IdZona"].ToString().Trim();
                                info4.ConceptoContable = "005";
                                info4.CodigoUbicacion = "P000";
                                info4.Valor = Convert.ToDecimal(current["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", "")) / ((info4.TarifaIVA / 100M) + 1);
                                info4.Cantidad = 1M;
                                info4.PLU = 3357M;
                            }
                            if (this.ExcentoIVA)
                            {
                                info4.TarifaIVA = 0M;
                            }
                            else
                            {
                                info3 = ciudad.ListxCiudadxPlu(this.CodCiudadCliente, Convert.ToInt32(info4.PLU));
                                if (!ReferenceEquals(info3, null))
                                {
                                    info4.TarifaIVA = 0M;
                                }
                            }
                            info4.Numero = this.IdPedido;
                            info4.Referencia = info4.Referencia;
                            info4.Descripcion = info4.Descripcion.Replace("<b>", "").Replace("</b>", "");
                            info4.Valor = info4.Valor;
                            info4.Cantidad = info4.Cantidad;
                            info4.Descuento = 0M;
                            info4.Anulado = 0;
                            info4.Lote = info4.CentroCostos;
                            info4.Ensamblado = 0;
                            info4.CantidadPedida = 0M;
                            info4.IdDocumentoFuente = "";
                            info4.CodigoUbicacion = info4.CodigoUbicacion;
                            info4.PLU = info4.PLU;
                            info4.NumeroEnvio = 0M;
                            info4.ConceptoContable = info4.ConceptoContable;
                            info4.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            info4.Grupo = info4.Grupo;
                            info4.Imagen = info4.Imagen;
                            info4.ValorPrecioCatalogo = info4.ValorPrecioCatalogo;
                            if (!this.ExcentoIVA)
                            {
                                info4.IVAPrecioCatalogo = ReferenceEquals(info3, null) ? (info4.ValorPrecioCatalogo * (this.ConsultarIVA(info4.Grupo) / 100M)) : 0M;
                            }
                            else
                            {
                                info4.IVAPrecioCatalogo = 0M;
                            }
                            info4.Catalogo = this.rcb_catalogo.SelectedValue;
                            info4.NumeroPedidoPadre = this.IdPedido;
                            info4.ValorUnitario = info4.Valor / info4.Cantidad;
                            info4.IdCodigoCorto = current["CodigoRapido"].Text;
                            info4.CatalogoReal = current["CatalogoReal"].Text;
                            info4.UnidadNegocio = info4.UnidadNegocio;
                            objA = (info4.UnidadNegocio != "02") ? glod.ListxValorPedido(this.ValorTotalParaDescuento, info4.UnidadNegocio, info4.GrupoProducto, this.rcb_campana.SelectedItem.Value) : glod.ListxValorPedido(this.ValorTotalParaDescuentoPisame, info4.UnidadNegocio, info4.GrupoProducto, this.rcb_campana.SelectedItem.Value);
                            decimal porcentajeHogar = 0M;
                            if (ReferenceEquals(objA, null))
                            {
                                porcentajeHogar = 0M;
                            }
                            else if (info4.CatalogoReal.Trim().ToUpper().StartsWith("H"))
                            {
                                porcentajeHogar = objA.PorcentajeHogar;
                            }
                            else if (info4.CatalogoReal.Trim().ToUpper().StartsWith("T"))
                            {
                                porcentajeHogar = 0M;
                            }
                            else
                            {
                                porcentajeHogar = !info4.CatalogoReal.ToUpper().StartsWith("L") ? objA.Porcentaje : 0M;
                            }
                            info4.ValorPrecioCatalogoUnitario = info4.ValorPrecioCatalogo / info4.Cantidad;
                            info4.Valor = info4.ValorPrecioCatalogoUnitario - (info4.ValorPrecioCatalogoUnitario * (porcentajeHogar / 100M));
                            info4.PorcentajeDescuento = porcentajeHogar;
                            num += info4.Valor * info4.Cantidad;
                            num2 += (info4.Valor * info4.Cantidad) * (info4.TarifaIVA / 100M);
                            num3 += info4.ValorPrecioCatalogoUnitario * info4.Cantidad;
                            num4 += (info4.ValorPrecioCatalogoUnitario * info4.Cantidad) * (info4.TarifaIVA / 100M);
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                info4.CantidadPedida = 1M;
                                info4.CatalogoReal = this.rcb_catalogo.SelectedValue;
                                info4.ValorPrecioCatalogo = info4.ValorUnitario;
                                info4.IVAPrecioCatalogo = info4.ValorPrecioCatalogo * (this.ConsultarIVA(info4.Grupo) / 100M);
                            }
                            bool flag4 = true;
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                flag4 = false;
                            }
                            str = "";
                            decimal pLUSustituto = info4.PLUSustituto;
                            if ((info4.PLUSustituto == 0M) || (info4.CodigoRapidoSustituto == null))
                            {
                                num1 = 0;
                            }
                            else
                            {
                                num1 = (int)(info4.CodigoRapidoSustituto != "");
                            }
                            if (num1 == 0)
                            {
                                info4.PLUSustituto = 0M;
                                info4.CodigoRapidoSustituto = "";
                            }
                            if (flag4)
                            {
                                str = cliente2.Insert(info4);
                            }
                            flag = true;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        flag11 = ReferenceEquals(disposable, null);
                        if (!flag11)
                        {
                            disposable.Dispose();
                        }
                    }
                    if (!this.AdicionarFleteYPremios)
                    {
                        goto TR_0004;
                    }
                    else
                    {
                        int num7;
                        bool tipoFlete = this.ValidarPedidoMinimoxTipoParaFlete();
                        info4 = new PedidosDetalleClienteInfo();
                        if (tipoFlete)
                        {
                            if (this.Session["vstipoenviopedido"].ToString() == "1")
                            {
                                info4 = this.AdicionarFletePedidoConCiudad(tipoFlete, this.IdPedido);
                            }
                            else
                            {
                                info4 = (this.Session["vstipoenviopedido"].ToString() != "2") ? this.AdicionarFletePedidoConLider(tipoFlete, this.IdPedido) : this.AdicionarFletePedidoConZona(tipoFlete, this.IdPedido);
                            }
                        }
                        if (this.ExcentoIVA)
                        {
                            info4.TarifaIVA = 0M;
                        }
                        else
                        {
                            if (info4.IdCodigoCorto == "FL00")
                            {
                                info4.Grupo = "FT0001";
                            }
                            info4.TarifaIVA = this.ConsultarIVA(info4.Grupo);
                        }
                        if (info4.IdCodigoCorto == "FL00")
                        {
                            info4.Referencia = "FT0001";
                            info4.Descripcion = "MANEJO LOGISTICO - CIUDAD: " + this.CodCiudadCliente;
                            info4.Grupo = "FT0001";
                            info4.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            info4.ConceptoContable = "005";
                            info4.CodigoUbicacion = "P000";
                            info4.Cantidad = 1M;
                            info4.PLU = 3357M;
                            info4.CantidadPedida = 1M;
                            info4.CatalogoReal = this.rcb_catalogo.SelectedValue;
                            info4.ValorPrecioCatalogo = info4.ValorUnitario;
                            info4.IVAPrecioCatalogo = info4.ValorPrecioCatalogo * (info4.TarifaIVA / 100M);
                            info4.PLUSustituto = 0M;
                            info4.CodigoRapidoSustituto = "";
                        }
                        decimal pLUSustituto = info4.PLUSustituto;
                        if ((info4.PLUSustituto == 0M) || (info4.CodigoRapidoSustituto == null))
                        {
                            num7 = 0;
                        }
                        else
                        {
                            num7 = (int)(info4.CodigoRapidoSustituto != "");
                        }
                        if (num7 == 0)
                        {
                            info4.PLUSustituto = 0M;
                            info4.CodigoRapidoSustituto = "";
                        }
                        num += info4.Valor * info4.Cantidad;
                        num2 += (info4.Valor * info4.Cantidad) * (info4.TarifaIVA / 100M);
                        num3 += info4.ValorPrecioCatalogoUnitario * info4.Cantidad;
                        num4 += (info4.ValorPrecioCatalogoUnitario * info4.Cantidad) * (info4.TarifaIVA / 100M);
                        str = cliente2.Insert(info4);
                        if (this.PremioBienvenida != 0)
                        {
                            goto TR_0011;
                        }
                        else
                        {
                            ParametrosInfo info5 = new ParametrosInfo();
                            info5 = new Parametros("conexion").ListxId(20);
                            if (ReferenceEquals(info5, null))
                            {
                                goto TR_0011;
                            }
                            else if (this.TotalPrecioCatalogoGlobal >= Convert.ToDecimal(info5.Valor))
                            {
                                int tipoPedidoMinimo = this.TipoPedidoMinimo;
                                List<PedidosDetalleClienteInfo> list = cliente2.ListPremiosBienvenidaActivos("0" + tipoPedidoMinimo.ToString());
                                flag11 = (list == null) || (list.Count <= 0);
                                if (!flag11)
                                {
                                    using (enumerator2 = list.GetEnumerator())
                                    {
                                        while (true)
                                        {
                                            flag11 = enumerator2.MoveNext();
                                            if (!flag11)
                                            {
                                                break;
                                            }
                                            PedidosDetalleClienteInfo current = enumerator2.Current;
                                            tipoPedidoMinimo = DateTime.Now.Second;
                                            str2 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + tipoPedidoMinimo.ToString();
                                            current.Id = this.IdPedido + "_PRE_" + str2;
                                            current.Numero = this.IdPedido;
                                            current.NumeroPedidoPadre = this.IdPedido;
                                            DateTime now = DateTime.Now;
                                            current.IdDocumentoFuente = now.ToString();
                                            current.Catalogo = this.rcb_catalogo.SelectedValue;
                                            current.CatalogoReal = current.Catalogo;
                                            current.IdCodigoCorto = "PRE00";
                                            current.PorcentajeDescuento = 0M;
                                            current.CentroCostos = this.Session["IdZona"].ToString().Trim();
                                            num += current.Valor * current.Cantidad;
                                            num2 += (current.Valor * current.Cantidad) * (current.TarifaIVA / 100M);
                                            num3 += current.ValorPrecioCatalogoUnitario * current.Cantidad;
                                            num4 += (current.ValorPrecioCatalogoUnitario * current.Cantidad) * (current.TarifaIVA / 100M);
                                            current.PLUSustituto = 0M;
                                            current.CodigoRapidoSustituto = "";
                                            str3 = cliente2.Insert(current);
                                            if ((str3 == "") || ReferenceEquals(str3, null))
                                            {
                                                auditoria = new Auditoria("conexion");
                                                info7 = new AuditoriaInfo
                                                {
                                                    FechaSistema = DateTime.Now,
                                                    Proceso = "No se pudo adicionar premio de bienvenida al pedido: " + this.IdPedido,
                                                    Usuario = this.Session["Usuario"].ToString().Trim()
                                                };
                                                auditoria.Insert(info7);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!new Cliente("conexion").UpdateEstadoPremioCliente(this.txt_nodocumento.Text))
            {
                auditoria = new Auditoria("conexion");
                info7 = new AuditoriaInfo
                {
                    FechaSistema = DateTime.Now,
                    Proceso = "No se pudo actualizar estado del cliente premio de bienvenida con pedido: " + this.IdPedido,
                    Usuario = this.Session["Usuario"].ToString().Trim()
                };
                auditoria.Insert(info7);
            }
            goto TR_0011;
        TR_0003:
            if ((this.Session["recogePedidoTienda"] != null) && (((int)this.Session["recogePedidoTienda"]) == 1))
            {
                new Inventario().eliminarFlete(this.IdPedido);
            }
            return flag;
        TR_0004:
            flag8 = cliente.UpdateValorPedidoSVDN(this.IdPedido, num, num2);
            bool flag9 = cliente.UpdateValorPrecioCatalogoPedidoSVDN(this.IdPedido, num3, num4);
            goto TR_0003;
        TR_0011:
            if (!this.TienePedidoCampanaActual())
            {
                List<PedidosDetalleClienteInfo> list2 = cliente2.ListCatalogosSiguientes(this.rcb_campana.SelectedItem.Value.Trim());
                flag11 = (list2 == null) || (list2.Count <= 0);
                if (!flag11)
                {
                    using (enumerator2 = list2.GetEnumerator())
                    {
                        while (true)
                        {
                            flag11 = enumerator2.MoveNext();
                            if (!flag11)
                            {
                                break;
                            }
                            PedidosDetalleClienteInfo current = enumerator2.Current;
                            str2 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            current.Id = this.IdPedido + "_CAT_" + str2;
                            current.Numero = this.IdPedido;
                            current.NumeroPedidoPadre = this.IdPedido;
                            current.IdDocumentoFuente = DateTime.Now.ToString();
                            current.Catalogo = this.rcb_catalogo.SelectedValue;
                            current.CatalogoReal = current.Catalogo;
                            current.IdCodigoCorto = "CAT00";
                            current.PorcentajeDescuento = 0M;
                            current.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            num += current.Valor * current.Cantidad;
                            num2 += (current.Valor * current.Cantidad) * (current.TarifaIVA / 100M);
                            num3 += current.ValorPrecioCatalogoUnitario * current.Cantidad;
                            num4 += (current.ValorPrecioCatalogoUnitario * current.Cantidad) * (current.TarifaIVA / 100M);
                            current.PLUSustituto = 0M;
                            current.CodigoRapidoSustituto = "";
                            str3 = cliente2.Insert(current);
                            if ((str3 == "") || ReferenceEquals(str3, null))
                            {
                                auditoria = new Auditoria("conexion");
                                info7 = new AuditoriaInfo
                                {
                                    FechaSistema = DateTime.Now,
                                    Proceso = "No se pudo adicionar catalogo siguiente al pedido: " + this.IdPedido,
                                    Usuario = this.Session["Usuario"].ToString().Trim()
                                };
                                auditoria.Insert(info7);
                            }
                        }
                    }
                }
            }
            this.AdicionarFleteYPremios = false;
            goto TR_0004;
        }

        private int EliminarPLU(int PLU)
        {
            int cantidad = 0;
            for (int i = 0; i < this.PLUList.Count; i++)
            {
                if (this.PLUList[i].PLU == PLU)
                {
                    cantidad = this.PLUList[i].Cantidad;
                    int index = 0;
                    while (true)
                    {
                        if (index >= this.PLUNoDisponibleList.Count)
                        {
                            this.ValorCatalogoHogar = 0M;
                            this.ValorCatalogoOutlet = 0M;
                            this.TotalPrecioCatalogoGlobal = 0M;
                            this.ValorCatalogoPisame = 0M;
                            this.ValorCatalogoOutletPisame = 0M;
                            this.ValorCatalogoNivi = 0M;
                            this.ValorTotalParaDescuento = 0M;
                            this.ValorTotalParaDescuentoPisame = 0M;
                            this.PLUList.RemoveAt(i);
                            i = -1;
                            break;
                        }
                        if (Convert.ToInt32(this.PLUNoDisponibleList[index]) == PLU)
                        {
                            PLUInfo info = new PLUInfo();
                            info = new PLU("conexion").ListxArticulosxPLUxTipoPrecio(PLU, 1.ToString());
                            this.TotalArtNoDiponibles = 0M;
                            this.PLUNoDisponibleList.RemoveAt(index);
                        }
                        index++;
                    }
                }
            }
            return cantidad;
        }

        public bool empresariaPuedeReclamaryAcumular(List<PremiosNivelesInfo> listNiveles, decimal acumulado)
        {
            int num = 0;
            decimal num2 = 0M;
            decimal num3 = 0M;
            int num4 = 0;
            bool flag = false;
            int num5 = 0;
            while (true)
            {
                bool flag3 = num5 < listNiveles.Count;
                if (!flag3)
                {
                    if ((acumulado < num2) && (num > 0))
                    {
                        flag = true;
                        this.Session["agregarPremio"] = 1;
                    }
                    if (num3 > 0M)
                    {
                        this.Session["idCortoPremioEmpresaria"] = listNiveles[num4].Codigorapido;
                        this.Session["nivelEmpresariaPremio"] = listNiveles[num4].IdNivel;
                        this.Session["descripcionPremio"] = listNiveles[num4].Descripcion;
                        this.Session["premioEmpresaria"] = listNiveles[num4];
                    }
                    if (acumulado < num2)
                    {
                        this.Session["ganoPremioMayor"] = 0;
                    }
                    else
                    {
                        List<PremiosNivelesInfo> list;
                        this.ImageGanoPremio.Visible = true;
                        this.LabelMayor.Text = "\x00a1Ganaste el Premio Mayor!";
                        this.Session["agregarPremio"] = 1;
                        this.Session["ganoPremioMayor"] = 1;
                        PremiosNivelesInfo objA = listNiveles[num4];
                        if (this.Session["listaPremiosEmpresaria"] == null)
                        {
                            list = new List<PremiosNivelesInfo>();
                            if (!ReferenceEquals(objA, null))
                            {
                                list.Add(objA);
                                this.Session["listaPremiosEmpresaria"] = list;
                                this.Session["cantidadMayoresGanados"] = 1;
                            }
                        }
                        else
                        {
                            list = (List<PremiosNivelesInfo>)this.Session["listaPremiosEmpresaria"];
                            if (!ReferenceEquals(objA, null))
                            {
                                int num6 = 0;
                                int num7 = 0;
                                num5 = 0;
                                while (true)
                                {
                                    flag3 = num5 < list.Count;
                                    if (!flag3)
                                    {
                                        if (num6 <= 0)
                                        {
                                            list.Add(objA);
                                        }
                                        else
                                        {
                                            list[num7].Cantidad++;
                                            this.ImageGanoPremio.Visible = true;
                                            this.LabelMayor.Text = "\x00a1Ganaste " + list[num7].Cantidad + " Premios Mayores!";
                                            this.Session["cantidadMayoresGanados"] = list[num7].Cantidad;
                                        }
                                        this.Session["listaPremiosEmpresaria"] = list;
                                        break;
                                    }
                                    if (list[num5].PLU == objA.PLU)
                                    {
                                        num6++;
                                        num7 = num5;
                                    }
                                    num5++;
                                }
                            }
                        }
                        flag = this.empresariaPuedeReclamaryAcumular(listNiveles, acumulado - num2);
                    }
                    return flag;
                }
                if (Convert.ToDecimal(listNiveles[num5].ValorMinimo.Replace(".", ",")) >= num2)
                {
                    num2 = Convert.ToDecimal(listNiveles[num5].ValorMinimo.Replace(".", ","));
                }
                if (acumulado >= Convert.ToDecimal(listNiveles[num5].ValorMinimo.Replace(".", ",")))
                {
                    num++;
                    if (Convert.ToDecimal(listNiveles[num5].ValorMinimo.Replace(".", ",")) > num3)
                    {
                        num3 = Convert.ToDecimal(listNiveles[num5].ValorMinimo.Replace(".", ","));
                        num4 = num5;
                    }
                }
                num5++;
            }
        }

        private void EnviarCorreo()
        {
            ParametrosInfo info = new ParametrosInfo();
            Parametros parametros = new Parametros("conexion");
            bool flag = false;
            ClienteInfo objA = new Cliente("conexion").ListxNIT(this.txt_nodocumento.Text);
            string nombreEmpresaria = "";
            string email = "";
            if (!ReferenceEquals(objA, null))
            {
                string[] strArray = new string[] { objA.Nombre1, " ", objA.Nombre2, " ", objA.Apellido1, " ", objA.Apellido2 };
                nombreEmpresaria = string.Concat(strArray);
                if ((parametros.ListxId(0x1d).Valor == "SI") && this.ValidaCorreo(objA.Email.Trim()))
                {
                    email = objA.Email;
                }
            }
            string str3 = "";
            if ((this.Session["IdVendedor"].ToString() != null) && (this.Session["IdVendedor"].ToString() != ""))
            {
                VendedorInfo info3 = new Vendedor("conexion").ListxIdVendedor(this.Session["IdVendedor"].ToString());
            }
            string emailPara = "";
            if ((str3 != "") && (email != ""))
            {
                emailPara = str3 + "," + email;
            }
            else if ((str3 == "") && (email != ""))
            {
                emailPara = email;
            }
            else if ((str3 != "") && (email == ""))
            {
                emailPara = str3;
            }
            Mail mail = new Mail();
            SmtpMailInfo info4 = new SmtpMailInfo();
            flag = mail.SendMail(mail.ConfigurarParametros(2, emailPara, "", "", nombreEmpresaria, this.IdPedido, this.Total.ToString()));
        }

        public bool esLoginEmpresaria()
        {
            bool flag = false;
            if ((this.Session["IdGrupoLogin"] != null) && (((string)this.Session["IdGrupoLogin"]) == Convert.ToString(50)))
            {
                flag = true;
            }
            return flag;
        }

        public bool esLoginSac()
        {
            bool flag = false;
            if (this.Session["IdGrupoLogin"] != null)
            {
                string str = (string)this.Session["IdGrupoLogin"];
                if ((str == Convert.ToString(12)) || (str == Convert.ToString(15)))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool espedidoRapido()
        {
            bool flag = false;
            if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(0x61)))
            {
                flag = true;
            }
            return flag;
        }

        private bool ExistePLU(int PLU)
        {
            bool flag = false;
            if (this.PLUList.Count > 0)
            {
                int num = 0;
                while (true)
                {
                    if (num < this.PLUList.Count)
                    {
                        if (this.PLUList[num].PLU != PLU)
                        {
                            num++;
                            continue;
                        }
                        flag = true;
                    }
                    break;
                }
            }
            return flag;
        }

        public void gastarPuntos(int cantpuntosGastados, string cedula)
        {
            PuntosBo bo = new PuntosBo();
            try
            {
                if (((this.RadNumericPuntosUsar.Text != null) && (this.RadNumericPuntosUsar.Text != "")) && (Convert.ToInt32(this.RadNumericPuntosUsar.Text) > 0))
                {
                    cantpuntosGastados = Convert.ToInt32(this.RadNumericPuntosUsar.Text);
                }
                if (cantpuntosGastados > 0)
                {
                    bo.insertarDetalleGastoPuntos(this.IdPedido, cedula, cantpuntosGastados);
                }
            }
            catch
            {
            }
        }

        public List<AmarresInfo> getAmarres(string codigo)
        {
            AmarresInfo info = new AmarresInfo();
            return new AmarresBo().ListAmarresxCodigo(codigo);
        }

        public int getcantidadCampanasAcumulaPremio() =>
            new PremiosNiveles().getCantidadCampaniasAcumulaNivel();

        public List<AmarresInfo> getPintasVigentes()
        {
            List<AmarresInfo> list = new List<AmarresInfo>();
            return new AmarresBo().verPintasVigentes();
        }

        public List<AmarresInfo> getPintasVigentesxIdCorto()
        {
            List<AmarresInfo> list = new List<AmarresInfo>();
            return new AmarresBo().verPintasVigentesxIdCorto();
        }

        public decimal getTotalAcumladoParaPremio(decimal totalPedido, string nit, int cantCampanas)
        {
            decimal num = new PremiosNiveles().getAcumuladoEmpresaria(nit);
            return (totalPedido + num);
        }

        protected void grdData_ItemDataBound(object sender, GridItemEventArgs e)
        {
            int num2;
            bool flag;
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item["Cantidad"].Text) > 1)
                {
                    item["Cantidad"].ForeColor = System.Drawing.Color.Red;
                    item["Cantidad"].Font.Bold = true;
                }
                else
                {
                    item["Cantidad"].ForeColor = System.Drawing.Color.Black;
                    item["Cantidad"].Font.Bold = false;
                }
                string menosArticulosNoDiponibles = "0";
                Inventario inventario = new Inventario("conexion");
                InventarioInfo info = new InventarioInfo();
                string str2 = "";
                if (this.Session["bodegaEmpresaria"] != null)
                {
                    str2 = (string)this.Session["bodegaEmpresaria"];
                }
                info = inventario.ListSaldosBodegaxPLUxEmpresaria(str2, Convert.ToInt32(item["PLU"].Text));
                string str3 = "";
                if (!ReferenceEquals(info, null))
                {
                    if (info.Saldo > 0M)
                    {
                        (item["Disponible"].FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = "../images/aprobar.gif";
                    }
                    else
                    {
                        (item["Disponible"].FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = "../images/nodisp.gif";
                        str3 = inventario.BuscaFechaProducto(Convert.ToInt32(item["PLU"].Text), this.rcb_campana.SelectedValue);
                        if (str3 != "")
                        {
                            (item["Disponible"].FindControl("labelDisponible") as Label).Text = "Desde:" + str3;
                            (item["Disponible"].FindControl("labelDisponible") as Label).Visible = true;
                        }
                        this.TotalArtNoDiponibles += Convert.ToDecimal(item["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", ""));
                        menosArticulosNoDiponibles = item["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", "");
                        this.PLUNoDisponibleList.Add(item["PLU"].Text);
                    }
                }
                else
                {
                    (item["Disponible"].FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = "../images/nodisp.gif";
                    str3 = inventario.BuscaFechaProducto(Convert.ToInt32(item["PLU"].Text), this.rcb_campana.SelectedValue);
                    if (str3 != "")
                    {
                        (item["Disponible"].FindControl("labelDisponible") as Label).Text = "Desde:" + str3;
                        (item["Disponible"].FindControl("labelDisponible") as Label).Visible = true;
                    }
                    if (Convert.ToInt32(item["PLU"].Text) == 0xbccc)
                    {
                        (item["Disponible"].FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = "../images/aprobar.gif";
                    }
                    else
                    {
                        this.TotalArtNoDiponibles += Convert.ToDecimal(item["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", ""));
                        menosArticulosNoDiponibles = item["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", "");
                    }
                    this.PLUNoDisponibleList.Add(item["PLU"].Text);
                }
                this.SumarValoresOutletHogar(item["CatalogoReal"].Text, item["PrecioCatalogoTotalConIVA"].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""), menosArticulosNoDiponibles);
                if (item["CatalogoReal"].Text.Trim().ToUpper().StartsWith("T"))
                {
                    item["Catalogo"].Text = "OUTLET NIVI";
                }
                else if (item["CatalogoReal"].Text.Trim().ToUpper().StartsWith("H"))
                {
                    item["Catalogo"].Text = "HOGAR";
                }
                else
                {
                    KardexInfo info2;
                    if (item["CatalogoReal"].Text.Trim().ToUpper().StartsWith("P"))
                    {
                        item["Catalogo"].Text = "PISAME";
                        info2 = new KardexInfo();
                        if (!ReferenceEquals(new Kardex("conexion").ListxGrupoProductoxPLU(Convert.ToInt32(item["PLU"].Text)), null))
                        {
                            this.SumarValorCatalogoParaDescuentoPisame(item["PrecioCatalogoTotalConIVA"].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""), menosArticulosNoDiponibles);
                        }
                    }
                    else if (item["CatalogoReal"].Text.Trim().ToUpper().StartsWith("L"))
                    {
                        item["Catalogo"].Text = "OUTLET PISAME";
                    }
                    else if (item["CatalogoReal"].Text.Trim().ToUpper().StartsWith("O"))
                    {
                        item["Catalogo"].Text = "NIVI E.";
                    }
                    else
                    {
                        item["Catalogo"].Text = "NIVI";
                        info2 = new KardexInfo();
                        if (!ReferenceEquals(new Kardex("conexion").ListxGrupoProductoxPLU(Convert.ToInt32(item["PLU"].Text)), null))
                        {
                            this.SumarValorCatalogoParaDescuento(item["PrecioCatalogoTotalConIVA"].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""), menosArticulosNoDiponibles);
                        }
                    }
                }
                DescuentoGlod glod = new DescuentoGlod("conexion");
                DescuentoInfo info3 = new DescuentoInfo();
                decimal num = 0M;
                KardexInfo info4 = new Kardex("conexion").ListxArticuloxPLU(Convert.ToInt32(item["PLU"].Text));
                string str4 = "";
                num2 = 0;
                while (true)
                {
                    flag = num2 < this.PLUList.Count;
                    if (!flag)
                    {
                        string str5 = "";
                        if (this.Session["grupoCliente"] != null)
                        {
                            str5 = (string)this.Session["grupoCliente"];
                        }
                        KardexInfo info5 = new Kardex("conexion").ListxArticuloxPLU(Convert.ToInt32(item["PLU"].Text));
                        num = this.CalcularDescuentoPrivilegioProdEstrella(info5.UnidadNegocio.Trim(), info5.GrupoProducto.Trim(), this.Session["CampanaPrev"].ToString(), item["CatalogoReal"].Text.Trim().ToUpper(), info5.ProdEstrella);
                        str2 = "";
                        if (this.Session["bodegaEmpresaria"] != null)
                        {
                            str2 = (string)this.Session["bodegaEmpresaria"];
                        }
                        info = inventario.ListSaldosBodegaxPLUxEmpresaria(str2, Convert.ToInt32(item["PLU"].Text));
                        decimal num4 = Convert.ToDecimal(item["PrecioCatalogoTotalConIVA"].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""));
                        decimal num5 = 0M;
                        if (ReferenceEquals(info, null))
                        {
                            num5 = 0M;
                            num = 0M;
                        }
                        else if (info.Saldo > 0M)
                        {
                            num5 = num4 - (num4 * (num / 100M));
                        }
                        else
                        {
                            num5 = 0M;
                            num = 0M;
                        }
                        item["PorcentajeDescuento"].Text = $"{num:N2}%";
                        item["PorcentajeDescuento"].Font.Bold = true;
                        item["PorcentajeDescuento"].ForeColor = System.Drawing.Color.Red;
                        num2 = 0;
                        while (true)
                        {
                            flag = num2 < this.PLUList.Count;
                            if (!flag)
                            {
                                num5 = Math.Round(num5, 0);
                                item["PrecioEmpre"].ForeColor = System.Drawing.Color.Crimson;
                                item["PrecioEmpre"].Text = $"{num5:C}";
                                if (this.Session["totalPagarEmprep"] != null)
                                {
                                    this.Session["totalPagarEmprep"] = ((decimal)this.Session["totalPagarEmprep"]) + num5;
                                }
                                break;
                            }
                            if (this.PLUList[num2].CodigoRapido.Trim().Equals(item["CodigoRapido"].Text.Trim()))
                            {
                                this.PLUList[num2].Descuentoempresaria = num5;
                            }
                            num2++;
                        }
                        break;
                    }
                    if (this.PLUList[num2].CodigoRapido.Trim().Equals(item["CodigoRapido"].Text.Trim()))
                    {
                        str4 = this.PLUList[num2].Grupo.Trim();
                        decimal pagopuntos = Convert.ToDecimal(new PuntosBo().getPrecioPuntosProducto(item["CodigoRapido"].Text.Trim(), this.Session["CampanaPrev"].ToString()));
                        this.PLUList[num2].Pagopuntos = pagopuntos * this.PLUList[num2].Cantidad;
                        pagopuntos = this.PLUList[num2].Pagopuntos;
                        info = inventario.ListSaldosBodegaxPLUxEmpresaria(str2, Convert.ToInt32(item["PLU"].Text));
                        if ((!ReferenceEquals(info, null) && (info.Saldo > 0M)) && (this.Session["totalPedidoenPuntos"] != null))
                        {
                            this.Session["totalPedidoenPuntos"] = ((decimal)this.Session["totalPedidoenPuntos"]) + pagopuntos;
                        }
                        (item["PrecioPuntos"].FindControl("LabelPrecioPuntos") as Label).Text = pagopuntos;
                        (item["PrecioPuntos"].FindControl("LabelPrecioPuntos") as Label).ForeColor = System.Drawing.Color.ForestGreen;
                        this.PLUList[num2].CatalogoInicial = item["Catalogo"].Text.Trim().ToUpper();
                        this.PLUList[num2].EsCataNivi = !item["Catalogo"].Text.Trim().ToUpper().StartsWith("N") ? 0 : 1;
                    }
                    num2++;
                }
            }
            else if (e.Item is GridFooterItem)
            {
                decimal num6 = 0M;
                decimal num7 = 0M;
                decimal num8 = 0M;
                if (this.Session["totalPagarEmprep"] != null)
                {
                    num6 = (decimal)this.Session["totalPagarEmprep"];
                }
                if (this.Session["totalPedidoenPuntos"] != null)
                {
                    num7 = (decimal)this.Session["totalPedidoenPuntos"];
                }
                if (this.Session["valorpuntoensoles"] != null)
                {
                    num8 = (decimal)this.Session["valorpuntoensoles"];
                }
                GridFooterItem item = (GridFooterItem)e.Item;
                item["PrecioTotalConIVA"].ForeColor = System.Drawing.Color.Magenta;
                item["PrecioCatalogoTotalConIVA"].ForeColor = System.Drawing.Color.Blue;
                item["PrecioPuntos"].ForeColor = System.Drawing.Color.ForestGreen;
                item["PrecioEmpre"].ForeColor = System.Drawing.Color.Crimson;
                item["PrecioPuntos"].Font.Bold = true;
                item["PrecioEmpre"].Font.Bold = true;
                item["PrecioEmpre"].Text = $"{num6:C}";
                item["PrecioPuntos"].Text = $"{num7:C}";
                item["PrecioPuntos"].Text = item["PrecioPuntos"].Text.Replace("$", "");
                this.RadComboBox1SaldoPagar.Items.Insert(0, new RadComboBoxItem("$ " + Math.Round(num6, 0), Math.Round(num6, 0).ToString()));
                this.RadComboBox1SaldoPagar.SelectedIndex = 0;
            }
            Inventario inventario2 = new Inventario("conexion");
            InventarioInfo objA = new InventarioInfo();
            decimal d = 0M;
            string bodega = "";
            if (this.Session["bodegaEmpresaria"] != null)
            {
                bodega = (string)this.Session["bodegaEmpresaria"];
            }
            num2 = 0;
            while (true)
            {
                flag = num2 < this.PLUList.Count;
                if (!flag)
                {
                    this.RadComboBox1SaldoPagar.Items.Insert(0, new RadComboBoxItem("$ " + Math.Round(d, 0), Math.Round(d, 0).ToString()));
                    this.RadComboBox1SaldoPagar.SelectedIndex = 0;
                    this.actualizarTotalpagermenospuntos();
                    return;
                }
                objA = inventario2.ListSaldosBodegaxPLUxEmpresaria(bodega, this.PLUList[num2].PLU);
                if (!ReferenceEquals(objA, null) && (objA.Saldo > 0M))
                {
                    d += this.PLUList[num2].PrecioCatalogoTotalConIVA;
                }
                num2++;
            }
        }

        protected void grdData_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.grdData.DataSource = ((this.PLUList.Count <= 0) || ReferenceEquals(this.PLUList, null)) ? new List<PLUInfo>() : this.PLUList;
        }

        public bool GuardarDetalleTraslado()
        {
            TrasladoDetInfo item = new TrasladoDetInfo();
            TrasladoDet det = new TrasladoDet("conexion");
            bool flag = false;
            try
            {
                item.Numero = "";
                item.Anulado = 0;
                item.Id = "";
                item.Referencia = "";
                item.Descripcion = "";
                item.Ensamblado = 0;
                item.Cantidad = 0M;
                item.Valor = 0M;
                item.CCostos = "";
                item.ConceptoContable = "02";
                item.CentroCostos = "0010";
                item.Serie = "";
                item.CodTipo = "";
                item.Nit = "";
                item.TarifaIva = 0M;
                item.CodUbicacion = "P000";
                item.Plu = 0M;
                item.CodigoBarras = "";
                item.Estado = 1;
                item.EstCan = 0M;
                if (!((det.Insert(item) == "") || ReferenceEquals(det.Insert(item), null)))
                {
                    flag = true;
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public bool GuardarEncabezadoTraslado(string NumeroPedido)
        {
            TrasladoEncInfo item = new TrasladoEncInfo();
            TrasladoEnc enc = new TrasladoEnc("conexion");
            bool flag = false;
            try
            {
                string str = "00";
                if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
                {
                    str = "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    str = DateTime.Now.Month.ToString();
                }
                item.Numero = "";
                item.Mes = DateTime.Now.Year.ToString() + str;
                item.Anulado = 0;
                item.Fecha = DateTime.Now;
                item.BodegaHacia = "022";
                item.Observaciones = "TRASLADO X RESERVA DE MERCANCIA DESDE SVDN NUMERO PEDIDO:" + NumeroPedido;
                item.Bodega = "002";
                item.FechaCreacion = DateTime.Now;
                item.ClaveUsuario = "";
                item.TrasladoPyG = 0;
                item.NumeroDocEspera = "0";
                item.Zona = "0010";
                item.Espera = 0;
                item.CodigoNumeracion = "045";
                item.Transmitido = 0;
                item.CodTipo = "";
                item.Devol = "";
                item.Nit = this.txt_nodocumento.Text;
                item.Catalogo = "";
                item.Unidades = 0;
                item.TotalSeparados = 0M;
                item.Separado = 0;
                if (!((enc.Insert(item) == "") || ReferenceEquals(enc.Insert(item), null)))
                {
                    flag = true;
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public bool GuardarPedido()
        {
            PedidosCliente cliente;
            string str7;
            PedidosDetalleCliente cliente5;
            decimal num4;
            decimal num5;
            decimal num6;
            decimal num7;
            string str11;
            string str12;
            Auditoria auditoria;
            AuditoriaInfo info11;
            bool flag9;
            bool flag12;
            List<PedidosDetalleClienteInfo>.Enumerator enumerator2;
            bool flag = false;
            bool flag2 = false;
            int num = 0;
            string str = "";
            PremiosNivelesInfo info = new PremiosNivelesInfo();
            List<PremiosNivelesInfo> list = new List<PremiosNivelesInfo>();
            decimal num2 = 0M;
            if ((this.Session["agregarPremio"] != null) || (this.Session["listaPremiosEmpresaria"] != null))
            {
                if (((int)this.Session["agregarPremio"]) == 1)
                {
                    flag2 = true;
                }
                if (this.Session["listaPremiosEmpresaria"] != null)
                {
                    flag2 = true;
                }
            }
            if (this.Session["nivelEmpresariaPremio"] != null)
            {
                num = (int)this.Session["nivelEmpresariaPremio"];
            }
            if (this.Session["idCortoPremioEmpresaria"] != null)
            {
                str = (string)this.Session["idCortoPremioEmpresaria"];
            }
            if (this.Session["premioEmpresaria"] != null)
            {
                info = (PremiosNivelesInfo)this.Session["premioEmpresaria"];
            }
            if (this.Session["listaPremiosEmpresaria"] != null)
            {
                list = (List<PremiosNivelesInfo>)this.Session["listaPremiosEmpresaria"];
            }
            int num3 = 0;
            while (true)
            {
                ClienteInfo info3;
                flag12 = num3 < this.PLUList.Count;
                if (flag12)
                {
                    num2 += this.PLUList[num3].PrecioCatalogoTotalConIVA;
                    num3++;
                    continue;
                }
                PedidosClienteInfo info2 = new PedidosClienteInfo();
                cliente = new PedidosCliente("conexion");
                string str2 = "00";
                if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
                {
                    str2 = "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    str2 = DateTime.Now.Month.ToString();
                }
                string str3 = "";
                string str4 = "";
                string str5 = "";
                bool flag3 = false;
                bool flag4 = false;
                if (this.Session["IdGrupoLogin"] != null)
                {
                    string str6 = Convert.ToString(this.Session["IdGrupoLogin"]);
                    if (str6 == Convert.ToString(50))
                    {
                        flag3 = true;
                    }
                    if (str6 == Convert.ToString(0x61))
                    {
                        flag4 = true;
                    }
                }
                if (flag3 || flag4)
                {
                    str3 = this.Session["IdVendedor"].ToString().Trim();
                    str4 = this.Session["IdZona"].ToString().Trim();
                    info2.Portal = "Pedido Rapido";
                    this.Session["Campana"] = info2.Campana;
                }
                if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x34)) || (this.Session["IdGrupo"].ToString() == Convert.ToString(60)))
                {
                    str3 = this.Session["IdVendedor"].ToString().Trim();
                    str4 = this.Session["IdZona"].ToString().Trim();
                    if (this.Session["Asistente"].ToString().Trim() != "")
                    {
                        str5 = this.Session["Asistente"].ToString().Trim();
                    }
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                {
                    info3 = new ClienteInfo();
                    info3 = new Cliente("conexion").ListClienteNivixNit(this.txt_nodocumento.Text);
                    str3 = info3.Vendedor.Trim();
                    str4 = info3.Zona.Trim();
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x3b))
                {
                    info3 = new ClienteInfo();
                    info3 = new Cliente("conexion").ListClienteNivixNit(this.txt_nodocumento.Text);
                    str3 = info3.Vendedor.Trim();
                    str4 = info3.Zona.Trim();
                    if (this.Session["Asistente"].ToString().Trim() != "")
                    {
                        str5 = this.Session["Asistente"].ToString().Trim();
                    }
                }
                if (flag4)
                {
                    ClienteInfo info4 = new ClienteInfo();
                    info4 = new Cliente("conexion").ListClienteNivixNit(this.txt_nodocumento.Text);
                    str3 = info4.Vendedor.Trim();
                    str4 = info4.Zona.Trim();
                }
                info2.Mes = DateTime.Now.Year.ToString() + str2;
                info2.Fecha = DateTime.Now;
                info2.Anulado = 0;
                info2.Espera = 0;
                info2.Despacho = DateTime.Now;
                info2.Nit = this.txt_nodocumento.Text;
                info2.Vendedor = str3.Trim();
                info2.IVA = this.IVA;
                info2.Valor = this.SubTotal;
                info2.Descuento = 0M;
                info2.FechaCreacion = DateTime.Now;
                info2.ClaveUsuario = this.Session["ClaveUsuario"].ToString().Trim();
                info2.Zona = str4.Trim();
                info2.CodigoNumeracion = "PEW";
                info2.Transmitido = 0;
                info2.Campana = this.rcb_campana.SelectedItem.Value;
                info2.NumeroEnvio = "";
                info2.NoFacturado = 0M;
                info2.Facturar = 0;
                info2.CodTipo = "004";
                info2.Devol = "";
                info2.Factura = "";
                info2.Orden = 0;
                info2.Procesado = false;
                info2.GeneraPremios = true;
                info2.IVAPrecioCat = this.IVAPrecioCat;
                info2.ValorPrecioCat = this.SubTotalPrecioCat;
                info2.Codigo = this.rcb_catalogo.SelectedValue;
                if ((this.Session["MostrarNombreGerente"] != null) && (this.Session["MostrarNombreGerente"].ToString() == "true"))
                {
                    info2.GuardarAuditoria = true;
                    info2.Usuario = this.Session["NombreUsuario"].ToString();
                }
                info2.IdLider = "N/A";
                info2.Reserva = true;
                info2.Borrador = true;
                info2.FechaCierreBorrador = DateTime.Now.AddDays(Convert.ToDouble(this.Session["DiasCierrePedidoBorrador"].ToString()));
                DateTime fechaCierreBorrador = info2.FechaCierreBorrador;
                this.strFechaCierreBorrador = fechaCierreBorrador.ToString();
                if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x34))
                {
                    info2.Portal = "GERENTE DE ZONA";
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                {
                    info2.Portal = "GERENTE DIVISIONAL";
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(60))
                {
                    info2.Portal = "LIDER";
                }
                if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x34))
                {
                    info3 = new ClienteInfo();
                    info3 = new Cliente("conexion").ListxNITSimpleEdit(info2.Nit);
                    info2.IdLider = !ReferenceEquals(info3, null) ? info3.Lider : this.Session["IdVendedor"].ToString();
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(60))
                {
                    if (this.Session["IdLider"] != null)
                    {
                        info2.IdLider = this.Session["IdLider"].ToString();
                    }
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                {
                    info3 = new ClienteInfo();
                    info3 = new Cliente("conexion").ListxNITSimpleEdit(info2.Nit);
                    info2.IdLider = !ReferenceEquals(info3, null) ? info3.Lider.Trim() : this.Session["IdVendedor"].ToString();
                }
                if (flag3)
                {
                    info3 = new ClienteInfo();
                    info2.IdLider = new Cliente("conexion").ListxNITSimpleEdit(info2.Nit).Lider.Trim();
                }
                if (this.Session["vstipoenviopedido"] == null)
                {
                    info2.TipoEnvio = (this.TipoEnvioCliente == 0) ? 1 : this.TipoEnvioCliente;
                }
                else if ((this.Session["vstipoenviopedido"].ToString() != "0") && (this.Session["vstipoenviopedido"].ToString() != ""))
                {
                    info2.TipoEnvio = Convert.ToInt32(this.Session["vstipoenviopedido"].ToString());
                }
                else
                {
                    info2.TipoEnvio = (this.TipoEnvioCliente == 0) ? 1 : this.TipoEnvioCliente;
                }
                info2.CiudadDespacho = this.CodCiudadDespacho;
                info2.Asistente = str5.Trim();
                str7 = cliente.Insert(info2);
                info2.Numero = str7;
                if ((str7 == "") || ReferenceEquals(str7, null))
                {
                    goto TR_0000;
                }
                else
                {
                    PedidosDetalleClienteInfo info8;
                    string str10;
                    this.IdPedido = str7;
                    this.IdPedidoRes = str7;
                    cliente5 = new PedidosDetalleCliente("conexion");
                    this.SubTotalPrecioCat = 0M;
                    this.IVAPrecioCat = 0M;
                    DescuentoGlod glod = new DescuentoGlod("conexion");
                    DescuentoInfo objA = new DescuentoInfo();
                    num4 = 0M;
                    num5 = 0M;
                    num6 = 0M;
                    num7 = 0M;
                    ArtExcentosxCiudad ciudad = new ArtExcentosxCiudad("conexion");
                    ArtExcentosxCiudadInfo info6 = new ArtExcentosxCiudadInfo();
                    string user = "";
                    if (this.Session["Usuario"] != null)
                    {
                        user = this.Session["Usuario"].ToString().Trim();
                    }
                    this.acumularPremio(this.txt_nodocumento.Text, Convert.ToString(num2).Replace(",", "."), str7, user);
                    if (flag2)
                    {
                        num3 = 0;
                        while (true)
                        {
                            flag12 = num3 < list.Count;
                            if (!flag12)
                            {
                                break;
                            }
                            info = list[num3];
                            int num8 = 0;
                            while (true)
                            {
                                flag12 = num8 < info.Cantidad;
                                if (!flag12)
                                {
                                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();
                                    objPedidosDetalleClienteInfo = this.agregarDetallePremio(objPedidosDetalleClienteInfo, info.PLU);
                                    objPedidosDetalleClienteInfo.IdCodigoCorto = str;
                                    objPedidosDetalleClienteInfo.Numero = str7;
                                    objPedidosDetalleClienteInfo.Referencia = info.Referencia;
                                    objPedidosDetalleClienteInfo.Descripcion = info.Descripcion;
                                    objPedidosDetalleClienteInfo.Cantidad = info.Cantidad;
                                    objPedidosDetalleClienteInfo.Anulado = 0;
                                    objPedidosDetalleClienteInfo.TarifaIVA = this.ConsultarIVA(objPedidosDetalleClienteInfo.Grupo);
                                    objPedidosDetalleClienteInfo.Lote = objPedidosDetalleClienteInfo.CentroCostos;
                                    objPedidosDetalleClienteInfo.Ensamblado = 0;
                                    objPedidosDetalleClienteInfo.CantidadPedida = info.Cantidad;
                                    objPedidosDetalleClienteInfo.IdDocumentoFuente = DateTime.Now.ToString();
                                    objPedidosDetalleClienteInfo.PLU = info.PLU;
                                    objPedidosDetalleClienteInfo.NumeroEnvio = 0M;
                                    objPedidosDetalleClienteInfo.ConceptoContable = objPedidosDetalleClienteInfo.ConceptoContable;
                                    objPedidosDetalleClienteInfo.CentroCostos = this.Session["IdZona"].ToString().Trim();
                                    objPedidosDetalleClienteInfo.Grupo = objPedidosDetalleClienteInfo.Grupo;
                                    objPedidosDetalleClienteInfo.Imagen = objPedidosDetalleClienteInfo.Imagen;
                                    objPedidosDetalleClienteInfo.CantidadNivelServicio = 0M;
                                    objPedidosDetalleClienteInfo.Catalogo = this.rcb_catalogo.SelectedValue;
                                    objPedidosDetalleClienteInfo.NumeroPedidoPadre = str7;
                                    objPedidosDetalleClienteInfo.CatalogoReal = objPedidosDetalleClienteInfo.Catalogo;
                                    objPedidosDetalleClienteInfo.CatalogoReal = info.Codigorapido;
                                    objPedidosDetalleClienteInfo.CodigoRapidoSustituto = "";
                                    objPedidosDetalleClienteInfo.PLUSustituto = 0M;
                                    objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.ValorPrecioCatalogo = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.ValorUnitario = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.IVAPrecioCatalogo = objPedidosDetalleClienteInfo.ValorPrecioCatalogo * (objPedidosDetalleClienteInfo.TarifaIVA / 100M);
                                    objPedidosDetalleClienteInfo.PorcentajeDescuento = 100M;
                                    objPedidosDetalleClienteInfo.Descuento = 100M;
                                    objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.Valor = 0M;
                                    cliente5.Insert(objPedidosDetalleClienteInfo);
                                    num3++;
                                    break;
                                }
                                this.redimirPremio(this.txt_nodocumento.Text, info.ValorMinimo, str7, user);
                                num8++;
                            }
                        }
                    }
                    IEnumerator enumerator = this.grdData.Items.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            string text;
                            int num1;
                            flag12 = enumerator.MoveNext();
                            if (!flag12)
                            {
                                break;
                            }
                            GridDataItem current = (GridDataItem)enumerator.Current;
                            if ((current["CodigoRapidoSustituto"].Text == "&NBSP;") || (current["CodigoRapidoSustituto"].Text == "&nbsp;"))
                            {
                                text = "";
                            }
                            else
                            {
                                text = current["CodigoRapidoSustituto"].Text;
                            }
                            info8 = this.AdicionarDetallePedido(Convert.ToInt32(current["PLU"].Text), Convert.ToDecimal(current["Cantidad"].Text), text, Convert.ToInt32(current["PLUSustituto"].Text));
                            if (this.ExcentoIVA)
                            {
                                info8.TarifaIVA = 0M;
                            }
                            else
                            {
                                if (current["CodigoRapido"].Text == "FL00")
                                {
                                    info8.Grupo = "FT0001";
                                }
                                info8.TarifaIVA = this.ConsultarIVA(info8.Grupo);
                            }
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                info8.Referencia = "FT0001";
                                info8.Descripcion = "MANEJO LOGISTICO - CIUDAD: " + this.CodCiudadCliente;
                                info8.Grupo = "FT0001";
                                info8.CentroCostos = info2.Zona;
                                info8.ConceptoContable = "005";
                                info8.CodigoUbicacion = "P000";
                                info8.Valor = Convert.ToDecimal(current["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", "")) / ((info8.TarifaIVA / 100M) + 1);
                                info8.Cantidad = 1M;
                                info8.PLU = 3357M;
                            }
                            if (this.ExcentoIVA)
                            {
                                info8.TarifaIVA = 0M;
                            }
                            else
                            {
                                info6 = ciudad.ListxCiudadxPlu(this.CodCiudadCliente, Convert.ToInt32(info8.PLU));
                                if (!ReferenceEquals(info6, null))
                                {
                                    info8.TarifaIVA = 0M;
                                }
                            }
                            info8.Numero = str7;
                            info8.Referencia = info8.Referencia;
                            info8.Descripcion = info8.Descripcion.Replace("<b>", "").Replace("</b>", "");
                            info8.Valor = info8.Valor;
                            info8.Cantidad = info8.Cantidad;
                            info8.Descuento = 0M;
                            info8.Anulado = 0;
                            info8.Lote = info8.CentroCostos;
                            info8.Ensamblado = 0;
                            info8.CantidadPedida = 0M;
                            info8.IdDocumentoFuente = "";
                            info8.CodigoUbicacion = info8.CodigoUbicacion;
                            info8.PLU = info8.PLU;
                            info8.NumeroEnvio = 0M;
                            info8.ConceptoContable = info8.ConceptoContable;
                            info8.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            info8.Grupo = info8.Grupo;
                            info8.Imagen = info8.Imagen;
                            info8.ValorPrecioCatalogo = info8.ValorPrecioCatalogo;
                            if (!this.ExcentoIVA)
                            {
                                info8.IVAPrecioCatalogo = ReferenceEquals(info6, null) ? (info8.ValorPrecioCatalogo * (this.ConsultarIVA(info8.Grupo) / 100M)) : 0M;
                            }
                            else
                            {
                                info8.IVAPrecioCatalogo = 0M;
                            }
                            info8.Catalogo = this.rcb_catalogo.SelectedValue;
                            info8.NumeroPedidoPadre = str7;
                            info8.ValorUnitario = info8.Valor / info8.Cantidad;
                            info8.IdCodigoCorto = current["CodigoRapido"].Text;
                            info8.CatalogoReal = current["CatalogoReal"].Text;
                            info8.UnidadNegocio = info8.UnidadNegocio;
                            string grupoCliente = "";
                            if (this.Session["grupoCliente"] != null)
                            {
                                grupoCliente = (string)this.Session["grupoCliente"];
                            }
                            objA = (info8.UnidadNegocio != "02") ? glod.ListxValorPedidoProdEstrellaXGrupoCliente(this.ValorTotalParaDescuento, info8.UnidadNegocio, info8.GrupoProducto, this.rcb_campana.SelectedItem.Value, false, grupoCliente) : glod.ListxValorPedidoProdEstrellaXGrupoCliente(this.ValorTotalParaDescuentoPisame, info8.UnidadNegocio, info8.GrupoProducto, this.rcb_campana.SelectedItem.Value, false, grupoCliente);
                            decimal porcentajeHogar = 0M;
                            if (ReferenceEquals(objA, null))
                            {
                                porcentajeHogar = 0M;
                            }
                            else if (info8.CatalogoReal.Trim().ToUpper().StartsWith("H"))
                            {
                                porcentajeHogar = objA.PorcentajeHogar;
                            }
                            else if (info8.CatalogoReal.Trim().ToUpper().StartsWith("T"))
                            {
                                porcentajeHogar = 0M;
                            }
                            else
                            {
                                porcentajeHogar = !info8.CatalogoReal.ToUpper().StartsWith("L") ? objA.Porcentaje : 0M;
                            }
                            info8.ValorPrecioCatalogoUnitario = info8.ValorPrecioCatalogo / info8.Cantidad;
                            info8.Valor = info8.ValorPrecioCatalogoUnitario - (info8.ValorPrecioCatalogoUnitario * (porcentajeHogar / 100M));
                            info8.PorcentajeDescuento = porcentajeHogar;
                            num4 += info8.Valor * info8.Cantidad;
                            num5 += (info8.Valor * info8.Cantidad) * (info8.TarifaIVA / 100M);
                            num6 += info8.ValorPrecioCatalogoUnitario * info8.Cantidad;
                            num7 += (info8.ValorPrecioCatalogoUnitario * info8.Cantidad) * (info8.TarifaIVA / 100M);
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                info8.CantidadPedida = 1M;
                                info8.CatalogoReal = this.rcb_catalogo.SelectedValue;
                                info8.ValorPrecioCatalogo = info8.ValorUnitario;
                                info8.IVAPrecioCatalogo = info8.ValorPrecioCatalogo * (this.ConsultarIVA(info8.Grupo) / 100M);
                            }
                            bool flag5 = true;
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                flag5 = false;
                            }
                            str10 = "";
                            decimal pLUSustituto = info8.PLUSustituto;
                            if ((info8.PLUSustituto == 0M) || (info8.CodigoRapidoSustituto == null))
                            {
                                num1 = 0;
                            }
                            else
                            {
                                num1 = (int)(info8.CodigoRapidoSustituto != "");
                            }
                            if (num1 == 0)
                            {
                                info8.PLUSustituto = 0M;
                                info8.CodigoRapidoSustituto = "";
                            }
                            if (flag5)
                            {
                                str10 = cliente5.Insert(info8);
                            }
                            flag = true;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        flag12 = ReferenceEquals(disposable, null);
                        if (!flag12)
                        {
                            disposable.Dispose();
                        }
                    }
                    if ((this.Session["recogePedidoTienda"] != null) && (((int)this.Session["recogePedidoTienda"]) == 1))
                    {
                        this.AdicionarFleteYPremios = false;
                    }
                    if (!this.AdicionarFleteYPremios)
                    {
                        goto TR_0001;
                    }
                    else
                    {
                        int num12;
                        bool tipoFlete = this.ValidarPedidoMinimoxTipoParaFlete();
                        info8 = new PedidosDetalleClienteInfo();
                        if (ReferenceEquals(this.CodCiudadDespacho, null))
                        {
                            info8 = this.AdicionarFletePedidoConCiudad(tipoFlete, this.IdPedido);
                        }
                        else if (this.CodCiudadDespacho == "")
                        {
                            info8 = (this.Session["vstipoenviopedido"].ToString() == "3") ? this.CrearDetalleFletePedidoParaLider() : this.CrearDetalleFletePedidoParaZona();
                        }
                        else
                        {
                            this.CodCiudadCliente = this.CodCiudadDespacho;
                            info8 = this.AdicionarFletePedidoConCiudad(tipoFlete, this.IdPedido);
                        }
                        if (this.ExcentoIVA)
                        {
                            info8.TarifaIVA = 0M;
                        }
                        else
                        {
                            if (info8.IdCodigoCorto == "FL00")
                            {
                                info8.Grupo = "FT0001";
                            }
                            info8.TarifaIVA = this.ConsultarIVA(info8.Grupo);
                        }
                        if (info8.IdCodigoCorto == "FL00")
                        {
                            info8.Referencia = "FT0001";
                            info8.Grupo = "FT0001";
                            info8.CentroCostos = info2.Zona;
                            info8.ConceptoContable = "005";
                            info8.CodigoUbicacion = "P000";
                            info8.Cantidad = 1M;
                            info8.PLU = 3357M;
                            info8.CantidadPedida = 1M;
                            info8.CatalogoReal = this.rcb_catalogo.SelectedValue;
                            info8.ValorPrecioCatalogo = info8.ValorUnitario;
                            info8.IVAPrecioCatalogo = info8.ValorPrecioCatalogo * (info8.TarifaIVA / 100M);
                            info8.PLUSustituto = 0M;
                            info8.CodigoRapidoSustituto = "";
                        }
                        decimal pLUSustituto = info8.PLUSustituto;
                        if ((info8.PLUSustituto == 0M) || (info8.CodigoRapidoSustituto == null))
                        {
                            num12 = 0;
                        }
                        else
                        {
                            num12 = (int)(info8.CodigoRapidoSustituto != "");
                        }
                        if (num12 == 0)
                        {
                            info8.PLUSustituto = 0M;
                            info8.CodigoRapidoSustituto = "";
                        }
                        num4 += info8.Valor * info8.Cantidad;
                        num5 += (info8.Valor * info8.Cantidad) * (info8.TarifaIVA / 100M);
                        num6 += info8.ValorPrecioCatalogoUnitario * info8.Cantidad;
                        num7 += (info8.ValorPrecioCatalogoUnitario * info8.Cantidad) * (info8.TarifaIVA / 100M);
                        str10 = cliente5.Insert(info8);
                        if (this.PremioBienvenida != 0)
                        {
                            goto TR_000E;
                        }
                        else
                        {
                            ParametrosInfo info9 = new ParametrosInfo();
                            info9 = new Parametros("conexion").ListxId(20);
                            if (ReferenceEquals(info9, null))
                            {
                                goto TR_000E;
                            }
                            else if (this.TotalPrecioCatalogoGlobal >= Convert.ToDecimal(info9.Valor))
                            {
                                int tipoPedidoMinimo = this.TipoPedidoMinimo;
                                List<PedidosDetalleClienteInfo> list2 = cliente5.ListPremiosBienvenidaActivos("0" + tipoPedidoMinimo.ToString());
                                flag12 = (list2 == null) || (list2.Count <= 0);
                                if (!flag12)
                                {
                                    using (enumerator2 = list2.GetEnumerator())
                                    {
                                        while (true)
                                        {
                                            flag12 = enumerator2.MoveNext();
                                            if (!flag12)
                                            {
                                                break;
                                            }
                                            PedidosDetalleClienteInfo current = enumerator2.Current;
                                            tipoPedidoMinimo = DateTime.Now.Second;
                                            str11 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + tipoPedidoMinimo.ToString();
                                            current.Id = this.IdPedido + "_PRE_" + str11;
                                            current.Numero = this.IdPedido;
                                            current.NumeroPedidoPadre = this.IdPedido;
                                            fechaCierreBorrador = DateTime.Now;
                                            current.IdDocumentoFuente = fechaCierreBorrador.ToString();
                                            current.Catalogo = this.rcb_catalogo.SelectedValue;
                                            current.CatalogoReal = current.Catalogo;
                                            current.IdCodigoCorto = "PRE00";
                                            current.PorcentajeDescuento = 0M;
                                            current.CentroCostos = this.Session["IdZona"].ToString().Trim();
                                            num4 += current.Valor * current.Cantidad;
                                            num5 += (current.Valor * current.Cantidad) * (current.TarifaIVA / 100M);
                                            num6 += current.ValorPrecioCatalogoUnitario * current.Cantidad;
                                            num7 += (current.ValorPrecioCatalogoUnitario * current.Cantidad) * (current.TarifaIVA / 100M);
                                            current.PLUSustituto = 0M;
                                            current.CodigoRapidoSustituto = "";
                                            str12 = cliente5.Insert(current);
                                            if ((str12 == "") || ReferenceEquals(str12, null))
                                            {
                                                auditoria = new Auditoria("conexion");
                                                info11 = new AuditoriaInfo
                                                {
                                                    FechaSistema = DateTime.Now,
                                                    Proceso = "No se pudo adicionar premio de bienvenida al pedido: " + this.IdPedido,
                                                    Usuario = this.Session["Usuario"].ToString().Trim()
                                                };
                                                auditoria.Insert(info11);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            }
            if (!new Cliente("conexion").UpdateEstadoPremioCliente(this.txt_nodocumento.Text))
            {
                auditoria = new Auditoria("conexion");
                info11 = new AuditoriaInfo
                {
                    FechaSistema = DateTime.Now,
                    Proceso = "No se pudo actualizar estado de premio de bienvenida al cliente con pedido: " + this.IdPedido,
                    Usuario = this.Session["Usuario"].ToString().Trim()
                };
                auditoria.Insert(info11);
            }
            goto TR_000E;
        TR_0000:
            this.lbl_numeropedido.Text = str7;
            this.lbl_numeropedido.ForeColor = System.Drawing.Color.Red;
            decimal num10 = (decimal)this.Session["valorpuntoensoles"];
            return flag;
        TR_0001:
            flag9 = cliente.UpdateValorPedidoSVDN(str7, num4, num5);
            bool flag10 = cliente.UpdateValorPrecioCatalogoPedidoSVDN(str7, num6, num7);
            goto TR_0000;
        TR_000E:
            if (!this.TienePedidoCampanaActual())
            {
                List<PedidosDetalleClienteInfo> list3 = cliente5.ListCatalogosSiguientes(this.rcb_campana.SelectedItem.Value.Trim());
                flag12 = (list3 == null) || (list3.Count <= 0);
                if (!flag12)
                {
                    using (enumerator2 = list3.GetEnumerator())
                    {
                        while (true)
                        {
                            flag12 = enumerator2.MoveNext();
                            if (!flag12)
                            {
                                break;
                            }
                            PedidosDetalleClienteInfo current = enumerator2.Current;
                            str11 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            current.Id = this.IdPedido + "_CAT_" + str11;
                            current.Numero = this.IdPedido;
                            current.NumeroPedidoPadre = this.IdPedido;
                            current.IdDocumentoFuente = DateTime.Now.ToString();
                            current.Catalogo = this.rcb_catalogo.SelectedValue;
                            current.CatalogoReal = current.Catalogo;
                            current.IdCodigoCorto = "CAT00";
                            current.PorcentajeDescuento = 0M;
                            current.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            num4 += current.Valor * current.Cantidad;
                            num5 += (current.Valor * current.Cantidad) * (current.TarifaIVA / 100M);
                            num6 += current.ValorPrecioCatalogoUnitario * current.Cantidad;
                            num7 += (current.ValorPrecioCatalogoUnitario * current.Cantidad) * (current.TarifaIVA / 100M);
                            current.PLUSustituto = 0M;
                            current.CodigoRapidoSustituto = "";
                            str12 = cliente5.Insert(current);
                            if ((str12 == "") || ReferenceEquals(str12, null))
                            {
                                auditoria = new Auditoria("conexion");
                                info11 = new AuditoriaInfo
                                {
                                    FechaSistema = DateTime.Now,
                                    Proceso = "No se pudo adicionar catalogo siguiente al pedido: " + this.IdPedido,
                                    Usuario = this.Session["Usuario"].ToString().Trim()
                                };
                                auditoria.Insert(info11);
                            }
                        }
                    }
                }
            }
            this.AdicionarFleteYPremios = false;
            goto TR_0001;
        }

        public bool GuardarPedidoDirecto()
        {
            PedidosCliente cliente;
            string str6;
            PedidosDetalleCliente cliente4;
            decimal num4;
            decimal num5;
            decimal num6;
            decimal num7;
            string str9;
            string str10;
            Auditoria auditoria;
            AuditoriaInfo info12;
            bool flag7;
            bool flag10;
            List<PedidosDetalleClienteInfo>.Enumerator enumerator2;
            bool flag = false;
            ZonaInfo info = new ZonaInfo();
            info = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
            this.Session["CodCiudadDespacho"] = info.CodLocalidad;
            bool flag2 = false;
            int num = 0;
            string str = "";
            PremiosNivelesInfo info2 = new PremiosNivelesInfo();
            List<PremiosNivelesInfo> list = new List<PremiosNivelesInfo>();
            decimal num2 = 0M;
            if ((this.Session["agregarPremio"] != null) || (this.Session["listaPremiosEmpresaria"] != null))
            {
                if (((int)this.Session["agregarPremio"]) == 1)
                {
                    flag2 = true;
                }
                if (this.Session["listaPremiosEmpresaria"] != null)
                {
                    flag2 = true;
                }
            }
            if (this.Session["nivelEmpresariaPremio"] != null)
            {
                num = (int)this.Session["nivelEmpresariaPremio"];
            }
            if (this.Session["idCortoPremioEmpresaria"] != null)
            {
                str = (string)this.Session["idCortoPremioEmpresaria"];
            }
            if (this.Session["premioEmpresaria"] != null)
            {
                info2 = (PremiosNivelesInfo)this.Session["premioEmpresaria"];
            }
            if (this.Session["listaPremiosEmpresaria"] != null)
            {
                list = (List<PremiosNivelesInfo>)this.Session["listaPremiosEmpresaria"];
            }
            int num3 = 0;
            while (true)
            {
                ClienteInfo info5;
                flag10 = num3 < this.PLUList.Count;
                if (flag10)
                {
                    num2 += this.PLUList[num3].PrecioCatalogoTotalConIVA;
                    num3++;
                    continue;
                }
                PedidosClienteInfo info3 = new PedidosClienteInfo();
                cliente = new PedidosCliente("conexion");
                string str2 = "00";
                if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
                {
                    str2 = "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    str2 = DateTime.Now.Month.ToString();
                }
                string str5 = "";
                ClienteInfo info4 = new ClienteInfo();
                info4 = new Cliente("conexion").ListClienteNivixNit(this.txt_nodocumento.Text);
                info3.Mes = DateTime.Now.Year.ToString() + str2;
                info3.Fecha = DateTime.Now;
                info3.Anulado = 0;
                info3.Espera = 0;
                info3.Despacho = DateTime.Now;
                info3.Nit = this.txt_nodocumento.Text.Trim();
                info3.Vendedor = info4.Vendedor.Trim().Trim();
                info3.IVA = this.IVA;
                info3.Valor = this.SubTotal;
                info3.Descuento = 0M;
                info3.FechaCreacion = DateTime.Now;
                info3.ClaveUsuario = this.Session["ClaveUsuario"].ToString().Trim();
                info3.Zona = info4.Zona.Trim().Trim();
                info3.CodigoNumeracion = "PEW";
                info3.Transmitido = 0;
                info3.Campana = this.rcb_campana.SelectedItem.Value;
                info3.NumeroEnvio = "";
                info3.NoFacturado = 0M;
                info3.Facturar = 0;
                info3.CodTipo = "004";
                info3.Devol = "";
                info3.Factura = "";
                info3.Orden = 0;
                info3.Procesado = false;
                info3.GeneraPremios = true;
                info3.IVAPrecioCat = this.IVAPrecioCat;
                info3.ValorPrecioCat = this.SubTotalPrecioCat;
                info3.Codigo = this.rcb_catalogo.SelectedValue;
                if ((this.Session["MostrarNombreGerente"] != null) && (this.Session["MostrarNombreGerente"].ToString() == "true"))
                {
                    info3.GuardarAuditoria = true;
                    info3.Usuario = this.Session["NombreUsuario"].ToString();
                }
                info3.IdLider = "N/A";
                info3.Reserva = true;
                info3.Borrador = true;
                info3.FechaCierreBorrador = DateTime.Now.AddDays(Convert.ToDouble(this.Session["DiasCierrePedidoBorrador"].ToString()));
                DateTime fechaCierreBorrador = info3.FechaCierreBorrador;
                this.strFechaCierreBorrador = fechaCierreBorrador.ToString();
                info3.Portal = "PEDIDO RAPIDO";
                this.Session["Campana"] = info3.Campana;
                if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x34))
                {
                    info5 = new ClienteInfo();
                    info5 = new Cliente("conexion").ListxNITSimpleEdit(info3.Nit);
                    info3.IdLider = !ReferenceEquals(info5, null) ? info5.Lider : this.Session["IdVendedor"].ToString();
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(60))
                {
                    if (this.Session["IdLider"] != null)
                    {
                        info3.IdLider = this.Session["IdLider"].ToString();
                    }
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                {
                    info5 = new ClienteInfo();
                    info5 = new Cliente("conexion").ListxNITSimpleEdit(info3.Nit);
                    info3.IdLider = !ReferenceEquals(info5, null) ? info5.Lider.Trim() : this.Session["IdVendedor"].ToString();
                }
                if (this.Session["vstipoenviopedido"] == null)
                {
                    info3.TipoEnvio = (this.TipoEnvioCliente == 0) ? 1 : this.TipoEnvioCliente;
                }
                else if ((this.Session["vstipoenviopedido"].ToString() != "0") && (this.Session["vstipoenviopedido"].ToString() != ""))
                {
                    info3.TipoEnvio = Convert.ToInt32(this.Session["vstipoenviopedido"].ToString());
                }
                else
                {
                    info3.TipoEnvio = (this.TipoEnvioCliente == 0) ? 1 : this.TipoEnvioCliente;
                }
                info3.CiudadDespacho = this.CodCiudadDespacho;
                info3.Asistente = str5.Trim();
                str6 = cliente.Insert(info3);
                info3.Numero = str6;
                if ((str6 == "") || ReferenceEquals(str6, null))
                {
                    goto TR_0003;
                }
                else
                {
                    PedidosDetalleClienteInfo info9;
                    string str8;
                    this.IdPedido = str6;
                    this.IdPedidoRes = str6;
                    cliente4 = new PedidosDetalleCliente("conexion");
                    this.SubTotalPrecioCat = 0M;
                    this.IVAPrecioCat = 0M;
                    DescuentoGlod glod = new DescuentoGlod("conexion");
                    DescuentoInfo objA = new DescuentoInfo();
                    num4 = 0M;
                    num5 = 0M;
                    num6 = 0M;
                    num7 = 0M;
                    ArtExcentosxCiudad ciudad = new ArtExcentosxCiudad("conexion");
                    ArtExcentosxCiudadInfo info7 = new ArtExcentosxCiudadInfo();
                    string user = "";
                    if (this.Session["Usuario"] != null)
                    {
                        user = this.Session["Usuario"].ToString().Trim();
                    }
                    this.acumularPremio(this.txt_nodocumento.Text, Convert.ToString(num2).Replace(",", "."), str6, user);
                    if (flag2)
                    {
                        num3 = 0;
                        while (true)
                        {
                            flag10 = num3 < list.Count;
                            if (!flag10)
                            {
                                break;
                            }
                            info2 = list[num3];
                            int num8 = 0;
                            while (true)
                            {
                                flag10 = num8 < info2.Cantidad;
                                if (!flag10)
                                {
                                    PedidosDetalleClienteInfo objPedidosDetalleClienteInfo = new PedidosDetalleClienteInfo();
                                    objPedidosDetalleClienteInfo = this.agregarDetallePremio(objPedidosDetalleClienteInfo, info2.PLU);
                                    objPedidosDetalleClienteInfo.IdCodigoCorto = str;
                                    objPedidosDetalleClienteInfo.Numero = str6;
                                    objPedidosDetalleClienteInfo.Referencia = info2.Referencia;
                                    objPedidosDetalleClienteInfo.Descripcion = info2.Descripcion;
                                    objPedidosDetalleClienteInfo.Cantidad = info2.Cantidad;
                                    objPedidosDetalleClienteInfo.Anulado = 0;
                                    objPedidosDetalleClienteInfo.TarifaIVA = this.ConsultarIVA(objPedidosDetalleClienteInfo.Grupo);
                                    objPedidosDetalleClienteInfo.Lote = objPedidosDetalleClienteInfo.CentroCostos;
                                    objPedidosDetalleClienteInfo.Ensamblado = 0;
                                    objPedidosDetalleClienteInfo.CantidadPedida = info2.Cantidad;
                                    objPedidosDetalleClienteInfo.IdDocumentoFuente = DateTime.Now.ToString();
                                    objPedidosDetalleClienteInfo.PLU = info2.PLU;
                                    objPedidosDetalleClienteInfo.NumeroEnvio = 0M;
                                    objPedidosDetalleClienteInfo.ConceptoContable = objPedidosDetalleClienteInfo.ConceptoContable;
                                    objPedidosDetalleClienteInfo.CentroCostos = this.Session["IdZona"].ToString().Trim();
                                    objPedidosDetalleClienteInfo.Grupo = objPedidosDetalleClienteInfo.Grupo;
                                    objPedidosDetalleClienteInfo.Imagen = objPedidosDetalleClienteInfo.Imagen;
                                    objPedidosDetalleClienteInfo.CantidadNivelServicio = 0M;
                                    objPedidosDetalleClienteInfo.Catalogo = this.rcb_catalogo.SelectedValue;
                                    objPedidosDetalleClienteInfo.NumeroPedidoPadre = str6;
                                    objPedidosDetalleClienteInfo.CatalogoReal = objPedidosDetalleClienteInfo.Catalogo;
                                    objPedidosDetalleClienteInfo.CatalogoReal = info2.Codigorapido;
                                    objPedidosDetalleClienteInfo.CodigoRapidoSustituto = "";
                                    objPedidosDetalleClienteInfo.PLUSustituto = 0M;
                                    objPedidosDetalleClienteInfo.Valor = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.ValorPrecioCatalogo = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.ValorUnitario = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.IVAPrecioCatalogo = objPedidosDetalleClienteInfo.ValorPrecioCatalogo * (objPedidosDetalleClienteInfo.TarifaIVA / 100M);
                                    objPedidosDetalleClienteInfo.PorcentajeDescuento = 100M;
                                    objPedidosDetalleClienteInfo.Descuento = 100M;
                                    objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario = objPedidosDetalleClienteInfo.ValorPrecioCatalogoUnitario;
                                    objPedidosDetalleClienteInfo.Valor = 0M;
                                    cliente4.Insert(objPedidosDetalleClienteInfo);
                                    num3++;
                                    break;
                                }
                                this.redimirPremio(this.txt_nodocumento.Text, info2.ValorMinimo, str6, user);
                                num8++;
                            }
                        }
                    }
                    IEnumerator enumerator = this.grdData.Items.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            string text;
                            int num1;
                            flag10 = enumerator.MoveNext();
                            if (!flag10)
                            {
                                break;
                            }
                            GridDataItem current = (GridDataItem)enumerator.Current;
                            if ((current["CodigoRapidoSustituto"].Text == "&NBSP;") || (current["CodigoRapidoSustituto"].Text == "&nbsp;"))
                            {
                                text = "";
                            }
                            else
                            {
                                text = current["CodigoRapidoSustituto"].Text;
                            }
                            info9 = this.AdicionarDetallePedido(Convert.ToInt32(current["PLU"].Text), Convert.ToDecimal(current["Cantidad"].Text), text, Convert.ToInt32(current["PLUSustituto"].Text));
                            if (this.ExcentoIVA)
                            {
                                info9.TarifaIVA = 0M;
                            }
                            else
                            {
                                if (current["CodigoRapido"].Text == "FL00")
                                {
                                    info9.Grupo = "FT0001";
                                }
                                info9.TarifaIVA = this.ConsultarIVA(info9.Grupo);
                            }
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                info9.Referencia = "FT0001";
                                info9.Descripcion = "MANEJO LOGISTICO - CIUDAD: " + this.CodCiudadCliente;
                                info9.Grupo = "FT0001";
                                info9.CentroCostos = info3.Zona;
                                info9.ConceptoContable = "005";
                                info9.CodigoUbicacion = "P000";
                                info9.Valor = Convert.ToDecimal(current["PrecioCatalogoTotalConIVA"].Text.Replace("$", "").Replace(" ", "")) / ((info9.TarifaIVA / 100M) + 1);
                                info9.Cantidad = 1M;
                                info9.PLU = 3357M;
                            }
                            if (this.ExcentoIVA)
                            {
                                info9.TarifaIVA = 0M;
                            }
                            else
                            {
                                info7 = ciudad.ListxCiudadxPlu(this.CodCiudadCliente, Convert.ToInt32(info9.PLU));
                                if (!ReferenceEquals(info7, null))
                                {
                                    info9.TarifaIVA = 0M;
                                }
                            }
                            info9.Numero = str6;
                            info9.Referencia = info9.Referencia;
                            info9.Descripcion = info9.Descripcion.Replace("<b>", "").Replace("</b>", "");
                            info9.Valor = info9.Valor;
                            info9.Cantidad = info9.Cantidad;
                            info9.Descuento = 0M;
                            info9.Anulado = 0;
                            info9.Lote = info9.CentroCostos;
                            info9.Ensamblado = 0;
                            info9.CantidadPedida = 0M;
                            info9.IdDocumentoFuente = "";
                            info9.CodigoUbicacion = info9.CodigoUbicacion;
                            info9.PLU = info9.PLU;
                            info9.NumeroEnvio = 0M;
                            info9.ConceptoContable = info9.ConceptoContable;
                            info9.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            info9.Grupo = info9.Grupo;
                            info9.Imagen = info9.Imagen;
                            info9.ValorPrecioCatalogo = info9.ValorPrecioCatalogo;
                            if (!this.ExcentoIVA)
                            {
                                info9.IVAPrecioCatalogo = ReferenceEquals(info7, null) ? (info9.ValorPrecioCatalogo * (this.ConsultarIVA(info9.Grupo) / 100M)) : 0M;
                            }
                            else
                            {
                                info9.IVAPrecioCatalogo = 0M;
                            }
                            info9.Catalogo = this.rcb_catalogo.SelectedValue;
                            info9.NumeroPedidoPadre = str6;
                            info9.ValorUnitario = info9.Valor / info9.Cantidad;
                            info9.IdCodigoCorto = current["CodigoRapido"].Text;
                            info9.CatalogoReal = current["CatalogoReal"].Text;
                            info9.UnidadNegocio = info9.UnidadNegocio;
                            objA = (info9.UnidadNegocio != "02") ? glod.ListxValorPedido(this.ValorTotalParaDescuento, info9.UnidadNegocio, info9.GrupoProducto, this.rcb_campana.SelectedItem.Value) : glod.ListxValorPedido(this.ValorTotalParaDescuentoPisame, info9.UnidadNegocio, info9.GrupoProducto, this.rcb_campana.SelectedItem.Value);
                            decimal porcentajeHogar = 0M;
                            if (ReferenceEquals(objA, null))
                            {
                                porcentajeHogar = 0M;
                            }
                            else if (info9.CatalogoReal.Trim().ToUpper().StartsWith("H"))
                            {
                                porcentajeHogar = objA.PorcentajeHogar;
                            }
                            else if (info9.CatalogoReal.Trim().ToUpper().StartsWith("T"))
                            {
                                porcentajeHogar = 0M;
                            }
                            else
                            {
                                porcentajeHogar = !info9.CatalogoReal.ToUpper().StartsWith("L") ? objA.Porcentaje : 0M;
                            }
                            info9.ValorPrecioCatalogoUnitario = info9.ValorPrecioCatalogo / info9.Cantidad;
                            info9.Valor = info9.ValorPrecioCatalogoUnitario - (info9.ValorPrecioCatalogoUnitario * (porcentajeHogar / 100M));
                            info9.PorcentajeDescuento = porcentajeHogar;
                            num4 += info9.Valor * info9.Cantidad;
                            num5 += (info9.Valor * info9.Cantidad) * (info9.TarifaIVA / 100M);
                            num6 += info9.ValorPrecioCatalogoUnitario * info9.Cantidad;
                            num7 += (info9.ValorPrecioCatalogoUnitario * info9.Cantidad) * (info9.TarifaIVA / 100M);
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                info9.CantidadPedida = 1M;
                                info9.CatalogoReal = this.rcb_catalogo.SelectedValue;
                                info9.ValorPrecioCatalogo = info9.ValorUnitario;
                                info9.IVAPrecioCatalogo = info9.ValorPrecioCatalogo * (this.ConsultarIVA(info9.Grupo) / 100M);
                            }
                            bool flag3 = true;
                            if (current["CodigoRapido"].Text == "FL00")
                            {
                                flag3 = false;
                            }
                            str8 = "";
                            decimal pLUSustituto = info9.PLUSustituto;
                            if ((info9.PLUSustituto == 0M) || (info9.CodigoRapidoSustituto == null))
                            {
                                num1 = 0;
                            }
                            else
                            {
                                num1 = (int)(info9.CodigoRapidoSustituto != "");
                            }
                            if (num1 == 0)
                            {
                                info9.PLUSustituto = 0M;
                                info9.CodigoRapidoSustituto = "";
                            }
                            if (flag3)
                            {
                                str8 = cliente4.Insert(info9);
                            }
                            flag = true;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        flag10 = ReferenceEquals(disposable, null);
                        if (!flag10)
                        {
                            disposable.Dispose();
                        }
                    }
                    if ((this.Session["recogePedidoTienda"] != null) && (((int)this.Session["recogePedidoTienda"]) == 1))
                    {
                        this.AdicionarFleteYPremios = false;
                    }
                    if (!this.AdicionarFleteYPremios)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        int num11;
                        bool tipoFlete = this.ValidarPedidoMinimoxTipoParaFlete();
                        info9 = new PedidosDetalleClienteInfo();
                        if (ReferenceEquals(this.CodCiudadDespacho, null))
                        {
                            info9 = this.AdicionarFletePedidoConCiudad(tipoFlete, this.IdPedido);
                        }
                        else if (this.CodCiudadDespacho == "")
                        {
                            info9 = (this.Session["vstipoenviopedido"].ToString() == "3") ? this.CrearDetalleFletePedidoParaLider() : this.CrearDetalleFletePedidoParaZona();
                        }
                        else
                        {
                            this.CodCiudadCliente = this.CodCiudadDespacho;
                            info9 = this.AdicionarFletePedidoConCiudad(tipoFlete, this.IdPedido);
                        }
                        if (this.ExcentoIVA)
                        {
                            info9.TarifaIVA = 0M;
                        }
                        else
                        {
                            if (info9.IdCodigoCorto == "FL00")
                            {
                                info9.Grupo = "FT0001";
                            }
                            info9.TarifaIVA = this.ConsultarIVA(info9.Grupo);
                        }
                        if (info9.IdCodigoCorto == "FL00")
                        {
                            info9.Referencia = "FT0001";
                            info9.Grupo = "FT0001";
                            info9.CentroCostos = info3.Zona;
                            info9.ConceptoContable = "005";
                            info9.CodigoUbicacion = "P000";
                            info9.Cantidad = 1M;
                            info9.PLU = 3357M;
                            info9.CantidadPedida = 1M;
                            info9.CatalogoReal = this.rcb_catalogo.SelectedValue;
                            info9.ValorPrecioCatalogo = info9.ValorUnitario;
                            info9.IVAPrecioCatalogo = info9.ValorPrecioCatalogo * (info9.TarifaIVA / 100M);
                            info9.PLUSustituto = 0M;
                            info9.CodigoRapidoSustituto = "";
                        }
                        decimal pLUSustituto = info9.PLUSustituto;
                        if ((info9.PLUSustituto == 0M) || (info9.CodigoRapidoSustituto == null))
                        {
                            num11 = 0;
                        }
                        else
                        {
                            num11 = (int)(info9.CodigoRapidoSustituto != "");
                        }
                        if (num11 == 0)
                        {
                            info9.PLUSustituto = 0M;
                            info9.CodigoRapidoSustituto = "";
                        }
                        num4 += info9.Valor * info9.Cantidad;
                        num5 += (info9.Valor * info9.Cantidad) * (info9.TarifaIVA / 100M);
                        num6 += info9.ValorPrecioCatalogoUnitario * info9.Cantidad;
                        num7 += (info9.ValorPrecioCatalogoUnitario * info9.Cantidad) * (info9.TarifaIVA / 100M);
                        str8 = cliente4.Insert(info9);
                        if (this.PremioBienvenida != 0)
                        {
                            goto TR_0012;
                        }
                        else
                        {
                            ParametrosInfo info10 = new ParametrosInfo();
                            info10 = new Parametros("conexion").ListxId(20);
                            if (ReferenceEquals(info10, null))
                            {
                                goto TR_0012;
                            }
                            else if (this.TotalPrecioCatalogoGlobal >= Convert.ToDecimal(info10.Valor))
                            {
                                int tipoPedidoMinimo = this.TipoPedidoMinimo;
                                List<PedidosDetalleClienteInfo> list2 = cliente4.ListPremiosBienvenidaActivos("0" + tipoPedidoMinimo.ToString());
                                flag10 = (list2 == null) || (list2.Count <= 0);
                                if (!flag10)
                                {
                                    using (enumerator2 = list2.GetEnumerator())
                                    {
                                        while (true)
                                        {
                                            flag10 = enumerator2.MoveNext();
                                            if (!flag10)
                                            {
                                                break;
                                            }
                                            PedidosDetalleClienteInfo current = enumerator2.Current;
                                            tipoPedidoMinimo = DateTime.Now.Second;
                                            str9 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + tipoPedidoMinimo.ToString();
                                            current.Id = this.IdPedido + "_PRE_" + str9;
                                            current.Numero = this.IdPedido;
                                            current.NumeroPedidoPadre = this.IdPedido;
                                            fechaCierreBorrador = DateTime.Now;
                                            current.IdDocumentoFuente = fechaCierreBorrador.ToString();
                                            current.Catalogo = this.rcb_catalogo.SelectedValue;
                                            current.CatalogoReal = current.Catalogo;
                                            current.IdCodigoCorto = "PRE00";
                                            current.PorcentajeDescuento = 0M;
                                            current.CentroCostos = this.Session["IdZona"].ToString().Trim();
                                            num4 += current.Valor * current.Cantidad;
                                            num5 += (current.Valor * current.Cantidad) * (current.TarifaIVA / 100M);
                                            num6 += current.ValorPrecioCatalogoUnitario * current.Cantidad;
                                            num7 += (current.ValorPrecioCatalogoUnitario * current.Cantidad) * (current.TarifaIVA / 100M);
                                            current.PLUSustituto = 0M;
                                            current.CodigoRapidoSustituto = "";
                                            str10 = cliente4.Insert(current);
                                            if ((str10 == "") || ReferenceEquals(str10, null))
                                            {
                                                auditoria = new Auditoria("conexion");
                                                info12 = new AuditoriaInfo
                                                {
                                                    FechaSistema = DateTime.Now,
                                                    Proceso = "No se pudo adicionar premio de bienvenida al pedido: " + this.IdPedido,
                                                    Usuario = this.Session["Usuario"].ToString().Trim()
                                                };
                                                auditoria.Insert(info12);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            }
            if (!new Cliente("conexion").UpdateEstadoPremioCliente(this.txt_nodocumento.Text))
            {
                auditoria = new Auditoria("conexion");
                info12 = new AuditoriaInfo
                {
                    FechaSistema = DateTime.Now,
                    Proceso = "No se pudo actualizar estado de premio de bienvenida al cliente con pedido: " + this.IdPedido,
                    Usuario = this.Session["Usuario"].ToString().Trim()
                };
                auditoria.Insert(info12);
            }
            goto TR_0012;
        TR_0003:
            this.lbl_numeropedido.Text = str6;
            this.lbl_numeropedido.ForeColor = System.Drawing.Color.Red;
            if ((this.Session["recogePedidoTienda"] != null) && (((int)this.Session["recogePedidoTienda"]) == 1))
            {
                new Inventario().eliminarFlete(str6);
            }
            return flag;
        TR_0005:
            flag7 = cliente.UpdateValorPedidoSVDN(str6, num4, num5);
            bool flag8 = cliente.UpdateValorPrecioCatalogoPedidoSVDN(str6, num6, num7);
            goto TR_0003;
        TR_0012:
            if (!this.TienePedidoCampanaActual())
            {
                List<PedidosDetalleClienteInfo> list3 = cliente4.ListCatalogosSiguientes(this.rcb_campana.SelectedItem.Value.Trim());
                flag10 = (list3 == null) || (list3.Count <= 0);
                if (!flag10)
                {
                    using (enumerator2 = list3.GetEnumerator())
                    {
                        while (true)
                        {
                            flag10 = enumerator2.MoveNext();
                            if (!flag10)
                            {
                                break;
                            }
                            PedidosDetalleClienteInfo current = enumerator2.Current;
                            str9 = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            current.Id = this.IdPedido + "_CAT_" + str9;
                            current.Numero = this.IdPedido;
                            current.NumeroPedidoPadre = this.IdPedido;
                            current.IdDocumentoFuente = DateTime.Now.ToString();
                            current.Catalogo = this.rcb_catalogo.SelectedValue;
                            current.CatalogoReal = current.Catalogo;
                            current.IdCodigoCorto = "CAT00";
                            current.PorcentajeDescuento = 0M;
                            current.CentroCostos = this.Session["IdZona"].ToString().Trim();
                            num4 += current.Valor * current.Cantidad;
                            num5 += (current.Valor * current.Cantidad) * (current.TarifaIVA / 100M);
                            num6 += current.ValorPrecioCatalogoUnitario * current.Cantidad;
                            num7 += (current.ValorPrecioCatalogoUnitario * current.Cantidad) * (current.TarifaIVA / 100M);
                            current.PLUSustituto = 0M;
                            current.CodigoRapidoSustituto = "";
                            str10 = cliente4.Insert(current);
                            if ((str10 == "") || ReferenceEquals(str10, null))
                            {
                                auditoria = new Auditoria("conexion");
                                info12 = new AuditoriaInfo
                                {
                                    FechaSistema = DateTime.Now,
                                    Proceso = "No se pudo adicionar catalogo siguiente al pedido: " + this.IdPedido,
                                    Usuario = this.Session["Usuario"].ToString().Trim()
                                };
                                auditoria.Insert(info12);
                            }
                        }
                    }
                }
            }
            this.AdicionarFleteYPremios = false;
            goto TR_0005;
        }

        public bool GuardarPedidoReservaEnLinea(string NumeroPedido)
        {
            string bodega = "";
            if (this.Session["bodegaEmpresaria"] != null)
            {
                bodega = (string)this.Session["bodegaEmpresaria"];
            }
            int cobrarFlete = 1;
            bool flag5 = this.Session["recogePedidoTienda"] == null;
            if (!flag5)
            {
                flag5 = ((int)this.Session["recogePedidoTienda"]) != 1;
                if (!flag5)
                {
                    cobrarFlete = 0;
                }
            }
            ReservaEnLineaGlod glod = new ReservaEnLineaGlod("conexion");
            PedidosCliente cliente = new PedidosCliente("conexion");
            bool flag = false;
            try
            {
                if (glod.RealizarReservaEnLineaDifBodega(NumeroPedido, bodega, cobrarFlete) == "")
                {
                    return flag;
                }
                else if (this.Session["sisPuntosAct"] != null)
                {
                    flag5 = ((int)this.Session["sisPuntosAct"]) != 1;
                    if (!flag5)
                    {
                        try
                        {
                            decimal valorPuntos = (decimal)this.Session["valorpuntoensoles"];
                            int totalPedidoPuntos = 0;
                            int totalDescuentoPuntos = 0;
                            int bonopuntosganar = 0;
                            decimal descuentoporpuntos = 0M;
                            int cantpuntosGastados = 0;
                            string text = this.txt_nodocumento.Text;
                            if (this.Session["totalPedidoPuntos"] != null)
                            {
                                totalPedidoPuntos = (int)this.Session["totalPedidoPuntos"];
                            }
                            flag5 = this.Session["pagadoPuntos"] == null;
                            if (!flag5)
                            {
                                totalDescuentoPuntos = (int)this.Session["pagadoPuntos"];
                            }
                            this.gastarPuntos(cantpuntosGastados, text);
                            this.acumularPuntosxEstado(totalPedidoPuntos, totalDescuentoPuntos, bonopuntosganar, descuentoporpuntos, text);
                            this.agregarDescuentoPuntos(valorPuntos, totalPedidoPuntos, totalDescuentoPuntos);
                            this.actualizarEncabezadoPuntosxCedula(text);
                        }
                        catch
                        {
                        }
                    }
                }
                ParametrosInfo info = new ParametrosInfo();
                if (((new Parametros("conexion").ListxId(0x1b).Valor == "SI") && new Cliente("conexion").BuscaDemanteladora(this.txt_nodocumento.Text, this.Session["IdZona"].ToString())) && !cliente.UpdateEstadoDesmanteladoPedido(this.IdPedido, this.txt_nodocumento.Text, this.Session["IdZona"].ToString(), this.Session["NombreUsuario"].ToString()))
                {
                    this.RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('No se pudo actualizar el estado del pedido " + this.IdPedido + " a desmateladora, Porfavor contacte a soporte de Informatica Niviglobal.');");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void HabilitarControles(bool Estado)
        {
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["espedidoPreventa"] = null;
            base.Response.Redirect("PedidosRapidoCodRes.aspx");
        }

        protected void img_adicionar_Click(object sender, ImageClickEventArgs e)
        {
            this.AdicionarArticulo();
            this.actualizarTotalpagermenospuntos();
            this.mostrarAmarres();
        }

        protected void img_buscarempresaria_Click(object sender, ImageClickEventArgs e)
        {
            this.lbl_nombreempresaria.Text = this.ValidaExisteEmpresariaNombre(this.txt_nodocumento.Text);
        }

        protected void img_otracantidad_Click(object sender, ImageClickEventArgs e)
        {
            if (this.txt_cantidad.Text != "")
            {
                this.ValorTotal(Convert.ToInt32(this.txt_cantidad.Text));
            }
            else
            {
                this.RadWindowManager1.RadAlert("Debe ingresar una cantidad.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
        }

        private void insertarAmarre()
        {
        }

        protected void LblTextoAdicionar_Click(object sender, EventArgs e)
        {
            this.AdicionarArticulo();
            this.actualizarTotalpagermenospuntos();
            this.mostrarAmarres();
        }

        private void LimpiarReferencia()
        {
            this.rcb_codigorapido_loc.Text = "";
            this.rcb_codigorapido_loc.ClearSelection();
            this.rcb_nombrearticulo.Text = "";
            this.rcb_nombrearticulo.Items.Clear();
            this.rcb_nombrearticulo.ClearSelection();
            this.rcb_preciounitario.Text = "";
            this.rcb_preciounitario.Items.Clear();
            this.rcb_preciounitario.ClearSelection();
            this.rcb_preciototal.Text = "";
            this.rcb_preciototal.Items.Clear();
            this.rcb_preciototal.ClearSelection();
            this.rcb_cantidad.ClearSelection();
            this.txt_cantidad.Text = "";
            this.rcb_codigorapido.Text = "";
            this.rcb_codigorapido_loc.Text = "";
            this.CantidadSeleccionada = 0;
        }

        private void ListPedidoxId(string IdPedido)
        {
            bool flag;
            this.txt_nodocumento.ReadOnly = true;
            this.lbl_numeropedido.Text = IdPedido;
            this.lbl_numeropedido.ForeColor = System.Drawing.Color.Red;
            PedidosClienteInfo objA = new PedidosClienteInfo();
            objA = new PedidosCliente("conexion").ListPedidoxId(IdPedido);
            if (!ReferenceEquals(objA, null))
            {
                this.txt_nodocumento.Text = objA.Nit;
                this.Session["bodegaEmpresaria"] = new BodegaGlod().getbodegaEmpresaria(objA.Nit);
                this.Session["recogePedidoTienda"] = (objA.CobrarFlete != 0) ? 0 : 1;
                this.lbl_nombreempresaria.Text = this.ValidaExisteEmpresariaNombre(this.txt_nodocumento.Text);
                this.lbl_nombreempresaria.ForeColor = System.Drawing.Color.Green;
                this.strFechaCierreBorrador = objA.FechaCierreBorrador.ToString();
                if (this.Session["vstipoenviopedido"] != null)
                {
                    this.Session["vstipoenviopedido"] = ((this.Session["vstipoenviopedido"].ToString() == "0") || (this.Session["vstipoenviopedido"].ToString() == "")) ? Convert.ToString(1) : Convert.ToString(objA.TipoEnvio);
                }
                else
                {
                    this.Session["vstipoenviopedido"] = Convert.ToString(1);
                }
                ClienteInfo info2 = new ClienteInfo();
                info2 = new Cliente("conexion").ListClienteSVDNxNit(objA.Nit);
                if (!ReferenceEquals(info2, null))
                {
                    this.TipoPedidoMinimo = info2.TipoPedidoMinimo;
                    this.CodCiudadCliente = info2.CodCiudad;
                    this.PremioBienvenida = info2.Premio;
                }
                this.LoadCatalogos();
                this.LoadCampanas();
                List<CampanaInfo> list = new List<CampanaInfo>();
                list = new Campana("conexion").Listxidpreventa(this.rcb_campana.SelectedItem.Value);
                flag = (list == null) || (list.Count <= 0);
                if (!flag)
                {
                    this.rcb_campana.DataTextField = "Campana";
                    this.rcb_campana.DataValueField = "Campana";
                    this.rcb_campana.DataSource = list;
                    this.rcb_campana.DataBind();
                }
                else
                {
                    this.rcb_campana.Text = "";
                    this.rcb_campana.SelectedValue = "";
                    this.rcb_campana.ClearSelection();
                    this.rcb_campana.Items.Clear();
                }
                this.rcb_campana.SelectedValue = objA.Campana;
                Campana campana2 = new Campana("conexion");
                CampanaInfo info3 = new CampanaInfo();
                try
                {
                    info3 = campana2.ListxCampana(this.rcb_campana.SelectedValue);
                    this.rcb_catalogo.Enabled = true;
                    RadComboBoxItem item = new RadComboBoxItem
                    {
                        Text = "CATALOGO NIVI",
                        Value = info3.Catalogo
                    };
                    this.rcb_catalogo.Items.Add(item);
                    this.rcb_catalogo.SelectedValue = info3.Catalogo;
                    this.rcb_catalogo.Enabled = false;
                    flag = this.rcb_campana.SelectedValue != this.Session["Campana"].ToString();
                    this.Label9.Visible = flag;
                }
                catch (Exception)
                {
                }
            }
            ArtExcentosxCiudad ciudad = new ArtExcentosxCiudad("conexion");
            ArtExcentosxCiudadInfo info4 = new ArtExcentosxCiudadInfo();
            List<PedidosDetalleClienteInfo> list2 = new List<PedidosDetalleClienteInfo>();
            list2 = new PedidosDetalleCliente("conexion").ListPedidoDetallexIdxReserva(IdPedido);
            CatalogoPlu plu = new CatalogoPlu("conexion");
            flag = (list2.Count <= 0) || ReferenceEquals(list2, null);
            if (flag)
            {
                this.grdData.DataSource = new List<PedidosDetalleClienteInfo>();
            }
            else
            {
                using (List<PedidosDetalleClienteInfo>.Enumerator enumerator = list2.GetEnumerator())
                {
                    while (true)
                    {
                        flag = enumerator.MoveNext();
                        if (!flag)
                        {
                            break;
                        }
                        PedidosDetalleClienteInfo current = enumerator.Current;
                        CatalogoPluInfo info6 = new CatalogoPluInfo();
                        if (current.IdCodigoCorto != "N/A")
                        {
                            info6 = plu.ListxCodigoRapidoSinCatalogoSinBloqueo(current.IdCodigoCorto);
                            if (!ReferenceEquals(info6, null))
                            {
                                PLUInfo item = new PLUInfo
                                {
                                    PLU = Convert.ToInt32(info6.PLU)
                                };
                                if (item.PLU != 0xd1d)
                                {
                                    if (ReferenceEquals(ciudad.ListxCiudadxPlu(this.CodCiudadCliente, Convert.ToInt32(item.PLU)), null))
                                    {
                                        item.IVAPrecioCatalogo = current.IVAPrecioCatalogo;
                                    }
                                    else
                                    {
                                        current.TarifaIVA = 0M;
                                        item.IVAPrecioCatalogo = 0M;
                                    }
                                    item.PrecioConIVA = Convert.ToDecimal((decimal)(current.Valor + ((current.Valor * current.TarifaIVA) / 100M)));
                                    item.PrecioTotalConIVA = Convert.ToDecimal((decimal)(current.Valor + ((current.Valor * current.TarifaIVA) / 100M))) * current.Cantidad;
                                    item.PrecioCatalogoSinIVA = current.ValorPrecioCatalogo;
                                    item.PrecioCatalogoTotalConIVA = item.PrecioCatalogoSinIVA + item.IVAPrecioCatalogo;
                                }
                                else
                                {
                                    ZonaInfo info8 = new ZonaInfo();
                                    info8 = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
                                    if (!ReferenceEquals(info8, null))
                                    {
                                        if (ReferenceEquals(ciudad.ListxCiudadxPlu(this.CodCiudadCliente, Convert.ToInt32(item.PLU)), null))
                                        {
                                            item.IVAPrecioCatalogo = Convert.ToDecimal((decimal)((info8.ValorFlete * current.TarifaIVA) / 100M));
                                        }
                                        else
                                        {
                                            current.TarifaIVA = 0M;
                                            item.IVAPrecioCatalogo = 0M;
                                        }
                                        item.PrecioConIVA = Convert.ToDecimal((decimal)(info8.ValorFlete + ((info8.ValorFlete * current.TarifaIVA) / 100M)));
                                        item.PrecioTotalConIVA = Convert.ToDecimal((decimal)(info8.ValorFlete + ((info8.ValorFlete * current.TarifaIVA) / 100M)));
                                        item.Cantidad = Convert.ToInt32(current.Cantidad);
                                        item.PrecioCatalogoSinIVA = Convert.ToDecimal(info8.ValorFlete);
                                        item.PrecioCatalogoTotalConIVA = item.PrecioTotalConIVA;
                                    }
                                }
                                item.Cantidad = Convert.ToInt32(current.Cantidad);
                                item.CodigoRapido = current.IdCodigoCorto;
                                item.FechaCreacion = current.FechaCreacion;
                                item.CatalogoReal = current.CatalogoReal;
                                item.NombreProducto = current.Descripcion;
                                item.CodigoRapidoSustituto = current.CodigoRapidoSustituto;
                                item.PLUSustituto = Convert.ToInt32(current.PLUSustituto);
                                DescuentoGlod glod2 = new DescuentoGlod();
                                this.PLUList.Add(item);
                            }
                        }
                    }
                }
            }
        }

        protected void lkb_otracantidad_Click(object sender, EventArgs e)
        {
            this.txt_cantidad.Text = "";
            this.img_otracantidad.Visible = true;
            this.lkb_otracantidad.Visible = false;
            this.txt_cantidad.Visible = true;
            this.rcb_cantidad.Visible = false;
        }

        public void loadBodegasCombo()
        {
            List<BodegaInfo> list = new BodegaGlod().ListAll();
            if ((list != null) && (list.Count > 0))
            {
                this.RadComboBox1SelectBodega.DataTextField = "nombre";
                this.RadComboBox1SelectBodega.DataValueField = "bodega";
                this.RadComboBox1SelectBodega.DataSource = list;
                this.RadComboBox1SelectBodega.DataBind();
            }
            else
            {
                this.RadComboBox1SelectBodega.Text = "";
                this.RadComboBox1SelectBodega.SelectedValue = "";
                this.RadComboBox1SelectBodega.ClearSelection();
                this.RadComboBox1SelectBodega.Items.Clear();
            }
        }

        protected void LoadCampanas()
        {
            List<CampanaInfo> list = new List<CampanaInfo>();
            Campana campana = new Campana("conexion");
            if (!ReferenceEquals(this.rcb_catalogo.SelectedItem, null))
            {
                list = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListCampanasXCatalogo(this.rcb_catalogo.SelectedItem.Value) : campana.ListxCampanaLista(this.Session["Campana"].ToString());
            }
            if ((list != null) && (list.Count > 0))
            {
                this.rcb_campana.DataTextField = "Campana";
                this.rcb_campana.DataValueField = "Campana";
                this.rcb_campana.DataSource = list;
                this.rcb_campana.DataBind();
            }
            else
            {
                this.rcb_campana.Text = "";
                this.rcb_campana.SelectedValue = "";
                this.rcb_campana.ClearSelection();
                this.rcb_campana.Items.Clear();
            }
            this.rcb_campana.MaxHeight = 60;
            if (list.Count == 0)
            {
                this.DeshabilitarControles();
                this.RadWindowManager1.RadAlert("No se pueden crear pedidos en este periodo.<br>La campa\x00f1a no ha sido habilitada.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");
            }
        }

        protected void LoadCatalogos()
        {
            int num1;
            List<CatalogoInfo> list = new List<CatalogoInfo>();
            Catalogo catalogo = new Catalogo("conexion");
            if ((this.Session["Catalogo"] == null) || (this.Session["Catalogo"].ToString() == ""))
            {
                num1 = 1;
            }
            else
            {
                num1 = (int)(this.Session["ZonaReservaEnLinea"].ToString() != "true");
            }
            list = num1 ? catalogo.ListCatalogoFechaActual() : catalogo.ListxId(this.Session["Catalogo"].ToString());
            if ((list != null) && (list.Count > 0))
            {
                this.rcb_catalogo.DataTextField = "GrupoCatalogo";
                this.rcb_catalogo.DataValueField = "Codigo";
                this.rcb_catalogo.DataSource = list;
                this.rcb_catalogo.DataBind();
            }
            else
            {
                this.rcb_catalogo.Text = "";
                this.rcb_catalogo.SelectedValue = "";
                this.rcb_catalogo.ClearSelection();
                this.rcb_catalogo.Items.Clear();
            }
            this.rcb_catalogo.MaxHeight = 60;
            if (list.Count == 0)
            {
                this.DeshabilitarControles();
                this.RadWindowManager1.RadAlert("No se pueden crear pedidos en este periodo.<br>El catalogo no ha sido habilitado.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");
            }
        }

        protected void LoadCodigoRapido(string Catalogo)
        {
            List<CatalogoPluInfo> list = new List<CatalogoPluInfo>();
            list = new CatalogoPlu("conexion").ListxIdCodigoRapidoxCatalogo(Catalogo);
            if ((list != null) && (list.Count > 0))
            {
                this.rcb_codigorapido_loc.DataTextField = "IdCodigoCorto";
                this.rcb_codigorapido_loc.DataValueField = "IdCodigoCorto";
                this.rcb_codigorapido_loc.DataSource = list;
                this.rcb_codigorapido_loc.DataBind();
            }
            else
            {
                this.rcb_codigorapido_loc.Text = "";
                this.rcb_codigorapido_loc.SelectedValue = "";
                this.rcb_codigorapido_loc.ClearSelection();
                this.rcb_codigorapido_loc.Items.Clear();
            }
            this.rcb_codigorapido_loc.Items.Insert(0, new RadComboBoxItem(" "));
            this.rcb_codigorapido_loc.MaxHeight = 60;
            this.rcb_codigorapido_loc.SelectedValue = "";
            this.rcb_codigorapido_loc.Text = "";
        }

        public void mostrarAmarres()
        {
            string str = "";
            string str2 = "";
            if ((this.Session["current_tiene_amarre"] != null) && (((int)this.Session["current_tiene_amarre"]) == 1))
            {
                if (this.Session["last_codigo_rapido"] != null)
                {
                    str = (string)this.Session["last_codigo_rapido"];
                }
                if (this.Session["last_catalogo_real"] != null)
                {
                    str2 = (string)this.Session["last_catalogo_real"];
                }
                ScriptManager.RegisterClientScriptBlock((Page)this, base.GetType(), "Javascript", "VerAmarres('" + str + "','" + str2 + "'); ", true);
            }
        }

        private void MostrarDescuentoTemporal()
        {
            string script = "<script language='javascript'>function f(){MostrarDescuento(); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", script);
        }

        public void mostrarInterfazPuntos()
        {
            if (this.Session["sisPuntosAct"] == null)
            {
                this.Label8.Visible = false;
                this.Labeltuspuntos.Visible = false;
                this.RadComboBoxSaldoPuntos.Visible = false;
                this.LabelValoraPagar.Visible = false;
                this.RadComboBox1SaldoPagar.Visible = false;
                this.LabelPuntosaUsar.Visible = false;
                this.RadNumericPuntosUsar.Visible = false;
                this.LabelTotalPagarDespuesPuntos.Visible = false;
                this.RadComboBoxTotalpagardespuesPuntos.Visible = false;
                this.RadComboBoxPrecioPuntos.Visible = false;
                this.Label10.Visible = false;
            }
            else if (((int)this.Session["sisPuntosAct"]) == 1)
            {
                this.Label8.Visible = true;
                this.Labeltuspuntos.Visible = true;
                this.RadComboBoxSaldoPuntos.Visible = true;
                this.LabelValoraPagar.Visible = true;
                this.RadComboBox1SaldoPagar.Visible = true;
                this.LabelPuntosaUsar.Visible = true;
                this.RadNumericPuntosUsar.Visible = true;
                this.LabelTotalPagarDespuesPuntos.Visible = true;
                this.RadComboBoxTotalpagardespuesPuntos.Visible = true;
                this.RadComboBoxPrecioPuntos.Visible = true;
                this.Label10.Visible = true;
            }
            else
            {
                this.Label8.Visible = false;
                this.Labeltuspuntos.Visible = false;
                this.RadComboBoxSaldoPuntos.Visible = false;
                this.LabelValoraPagar.Visible = false;
                this.RadComboBox1SaldoPagar.Visible = false;
                this.LabelPuntosaUsar.Visible = false;
                this.RadNumericPuntosUsar.Visible = false;
                this.LabelTotalPagarDespuesPuntos.Visible = false;
                this.RadComboBoxTotalpagardespuesPuntos.Visible = false;
                this.RadComboBoxPrecioPuntos.Visible = false;
                this.Label10.Visible = false;
            }
        }

        public void mostrarPopupPedidoMinimoNivi()
        {
            string script = "<script language='javascript'>function f(){ VerAnuncioPedidoMinimoNivi();}; Sys.Application.add_load(f);</script>";
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", script);
        }

        public void mostrarPopupReprogramacion()
        {
            string script = "<script language='javascript'>function f(){ VerAnuncioReprogramacion();}; Sys.Application.add_load(f);</script>";
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", script);
        }

        public void mostrarPopupSeleccionarPreventa()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.IsPostBack)
            {
                goto TR_0000;
            }
            else
            {
                int num1;
                if (!this.esLoginSac() && !this.espedidoRapido())
                {
                    this.RadComboBox1SelectBodega.Visible = false;
                    this.Label10bodeInventario.Visible = false;
                }
                else
                {
                    this.RadComboBox1SelectBodega.Visible = true;
                    this.Label10bodeInventario.Visible = true;
                    this.loadBodegasCombo();
                }
                this.Session["idPedidoEnviado"] = null;
                this.Session["nitPedidoEnviado"] = null;
                this.Session["enviarPedidoSinMontoMimo"] = null;
                this.Session["diferenciaPediMinimoNivi"] = null;
                this.Session["bodegaEmpresaria"] = "";
                this.Session["recogePedidoTienda"] = 0;
                this.Session["grupoCliente"] = "";
                decimal num = 0M;
                this.Session["codigorapidosusadosdescuento"] = null;
                this.Session["listaamarresactualpedio"] = null;
                this.Session["current_tiene_amarre"] = null;
                this.Session["descuentosporAmarre"] = num;
                this.Session["esborrador"] = 0;
                this.Session["listaplusconamarre"] = null;
                this.Session["lista_amarresplu_para_descuentos"] = null;
                this.Session["amarresagredoslist"] = null;
                this.Session["listaplusdescontados"] = null;
                this.Session["listaplusconpinta"] = null;
                List<AmarresInfo> list = this.getPintasVigentes();
                this.Session["pintasAuxiliar"] = list;
                list = this.getPintasVigentesxIdCorto();
                this.Session["pintasAuxiliarxIdCorto"] = list;
                this.Session["totalPagarEmprep"] = num;
                this.Session["totalPedidoenPuntos"] = num;
                this.Session["totalpedidodespuesdescuentos"] = num;
                this.Session["PlulistConDescuentoEmpresaria"] = this.PLUList;
                this.Session["descuentoporpuntosusados"] = num;
                PuntosBo bo = new PuntosBo();
                this.Session["valorpuntoensoles"] = bo.getvalorPuntoEnSoles();
                this.Session["pedidoMinimoGanarPuntos"] = bo.getPedidoMinimoGanarPuntos();
                this.Session["pagadoPuntos"] = 0;
                this.Session["totalPedidoPuntos"] = 0;
                this.Session["puntosGanadosPedido"] = 0;
                this.Session["diferenciaPediMinimoPuntos"] = null;
                this.Session["enviarPedidoSinMontoMinimoPuntos"] = null;
                this.Session["cumpleminimoparapuntos"] = null;
                this.Session["diferenciaNivelPuntos"] = null;
                this.Session["cumpleNivelpuntos"] = null;
                this.Session["enviarPedidoSinNivelPuntos"] = null;
                this.Session["puntosGanarNivel"] = null;
                this.Session["mensajePedMinimoPuntos"] = null;
                this.Session["mensajeProximoNivelPuntos"] = null;
                ParametrosInfo objA = new Parametros().ListxId(0x41);
                if (!ReferenceEquals(objA, null))
                {
                    this.Session["sisPuntosAct"] = (objA.Valor != "1") ? 0 : 1;
                }
                else
                {
                    this.Session["sisPuntosAct"] = 0;
                }
                this.mostrarInterfazPuntos();
                if ((this.Session["IdVendedor"] == null) || (this.Session["IdVendedor"].ToString() == ""))
                {
                    base.Response.Redirect("../Login.aspx");
                }
                this.SetPermissions();
                this.IdPedidoRes = "";
                this.RealizoReserva = false;
                this.vsclickreserva = false;
                this.TotalArtNoDiponibles = 0M;
                this.ValorCatalogoHogar = 0M;
                this.ValorCatalogoOutlet = 0M;
                this.TotalPrecioCatalogoGlobal = 0M;
                this.strFechaCierreBorrador = "";
                this.PLUNoDisponibleList = null;
                this.TipoPedidoMinimo = 0;
                this.ValorCatalogoPisame = 0M;
                this.ValorCatalogoNivi = 0M;
                this.ValorCatalogoOutletPisame = 0M;
                this.AdicionarFleteYPremios = false;
                this.ExcentoIVA = false;
                this.CodCiudadCliente = "";
                this.TipoDescuento = 0;
                this.PremioBienvenida = 0;
                this.TipoEnvioCliente = 0;
                this.ValorTotalParaDescuento = 0M;
                this.ValorTotalParaDescuentoPisame = 0M;
                this.CodCiudadDespacho = "";
                this.ConsultarZonaMultiPedidos();
                this.vsEditarPedido = "false";
                bool flag = false;
                if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(50)))
                {
                    flag = true;
                }
                if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x34)) || (this.Session["IdGrupo"].ToString() == Convert.ToString(60)))
                {
                    num1 = 0;
                }
                else
                {
                    num1 = (int)!flag;
                }
                bool flag2 = (bool)num1;
                if (flag2)
                {
                    if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x35)) || (this.Session["IdGrupo"].ToString() == Convert.ToString(0x3b)))
                    {
                        this.CargarValoresIniciales();
                    }
                }
                else
                {
                    MailPlan plan = new MailPlan("conexion");
                    MailPlanInfo info2 = new MailPlanInfo();
                    string str2 = "";
                    Lideres lideres = new Lideres("conexion");
                    LideresInfo info3 = new LideresInfo();
                    info3 = lideres.ListxCiudadxUsuario(Tools.Encrypt(this.Session["ClaveUsuario"].ToString().Trim(), true));
                    try
                    {
                        flag2 = !flag;
                        if (!flag2)
                        {
                            string str3 = new PuntosBo().getClaveLider(this.Session["Usuario"].ToString());
                            flag2 = str3.Trim() != "";
                            if (flag2)
                            {
                                info3 = lideres.ListxCiudadxUsuario(str3);
                            }
                            else
                            {
                                info3 = null;
                                this.DeshabilitarControles();
                                this.RadWindowManager1.IconUrl = "../images/favicon.ico";
                                this.RadWindowManager1.RadAlert("No se encontro un lider asignado a la empresaria.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (!ReferenceEquals(info3, null))
                    {
                        str2 = info3.CodCiudad.Trim();
                    }
                    if ((this.Session["CiudadVLSAC"] != null) && (this.Session["CiudadVLSAC"].ToString().Trim() != ""))
                    {
                        str2 = this.Session["CiudadVLSAC"].ToString().Trim();
                    }
                    info2 = plan.ListxZonaxIdxFacturacionDiaria(str2.Trim());
                    if (str2 == "")
                    {
                        info2 = null;
                    }
                    if (!ReferenceEquals(info2, null))
                    {
                        this.CargarValoresIniciales();
                        this.ConfigCombos();
                    }
                    else
                    {
                        this.DeshabilitarControles();
                        this.RadWindowManager1.IconUrl = "../images/favicon.ico";
                        this.RadWindowManager1.RadAlert("Su zona se encuentra deshabilitada para el ingreso de pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                }
                if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(0x61)))
                {
                    decimal num2 = 0M;
                    this.Session["IVA"] = num2;
                    this.Session["SubTotal"] = num2;
                    this.Session["Total"] = num2;
                    this.Session["PrecioCat"] = num2;
                    this.Session["SubTotalPrecioCat"] = num2;
                    this.Session["IVAPrecioCat"] = num2;
                    this.Session["TotalPrecioCat"] = num2;
                    this.Session["TotalArtNoDiponibles"] = num2;
                    this.Session["ValorCatalogoHogar"] = num2;
                    this.Session["ValorCatalogoOutlet"] = num2;
                    this.Session["TotalPrecioCatalogoGlobal"] = num2;
                    this.Session["ValorCatalogoNivi"] = num2;
                    this.Session["ValorCatalogoPisame"] = num2;
                    this.Session["ValorCatalogoOutletPisame"] = num2;
                    this.Session["ValorTotalParaDescuento"] = num2;
                    this.Session["ValorTotalParaDescuentoPisame"] = num2;
                    this.CargarValoresIniciales();
                    this.ConfigCombos();
                }
                if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(50)))
                {
                    if (this.Session["UsuarioLogin"] != null)
                    {
                        this.txt_nodocumento.Text = (string)this.Session["UsuarioLogin"];
                        this.txt_nodocumento.Enabled = false;
                    }
                    this.documentochangeempresaria();
                }
                if (this.Session["espedidoPreventa"] == null)
                {
                    this.mostrarPopupSeleccionarPreventa();
                }
                else
                {
                    flag2 = ((int)this.Session["espedidoPreventa"]) != 1;
                    if (flag2)
                    {
                        this.rcb_campana.SelectedIndex = 0;
                        this.rcb_campana.ForeColor = System.Drawing.Color.DarkBlue;
                    }
                    else
                    {
                        this.rcb_campana.SelectedIndex = 1;
                        this.rcb_campana.ForeColor = System.Drawing.Color.Tomato;
                        Campana campana = new Campana("conexion");
                        CampanaInfo info4 = new CampanaInfo();
                        try
                        {
                            info4 = campana.ListxCampana(this.rcb_campana.SelectedValue);
                            this.rcb_catalogo.Enabled = true;
                            RadComboBoxItem item = new RadComboBoxItem
                            {
                                Text = "CATALOGO NIVI",
                                Value = info4.Catalogo
                            };
                            this.rcb_catalogo.Items.Add(item);
                            this.rcb_catalogo.SelectedValue = info4.Catalogo;
                            this.rcb_catalogo.Enabled = false;
                            this.Session["CampanaPrev"] = this.rcb_campana.SelectedValue;
                            flag2 = this.rcb_campana.SelectedValue != this.Session["Campana"].ToString();
                            if (!flag2)
                            {
                                this.Label9.Visible = false;
                                this.rcb_campana.ForeColor = System.Drawing.Color.DarkBlue;
                            }
                            else
                            {
                                this.rcb_campana.ForeColor = System.Drawing.Color.Tomato;
                                this.Label9.Visible = true;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            List<PremiosNivelesInfo> list2 = new PremiosNiveles().ListxTodosNiveles();
            this.Session["nivelesPremiosActual"] = list2;
            this.Session["cantcamapanasAcumulaPremios"] = this.getcantidadCampanasAcumulaPremio();
            this.Session["nivelEmpresariaPremio"] = null;
            this.Session["agregarPremio"] = null;
            this.Session["idCortoPremioEmpresaria"] = null;
            this.Session["premioEmpresaria"] = null;
            this.Session["ganoPremioMayor"] = null;
            this.Session["listaPremiosEmpresaria"] = null;
            this.Session["totalRedimido"] = null;
            this.Session["cantidadMayoresGanados"] = null;
            this.LabelPuntosaUsar.Text = "\x00bfCuantos Puntos Usaras?";
            int num3 = 0;
            this.Session["diasparaReprogramacion"] = num3;
            if ((this.Session["mostrodiareprogramacion"] == null) && (num3 > 0))
            {
                this.mostrarPopupReprogramacion();
            }
        TR_0000:
            this.Session["CampanaPrev"] = this.rcb_campana.SelectedValue;
        }

        private void ProcesarPedido()
        {
            if (this.grdData.Items.Count <= 0)
            {
                this.RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('Debe adicionar por lo menos un articulo para crear el pedido.');");
            }
            else
            {
                int num1;
                bool flag = false;
                List<PedidosClienteInfo> objA = new List<PedidosClienteInfo>();
                PedidosCliente cliente = new PedidosCliente("conexion");
                CampanaInfo info = new CampanaInfo();
                Campana campana = new Campana("conexion");
                info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
                objA = cliente.ListxPedidoSinFacturarxReserva(this.txt_nodocumento.Text, info.Campana, this.rcb_catalogo.SelectedValue, this.IdPedido);
                if (this.ZonaMultiPedidos && (this.vsEditarPedido == "false"))
                {
                    objA = null;
                }
                if ((!ReferenceEquals(objA, null) && (objA.Count > 0)) && (objA[0].Numero.Trim().Substring(0, 3) == "PPC"))
                {
                    objA = null;
                }
                if ((objA != null) && (objA.Count > 0))
                {
                    this.IdPedido = objA[0].Numero;
                    this.IdPedidoRes = objA[0].Numero;
                }
                if ((this.IdPedido == "0") || (this.IdPedido == null))
                {
                    num1 = 1;
                }
                else
                {
                    num1 = (int)(this.IdPedido == "");
                }
                if (num1 == 0)
                {
                    flag = this.EditarPedido();
                }
                else if (this.txt_nodocumento.Text != "")
                {
                    flag = this.GuardarPedido();
                }
                else
                {
                    this.RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('Debe seleccionar una empresaria para crear el pedido.');");
                }
                if (!flag)
                {
                    this.RadWindowManager1.RadAlert("No se pudo guardar Pedido, por favor comuniquese con el area de informatica Niviglobal SAS.", 350, 140, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");
                }
                else
                {
                    this.lbl_numeropedido.Text = this.IdPedido;
                    this.lbl_numeropedido.ForeColor = System.Drawing.Color.Red;
                    if (!this.vsclickreserva)
                    {
                        this.RadWindowManager1.RadAlert("Se almacen\x00f3 el Pedido <b>BORRADOR</b> N\x00famero: <font color=red><b>" + this.IdPedido + "</b></font> exitosamente.<br /><br /><font color=darkviolet><b>DEBE ENVIAR EL PEDIDO ANTES DEL " + this.strFechaCierreBorrador.ToUpper() + ", \x00d3 ESTE SER\x00c1 ANULADO.</b></font>", 350, 140, "SVDN - Pedidos", "MensajeSistema", "../images/ok.png");
                    }
                    this.EnviarCorreo();
                }
            }
        }

        private void ProcesarPedidoReservaEnLinea()
        {
            if (this.grdData.Items.Count <= 0)
            {
                this.RadAjaxManager1.ResponseScripts.Add("callAlertGenerico('Debe adicionar por lo menos un articulo para crear el pedido.');");
            }
            else
            {
                int num1;
                bool flag = false;
                if ((this.IdPedido == "0") || (this.IdPedido == null))
                {
                    num1 = 1;
                }
                else
                {
                    num1 = (int)(this.IdPedido == "");
                }
                if (num1 == 0)
                {
                    flag = this.GuardarPedidoReservaEnLinea(this.IdPedido);
                }
                if (!flag)
                {
                    this.RadWindowManager1.RadAlert("No se pudo guardar Pedido, por favor comuniquese con el area de informatica Niviglobal SAS.", 350, 140, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");
                }
                else
                {
                    this.lbl_numeropedido.Text = this.IdPedido;
                    this.lbl_numeropedido.ForeColor = System.Drawing.Color.Red;
                    if (!this.RealizoReserva)
                    {
                        this.RadWindowManager1.RadAlert("Se almacen\x00f3 el Pedido <b>BORRADOR</b> N\x00famero: <font color=red><b>" + this.IdPedido + "</b></font> exitosamente.", 350, 140, "SVDN - Pedidos", "MensajeSistema", "../images/ok.png");
                    }
                    this.EnviarCorreo();
                }
            }
        }

        private void ProcessRequest(string accion)
        {
            this.RadWindowManager1.Windows.Clear();
            if (accion == "GuardarPedido")
            {
                this.ProcesarPedido();
            }
            else if (accion == "Excel")
            {
                this.SaveExcel();
            }
            else if (accion == "PDF")
            {
                this.SavePdf();
            }
            else if (accion != "TerminosCondiciones")
            {
                if (accion == "VerPorcentaje")
                {
                    this.MostrarDescuentoTemporal();
                }
            }
            else
            {
                this.RadWindowManager1.Windows.Clear();
                this.RadWindow1.NavigateUrl = "TerminosCondiciones.aspx";
                this.RadWindow1.VisibleOnPageLoad = true;
                this.RadWindow1.Modal = true;
                this.RadWindow1.Width = 800;
                this.RadWindow1.Height = 550;
                this.RadWindowManager1.Windows.Add(this.RadWindow1);
                this.RadWindowManager1.DestroyOnClose = true;
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            PLUInfo current;
            bool flag2;
            List<PLUInfo>.Enumerator enumerator;
            if (e.Argument.ToString() != "ok_eliminararticulo")
            {
                if (e.Argument.ToString() == "ok_verificarpedido")
                {
                    if (this.Session["vsokactualizacion"].ToString() == "true")
                    {
                        this.ProcessRequest("GuardarPedido");
                    }
                }
                else if (e.Argument.ToString() == "ok_reservarpedido")
                {
                    if (this.grdData.Items.Count > 0)
                    {
                        this.ValidarPedidoReserva();
                    }
                    else
                    {
                        this.RadWindowManager1.RadAlert("Debe ingresar al menos 1 articulo para guardar el pedido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                }
                else if (e.Argument.ToString() == "ok_item_premio")
                {
                    if ((this.Session["agregarPremio"] != null) && ((((int)this.Session["agregarPremio"]) == 1) || (((int)this.Session["agregarPremio"]) == 0)))
                    {
                        if (((int)this.Session["agregarPremio"]) == 1)
                        {
                            bool flag = false;
                            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
                            PedidosCliente cliente = new PedidosCliente("conexion");
                            CampanaInfo info3 = new CampanaInfo();
                            Campana campana = new Campana("conexion");
                            info3 = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
                            list = cliente.ListxPedidoSinFacturarxReserva(this.txt_nodocumento.Text, info3.Campana, this.rcb_catalogo.SelectedValue, this.IdPedido);
                            if ((list != null) && (list.Count > 0))
                            {
                                flag = true;
                            }
                            if (!flag)
                            {
                                List<PremiosNivelesInfo> list2 = new List<PremiosNivelesInfo>();
                                if (this.Session["nivelesPremiosActual"] != null)
                                {
                                    list2 = (List<PremiosNivelesInfo>)this.Session["nivelesPremiosActual"];
                                }
                                int cantCampanas = 0;
                                if (this.Session["cantcamapanasAcumulaPremios"] != null)
                                {
                                    cantCampanas = (int)this.Session["cantcamapanasAcumulaPremios"];
                                }
                                decimal num7 = this.getTotalAcumladoParaPremio(0M, this.txt_nodocumento.Text, cantCampanas);
                            }
                        }
                        if ((this.Session["esPedidoReservado"] != null) && (((int)this.Session["esPedidoReservado"]) == 1))
                        {
                            EdicionPedidoReservadoBO obo = new EdicionPedidoReservadoBO();
                            obo.reversarsaldoPedido(this.IdPedido);
                            obo.eliminarPedidoOriginal(this.IdPedido);
                        }
                        if (this.grdData.Items.Count > 0)
                        {
                            this.ValidarPedidoReserva();
                        }
                        else
                        {
                            this.RadWindowManager1.RadAlert("Debe ingresar al menos 1 articulo para guardar el pedido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                        }
                    }
                }
                else
                {
                    flag2 = e.Argument.ToString() != "ok_sustituto";
                    if (!flag2)
                    {
                        this.CargarArticulo();
                        using (enumerator = this.PLUList.GetEnumerator())
                        {
                            while (true)
                            {
                                flag2 = enumerator.MoveNext();
                                if (flag2)
                                {
                                    current = enumerator.Current;
                                    if (current.CodigoRapido != this.Session["CodigoRapido"].ToString())
                                    {
                                        continue;
                                    }
                                    current.CodigoRapidoSustituto = this.Session["CodigoRapidoSustituto"].ToString();
                                    current.PLUSustituto = Convert.ToInt32(this.Session["PLUSustituto"].ToString());
                                }
                                break;
                            }
                        }
                        this.AdicionarArticulo();
                    }
                    else if (e.Argument.ToString() == "ok_campanaPreventa")
                    {
                        this.Session["seleccionocampana"] = 1;
                        if (this.Session["espedidoPreventa"] != null)
                        {
                            this.rcb_campana.SelectedIndex = (((int)this.Session["espedidoPreventa"]) != 1) ? 0 : 1;
                        }
                    }
                    else if (e.Argument.ToString() == "ok_reprogramacion")
                    {
                        this.Session["mostrodiareprogramacion"] = 5;
                        base.Response.Redirect("PedidosRapidoCodRes.aspx");
                    }
                    else if (e.Argument.ToString() == "ok_PedidoMinimoNivi")
                    {
                        if ((this.Session["enviarPedidoSinMontoMimo"] != null) && (((int)this.Session["enviarPedidoSinMontoMimo"]) == 1))
                        {
                            this.ValidarGuardarReserva();
                        }
                    }
                    else if (e.Argument.ToString() == "ok_PedidoMinimoPuntos")
                    {
                        if ((this.Session["enviarPedidoSinMontoMinimoPuntos"] != null) && (((int)this.Session["enviarPedidoSinMontoMinimoPuntos"]) == 1))
                        {
                            this.ValidarGuardarReserva();
                        }
                    }
                    else if (((e.Argument.ToString() == "ok_PedidoNivelesPuntos") && (this.Session["enviarPedidoSinNivelPuntos"] != null)) && (((int)this.Session["enviarPedidoSinNivelPuntos"]) == 1))
                    {
                        this.ValidarGuardarReserva();
                    }
                }
                return;
            }
            else
            {
                decimal num = 0M;
                this.Session["totalPagarEmprep"] = num;
                this.Session["totalPedidoenPuntos"] = num;
                GridDataItem item = (GridDataItem)this.grdData.SelectedItems[this.grdData.SelectedItems.Count - 1];
                int num2 = Convert.ToInt32(item.GetDataKeyValue("PLU").ToString());
                flag2 = (item["Disponible"].FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl.ToString() != "../images/nodisp.gif";
                if (!flag2)
                {
                    this.RadWindowManager1.RadAlert("No se puede eliminar Articulo.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
                else
                {
                    int num3 = 0;
                    using (enumerator = this.PLUList.GetEnumerator())
                    {
                        while (true)
                        {
                            flag2 = enumerator.MoveNext();
                            if (flag2)
                            {
                                current = enumerator.Current;
                                if (current.PLU != num2)
                                {
                                    continue;
                                }
                                flag2 = current.PLUSustituto <= 0;
                                if (!flag2)
                                {
                                    num3 = 1;
                                }
                            }
                            break;
                        }
                    }
                    flag2 = num3 != 1;
                    if (!flag2)
                    {
                        this.RadWindowManager1.RadAlert("No se puede eliminar este producto hasta que elimine el sustituto.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                    else
                    {
                        IEnumerator enumerator2 = this.grdData.MasterTableView.Items.GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                flag2 = enumerator2.MoveNext();
                                if (flag2)
                                {
                                    GridDataItem current = (GridDataItem)enumerator2.Current;
                                    if (!current.Selected)
                                    {
                                        continue;
                                    }
                                    int pLU = Convert.ToInt32(current.GetDataKeyValue("PLU"));
                                    flag2 = pLU == 0xd1d;
                                    if (flag2)
                                    {
                                        this.RadWindowManager1.RadAlert("No se puede eliminar MANEJO LOGISTICO.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                                    }
                                    else
                                    {
                                        int num5 = this.EliminarPLU(pLU);
                                        using (enumerator = this.PLUList.GetEnumerator())
                                        {
                                            while (true)
                                            {
                                                flag2 = enumerator.MoveNext();
                                                if (flag2)
                                                {
                                                    PLUInfo info2 = enumerator.Current;
                                                    if (info2.PLUSustituto != num2)
                                                    {
                                                        continue;
                                                    }
                                                    info2.PLUSustituto = 0;
                                                    info2.CodigoRapidoSustituto = "";
                                                }
                                                break;
                                            }
                                        }
                                        this.grdData.Rebind();
                                    }
                                }
                                break;
                            }
                        }
                        finally
                        {
                            IDisposable objA = enumerator2 as IDisposable;
                            if (!ReferenceEquals(objA, null))
                            {
                                objA.Dispose();
                            }
                        }
                    }
                }
            }
            this.actualizarTotalpagermenospuntos();
        }

        protected void RadComboBox1SelectBodega_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string selectedValue = this.RadComboBox1SelectBodega.SelectedValue;
            this.Session["bodegaEmpresaria"] = selectedValue;
            this.grdData.Rebind();
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                int num1;
                int num8;
                PLUInfo info = (this.Session["PLUList"] as List<PLUInfo>)[e.Item.ItemIndex];
                Inventario inventario = new Inventario("conexion");
                InventarioInfo objA = new InventarioInfo();
                string bodega = "";
                if (this.Session["bodegaEmpresaria"] != null)
                {
                    bodega = (string)this.Session["bodegaEmpresaria"];
                }
                objA = inventario.ListSaldosBodegaxPLUxEmpresaria(bodega, info.PLU);
                Button button = (Button)e.Item.FindControl("btnSustitutos");
                ImageButton button2 = (ImageButton)e.Item.FindControl("Imageamarre");
                Label label = (Label)e.Item.FindControl("Label8IdRegla");
                ImageButton button3 = (ImageButton)e.Item.FindControl("ImageButtonPrecioPuntos");
                Label label2 = (Label)e.Item.FindControl("LabelDescuentoEmpre");
                Label label3 = (Label)e.Item.FindControl("LabelPrecioPuntos");
                string codigoRapido = info.CodigoRapido;
                int count = this.getAmarres(codigoRapido).Count;
                int num2 = this.getAmarres(codigoRapido).Count;
                if (ReferenceEquals(objA, null))
                {
                    button2.ImageUrl = "~/images/fondo_frame.jpg";
                    button2.Visible = false;
                    label.Visible = false;
                    button3.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                }
                else
                {
                    if ((count <= 0) || (objA.Saldo <= 0M))
                    {
                        button2.ImageUrl = "~/images/fondo_frame.jpg";
                        button2.Visible = false;
                        label.Visible = false;
                    }
                    else
                    {
                        button2.ImageUrl = "~/images/amarre.png";
                        button2.Visible = true;
                        label.Text = "ID: " + this.getAmarres(codigoRapido)[0].Id_regla;
                        label.Visible = true;
                    }
                    if (objA.Saldo > 0M)
                    {
                        button3.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                    }
                    else
                    {
                        button3.Visible = false;
                        label2.Visible = false;
                        label3.Visible = false;
                    }
                }
                int num3 = 0;
                if (count <= 0)
                {
                    this.Session["current_tiene_amarre"] = 0;
                    this.Session["last_codigo_rapido"] = info.CodigoRapido;
                }
                else
                {
                    AmarresInfo item = new AmarresInfo();
                    string str3 = "font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 11px;font-weight: bold;color: #045FB4;text-decoration: none;text-align: left;text-indent: 5px;";
                    List<AmarresInfo> list = new List<AmarresInfo>();
                    List<AmarresInfo> list2 = new List<AmarresInfo>();
                    list = this.getAmarres(info.CodigoRapido);
                    int num4 = 0;
                    while (true)
                    {
                        decimal precio;
                        if (num4 >= list.Count)
                        {
                            this.Session["current_tiene_amarre"] = 1;
                            this.Session["lista_amarres_current"] = list2;
                            this.Session["last_codigo_rapido"] = info.CodigoRapido;
                            this.Session["last_catalogo_real"] = info.CatalogoReal;
                            this.Session["last_descripcion"] = info.NombreProducto;
                            this.Session["cant_amarres"] = list2.Count;
                            break;
                        }
                        item = list[num4];
                        object[] args = new object[] { Convert.ToDecimal(precio.ToString().Replace(".", ",").Trim()) };
                        precio = list[num4].Precio;
                        string str4 = string.Format(CultureInfo.CreateSpecificCulture("es-PE"), "{0,9:c2}", args);
                        if (item.Pinta == 1)
                        {
                            string[] strArray;
                            if (item.xReferencia == 1)
                            {
                                strArray = new string[] { "<font style=\"", str3, "\">Arma tu conjunto  por ", str4, ",.</br>", item.Descripcion, "</font>" };
                                item.Descripcion = string.Concat(strArray);
                            }
                            else
                            {
                                strArray = new string[] { "<font style=\"", "font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 13px;font-weight: bold;color: #045FB4;text-decoration: none;text-align: left;text-indent: 5px;", "\">", item.Descripcion, "</font>" };
                                item.Descripcion = string.Concat(strArray);
                            }
                        }
                        list2.Add(item);
                        num4++;
                    }
                }
                if (!ReferenceEquals(objA, null))
                {
                    if (objA.Saldo < 1M)
                    {
                        num3 = 1;
                    }
                }
                else if (info.PLU != 0xbccc)
                {
                    num3 = 1;
                }
                if (num3 != 1)
                {
                    num1 = 1;
                }
                else if ((info.CodigoRapidoSustituto == "") || (info.CodigoRapidoSustituto == "&nbsp;"))
                {
                    num1 = 0;
                }
                else
                {
                    num1 = (int)!ReferenceEquals(info.CodigoRapidoSustituto, null);
                }
                if (num8 != 0)
                {
                    button.Visible = false;
                }
                else
                {
                    button.Visible = false;
                    List<SustitutosInfo> list3 = new List<SustitutosInfo>();
                    if (new Sustitutos("conexion").Lista(info.CodigoRapido.ToString(), this.rcb_catalogo.SelectedValue.ToString()).Count<SustitutosInfo>() > 0)
                    {
                        if ((this.Session["Sust_agregado"] == null) || (((int)this.Session["Sust_agregado"]) == 0))
                        {
                            ScriptManager.RegisterClientScriptBlock((Page)this, base.GetType(), "Javascript", "VerSustitutos('" + this.rcb_catalogo.SelectedValue.ToString() + "','" + info.CodigoRapido.ToString() + "','" + info.Cantidad.ToString() + "'); ", true);
                        }
                        this.Session["Sust_agregado"] = 0;
                    }
                }
            }
        }

        protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
        {
            this.ProcessRequest(e.Item.Value);
        }

        protected void RadNumericPuntosUsar_TextChanged(object sender, EventArgs e)
        {
            this.Session["pagadoPuntos"] = Convert.ToInt32(this.RadNumericPuntosUsar.Text);
            this.actualizarTotalpagermenospuntos();
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
        }

        protected void RadTabStrip1_TabClick1(object sender, RadTabStripEventArgs e)
        {
            if (e.Tab.Index == 0)
            {
                this.Session["espedidoPreventa"] = null;
                base.Response.Redirect("PedidosRapidoCodRes.aspx");
            }
            else if (e.Tab.Index == 1)
            {
                base.Response.Redirect("PedidosList.aspx");
            }
            else if (e.Tab.Index == 2)
            {
                base.Response.Redirect("RegistroEmpresariaEc.aspx");
            }
            else if (e.Tab.Index == 3)
            {
                base.Response.Redirect("MisEmpresarias.aspx");
            }
            else if (e.Tab.Index == 4)
            {
                base.Response.Redirect("MisGerentesZonales.aspx");
            }
            else if (e.Tab.Index == 5)
            {
                base.Response.Redirect("PedidosListFacturados.aspx");
            }
            else if (e.Tab.Index == 6)
            {
                base.Response.Redirect("ResumenPedidos.aspx");
            }
            else if (e.Tab.Index == 7)
            {
                base.Response.Redirect("MatrizComercial.aspx");
            }
            else if (e.Tab.Index == 8)
            {
                base.Response.Redirect("MatrizComercialResumen.aspx");
            }
            else if (e.Tab.Index == 9)
            {
                base.Response.Redirect("MisPedidosDespachados.aspx");
            }
            else if (e.Tab.Index == 10)
            {
                base.Response.Redirect("MisPedidosRetenidos.aspx");
            }
            else if (e.Tab.Index == 11)
            {
                base.Response.Redirect("MisPedidosAnulados.aspx");
            }
            else if (e.Tab.Index == 12)
            {
                base.Response.Redirect("MisHistorico.aspx");
            }
            else if (e.Tab.Index == 13)
            {
                base.Response.Redirect("PedidosListReserva.aspx");
            }
            else if (e.Tab.Index == 14)
            {
                base.Response.Redirect("InformesFacturacion.aspx");
            }
            else if (e.Tab.Index == 15)
            {
                base.Response.Redirect("SaldosFacturacion.aspx");
            }
            else if (e.Tab.Index == 0x10)
            {
                base.Response.Redirect("Factura.aspx");
            }
            else if (e.Tab.Index == 0x11)
            {
                base.Response.Redirect("MatrizComercialDivZona.aspx");
            }
            else if (e.Tab.Index == 0x12)
            {
                base.Response.Redirect("BrowserContactoNivi2.aspx");
            }
        }

        protected void RadToolbar1_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            this.RadWindowManager1.Windows.Clear();
            RadToolBarButton item = e.Item as RadToolBarButton;
            if (this.RealizoReserva)
            {
                int num1;
                if ((item.CommandName.ToString() == "Excel") || (item.CommandName.ToString() == "PDF"))
                {
                    num1 = 0;
                }
                else
                {
                    num1 = (int)(item.CommandName.ToString() != "TerminosCondiciones");
                }
                if (num1 == 0)
                {
                    this.ProcessRequest(item.CommandName.ToString());
                }
                else
                {
                    this.RadWindowManager1.RadAlert("No puede reservar el pedido mas de una vez.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
            else
            {
                bool flag;
                ParametrosInfo info;
                string str;
                if (item.CommandName.ToString() == "GuardarPedido")
                {
                    if (this.grdData.Items.Count <= 0)
                    {
                        this.RadWindowManager1.RadAlert("Debe ingresar al menos 1 articulo para guardar el pedido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                    else
                    {
                        this.vsclickreserva = false;
                        flag = false;
                        info = new ParametrosInfo();
                        str = new Parametros("conexion").ListxId(0x13).Valor.ToString();
                        flag = ("NO".ToUpper() != "SI") || this.ValidarPedidoMinimoxTipo();
                        flag = true;
                        this.CalcularValoresPrecioCatalogo();
                        this.ValidarPedido();
                    }
                }
                else if (item.CommandName.ToString() == "EnviarPedido")
                {
                    if (this.grdData.Items.Count <= 0)
                    {
                        this.RadWindowManager1.RadAlert("Debe ingresar al menos 1 articulo para enviar el pedido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                    else
                    {
                        flag = false;
                        info = new ParametrosInfo();
                        str = new Parametros("conexion").ListxId(0x13).Valor.ToString();
                        if ("NO".ToUpper() == "SI")
                        {
                            flag = this.ValidarPedidoMinimoxTipo();
                        }
                        else
                        {
                            flag = true;
                            this.CalcularValoresPrecioCatalogo();
                        }
                        if (flag && (this.ValidarPedidoMinimoOutlet() && this.ValidarPedidoMinimoOutletPisame()))
                        {
                            this.vsclickreserva = true;
                            this.ValidarGuardarReserva();
                        }
                    }
                }
                else if (item.CommandName.ToString() == "EliminarArticulo")
                {
                    if (this.grdData.SelectedItems.Count > 0)
                    {
                        this.RadWindowManager1.RadConfirm("Esta seguro de eliminar el Articulo de la lista de pedido?", "confirmCallBackFn", 330, 100, null, "SVDN - Pedidos");
                    }
                    else
                    {
                        this.RadWindowManager1.RadAlert("Debe seleccionar un articulo de la lista.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                }
                else if (item.CommandName.ToString() != "VerPorcentaje")
                {
                    this.ProcessRequest(item.CommandName.ToString());
                }
                else if (this.grdData.Items.Count > 0)
                {
                    this.MostrarDescuentoTemporal();
                }
                else
                {
                    this.RadWindowManager1.RadAlert("Debe adicionar por lo menos 1 articulo.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
        }

        protected void rcb_campana_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Campana campana = new Campana("conexion");
            CampanaInfo info = new CampanaInfo();
            try
            {
                info = campana.ListxCampana(this.rcb_campana.SelectedValue);
                this.rcb_catalogo.Enabled = true;
                RadComboBoxItem item = new RadComboBoxItem
                {
                    Text = "CATALOGO NIVI",
                    Value = info.Catalogo
                };
                this.rcb_catalogo.Items.Add(item);
                this.rcb_catalogo.SelectedValue = info.Catalogo;
                this.rcb_catalogo.Enabled = false;
                this.Session["espedidoPreventa"] = this.rcb_campana.SelectedIndex;
                this.Session["CampanaPrev"] = this.rcb_campana.SelectedValue;
                if (this.rcb_campana.SelectedValue == this.Session["Campana"].ToString())
                {
                    this.Label9.Visible = false;
                    this.rcb_campana.ForeColor = System.Drawing.Color.DarkBlue;
                }
                else
                {
                    this.rcb_campana.ForeColor = System.Drawing.Color.Tomato;
                    this.Label9.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void rcb_cantidad_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value) == 1)
            {
                this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
            }
            else
            {
                this.RadWindowManager1.RadAlert("Usted ha seleccionado <font color=red><b>" + this.rcb_cantidad.SelectedItem.Value + "</b></font> Unidades.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
            }
        }

        protected void rcb_codigorapido_loc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (this.Session["bodegaEmpresaria"] != null)
            {
                string str = (string)this.Session["bodegaEmpresaria"];
            }
            this.rcb_cantidad.Enabled = true;
            this.txt_nodocumento.Enabled = false;
            this.rcb_nombrearticulo.Text = "";
            this.rcb_nombrearticulo.Items.Clear();
            this.rcb_nombrearticulo.ClearSelection();
            this.rcb_preciounitario.Text = "";
            this.rcb_preciounitario.Items.Clear();
            this.rcb_preciounitario.ClearSelection();
            this.rcb_preciototal.Text = "";
            this.rcb_preciototal.Items.Clear();
            this.rcb_preciototal.ClearSelection();
            PLUInfo objA = new PLUInfo();
            PLU plu = new PLU("conexion");
            PLUInfo info2 = new PLUInfo();
            CatalogoPluInfo info3 = new CatalogoPluInfo();
            CatalogoPlu plu2 = new CatalogoPlu("conexion");
            PuntosBo bo = new PuntosBo();
            info3 = plu2.ListxCodigoRapidoSinCatalogo(this.rcb_codigorapido_loc.Text.ToUpper());
            if (ReferenceEquals(info3, null))
            {
                info3 = plu2.ListxCodigoRapidoSinCatalogoAgotadoAnunciado(this.rcb_codigorapido_loc.Text.ToUpper());
                if (ReferenceEquals(info3, null))
                {
                    this.intPLU = -1;
                    this.rcb_nombrearticulo.Text = "";
                    this.rcb_nombrearticulo.EmptyMessage = "No se encontraron resultados. Por favor verifique.";
                    this.rcb_preciounitario.Text = "";
                    this.rcb_preciounitario.EmptyMessage = "$ 0.0";
                    this.rcb_preciototal.Text = "";
                    this.rcb_preciototal.EmptyMessage = "$ 0.0";
                    this.rcb_codigorapido_loc.Focus();
                }
                else
                {
                    string str2 = "";
                    if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x34))
                    {
                        str2 = this.Session["IdZona"].ToString().Trim();
                    }
                    else if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x35))
                    {
                        ClienteInfo info5 = new ClienteInfo();
                        str2 = new Cliente("conexion").ListClienteNivixNit(this.txt_nodocumento.Text).Zona.Trim();
                    }
                    CicloxPlu plu3 = new CicloxPlu("conexion");
                    CicloxPluInfo item = new CicloxPluInfo
                    {
                        Referencia = info3.Referencia.Trim(),
                        CCostos = "P000-" + info3.PLU.ToString(),
                        PLU = info3.PLU,
                        Usuario = this.Session["Usuario"].ToString().Trim(),
                        CodigoRapido = this.rcb_codigorapido_loc.Text.ToUpper(),
                        Campana = this.rcb_campana.SelectedItem.Value,
                        Zona = str2.Trim()
                    };
                    int num = plu3.Insert(item);
                    this.RadWindowManager1.RadAlert("El articulo se encuentra agotado. <br><b>No disponible para la digitacion.</b>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
            else
            {
                objA = plu.ListxArticulosxPLUxTipoPrecio(info3.PLU, 2.ToString());
                if (!ReferenceEquals(objA, null))
                {
                    this.intPLU = objA.PLU;
                    this.strCodigoRapido = this.rcb_codigorapido_loc.Text.ToUpper();
                    this.strCatalogoReal = info3.CatalogoReal;
                    this.rcb_nombrearticulo.Items.Insert(0, new RadComboBoxItem(objA.NombreProducto, objA.PLU.ToString()));
                    this.rcb_nombrearticulo.SelectedIndex = 0;
                    this.RadComboBoxPrecioPuntos.Items.Insert(0, new RadComboBoxItem(objA.PrecioPuntos, objA.PLU.ToString()));
                    this.RadComboBoxPrecioPuntos.SelectedIndex = 0;
                    info2 = plu.ListxArticulosxPLUxTipoPrecio(info3.PLU, 1.ToString());
                    if (this.ExcentoIVA)
                    {
                        this.PrecioCat = info2.PrecioSinIVA;
                        this.IVAPrecioCat = 0M;
                        this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{objA.PrecioSinIVA:C}", objA.PLU.ToString()));
                        this.rcb_preciounitario.SelectedIndex = 0;
                        this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{objA.PrecioSinIVA:C}", objA.PLU.ToString()));
                        this.rcb_preciototal.SelectedIndex = 0;
                    }
                    else
                    {
                        ArtExcentosxCiudadInfo info4 = new ArtExcentosxCiudadInfo();
                        if (!ReferenceEquals(new ArtExcentosxCiudad("conexion").ListxCiudadxPlu(this.CodCiudadCliente, objA.PLU), null))
                        {
                            this.PrecioCat = info2.PrecioSinIVA;
                            this.IVAPrecioCat = 0M;
                            this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioSinIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciounitario.SelectedIndex = 0;
                            this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioSinIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciototal.SelectedIndex = 0;
                        }
                        else
                        {
                            this.PrecioCat = info2.PrecioSinIVA;
                            this.IVAPrecioCat = info2.IVA;
                            this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioConIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciounitario.SelectedIndex = 0;
                            this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{info2.PrecioConIVA:C}", objA.PLU.ToString()));
                            this.rcb_preciototal.SelectedIndex = 0;
                        }
                    }
                    this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
                }
                this.rcb_cantidad.SelectedValue = "1";
                this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
                this.img_adicionar.Focus();
            }
        }

        protected void rcb_codigorapido_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.rcb_cantidad.Enabled = true;
            this.rcb_nombrearticulo.Text = "";
            this.rcb_nombrearticulo.Items.Clear();
            this.rcb_nombrearticulo.ClearSelection();
            this.rcb_preciounitario.Text = "";
            this.rcb_preciounitario.Items.Clear();
            this.rcb_preciounitario.ClearSelection();
            this.rcb_preciototal.Text = "";
            this.rcb_preciototal.Items.Clear();
            this.rcb_preciototal.ClearSelection();
            PLUInfo objA = new PLUInfo();
            PLU plu = new PLU("conexion");
            PLUInfo info2 = new PLUInfo();
            CatalogoPluInfo info3 = new CatalogoPluInfo();
            info3 = new CatalogoPlu("conexion").ListxIdCodigoRapidoUnico(this.rcb_codigorapido.Text, this.rcb_catalogo.SelectedItem.Value);
            if (ReferenceEquals(info3, null))
            {
                this.intPLU = -1;
                this.rcb_nombrearticulo.Text = "";
                this.rcb_nombrearticulo.EmptyMessage = "No se encontraron resultados. Por favor verifique.";
                this.rcb_preciounitario.Text = "";
                this.rcb_preciounitario.EmptyMessage = "Por favor verifique.";
                this.rcb_preciototal.Text = "";
                this.rcb_preciototal.EmptyMessage = "$ 0.0";
            }
            else
            {
                objA = plu.ListxArticulosxPLUxTipoPrecio(info3.PLU, 2.ToString());
                if (!ReferenceEquals(objA, null))
                {
                    this.intPLU = objA.PLU;
                    this.strCodigoRapido = this.rcb_codigorapido.Text;
                    this.strCatalogoReal = info3.CatalogoReal;
                    this.rcb_nombrearticulo.Items.Insert(0, new RadComboBoxItem(objA.NombreProducto, objA.PLU.ToString()));
                    this.rcb_nombrearticulo.SelectedIndex = 0;
                    this.rcb_preciounitario.Items.Insert(0, new RadComboBoxItem($"{objA.PrecioConIVA:C}", objA.PLU.ToString()));
                    this.rcb_preciounitario.SelectedIndex = 0;
                    this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{objA.PrecioConIVA:C}", objA.PLU.ToString()));
                    this.rcb_preciototal.SelectedIndex = 0;
                    info2 = plu.ListxArticulosxPLUxTipoPrecio(info3.PLU, 1.ToString());
                    this.SubTotalPrecioCat += info2.PrecioSinIVA;
                    this.PrecioCat = info2.PrecioSinIVA;
                    this.IVAPrecioCat = info2.IVA;
                    this.ValorTotal(Convert.ToInt32(this.rcb_cantidad.SelectedItem.Value));
                }
            }
        }

        protected void rcb_gerentezona_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
        }

        public void redimirPremio(string nit, string valor, string IdPedido, string user)
        {
            new PremiosNiveles().redimirPremio(nit, valor, IdPedido, user);
        }

        private void SaveExcel()
        {
            this.grdData.ExportSettings.ExportOnlyData = true;
            this.grdData.ExportSettings.IgnorePaging = false;
            this.grdData.ExportSettings.OpenInNewWindow = true;
            this.grdData.ExportSettings.Pdf.PageWidth = Unit.Parse("500mm");
            this.grdData.MasterTableView.ExportToExcel();
        }

        private void SavePdf()
        {
            if (this.grdData.Items.Count > 0)
            {
                this.grdData.ExportSettings.ExportOnlyData = true;
                this.grdData.ExportSettings.IgnorePaging = false;
                this.grdData.ExportSettings.OpenInNewWindow = true;
                this.grdData.ExportSettings.Pdf.PageWidth = Unit.Parse("500mm");
                this.grdData.MasterTableView.ExportToPdf();
            }
        }

        private void SetPermissions()
        {
            try
            {
                if ((((this.Session["AsistentexZona"] == null) || (this.Session["AsistentexZona"].ToString() == "")) && (this.Session["MostrarNombreGerente"] != null)) && (this.Session["MostrarNombreGerente"].ToString() == "true"))
                {
                    this.Session["IdGrupo"] = Convert.ToString(0x34);
                }
                if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x34)) || (this.Session["AsistentexZona"].ToString() == ""))
                {
                    this.RadTabStrip1.Tabs[4].Visible = false;
                    this.RadTabStrip1.Tabs[8].Visible = false;
                }
                else if ((this.Session["IdGrupo"].ToString() == Convert.ToString(0x35)) || (this.Session["IdGrupo"].ToString() == Convert.ToString(0x3b)))
                {
                    this.RadTabStrip1.Tabs[4].Visible = true;
                    this.RadTabStrip1.Tabs[8].Visible = false;
                }
                else if (this.Session["IdGrupo"].ToString() == Convert.ToString(60))
                {
                    this.RadTabStrip1.Tabs[4].Visible = false;
                    this.RadTabStrip1.Tabs[8].Visible = false;
                }
                if (this.Session["IdGrupo"].ToString() == Convert.ToString(0x3b))
                {
                    this.RadTabStrip1.Tabs[4].Visible = false;
                }
                this.RadTabStrip1.Tabs[13].Visible = true;
                this.RadTabStrip1.Tabs[1].Text = "Mis Pedidos Digitados (Borrador)";
            }
            catch
            {
                try
                {
                    if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(0x61)))
                    {
                        this.RadTabStrip1.Tabs[1].Visible = false;
                        this.RadTabStrip1.Tabs[2].Visible = false;
                        this.RadTabStrip1.Tabs[3].Visible = false;
                        this.RadTabStrip1.Tabs[4].Visible = false;
                        this.RadTabStrip1.Tabs[5].Visible = false;
                        this.RadTabStrip1.Tabs[6].Visible = false;
                        this.RadTabStrip1.Tabs[7].Visible = false;
                        this.RadTabStrip1.Tabs[8].Visible = false;
                        this.RadTabStrip1.Tabs[9].Visible = false;
                        this.RadTabStrip1.Tabs[10].Visible = false;
                        this.RadTabStrip1.Tabs[11].Visible = false;
                        this.RadTabStrip1.Tabs[12].Visible = false;
                        this.RadTabStrip1.Tabs[12].Visible = false;
                        this.RadTabStrip1.Tabs[13].Visible = false;
                        this.RadTabStrip1.Tabs[14].Visible = false;
                    }
                }
                catch
                {
                    this.RadWindowManager1.RadAlert("Por favor inicie sesion nuevamente.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/error.png");
                }
            }
        }

        private void SumarValorCatalogoParaDescuento(string ValorPrecioCatalogo, string MenosArticulosNoDiponibles)
        {
            this.ValorTotalParaDescuento = (this.ValorTotalParaDescuento + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
        }

        private void SumarValorCatalogoParaDescuentoPisame(string ValorPrecioCatalogo, string MenosArticulosNoDiponibles)
        {
            this.ValorTotalParaDescuentoPisame = (this.ValorTotalParaDescuentoPisame + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
        }

        private void SumarValoresOutletHogar(string Catalogo, string ValorPrecioCatalogo, string MenosArticulosNoDiponibles)
        {
            if (Catalogo.Trim().ToUpper().StartsWith("T"))
            {
                this.ValorCatalogoOutlet = (this.ValorCatalogoOutlet + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
            }
            else if (Catalogo.Trim().ToUpper().StartsWith("H"))
            {
                this.ValorCatalogoHogar = (this.ValorCatalogoHogar + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
            }
            else if (Catalogo.Trim().ToUpper().StartsWith("P"))
            {
                this.ValorCatalogoPisame = (this.ValorCatalogoPisame + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
            }
            else if (Catalogo.Trim().ToUpper().StartsWith("L"))
            {
                this.ValorCatalogoOutletPisame = (this.ValorCatalogoOutletPisame + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
            }
            else
            {
                this.ValorCatalogoNivi = (this.ValorCatalogoNivi + Convert.ToDecimal(ValorPrecioCatalogo)) - Convert.ToDecimal(MenosArticulosNoDiponibles);
            }
        }

        private bool TienePedidoCampanaActual()
        {
            bool flag = false;
            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
            PedidosCliente cliente = new PedidosCliente("conexion");
            CampanaInfo info = new CampanaInfo();
            Campana campana = new Campana("conexion");
            info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            list = cliente.ListxPedidoxNitxCampana(this.txt_nodocumento.Text, info.Campana, this.IdPedido);
            if ((list != null) && (list.Count > 0))
            {
                flag = true;
            }
            return flag;
        }

        public bool tienereservado()
        {
            bool flag = false;
            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
            PedidosCliente cliente = new PedidosCliente("conexion");
            CampanaInfo info = new CampanaInfo();
            Campana campana = new Campana("conexion");
            info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            list = cliente.ListxPedidoSinFacturarxReserva(this.txt_nodocumento.Text, info.Campana, this.rcb_catalogo.SelectedValue, this.IdPedido);
            if ((list != null) && (list.Count > 0))
            {
                flag = true;
            }
            return flag;
        }

        protected void txt_nodocumento_TextChanged(object sender, EventArgs e)
        {
            ClienteInfo info;
            this.lbl_nombreempresaria.Text = this.ValidaExisteEmpresariaNombre(this.txt_nodocumento.Text);
            PremiosNiveles niveles = new PremiosNiveles();
            this.LabelAcumuladoPedidos.Text = "Acumulado Pedidos: $." + niveles.getAcumuladoEmpresaria(this.txt_nodocumento.Text);
            int num = new PuntosBo().getPuntosEfectivoEmpresaria(this.txt_nodocumento.Text);
            BodegaGlod glod = new BodegaGlod();
            this.Session["bodegaEmpresaria"] = glod.getbodegaEmpresaria(this.txt_nodocumento.Text);
            this.Session["grupoCliente"] = new DescuentoGlod().getGrupoCliente(this.txt_nodocumento.Text);
            if (this.espedidoRapido())
            {
                info = new Cliente().ListClienteSVDNxNit(this.txt_nodocumento.Text);
                this.Session["IdZona"] = info.Zona;
                this.cargarSessionClienterapido();
            }
            this.RadComboBox1SelectBodega.SelectedValue = glod.getbodegaEmpresaria(this.txt_nodocumento.Text);
            this.RadComboBoxSaldoPuntos.Items.Insert(0, new RadComboBoxItem(num, num.ToString()));
            this.RadComboBoxSaldoPuntos.SelectedIndex = 0;
            if ((this.Session["IdGrupoLogin"] != null) && (Convert.ToString(this.Session["IdGrupoLogin"]) == Convert.ToString(0x61)))
            {
                info = new Cliente().ListClienteSVDNxNit(this.txt_nodocumento.Text);
                this.Session["IdZona"] = info.Zona;
                ZonaInfo objA = new ZonaInfo();
                objA = new Zona("conexion").ListxIdZona(this.Session["IdZona"].ToString());
                if (!ReferenceEquals(objA, null))
                {
                    this.Session["DiasCierrePedidoBorrador"] = objA.DiasBorrador;
                    this.Session["DiasCierrePedidoReservado"] = objA.DiasReserva;
                    this.Session["DiasDeGracia"] = objA.DiasDeGracia;
                    this.Session["UniNegZona"] = objA.UnidadNegocio;
                }
            }
            this.RadComboBoxSaldoPuntos.Items.Insert(0, new RadComboBoxItem(num, num.ToString()));
            this.RadComboBoxSaldoPuntos.SelectedIndex = 0;
            this.LabelPuntosaUsar.Text = "\x00bfCuantos Puntos Usaras?";
            this.RadNumericPuntosUsar.Text = "0";
            if ((this.lbl_nombreempresaria.Text.ToUpper() != "NO EXISTE LA EMPRESARIA,<BR />POR FAVOR REALICE EL REGISTRO.") && (this.lbl_nombreempresaria.Text != ""))
            {
                ParametrosInfo info3 = new ParametrosInfo();
                if (new Parametros("conexion").ListxId(0x19).Valor.ToString().ToUpper() == "SI")
                {
                    this.RadAjaxManager1.ResponseScripts.Add("ValidarDireccionTelefono('" + this.txt_nodocumento.Text + "');");
                }
            }
        }

        public bool ValidaCorreo(string Correo)
        {
            bool flag = false;
            if (new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").IsMatch(Correo))
            {
                flag = true;
            }
            return flag;
        }

        private string ValidaExisteEmpresariaNombre(string Nit)
        {
            string str = "";
            ClienteInfo objA = new ClienteInfo();
            objA = new Cliente("conexion").ListClienteSVDNxNit(Nit);
            if (ReferenceEquals(objA, null))
            {
                str = "No existe la empresaria,<br />por favor realice el registro.";
                this.lbl_nombreempresaria.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string[] strArray = new string[] { objA.Nombre1, " ", objA.Nombre2, " ", objA.Apellido1, " ", objA.Apellido2 };
                str = string.Concat(strArray);
                this.lbl_nombreempresaria.ForeColor = System.Drawing.Color.Green;
                this.TipoPedidoMinimo = objA.TipoPedidoMinimo;
                this.CodCiudadCliente = objA.CodCiudad;
                this.PremioBienvenida = objA.Premio;
                this.TipoEnvioCliente = objA.TipoEnvio;
                this.Empresaria_Lider = objA.Lider;
                CiudadInfo info2 = new CiudadInfo();
                info2 = new Ciudad("conexion").ListCiudadxId(this.CodCiudadCliente);
                if (!ReferenceEquals(info2, null))
                {
                    this.ExcentoIVA = info2.ExcluidoIVA == 1;
                }
            }
            return str.ToUpper();
        }

        private bool ValidarExistePedidoBorradorSVDN()
        {
            bool flag = false;
            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
            PedidosCliente cliente = new PedidosCliente("conexion");
            CampanaInfo info = new CampanaInfo();
            Campana campana = new Campana("conexion");
            info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            list = cliente.ListxPedidoBorradorSVDN(this.txt_nodocumento.Text, info.Campana);
            if ((list != null) && (list.Count > 0))
            {
                flag = true;
            }
            return flag;
        }

        private void ValidarGuardarReserva()
        {
            this.Session["pagadoPuntos"] = (this.RadNumericPuntosUsar.Text == "") ? 0 : Convert.ToInt32(this.RadNumericPuntosUsar.Text);
            Parametros parametros = new Parametros();
            PuntosBo bo = new PuntosBo();
            decimal num = Convert.ToDecimal(parametros.ListxId(0x33).Valor.Replace(".", ","));
            decimal num2 = Convert.ToDecimal(parametros.ListxId(0x30).Valor.Replace(".", ","));
            Inventario inventario = new Inventario("conexion");
            InventarioInfo objA = new InventarioInfo();
            List<PremiosNivelesInfo> list = new List<PremiosNivelesInfo>();
            if (this.Session["nivelesPremiosActual"] != null)
            {
                list = (List<PremiosNivelesInfo>)this.Session["nivelesPremiosActual"];
            }
            string text = this.txt_nodocumento.Text;
            int cantCampanas = 0;
            if (this.Session["cantcamapanasAcumulaPremios"] != null)
            {
                cantCampanas = (int)this.Session["cantcamapanasAcumulaPremios"];
            }
            decimal totalPedido = 0M;
            decimal monto = 0M;
            decimal num6 = 0M;
            string bodega = "";
            if (this.Session["bodegaEmpresaria"] != null)
            {
                bodega = (string)this.Session["bodegaEmpresaria"];
            }
            int num7 = 0;
            while (true)
            {
                if (num7 >= this.PLUList.Count)
                {
                    decimal num11;
                    string str3;
                    if (this.Session["totalRedimido"] != null)
                    {
                        totalPedido -= (decimal)this.Session["totalRedimido"];
                    }
                    decimal num8 = this.getTotalAcumladoParaPremio(totalPedido, text, cantCampanas);
                    bool flag = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    bool flag4 = false;
                    decimal num9 = 0M;
                    int puntos = 0;
                    PuntosInfo info4 = bo.getSiguienteNivelPuntos(monto);
                    if (!ReferenceEquals(info4, null))
                    {
                        num9 = info4.Valor_decimal_a;
                        puntos = info4.Puntos;
                    }
                    if (monto < num)
                    {
                        flag = true;
                        num11 = num - monto;
                        this.Session["diferenciaPediMinimoNivi"] = num11;
                    }
                    if (monto >= num2)
                    {
                        this.Session["cumpleminimoparapuntos"] = 1;
                    }
                    else
                    {
                        flag3 = true;
                        num11 = num2 - monto;
                        this.Session["diferenciaPediMinimoPuntos"] = num11;
                        this.Session["cumpleminimoparapuntos"] = 0;
                    }
                    if (num6 >= num9)
                    {
                        this.Session["cumpleNivelpuntos"] = 1;
                    }
                    else
                    {
                        if (this.Session["totalPagarEmprep"] != null)
                        {
                            num6 = (decimal)this.Session["totalPagarEmprep"];
                        }
                        flag4 = true;
                        num11 = Math.Round((decimal)(num9 - num6), 0);
                        this.Session["diferenciaNivelPuntos"] = num11;
                        this.Session["cumpleNivelpuntos"] = 0;
                        this.Session["puntosGanarNivel"] = puntos;
                    }
                    bool flag5 = false;
                    if ((this.Session["espedidoPreventa"] != null) && (((int)this.Session["espedidoPreventa"]) == 1))
                    {
                        flag5 = true;
                    }
                    ParametrosInfo info5 = new Parametros().ListxId(0x48);
                    if (this.Session["sisPuntosAct"] == null)
                    {
                        flag2 = false;
                        flag3 = false;
                        flag4 = false;
                    }
                    else if (((int)this.Session["sisPuntosAct"]) != 1)
                    {
                        flag2 = false;
                        flag3 = false;
                        flag4 = false;
                    }
                    flag = false;
                    flag2 = false;
                    flag3 = false;
                    flag4 = false;
                    if (flag)
                    {
                        if (flag3)
                        {
                            this.Session["mensajePedMinimoPuntos"] = 1;
                        }
                        if (flag4)
                        {
                            this.Session["mensajeProximoNivelPuntos"] = 1;
                        }
                        flag3 = false;
                        flag4 = false;
                    }
                    if (info5.Valor.Trim() == "0")
                    {
                        flag3 = false;
                        flag4 = false;
                        this.Session["mensajeProximoNivelPuntos"] = null;
                    }
                    if ((info5.Valor.Trim() == "1") && flag5)
                    {
                        flag3 = false;
                        flag4 = false;
                        this.Session["mensajeProximoNivelPuntos"] = null;
                    }
                    if ((info5.Valor.Trim() == "2") && !flag5)
                    {
                        flag3 = false;
                        flag4 = false;
                        this.Session["mensajeProximoNivelPuntos"] = null;
                    }
                    if (!this.tienereservado())
                    {
                        if (this.Session["ganoPremioMayor"] != null)
                        {
                        }
                        if (flag2)
                        {
                            str3 = "<script language='javascript'>function f(){VerPremio(); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", str3);
                        }
                    }
                    if (((this.Session["enviarPedidoSinNivelPuntos"] == null) || ((this.Session["enviarPedidoSinNivelPuntos"] != null) && (((int)this.Session["enviarPedidoSinNivelPuntos"]) == 0))) && flag4)
                    {
                        str3 = "<script language='javascript'>function f(){VerAnuncioPedidoNivelesPuntos(); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", str3);
                    }
                    if (((this.Session["enviarPedidoSinMontoMinimoPuntos"] == null) || ((this.Session["enviarPedidoSinMontoMinimoPuntos"] != null) && (((int)this.Session["enviarPedidoSinMontoMinimoPuntos"]) == 0))) && flag3)
                    {
                        str3 = "<script language='javascript'>function f(){VerAnuncioPedidoMinimoPuntos(); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", str3);
                    }
                    if (((this.Session["enviarPedidoSinMontoMimo"] == null) || ((this.Session["enviarPedidoSinMontoMimo"] != null) && (((int)this.Session["enviarPedidoSinMontoMimo"]) == 0))) && flag)
                    {
                        str3 = "<script language='javascript'>function f(){VerAnuncioPedidoMinimoNivi(); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", str3);
                    }
                    string script = "<script language='javascript'>function f(){callConfirmPedido(); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "radalert", script);
                    return;
                }
                objA = inventario.ListSaldosBodegaxPLUxEmpresaria(bodega, this.PLUList[num7].PLU);
                if (!ReferenceEquals(objA, null) && (objA.Saldo > 0M))
                {
                    totalPedido += this.PLUList[num7].PrecioCatalogoTotalConIVA;
                    num6 += this.PLUList[num7].Descuentoempresaria;
                    if (this.PLUList[num7].EsCataNivi == 1)
                    {
                        monto += this.PLUList[num7].PrecioCatalogoTotalConIVA;
                    }
                }
                num7++;
            }
        }

        public void ValidarPedido()
        {
            if ((this.Edit == "") || ReferenceEquals(this.Edit, null))
            {
                if (!this.ValidarPedidoEmpresaria())
                {
                    this.RadWindowManager1.Windows.Clear();
                    this.RadWindow1.NavigateUrl = "ValidarPedidoCod.aspx?Nit=" + this.txt_nodocumento.Text;
                    this.RadWindow1.VisibleOnPageLoad = true;
                    this.RadWindow1.Modal = true;
                    this.RadWindow1.Width = 900;
                    this.RadWindow1.Height = 500;
                    this.RadWindowManager1.Windows.Add(this.RadWindow1);
                    this.RadWindowManager1.DestroyOnClose = true;
                }
            }
            else if (this.Edit == "true")
            {
                this.RadWindowManager1.Windows.Clear();
                this.RadWindow1.NavigateUrl = "ValidarPedidoCod.aspx?Nit=" + this.txt_nodocumento.Text;
                this.RadWindow1.VisibleOnPageLoad = true;
                this.RadWindow1.Modal = true;
                this.RadWindow1.Width = 900;
                this.RadWindow1.Height = 500;
                this.RadWindowManager1.Windows.Add(this.RadWindow1);
                this.RadWindowManager1.DestroyOnClose = true;
            }
        }

        private bool ValidarPedidoEmpresaria()
        {
            bool flag = false;
            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
            PedidosCliente cliente = new PedidosCliente("conexion");
            CampanaInfo info = new CampanaInfo();
            Campana campana = new Campana("conexion");
            info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            list = cliente.ListxPedidoSinFacturarxReserva(this.txt_nodocumento.Text, info.Campana, this.rcb_catalogo.SelectedValue, this.IdPedido);
            if ((list != null) && (list.Count > 0))
            {
                if (this.ZonaMultiPedidos)
                {
                    flag = false;
                }
                else
                {
                    this.RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + list[0].Numero + "</b></font> del <b>" + this.rcb_catalogo.Text.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    flag = true;
                }
            }
            return flag;
        }

        private bool ValidarPedidoEmpresariaReserva()
        {
            bool flag = false;
            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
            PedidosCliente cliente = new PedidosCliente("conexion");
            CampanaInfo info = new CampanaInfo();
            Campana campana = new Campana("conexion");
            info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            list = cliente.ListxPedidoEnReservaxCampanaxCatalogo(this.txt_nodocumento.Text, info.Campana, this.rcb_catalogo.SelectedValue);
            if ((list != null) && (list.Count > 0))
            {
                this.IdPedidoRes = list[0].Numero;
                this.RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + list[0].Numero + "</b></font> del <b>" + this.rcb_catalogo.Text.ToLower() + "</b>. <br>Se debe cancelar el pago total de este pedido para realizar otro adicional.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                flag = true;
            }
            return flag;
        }

        private bool ValidarPedidoMinimoHogar()
        {
            bool flag = false;
            if (this.ValorCatalogoHogar <= 0M)
            {
                flag = true;
            }
            else
            {
                ParametrosInfo info = new ParametrosInfo();
                decimal num = Convert.ToDecimal(new Parametros("conexion").ListxId(5).Valor.ToString());
                if (num <= 0M)
                {
                    flag = true;
                }
                else if (this.TotalPrecioCatalogoGlobal >= num)
                {
                    flag = true;
                }
                else
                {
                    this.RadWindowManager1.RadAlert("La empresaria debe cumplir con un pedido de valor precio catalogo minimo de <b>" + $"{num:C}" + " </b> Dolares para poder realizar un pedido del Catalogo Hogar.<br /><font color=darkviolet>NO se suma el valor de los articulos No disponibles, ni valor de articulos outlet/hogar.</font><br /><font color=red><b>NO SE ENVIO EL PEDIDO.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
            return flag;
        }

        private bool ValidarPedidoMinimoOutlet()
        {
            bool flag = false;
            if (this.ValorCatalogoOutlet <= 0M)
            {
                flag = true;
            }
            else
            {
                TipoPedidoMinimoInfo info = new TipoPedidoMinimoInfo();
                decimal valorOutletNivi = new NIVI.SVDN.Business.Rules.TipoPedidoMinimo("conexion").ListxId(this.TipoPedidoMinimo).ValorOutletNivi;
                if (valorOutletNivi <= 0M)
                {
                    flag = true;
                }
                else if (this.TotalPrecioCatalogoGlobal >= valorOutletNivi)
                {
                    flag = true;
                }
                else
                {
                    this.RadWindowManager1.RadAlert("La empresaria debe cumplir con un pedido de valor precio catalogo minimo de <b>" + $"{valorOutletNivi:C}" + " </b> Dolares para poder realizar un pedido del Catalogo Outlet Nivi.<br /><font color=darkviolet>NO se suma el valor de los articulos No disponibles, ni valor de articulos outlet.</font><br /><font color=red><b>NO SE ENVIO EL PEDIDO.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
            return flag;
        }

        private bool ValidarPedidoMinimoOutletPisame()
        {
            bool flag = false;
            if (this.ValorCatalogoOutletPisame <= 0M)
            {
                flag = true;
            }
            else
            {
                TipoPedidoMinimoInfo info = new TipoPedidoMinimoInfo();
                decimal valorOutletPisame = new NIVI.SVDN.Business.Rules.TipoPedidoMinimo("conexion").ListxId(this.TipoPedidoMinimo).ValorOutletPisame;
                if (valorOutletPisame <= 0M)
                {
                    flag = true;
                }
                else if (this.TotalPrecioCatalogoGlobal >= valorOutletPisame)
                {
                    flag = true;
                }
                else
                {
                    this.RadWindowManager1.RadAlert("La empresaria debe cumplir con un pedido de valor precio catalogo minimo de <b>" + $"{valorOutletPisame:C}" + " </b> Dolares para poder realizar un pedido del Catalogo Outlet Pisame.<br /><font color=darkviolet>NO se suma el valor de los articulos No disponibles, ni valor de articulos outlet.</font><br /><font color=red><b>NO SE ENVIO EL PEDIDO.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                }
            }
            return flag;
        }

        private bool ValidarPedidoMinimoxTipo()
        {
            Inventario inventario = new Inventario("conexion");
            InventarioInfo objA = new InventarioInfo();
            decimal num = 0M;
            string bodega = "";
            if (this.Session["bodegaEmpresaria"] != null)
            {
                bodega = (string)this.Session["bodegaEmpresaria"];
            }
            int num2 = 0;
            while (true)
            {
                if (num2 >= this.PLUList.Count)
                {
                    bool flag = false;
                    TipoPedidoMinimoInfo info2 = new TipoPedidoMinimoInfo();
                    info2 = new NIVI.SVDN.Business.Rules.TipoPedidoMinimo("conexion").ListxId(this.TipoPedidoMinimo);
                    if (ReferenceEquals(info2, null))
                    {
                        this.RadWindowManager1.RadAlert("No se puede crear el pedido por que el cliente no tiene configurado el tipo de pedido minimo.<br />Por favor comuniquese con Inteligencia Comercial - IDN.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    }
                    else
                    {
                        decimal valor = info2.Valor;
                        decimal num4 = Convert.ToDecimal(((GridFooterItem)this.grdData.MasterTableView.GetItems(new GridItemType[] { 3 })[0]).Cells[10].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""));
                        if (this.TipoPedidoMinimo == 1)
                        {
                            num4 = (((num4 - this.ValorCatalogoPisame) - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
                        }
                        else if (this.TipoPedidoMinimo == 2)
                        {
                            num4 = (((num4 - this.ValorCatalogoNivi) - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
                        }
                        else if (this.TipoPedidoMinimo == 3)
                        {
                            num4 = ((num4 - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
                        }
                        this.TotalPrecioCatalogoGlobal = num4;
                        if (num4 >= valor)
                        {
                            flag = true;
                        }
                        else
                        {
                            this.RadWindowManager1.RadAlert("La empresaria debe cumplir con un pedido de valor precio catalogo minimo de <b>" + $"{info2.TextoAMostrar:C}" + " </b> Dolares para poder realizar un pedido.<br /><font color=darkviolet>NO se suma el valor de los articulos No disponibles, ni valor de articulos outlet.</font><br /><font color=red><b>NO SE GUARDO EL PEDIDO.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                        }
                    }
                    return flag;
                }
                objA = inventario.ListSaldosBodegaxPLUxEmpresaria(bodega, this.PLUList[num2].PLU);
                if (!ReferenceEquals(objA, null) && (objA.Saldo > 0M))
                {
                    num += this.PLUList[num2].PrecioCatalogoTotalConIVA;
                }
                num2++;
            }
        }

        private bool ValidarPedidoMinimoxTipoParaFlete()
        {
            bool flag = false;
            TipoPedidoMinimoInfo objA = new TipoPedidoMinimoInfo();
            objA = new NIVI.SVDN.Business.Rules.TipoPedidoMinimo("conexion").ListxId(this.TipoPedidoMinimo);
            if (ReferenceEquals(objA, null))
            {
                flag = false;
            }
            else
            {
                decimal valor = objA.Valor;
                decimal num2 = Convert.ToDecimal(((GridFooterItem)this.grdData.MasterTableView.GetItems(new GridItemType[] { 3 })[0]).Cells[10].Text.Replace("<b>", "").Replace("</b>", "").Replace("$", ""));
                if (this.TipoPedidoMinimo == 1)
                {
                    num2 = (((num2 - this.ValorCatalogoPisame) - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
                }
                else if (this.TipoPedidoMinimo == 2)
                {
                    num2 = (((num2 - this.ValorCatalogoNivi) - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
                }
                else if (this.TipoPedidoMinimo == 3)
                {
                    num2 = ((num2 - this.ValorCatalogoOutletPisame) - this.ValorCatalogoOutlet) - this.TotalArtNoDiponibles;
                }
                this.TotalPrecioCatalogoGlobal = num2;
                flag = num2 >= valor;
            }
            return flag;
        }

        public void ValidarPedidoReserva()
        {
            if (this.ValidarPedidoSinFacturar())
            {
                string str = "";
                str = new PuntosBo().getPedidoActivo(this.txt_nodocumento.Text.Trim());
                base.Response.Redirect("ErrorReserva.aspx?IdPedido=" + str + "&Nit=" + this.txt_nodocumento.Text);
            }
            else
            {
                this.AdicionarFleteYPremios = true;
                this.ProcessRequest("GuardarPedido");
                this.insertarAmarre();
                if (this.GuardarPedidoReservaEnLinea(this.IdPedido))
                {
                    this.RealizoReserva = true;
                    base.Response.Redirect("ValidarPedidoEnviadoEmpresaria.aspx?IdPedido=" + this.IdPedido + "&Nit=" + this.txt_nodocumento.Text);
                    this.RadToolbar1.Items[0].Enabled = false;
                    this.RadToolbar1.Items[1].Enabled = false;
                    this.BtnEnviar.Enabled = false;
                    this.BtnGuardarBorrador.Enabled = false;
                }
                else
                {
                    this.RadWindowManager1.RadAlert("<font color=red><b>Su reserva NO pudo ser almacenada, por favor comuniquese con el area de CCN de Niviglobal y verifique su pedido para evitar inconvenientes de envio.</b></font>", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    this.RadToolbar1.Items[0].Enabled = false;
                    this.RadToolbar1.Items[1].Enabled = false;
                    this.BtnEnviar.Enabled = false;
                    this.BtnGuardarBorrador.Enabled = false;
                    this.RealizoReserva = true;
                }
            }
        }

        private bool ValidarPedidoSinFacturar()
        {
            bool flag = false;
            List<PedidosClienteInfo> list = new List<PedidosClienteInfo>();
            PedidosCliente cliente = new PedidosCliente("conexion");
            CampanaInfo info = new CampanaInfo();
            Campana campana = new Campana("conexion");
            info = ((this.Session["Campana"] == null) || (this.Session["Campana"].ToString() == "")) ? campana.ListxGetDate() : campana.ListxCampana(this.Session["Campana"].ToString());
            list = cliente.ListxPedidoSinFacturarxParaReservar(this.txt_nodocumento.Text, info.Campana, this.rcb_catalogo.SelectedValue, this.IdPedido);
            if ((list != null) && (list.Count > 0))
            {
                PedidosClienteInfo info2;
                string[] strArray;
                if (this.ZonaMultiPedidos)
                {
                    if (this.rcb_campana.SelectedValue == this.Session["Campana"].ToString())
                    {
                        flag = false;
                    }
                    else
                    {
                        info2 = new PedidosClienteInfo();
                        info2 = cliente.ListxPedidoPreventa(this.txt_nodocumento.Text, info.Campana);
                        if (ReferenceEquals(info2, null))
                        {
                            flag = false;
                        }
                        else if (info2.Numero.Trim() == "")
                        {
                            flag = false;
                        }
                        else
                        {
                            strArray = new string[] { "La empresaria tiene activo el Pedido No: <font color=red><b>", info2.Numero, "</b></font> del <b>", this.rcb_catalogo.Text.ToLower(), "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos." };
                            this.RadWindowManager1.RadAlert(string.Concat(strArray), 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                            flag = true;
                        }
                    }
                }
                else if (this.rcb_campana.SelectedValue == this.Session["Campana"].ToString())
                {
                    strArray = new string[] { "La empresaria tiene activo el Pedido No: <font color=red><b>", list[0].Numero, "</b></font> del <b>", this.rcb_catalogo.Text.ToLower(), "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos." };
                    this.RadWindowManager1.RadAlert(string.Concat(strArray), 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                    flag = true;
                }
                else
                {
                    info2 = new PedidosClienteInfo();
                    info2 = cliente.ListxPedidoPreventa(this.txt_nodocumento.Text, info.Campana);
                    if (ReferenceEquals(info2, null))
                    {
                        flag = false;
                    }
                    else if (info2.Numero.Trim() == "")
                    {
                        flag = false;
                    }
                    else
                    {
                        this.RadWindowManager1.RadAlert("La empresaria tiene activo el Pedido No: <font color=red><b>" + info2.Numero + "</b></font> del <b>" + this.rcb_catalogo.Text.ToLower() + "</b>.<br><br>Por favor cancele el valor total para seguir realizando pedidos.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
                        flag = true;
                    }
                }
            }
            return flag;
        }

        private void ValorTotal(int Cantidad)
        {
            if (ReferenceEquals(this.rcb_preciounitario.SelectedItem, null))
            {
                this.RadWindowManager1.RadAlert("Debe ingresar una referencia de C\x00f3digo R\x00e1pido.", 330, 130, "SVDN - Pedidos", "MensajeSistema", "../images/warning.gif");
            }
            else
            {
                this.img_adicionar.Visible = true;
                this.img_adicionar.Enabled = true;
                this.LblTextoAdicionar.Visible = true;
                this.rcb_preciototal.Text = "";
                this.rcb_preciototal.Items.Clear();
                this.rcb_preciototal.ClearSelection();
                this.rcb_preciototal.Items.Insert(0, new RadComboBoxItem($"{Convert.ToDecimal(this.rcb_preciounitario.SelectedItem.Text.Replace("$", "").Replace(" ", "")) * Cantidad:C}"));
                this.rcb_preciototal.SelectedIndex = 0;
                this.CantidadSeleccionada = Cantidad;
            }
        }

        private List<PLUInfo> PLUList
        {
            get
            {
                if (this.Session["PLUList"] == null)
                {
                    this.Session["PLUList"] = new List<PLUInfo>();
                }
                return (List<PLUInfo>)this.Session["PLUList"];
            }
            set =>
                (this.Session["PLUList"] = value);
        }

        [Dynamic(new bool[] { false, true })]
        private List<object> Amarredetalle
        {
            [return: Dynamic(new bool[] { false, true })]
            get
            {
                if (this.Session["Amarredetalle"] == null)
                {
                    this.Session["Amarredetalle"] = new List<object>();
                }
                return (List<object>)this.Session["Amarredetalle"];
            }
            [param: Dynamic(new bool[] { false, true })]
            set =>
                (this.Session["Amarredetalle"] = value);
        }

        private DataTable Amarre
        {
            get
            {
                if (this.Session["Amarre"] == null)
                {
                    this.Session["Amarre"] = new List<PLUInfo>();
                }
                return (DataTable)this.Session["Amarre"];
            }
            set =>
                (this.Session["Amarre"] = value);
        }

        private string IdPedido
        {
            get
            {
                if (this.ViewState["IdPedido"] == null)
                {
                    this.ViewState["IdPedido"] = ReferenceEquals(base.Request.Params["IdPedido"], null) ? "" : base.Request.Params["IdPedido"];
                }
                return (string)this.ViewState["IdPedido"];
            }
            set =>
                (this.ViewState["IdPedido"] = value);
        }

        private string Edit
        {
            get
            {
                if (this.ViewState["Edit"] == null)
                {
                    this.ViewState["Edit"] = ReferenceEquals(base.Request.Params["Edit"], null) ? "" : base.Request.Params["Edit"];
                }
                return (string)this.ViewState["Edit"];
            }
            set =>
                (this.ViewState["Edit"] = value);
        }

        private decimal IVA
        {
            get
            {
                if (this.Session["IVA"] == null)
                {
                    this.Session["IVA"] = 0.0;
                }
                return (decimal)this.Session["IVA"];
            }
            set =>
                (this.Session["IVA"] = value);
        }

        private decimal SubTotal
        {
            get
            {
                if (this.Session["SubTotal"] == null)
                {
                    this.Session["SubTotal"] = 0.0;
                }
                return (decimal)this.Session["SubTotal"];
            }
            set =>
                (this.Session["SubTotal"] = value);
        }

        private decimal Total
        {
            get
            {
                if (this.Session["Total"] == null)
                {
                    this.Session["Total"] = 0.0;
                }
                return (decimal)this.Session["Total"];
            }
            set =>
                (this.Session["Total"] = value);
        }

        private decimal PrecioCat
        {
            get
            {
                if (this.Session["PrecioCat"] == null)
                {
                    this.Session["PrecioCat"] = 0.0;
                }
                return (decimal)this.Session["PrecioCat"];
            }
            set =>
                (this.Session["PrecioCat"] = value);
        }

        private decimal SubTotalPrecioCat
        {
            get
            {
                if (this.Session["SubTotalPrecioCat"] == null)
                {
                    this.Session["SubTotalPrecioCat"] = 0.0;
                }
                return (decimal)this.Session["SubTotalPrecioCat"];
            }
            set =>
                (this.Session["SubTotalPrecioCat"] = value);
        }

        private decimal IVAPrecioCat
        {
            get
            {
                if (this.Session["IVAPrecioCat"] == null)
                {
                    this.Session["IVAPrecioCat"] = 0.0;
                }
                return (decimal)this.Session["IVAPrecioCat"];
            }
            set =>
                (this.Session["IVAPrecioCat"] = value);
        }

        private decimal TotalPrecioCat
        {
            get
            {
                if (this.Session["TotalPrecioCat"] == null)
                {
                    this.Session["TotalPrecioCat"] = 0.0;
                }
                return (decimal)this.Session["TotalPrecioCat"];
            }
            set =>
                (this.Session["TotalPrecioCat"] = value);
        }

        private bool ExcentoIVA
        {
            get
            {
                if (this.Session["ExcentoIVA"] == null)
                {
                    this.Session["ExcentoIVA"] = false;
                }
                return (bool)this.Session["ExcentoIVA"];
            }
            set =>
                (this.Session["ExcentoIVA"] = value);
        }

        private int intPLU
        {
            get
            {
                if (this.Session["intPLU"] == null)
                {
                    this.Session["intPLU"] = false;
                }
                return (int)this.Session["intPLU"];
            }
            set =>
                (this.Session["intPLU"] = value);
        }

        private string strCodigoRapido
        {
            get
            {
                if (this.Session["strCodigoRapido"] == null)
                {
                    this.Session["strCodigoRapido"] = false;
                }
                return (string)this.Session["strCodigoRapido"];
            }
            set =>
                (this.Session["strCodigoRapido"] = value);
        }

        private string strCatalogoReal
        {
            get
            {
                if (this.Session["strCatalogoReal"] == null)
                {
                    this.Session["strCatalogoReal"] = false;
                }
                return (string)this.Session["strCatalogoReal"];
            }
            set =>
                (this.Session["strCatalogoReal"] = value);
        }

        private int CantidadSeleccionada
        {
            get
            {
                if (this.Session["CantidadSeleccionada"] == null)
                {
                    this.Session["CantidadSeleccionada"] = false;
                }
                return (int)this.Session["CantidadSeleccionada"];
            }
            set =>
                (this.Session["CantidadSeleccionada"] = value);
        }

        private string IdPedidoRes
        {
            get
            {
                if (this.Session["IdPedidoRes"] == null)
                {
                    this.Session["IdPedidoRes"] = false;
                }
                return (string)this.Session["IdPedidoRes"];
            }
            set =>
                (this.Session["IdPedidoRes"] = value);
        }

        private bool RealizoReserva
        {
            get
            {
                if (this.Session["RealizoReserva"] == null)
                {
                    this.Session["RealizoReserva"] = false;
                }
                return (bool)this.Session["RealizoReserva"];
            }
            set =>
                (this.Session["RealizoReserva"] = value);
        }

        private bool vsclickreserva
        {
            get =>
                ((bool)this.Session["vsclickreserva"]);
            set =>
                (this.Session["vsclickreserva"] = value);
        }

        private decimal TotalArtNoDiponibles
        {
            get
            {
                if (this.Session["TotalArtNoDiponibles"] == null)
                {
                    this.Session["TotalArtNoDiponibles"] = 0.0;
                }
                return (decimal)this.Session["TotalArtNoDiponibles"];
            }
            set =>
                (this.Session["TotalArtNoDiponibles"] = value);
        }

        private decimal ValorCatalogoHogar
        {
            get
            {
                if (this.Session["ValorCatalogoHogar"] == null)
                {
                    this.Session["ValorCatalogoHogar"] = 0.0;
                }
                return (decimal)this.Session["ValorCatalogoHogar"];
            }
            set =>
                (this.Session["ValorCatalogoHogar"] = value);
        }

        private decimal ValorCatalogoOutlet
        {
            get
            {
                if (this.Session["ValorCatalogoOutlet"] == null)
                {
                    this.Session["ValorCatalogoOutlet"] = 0.0;
                }
                return (decimal)this.Session["ValorCatalogoOutlet"];
            }
            set =>
                (this.Session["ValorCatalogoOutlet"] = value);
        }

        private decimal TotalPrecioCatalogoGlobal
        {
            get
            {
                if (this.Session["TotalPrecioCatalogoGlobal"] == null)
                {
                    this.Session["TotalPrecioCatalogoGlobal"] = 0.0;
                }
                return (decimal)this.Session["TotalPrecioCatalogoGlobal"];
            }
            set =>
                (this.Session["TotalPrecioCatalogoGlobal"] = value);
        }

        private string strFechaCierreBorrador
        {
            get
            {
                if (this.Session["strFechaCierreBorrador"] == null)
                {
                    this.Session["strFechaCierreBorrador"] = false;
                }
                return (string)this.Session["strFechaCierreBorrador"];
            }
            set =>
                (this.Session["strFechaCierreBorrador"] = value);
        }

        private List<string> PLUNoDisponibleList
        {
            get
            {
                if (this.Session["PLUNoDisponibleList"] == null)
                {
                    this.Session["PLUNoDisponibleList"] = new List<string>();
                }
                return (List<string>)this.Session["PLUNoDisponibleList"];
            }
            set =>
                (this.Session["PLUNoDisponibleList"] = value);
        }

        private int TipoPedidoMinimo
        {
            get
            {
                if (this.Session["TipoPedidoMinimo"] == null)
                {
                    this.Session["TipoPedidoMinimo"] = 0;
                }
                return (int)this.Session["TipoPedidoMinimo"];
            }
            set =>
                (this.Session["TipoPedidoMinimo"] = value);
        }

        private decimal ValorCatalogoNivi
        {
            get
            {
                if (this.Session["ValorCatalogoNivi"] == null)
                {
                    this.Session["ValorCatalogoNivi"] = 0.0;
                }
                return (decimal)this.Session["ValorCatalogoNivi"];
            }
            set =>
                (this.Session["ValorCatalogoNivi"] = value);
        }

        private decimal ValorCatalogoPisame
        {
            get
            {
                if (this.Session["ValorCatalogoPisame"] == null)
                {
                    this.Session["ValorCatalogoPisame"] = 0.0;
                }
                return (decimal)this.Session["ValorCatalogoPisame"];
            }
            set =>
                (this.Session["ValorCatalogoPisame"] = value);
        }

        private decimal ValorCatalogoOutletPisame
        {
            get
            {
                if (this.Session["ValorCatalogoOutletPisame"] == null)
                {
                    this.Session["ValorCatalogoOutletPisame"] = 0.0;
                }
                return (decimal)this.Session["ValorCatalogoOutletPisame"];
            }
            set =>
                (this.Session["ValorCatalogoOutletPisame"] = value);
        }

        private string CodCiudadCliente
        {
            get
            {
                if (this.Session["CodCiudadCliente"] == null)
                {
                    this.Session["CodCiudadCliente"] = 0;
                }
                return (string)this.Session["CodCiudadCliente"];
            }
            set =>
                (this.Session["CodCiudadCliente"] = value);
        }

        private int TipoDescuento
        {
            get
            {
                if (this.Session["TipoDescuento"] == null)
                {
                    this.Session["TipoDescuento"] = 0;
                }
                return (int)this.Session["TipoDescuento"];
            }
            set =>
                (this.Session["TipoDescuento"] = value);
        }

        private bool AdicionarFleteYPremios
        {
            get
            {
                if (this.Session["AdicionarFleteYPremios"] == null)
                {
                    this.Session["AdicionarFleteYPremios"] = false;
                }
                return (bool)this.Session["AdicionarFleteYPremios"];
            }
            set =>
                (this.Session["AdicionarFleteYPremios"] = value);
        }

        private int PremioBienvenida
        {
            get
            {
                if (this.Session["PremioBienvenida"] == null)
                {
                    this.Session["PremioBienvenida"] = 0;
                }
                return (int)this.Session["PremioBienvenida"];
            }
            set =>
                (this.Session["PremioBienvenida"] = value);
        }

        private int TipoEnvioCliente
        {
            get
            {
                if (this.Session["TipoEnvioCliente"] == null)
                {
                    this.Session["TipoEnvioCliente"] = 0;
                }
                return (int)this.Session["TipoEnvioCliente"];
            }
            set =>
                (this.Session["TipoEnvioCliente"] = value);
        }

        private string Empresaria_Lider
        {
            get
            {
                if (this.Session["Empresaria_Lider"] == null)
                {
                    this.Session["Empresaria_Lider"] = "";
                }
                return (string)this.Session["Empresaria_Lider"];
            }
            set =>
                (this.Session["Empresaria_Lider"] = value);
        }

        private decimal ValorTotalParaDescuento
        {
            get
            {
                if (this.Session["ValorTotalParaDescuento"] == null)
                {
                    this.Session["ValorTotalParaDescuento"] = 0.0;
                }
                return (decimal)this.Session["ValorTotalParaDescuento"];
            }
            set =>
                (this.Session["ValorTotalParaDescuento"] = value);
        }

        private decimal ValorTotalParaDescuentoPisame
        {
            get
            {
                if (this.Session["ValorTotalParaDescuentoPisame"] == null)
                {
                    this.Session["ValorTotalParaDescuentoPisame"] = 0.0;
                }
                return (decimal)this.Session["ValorTotalParaDescuentoPisame"];
            }
            set =>
                (this.Session["ValorTotalParaDescuentoPisame"] = value);
        }

        private string CodCiudadDespacho
        {
            get
            {
                if (this.Session["CodCiudadDespacho"] == null)
                {
                    this.Session["CodCiudadDespacho"] = "";
                }
                return (string)this.Session["CodCiudadDespacho"];
            }
            set =>
                (this.Session["CodCiudadDespacho"] = value);
        }

        private bool ZonaMultiPedidos
        {
            get
            {
                if (this.Session["ZonaMultiPedidos"] == null)
                {
                    this.Session["ZonaMultiPedidos"] = false;
                }
                return (bool)this.Session["ZonaMultiPedidos"];
            }
            set =>
                (this.Session["ZonaMultiPedidos"] = value);
        }

        private string vsEditarPedido
        {
            get
            {
                if (this.ViewState["vsEditarPedido"] == null)
                {
                    this.ViewState["vsEditarPedido"] = ReferenceEquals(base.Request.Params["vsEditarPedido"], null) ? "" : base.Request.Params["vsEditarPedido"];
                }
                return (string)this.ViewState["vsEditarPedido"];
            }
            set =>
                (this.ViewState["vsEditarPedido"] = value);
        }
    }
}

*/