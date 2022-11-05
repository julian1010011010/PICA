using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
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
                entity.HasKey(e => e.ProyectoId)
                    .HasName("PK__Proyecto__CF241D6542CA15DA");

                entity.ToTable("Proyecto", "Proyecto");

                entity.Property(e => e.Nombre).HasMaxLength(250);

                entity.Property(e => e.Presupuesto).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.HasSequence<int>("ConsecutivoActaRendimientos");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
