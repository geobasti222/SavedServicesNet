using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de MailPlan
    /// </summary>
    public interface IMailPlan
    {
        #region "Metodos de MailPlan"

        /// <summary>
        /// lista todos los MailPlan existentes.
        /// </summary>
        /// <returns></returns>
        List<MailPlanInfo> List();

        /// <summary>
        /// Lista un mailplan x id
        /// </summary>
        /// <param name="IdMailPlan"></param>
        /// <returns></returns>
        MailPlanInfo ListxId(int IdMailPlan);

        /// <summary>
        /// Lista un mailplan x fecha y zona si esta activo para ingresar pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        MailPlanInfo ListxZonaxId(string Zona);

        /// <summary>
        /// lista todos los MailPlan existentes para facturacion.
        /// </summary>
        /// <returns></returns>
        List<MailPlanInfo> ListMailPlanFacturacion();

        /// <summary>
        ///--Lista un mailplan de facturacion diaria x fecha y zona si esta activo para ingresar pedidos.
        ///-- si hay mas de un mail plan activo solo se trae 1 que es el ultimo de la fecha configurado.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        MailPlanInfo ListxZonaxIdxFacturacionDiaria(string Zona);

        /// <summary>
        /// Lista todos los mailplan de facturacion diaria.
        /// </summary>
        /// <returns></returns>
        List<MailPlanInfo> ListMailPlanFacturacionDiaria();

        /// <summary>
        /// Lista un mailplan de facturacion diaria x id
        /// </summary>
        /// <param name="IdMailPlan"></param>
        /// <returns></returns>
        MailPlanInfo ListxIdFacturacionDiaria(int IdMailPlan);

        /// <summary>
        /// Guarda un mailplan nuevo.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(MailPlanInfo item);

        /// <summary>
        /// Guarda un mailplan de facturacion diaria nuevo.
        /// </summary>
        /// <param name="item"></param>
        bool InsertFacturacionDiaria(MailPlanInfo item);

        /// <summary>
        /// Realiza la actualizacion de un mailplan existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(MailPlanInfo item);

        /// <summary>
        /// Realiza la actualizacion de un mailplan de facturacion diaria existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateFacturacionDiaria(MailPlanInfo item);


        #endregion
    }
}

