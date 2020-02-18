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
    
    public class TipoDocumentoController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public List<TipoDocumentoInfo> ListarTipoDocumento(SessionUserInfo ObjSessionUserInfo)
        {
            List<TipoDocumentoInfo> lista = new List<TipoDocumentoInfo>();
            Application.Enterprise.Business.TipoDocumento module = new Application.Enterprise.Business.TipoDocumento("conexion");

            lista = module.List();
                       
            return lista;
        }
    
    }
}
