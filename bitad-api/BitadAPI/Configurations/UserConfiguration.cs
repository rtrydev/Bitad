using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.CurrentJwt)
                .HasColumnName("current_jwt")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.CurrentScore)
                .HasColumnName("current_score")
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasColumnName("password_salt")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Username)
                .HasColumnName("username")
                .HasColumnType("text")
                .IsRequired();

        }
    }
}
