using System;
using System.Text;
using System.Data;
using System.Diagnostics;
//using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Configuration;
using System.Globalization;
using System.IO;
//using codfll;


namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class Tools
    {
        #region Enumerations
        /// <summary>
        /// Enumeración para el tipo de ordenamiento de un DataTable
        /// </summary>		
        public enum OrderType
        {
            /// <summary>
            /// Orden Ascendente
            /// </summary>
            ASC = 0,
            /// <summary>
            /// Orden Descendente
            /// </summary>
            DESC
        }
        #endregion

        #region Funciones de Conversion

        #region Metodos IDataReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool ToBoolean(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetBoolean(dr.GetOrdinal(columnName));
            }
            else return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static byte ToByte(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetByte(dr.GetOrdinal(columnName));
            }
            else return (byte)0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int ToInt32(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetInt32(dr.GetOrdinal(columnName));
            }
            else return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static double ToDouble(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetDouble(dr.GetOrdinal(columnName));
            }
            else return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static float ToFloat(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return (float)dr.GetFloat(dr.GetOrdinal(columnName));
            }
            else return 0F;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ToString(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetString(dr.GetOrdinal(columnName));
            }
            else return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetDateTime(dr.GetOrdinal(columnName));
            }
            else return DateTime.MinValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static decimal ToDecimal(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetDecimal(dr.GetOrdinal(columnName));
            }
            else return (decimal)0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static float ToSingle(IDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetFloat(dr.GetOrdinal(columnName));
            }
            else return (float)0;
        }
        #endregion

        /// <summary>
        /// Devuelve el Booleano en la columna y fila del DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Booleano</returns>
        public static bool ToBoolean(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return false;
            return Convert.ToBoolean(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Booleano en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Booleano</returns>
        public static bool ToBoolean(DataRow dr, string columnName)
        {
            return Convert.ToBoolean(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Booleano contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Boooleano</returns>
        public static bool ToBoolean(object o)
        {
            if (o == null || o == DBNull.Value) return false;
            return Convert.ToBoolean(o);
        }
        /// <summary>
        /// Devuelve el Byte en la columna, fila y DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Byte</returns>
        public static byte ToByte(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToByte(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Byte en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Byte</returns>
        public static byte ToByte(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToByte(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Byte contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Byte</returns>
        public static byte ToByte(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToByte(o);
        }
        /// <summary>
        /// Devuelve el Int16 en la columna y fila del DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Int16</returns>
        public static short ToInt16(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToInt16(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Int16 en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Int16</returns>
        public static short ToInt16(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToInt16(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Int16 contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Int16</returns>
        public static short ToInt16(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToInt16(o);
        }
        /// <summary>
        /// Devuelve el Int32 en la columna, fila y DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Int32</returns>
        public static int ToInt32(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToInt32(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Int32 en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Int32</returns>
        public static int ToInt32(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToInt32(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Int32 contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Int32</returns>
        public static int ToInt32(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToInt32(o);
        }
        /// <summary>
        /// Devuelve el Int64 en la columna y fila del DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Int64</returns>
        public static long ToInt64(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToInt64(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Int64 en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Int64</returns>
        public static long ToInt64(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToInt64(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Int64 contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Int64</returns>
        public static long ToInt64(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToInt64(o);
        }
        /// <summary>
        /// Devuelve el string en la columna, fila y DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El string</returns>
        public static string ToString(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return "";
            return Convert.ToString(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el String en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El String</returns>
        public static string ToString(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return "";
            return Convert.ToString(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el String contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El String</returns>
        public static string ToString(object o)
        {
            if (o == null || o == DBNull.Value) return "";
            return Convert.ToString(o);
        }
        /// <summary>
        /// Devuelve el Single en la columna y fila del DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Single</returns>
        public static float ToSingle(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToSingle(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Single en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Single</returns>
        public static float ToSingle(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToSingle(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Single contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Single</returns>
        public static float ToSingle(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToSingle(o);
        }
        /// <summary>
        /// Devuelve el Double en la columna y fila del DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Double</returns>
        public static double ToDouble(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToDouble(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Double en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Double</returns>
        public static double ToDouble(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToDouble(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Double contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Double</returns>
        public static double ToDouble(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToDouble(o);
        }
        /// <summary>
        /// Devuelve el DateTime en la columna, fila y DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El DateTime</returns>
        public static DateTime ToDateTime(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return DateTime.MinValue;
            return Convert.ToDateTime(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el DateTime en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El DateTime</returns>
        public static DateTime ToDateTime(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return DateTime.MinValue;
            return Convert.ToDateTime(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el DateTime contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El DateTime</returns>
        public static DateTime ToDateTime(object o)
        {
            if (o == null || o == DBNull.Value) return DateTime.MinValue;
            return Convert.ToDateTime(o);
        }
        /// <summary>
        /// Devuelve el Decimal en la columna y fila del DataTable especificado.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="row">Numero de la Fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Decimal</returns>
        public static decimal ToDecimal(DataTable dt, int row, string columnName)
        {
            if (dt.Rows[row].IsNull(columnName)) return 0;
            return Convert.ToDecimal(dt.Rows[row][columnName]);
        }
        /// <summary>
        /// Devuelve el Decimal en la columna del DataRow especificado
        /// </summary>
        /// <param name="dr">DataRow que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns>El Decimal</returns>
        public static decimal ToDecimal(DataRow dr, string columnName)
        {
            if (dr.IsNull(columnName)) return 0;
            return Convert.ToDecimal(dr[columnName]);
        }
        /// <summary>
        /// Devuelve el Decimal contenido en el Object especificado
        /// </summary>
        /// <param name="o">Objecto que contiene el valor</param>
        /// <returns>El Decimal</returns>
        public static decimal ToDecimal(object o)
        {
            if (o == null || o == DBNull.Value) return 0;
            return Convert.ToDecimal(o);
        }

        /// <summary>
        /// Realiza una conversion a lista de strings a partir de una cadena de texto con nueva linea
        /// </summary>
        /// <param name="Texto">cadena del tipo "PA110801\nPA120106\nPA120203"</param>
        /// <returns>lista de strings</returns>
        public static List<string> TextoALista(string Texto)
        {
            List<string> lista = new List<string>(
            Texto.Split(new string[] { "\r\n" },
            StringSplitOptions.RemoveEmptyEntries));
            return lista;
        }

        /// <summary>
        /// Realiza una conversion a lista de strings a partir de una cadena de texto con nueva linea
        /// </summary>
        /// <param name="Texto">cadena del tipo "PA110801\nPA120106\nPA120203"</param>
        /// <returns>lista de strings</returns>
        public static List<string> TextoAListaWeb(string Texto)
        {
            List<string> lista = new List<string>(
            Texto.Split(new string[] { "\r\n", "\n" },
            StringSplitOptions.RemoveEmptyEntries));
            return lista;
        }

        /// <summary>
        /// Convierte una lista de cualquier tipo a DataTable
        /// </summary>
        /// <typeparam name="T">cualquier tipo de variable</typeparam>
        /// <param name="data">Lista de cualquier tipo</param>
        /// <returns>Un datatable conservando la estructura de la lista original</returns>
        public static DataTable ListaADatatableMC<T>(IList<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection properties =
               System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        #endregion

        #region Funciones de DataTables
        /// <summary>
        /// Suma las columnas especificadas por filas
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <param name="column"></param>
        /// <param name="type"></param>
        public static void AddColumnSum(DataTable dt, string columnName, string[] column, System.Type type)
        {
            //Adiciona la columna de total
            dt.Columns.Add(columnName, type);

            //Recorre las filas
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double sum = 0;
                double val = 0;

                for (int j = 0; j < column.Length; j++)
                {
                    try
                    {
                        val = ToDouble(dt.Rows[i][column[j]]);
                    }
                    catch { val = 0; }

                    sum += val;
                }

                dt.Rows[i][columnName] = Convert.ChangeType(sum, type);
            }
        }
        /// <summary>
        /// Adjunta una tabla al final de la otra.  Las tablas deben tener el mismo esquema
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="dtAppend"></param>
        public static void AppendTable(DataTable dtSource, DataTable dtAppend)
        {
            for (int i = 0; i < dtAppend.Rows.Count; i++)
            {
                dtSource.Rows.Add(dtAppend.Rows[i].ItemArray);
            }
        }
        /// <summary>
        /// Devuelve la fila donde el valor especificado es igual al contenido en la columna dada.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos</param>
        /// <param name="columnName">Nombre de la columna donde se va buscar</param>
        /// <param name="value">Valor que se va a buscar</param>
        /// <returns>El número de la fila, -1 si no se encuentra</returns>
        public static int FindInDataTable(DataTable dt, string columnName, object @value)
        {
            int col = dt.Columns.IndexOf(columnName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][col].Equals(@value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Actualiza un DataRow de un DataTable
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="rowIndex">indice del DataRow a actualizar</param>
        /// <param name="values">Pares de valores de la forma {Nombre de la columna,valor}</param>
        public static void UpdateDataRow(DataTable dt, int rowIndex, params object[] values)
        {
            if (rowIndex > dt.Rows.Count - 1) return;
            DataRow dr = dt.Rows[rowIndex];
            for (int i = 0; i < values.Length; i += 2)
            {
                if (!dt.Columns.Contains((string)values[i])) continue;
                dr[(string)values[i]] = values[i + 1];
            }
        }
        /// <summary>
        /// Agrega los valores especificados a un DataTable
        /// </summary>
        /// <param name="dt">DataTable a ser modificado</param>
        /// <param name="values">secuencia valores, deben estar en el orden correspondiente en el DataTAble</param>
        public static void AddDataRow(DataTable dt, params object[] values)
        {
            dt.Rows.Add(values);
        }
        /// <summary>
        /// Agrega un array de DataRows a un DataTable.  los DataRows deben tener el mismo esquema que el DataTable
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="dr">Arreglo de DataTable</param>
        public static void AddDataRow(DataTable dt, DataRow[] dr)
        {
            for (int i = 0; i < dr.Length; i++)
            {
                dt.ImportRow(dr[i]);
            }
        }
        /// <summary>
        /// Ordena los contenidos de un DataTable de acuerdo con los valores contenidos en la columna especificada
        /// </summary>
        /// <param name="dt">DataTable para ordenar</param>
        /// <param name="NameField">Nombre de la columna por donde se va ordenar</param>
        /// <returns>DataTable con los datos ordenados</returns>
        private static DataTable SortTable(DataTable dt, string NameField)
        {
            DataTable dtSort = dt.Clone();
            DataRow[] dr = dt.Select("", NameField);
            DataRow[] draux = (DataRow[])dr.Clone();

            for (int i = 0; i < draux.Length; i++) dtSort.ImportRow(draux[i]);
            return dtSort;
        }
        /// <summary>
        /// Filtra los datos de un DataTable segun el criterio especificado
        /// </summary>
        /// <param name="dt">DataTable para filtrar</param>
        /// <param name="filter">String conteniendo el filtro</param>
        /// <returns>DataTable con los datos filtrados</returns>
        public static DataTable ApplyFilter(DataTable dt, string filter)
        {
            DataTable dtResults = dt.Clone();
            DataRow[] dr = dt.Select(filter);
            DataRow[] draux = (DataRow[])dr.Clone();
            for (int i = 0; i < draux.Length; i++) dtResults.ImportRow(draux[i]);
            return dtResults;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filter"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public static DataTable ApplyFilter(DataTable dt, string filter, string sortExpression)
        {
            DataTable dtResults = dt.Clone();
            DataRow[] dr = dt.Select(filter, sortExpression);
            DataRow[] draux = (DataRow[])dr.Clone();
            for (int i = 0; i < draux.Length; i++) dtResults.ImportRow(draux[i]);
            return dtResults;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public static DataTable SortDataTable(DataTable dt, string sortExpression)
        {
            DataTable dtResults = dt.Clone();
            DataRow[] dr = dt.Select("", sortExpression);
            DataRow[] draux = (DataRow[])dr.Clone();
            for (int i = 0; i < draux.Length; i++) dtResults.ImportRow(draux[i]);
            return dtResults;

        }
        /// <summary>
        /// Convierte el contenido de la columna de un DataTable a un string separados por la cadena especificada.
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos.</param>
        /// <param name="columnName">Nombre de la columna que contiene los datos.</param>
        /// <param name="separator">Separador de la lista.</param>
        /// <returns></returns>
        public static string ColumnToString(DataTable dt, string columnName, string separator)
        {
            if (dt.Rows.Count == 0) return "";
            int col = dt.Columns.IndexOf(columnName);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(dt.Rows[0][col].ToString());
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                sb.Append(separator);
                sb.Append(dt.Rows[i][col]);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <param name="columnNames">Nombre de columnas que se desean incluir en el vector</param>
        /// <returns></returns>
        public static string[] RowToString(DataTable dt, int row, params string[] columnNames)
        {
            try
            {

                string[] returnValue = new string[columnNames.Length];

                for (int j = 0; j < columnNames.Length; j++)
                {
                    returnValue[j] = ToString(dt, row, columnNames[j]);
                }

                return returnValue;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static string[] RowToFormatString(DataTable dt, int row, params string[] columnNames)
        {
            try
            {

                string[] returnValue = new string[columnNames.Length];

                for (int j = 0; j < columnNames.Length; j++)
                {
                    returnValue[j] = ToFormatString(dt, row, columnNames[j]);
                }

                return returnValue;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Convierte un datatable en un array Bi-Dimensional tipo object
        /// Por Henry Rosales P : henryr@softwarelayer.com
        /// 5-4-2004 10:30 ET
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos.</param>	
        /// <returns>Object Array bidimensional con los Datos del Datatable </returns>
        public static object[,] DataTableToArray(DataTable dt)
        {

            int rowCnt = dt.Rows.Count;
            int colCnt = dt.Columns.Count;

            object[,] arr = new object[rowCnt, colCnt];

            for (int xIndex = 0; xIndex < dt.Rows.Count; xIndex++)
            {
                for (int yIndex = 0; yIndex < dt.Columns.Count; yIndex++)
                {
                    object cellData = dt.Rows[xIndex][yIndex];
                    arr[xIndex, yIndex] = cellData;
                }
            }

            return arr;


        }
        /// <summary>
        /// Convierte un datatable en un array Bi-Dimensional tipo object
        /// Por Henry Rosales P : henryr@softwarelayer.com
        /// 5-4-2004 10:30 ET
        /// </summary>
        /// <param name="dt">DataTable que contiene los datos.</param>
        /// <param name="columns">Columnas que contienen los datos a ser pasados al array</param>
        /// <returns>Object Array bidimensional con los Datos del Datatable </returns>
        public static object[,] DataTableToArray(DataTable dt, params string[] columns)
        {

            int rowCnt = dt.Rows.Count;
            int colCnt = columns.Length;

            object[,] arr = new object[rowCnt, colCnt];

            for (int xIndex = 0; xIndex < dt.Rows.Count; xIndex++)
            {
                for (int yIndex = 0; yIndex < columns.Length; yIndex++)
                {
                    object cellData = dt.Rows[xIndex][columns[yIndex]];
                    arr[xIndex, yIndex] = cellData;
                }
            }

            return arr;


        }
        /// <summary>
        /// Escoje los elementos distintintos en una columna dada de un DataTable
        /// </summary>
        /// <param name="dt">DataTable donde se realizará la consulta.</param>
        /// <param name="columnName">Nombre de la columna que contiene los datos.</param>
        /// <returns>Arreglo de Objects con los valores distintos</returns>
        public static DataTable SelectDistinct(DataTable dt, string columnName)
        {

            DataTable dtResult = dt.Clone();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object val = dt.Rows[i][columnName];

                int exist = FindInDataTable(dt, columnName, val);

                if (exist != -1)
                {
                    dtResult.Rows.Add(dt.Rows[i].ItemArray);
                }
            }

            return dtResult;

        }
        /// <summary>
        /// Convierte un DataTable a un string XML
        /// </summary>
        /// <param name="dt">DataTable con la información</param>
        /// <param name="dataTableName">Nombre del DataTable</param>
        /// <returns>Cadena XML con la representación del DataTable</returns>
        public static string DataTableToXML(DataTable dt, string dataTableName)
        {
            DataSet dsContents = new DataSet("Contents_" + dataTableName);
            dt.TableName = dataTableName;
            dsContents.Tables.Add(dt);
            return dsContents.GetXml();
        }
        /// <summary>
        /// Convierte un DataTable a un string separado por valores en filas y columnas(ejemplo, ","y ";")
        /// </summary>
        /// <param name="dt">DataTable con la información</param>
        /// <param name="rowSeparator">Separador de las filas</param>
        /// <param name="columnSeparator">Separador de la columnas</param>
        /// <param name="includeColumnNames">Si incluye o no nombres de las columnas</param>
        /// <returns>Cadena con la representación del DataTable</returns>
        public static string DataTableToString(DataTable dt, string rowSeparator, string columnSeparator, bool includeColumnNames)
        {
            string localData = "";
            if (dt == null || dt.Rows.Count < 1) return localData;
            //Primera fila con nombres de las columnas
            if (includeColumnNames)
            {
                for (int i = 0; i < dt.Columns.Count; i++) localData += ToString(dt.Columns[i].ColumnName) + columnSeparator;
                localData += rowSeparator;
            }
            // A partir de la segunda fila con los datos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++) localData += ToString(dt.Rows[i][j]) + columnSeparator;
                localData.Remove(localData.Length - 1, 1);
                localData += rowSeparator;
            }
            localData.Remove(localData.Length - 1, 1);
            return localData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columName"></param>
        /// <returns></returns>
        public static decimal DataTableSum(ref DataTable dt, string columName)
        {
            decimal sum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += ToDecimal(dt, i, columName);
            }

            return sum;
        }
        /// <summary>
        /// Adiciona una fila al final de datatable con los valores de totales especificados
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="totalFieldName">Columna para colocar el titulo 'Total'</param>
        /// <param name="columnTotals">Nombre de las columnas que se quieren totalizar</param>
        public static void AddTotal(DataTable dt, string totalFieldName, Array columnTotals)
        {
            double[] totals = new double[columnTotals.Length];

            DataRow dr = dt.NewRow();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < columnTotals.Length; j++)
                {
                    double val = Tools.ToDouble(dt, i, columnTotals.GetValue(j).ToString());
                    double actualValue = Tools.ToDouble(dr, columnTotals.GetValue(j).ToString());
                    dr[columnTotals.GetValue(j).ToString()] = actualValue + val;
                }
            }

            dr[totalFieldName] = "TOTAL";

            //Adiciona la fila de totales al datatable
            dt.Rows.Add(dr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="totalFieldName"></param>
        /// <param name="columns"></param>
        public static void AddTotal(DataTable dt, string totalFieldName, params string[] columns)
        {
            double[] totals = new double[columns.Length];

            DataRow dr = dt.NewRow();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    double val = Tools.ToDouble(dt, i, columns[j]);
                    double actualValue = Tools.ToDouble(dr, columns[j]);
                    double totalVal = actualValue + val;
                    dr[columns[j]] = Convert.ChangeType(totalVal, dt.Columns[columns[j]].DataType);
                }
            }

            dr[totalFieldName] = "TOTAL";

            //Adiciona la fila de totales al datatable
            dt.Rows.Add(dr);
        }
        /// <summary>
        /// Adiciona una columna y coloca los totales por filas
        /// </summary>
        /// <param name="dt">Fuente de datos</param>
        /// <param name="columnName">Nombre de la columna donde se calculara el total</param>
        /// <param name="columnStart">Columna de inicio para la sumatoria</param>
        /// <param name="columnEnd">Columna fin para el calculo de la suma</param>
        /// <param name="dType">tipo de Datos de la columna de totales</param>
        /// <returns>Datatable con la modificacion</returns>
        public static DataTable AddRowTotal(DataTable dt, string columnName, int columnStart, int columnEnd, System.Type dType)
        {
            dt.Columns.Add(columnName, dType);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal total = 0;
                for (int j = columnStart; j < columnEnd; j++)
                {
                    total += ToDecimal(dt.Rows[i][j]);
                }
                dt.Rows[i][columnName] = Convert.ChangeType(total, dType);
            }

            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int FindLastInDataTable(DataTable dt, string columnName, object @value)
        {
            int col = dt.Columns.IndexOf(columnName);
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][col].Equals(@value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Escribe un datatable a un archivo plano, no se recomienda para datatables grandes
        /// dado que se escribe al archivo registro a registro
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="exportColumnNames"></param>
        /// <param name="pathFile"></param>
        public static void ExportDataTable(DataTable dt, string pathFile, bool exportColumnNames)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(pathFile, true, System.Text.Encoding.UTF8);

                if (exportColumnNames)
                {
                    string colNames = ToStringArray(dt.Columns, ",");
                    sw.WriteLine(colNames.Substring(0, colNames.Length - 1));
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string registry = ToStringArray(dt.Rows[i].ItemArray, ",");

                    //Recortar el ultimo caracter de separacion
                    registry = registry.Substring(0, registry.Length - 1);

                    sw.WriteLine(registry);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
            }
        }
        /// <summary>
        /// Recibe un datatable comun y retorna un datatable con rotacion de 90 grados. Una tabla Transpuesta
        /// </summary>
        /// <param name="dt">DataTable a realizar la rotacion</param>
        /// <returns>Datatable con las columnas en sentido horizontal</returns>
        public static DataTable TablaTranspuesta(DataTable dt)
        {
            DataTable dest = new DataTable("Pivote" + dt.TableName);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //    dest.Columns.Add(i.ToString());

            dest.Columns.Add(dt.Columns[0].ColumnName);
            for (int i = 0; i < dt.Rows.Count; i++)
                dest.Columns.Add(dt.Rows[i][0].ToString());

            for (int i = 0; i < dt.Columns.Count - 1; i++)
            {
                dest.Rows.Add(dest.NewRow());
            }

            for (int r = 0; r < dest.Rows.Count; r++)
            {
                for (int c = 0; c < dest.Columns.Count; c++)
                {
                    if (c == 0)
                        dest.Rows[r][0] = dt.Columns[r + 1].ColumnName;
                    else
                        dest.Rows[r][c] = dt.Rows[c - 1][r + 1];
                }
            }
            dest.AcceptChanges();
            return dest;
        }

        #endregion

        #region Funciones de Vectores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int FindInVec(Array vector, object val)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                object o = vector.GetValue(i);
                if (o.Equals(val))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// devuelve un array de objects en un array de strings
        /// </summary>
        /// <param name="vector"></param>		
        /// <returns></returns>
        public static string[] ToStringArray(object[] vector)
        {
            string[] retValue = new string[vector.Length];
            for (int i = 0; i < retValue.Length; i++)
            {
                retValue[i] = vector[i].ToString();

            }
            return retValue;
        }
        /// <summary>
        /// Convierte un vector de objetos en un cadena de texto
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToStringArray(object[] vector, string separator)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < vector.Length; i++)
            {
                string text = string.Format("{0}{1}", ToString(vector[i]), separator);
                sb.Append(text);
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToStringArray(System.Data.DataColumnCollection col, string separator)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < col.Count; i++)
            {
                string text = string.Format("{0},", ToString(col[i].ColumnName));
                sb.Append(text);
            }

            return sb.ToString();
        }
        #endregion

        #region Funciones de Excepciones
        /// <summary>
        /// Retorna el error completo de la exepcion ingresada
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetAllError(Exception ex)
        {
            //Copia el objeto de exepcion
            Exception t = ex;
            System.Text.StringBuilder StrResults = new System.Text.StringBuilder();

            //Recorre hasta que no hayan mas exepciones
            while (t != null)
            {
                StrResults.Append(t.Message + " ::: ");
                t = t.InnerException;
            }

            StrResults.Append(" StactTrace: " + ex.StackTrace);
            return StrResults.ToString();
        }
        /// <summary>
        /// Constructor con separador
        /// </summary>
        /// <param name="ex">Exepcion</param>
        /// <param name="separator">Cadena que separa las exepciones</param>
        /// <returns></returns>
        public static string GetAllError(Exception ex, string separator)
        {
            //Copia el objeto de exepcion
            Exception t = ex;
            System.Text.StringBuilder StrResults = new System.Text.StringBuilder();

            //Recorre hasta que no hayan mas exepciones
            while (t != null)
            {
                StrResults.Append(t.Message + separator);
                t = t.InnerException;
            }
            return StrResults.ToString();
        }
        #endregion

        #region Funciones de cadenas
        /// <summary>
        /// Convierte e
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TitleCase(string text)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool capital = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (capital)
                {
                    sb.Append(char.ToUpper(text[i]));
                    capital = false;
                }
                else
                {
                    sb.Append(char.ToLower(text[i]));
                }
                if (text[i] == ' ') capital = true;
            }
            return sb.ToString();
        }
        /// <summary>
        /// Quita puntos del texto de una Cédula
        /// </summary>
        /// <param name="docNumber">Texto del NIT</param>
        /// <returns>Cédula sin formato</returns>
        public static string RemoveDocNumberFormat(string docNumber)
        {
            return docNumber.Replace(".", "");
        }
        /// <summary>
        /// Aplica el formato a una cédula.
        /// </summary>
        /// <param name="docNumber">Cédula.</param>
        /// <returns>Cédula con el formato.</returns>
        public static string FormatDocNumber(string docNumber)
        {
            string temp = RemoveDocNumberFormat(docNumber);
            if (temp.Length > 3)
            {
                int first;
                int groups = Math.DivRem(temp.Length - 3, 3, out first);
                string result = first == 0 ? "" : temp.Substring(0, first) + ".";
                for (int i = 0; i < groups; i++)
                {
                    result += temp.Substring(first + 3 * i, 3) + ".";
                }
                return result + temp.Substring(first + 3 * groups, 3);
            }
            else
            {
                return temp;
            }
        }
        /// <summary>
        /// Registra un evento al evenlog de windows
        /// </summary>
        /// <param name="source"></param>		
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void WriteWindowsLog(string source, string message, EventLogEntryType type)
        {
            try
            {
                EventLog.WriteEntry(source, message, type);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(GetAllError(ex));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static DataTable GetTotals(DataTable dt, params string[] columnNames)
        {
            DataTable dtResult = dt.Clone();

            DataRow dr = dtResult.NewRow();
            for (int j = 0; j < columnNames.Length; j++)
            {
                decimal total = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total += Tools.ToDecimal(dt, i, columnNames[j]);
                }
                dr[columnNames[j]] = total;
            }

            //Adiciona el total al datatable resultado
            dtResult.Rows.Add(dr);

            return dtResult;
        }
        /// <summary>
        /// Realiza la suma de la columna especificada
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>		
        /// <returns></returns>
        public static object SumColumn(DataTable dt, string columnName)
        {
            System.Type type = dt.Columns[columnName].DataType;

            float total = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += ToSingle(dt, i, columnName);
            }

            return Convert.ChangeType(total, type);
        }
        /// <summary>
        /// Ajusta un texto en el numero de caracteres especificado de ancho
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string AdjustText(string text, int width)
        {
            if (text.Length > 0 && width > 0)
            {
                int counter = (int)(text.Length / width);

                if (counter > 0)
                {
                    int pos = width;
                    for (int i = 1; i <= counter; i++)
                    {
                        //Busca el espacio mas cercano
                        int posSpace = text.LastIndexOf(" ", pos);

                        //Si no lo encuentra, cortar en pos
                        posSpace = posSpace == -1 ? pos : posSpace;

                        //Insertar un salto de seccion
                        text = text.Insert(posSpace, "\n");

                        //Incrementar el contador de ancho de parrafo
                        pos += width + 1;
                    }
                }
            }
            return text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToFormatString(object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Int32:
                    return string.Format("{0,15:N}", o);
                default:
                    return ToString(o);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ToFormatString(DataTable dt, int row, string columnName)
        {
            object o = dt.Rows[row][columnName];

            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Int32:
                    return string.Format("{0,15:N}", o);
                default:
                    return ToString(o);
            }
        }
        #endregion

        #region Funciones de Serializacion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static System.IO.MemoryStream Serialize(object o)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.MemoryStream mem = new System.IO.MemoryStream();

            f.Serialize(mem, o);

            return mem;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public static object Deserialize(System.IO.MemoryStream mem)
        {
            mem.Position = 0;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            object o = f.Deserialize(mem);

            mem.Close();

            return o;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /*public static string SerializeToString(object o)
        {
            System.IO.MemoryStream mem = Serialize(o);
            mem.Position = 0;

            byte[] buffer = mem.ToArray();

            return HexEncoding.GetString(buffer);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object DeserializeFromString(string data)
        {
            int val;

            byte[] buffer = HexEncoding.GetBytes(data, out val);

            System.IO.MemoryStream mem = new System.IO.MemoryStream(buffer);

            return Deserialize(mem);
        }*/
        #endregion

        #region Funciones de Fechas

        /// <summary>
        /// Recibe un tipo DayWeek y retorna su dia en string
        /// </summary>
        /// <param name="diaSemana"></param>
        /// <returns></returns>
        public static string FormatDay(DayOfWeek diaSemana)
        {

            string cadenaDiaSemana = "Domingo";


            switch (diaSemana)
            {
                case DayOfWeek.Monday:
                    cadenaDiaSemana = "Lunes"; break;
                case DayOfWeek.Tuesday:
                    cadenaDiaSemana = "Martes"; break;
                case DayOfWeek.Wednesday:
                    cadenaDiaSemana = "Miércoles"; break;
                case DayOfWeek.Thursday:
                    cadenaDiaSemana = "Jueves"; break;
                case DayOfWeek.Friday:
                    cadenaDiaSemana = "Viernes"; break;
                case DayOfWeek.Saturday:
                    cadenaDiaSemana = "Sábado"; break;
                default: //case DayOfWeek.Sunday:
                    cadenaDiaSemana = "Domingo"; break;
            }

            return cadenaDiaSemana;
        }
        #endregion

        #region Funciones de Criptografia
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        ///// <summary>
        ///// Encripta una cadena con el algorito de G&G
        ///// </summary>
        ///// <param name="toEncrypt"></param>
        ///// <returns></returns>
        //public static string EncryptCYPHER(string toEncrypt)
        //{
        //    codflls DllCypher = new codflls();

        //    return DllCypher.encripta(toEncrypt);
        //}

        ///// <summary>
        ///// Desencripta una cadena con el algorito de G&G
        ///// </summary>
        ///// <param name="cipherString"></param>
        ///// <returns></returns>
        //public static string DecryptCYPHER(string cipherString)
        //{
        //    codflls DllCypher = new codflls();

        //    return DllCypher.Decripta(cipherString);
        //}
        #endregion

        #region funciones de redondeo

        /// <summary>
        /// redondea un numero a 0,5. ej: 2.1 = 2.0, 2.3 = 2.5
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>numero redondeado</returns>
        public static double RedondearCeroCinco(double numero)
        {
            return Math.Round(numero / 0.5) * 0.5;
        }

        #endregion

        #region funciones de textbox

        /// <summary>
        /// Metodo que valida si la cadena de texto es solo numerico
        /// </summary>
        /// <param name="text">string numerico</param>
        /// <returns>Respuesta falso o verdadero a validacion de string numerico</returns>
        public static bool EsNumero(string text)
        {
            bool res = true;
            try
            {
                if (!string.IsNullOrEmpty(text.Trim()) && ((text.Trim().Length != 1) || (text.Trim() != "-")))
                {
                    Decimal d = decimal.Parse(text, CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }

        #endregion

        #region funciones de archivo

        /// <summary>
        /// Metodo que abre una busqueda de archivo txt
        /// </summary>
        /// <param name="BuscarUbicacionArchivo">True: si va a buscar el archivo en la ruta deseada.  False si esta en la carpeta que contiene el ejecutable</param>
        /// <param name="archivo">Opcional: el nombre del archivo CON extension</param>
        /// <returns>Una lista de strings separados por los saltos de lineas del texto</returns>
        /*public static List<string> LeerArchivo(bool BuscarUbicacionArchivo, string archivo = "")
        {
            List<string> resultado = new List<string>();
            string ruta = string.Empty;
            OpenFileDialog dialogo = new OpenFileDialog();
            StreamReader objLector;

            try
            {
                if (BuscarUbicacionArchivo)
                {
                    dialogo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    dialogo.Filter = "Archivos txt (*.txt)|*.txt|Todos (*.*)|*.*";
                    dialogo.FilterIndex = 1;
                    dialogo.RestoreDirectory = true;

                    if (dialogo.ShowDialog() == DialogResult.OK)
                    {
                        if ((ruta = dialogo.FileName.ToString()) != null)
                        {
                            using (objLector = new StreamReader(ruta.ToString()))
                            {
                                string sLine = "";
                                while (sLine != null)
                                {
                                    sLine = objLector.ReadLine();
                                    if (sLine != null)
                                        resultado.Add(sLine);
                                }
                                objLector.Close();
                            }
                            //resultado = ObtenerContenidoArchivo(ruta);
                        }
                    }
                }
                else
                {
                    ruta = System.IO.Directory.GetCurrentDirectory() + @"\" + archivo;
                    using (objLector = new StreamReader(ruta.ToString()))
                    {
                        string sLine = "";
                        while (sLine != null)
                        {
                            sLine = objLector.ReadLine();
                            if (sLine != null)
                                resultado.Add(sLine);
                        }
                        objLector.Close();
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se puede leer archivo del disco. \r\n Error Originado: " + ex.Message);
            }
            return resultado;
        }

        public static bool GuardarArchivo(bool BuscarUbicacionArchivo, string Texto, string archivo = "")
        {
            bool guardado = true;
            try
            {
                if (BuscarUbicacionArchivo)
                {
                    SaveFileDialog dialogo = new SaveFileDialog();
                    dialogo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    dialogo.Filter = "Archivos txt (*.txt)|*.txt|Todos (*.*)|*.*";
                    dialogo.FilterIndex = 1;
                    dialogo.RestoreDirectory = true;

                    if (dialogo.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(dialogo.FileName.ToString(), Texto);
                }
                else
                    File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + @"\" + archivo, Texto);                
            }
            catch
            {
                guardado = false;
            }
            return guardado;
        }*/

        /// <summary>
        /// GAVL Instruccion para Cadenas
        /// </summary>
        /// <param name="param"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(string param, int length)
        {

            string result = param.Substring(0, length);
            return result;
        }

        /// <summary>
        /// GAVL Instruccion para Cadenas
        /// </summary>
        /// <param name="param"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        #endregion

        #region funcion fecha
        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion



    }
}
