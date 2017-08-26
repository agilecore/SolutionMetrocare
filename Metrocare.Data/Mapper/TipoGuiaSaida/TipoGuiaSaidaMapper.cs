using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TipoGuiaSaidaMapper : EntityTypeConfiguration<TipoGuiaSaidaDto>
    {
        public TipoGuiaSaidaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_TIPO_GUIA).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MC_TIPO_GUIA_SAIDA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_TIPO_SAIDA");
            this.Property(_ => _.ID_TIPO_GUIA).HasColumnName("ID_TIPO_GUIA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

