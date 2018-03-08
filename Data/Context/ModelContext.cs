using Data.EntityConfig;
using Domain.Entities;
using System.Data.Entity;

namespace Data.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext()
           : base("name=mysqlconnection")
        {
        }
        //public virtual DbSet<Unit> Unit { get; set; }
        //public virtual DbSet<Variable> Variable { get; set; }
        //public virtual DbSet<LogError> LogError { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ROOT");

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("Varchar2"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(256));

          //  modelBuilder.Configurations.Add(new UnitConfiguration());
           // modelBuilder.Configurations.Add(new LogErrorConfiguration());
        }


    }
}
