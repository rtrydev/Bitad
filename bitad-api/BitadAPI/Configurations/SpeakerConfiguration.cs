using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
            builder.ToTable("speakers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Company)
                .HasColumnName("company")
                .HasColumnType("text")
                .IsRequired(false);

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

            builder.Property(x => x.Website)
                .HasColumnName("website")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.WebsiteLink)
                .HasColumnName("website_link")
                .HasColumnType("text")
                .IsRequired(false);

        }
    }
}
