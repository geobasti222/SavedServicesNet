using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    public class PremiosWinform : IPremiosWinform
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosWinform module;

        public PremiosWinform()
        {
            module = new Application.Enterprise.Data.PremiosWinform();
        }

        public PremiosWinform(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosWinform(databaseName);
        }

        #region Miembros de IPremiosWinform
        
        /// <summary>
        /// Lista todos los premioswinform
        /// </summary>
        /// <returns></returns>
        public List<PremiosWinformInfo> List(string Campana, string MinimoPuntos, List<string> lReferenciasCorrea, List<string> lPLUExcluidas, string CampanaEntrega)
        {
            string ReferenciasCorrea = string.Empty;
            string PLUExcluidas = ", ";

            if (lReferenciasCorrea.Count > 0)
            {
                foreach (string refcor in lReferenciasCorrea)
                    ReferenciasCorrea = ReferenciasCorrea + "'" + refcor + "', ";
                ReferenciasCorrea = ReferenciasCorrea.Remove(ReferenciasCorrea.Length - 2, 1);
            }

            if (lPLUExcluidas.Count > 0)
            {
                foreach (string pluex in lPLUExcluidas)
                    PLUExcluidas = PLUExcluidas + pluex + ", ";

                PLUExcluidas = PLUExcluidas.Remove(PLUExcluidas.Length - 2, 1);
            }

            if (ReferenciasCorrea.Trim() == string.Empty)
                ReferenciasCorrea = "' '";
            if (PLUExcluidas.Trim() == ",")
                PLUExcluidas = string.Empty;

            return module.List(Campana, MinimoPuntos, ReferenciasCorrea, PLUExcluidas, CampanaEntrega);
        }

        /// <summary>
        /// Lista la cantidad solicitada de resultados
        /// </summary>
        /// <param name="MinimoPuntos"></param>
        /// <param name="CantResults"></param>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="RefContenedora"></param>
        /// <returns></returns>
        public List<PremiosWinformInfo> ListCantidadSolicitada(string Campana, string MinimoPuntos, string CantResults, List<string> lReferenciasCorrea, string RefContenedora, List<string> lPLUExcluidas, string CampanaEntrega)
        {
            string ReferenciasCorrea = string.Empty;
            string PLUExcluidas = ", ";

            if (lReferenciasCorrea.Count > 0)
            {
                foreach (string refcor in lReferenciasCorrea)
                    ReferenciasCorrea = ReferenciasCorrea + "'" + refcor + "', ";
                ReferenciasCorrea = ReferenciasCorrea.Remove(ReferenciasCorrea.Length - 2, 1);
            }
            if (lPLUExcluidas.Count > 0)
            {
                foreach (string refex in lPLUExcluidas)
                    PLUExcluidas = PLUExcluidas + refex + ", ";
                PLUExcluidas = PLUExcluidas.Remove(PLUExcluidas.Length - 2, 1);
            }

            if (ReferenciasCorrea.Trim() == string.Empty)
                ReferenciasCorrea = "' '";
            if (PLUExcluidas.Trim() == ",")
                PLUExcluidas = string.Empty;

            return module.ListCantidadSolicitada(Campana, MinimoPuntos, CantResults, ReferenciasCorrea, RefContenedora, PLUExcluidas, CampanaEntrega);
        }

        /// <summary>
        /// Lista todos los premioswinform adicionando puntos sobrantes
        /// </summary>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="CampanaPremio"></param>
        /// <param name="ReferenciaPremio"></param>
        /// <returns></returns>
        public List<PremiosWinformInfo> ListSobrantes(List<string> lReferenciasCorrea, string CampanaPremio, string MinimoPuntos, string ReferenciaPremio, List<string> lPLUExcluidas, string CampanaEntrega, string PedidoMinimo)
        {
            string ReferenciasCorrea = string.Empty;
            string PLUExcluidas = ", ";

            if (lReferenciasCorrea.Count > 0)
            {
                foreach (string refcor in lReferenciasCorrea)
                    ReferenciasCorrea = ReferenciasCorrea + "''" + refcor + "'', ";
                ReferenciasCorrea = ReferenciasCorrea.Remove(ReferenciasCorrea.Length - 2, 1);
            }
            if (lPLUExcluidas.Count > 0)
            {
                foreach (string refex in lPLUExcluidas)
                    PLUExcluidas = PLUExcluidas + refex + ", ";
                PLUExcluidas = PLUExcluidas.Remove(PLUExcluidas.Length - 2, 1);
            }

            //if (ReferenciasCorrea.Trim() == string.Empty)
            //    ReferenciasCorrea = string.Empty;
            if (PLUExcluidas.Trim() == ",")
                PLUExcluidas = string.Empty;

            return module.ListSobrantes(ReferenciasCorrea, CampanaPremio, MinimoPuntos, ReferenciaPremio, PLUExcluidas, CampanaEntrega, PedidoMinimo);
        }

        /// <summary>
        /// Lista todos los premioswinform adicionando puntos acumulados
        /// </summary>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="CampanaPremio"></param>
        /// <param name="ReferenciaPremio"></param>
        /// <returns></returns>
        public List<PremiosWinformInfo> ListAcumulados(char opcAcum, string MinimoPuntos, List<string> lReferenciasCorrea, string RefContenedora, string CampanaPremio, List<string> lPLUExcluidas, string CampanaEntrega, string PedidoMinimo, bool IncluyePadre)
        {
            string ReferenciasCorrea = string.Empty;
            string PLUExcluidas = ", ";

            if (lReferenciasCorrea.Count > 0)
            {
                foreach (string refcor in lReferenciasCorrea)
                    ReferenciasCorrea = ReferenciasCorrea + "'" + refcor + "', ";
                ReferenciasCorrea = ReferenciasCorrea.Remove(ReferenciasCorrea.Length - 2, 1);
            }
            if (lPLUExcluidas.Count > 0)
            {
                foreach (string refex in lPLUExcluidas)
                    PLUExcluidas = PLUExcluidas + refex + ", ";
                PLUExcluidas = PLUExcluidas.Remove(PLUExcluidas.Length - 2, 1);
            }

            if (ReferenciasCorrea.Trim() == string.Empty)
                ReferenciasCorrea = "' '";
            if (PLUExcluidas.Trim() == ",")
                PLUExcluidas = string.Empty;

            return module.ListAcumulados(opcAcum, MinimoPuntos, ReferenciasCorrea, CampanaPremio, RefContenedora, PLUExcluidas, CampanaEntrega, PedidoMinimo, IncluyePadre.ToString());            
        }               

        /// <summary>
        /// Lista los detalles de un pedido de acuerdo a una cedula y  campaña, se incluyen las referencias a excluir
        /// </summary>
        /// <param name="CampanaPremio"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public List<PremiosWinformPedidoInfo> ListPedidoDetalle(string CampanaPremio, List<string> lPLUExcluidas, string Cedula, string NroPedido)
        {
            string PLUExcluidas = ", ";

            if (lPLUExcluidas.Count > 0)
            {
                foreach (string refex in lPLUExcluidas)
                    PLUExcluidas = PLUExcluidas + refex + ", ";
                PLUExcluidas = PLUExcluidas.Remove(PLUExcluidas.Length - 2, 1);
            }

            if (PLUExcluidas.Trim() == ",")
                PLUExcluidas = string.Empty;

            return module.ListPedidoDetalle(CampanaPremio, PLUExcluidas, Cedula, NroPedido);
        }

        /// <summary>
        /// Lista los detalles de unan devolucion de acuerdo a una cedula y campaña, se incluyen las referencias a excluir
        /// </summary>
        /// <param name="CampanaPremio"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public List<PremiosWinformPedidoInfo> ListDevolucionDetalle(string CampanaPremio, List<string> lPLUExcluidas, string Cedula)
        {
            string PLUExcluidas = ", ";

            if (lPLUExcluidas.Count > 0)
            {
                foreach (string refex in lPLUExcluidas)
                    PLUExcluidas = PLUExcluidas + refex + ", ";
                PLUExcluidas = PLUExcluidas.Remove(PLUExcluidas.Length - 2, 1);
            }

            if (PLUExcluidas.Trim() == ",")
                PLUExcluidas = string.Empty;

            return module.ListDevolucionDetalle(CampanaPremio, PLUExcluidas, Cedula);
        }

        /// <summary>
        /// Se carga el contenido de un archivo plano en un campo de texto.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public string cargararchivo(string nombreArchivo)
        {
            string InfoObtenida = string.Empty;
            //List<string> ContenidoArchivo = Tools.LeerArchivo(false, nombreArchivo + ".txt");
            //foreach (string str in ContenidoArchivo)
            //    InfoObtenida += str + "\r\n";
            return InfoObtenida;
        }

        #endregion

    }
}
