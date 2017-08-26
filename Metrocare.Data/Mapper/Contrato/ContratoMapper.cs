using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class ContratoMapper : EntityTypeConfiguration<ContratoDto>
    {
        public ContratoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_PLANO).IsRequired();
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DESCRICAO).IsRequired().HasMaxLength(2147483647);
            this.Property(_ => _.DT_CADASTRO).IsRequired();
            this.Property(_ => _.DT_ATIVACAO).IsRequired();
            this.Property(_ => _.DT_DESATIVACAO).IsRequired();
            this.Property(_ => _.DOCUMENTO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.STATUS).IsRequired().HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MC_CONTRATO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_CONTRATO");
            this.Property(_ => _.ID_PLANO).HasColumnName("ID_PLANO");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.DESCRICAO).HasColumnName("DESCRICAO");
            this.Property(_ => _.DT_CADASTRO).HasColumnName("DT_CADASTRO");
            this.Property(_ => _.DT_ATIVACAO).HasColumnName("DT_ATIVACAO");
            this.Property(_ => _.DT_DESATIVACAO).HasColumnName("DT_DESATIVACAO");
            this.Property(_ => _.DOCUMENTO).HasColumnName("DOCUMENTO");
            this.Property(_ => _.STATUS).HasColumnName("STATUS");
        }
    }
}

