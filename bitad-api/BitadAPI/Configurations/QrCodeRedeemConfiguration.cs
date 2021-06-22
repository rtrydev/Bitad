using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class QrCodeRedeemConfiguration : IEntityTypeConfiguration<QrCodeRedeem>
    {
        public void Configure(EntityTypeBuilder<QrCodeRedeem> builder)
        {
            builder.ToTable("qr_code_reedeems");

            builder.HasOne(x => x.QrCode)
                .WithMany()
                .HasForeignKey("qr_code_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey("user_id")
                .IsRequired();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.RedeemTime)
                .HasColumnName("redeem_time")
                .HasColumnType("timestamp")
                .ValueGeneratedOnAdd();

        }
    }
}
