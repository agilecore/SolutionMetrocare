using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TipoInternacaoMapper : EntityTypeConfiguration<TipoInternacaoDto>
    {
        public TipoInternacaoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TIPO_INTERNACAO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_TIPO_INTERNACAO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

