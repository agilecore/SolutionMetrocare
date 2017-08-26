using System.Data.Entity.ModelConfiguration;
using Metrocare.Common;

namespace Metrocare.Data
{
    public class TussMapper : EntityTypeConfiguration<TussDto>
    {
        public TussMapper()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Propertys Required
            this.Property(_ => _.ID_PROC_AMB90).IsRequired().HasMaxLength(30);
            this.Property(_ => _.ID_PROC_AMB92).IsRequired().HasMaxLength(30);
            this.Property(_ => _.ID_PROC_AMB96).IsRequired().HasMaxLength(30);
            this.Property(_ => _.ID_PROC_CBHPM5).IsRequired().HasMaxLength(30);
            this.Property(_ => _.ID_PROC_TUSS).IsRequired().HasMaxLength(30);
            this.Property(_ => _.NOME).IsRequired().HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MC_TUSS", "dbo");

            // Propertys Relationship Database Table Columns
            this.Property(_ => _.ID_PROC_AMB90).HasColumnName("ID_PROC_AMB90");
            this.Property(_ => _.ID_PROC_AMB92).HasColumnName("ID_PROC_AMB92");
            this.Property(_ => _.ID_PROC_AMB96).HasColumnName("ID_PROC_AMB96");
            this.Property(_ => _.ID_PROC_CBHPM5).HasColumnName("ID_PROC_CBHPM5");
            this.Property(_ => _.ID_PROC_TUSS).HasColumnName("ID_PROC_TUSS");
            this.Property(_ => _.NOME).HasColumnName("NOME");
        }
    }
}

