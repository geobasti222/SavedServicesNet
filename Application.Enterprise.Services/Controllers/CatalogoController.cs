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
    
    public class CatalogoController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public List<CatalogoInfo> ListarCatalogo(SessionUserInfo ObjSessionUserInfo)
        {
            List<CatalogoInfo> lista = new List<CatalogoInfo>();
            Catalogo module = new Catalogo("conexion");

            if (ObjSessionUserInfo.Catalogo != null && ObjSessionUserInfo.Catalogo != "" && ObjSessionUserInfo.ZonaReservaEnLinea == "true")
            {
                lista = module.ListxId(ObjSessionUserInfo.Catalogo);
            }
            else
            {
                lista = module.ListCatalogoFechaActual();
            }
                   
            //Si no hay catalogos se bloquea la aplicacion para la digitacion de pedidos.
            if (lista.Count == 0)
            {
                CatalogoInfo objCatalogoInfo = new CatalogoInfo();

                objCatalogoInfo.Codigo = "N/A";
                objCatalogoInfo.Ano = "";
                objCatalogoInfo.Estado = false;
                objCatalogoInfo.GrupoCatalogo = "";
                objCatalogoInfo.Nombre = "";
                objCatalogoInfo.Unineg = "";
                objCatalogoInfo.Usuario = "";
                objCatalogoInfo.FechaInicial = DateTime.Now;
                objCatalogoInfo.FechaFin = DateTime.Now;

                objCatalogoInfo.Error = new Error();
                objCatalogoInfo.Error.Id = -1;
                objCatalogoInfo.Error.Descripcion = "Error: No se pueden crear pedidos en este periodo. El catalogo no ha sido habilitado.";
                
                lista.Add(objCatalogoInfo);
            }

            return lista;
        }
    
    }
}
