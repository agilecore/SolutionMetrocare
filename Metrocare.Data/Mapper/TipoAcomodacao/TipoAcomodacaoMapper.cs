using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TipoAcomodacaoMapper : EntityTypeConfiguration<TipoAcomodacaoDto>
    {
        public TipoAcomodacaoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TIPO_ACOMODACAO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("TIPO_ACOMODACAO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}
