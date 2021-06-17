using System;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=Bitad;User Id=postgres;Password=Pa$$w0rd");
        }

    }
}
