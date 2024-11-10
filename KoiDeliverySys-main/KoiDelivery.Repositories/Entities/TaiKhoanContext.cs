using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiDelivery.Repositories.Entities;

public partial class TaiKhoanContext : DbContext
{
    public TaiKhoanContext()
    {
    }

    public TaiKhoanContext(DbContextOptions<TaiKhoanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaiKhoanKhachHang> TaiKhoanKhachHangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.1.2,1433;Initial Catalog=TaiKhoan;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaiKhoanKhachHang>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__TaiKhoan__91CBC3987C26911F");

            entity.ToTable("TaiKhoanKhachHang");

            entity.HasIndex(e => e.EmailAddress, "UQ__TaiKhoan__49A1474032072440").IsUnique();

            entity.Property(e => e.AccId)
                .ValueGeneratedNever()
                .HasColumnName("AccID");
            entity.Property(e => e.Description).HasMaxLength(140);
            entity.Property(e => e.EmailAddress).HasMaxLength(90);
            entity.Property(e => e.Password).HasMaxLength(90);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
