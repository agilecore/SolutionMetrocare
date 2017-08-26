using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class GlosasMensagensMapper : EntityTypeConfiguration<GlosasMensagensDto>
    {
        public GlosasMensagensMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.GRUPO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DESCRICAO).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_GLOSAS_MENSAGENS", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.GRUPO).HasColumnName("GRUPO");
            this.Property(_ => _.ID).HasColumnName("ID_GLOSAS_ERROS");
            this.Property(_ => _.DESCRICAO).HasColumnName("DESCRICAO");
        }
    }
}

