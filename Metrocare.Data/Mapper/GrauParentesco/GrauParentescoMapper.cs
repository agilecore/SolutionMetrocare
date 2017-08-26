using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class GrauParentescoMapper : EntityTypeConfiguration<GrauParentescoDto>
    {
        public GrauParentescoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_GRAU_PARENTESCO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PARENTESCO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

