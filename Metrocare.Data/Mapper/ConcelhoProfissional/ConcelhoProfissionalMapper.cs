using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class ConcelhoProfissionalMapper : EntityTypeConfiguration<ConcelhoProfissionalDto>
    {
        public ConcelhoProfissionalMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DESCRICAO).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_CONCELHO_PROFISSIONAL", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_CONCELHO_PROFISSIONAL");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.DESCRICAO).HasColumnName("DESCRICAO");
        }
    }
}

