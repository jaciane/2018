using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class LogErrorConfiguration : EntityTypeConfiguration<LogError>
    {
        public LogErrorConfiguration()
        {
            ToTable("LOGERROR");
            HasKey(e => e.Id);

            Property(e => e.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(100);

            Property(e => e.Controller)
             .HasColumnName("CONTROLLER")
             .HasMaxLength(50);

            Property(e => e.Action)
            .HasColumnName("ACTION")
            .HasMaxLength(50);

            Property(e => e.StackTrace)
            .HasColumnName("STACKTRACE")
            .HasColumnType("CLOB")
            .HasMaxLength(50);

            Property(e => e.OccurrenceTime)
           .HasColumnName("OCCURRENCETIME")
           .HasColumnType("TIMESTAMP");

            Property(e => e.Id)
             .HasColumnName("ID")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
