using Data.EntityConfig;
using Domain.Entities;
using System.Data.Entity;

namespace Data.Context
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ModelContext : DbContext
    {
        public ModelContext()
           : base("Mysqlconnection")
        {
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Access> Access { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("EARTH");
            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("Varchar2"));
            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(256));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new AccessConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new ParameterConfiguration());
        }


    }
}
