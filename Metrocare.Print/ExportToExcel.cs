using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metronic.Print.Interfaces;
using Microsoft.Office.Interop.Excel;

namespace Metronic.Print
{
    //http://www.c-sharpcorner.com/UploadFile/deveshomar/exporting-generic-listt-to-excel-in-C-Sharp-using-interop/
    public class ExportToExcel : IExportToExcel
    {
        /// <summary>
        /// Exporta dados da um datatable para planilha do excel.
        /// </summary>
        /// <param name="DataList">Lista de dados em Datatable.</param>
        /// <param name="ColumnWidth">Expecifica o tamanho de uma coluna</param>
        public void ExportDataToExcelWorkbook(System.Data.DataTable DataList, Double ColumnWidth)
        {
            if (DataList.Rows.Count > 0)
            {
                var Worksheet = new Microsoft.Office.Interop.Excel.Application();

                try
                {
                    Worksheet.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < DataList.Columns.Count + 1; i++)
                    {
                        Worksheet.Cells[1, i] = DataList.Columns[i - 1].ColumnName; 
                    }

                    for (int i = 0; i < DataList.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < DataList.Columns.Count; j++)
                        {
                            //Excel.Cells[i + 2, j + 1] = Data.Rows[i].Cells[j].Value.ToString();
                            Worksheet.Cells[i + 2, j + 1] = DataList.Rows[i][j].ToString();
                        }
                    }

                    if (ColumnWidth > 0) { Worksheet.Columns.ColumnWidth = ColumnWidth; } else { Worksheet.Columns.AutoFit(); }

                    Worksheet.Visible = true;
                }
                catch (Exception ex)
                {
                    Worksheet.Quit();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Exporta dados da um dataset para planilha do excel.
        /// </summary>
        /// <param name="DataList">Lista de dados em DataSet.</param>
        /// <param name="ColumnWidth">Expecifica o tamanho de uma coluna</param>
        public void ExportDataToExcelWorkbook(System.Data.DataSet DataList, Double ColumnWidth)
        {      
            if (DataList.Tables.Count > 0)
            {
                var Data = DataList.Tables[0];

                if (Data.Rows.Count > 0)
                {
                    var Worksheet = new Microsoft.Office.Interop.Excel.Application();

                    try
                    {
                        Worksheet.Application.Workbooks.Add(Type.Missing);

                        for (int i = 1; i < Data.Columns.Count + 1; i++)
                        {
                            Worksheet.Cells[1, i] = Data.Columns[i - 1].ColumnName;
                        }

                        for (int i = 0; i < Data.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < Data.Columns.Count; j++)
                            {
                                Worksheet.Cells[i + 2, j + 1] = Data.Rows[i][j].ToString();
                            }
                        }

                        if (ColumnWidth > 0) { Worksheet.Columns.ColumnWidth = ColumnWidth; } else { Worksheet.Columns.AutoFit(); }

                        Worksheet.Visible = true;

                        // -------------------------
                        // Expecificação
                        // -------------------------
                        // object GetSaveAsFilename
                        // (
                        //     [In, Optional] object InitialFilename,  //--> Especifica o nome de arquivo sugerido. Se este argumento for omitido, o Microsoft Excel usará o nome da pasta de trabalho ativa.
                        //     [In, Optional] object FileFilter,       //--> Uma sequência de caracteres que especifica os critérios de filtragem de arquivos.
	                    //     [In, Optional] object FilterIndex,      //--> Especifica o número do índice do critério de filtragem do arquivo padrão, de 1 para o número de filtros especificados em FileFilter. Se este argumento for omitido ou maior do que o número de filtros presentes, o primeiro filtro de arquivo é usado.
                        //     [In, Optional] object Title,            //--> Especifica o título da caixa de diálogo. Se este argumento for omitido, o título padrão é usado.
                        //     [In, Optional] object ButtonText        //--> Apenas para Macintosh.
                        // );

                        Worksheet.GetSaveAsFilename
                        (    
                             InitialFilename : "export", 
                             FileFilter      : "Xls Format (*.xls),*.xls"
                        );
                    }
                    catch (Exception ex)
                    {
                        Worksheet.Quit();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Converte um tipo IList para datatable.
        /// </summary>
        /// <typeparam name="T">objeto que sera dentro da lista</typeparam>
        /// <param name="data">IList de objetos para ser convertido em datatable.</param>
        public System.Data.DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var retorno = new System.Data.DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                retorno.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                var row = retorno.NewRow();
                foreach (PropertyDescriptor prop in properties) { row[prop.Name] = prop.GetValue(item) ?? DBNull.Value; }
                retorno.Rows.Add(row);
            }

            return (retorno);
        }

        //private void ExportToExcel(string fileName, bool hasColumnHeaders, double columnWidth)
        //{
        //    ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
        //    DiskFileDestinationOptions diskOpts = new
        //    DiskFileDestinationOptions();

        //    // Set the excel format options.
        //    excelFormatOpts.ExcelTabHasColumnHeadings = true;
        //    excelFormatOpts.ExcelUseConstantColumnWidth = hasColumnHeaders;
        //    excelFormatOpts.ExcelConstantColumnWidth = columnWidth;
        //    Report.ExportOptions.ExportFormatType = ExportFormatType.Excel;
        //    Report.ExportOptions.FormatOptions = excelFormatOpts;

        //    // Set the disk file options and export.
        //    Report.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //    diskOpts.DiskFileName = fileName;
        //    Report.ExportOptions.DestinationOptions = diskOpts;

        //    Report.Export();
        //}
    }
}
