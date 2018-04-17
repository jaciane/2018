using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            ToTable("USERLOGIN");
            HasKey(ul => new { ul.IdUser, ul.LoginProvider, ul.ProviderKey });

            Property(u => u.IdUser)
                .HasColumnName("ID_USER")
                .IsRequired();

            Property(ul => ul.LoginProvider)
                .HasColumnName("LOGINPROVIDER")
                .HasMaxLength(128);

            Property(ul => ul.ProviderKey)
                .HasColumnName("PROVIDERKEY")
                .HasMaxLength(128);

            HasRequired(ul => ul.User)
                .WithMany(u => u.UserLoginList)
                .HasForeignKey(ul => ul.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
