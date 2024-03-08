using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserPanelAPP.Models;

public partial class DbLocalContext : DbContext
{
    public DbLocalContext()
    {
    }

    public DbLocalContext(DbContextOptions<DbLocalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=dbLocal;Username=postgres;Password=3121");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Tcno).HasName("Users_pkey");

            entity.Property(e => e.Tcno)
                .HasMaxLength(11)
                .HasColumnName("TCNO");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
