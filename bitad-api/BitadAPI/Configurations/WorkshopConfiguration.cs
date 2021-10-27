using System;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitadAPI.Configurations
{
    public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.ToTable("workshops");

            builder.HasOne(x => x.Speaker)
                .WithMany()
                .HasForeignKey("speaker_id")
                .IsRequired();

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Participants)
               .WithOne(x => x.Workshop)
               .HasForeignKey("workshop_id")
               .IsRequired(false);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.MaxParticipants)
                .HasColumnName("max_participants")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Room)
                .HasColumnName("room")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Start)
                .HasColumnName("start")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.End)
                .HasColumnName("end")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.ExternalLink)
                .HasColumnName("external_link")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(x => x.ShortInfo)
                .HasColumnName("short_info")
                .HasColumnType("text")
                .IsRequired(false);
        }
    }
}
