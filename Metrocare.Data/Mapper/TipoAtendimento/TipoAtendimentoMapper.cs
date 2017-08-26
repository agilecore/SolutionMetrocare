using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TipoAtendimentoMapper : EntityTypeConfiguration<TipoAtendimentoDto>
    {
        public TipoAtendimentoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TIPO_ATENDIMENTO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_TIPO_ATENDIMENTO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

