using System;
using System.Collections.Generic;
using Application.Enterprise.CommonObjects;
using System.Text;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IPremiosPuntosWinforms
    {
        #region "Metodos de PremiosWinform"

        List<PremiosPuntosWinformsInfo> List();

        List<PremiosPuntosWinformsInfo> ListXCampana(List<string> campana);

        List<PremiosPuntosWinformsInfo> ListReferenciasYCampanas(string campana, string referencia);

        List<PremiosPuntosWinformsInfo> ListSinRefcontenedora(int nivel, string refcontenedora, string filtro);

        string InsertPremiosPuntos(PremiosPuntosWinformsInfo item);

        bool UpdatePremiosPuntos(PremiosPuntosWinformsInfo item);

        #endregion
    }
}
