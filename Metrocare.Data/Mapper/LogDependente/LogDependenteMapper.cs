using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class LogDependenteMapper : EntityTypeConfiguration<LogDependenteDto>
    {
        public LogDependenteMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.ID_ALTERACAO).IsRequired();

            // Table & Column Mappings
            this.ToTable("MC_LOG_DEPENDENTE", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_LOG_DEPENDENTE");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.ID_ALTERACAO).HasColumnName("ID_ALTERACAO");
        }
    }
}

