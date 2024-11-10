using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiDelivery.Repositories.Entities;

public partial class KoiFishContext : DbContext
{
    public KoiFishContext()
    {
    }

    public KoiFishContext(DbContextOptions<KoiFishContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=KoiFish;Persist Security Info=True;User ID=sa;Password=reallyStrongPwd123;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiFish__3213E83FD21A51BC");

            entity.ToTable("KoiFish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CareRequirements).HasColumnName("care_requirements");
            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .HasColumnName("color");
            entity.Property(e => e.LifespanYears).HasColumnName("lifespan_years");
            entity.Property(e => e.NotableFeatures).HasColumnName("notable_features");
            entity.Property(e => e.SizeCm).HasColumnName("size_cm");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
