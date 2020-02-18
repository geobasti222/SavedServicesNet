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
    
    public class ProvinciaController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        
        public static IAutentication Instance => _Instance.Value;

        [HttpGet]
        [HttpPost]        
        public List<EstadoInfo> ListarProvincia(SessionUserInfo ObjSessionUserInfo)
        {
            List<EstadoInfo> lista = new List<EstadoInfo>();
            Estado module = new Estado("conexion");

            lista = module.ListByPais("593"); //593 Ecuador
                                
            return lista;
        }
    
    }
}
