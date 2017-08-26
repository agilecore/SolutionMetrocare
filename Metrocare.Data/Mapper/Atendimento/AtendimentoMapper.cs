using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class AtendimentoMapper : EntityTypeConfiguration<AtendimentoDto>
    {
        public AtendimentoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_AGENDA).IsRequired();
            this.Property(_ => _.DT_ATENDIMENTO).IsRequired();
            this.Property(_ => _.HORA).IsRequired().HasMaxLength(5);
            this.Property(_ => _.CONFIRMADO).IsRequired().HasMaxLength(1);
            this.Property(_ => _.ATENDIDO).IsRequired().HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MC_ATENDIMENTO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_ATENDIMENTO");
            this.Property(_ => _.ID_AGENDA).HasColumnName("ID_AGENDA");
            this.Property(_ => _.DT_ATENDIMENTO).HasColumnName("DT_ATENDIMENTO");
            this.Property(_ => _.HORA).HasColumnName("HORA");
            this.Property(_ => _.CONFIRMADO).HasColumnName("CONFIRMADO");
            this.Property(_ => _.ATENDIDO).HasColumnName("ATENDIDO");
        }
    }
}

