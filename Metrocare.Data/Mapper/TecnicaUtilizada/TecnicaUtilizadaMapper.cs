using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TecnicaUtilizadaMapper : EntityTypeConfiguration<TecnicaUtilizadaDto>
    {
        public TecnicaUtilizadaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_TECNICA_UTILIZADA).IsRequired().HasMaxLength(2);
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TECNICA_UTILIZADA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID_TECNICA_UTILIZADA).HasColumnName("ID_TECNICA_UTILIZADA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

