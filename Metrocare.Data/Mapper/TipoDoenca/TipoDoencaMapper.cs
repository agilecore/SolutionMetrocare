using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TipoDoencaMapper : EntityTypeConfiguration<TipoDoencaDto>
    {
        public TipoDoencaMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_TIPO_DOENCA).IsRequired().HasMaxLength(1);
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TIPO_DOENCA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID_TIPO_DOENCA).HasColumnName("ID_TIPO_DOENCA");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

