using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Generator.Models
{
    public class TableMapper
    {
        public TableMapper()                       {           }
        public String TableName                    { get; set; }
        public List<ColumnMapper> CollectionColumn { get; set; }
    }
}
