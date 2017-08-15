using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Generator.Infrastructure;
using Metrocare.Generator.Models;
using Metrocare.Generator.Connections;
using Metrocare.Generator.Enums;

namespace Metrocare.Generator.Infrastructure
{
    public class BuilderCommonDto
    {
        private String ProjectName = "Metronic";

        /// <summary>
        /// Cria objeto base para modelos de Dto's.
        /// </summary>
        public String BuildBaseDto()
        {
            var TextClass = new StringBuilder();

            TextClass.AppendLine("using System;");
            TextClass.AppendLine("using System.Linq;");
            TextClass.AppendLine("using System.Text;");
            TextClass.AppendLine("using System.Collections.Generic;");
            TextClass.AppendLine("using System.Threading.Tasks;");
            TextClass.AppendLine("");
            TextClass.AppendLine("namespace " + ProjectName + ".Common.Models");
            TextClass.AppendLine("{");
            TextClass.AppendLine("    public class Base");
            TextClass.AppendLine("    {");
            TextClass.AppendLine("        public Int32 Id { get; set; }");
            TextClass.AppendLine("    }");
            TextClass.AppendLine("}");

            return (string.Format("Gerado o classe Dto {0}...", Utils.CreateFile("Base", "Models", TextClass.ToString(), ETier.Data)));
        }

        /// <summary>
        /// Cria objeto dto das tabelas do banco de dados.
        /// </summary>
        /// <param name="TableName">Nome da tabela do banco de dados.</param>
        /// <param name="ModelConf">Expecificação de configuração da tabela para gerar o objeto (Conceito de classe POCOS).</param>
        /// <param name="Conexao">conexão com o banco ja aberta.</param>
        public String BuildClassDto(String TableName, ModelConfig ModelConf)
        {
            var ColumnDataType = String.Empty;
            var TextClass = new StringBuilder();

            TextClass.AppendLine("using System;");
            TextClass.AppendLine("using System.Linq;");
            TextClass.AppendLine("using System.Text;");
            TextClass.AppendLine("using System.Threading.Tasks;");
            TextClass.AppendLine("using System.Collections.Generic;");
            TextClass.AppendLine("");
            TextClass.AppendLine("namespace " + ProjectName + ".Common.Models");
            TextClass.AppendLine("{");
            TextClass.AppendLine("    public class " + ModelConf.ClassName + "Dto : Base, ICloneable");
            TextClass.AppendLine("    {");

            var Mapper = Utils.GetColumnsOracle(TableName);

            foreach (var ColumnMapper in Mapper.CollectionColumn)
            {
                if (ColumnMapper.ColumnKey != "pk")
                {
                    if (ColumnMapper.DataType == "datetime")
                    {
                        if (ColumnMapper.IsNullable == "yes")
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public Nullable<System.DateTime> " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                        else
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public " + ColumnDataType + " " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                    }
                    else if (ColumnMapper.DataType == "int")
                    {
                        if (ColumnMapper.IsNullable == "yes")
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public Nullable<System.Int32> " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                        else
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public " + ColumnDataType + " " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                    }
                    else if (ColumnMapper.DataType == "decimal")
                    {
                        if (ColumnMapper.IsNullable == "yes")
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public Nullable<System.Decimal> " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                        else
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public " + ColumnDataType + " " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                    }
                    else if (ColumnMapper.DataType == "long")
                    {
                        if (ColumnMapper.IsNullable == "yes")
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public Nullable<System.long> " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                        else
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public " + ColumnDataType + " " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                    }
                    else if (ColumnMapper.DataType == "longblob")
                    {
                        if (ColumnMapper.IsNullable == "yes")
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public Nullable<System.Byte> " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                        else
                        {
                            ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                            TextClass.AppendLine("        public " + ColumnDataType + " " + ColumnMapper.ColumnName + " { get; set; }");
                        }
                    }
                    else
                    {
                        ColumnDataType = Utils.GetColumnTypeOracle(ColumnMapper.DataType);
                        TextClass.AppendLine("        public " + ColumnDataType + " " + ColumnMapper.ColumnName + " { get; set; }");
                    }
                }
            }

            TextClass.AppendLine("        public object Clone()");
            TextClass.AppendLine("        {");
            TextClass.AppendLine("            return (this.MemberwiseClone());");
            TextClass.AppendLine("        }");
            TextClass.AppendLine("    }");
            TextClass.AppendLine("}");

            return (string.Format("Gerado o classe Dto {0}...", Utils.CreateFile(ModelConf.ClassName + "Dto", "Models", TextClass.ToString(), ETier.Data)));
        }
    }
}
