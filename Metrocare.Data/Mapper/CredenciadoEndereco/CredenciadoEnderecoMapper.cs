using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class CredenciadoEnderecoMapper : EntityTypeConfiguration<CredenciadoEnderecoDto>
    {
        public CredenciadoEnderecoMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_CREDENCIADO).IsRequired();
            this.Property(_ => _.LOGRADOURO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.COMPLEMENTO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.NUMERO).IsRequired();
            this.Property(_ => _.CEP).IsRequired();
            this.Property(_ => _.BAIRRO).IsRequired().HasMaxLength(255);
            this.Property(_ => _.CIDADE).IsRequired().HasMaxLength(255);
            this.Property(_ => _.UF).IsRequired().HasMaxLength(2);
            this.Property(_ => _.PRINCIPAL).IsRequired().HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("MC_CREDENCIADO_ENDERECO", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_ENDERECO");
            this.Property(_ => _.ID_CREDENCIADO).HasColumnName("ID_CREDENCIADO");
            this.Property(_ => _.LOGRADOURO).HasColumnName("LOGRADOURO");
            this.Property(_ => _.COMPLEMENTO).HasColumnName("COMPLEMENTO");
            this.Property(_ => _.NUMERO).HasColumnName("NUMERO");
            this.Property(_ => _.CEP).HasColumnName("CEP");
            this.Property(_ => _.BAIRRO).HasColumnName("BAIRRO");
            this.Property(_ => _.CIDADE).HasColumnName("CIDADE");
            this.Property(_ => _.UF).HasColumnName("UF");
            this.Property(_ => _.PRINCIPAL).HasColumnName("PRINCIPAL");
        }
    }
}

