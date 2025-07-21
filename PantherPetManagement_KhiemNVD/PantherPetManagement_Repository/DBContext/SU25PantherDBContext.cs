using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PantherPetManagement_Repository.Models;

namespace PantherPetManagement_Repository.DBContext;

public partial class SU25PantherDBContext : DbContext
{
    public SU25PantherDBContext()
    {
    }

    public SU25PantherDBContext(DbContextOptions<SU25PantherDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PantherAccount> PantherAccounts { get; set; }

    public virtual DbSet<PantherProfile> PantherProfiles { get; set; }

    public virtual DbSet<PantherType> PantherTypes { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PantherAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("PantherAccount");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<PantherProfile>(entity =>
        {
            entity.ToTable("PantherProfile");

            entity.Property(e => e.Characteristics)
                .IsRequired()
                .HasMaxLength(2000);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PantherName)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Warning)
                .IsRequired()
                .HasMaxLength(1500);

            entity.HasOne(d => d.PantherType).WithMany(p => p.PantherProfiles)
                .HasForeignKey(d => d.PantherTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PantherProfile_PantherType");
        });

        modelBuilder.Entity<PantherType>(entity =>
        {
            entity.ToTable("PantherType");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Origin).HasMaxLength(250);
            entity.Property(e => e.PantherTypeName).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}