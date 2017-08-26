using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class LogPrestadorMapper : EntityTypeConfiguration<LogPrestadorDto>
    {
        public LogPrestadorMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.ID_ALTERACAO).IsRequired();

            // Table & Column Mappings
            this.ToTable("MC_LOG_PRESTADOR", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_LOG_PRESTADOR");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.ID_ALTERACAO).HasColumnName("ID_ALTERACAO");
        }
    }
}

