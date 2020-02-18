using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para ClasificacionXValorProceso
    /// </summary>

    public class CommercialMatrix : ICommercialMatrix
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.CommercialMatrix module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CommercialMatrix()
        {
            module = new Application.Enterprise.Data.CommercialMatrix();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public CommercialMatrix(string databaseName)
        {
            module = new Application.Enterprise.Data.CommercialMatrix(databaseName);
        }

        #region Miembros de ICommercialMatrix

        /// <summary>
        /// Traer la Matriz Comercial Completa
        /// </summary>
        /// <returns></returns>

        public DataTable HacerPivote(DataTable dt_temp)
        {
            DataTable dt = new DataTable();

            try
            {

                List<DataRow> filas = new List<DataRow>();

                DataColumn col = new DataColumn(dt_temp.Columns[0].ColumnName);

                col.DataType = System.Type.GetType("System.String");

                dt.Columns.Add(col);

                foreach (DataRow dr in dt_temp.Rows)
                {
                    col = new DataColumn(dr[0].ToString());
                    col.DataType = System.Type.GetType("System.String");
                    dt.Columns.Add(col);
                }

                for (int i = 0; i < dt_temp.Columns.Count - 1; i++)
                {
                    DataRow row = dt.NewRow();
                    filas.Add(row);
                }

                int j = 0;

                for (int i = 0; i < filas.Count; i++)
                {
                    filas[i][0] = dt_temp.Columns[i + 1].ColumnName;
                    j = 1;
                    foreach (DataRow dr in dt_temp.Rows)
                    {
                        filas[i][j] = dr[i + 1].ToString();
                        j++;
                    }
                }

                for (int i = 0; i < filas.Count; i++)
                {
                    dt.Rows.Add(filas[i]);
                }
            }
            catch (Exception e)
            {
                dt = dt_temp;
            }
            return dt;
        }

        public DataTable traerCampanas(int vistaCampanas)
        {
            return module.traerCampanas(vistaCampanas);
        }

        public DataTable traerMailgroups()
        {
            return module.traerMailgroups();
        }

        public DataTable traerAsistentes()
        {
            return module.traerAsistentes();
        }

        public DataTable traerDivisiones()
        {
            return module.traerDivisiones();
        }

        public DataTable traerZonasXDivisiones(int division)
        {
            return module.traerZonasXDivisiones(division);
        }

        public DataTable traerZonasXMailgroups(int mailgroup)
        {
            return module.traerZonasXMailgroups(mailgroup);
        }

        public DataTable traerZonasXAsistentes(string asistente)
        {
            return module.traerZonasXAsistentes(asistente);
        }

        public DataTable MatrizComercialCompleta(string cpini, string cpfin, int vista)
        {
            return module.MatrizComercialCompleta(cpini, cpfin, vista);
        }

        public DataTable MatrizComercialCompletaXDivision(string cpini, string cpfin, int vista, int division)
        {
            return module.MatrizComercialCompletaXDivision(cpini, cpfin, vista, division);
        }

        public DataTable MatrizComercialCompletaXMailgroup(string cpini, string cpfin, int vista, int mailgroup)
        {
            return module.MatrizComercialCompletaXMailgroup(cpini, cpfin, vista, mailgroup);
        }

        public DataTable MatrizComercialCompletaXAsistente(string cpini, string cpfin, int vista, string asistente)
        {
            return module.MatrizComercialCompletaXAsistente(cpini, cpfin, vista, asistente);
        }

        public DataTable MatrizComercialCompletaXZona(string cpini, string cpfin, int vista, string zona)
        {
            return module.MatrizComercialCompletaXZona(cpini, cpfin, vista, zona);
        }

        public DataTable MatrizComercialDivision(string cpini, int vista)
        {
            return module.MatrizComercialDivision(cpini, vista);
        }

        public DataTable MatrizComercialMailgroup(string cpini, int vista)
        {
            return module.MatrizComercialMailgroup(cpini, vista);
        }

        public DataTable MatrizComercialAsistente(string cpini, int vista)
        {
            return module.MatrizComercialAsistente(cpini, vista);
        }

        public DataTable MatrizComercialZona(string cpini, int vista)
        {
            return module.MatrizComercialZona(cpini, vista);
        }

        public DataTable MatrizComercialZonaConDivisional(string cpini, int vista, int division)
        {
            return module.MatrizComercialZonaConDivisional(cpini, vista, division);
        }

        public DataTable MatrizComercialZonaConAsistente(string cpini, int vista, string asistente)
        {
            return module.MatrizComercialZonaConAsistente(cpini, vista, asistente);
        }

        public DataTable ClasificacionXValorCompleta(string cpini)
        {
            return module.ClasificacionXValorCompleta(cpini);
        }

        public DataTable ClasificacionXValorDivision(string cpini, int division)
        {
            return module.ClasificacionXValorDivision(cpini, division);
        }

        public DataTable ClasificacionXValorMailGroup(string cpini, int mailgroup)
        {
            return module.ClasificacionXValorMailGroup(cpini, mailgroup);
        }

        public DataTable ClasificacionXValorZona(string cpini, string zona)
        {
            return module.ClasificacionXValorZona(cpini, zona);
        }

        public List<decimal> MatrizComercialPorcentajes(int id)
        {
            return module.MatrizComercialPorcentajes(id);
        }

        public DataTable ListaEmpresariasCampanaZonaEstado(string campana, string zona, int estado, string TipoAgrupamiento)
        {
            return module.ListaEmpresariasCampanaZonaEstado(campana, zona, estado, TipoAgrupamiento);
        }

        // ***********************************************************************************************************
        // INICIO: METODOS DEL PROCESO
        // ***********************************************************************************************************

        public DataTable traerCampanasParaProcesar()
        {
            return module.traerCampanasParaProcesar();
        }

        public DataTable traerInformacionDeCampanaParaProcesar(string campana)
        {
            return module.traerInformacionDeCampanaParaProcesar(campana);
        }

        public void proceso01(string campana_actual, string campana_anterior, DateTime fecha_inicio, DateTime fecha_fin)
        {
            module.proceso01(campana_actual, campana_anterior, fecha_inicio, fecha_fin);
        }

        public void proceso02(string campana_actual)
        {
            module.proceso02(campana_actual);
        }

        public void proceso03(string campana_actual, string campana_anterior)
        {
            module.proceso03(campana_actual, campana_anterior);
        }

        public void proceso04(string campana_actual)
        {
            module.proceso04(campana_actual);
        }
        
        public void proceso04_extendido(string campana_actual, string opcion)
        {
            module.proceso04_extendido(campana_actual, opcion);
        }
        
        public void proceso05(string campana_actual, string campana_anterior)
        {
            module.proceso05(campana_actual, campana_anterior);
        }

        public void proceso05_extendido(string campana_actual, string campana_anterior, string opcion)
        {
            module.proceso05_extendido(campana_actual, campana_anterior, opcion);
        }

        public void proceso06(string campana_actual, string campana_anterior)
        {
            module.proceso06(campana_actual, campana_anterior);
        }

        public void proceso07(string campana_actual)
        {
            module.proceso07(campana_actual);
        }

        public void proceso08(string campana_actual)
        {
            module.proceso08(campana_actual);
        }

        public void proceso09()
        {
            module.proceso09();
        }

        // ***********************************************************************************************************
        // FIN: METODOS DEL PROCESO
        // ***********************************************************************************************************

        #endregion
    }
}
