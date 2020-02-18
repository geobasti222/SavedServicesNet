using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Lideres
    /// </summary>
    public class Lideres : ILideres
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Lideres module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Lideres()
        {
            module = new Application.Enterprise.Data.Lideres();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Lideres(string databaseName)
        {
            module = new Application.Enterprise.Data.Lideres(databaseName);
        }

        #region Miembros de ILideres
        /// <summary>
        /// Lista todos las lideres.
        /// </summary>
        /// <returns></returns>
        public List<LideresInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos las lideres x zona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<LideresInfo> ListxZona(string IdZona)
        {
            return module.ListxZona(IdZona);
        }

        /// <summary>
        /// Lista todos las lideres x zona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<LideresInfo> ListLideresxZona(string IdZona)
        {
            return module.ListLideresxZona(IdZona);
        }

         /// <summary>
        /// Lista todos las lideres x subzona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<LideresInfo> ListLideresxSubZona(string IdZona)
        {
            return module.ListLideresxSubZona(IdZona);
        }
        /// <summary>
        /// Lista un lider x cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public LideresInfo ListxCedula(string Cedula)
        {
            return module.ListxCedula(Cedula);
        }

        /// <summary>
        /// Lista la ciudad de un lider por usuario.
        /// </summary>
        /// <param name="clave_acce"></param>
        /// <returns></returns>
        public LideresInfo ListxCiudadxUsuario(string clave_acce)
        {
            return module.ListxCiudadxUsuario(clave_acce);
        }


        /// <summary>
        /// Guarda un lider nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(LideresInfo item)
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
        /// Realiza la actualizacion de un lider existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(LideresInfo item)
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
        /// Elimina un lider.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public bool Delete(string Cedula, string Usuario)
        {
            try
            {
                return module.Delete(Cedula, Usuario);
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
