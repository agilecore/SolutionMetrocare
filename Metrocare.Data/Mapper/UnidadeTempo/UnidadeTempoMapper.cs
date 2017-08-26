using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class UnidadeTempoMapper : EntityTypeConfiguration<UnidadeTempoDto>
    {
        public UnidadeTempoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_UNIDADE_TEMPO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_UNIDADE_TEMPO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

