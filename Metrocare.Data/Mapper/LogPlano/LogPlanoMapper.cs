using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class LogPlanoMapper : EntityTypeConfiguration<LogPlanoDto>
    {
        public LogPlanoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_ALTERACAO).IsRequired();
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.DT_ALTERACAO).IsRequired();

            // Table & Column Mappings
            this.ToTable("MC_LOG_PLANO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_LOG_PLANO");
            this.Property(_ => _.ID_ALTERACAO).HasColumnName("ID_ALTERACAO");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.DT_ALTERACAO).HasColumnName("DT_ALTERACAO");
        }
    }
}

