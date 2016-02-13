using Guitar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar.DAC
{
    public class GuitarDbContext : DbContext
    {
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Guitars> Guitar { get; set; }
        public virtual DbSet<GuitarBody> GuitarBody { get; set; }
        public virtual DbSet<GuitarNeck> GutiarNeck { get; set; }
        public virtual DbSet<GuitarBridge> GuitarBridge { get; set; }
        public virtual DbSet<GuitarPickup> GuitarPickup { get; set; }

        public GuitarDbContext(): base("GuitarDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GuitarBody>().ToTable("GuitarBody").HasKey(g => g.Id);
            modelBuilder.Entity<GuitarNeck>().ToTable("GuitarNeck").HasKey(g => g.Id);
            modelBuilder.Entity<GuitarBridge>().ToTable("GuitarBridge").HasKey(g => g.Id);
            modelBuilder.Entity<GuitarPickup>().ToTable("GuitarPickup").HasKey(g => g.Id);
            modelBuilder.Entity<Project>().ToTable("Project").HasKey(g => g.Id);
            modelBuilder.Entity<Project>().ToTable("Project").HasRequired(g => g.GuitarBody);
            modelBuilder.Entity<Project>().ToTable("Project").HasRequired(g => g.GuitarBridge);
            modelBuilder.Entity<Project>().ToTable("Project").HasRequired(g => g.GuitarNeck);
            modelBuilder.Entity<Project>().ToTable("Project").HasRequired(g => g.GuitarPickup);
            modelBuilder.Entity<Guitars>().ToTable("Guitar").HasKey(g => g.Id);
            modelBuilder.Entity<Guitars>().ToTable("Guitar").HasRequired(g => g.GuitarBody);
            modelBuilder.Entity<Guitars>().ToTable("Guitar").HasRequired(g => g.GuitarBridge);
            modelBuilder.Entity<Guitars>().ToTable("Guitar").HasRequired(g => g.GuitarNeck);
            modelBuilder.Entity<Guitars>().ToTable("Guitar").HasRequired(g => g.GuitarPickup);
        }
    }
}

