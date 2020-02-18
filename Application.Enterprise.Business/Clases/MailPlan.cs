using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para MailPlan
    /// </summary>
    public class MailPlan : IMailPlan
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MailPlan module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MailPlan()
        {
            module = new Application.Enterprise.Data.MailPlan();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MailPlan(string databaseName)
        {
            module = new Application.Enterprise.Data.MailPlan(databaseName);
        }

        #region Miembros de IMailPlan
        /// <summary>
        /// lista todos los MailPlan existentes.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un mailplan x id
        /// </summary>
        /// <param name="IdMailPlan"></param>
        /// <returns></returns>
        public MailPlanInfo ListxId(int IdMailPlan)
        {
            return module.ListxId(IdMailPlan);
        }

        /// <summary>
        /// Lista un mailplan x fecha y zona si esta activo para ingresar pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public MailPlanInfo ListxZonaxId(string Zona)
        {
            return module.ListxZonaxId(Zona);
        }


        /// <summary>
        /// lista todos los MailPlan existentes para facturacion.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanInfo> ListMailPlanFacturacion()
        {
            return module.ListMailPlanFacturacion();
        }

        /// <summary>
        ///--Lista un mailplan de facturacion diaria x fecha y zona si esta activo para ingresar pedidos.
        ///-- si hay mas de un mail plan activo solo se trae 1 que es el ultimo de la fecha configurado.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public MailPlanInfo ListxZonaxIdxFacturacionDiaria(string Zona)
        {
            return module.ListxZonaxIdxFacturacionDiaria(Zona);
        }

        /// <summary>
        /// Lista todos los mailplan de facturacion diaria.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanInfo> ListMailPlanFacturacionDiaria()
        {
            return module.ListMailPlanFacturacionDiaria();
        }

         /// <summary>
        /// Lista un mailplan de facturacion diaria x id
        /// </summary>
        /// <param name="IdMailPlan"></param>
        /// <returns></returns>
        public MailPlanInfo ListxIdFacturacionDiaria(int IdMailPlan)
        {
            return module.ListxIdFacturacionDiaria(IdMailPlan);
        }

        /// <summary>
        /// Guarda un mailplan nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(MailPlanInfo item)
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

        /// <summary>
        /// Guarda un mailplan de facturacion diaria nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertFacturacionDiaria(MailPlanInfo item)
        {
            try
            {
                return module.InsertFacturacionDiaria(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de un mailplan existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailPlanInfo item)
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
        /// Realiza la actualizacion de un mailplan de facturacion diaria existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateFacturacionDiaria(MailPlanInfo item)
        {
            try
            {
                return module.UpdateFacturacionDiaria(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza Actualizacion para Cerrar o Abrir todos los Mailplan
        /// </summary>
        /// <param name="Option"></param>
        /// <returns></returns>
        public bool UpdateCerrarTodos(int Option, string Usuario)
        {
            try
            {
                return module.UpdateCerrarTodos(Option,Usuario);



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
