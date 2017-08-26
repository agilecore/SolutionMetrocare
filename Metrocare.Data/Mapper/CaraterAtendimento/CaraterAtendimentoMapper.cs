using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class CaraterAtendimentoMapper : EntityTypeConfiguration<CaraterAtendimentoDto>
    {
        public CaraterAtendimentoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_CARATER_ATENDIMENTO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_CARATER_ATENDIMENTO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

