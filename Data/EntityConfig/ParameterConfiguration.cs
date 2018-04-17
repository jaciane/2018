using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class ParameterConfiguration: EntityTypeConfiguration<Parameter>
    {
        public ParameterConfiguration()
        {
            ToTable("PARAMETER");
            HasKey(p => p.Name);

            Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired();

            Property(p => p.Value)
                .HasColumnName("VALUE")
                .IsRequired();

            Property(p => p.Type)
                .HasColumnName("TYPE");
        }
    }
}
