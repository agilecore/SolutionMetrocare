using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class CredenciadoEspecialidadeMapper : EntityTypeConfiguration<CredenciadoEspecialidadeDto>
    {
        public CredenciadoEspecialidadeMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_CREDENCIADO).IsRequired();
            this.Property(_ => _.ID_ESPECIALIDADE).IsRequired();
            this.Property(_ => _.PRINCIPAL).IsRequired().HasMaxLength(1);
            this.Property(_ => _.DT_ATIVACAO);
            this.Property(_ => _.DT_INATIVACAO);

            // Table & Column Mappings
            this.ToTable("MC_CREDENCIADO_ESPECIALIDADE", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_CREDENCIADO_ESPECIALIDADE");
            this.Property(_ => _.ID_CREDENCIADO).HasColumnName("ID_CREDENCIADO");
            this.Property(_ => _.ID_ESPECIALIDADE).HasColumnName("ID_ESPECIALIDADE");
            this.Property(_ => _.PRINCIPAL).HasColumnName("PRINCIPAL");
            this.Property(_ => _.DT_ATIVACAO).HasColumnName("DT_ATIVACAO");
            this.Property(_ => _.DT_INATIVACAO).HasColumnName("DT_INATIVACAO");
        }
    }
}

