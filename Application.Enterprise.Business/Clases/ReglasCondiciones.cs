using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ReglasCondiciones
    /// </summary>
    public class ReglasCondiciones : IReglasCondiciones
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglasCondiciones module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasCondiciones()
        {
            module = new Application.Enterprise.Data.ReglasCondiciones();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasCondiciones(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglasCondiciones(databaseName);
        }

        #region Miembros de IReglasCondiciones
        /// <summary>
        /// lista todos los Paises existentes.
        /// </summary>
        /// <returns></returns>
        public List<ReglasCondicionesInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos las condiciones de una regla especifica.
        /// </summary>
        /// <param name="IdRegla"></param>
        /// <returns></returns>
        public List<ReglasCondicionesInfo> ListxIdRegla(int IdRegla)
        {
            return module.ListxIdRegla(IdRegla);
        }

        /// <summary>
        /// Realiza el registro de una condicion para las reglas.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(ReglasCondicionesInfo item)
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
        /// Realiza la actualizacion de una condicion.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(ReglasCondicionesInfo item)
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

        /// <summary>
        /// Elimina todas las condiciones de una regla.
        /// </summary>
        /// <param name="IdRegla">Id Regla</param>
        /// <returns></returns>
        public bool DeleteCondiciones(int IdRegla)
        {
            try
            {
                return module.DeleteCondiciones(IdRegla);
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
