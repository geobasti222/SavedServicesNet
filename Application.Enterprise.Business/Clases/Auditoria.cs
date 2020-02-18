using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Auditoria
    /// </summary>
    public class Auditoria : IAuditoria
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Auditoria module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Auditoria()
        {
            module = new Application.Enterprise.Data.Auditoria();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Auditoria(string databaseName)
        {
            module = new Application.Enterprise.Data.Auditoria(databaseName);
        }

        #region Miembros de IAuditoria
        /// <summary>
        /// lista todos las Auditorias existentes.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaInfo> List()
        {
            return module.List();
        }
        
        /// <summary>
        /// Guarda un proceso de auditoria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(AuditoriaInfo item)
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

        #endregion
    }
}
