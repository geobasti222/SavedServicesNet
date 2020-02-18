using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Parametros
    /// </summary>
    public class Parametros : IParametros
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Parametros module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Parametros()
        {
            module = new Application.Enterprise.Data.Parametros();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Parametros(string databaseName)
        {
            module = new Application.Enterprise.Data.Parametros(databaseName);
        }

        #region Miembros de IParametros
        /// <summary>
        /// Lista todos los parametros del sistema
        /// </summary>
        /// <returns></returns>
        public List<ParametrosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un parametro especifico del sistema
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ParametrosInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }

        /// <summary>
        /// Realiza la actualizacion de un parametro del sistema.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ParametrosInfo item)
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
