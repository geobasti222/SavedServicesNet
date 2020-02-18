using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ClasificacionXValorProceso
    /// </summary>
    
    public class ClasificacionXValorProceso : IClasificacionXValorProceso
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ClasificacionXValorProceso module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ClasificacionXValorProceso()
        {
            module = new Application.Enterprise.Data.ClasificacionXValorProceso();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ClasificacionXValorProceso(string databaseName)
        {
            module = new Application.Enterprise.Data.ClasificacionXValorProceso(databaseName);
        }

        #region Miembros de IClasificacionXValorProceso

        /// <summary>
        /// Traer todas las empresarias por campaña
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> List(ClasificacionXValorProcesoInfo item)
        {
            return module.List(item);
        }

        /// <summary>
        /// Traer las empresarias por campaña y nit
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXNit(ClasificacionXValorProcesoInfo item)
        {
            return module.ListXNit(item);
        }

        /// <summary>
        /// Traer promedios por campaña primera division
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXPrimerCuadrante(ClasificacionXValorProcesoInfo item)
        {
            return module.ListXPrimerCuadrante(item);
        }

        /// <summary>
        /// Traer promedios por campaña segunda division
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXSegundoCuadrante(ClasificacionXValorProcesoInfo item)
        {
            return module.ListXSegundoCuadrante(item);
        }

        /// <summary>
        /// Trae orden promedio Maximo
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXOrdenPromedioMaximo(ClasificacionXValorProcesoInfo item)
        {
            return module.ListXOrdenPromedioMaximo(item);
        }

        /// <summary>
        /// Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListConFiltro(ClasificacionXValorProcesoInfo item)
        {
            return module.ListConFiltro(item);
        }

        /// <summary>
        /// Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListConFiltroEstados(ClasificacionXValorProcesoInfo item)
        {
            return module.ListConFiltroEstados(item);
        }

        /// <summary>
        /// Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListConFiltroCount(ClasificacionXValorProcesoInfo item)
        {
            return module.ListConFiltroCount(item);
        }

        /// <summary>
        /// Trae cantidades de empresarias por clasificacion filtradas por region y zona 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListCantidadesConFiltro(ClasificacionXValorProcesoInfo item)
        {
            return module.ListCantidadesConFiltro(item);
        }

        /// <summary>
        /// Trae cantidades de empresarias por clasificacion filtradas por region y zona 
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXNitUltimaCampana(ClasificacionXValorProcesoInfo item)
        {
            return module.ListXNitUltimaCampana(item);
        }

        /// <summary>
        /// Ejecuta procedimiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ClasificacionXValorProcesoInfo item)
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
