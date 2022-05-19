using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebTraSua.Models
{
	public partial class MyDBTraSuaContext : DbContext
	{
		public MyDBTraSuaContext()
			: base("name=MyDBTraSuaContext")
		{
		}

		public virtual DbSet<Anh> Anhs { get; set; }
		public virtual DbSet<DanhMuc> DanhMucs { get; set; }
		public virtual DbSet<HoaDon> HoaDons { get; set; }
		public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
		public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
		public virtual DbSet<SanPham> SanPhams { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<TinTuc> TinTucs { get; set; }
		public virtual DbSet<AnhSP> AnhSPs { get; set; }
		public virtual DbSet<BinhLuan> BinhLuans { get; set; }
		public virtual DbSet<ChiTietHD> ChiTietHDs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Anh>()
				.Property(e => e.MaA)
				.IsUnicode(false);

			modelBuilder.Entity<Anh>()
				.Property(e => e.DuongDan)
				.IsUnicode(false);

			modelBuilder.Entity<Anh>()
				.HasMany(e => e.NguyenLieux)
				.WithRequired(e => e.Anh)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Anh>()
				.HasMany(e => e.AnhSPs)
				.WithRequired(e => e.Anh)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Anh>()
				.HasMany(e => e.TinTucs)
				.WithRequired(e => e.Anh)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<DanhMuc>()
				.Property(e => e.MaDM)
				.IsUnicode(false);

			modelBuilder.Entity<DanhMuc>()
				.HasMany(e => e.SanPhams)
				.WithRequired(e => e.DanhMuc)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HoaDon>()
				.Property(e => e.MaHD)
				.IsUnicode(false);

			modelBuilder.Entity<HoaDon>()
				.Property(e => e.MaND)
				.IsUnicode(false);

			modelBuilder.Entity<HoaDon>()
				.Property(e => e.TenHD)
				.IsUnicode(false);

			modelBuilder.Entity<HoaDon>()
				.Property(e => e.SoDienThoaiHD)
				.IsUnicode(false);

			modelBuilder.Entity<HoaDon>()
				.HasMany(e => e.ChiTietHDs)
				.WithRequired(e => e.HoaDon)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<NguoiDung>()
				.Property(e => e.MaND)
				.IsUnicode(false);

			modelBuilder.Entity<NguoiDung>()
				.Property(e => e.EmailND)
				.IsUnicode(false);

			modelBuilder.Entity<NguoiDung>()
				.Property(e => e.SoDienThoaiND)
				.IsUnicode(false);

			modelBuilder.Entity<NguoiDung>()
				.HasMany(e => e.HoaDons)
				.WithRequired(e => e.NguoiDung)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<NguoiDung>()
				.HasMany(e => e.NguyenLieux)
				.WithRequired(e => e.NguoiDung)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<NguoiDung>()
				.HasMany(e => e.BinhLuans)
				.WithRequired(e => e.NguoiDung)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<NguyenLieu>()
				.Property(e => e.MaNL)
				.IsUnicode(false);

			modelBuilder.Entity<NguyenLieu>()
				.Property(e => e.MaA)
				.IsUnicode(false);

			modelBuilder.Entity<NguyenLieu>()
				.Property(e => e.MaND)
				.IsUnicode(false);

			modelBuilder.Entity<SanPham>()
				.Property(e => e.MaSP)
				.IsUnicode(false);

			modelBuilder.Entity<SanPham>()
				.Property(e => e.MaDM)
				.IsUnicode(false);

			modelBuilder.Entity<SanPham>()
				.HasMany(e => e.ChiTietHDs)
				.WithRequired(e => e.SanPham)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<SanPham>()
				.HasMany(e => e.BinhLuans)
				.WithRequired(e => e.SanPham)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<SanPham>()
				.HasMany(e => e.AnhSPs)
				.WithRequired(e => e.SanPham)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TinTuc>()
				.Property(e => e.MaTT)
				.IsUnicode(false);

			modelBuilder.Entity<TinTuc>()
				.Property(e => e.MaA)
				.IsUnicode(false);

			modelBuilder.Entity<AnhSP>()
				.Property(e => e.MaSP)
				.IsUnicode(false);

			modelBuilder.Entity<AnhSP>()
				.Property(e => e.MaA)
				.IsUnicode(false);

			modelBuilder.Entity<BinhLuan>()
				.Property(e => e.MaSP)
				.IsUnicode(false);

			modelBuilder.Entity<BinhLuan>()
				.Property(e => e.MaND)
				.IsUnicode(false);

			modelBuilder.Entity<ChiTietHD>()
				.Property(e => e.MaSP)
				.IsUnicode(false);

			modelBuilder.Entity<ChiTietHD>()
				.Property(e => e.MaHD)
				.IsUnicode(false);
		}
	}
}
