using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class PlanoTabelaMapper : EntityTypeConfiguration<PlanoTabelaDto>
    {
        public PlanoTabelaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_PLANO).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_PLANO_TABELA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PLANO_TABELA");
            this.Property(_ => _.ID_PLANO).HasColumnName("ID_PLANO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

