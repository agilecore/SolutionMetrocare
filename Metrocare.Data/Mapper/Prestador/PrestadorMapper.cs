using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class PrestadorMapper : EntityTypeConfiguration<PrestadorDto>
    {
        public PrestadorMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.CPF).IsRequired().HasMaxLength(30);
            this.Property(_ => _.CNPJ).IsRequired().HasMaxLength(30);
            this.Property(_ => _.EMAIL).IsRequired().HasMaxLength(30);
            this.Property(_ => _.LOGRADOURO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.COMPLEMENTO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.NUMERO).IsRequired();
            this.Property(_ => _.CEP).IsRequired();
            this.Property(_ => _.BAIRRO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.CIDADE).IsRequired().HasMaxLength(255);
            this.Property(_ => _.UF).IsRequired().HasMaxLength(2);
            this.Property(_ => _.TELEFONE).IsRequired().HasMaxLength(15);
            this.Property(_ => _.CELULAR).IsRequired().HasMaxLength(15);
            this.Property(_ => _.CONTATO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DT_CADASTRO).IsRequired();
            this.Property(_ => _.LONGITUDE);
            this.Property(_ => _.LATITUDE);
            this.Property(_ => _.IBGE);

            // Table & Column Mappings
            this.ToTable("MC_PRESTADOR", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PRESTADOR");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.CPF).HasColumnName("CPF");
            this.Property(_ => _.CNPJ).HasColumnName("CNPJ");
            this.Property(_ => _.EMAIL).HasColumnName("EMAIL");
            this.Property(_ => _.LOGRADOURO).HasColumnName("LOGRADOURO");
            this.Property(_ => _.COMPLEMENTO).HasColumnName("COMPLEMENTO");
            this.Property(_ => _.NUMERO).HasColumnName("NUMERO");
            this.Property(_ => _.CEP).HasColumnName("CEP");
            this.Property(_ => _.BAIRRO).HasColumnName("BAIRRO");
            this.Property(_ => _.CIDADE).HasColumnName("CIDADE");
            this.Property(_ => _.UF).HasColumnName("UF");
            this.Property(_ => _.TELEFONE).HasColumnName("TELEFONE");
            this.Property(_ => _.CELULAR).HasColumnName("CELULAR");
            this.Property(_ => _.CONTATO).HasColumnName("CONTATO");
            this.Property(_ => _.DT_CADASTRO).HasColumnName("DT_CADASTRO");
            this.Property(_ => _.LONGITUDE).HasColumnName("LONGITUDE");
            this.Property(_ => _.LATITUDE).HasColumnName("LATITUDE");
            this.Property(_ => _.IBGE).HasColumnName("IBGE");
        }
    }
}

