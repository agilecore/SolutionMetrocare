using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TabelaProcedMapper : EntityTypeConfiguration<TabelaProcedDto>
    {
        public TabelaProcedMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_PLANO_TABELA).IsRequired();
            this.Property(_ => _.ID_PROCEDIMENTO).IsRequired().HasMaxLength(30);
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);
            this.Property(_ => _.NRO_AUXILIARES);
            this.Property(_ => _.VALOR_PORTE);
            this.Property(_ => _.VALOR_CUSTO_OPERACIONAL);
            this.Property(_ => _.VALOR_PORTE_ANESTESICO);
            this.Property(_ => _.VALOR_FILME);
            this.Property(_ => _.VALOR_TOTAL);

            // Table & Column Mappings
            this.ToTable("MC_TABELA_PROCED", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID).HasColumnName("ID_PLN_TBL_PRC");
            this.Property(_ => _.ID_PLANO_TABELA).HasColumnName("ID_PLANO_TABELA");
            this.Property(_ => _.ID_PROCEDIMENTO).HasColumnName("ID_PROCEDIMENTO");
            this.Property(_ => _.NOME).HasColumnName("NOME");
            this.Property(_ => _.NRO_AUXILIARES).HasColumnName("NRO_AUXILIARES");
            this.Property(_ => _.VALOR_PORTE).HasColumnName("VALOR_PORTE");
            this.Property(_ => _.VALOR_CUSTO_OPERACIONAL).HasColumnName("VALOR_CUSTO_OPERACIONAL");
            this.Property(_ => _.VALOR_PORTE_ANESTESICO).HasColumnName("VALOR_PORTE_ANESTESICO");
            this.Property(_ => _.VALOR_FILME).HasColumnName("VALOR_FILME");
            this.Property(_ => _.VALOR_TOTAL).HasColumnName("VALOR_TOTAL");
        }
    }
}

