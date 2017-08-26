using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class LogAcessoMapper : EntityTypeConfiguration<LogAcessoDto>
    {
        public LogAcessoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.DT_LOG).IsRequired();

            // Table & Column Mappings
            this.ToTable("MC_LOG_ACESSO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.DT_LOG).HasColumnName("DT_LOG");
        }
    }
}

