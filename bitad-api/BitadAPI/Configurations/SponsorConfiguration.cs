using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {
        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.ToTable("sponsors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Picture)
                .HasColumnName("picture")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.Rank)
                .HasColumnName("rank")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Webpage)
                .HasColumnName("website")
                .HasColumnType("text")
                .IsRequired(false);
        }
    }
}
