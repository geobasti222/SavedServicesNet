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

    public class CxCController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        //private static ITokenServices _TokenServices = new TokenServices();

        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]
        public List<CxCInfo> ListCxCDirector(CxCInfo ObjPedidosCxCInfoRequest)
        {

            List<CxCInfo> lista = new List<CxCInfo>(); ;
            CxC module = new CxC("conexion");

            //--------------------------------------------------------------------------------------------------------
           

            //--------------------------------------------------------------------------------------------------------
            lista = module.ListCxCVendedor(ObjPedidosCxCInfoRequest.Vendedor);
            

            if (lista != null && lista.Count > 0)
            {

            }
            else
            {
                lista = new List<CxCInfo>();
            }


            return lista;


        }



    }
}
