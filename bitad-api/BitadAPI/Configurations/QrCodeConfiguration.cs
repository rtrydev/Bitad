using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class QrCodeConfiguration : IEntityTypeConfiguration<QrCode>
    {
        public void Configure(EntityTypeBuilder<QrCode> builder)
        {
            builder.ToTable("qr_codes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Points)
                .HasColumnName("points")
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.ActivationTime)
                .HasColumnName("activation_time")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.UnixEpoch)
                .IsRequired();

            builder.Property(x => x.DeactivationTime)
                .HasColumnName("deactivation_time")
                .HasColumnType("timestamp")
                .IsRequired();

        }
    }
}
