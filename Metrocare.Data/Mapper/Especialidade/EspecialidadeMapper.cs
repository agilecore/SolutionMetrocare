using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class EspecialidadeMapper : EntityTypeConfiguration<EspecialidadeDto>
    {
        public EspecialidadeMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.STATUS).IsRequired().HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MC_ESPECIALIDADE", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_ESPECIALIDADE");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.STATUS).HasColumnName("STATUS");
        }
    }
}

