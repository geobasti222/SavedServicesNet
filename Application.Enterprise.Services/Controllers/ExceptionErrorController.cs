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
    
    public class ExceptionErrorController : BaseController
    {
        private static Lazy<IAutentication> _Instance = new Lazy<IAutentication>(() => new Autentication());
        //private static ITokenServices _TokenServices = new TokenServices();

        public static IAutentication Instance => _Instance.Value; 

        [HttpGet]
        [HttpPost]
        public ExceptionErrorInfo RegistrarException(ExceptionErrorInfo ObjExceptionErrorInfo)
        {
            ExceptionError objExceptionError = new ExceptionError("conexion");
            ExceptionErrorInfo objExceptionErrorInfo = new ExceptionErrorInfo();

            objExceptionErrorInfo.Id = ObjExceptionErrorInfo.Id;
            objExceptionErrorInfo.Componente = ObjExceptionErrorInfo.Componente;
            objExceptionErrorInfo.Metodo = ObjExceptionErrorInfo.Metodo;
            objExceptionErrorInfo.Descripcion = ObjExceptionErrorInfo.Descripcion;
            objExceptionErrorInfo.Usuario = ObjExceptionErrorInfo.Usuario;

            try
            {
                objExceptionError.RegistrarException(objExceptionErrorInfo);
            }
            catch (Exception)
            {

                //throw;
            }
            return ObjExceptionErrorInfo;

        }


    }
}
