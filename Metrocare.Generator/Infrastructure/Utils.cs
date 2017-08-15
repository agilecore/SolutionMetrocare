using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Generator.Models;
using Metrocare.Generator.Connections;
using System.IO;
using System.Configuration;
using Metrocare.Generator.Enums;

namespace Metrocare.Generator.Infrastructure
{
    public static class Utils
    {
        private static String FilePath = ConfigurationManager.AppSettings["PathDto"].ToString();
        private static String FilePathController = ConfigurationManager.AppSettings["PathController"].ToString();
        private static TableMapper LoadOracle(String TableName)
        {
            var TableMap = new TableMapper();
            var Query = String.Format(@"SELECT a.column_name column_name, 
                                               CASE a.nullable         
                                                    WHEN 'Y' then 'yes' 
                                                    WHEN 'N' then 'no' 
                                                    ELSE ''
                                               END is_nullable,       
                                               LOWER(a.data_type) data_type,        
                                               a.data_length maximum_length,
                                               CASE b.constraint_type 
                                                    WHEN 'P' THEN 'pk' 
                                                    ELSE ''
                                               END column_key  
                                          FROM all_tab_columns a,       
                                               (SELECT w.column_name, 
                                                       g.constraint_type,
                                                       w.table_name
                                                  FROM all_cons_columns w, all_constraints g  
                                                 WHERE w.constraint_name = g.constraint_name(+) 
                                                   AND g.constraint_type = 'P' ORDER BY 1) b  
                                         WHERE a.table_name  = b.table_name(+) 
                                           AND a.column_name = b.column_name(+) 
                                           AND a.table_name  = '{0}'", TableName);

            using (var Conexao = new ConnectionOracle(Query, string.Empty))
            {
                if (Conexao.Open())
                {
                    var Collection = new List<ColumnMapper>();
                    TableMap.TableName = TableName;

                    while (Conexao.LerRegistro())
                    {
                        var Column = new ColumnMapper();

                        Column.ColumnName = Conexao.Ler("COLUMN_NAME").ToString();
                        Column.IsNullable = Conexao.Ler("IS_NULLABLE").ToString();
                        Column.DataType   = Conexao.Ler("DATA_TYPE").ToString();
                        Column.MaxLenght  = Conexao.Ler("MAXIMUM_LENGTH").ToString();
                        Column.ColumnKey  = Conexao.Ler("COLUMN_KEY").ToString();

                        Collection.Add(Column);
                    }

                    TableMap.CollectionColumn = Collection;
                }
            }
            return (TableMap);
        }
        public static String GetColumnTypeOracle(String Columndatatype)
        {
            var datatype = String.Empty;

            if ((Columndatatype == "char") || (Columndatatype == "varchar") || (Columndatatype == "varchar2") || (Columndatatype == "nvarchar2") || (Columndatatype == "text") || (Columndatatype == "longtext") || (Columndatatype == "clob") || (Columndatatype == "long") || (Columndatatype == "nchar") || (Columndatatype == "nclob") || (Columndatatype == "rowid")) { datatype = "System.String"; }
            if ((Columndatatype == "binary") || (Columndatatype == "varbinary") || (Columndatatype == "blob") || (Columndatatype == "bfile") || (Columndatatype == "longblob") || (Columndatatype == "raw")) { datatype = "System.Byte[]"; }
            if ((Columndatatype == "datetime") || (Columndatatype == "date") || (Columndatatype == "timestamp")) { datatype = "System.DateTime"; }
            if ((Columndatatype == "decimal") || (Columndatatype == "float") || (Columndatatype == "integer")) { datatype = "System.Decimal"; }
            if ((Columndatatype == "int") || (Columndatatype == "number")) { datatype = "System.Int32"; }
            if ((Columndatatype == "boolean") || (Columndatatype == "bit")) { datatype = "System.Boolean"; }
            if ((Columndatatype == "tinyint") || (Columndatatype == "unsigned")) { datatype = "System.Byte"; }
            if ((Columndatatype == "double")) { datatype = "System.Double"; }
            if ((Columndatatype == "smallint")) { datatype = "System.Int16"; }
            if ((Columndatatype == "bigint")) { datatype = "System.Int64"; }
            if ((Columndatatype == "tinyint")) { datatype = "System.SByte"; }
            if ((Columndatatype == "float")) { datatype = "System.Single"; }
            if ((Columndatatype == "time")) { datatype = "System.TimeSpan"; }

            return (datatype);
        }
        
        /// <summary>
        /// Gerar o arquivo como classe DTO (Data Tranfer Object).
        /// </summary>
        /// <param name="ClassName">Nome da classe sem espaços.</param>
        /// <param name="Folder">Diretório onde sera gerado o arquivo.</param>
        public static String CreateFile(String Class, String Folder, String Content, ETier Tier)
        {
            var FileName = String.Format(@"{0}.{1}", Class, "cs");
            var Diretory = String.Format(@"{0}\{1}", ((ETier.WebUI == Tier) ? FilePathController : FilePath), Folder);
            var FullFile = String.Format(@"{0}\{1}", Diretory, FileName);
            var DirInfo = new DirectoryInfo(Diretory);

            if (!DirInfo.Exists) { DirInfo.Create(); } //Verifica se existe, se não cria o arquivo
            using (var Writer = File.CreateText(FullFile)) { Writer.WriteLine(Content.ToString());}

            return (FileName);
        }

        /// <summary>
        /// Retorna metadados da tabela do banco de dados.
        /// </summary>
        /// <param name="Table">Nome da tabela do banco de dados.</param>
        /// <param name="Conexao">Conexão ja aberta.</param>
        public static TableMapper GetColumnsOracle(String Table)
        {
            var Mapper = new TableMapper();
            var QueryBuild = new StringBuilder();
           
            QueryBuild.Append(" SELECT UPPER(A.COLUMN_NAME)       AS COLUMN_NAME        ");
            QueryBuild.Append("      , LOWER(A.DATA_TYPE)         AS DATA_TYPE          ");
            QueryBuild.Append("      , UPPER(A.DATA_LENGTH)       AS DATA_LENGTH        ");
            QueryBuild.Append("      , UPPER(A.COLUMN_ID)         AS COLUMN_ID          ");
            QueryBuild.Append("      , UPPER(B.COLUMN_NAME)       AS COLUMN_NAME        ");
            QueryBuild.Append("      , CASE A.NULLABLE                                  ");
            QueryBuild.Append("             WHEN 'Y' then 'yes'                         ");
            QueryBuild.Append("             WHEN 'N' then 'no'                          ");
            QueryBuild.Append("             ELSE ''                                     ");
            QueryBuild.Append("        END NULLABLE                                     ");
            QueryBuild.Append("      , CASE B.CONSTRAINT_TYPE                           "); 
            QueryBuild.Append("             WHEN 'P' THEN 'pk'                          ");
            QueryBuild.Append("             ELSE ''                                     ");
            QueryBuild.Append("        END CONSTRAINT_TYPE                              ");
            QueryBuild.Append(" FROM ALL_TAB_COLUMNS A,                                 ");
            QueryBuild.Append("      (                                                  ");
            QueryBuild.Append("         SELECT W.COLUMN_NAME                            ");
            QueryBuild.Append("              , G.CONSTRAINT_TYPE                        ");
            QueryBuild.Append("              , W.TABLE_NAME                             ");
            QueryBuild.Append("           FROM ALL_CONS_COLUMNS  W                      ");
            QueryBuild.Append("              , ALL_CONSTRAINTS   G                      ");
            QueryBuild.Append("          WHERE W.CONSTRAINT_NAME = G.CONSTRAINT_NAME(+) ");
            QueryBuild.Append("            AND G.CONSTRAINT_TYPE = 'P'                  ");
            QueryBuild.Append("          ORDER BY 1                                     ");
            QueryBuild.Append("      ) B                                                ");
            QueryBuild.Append(" WHERE A.TABLE_NAME  = B.TABLE_NAME (+)                  ");
            QueryBuild.Append("   AND A.COLUMN_NAME = B.COLUMN_NAME(+)                  ");
            QueryBuild.Append(String.Format("   AND A.TABLE_NAME  = '{0}' ",       Table));
            QueryBuild.Append(" ORDER BY COLUMN_ID ASC                                  ");
            
            using (var Conexao = new ConnectionOracle(String.Format(QueryBuild.ToString(), Table), String.Empty))
            {
                if (Conexao.Open())
                {
                    var Collection = new List<ColumnMapper>();

                    while (Conexao.LerRegistro())
                    {
                        var Column = new ColumnMapper();

                        Column.ColumnName = Conexao.Ler("COLUMN_NAME").ToString();
                        Column.DataType   = Conexao.Ler("DATA_TYPE").ToString();
                        Column.MaxLenght  = Conexao.Ler("DATA_LENGTH").ToString();
                        Column.IsNullable = Conexao.Ler("NULLABLE").ToString();
                        Column.ColumnKey  = Conexao.Ler("CONSTRAINT_TYPE").ToString();
                        
                        Collection.Add(Column);
                    }

                    Mapper.CollectionColumn = Collection;
                }

                return (Mapper);
            }
        }
    }
}
