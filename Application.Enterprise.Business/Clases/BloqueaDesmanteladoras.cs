using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class BloqueaDesmanteladoras 
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.BloqueaDesmanteladoras module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public BloqueaDesmanteladoras()
        {
            module = new Application.Enterprise.Data.BloqueaDesmanteladoras();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public BloqueaDesmanteladoras(string databaseName)
        {
            module = new Application.Enterprise.Data.BloqueaDesmanteladoras(databaseName);
        }

        #region Miembros de BloqueaDesmanteladoras
        /// <summary>
        /// Bloquea Desmanteladora
        /// </summary>
        /// <returns></returns>
        public int BloquearDesmanteladoras(string Usuario)
        {
            try
            {
                return module.BloquearDesmanteladoras(Usuario);
            }
            catch (Exception ex)
            {

                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                return 0;
            }
            
        }

        public List<DesmanteladasInfo> ListDesmanteladas()
        {
            try
            {
                 return module.ListDesmanteladas();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return new List<DesmanteladasInfo>();
            }
        }


        public List<DesmanteladasInfo> ListDesmanteladasXFecha(string Fecha)
        {
            try
            {
                return module.ListDesmanteladasXFecha(Fecha);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return new List<DesmanteladasInfo>();
            }
        }

        #endregion
    }
}
