using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class GrauParticipacaoMapper : EntityTypeConfiguration<GrauParticipacaoDto>
    {
        public GrauParticipacaoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_GRAU_PARTICIPACAO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_GRAU_PARTICIPACAO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

