using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class PlanoCategoriaMapper : EntityTypeConfiguration<PlanoCategoriaDto>
    {
        public PlanoCategoriaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_PLANO_CATEGORIA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PLANO_CATEGORIA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

