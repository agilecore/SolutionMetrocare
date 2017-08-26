using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class PlanoMapper : EntityTypeConfiguration<PlanoDto>
    {
        public PlanoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_PLANO_CATEGORIA).IsRequired();
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.PLANO_INATIVACAO).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.REGISTRO_ANS).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DT_CADASTRO).IsRequired();
            this.Property(_ => _.DT_ATIVACAO).IsRequired();
            this.Property(_ => _.DT_DESATIVACAO).IsRequired();
            this.Property(_ => _.IDADE_MINIMA).IsRequired();
            this.Property(_ => _.IDADE_MAXIMA).IsRequired();
            this.Property(_ => _.PERMITE_DEPENDENTES).IsRequired().HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MC_PLANO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PLANO");
            this.Property(_ => _.ID_PLANO_CATEGORIA).HasColumnName("ID_PLANO_CATEGORIA");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.PLANO_INATIVACAO).HasColumnName("PLANO_INATIVACAO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.REGISTRO_ANS).HasColumnName("REGISTRO_ANS");
            this.Property(_ => _.DT_CADASTRO).HasColumnName("DT_CADASTRO");
            this.Property(_ => _.DT_ATIVACAO).HasColumnName("DT_ATIVACAO");
            this.Property(_ => _.DT_DESATIVACAO).HasColumnName("DT_DESATIVACAO");
            this.Property(_ => _.IDADE_MINIMA).HasColumnName("IDADE_MINIMA");
            this.Property(_ => _.IDADE_MAXIMA).HasColumnName("IDADE_MAXIMA");
            this.Property(_ => _.PERMITE_DEPENDENTES).HasColumnName("PERMITE_DEPENDENTES");
        }
    }
}

