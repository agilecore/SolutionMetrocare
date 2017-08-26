using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class AgendaMapper : EntityTypeConfiguration<AgendaDto>
    {
        public AgendaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_CREDENCIADO).IsRequired();
            this.Property(_ => _.ID_PRESTADOR).IsRequired();
            this.Property(_ => _.ID_DIA).IsRequired();
            this.Property(_ => _.ID_DIA).IsRequired();
            this.Property(_ => _.ID_PERIODO).IsRequired();
            this.Property(_ => _.ID_PERIODO).IsRequired();

            // Table & Column Mappings
            this.ToTable("MC_AGENDA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_AGENDA");
            this.Property(_ => _.ID_CREDENCIADO).HasColumnName("ID_CREDENCIADO");
            this.Property(_ => _.ID_PRESTADOR).HasColumnName("ID_PRESTADOR");
            this.Property(_ => _.ID_DIA).HasColumnName("ID_DIA");
            this.Property(_ => _.ID_DIA).HasColumnName("ID_DIA");
            this.Property(_ => _.ID_PERIODO).HasColumnName("ID_PERIODO");
            this.Property(_ => _.ID_PERIODO).HasColumnName("ID_PERIODO");
        }
    }
}

