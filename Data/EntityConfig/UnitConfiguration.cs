using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class UnitConfiguration:EntityTypeConfiguration<Unit>
    {
        public UnitConfiguration() {

            ToTable("UNIT");
            HasKey(e => e.Id);

            Property(e => e.Symbol)
            .HasColumnName("SYMBOL")
            .IsRequired()
            .HasMaxLength(5);

           Property(e => e.Description)
            .HasColumnName("DESCRIPTION")
            .IsRequired()
            .HasMaxLength(50);

            Property(e => e.Id)
             .HasColumnName("ID")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
