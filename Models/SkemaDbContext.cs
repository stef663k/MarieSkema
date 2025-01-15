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

        builder.Entity<FagDage>()
            .HasOne(fd => fd.Fag)
            .WithMany(f => f.fagDageses)
            .HasForeignKey(fd => fd.FagId);

        builder.Entity<FagDage>()
            .HasOne(fd => fd.Laerer)
            .WithMany(l => l.FagsDages)
            .HasForeignKey(fd => fd.LaererId);       

        builder.Entity<FagDage>()
            .Property(f => f.Dag)
            .HasConversion(
                v => v.ToString(),      
                v => (Dage)Enum.Parse(typeof(Dage), v)  
            );
    }
   
}

