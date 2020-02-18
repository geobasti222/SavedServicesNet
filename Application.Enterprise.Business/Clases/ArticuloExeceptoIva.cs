using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;
using Application.Enterprise.Data;  

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ciudad
    /// </summary>
    public class ArticuloExeceptoIva : IArticuloExeceptoIva  
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ArticuloExeceptoIva  module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ArticuloExeceptoIva()
        {
            module = new Application.Enterprise.Data.ArticuloExeceptoIva();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ArticuloExeceptoIva(string databaseName)
        {
            module = new Application.Enterprise.Data.ArticuloExeceptoIva(databaseName);
        }
        
        #region Miembros de ICiudad
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ArticuloExeceptoIvaInfo> ListXCiudad(ArticuloExeceptoIvaInfo item)
        {
            return module.ListXCiudad(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ArticuloExeceptoIvaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los datos que se van a actualizar en la tabla principal de la Temporal
        /// </summary>
        /// <returns></returns>
        public List<ArticuloExeceptoIvaInfo> ListTemp()
        {
            return module.ListTemp();
        }

        /// <summary>
        /// Guarda Traslado de fletes para la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertaTablasTemporales(string  campos, string Tipocampo, string usuario)
        {
            try
            {
                ArticuloExeceptoIvaInfo item = new ArticuloExeceptoIvaInfo();
                item.Usuario = usuario;
                switch (Tipocampo )
                {
                    case "C1":
                        item.Codciudad   = campos;
                        break;
                    case "C2":
                        item.PLU   = Convert.ToInt32 (campos);
                        break;
                    case "C3":
                        item.Referencia  = campos;
                        break;
                    case "C4":
                        item.Estado = Convert.ToBoolean(Convert.ToInt32(campos));
                        break;
                    default:
                        break;
                }

                return module.InsertaTablasTemporales(item, Tipocampo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// inserta Todas las tablas temporales en una para que ejecute correctamente el grid
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertTablaTemporalPrincipal(string usuario)
        {
            try
            {
                return module.InsertTablaTemporalPrincipal(usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


       

        /// <summary>
        /// Elimina Valores de la tabla Temporal Dimciudad
        /// </summary>
        /// <returns></returns>
        public bool DeleteTempArticulosExeptos()
        {
            try
            {
                return module.DeleteTempArticulosExeptos ();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina Valores de la tabla Temporal Dimciudad
        /// </summary>
        /// <param name="TipoCampo"></param>
        /// <returns></returns>
        public bool DeleteTempArticulosExeptosXCiudad(string TipoCampo)
        {
            try
            {
                return module.DeleteTempArticulosExeptosXCiudad(TipoCampo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        public bool DeleteTempArticulosExeptosXRegistro(string codciudad, int PLU, string Usuario)
        {
            try
            {
                return module.DeleteTempArticulosExeptosXRegistro(codciudad, PLU, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        public bool ActualizaArticulosExceptos(string Usuario)
        {
            try
            {
                bool okTrans = false;
                List<ArticuloExeceptoIvaInfo> lista;
                List<ArticuloExeceptoIvaInfo> listaCarga;


                lista = module.ListTemp();

                if (lista != null)
                {

                    foreach (ArticuloExeceptoIvaInfo item in lista)
                    {

                        Application.Enterprise.Business.ArticuloExeceptoIva Carga = new Application.Enterprise.Business.ArticuloExeceptoIva("conexion");
                        listaCarga = Carga.ListXCiudad(item);
                        item.Usuario = Usuario;
                        if (listaCarga != null && listaCarga.Count > 0 )
                        {

                            okTrans = module.ActualizaArticulosExceptos(item);
                        }
                        else
                        {
                            okTrans = module.InsertRegistroTemporalPrincipal(item);
                        }
                    }
                }
                else
                {
                    return false;
                }
                return okTrans;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

     
        #endregion
    }
}
