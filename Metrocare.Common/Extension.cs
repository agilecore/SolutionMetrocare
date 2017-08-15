using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Exemplo https://msdn.microsoft.com/pt-br/library/bb383977.aspx
    /// </summary>
    public static class Extension
    {                    
        /// <summary>
        /// Verifica se vazio (empty) e troca pelo valor informado. Exemplo: str.DefaultIfEmpty("I'm exemple") retornara -> I'm exemple se string for vazia.
        /// </summary>
        /// <param name="value">Valor a ser verificado.</param>
        /// <param name="defaultValue">Valor padrão se vazio.</param>
        /// <param name="considerWhiteSpaceIsEmpty">Considera espaços.</param>
        /// <returns></returns>
        public static string DefaultIfEmpty(this string value, string defaultValue, bool considerWhiteSpaceIsEmpty = false)
        {
            return (considerWhiteSpaceIsEmpty ? string.IsNullOrWhiteSpace(value) : string.IsNullOrEmpty(value)) ? defaultValue : value;
        }

        /// <summary>
        /// Verifica se a string é uma data.
        /// </summary>
        /// <param name="value">String a ser verificada.</param>
        public static bool IsDate(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                DateTime dt;
                return (DateTime.TryParse(value, out dt));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Trunca o texto com '...' após uma determinada quantidade de carácteres.
        /// </summary>
        /// <param name="text">Texto a ser truncado.</param>
        /// <param name="maxLength">Numero de carácteres para truncar.</param>
        public static string Truncate(this string text, int maxLength)
        {
            // replaces the truncated string to a ...
            const string suffix = "...";
            string truncatedString = text;

            if (maxLength <= 0) return truncatedString;
            int strLength = maxLength - suffix.Length;

            if (strLength <= 0) return truncatedString;

            if (text == null || text.Length <= maxLength) return truncatedString;

            truncatedString = text.Substring(0, strLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;
            return truncatedString;
        }

        /// <summary>
        /// Retorna (true) se endereço de email é valido ou false se não for válido.
        /// </summary>
        /// <param name="value">String a ser verificada.</param>
        public static bool IsValidEmail(this string value)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Verifica se o um tipo inteiro é maior que zero.
        /// </summary>
        /// <param name="source">Tipo inteiro a ser verificado.</param>
        /// <returns></returns>
        public static bool GreaterZero(this int source)
        {
            return ((source > 0) ? true : false);
        }

        /// <summary>
        /// Retorna (true) se objeto é null ou quando objeto for uma string vazia.
        /// </summary>
        /// <param name="source">Objeto a ser verificado.</param>
        /// <returns></returns>
        public static bool IsEmptyOrNull(this object source)
        {
            var ret = false;

            if (source != null)
            {
                var t = (string)source;
                if (t == String.Empty) { ret = true; }
            }
            else
            {
                ret = true; 
            }

            return ret;
        }

        /// <summary>
        /// Retorna (true) se objeto data é null ou quando objeto for uma string vazia.
        /// </summary>
        /// <param name="source">Objeto a ser verificado.</param>
        /// <returns></returns>
        public static bool IsDateNull(this object source)
        {
            var ret = false;

            if (source != null)
            {
                var t = (DateTime)source;
                if (t == null) { ret = true; }
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// Verifica se o objeto passado é nulo.
        /// </summary>
        /// <param name="source">Objeto a ser verificado.</param>
        /// <returns></returns>
        public static bool IsNull(this object source)
        {
            return source == null;
        }

        /// <summary>
        /// Verifica se o tipo passado é um tipo numérico.
        /// </summary>
        /// <param name="value">String de verificação se numerico ou não.</param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            long retNum;
            return long.TryParse(value, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }

        /// <summary>
        /// Verifica se um tipo string é null ou vazio.
        /// </summary>
        /// <param name="value">String de verificação.</param>
        public static bool StringIsNullOrEmpty(this string value)
        {
            return !String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Verifica quantas letras contem na string passada.
        /// </summary>
        /// <param name="value">String de verificação.</param>
        public static int WordCount(this string value)
        {
            return value.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// http://www.extensionmethod.net/1753/csharp/data/datatable-to-csv-export
        /// </summary>
        /// <param name="table"></param>
        /// <param name="delimiter"></param>
        /// <param name="includeHeader"></param>
        public static void ToCSV(this DataTable table, string delimiter, bool includeHeader)
        {
            var result = new StringBuilder();

            if (includeHeader)
            {
                foreach (DataColumn column in table.Columns)
                {
                    result.Append(column.ColumnName);
                    result.Append(delimiter);
                }

                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }

            foreach (DataRow row in table.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    if (item is System.DBNull)
                        result.Append(delimiter);
                    else
                    {
                        var itemAsString = item.ToString();

                        // Double up all embedded double quotes  
                        itemAsString = itemAsString.Replace("\"", "\"\"");

                        // To keep things simple, always delimit with double-quotes  
                        // so we don't have to determine in which cases they're necessary 
                        // and which cases they're not.  
                        itemAsString = "\"" + itemAsString + "\"";
                        result.Append(itemAsString + delimiter);
                    }
                }

                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }

            using (StreamWriter writer = new StreamWriter(@"C:\log.csv", true))
            {
                writer.Write(result.ToString());
            }
        }

        /// <summary>
        /// http://www.extensionmethod.net/1742/csharp/ienumerable-t/todatatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        /// <summary>
        /// Converte formato de data para padrao inglês.
        /// </summary>
        public static DateTime ToUSFormatDate(this string value)
        {
            var result = DateTime.ParseExact(value, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            return (result);
        }

        /// <summary>
        /// Converte formato de data para padrao brasileiro
        /// </summary>
        public static DateTime ToBRFormatDate(this string value)
        {
            var result = DateTime.ParseExact(value, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            return (result);
        }

        //public static int GetEnumIndex(this Enum enumerable)
        //{
        //    return Convert.ToInt32(enumerable);
        //}

        //public static bool IsDateNullOrEmpty(this DateTime source)
        //{
        //    var ret = false;

        //    if (source != null)
        //    {
        //        var t = (DateTime)source;
        //        if (t == null) { ret = true; }
        //    }
        //    else
        //    {
        //        ret = true;
        //    }

        //    return ret;
        //}
    }
}
