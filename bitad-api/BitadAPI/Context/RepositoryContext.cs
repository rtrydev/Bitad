using System;
using BitadAPI.Configurations;
using BitadAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Context
{
    public partial class RepositoryContext : DbContext
    {
        public virtual DbSet<Agenda> Agendas { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }
        public virtual DbSet<QrCode> QrCodes { get; set; }
        public virtual DbSet<QrCodeRedeem> QrCodeRedeems { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=db;Database=Bitad;User Id=postgres;Password=Pa$$w0rd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Agenda>(new AgendaConfiguration());
            modelBuilder.ApplyConfiguration<QrCode>(new QrCodeConfiguration());
            modelBuilder.ApplyConfiguration<QrCodeRedeem>(new QrCodeRedeemConfiguration());
            modelBuilder.ApplyConfiguration<Speaker>(new SpeakerConfiguration());
            modelBuilder.ApplyConfiguration<Sponsor>(new SponsorConfiguration());
            modelBuilder.ApplyConfiguration<Staff>(new StaffConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Workshop>(new WorkshopConfiguration());

        }

    }
}
