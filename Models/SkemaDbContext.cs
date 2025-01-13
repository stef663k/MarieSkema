using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarieSkema.Models;

public class SkemaDbContext : DbContext
{
    public SkemaDbContext(DbContextOptions<SkemaDbContext> options) : base(options)
    {
    }

    public DbSet<Fag> Fag { get; set; }
    public DbSet<Laerer> Laerer{ get; set; }
    public DbSet<FagDage> FagDages { get; set;}


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Fag>()
            .HasMany(f => f.laererses)
            .WithMany(f => f.fags)
            .UsingEntity(j => j.ToTable("FagLaerer"));

        builder.Entity<Fag>()
            .HasMany(f => f.fagDageses)
            .WithMany(d => d.fag)
            .UsingEntity(j => j.ToTable("FagFagDage"));

        builder.Entity<Laerer>()
            .HasMany(l => l.fagsDage)
            .WithMany(d => d.laerers)
            .UsingEntity(j => j.ToTable("LaererFagDage"));        

    }
   
}

