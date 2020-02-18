using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Historico Cliente
    /// </summary>
    public class HistoricoCliente : IHistoricoCliente
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.HistoricoCliente module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public HistoricoCliente()
        {
            module = new Application.Enterprise.Data.HistoricoCliente();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public HistoricoCliente(string databaseName)
        {
            module = new Application.Enterprise.Data.HistoricoCliente(databaseName);
        }

        #region Miembros de IHistoricoCliente

        /// <summary>
        /// Guarda un historico de clientes nuevo.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(HistoricoClienteInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Insercion de todos los campos en la tabla SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool FullInsert(HistoricoClienteInfo item)
        {
            try
            {
                return module.FullInsert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Clonacion del historico de una campaña en campaña siguiente
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="id_campana_orig">Origen: 1. Actual  -  2. Una atras  -  3. Dos atras  -  4 Proxima</param>
        /// <param name="id_campana_dest">Destino: 1. Actual  -  2. Una atras  -  3. Dos atras  -  4 Proxima</param>
        /// <returns></returns>
        public bool InsCopyPasteHistoricoEntreCampanas(DateTime fecha, int id_campana_orig, int id_campana_dest)
        {
            return module.InsCopyPasteHistoricoEntreCampanas(fecha, id_campana_orig, id_campana_dest);
        }
                
        /// <summary>
        /// Realiza insercion de los clientes que son prospectos en la tabla de SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertNuevoProspecto(DateTime fecha)
        {
            try
            {
                return module.InsertNuevoProspecto(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Insercion de Nuevas, Activas, Retenidas y Reingresos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertEstadosIngresos(DateTime fecha)
        {
            try
            {
                return module.InsertEstadosIngresos(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Insercion de Posibles Egresos, Egresos e Inactivas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertEstadosInactividades(DateTime fecha)
        {
            try
            {
                return module.InsertEstadosInactividades(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Insercion de prospectos de campaña anterior en nueva campaña
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertProspectosCampAnterior(DateTime fecha)
        {
            try
            {
                return module.InsertProspectosCampAnterior(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina los registros de SVDN_CLIENTES_HISTORICO que hayan anulado todos sus pedidos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool EliminarPedidosAnulados(DateTime fecha)
        {
            try
            {
                return module.EliminarPedidosAnulados(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Fix del Bug que se genera al insertar nuevos prospectos
        /// Este procedimiento se encarga de eliminar los prospectos que se insertaron despues
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool EliminarProspectosFix(DateTime fecha)
        {
            try
            {
                return module.EliminarProspectosFix(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado activo de un historico existente.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateEstadoActivo(HistoricoClienteInfo item)
        {
            try
            {
                return module.UpdateEstadoActivo(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Actualizacion de empresaria que haya realizado pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateEmpresariasEstadoConPedido(DateTime fecha)
        {
            try
            {
                return module.UpdateEmpresariasEstadoConPedido(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }            
        }

        /// <summary>
        /// Actualizacion de empresaria que NO haya realizado pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateEmpresariasEstadoSinPedido(DateTime fecha)
        {
            try
            {
                return module.UpdateEmpresariasEstadoSinPedido(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }              
        }

        /// <summary>
        /// Actualizacion de campos de empresarias prospectos que puedan tener inconsistencias
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateProspectosIncompletos(DateTime fecha)
        {
            try
            {
                return module.UpdateProspectosIncompletos(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }               
        }

        /// <summary>
        /// Actualizacion de campos de empresarias que realizan anulaciones de todos sus pedidos.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateAnulaciones(DateTime fecha)
        {
            try
            {
                return module.UpdateAnulaciones(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            } 
        }

        /// <summary>
        /// ACTUALIZACION DE ESTADOS EN LA TABLA CLIENTES
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateTablaClientes(DateTime fecha)
        {
            try
            {
                return module.UpdateTablaClientes(fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        ///// <summary>
        ///// Actualizacion a Nuevas tomando todas las inactivas con mas de 18 campañas de inactividad
        ///// </summary>
        ///// <param name="fecha"></param>
        ///// <returns></returns>
        //public bool UpdateInactivasANuevas(DateTime fecha)
        //{
        //    try
        //    {
        //        return module.UpdateInactivasANuevas(fecha);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

        //        return false;
        //    }
        //}

        /// <summary>
        /// Lista todos los historicos de clientes
        /// </summary>
        /// <returns></returns>
        public List<HistoricoClienteInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista de informe comparativo de variables de la tabla de historicos de clientes entre campañas actual, anterior y año pasado
        /// </summary>
        /// <returns></returns>
        public List<HistoricoClienteComparacionInfo> HistoricoComparacion(DateTime fecha)
        {
            return module.HistoricoComparacion(fecha);
        }

        #endregion
    }
}
