using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class CredenciadoMapper : EntityTypeConfiguration<CredenciadoDto>
    {
        public CredenciadoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_CONCELHO_PROFISSIONAL).IsRequired();
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.NRO_CONCELHO).IsRequired();
            this.Property(_ => _.UF_CONCELHO).IsRequired().HasMaxLength(2);
            this.Property(_ => _.CPF).IsRequired().HasMaxLength(30);
            this.Property(_ => _.CNPJ).IsRequired().HasMaxLength(30);
            this.Property(_ => _.EMAIL).IsRequired().HasMaxLength(15);
            this.Property(_ => _.TELEFONE).IsRequired().HasMaxLength(15);
            this.Property(_ => _.CELULAR).IsRequired().HasMaxLength(15);
            this.Property(_ => _.CONTATO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.DT_CADASTRO).IsRequired();
            this.Property(_ => _.DT_NASCIMENTO).IsRequired();
            this.Property(_ => _.LONGITUDE).IsRequired();
            this.Property(_ => _.LATITUDE).IsRequired();
            this.Property(_ => _.IBGE);

            // Table & Column Mappings
            this.ToTable("MC_CREDENCIADO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_CREDENCIADO");
            this.Property(_ => _.ID_CONCELHO_PROFISSIONAL).HasColumnName("ID_CONCELHO_PROFISSIONAL");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.NRO_CONCELHO).HasColumnName("NRO_CONCELHO");
            this.Property(_ => _.UF_CONCELHO).HasColumnName("UF_CONCELHO");
            this.Property(_ => _.CPF).HasColumnName("CPF");
            this.Property(_ => _.CNPJ).HasColumnName("CNPJ");
            this.Property(_ => _.EMAIL).HasColumnName("EMAIL");
            this.Property(_ => _.TELEFONE).HasColumnName("TELEFONE");
            this.Property(_ => _.CELULAR).HasColumnName("CELULAR");
            this.Property(_ => _.CONTATO).HasColumnName("CONTATO");
            this.Property(_ => _.DT_CADASTRO).HasColumnName("DT_CADASTRO");
            this.Property(_ => _.DT_NASCIMENTO).HasColumnName("DT_NASCIMENTO");
            this.Property(_ => _.LONGITUDE).HasColumnName("LONGITUDE");
            this.Property(_ => _.LATITUDE).HasColumnName("LATITUDE");
            this.Property(_ => _.IBGE).HasColumnName("IBGE");
        }
    }
}

