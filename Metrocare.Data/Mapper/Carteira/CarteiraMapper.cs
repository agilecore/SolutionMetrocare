using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class CarteiraMapper : EntityTypeConfiguration<CarteiraDto>
    {
        public CarteiraMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_PLANO).IsRequired();
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.ID_PLANO_INATIVACAO);
            this.Property(_ => _.ID_BENEF_DEPEND).IsRequired();
            this.Property(_ => _.DT_ATIVACAO);
            this.Property(_ => _.DT_INATIVACAO);
            this.Property(_ => _.MARCA_OPTICA).IsRequired().HasMaxLength(255);
            this.Property(_ => _.STATUS).IsRequired().HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MC_CARTEIRA", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_CARTEIRA");
            this.Property(_ => _.ID_PLANO).HasColumnName("ID_PLANO");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.ID_PLANO_INATIVACAO).HasColumnName("ID_PLANO_INATIVACAO");
            this.Property(_ => _.ID_BENEF_DEPEND).HasColumnName("ID_BENEF_DEPEND");
            this.Property(_ => _.DT_ATIVACAO).HasColumnName("DT_ATIVACAO");
            this.Property(_ => _.DT_INATIVACAO).HasColumnName("DT_INATIVACAO");
            this.Property(_ => _.MARCA_OPTICA).HasColumnName("MARCA_OPTICA");
            this.Property(_ => _.STATUS).HasColumnName("STATUS");
        }
    }
}

