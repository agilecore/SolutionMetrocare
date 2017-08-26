using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class DiaMapper : EntityTypeConfiguration<DiaDto>
    {
        public DiaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(30);
            this.Property(_ => _.SIGLA).IsRequired().HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("MC_DIA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_DIA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.SIGLA).HasColumnName("SIGLA");
        }
    }
}

