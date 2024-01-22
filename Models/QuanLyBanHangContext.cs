using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLBH.Models
{
    public partial class QuanLyBanHangContext : DbContext
    {
        public QuanLyBanHangContext()
        {
        }

        public QuanLyBanHangContext(DbContextOptions<QuanLyBanHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BanHangg> BanHanggs { get; set; }
        public virtual DbSet<BangBaoGium> BangBaoGia { get; set; }
        public virtual DbSet<BaoCaoDoanhThu> BaoCaoDoanhThus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<MuaHang> MuaHangs { get; set; }
        public virtual DbSet<Ncc> Nccs { get; set; }
        public virtual DbSet<SanPhamm> SanPhamms { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-J68PT2SI\\THEVAN;Database=QuanLyBanHang;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BanHangg>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("BanHangg");

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.Dvt).HasColumnName("DVT");

                entity.Property(e => e.HangSx)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HangSX");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<BangBaoGium>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.Dvt).HasColumnName("DVT");

                entity.Property(e => e.SanPham)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaoCaoDoanhThu>(entity =>
            {
                entity.HasKey(e => e.SoLuongBan);

                entity.ToTable("BaoCaoDoanhThu");

                entity.Property(e => e.SoLuongBan).ValueGeneratedNever();
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .ValueGeneratedNever()
                    .HasColumnName("MaKH");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SoDt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<MuaHang>(entity =>
            {
                entity.HasKey(e => e.MaHang);

                entity.ToTable("MuaHang");

                entity.Property(e => e.MaHang).ValueGeneratedNever();

                entity.Property(e => e.Dvt).HasColumnName("DVT");

                entity.Property(e => e.TenHang)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ncc>(entity =>
            {
                entity.HasKey(e => e.MaNcc);

                entity.ToTable("NCC");

                entity.Property(e => e.MaNcc)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChiNcc)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("DiaChiNCC");

                entity.Property(e => e.QuocGia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<SanPhamm>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SanPhamm");

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.Dvt).HasColumnName("DVT");

                entity.Property(e => e.HangSx)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HangSX");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("TenSP");

                entity.Property(e => e.ThanhPhan)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
