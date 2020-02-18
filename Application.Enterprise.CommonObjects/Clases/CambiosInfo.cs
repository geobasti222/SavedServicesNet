using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class CambiosInfo
    {
        private string nit;

        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }
        private string campana;

        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }
        private string ped_numero;

        public string PedNumero
        {
            get { return ped_numero; }
            set { ped_numero = value; }
        }
        private string fac_numero;

        public string FacNumero
        {
            get { return fac_numero; }
            set { fac_numero = value; }
        }
        private string ent_numero;

        public string EntNumero
        {
            get { return ent_numero; }
            set { ent_numero = value; }
        }
        private DateTime ent_fecha;

        public DateTime EntFecha
        {
            get { return ent_fecha; }
            set { ent_fecha = value; }
        }
        private int ent_anulado;

        public int EntAnulado
        {
            get { return ent_anulado; }
            set { ent_anulado = value; }
        }
    }
}
