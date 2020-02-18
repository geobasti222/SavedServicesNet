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
    /// clase de negocio para presupuesto JA
    /// </summary>
    public class TrasladoPresupuestoMatriz 
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.TrasladoPresupuestoMatriz  module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TrasladoPresupuestoMatriz()
        {
            module = new Application.Enterprise.Data.TrasladoPresupuestoMatriz();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public TrasladoPresupuestoMatriz(string databaseName)
        {
            module = new Application.Enterprise.Data.TrasladoPresupuestoMatriz(databaseName);
        }
        
        #region Miembros de ICiudad
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> ListXCampanaYZona(TrasladoPresupuestoMatrizInfo item)
        {
            return module.ListXCampanaYZona(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> List()
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
                TrasladoPresupuestoMatrizInfo item = new TrasladoPresupuestoMatrizInfo();
                item.Usuario = usuario;
                switch (Tipocampo )
                {
                    case "C1":
                        item.Campana  = campos;
                        break;
                    case "C2":
                        item.Zona  = campos;
                        break;
                    case "C3":
                        item.Activo = Convert.ToInt32 (campos);
                        break;
                    case "C4":
                        item.NPedidos = Convert.ToInt32(campos);
                        break;
                    case "C5":
                        item.Vlr_Presupuesto = Convert.ToDecimal(campos);
                        break;
                    case "C6":
                        item.Vlr_Presupuesto_Nivi = Convert.ToDecimal(campos);
                        break;
                    case "C7":
                        item.Vlr_Presupuesto_Pisame = Convert.ToDecimal(campos);
                        break;
                   /* case "C8":
                        item.Vlr_Presupuesto_Outlet = Convert.ToDecimal(campos);
                        break;
                    case "C9":
                        item.Inactivas = Convert.ToInt32(campos);
                        break;
                    case "C10":
                        item.Reingresos = Convert.ToInt32(campos);
                        break;
                    case "C11":
                        item.Facturacion = Convert.ToDecimal(campos);
                        break;*/
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
        public bool DeleteTempTransferPresupuesto()
        {
            try
            {
                return module.DeleteTempTransferPresupuesto();
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
        public bool DeleteTransferPrespuesto(string TipoCampo)
        {
            try
            {
                return module.DeleteTransferPresupuesto(TipoCampo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        public bool DeletePresupuesto(string Campana, string zona, string usuario)
        {
            try
            {
                return module.DeletePresupuesto(Campana,zona,usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        public bool ActualizaTransferPresupuesto(string Usuario)
        {
            try
            {
                bool okTrans = false;
                List<TrasladoPresupuestoMatrizInfo> lista;
                List<TrasladoPresupuestoMatrizInfo> listaCarga;
                

                lista = module.ListTemp();

                if (lista != null)
                {

                    foreach (TrasladoPresupuestoMatrizInfo item in lista)
                    {

                        Application.Enterprise.Business.TrasladoPresupuestoMatriz Carga = new Application.Enterprise.Business.TrasladoPresupuestoMatriz("conexion");
                        listaCarga = Carga.ListXCampanaYZona(item);
                        if (listaCarga != null && listaCarga.Count > 0)
                        {
                            okTrans= module.ActualizaTransferPresupuesto(Usuario,item);
                        }
                        else
                        {
                            item.Usuario = Usuario;
                            okTrans=module.InsertRegistroTemporalPrincipal(item);
                        }
                    }
                }
                else 
                {
                    return false;
                }
                return  okTrans;
               
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
        /// Insert datos en la tabla presupuesto matriz
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertRegistro(TrasladoPresupuestoMatrizInfo item)
        {
            try
            {
                return module.InsertRegistro(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }



        /// <summary>
       /// Lista presupuesto por una campana
       /// </summary>
       /// <param name="campana"></param>
       /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> ListxCampana(String campana) {
            return module.ListxCampana(campana);
        }



         /// <summary>
        /// Lista presupuesto por una zona
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public TrasladoPresupuestoMatrizInfo ListxZona(String zona, String campana)
        {
            return module.ListxZona(zona,campana);
        }
        



          /// <summary>
        /// lista el presupuesto matriz usando distinct en campana
        /// </summary>
        /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> ListCampana()
        {
            return module.ListCampana();
        }
        #endregion
    }
}
