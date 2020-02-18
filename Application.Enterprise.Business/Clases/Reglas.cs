using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Reglas
    /// </summary>
    public class Reglas : IReglas
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Reglas module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Reglas()
        {
            module = new Application.Enterprise.Data.Reglas();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Reglas(string databaseName)
        {
            module = new Application.Enterprise.Data.Reglas(databaseName);
        }

        #region Miembros de IReglas
        /// <summary>
        /// Lista todas las reglas.
        /// </summary>
        /// <returns></returns>
        public List<ReglasInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Una regla especifica.
        /// </summary>
        /// <param name="IdRegla"></param>
        /// <returns></returns>
        public ReglasInfo ListxId(int IdRegla)
        {
            return module.ListxId(IdRegla);
        }
                       
        /// <summary>
        /// Lista las reglas ordenadas, activas para asignar los pedidos.
        /// </summary>
        /// <returns></returns>
        public List<ReglasInfo> ListAsignarPedidos()
        {
            return module.ListAsignarPedidos();
        }

        /// <summary>
        /// Realiza el registro de una regla.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(ReglasInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }            
        }

        /// <summary>
        /// Realiza la actualizacion del registro de una regla.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(ReglasInfo item)
        {
            try
            {
                return module.Update(item);
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
