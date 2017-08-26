using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class AltaMapper : EntityTypeConfiguration<AltaDto>
    {
        public AltaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_ALTA).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_ALTA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID_ALTA).HasColumnName("ID_ALTA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

