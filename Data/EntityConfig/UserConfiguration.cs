﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration() {

            ToTable("User");
            HasKey(u => u.Id);

            Property(u => u.IdProfile)
                .IsRequired();

            Property(u => u.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();

            //Property(u => u.PasswordHash)
            //    .HasColumnName("PASSWORDHASH")
            //    .IsRequired();

            //Property(u => u.SecurityStamp)
            //    .HasColumnName("SECURITYSTAMP");

            //Property(e => e.Active)
            //    .HasColumnName("ACTIVE")
            //    .HasColumnType("CHAR")
            //    .IsRequired()
            //    .HasMaxLength(1);

            //Property(u => u.EmailConfirmed)
            //    .HasColumnName("EMAILCONFIRMED")
            //    .HasColumnType("NUMBER")
            //    .IsRequired();

            //Property(u => u.PhoneNumber)
            //    .HasColumnName("PHONENUMBER")
            //    .HasMaxLength(50);

            //Property(u => u.PhoneNumberConfirmed)
            //    .HasColumnName("PHONENUMBERCONFIRMED")
            //    .HasColumnType("NUMBER")
            //    .IsRequired();

            //Property(u => u.TwoFactorEnabled)
            //    .HasColumnName("TWOFACTORENABLED")
            //    .HasColumnType("NUMBER")
            //    .IsRequired();

            //Property(u => u.LockoutEndDateUTC)
            //    .HasColumnName("LOCKOUTENDDATEUTC")
            //    .HasColumnType("TIMESTAMP")
            //    .HasPrecision(6);

            //Property(u => u.LockoutEnabled)
            //    .HasColumnName("LOCKOUTENABLED")
            //    .HasColumnType("NUMBER")
            //    .IsRequired();

            //Property(u => u.RecieveNotification)
            //    .HasColumnName("RECIEVENOTIFICATION")
            //    .HasColumnType("NUMBER")
            //    .IsRequired();

            //Property(u => u.AccessFailedCount)
            //    .HasColumnName("ACCESSFAILEDCOUNT")
            //    .IsRequired()
            //    .HasColumnType("int");

            //Property(u => u.Username)
            //    .HasColumnName("USERNAME")
            //    .HasMaxLength(50)
            //    .IsRequired();

            //HasRequired(u => u.Profile)
            //    .WithMany(p => p.UserList)
            //    .HasForeignKey(u => u.IdProfile)
            //    .WillCascadeOnDelete(false);

            Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}