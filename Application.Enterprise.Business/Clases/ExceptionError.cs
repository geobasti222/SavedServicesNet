using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ExceptionError
    /// </summary>
    public class ExceptionError : IExceptionError
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ExceptionError module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ExceptionError()
        {
            module = new Application.Enterprise.Data.ExceptionError();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ExceptionError(string databaseName)
        {
            module = new Application.Enterprise.Data.ExceptionError(databaseName);
        }

        #region Miembros de IExceptionError

             

        /// <summary>
        /// Alamacena la información de un usuario.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        public bool RegistrarException(ExceptionErrorInfo item)
        {
            try
            {
                return module.RegistrarException(item);
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