using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Contactenos
    /// </summary>
    public class Contactenos : IContactenos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Contactenos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Contactenos()
        {
            module = new Application.Enterprise.Data.Contactenos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Contactenos(string databaseName)
        {
            module = new Application.Enterprise.Data.Contactenos(databaseName);
        }

        /// <summary>
        ///  Lista todos los contactenos de las empresarias.
        /// </summary>
        /// <returns></returns>
        public List<ContactenosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un contactenos x id.
        /// </summary>
        /// <param name="Id">Id del contactenos.</param>
        /// <returns></returns>
        public ContactenosInfo ListxId(int Id)
        {
            return module.ListxId(Id);
        }


        /// <summary>
        /// Guarda un mensaje de contactenos de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Insert(ContactenosInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return "";
            }
        }

        /// <summary>
        /// Realiza la actualizacion del estado de un contactenos existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ContactenosInfo item)
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

    }
}
