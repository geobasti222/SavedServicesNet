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
    
    public class ParametrosController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public ParametrosInfo ListarParametrosxId(ParametrosInfo ObjParametrosInfo)
        {
            ParametrosInfo lista = new ParametrosInfo();
            Parametros module = new Parametros("conexion");

            lista = module.ListxId(ObjParametrosInfo.Id);
            
            return lista;
        }

        [HttpGet]
        [HttpPost]
        public ZonaInfo ZonaxId(string id)
        {
            ZonaInfo reg = null;
            Application.Enterprise.Business.Zona module = new Application.Enterprise.Business.Zona("conexion");

            reg = module.ListxIdZona(id);

            return reg;
        }

    }
}
