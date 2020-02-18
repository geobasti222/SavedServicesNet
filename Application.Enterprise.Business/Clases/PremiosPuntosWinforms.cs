using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    public class PremiosPuntosWinforms : IPremiosPuntosWinforms
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosPuntosWinforms module;

        public PremiosPuntosWinforms() 
        {
            module = new Application.Enterprise.Data.PremiosPuntosWinforms();
        }

        public PremiosPuntosWinforms(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosPuntosWinforms(databaseName);
        }

        #region Miembros de IPremiosWinform

        public List<PremiosPuntosWinformsInfo> List()
        {
            return module.List();
        }

        public List<PremiosPuntosWinformsInfo> ListXCampana(List<string> lstCampanas)
        {
            string Campanas = string.Empty;
            foreach (string campana in lstCampanas)
                Campanas += campana + ", ";
            Campanas = Campanas.Remove(Campanas.Length - 2, 1);
            
            return module.ListXCampana(Campanas);
        }

        public List<PremiosPuntosWinformsInfo> ListReferenciasYCampanas(string campana, string referencia)
        {
            return module.ListReferenciasYCampanas(campana, referencia);
        }

        public List<PremiosPuntosWinformsInfo> ListSinRefcontenedora(int nivel, string refcontenedora, string filtro)
        {
            return module.ListSinRefcontenedora(nivel, refcontenedora, filtro);
        }

        public string InsertPremiosPuntos(PremiosPuntosWinformsInfo item)
        {
            try
            {
                return module.InsertPremiosPuntos(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        public bool UpdatePremiosPuntos(PremiosPuntosWinformsInfo item)
        {
            try
            {
                return module.UpdatePremiosPuntos(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Metodo que valida y realiza actualizacion o insercion en la tabla SVDN_PREMIOS_PUNTOS_WINFORMS
        /// </summary>
        /// <param name="referencia"></param>
        /// <param name="Puntos"></param>
        /// <param name="Campana"></param>
        /// <param name="Nivel"></param>
        /// <returns>Mensaje despues de la operacion</returns>
        public string guardarPremioPuntos(string referencia, int Puntos, string Campana, int Nivel, string CampanaEntrega, string refcontenedora = "", string sumarpuntos = "")
        {
            string mensaje = string.Empty;
            string strResult = string.Empty;
            PremiosPuntosWinformsInfo ppw = new PremiosPuntosWinformsInfo();
            ppw.Referencia = referencia;
            ppw.Puntos = Puntos;
            ppw.Campana = Campana;
            ppw.Nivel = Nivel;
            ppw.Campana_Entrega = CampanaEntrega;

            if (sumarpuntos != "")
                ppw.SumarPuntos = sumarpuntos;

            if (refcontenedora != "")
                ppw.RefContenedora = refcontenedora;

            List<PremiosPuntosWinformsInfo> lista;

            lista = ListReferenciasYCampanas(Campana, referencia);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    if (UpdatePremiosPuntos(ppw))
                        mensaje = "Registro Actualizado";
                    else
                        mensaje = "Registro no pudo ser Actualizado";
                }
                else
                {
                    strResult = InsertPremiosPuntos(ppw);
                    mensaje = "Registro insertado correctamente";
                }
            }
            return mensaje;
        }

        #endregion
    }
}
