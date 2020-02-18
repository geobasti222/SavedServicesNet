using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data; 

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ciudad
    /// </summary>
    public class TrasladoFletesCiudad 
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TrasladoFletesCiudad  module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TrasladoFletesCiudad()
        {
            module = new Application.Enterprise.Data.TrasladoFletesCiudad();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TrasladoFletesCiudad(string databaseName)
        {
            module = new Application.Enterprise.Data.TrasladoFletesCiudad(databaseName);
        }
        
        #region Miembros de ICiudad
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TrasladoFleteCiudadinfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Guarda Traslado de fletes para la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertaTablasTemporales(string  campos, string Tipocampo, string usuario)
        {
            try
            {
                TrasladoFleteCiudadinfo item = new TrasladoFleteCiudadinfo ();
                item.Usuario = usuario;
                switch (Tipocampo )
                {
                    case "C1":
                        item.CodCiudad = campos;
                        break;
                    case "C2":
                        item.Valor  = Convert.ToDecimal(campos);
                        break;
                    case "C3":
                        item.Iva = Convert.ToDecimal(campos);
                        break;
                    case "C4":
                        item.ExcluidoIVA = Convert.ToInt32(campos);
                        break;
                    case "C5":
                        item.ValorFleteFull = Convert.ToDecimal(campos);
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
        /// Elimina Valores de la tabla Temporal Dimciudad
        /// </summary>
        /// <returns></returns>
        public bool DeleteTempTransferflete()
        {
            try
            {
                return module.DeleteTempTransferflete();
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
        public bool DeleteTransferflete(string TipoCampo)
        {
            try
            {
                return module.DeleteTransferflete(TipoCampo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        public bool ActualizaTransferflete(string Usuario)
        {
            try
            {
                return module.ActualizaTransferflete(Usuario);
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
        #endregion
    }
}
