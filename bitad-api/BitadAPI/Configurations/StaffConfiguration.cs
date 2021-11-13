using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("staff");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Picture)
                .HasColumnName("picture")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.Degree)
                .HasColumnName("degree")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.Contact)
                .HasColumnName("contact")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.IsPublic)
                .HasColumnName("is_public")
                .HasColumnType("bool")
                .IsRequired();

            builder.Property(x => x.StaffRole)
                .HasColumnName("staff_role")
                .HasColumnType("text")
                .IsRequired(false);
        }
    }
}
