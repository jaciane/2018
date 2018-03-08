using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Presentation.Models
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        public string Cpf { get; set; }
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext() : base("mysqlconnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ROOT");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.UserName).HasColumnName("USERNAME");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Cpf).HasColumnName("CPF");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.Name).HasColumnName("NAME");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.EmailConfirmed).HasColumnName("EMAILCONFIRMED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.SecurityStamp).HasColumnName("SECURITYSTAMP");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.PasswordHash).HasColumnName("PASSWORDHASH");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.PhoneNumber).HasColumnName("PHONENUMBER");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.PhoneNumberConfirmed).HasColumnName("PHONENUMBERCONFIRMED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.TwoFactorEnabled).HasColumnName("TWOFACTORENABLED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.LockoutEndDateUtc).HasColumnName("LOCKOUTENDDATEUTC");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.LockoutEnabled).HasColumnName("LOCKOUTENABLED");
            modelBuilder.Entity<ApplicationUser>().ToTable("USER").Property(x => x.AccessFailedCount).HasColumnName("ACCESSFAILEDCOUNT");
            modelBuilder.Entity<CustomRole>().ToTable("PROFILE").Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<CustomRole>().ToTable("PROFILE").Property(x => x.Name).HasColumnName("NAME");
            modelBuilder.Entity<CustomUserRole>().ToTable("USERPROFILE").Property(x => x.UserId).HasColumnName("ID_USER");
            modelBuilder.Entity<CustomUserRole>().ToTable("USERPROFILE").Property(x => x.RoleId).HasColumnName("ID_PROFILE");
            modelBuilder.Entity<CustomUserClaim>().ToTable("ACCESS").Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<CustomUserClaim>().ToTable("ACCESS").Property(x => x.ClaimType).HasColumnName("CLAIMTYPE");
            modelBuilder.Entity<CustomUserClaim>().ToTable("ACCESS").Property(x => x.ClaimValue).HasColumnName("CLAIMVALUE");
            modelBuilder.Entity<CustomUserClaim>().ToTable("ACCESS").Property(x => x.UserId).HasColumnName("ID_USER");
            modelBuilder.Entity<CustomUserLogin>().ToTable("USERLOGIN").Property(x => x.UserId).HasColumnName("ID_USER");
            modelBuilder.Entity<CustomUserLogin>().ToTable("USERLOGIN").Property(x => x.LoginProvider).HasColumnName("LOGINPROVIDER");
            modelBuilder.Entity<CustomUserLogin>().ToTable("USERLOGIN").Property(x => x.ProviderKey).HasColumnName("PROVIDERKEY");
        }
    }

        public class CustomUserRole : IdentityUserRole<int> { }
        public class CustomUserClaim : IdentityUserClaim<int> { }
        public class CustomUserLogin : IdentityUserLogin<int> { }

        public class CustomRole : IdentityRole<int, CustomUserRole>
        {
            public CustomRole() { }
            public CustomRole(string name) { Name = name; }
        }

        public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
        {
            public CustomUserStore(ApplicationDbContext context)
                : base(context)
            {
            }
        }

        public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
        {
            public CustomRoleStore(ApplicationDbContext context)
                : base(context)
            {
            }
        }

    }