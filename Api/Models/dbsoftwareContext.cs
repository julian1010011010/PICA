using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class dbsoftwareContext : DbContext
    {
        public dbsoftwareContext()
        {
        }

        public dbsoftwareContext(DbContextOptions<dbsoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Proyecto> Proyecto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("Proyecto", "Proyecto");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Presupuesto).HasColumnType("decimal(32, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
