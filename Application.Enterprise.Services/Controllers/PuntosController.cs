using Application.Enterprise.Business;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.Services.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Services.Controllers
{

    public class PuntosController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        //private static ITokenServices _TokenServices = new TokenServices();

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public List<EPuntosInfo> ListPuntosEmpresarias(EPuntosInfo ObjPedidosEPuntosInfoRequest)
        {

            List<EPuntosInfo> lista = new List<EPuntosInfo>(); ;
            EPuntos module = new EPuntos("conexion");

            //--------------------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------------------
            lista = module.ListPuntosEmpresarias(ObjPedidosEPuntosInfoRequest.Nit, ObjPedidosEPuntosInfoRequest.Lider, ObjPedidosEPuntosInfoRequest.Vendedor);


            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<EPuntosInfo>();
            }


            return lista;


        }


        [HttpGet]
        [HttpPost]
        public List<EPuntosInfo> ListDetallePuntosEmpresarias(EPuntosInfo ObjPedidosEPuntosInfoRequest)
        {

            List<EPuntosInfo> lista = new List<EPuntosInfo>(); ;
            EPuntos module = new EPuntos("conexion");

            //--------------------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------------------
            lista = module.ListDetallePuntosEmpresarias(ObjPedidosEPuntosInfoRequest.Nit);


            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<EPuntosInfo>();
            }


            return lista;


        }




    }
}
