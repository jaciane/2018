using Data.Context;
using Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomPermissionRole, CustomClaim>
    {
        public ApplicationDbContext()
            : base("DbContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(ContextConfig.SchemeName);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.IdProfile).HasColumnName("ID_PROFILE");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Cpf).HasColumnName("CPF");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Name).HasColumnName("NAME");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.PasswordHash).HasColumnName("PASSWORDHASH");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.SecurityStamp).HasColumnName("SECURITYSTAMP");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.PhoneNumber).HasColumnName("PHONENUMBER");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Active).HasColumnName("ACTIVE");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.EmailConfirmed).HasColumnName("EMAILCONFIRMED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.PhoneNumberConfirmed).HasColumnName("PHONENUMBERCONFIRMED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.TwoFactorEnabled).HasColumnName("TWOFACTORENABLED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.LockoutEndDateUtc).HasColumnName("LOCKOUTENDDATEUTC");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.LockoutEnabled).HasColumnName("LOCKOUTENABLED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.AccessFailedCount).HasColumnName("ACCESSFAILEDCOUNT");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.UserName).HasColumnName("USERNAME");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.RecieveNotification).HasColumnName("RECIEVENOTIFICATION");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").HasRequired(u => u.Profile)
                .WithMany(p => p.UserList)
                .HasForeignKey(u => u.IdProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomRole>().ToTable("PROFILE").Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<CustomRole>().ToTable("PROFILE").Property(x => x.Name).HasColumnName("NAME");

            modelBuilder.Entity<CustomPermissionRole>().ToTable("ACCESS").Property(x => x.IdPermission).HasColumnName("ID_PERMISSION");
            modelBuilder.Entity<CustomPermissionRole>().ToTable("ACCESS").Property(x => x.RoleId).HasColumnName("ID_PROFILE");
            modelBuilder.Entity<CustomPermissionRole>().ToTable("ACCESS").Property(x => x.UserId).HasColumnName("ID_USER");
            modelBuilder.Entity<CustomPermissionRole>().ToTable("ACCESS").HasRequired(u => u.Permission)
                .WithMany(p => p.AccessList)
                .HasForeignKey(u => u.IdPermission)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CustomPermissionRole>().ToTable("ACCESS").HasRequired(u => u.Profile)
                .WithMany(p => p.AccessList)
                .HasForeignKey(u => u.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomClaim>().ToTable("PERMISSION").Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<CustomClaim>().ToTable("PERMISSION").Property(x => x.ClaimType).HasColumnName("CLAIMTYPE");
            modelBuilder.Entity<CustomClaim>().ToTable("PERMISSION").Property(x => x.ClaimValue).HasColumnName("CLAIMVALUE");
            modelBuilder.Entity<CustomClaim>().ToTable("PERMISSION").Property(x => x.UserId).HasColumnName("ID_USER");

            modelBuilder.Entity<CustomUserLogin>().ToTable("USERLOGIN").Property(x => x.UserId).HasColumnName("ID_USER");
            modelBuilder.Entity<CustomUserLogin>().ToTable("USERLOGIN").Property(x => x.LoginProvider).HasColumnName("LOGINPROVIDER");
            modelBuilder.Entity<CustomUserLogin>().ToTable("USERLOGIN").Property(x => x.ProviderKey).HasColumnName("PROVIDERKEY");
        }
    }
}
