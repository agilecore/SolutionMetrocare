using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TempoDoencaMapper : EntityTypeConfiguration<TempoDoencaDto>
    {
        public TempoDoencaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_TEMPO_DOENCA).IsRequired().HasMaxLength(1);
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TEMPO_DOENCA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID_TEMPO_DOENCA).HasColumnName("ID_TEMPO_DOENCA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

