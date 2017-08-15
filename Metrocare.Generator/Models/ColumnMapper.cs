using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Generator.Models
{
    public class ColumnMapper
    {
        public String ColumnName { get; set; }
        public String IsNullable { get; set; }
        public String DataType   { get; set; }
        public String MaxLenght  { get; set; }
        public String ColumnKey  { get; set; }
    }
}
