using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class DependenteMapper : EntityTypeConfiguration<DependenteDto>
    {
        public DependenteMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_BENEFICIARIO).IsRequired();
            this.Property(_ => _.ID_PARENTESCO).IsRequired();
            this.Property(_ => _.ID_CARTEIRA).IsRequired();
            this.Property(_ => _.ID_USUARIO).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.CPF).IsRequired().HasMaxLength(255);
            this.Property(_ => _.RG).IsRequired().HasMaxLength(255);
            this.Property(_ => _.LOGRADOURO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.COMPLEMENTO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.NUMERO).IsRequired();
            this.Property(_ => _.CEP).IsRequired();
            this.Property(_ => _.BAIRRO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.CIDADE).IsRequired().HasMaxLength(255);
            this.Property(_ => _.UF).IsRequired().HasMaxLength(2);
            this.Property(_ => _.EMAIL).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DT_CADASTRO).IsRequired();

            // Table & Column Mappings
            this.ToTable("MC_DEPENDENTE", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_DEPENDENTE");
            this.Property(_ => _.ID_BENEFICIARIO).HasColumnName("ID_BENEFICIARIO");
            this.Property(_ => _.ID_PARENTESCO).HasColumnName("ID_PARENTESCO");
            this.Property(_ => _.ID_CARTEIRA).HasColumnName("ID_CARTEIRA");
            this.Property(_ => _.ID_USUARIO).HasColumnName("ID_USUARIO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.CPF).HasColumnName("CPF");
            this.Property(_ => _.RG).HasColumnName("RG");
            this.Property(_ => _.LOGRADOURO).HasColumnName("LOGRADOURO");
            this.Property(_ => _.COMPLEMENTO).HasColumnName("COMPLEMENTO");
            this.Property(_ => _.NUMERO).HasColumnName("NUMERO");
            this.Property(_ => _.CEP).HasColumnName("CEP");
            this.Property(_ => _.BAIRRO).HasColumnName("BAIRRO");
            this.Property(_ => _.CIDADE).HasColumnName("CIDADE");
            this.Property(_ => _.UF).HasColumnName("UF");
            this.Property(_ => _.EMAIL).HasColumnName("EMAIL");
            this.Property(_ => _.DT_CADASTRO).HasColumnName("DT_CADASTRO");
        }
    }
}

