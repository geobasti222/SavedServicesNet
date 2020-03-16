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

namespace Application.Enterprise.Services.Controllers
{

    public class PLUController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public PLUInfo ListarxCodigoRapido(PLUInfo ObjPLUInfo)
        {
            PLUInfo lista = new PLUInfo();

            bool ExcentoIVA = false; //MRG: Arreglar esta bandera para que se ponga en true si hay IVA x ciudad x zona x articulo x cliente.
            string CodCiudadCliente = ObjPLUInfo.SessionEmpresaria.CodCiudadCliente.Trim();
            decimal PrecioCat = 0;
            decimal IVAPrecioCat = 0;
            int CantidadSeleccionada = 0;
            decimal PrecioTotal = 0;
            decimal PrecioUnitario = 0;
            int Cantidad = 1;
            decimal PrecioCatalogo = 0;
            decimal ValorIVA = 0;

            PLUInfo objPLU = new PLUInfo();
            PLU module = new PLU("conexion");

            PLUInfo objPLUPrecioCat = new PLUInfo();

            CatalogoPluInfo objCatalogoPluInfo = new CatalogoPluInfo();
            CatalogoPlu objCatalogoPlu = new CatalogoPlu("conexion");


            objCatalogoPluInfo = objCatalogoPlu.ListxCodigoRapidoSinCatalogo(ObjPLUInfo.CodigoRapido.ToUpper());

            if (objCatalogoPluInfo != null)
            {
                objPLU = module.ListxArticulosxPLUxTipoPrecio(objCatalogoPluInfo.PLU, ((int)TipoPrecioEnum.PrecioEmpresaria).ToString());

                if (objPLU != null)
                {
                    objPLU.CatalogoReal = objCatalogoPluInfo.CatalogoReal;
                    objPLU.CodigoRapido = ObjPLUInfo.CodigoRapido.ToUpper();
                    string strProducto = objPLU.NombreProducto.Trim().ToUpper();
                    string[] strProductoList = strProducto.Split(',');
                    objPLU.NombreProducto = strProductoList[0].Trim().ToUpper();
                    objPLU.NombreColor = strProductoList[1].Trim().ToUpper();
                    objPLU.NombreTalla = strProductoList[2].Trim().ToUpper();
                    objPLU.IdZona = ObjPLUInfo.SessionEmpresaria.IdZona.Trim().ToUpper();
                    objPLU.PLU = objCatalogoPluInfo.PLU;
                    objPLU.Referencia = objCatalogoPluInfo.Referencia.Trim().ToUpper();
                    objPLU.Campana = ObjPLUInfo.SessionEmpresaria.Campana.Trim().ToUpper();
                    objPLU.PrecioPuntos = objPLU.PrecioPuntos;
                    objPLU.PuntosGanados = objPLU.PuntosGanados;

                    if (!ExcentoIVA)
                    {
                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                        ArtExcentosxCiudad objArtExcentosxCiudad = new ArtExcentosxCiudad("conexion");
                        ArtExcentosxCiudadInfo objArtExcentosxCiudadInfo = new ArtExcentosxCiudadInfo();
                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()

                        //()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()()
                        //Se valida si el articulo se encuentra excento de iva en la ciudad del cliente.

                        objArtExcentosxCiudadInfo = objArtExcentosxCiudad.ListxCiudadxPlu(ObjPLUInfo.SessionEmpresaria.CodCiudadCliente.Trim(), objPLU.PLU);

                        //Si se encuentra exento el iva debe ser 0.
                        if (objArtExcentosxCiudadInfo != null)
                        {
                            PrecioCat = objPLU.PrecioSinIVA;
                            IVAPrecioCat = 0;

                            PrecioUnitario = objPLU.PrecioSinIVA;
                            //PrecioCatalogo = objPLU.PrecioSinIVA;
                            ValorIVA = 0;
                        }
                        else
                        {
                            PrecioCat = objPLU.PrecioSinIVA;
                            IVAPrecioCat = objPLU.IVA;

                            PrecioUnitario = objPLU.PrecioConIVA;
                            //PrecioCatalogo = objPLU.PrecioConIVA;
                            ValorIVA = objPLU.IVA;
                        }
                    }
                    else
                    {
                        PrecioCat = objPLU.PrecioSinIVA;
                        IVAPrecioCat = 0;
                        PrecioUnitario = objPLU.PrecioSinIVA;
                        //PrecioCatalogo = objPLU.PrecioSinIVA;
                        ValorIVA = 0;
                    }

                    PrecioTotal = PrecioUnitario * Cantidad;
                    CantidadSeleccionada = Cantidad;                    
                    objPLU.Cantidad = Cantidad;

                    //---------------------------------------------------------------------------------------
                    //Descuento y Consulta la disponibilidad de cada articulo.

                    DescuentoGlod glod = new DescuentoGlod("conexion");
                    DescuentoInfo info3 = new DescuentoInfo();
                    decimal descuento = 0M;
                    string bodegasel = "";
                    Inventario inventario = new Inventario("conexion");
                    InventarioInfo info = new InventarioInfo();

                    string grupodscto = "";
                    if (ObjPLUInfo.SessionEmpresaria.GrupoDescuento != null)
                    {
                        grupodscto = ObjPLUInfo.SessionEmpresaria.GrupoDescuento;
                    }
                    KardexInfo info5 = new Kardex("conexion").ListxArticuloxPLU(Convert.ToInt32(objCatalogoPluInfo.PLU));
                    descuento = this.CalcularDescuentoPrivilegioProdEstrella(info5.UnidadNegocio.Trim(), info5.GrupoProducto.Trim(), ObjPLUInfo.SessionEmpresaria.Campana, objCatalogoPluInfo.CatalogoReal.Trim().ToUpper(), info5.ProdEstrella, PrecioUnitario, grupodscto);
                    bodegasel = "";
                    if (ObjPLUInfo.SessionEmpresaria.Bodegas != null)
                    {
                        bodegasel = ObjPLUInfo.SessionEmpresaria.Bodegas.Bodega;
                    }
                    info = inventario.ListSaldosBodegaxPLUxEmpresaria(bodegasel, Convert.ToInt32(objCatalogoPluInfo.PLU));
                    decimal punitario = PrecioUnitario; //Ver codigo de arriba xq aqui ya viene sumado o no el IVA excluido.
                    decimal precioempivadesc = 0M;
                    decimal precioempsiniva = 0;
                    decimal ivaprecioempresaria = 0;
                    if (ReferenceEquals(info, null))
                    {
                        
                        descuento = 0M;
                        objPLU.Disponible = false;
                        precioempsiniva = 0;
                        ivaprecioempresaria = 0;
                        precioempsiniva = PrecioCat;
                        precioempivadesc = PrecioTotal;
                    }
                    else if (info.Saldo > 0M)
                    {
                        //PrecioEmpresaria= objPLU.PrecioTotalConIVA* objPLU.PorcentajeDescuento
                        precioempivadesc = punitario - (punitario * (descuento / 100M));

                        objPLU.Disponible = true;

                        precioempsiniva = PrecioCat - (PrecioCat * (descuento / 100));
                        //ivaprecioempresaria = (((1 + (objPLU.PorcentajeIVA / 100)) * precioempsiniva) - precioempsiniva);
                        ivaprecioempresaria = precioempsiniva * ((objPLU.PorcentajeIVA / 100));
                    }
                    else
                    {
                        
                        descuento = 0M;
                        precioempsiniva = 0;
                        ivaprecioempresaria = 0;
                        objPLU.Disponible = false;
                        precioempsiniva = PrecioCat;
                        precioempivadesc = PrecioTotal;
                    }

                    objPLU.PorcentajeDescuento = descuento;


                    objPLU.PrecioEmpresaria = precioempivadesc;

                    //-------------------------------------------------------------
                    //MRG: Se envian los precios del producto PLU con la configuracion de ExcentoIVA IVA.
                    objPLU.PrecioTotalConIVA = PrecioTotal; //MRG: Este es el valor que se carga en el front en la sesion DetallePedidoService con IVA o sin IVA.
                    objPLU.PrecioCatalogoSinIVA = objPLU.PrecioSinIVA;
                    objPLU.PrecioEmpresariaSinIVA = precioempsiniva;
                    objPLU.IVAPrecioCatalogo = ValorIVA;
                    objPLU.IVAPrecioEmpresaria = ivaprecioempresaria;
                    objPLU.PorcentajeIVA = objPLU.PorcentajeIVA;
                    objPLU.ExcentoIVA = ExcentoIVA;
                    //-------------------------------------------------------------



                    objPLU.SessionEmpresaria = new SessionEmpresariaInfo();
                    objPLU.SessionEmpresaria = ObjPLUInfo.SessionEmpresaria;
                    //........................................................................................
                    //Path de imagenes

                    objPLU.SessionEmpresaria.CarpetaImagenes = ObjPLUInfo.SessionEmpresaria.CarpetaImagenes.Trim();

                    /*llenar variable de sesion con el % Descuento asingado en la busqeuda de la cedula
                        validar path de imagenes para que cargue lo que es y dejar ese path desde bd, sino trae imagenes x default
                        organizar calculos de detalle articulo con lo obtenido desde aqui
                        mostrar bien disponible en verde o rojo*/
                }

            }
            else
            {
                objPLU.PLU = -1;

                objPLU.Error = new Error();
                objPLU.Error.Id = -1;
                objPLU.Error.Descripcion = "No se encontraron resultados. Por favor verifique. Codigo Rapido: " + ObjPLUInfo.CodigoRapido.ToUpper();
                objPLU.CodigoRapido = ObjPLUInfo.CodigoRapido.ToUpper();

            }


            return objPLU;
        }


        private decimal CalcularDescuentoPrivilegioProdEstrella(string UnidadNegocio, string ArtGrupoProducto, string strCampana, string CatalogoReal, bool ProdEstrella, decimal ValorPedido, string grupoCliente)
        {
            DescuentoGlod glod = new DescuentoGlod("conexion");
            DescuentoInfo objA = new DescuentoInfo();
            DescuentoPrivilegio privilegio = new DescuentoPrivilegio("conexion");
            DescuentoPrivilegioInfo info2 = new DescuentoPrivilegioInfo();
            decimal porcentaje = 0;

            objA = glod.ListxValorPedidoProdEstrellaXGrupoCliente(ValorPedido, UnidadNegocio, ArtGrupoProducto, strCampana, false, grupoCliente);

            if (objA != null)
            {
                porcentaje = objA.Porcentaje;
            }
            else
            {
                porcentaje = 0;
            }
            return porcentaje;
        }


        [HttpGet]
        [HttpPost]
        public List<PLUInfo> ListCatalogoActual(PLUInfo ObjPluInfoRequest)
        {

            List<PLUInfo> lista = new List<PLUInfo>(); ;
            PLU module = new PLU("conexion");

            //--------------------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------------------
            lista = module.ListCatalogoActual(ObjPluInfoRequest.Campana);


            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<PLUInfo>();
            }


            return lista;


        }


    }
}
