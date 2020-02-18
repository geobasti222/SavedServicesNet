using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// JA
    /// </summary>
    public class MatrizComercialMeta:IMatrizComercialMeta
    {
         /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MatrizComercialMeta module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MatrizComercialMeta()
        {
            module = new Application.Enterprise.Data.MatrizComercialMeta();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MatrizComercialMeta(string databaseName)
        {
            module = new Application.Enterprise.Data.MatrizComercialMeta(databaseName);
        }

        /// <summary>
        /// lista el presupuesto matriz usando distinct en campana
        /// </summary>
        /// <returns></returns>
        public List<MatrizComercialMetaInfo> ListCampana()
        {
            return module.ListCampana();
        }

        /// <summary>
        /// Lista presupuesto por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialMetaInfo> ListxCampana(String campana)
        {
            return module.ListxCampana(campana);
        }

        /// <summary>
        /// Eliminar una meta
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="zona"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool DeleteMeta(string Campana, string zona, string usuario)
        {
            try
            {
                return module.DeleteMeta(Campana, zona, usuario);
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
        public bool InsertRegistroMeta(MatrizComercialMetaInfo item)
        {
            try
            {
                return module.InsertRegistroMeta(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        
        /// <summary>
        /// obtiene una Zona existente mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public MatrizComercialMetaInfo ListxZona(String zona, String campana)
        {
            return module.ListxZona(zona, campana);
        }

    }
}
