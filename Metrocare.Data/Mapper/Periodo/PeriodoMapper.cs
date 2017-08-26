using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class PeriodoMapper : EntityTypeConfiguration<PeriodoDto>
    {
        public PeriodoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("MC_PERIODO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PERIODO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

