using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metronic.Print.Interfaces
{
    public interface IExportToExcel
    {
        void ExportDataToExcelWorkbook(System.Data.DataTable DataList, Double ColumnWidth);
        void ExportDataToExcelWorkbook(System.Data.DataSet DataList, Double ColumnWidth);
    }
}
