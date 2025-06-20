﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prj_Ban_Quan_Ao.Models;

public partial class DbQuanAoContext : DbContext
{
    public DbQuanAoContext()
    {
    }

    public DbQuanAoContext(DbContextOptions<DbQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountMaGiamGium> AccountMaGiamGia { get; set; }

    public virtual DbSet<AnhDanhGium> AnhDanhGia { get; set; }

    public virtual DbSet<AnhSanPham> AnhSanPhams { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<ChatBox> ChatBoxes { get; set; }

    public virtual DbSet<ChiPhi> ChiPhis { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<DiaChi> DiaChis { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<GopY> Gopies { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<MaGiamGium> MaGiamGia { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamDonHang> SanPhamDonHangs { get; set; }

    public virtual DbSet<SanPhamGioHang> SanPhamGioHangs { get; set; }

    public virtual DbSet<SanPhamKichCo> SanPhamKichCos { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<VaiTroQuyen> VaiTroQuyens { get; set; }

    public virtual DbSet<YeuThich> YeuThiches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Hoang-sobi;Initial Catalog=DbQuanAo;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F29E21319");

            entity.ToTable("Account", tb => tb.HasTrigger("trg_InsertAccount_GioHang"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DuongDanAnh).HasColumnName("duongDanAnh");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");
            entity.Property(e => e.IsLocked).HasColumnName("isLocked");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("matKhau");
            entity.Property(e => e.NgaySinh).HasColumnName("ngaySinh");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(255)
                .HasColumnName("soDienThoai");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(255)
                .HasColumnName("tenDangNhap");
            entity.Property(e => e.TenHienThi)
                .HasMaxLength(255)
                .HasColumnName("tenHienThi");
            entity.Property(e => e.VaiTroId).HasColumnName("vaiTroId");

            entity.HasOne(d => d.VaiTro).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.VaiTroId)
                .HasConstraintName("FK_Account_VaiTro");
        });

        modelBuilder.Entity<AccountMaGiamGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account___3213E83F129DEC7B");

            entity.ToTable("Account_MaGiamGia", tb => tb.HasTrigger("trg_magiamgia"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.MagiamgiaId).HasColumnName("Magiamgia_id");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountMaGiamGia)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Account_MaGiamGia_MaGiamGia_id");

            entity.HasOne(d => d.Magiamgia).WithMany(p => p.AccountMaGiamGia)
                .HasForeignKey(d => d.MagiamgiaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Account_MaGiamGia_Account_id");
        });

        modelBuilder.Entity<AnhDanhGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnhDanhG__3213E83F0936EDFE");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DanhGiaId).HasColumnName("DanhGia_id");
            entity.Property(e => e.DuongDan).HasColumnName("duongDan");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");

            entity.HasOne(d => d.DanhGia).WithMany(p => p.AnhDanhGia)
                .HasForeignKey(d => d.DanhGiaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_AnhDanhGia_DanhGia_id");
        });

        modelBuilder.Entity<AnhSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnhSanPh__3213E83F3AC1BB1B");

            entity.ToTable("AnhSanPham");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DuongDan).HasColumnName("duongDan");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPham_id");

            entity.HasOne(d => d.SanPham).WithMany(p => p.AnhSanPhams)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("fk_AnhSanPham_SanPham_id");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BaiViet__3213E83F2DB3782D");

            entity.ToTable("BaiViet");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.NoiDung).HasColumnName("noiDung");
        });

        modelBuilder.Entity<ChatBox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatBox__3213E83F3911B4B1");

            entity.ToTable("ChatBox");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.AdminId).HasColumnName("Admin_id");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.NguoiGuiId).HasColumnName("nguoiGui_id");
            entity.Property(e => e.NoiDung).HasColumnName("noiDung");
        });

        modelBuilder.Entity<ChiPhi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiPhi__3213E83F83A3FBE0");

            entity.ToTable("ChiPhi");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.MucDich)
                .HasMaxLength(1000)
                .HasColumnName("mucDich");
            entity.Property(e => e.NgayChi)
                .HasColumnType("datetime")
                .HasColumnName("ngayChi");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SoTien).HasColumnName("soTien");
            entity.Property(e => e.TenChiPhi)
                .HasMaxLength(500)
                .HasColumnName("tenChiPhi");

            entity.HasOne(d => d.Account).WithMany(p => p.ChiPhis)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ChiPhi__accountI__2077C861");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DanhGia__3213E83F6069BE80");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_DeleteDanhGia");
                    tb.HasTrigger("trg_InsertDanhGia");
                    tb.HasTrigger("trg_UpdateDanhGia");
                });

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.DonHangId).HasColumnName("DonHang_id");
            entity.Property(e => e.KichCo).HasColumnName("kichCo");
            entity.Property(e => e.Mau)
                .HasComment("1.đỏ, 2. cam, 3. vàng, 4. xanh lục, 5. xanh dương, 6. tím, 7.đen, 8. trắng")
                .HasColumnName("mau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.NoiDung).HasColumnName("noiDung");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPham_id");
            entity.Property(e => e.Vote).HasColumnName("vote");

            entity.HasOne(d => d.Account).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_DanhGia_Account_id");

            entity.HasOne(d => d.SanPham).WithMany(p => p.DanhGiaNavigation)
                .HasForeignKey(d => d.SanPhamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_SanPham_DanhGia_id");
        });

        modelBuilder.Entity<DiaChi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiaChi__3213E83FFCBD13B5");

            entity.ToTable("DiaChi");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(255)
                .HasColumnName("ghiChu");
            entity.Property(e => e.Huyen)
                .HasMaxLength(255)
                .HasColumnName("huyen");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.Tinh)
                .HasMaxLength(255)
                .HasColumnName("tinh");
            entity.Property(e => e.Xa)
                .HasMaxLength(255)
                .HasColumnName("xa");

            entity.HasOne(d => d.Account).WithMany(p => p.DiaChis)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_DiaChi_Account_id");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DonHang__3213E83F9B700232");

            entity.ToTable("DonHang");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.DiaChi).HasColumnName("diaChi");
            entity.Property(e => e.GhiChu).HasColumnName("ghiChu");
            entity.Property(e => e.MaGiamGiaId).HasColumnName("MaGiamGia_id");
            entity.Property(e => e.NgayHuy)
                .HasColumnType("datetime")
                .HasColumnName("ngayHuy");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.PhuongThucThanhToan).HasColumnName("phuongThucThanhToan");
            entity.Property(e => e.PhuongThucVanChuyen).HasColumnName("phuongThucVanChuyen");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(50)
                .HasColumnName("soDienThoai");
            entity.Property(e => e.TenNguoiMua).HasColumnName("tenNguoiMua");
            entity.Property(e => e.ThanhTien).HasColumnName("thanhTien");
            entity.Property(e => e.TrangThai)
                .HasComment("Chờ xác nhận đơn hàng, Đang chuẩn bị hàng, Đang giao hàng, Giao hàng thành công, Đã hủy")
                .HasColumnName("trangThai");

            entity.HasOne(d => d.Account).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_DonHang_Account_id");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GioHang__3213E83FC552FA08");

            entity.ToTable("GioHang");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.TongSoLuong)
                .HasDefaultValue(0)
                .HasColumnName("tongSoLuong");

            entity.HasOne(d => d.Account).WithOne(p => p.GioHang)
                .HasForeignKey<GioHang>(d => d.Id)
                .HasConstraintName("fk_GioHang_id");
        });

        modelBuilder.Entity<GopY>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GopY__3213E83F8D93A4D8");

            entity.ToTable("GopY");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("hoTen");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.NoiDung).HasColumnName("noiDung");
            entity.Property(e => e.PhanHoi).HasColumnName("phanHoi");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(255)
                .HasColumnName("soDienThoai");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(500)
                .HasColumnName("tieuDe");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoaiSanP__3213E83FE10F5703");

            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.LoaiSanPhamChaId).HasColumnName("LoaiSanPhamCha_Id");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(255)
                .HasColumnName("tenLoai");
        });

        modelBuilder.Entity<MaGiamGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MaGiamGi__3213E83FD86A52CC");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.LuongGiam)
                .HasComment("theo phần trăm")
                .HasColumnName("luongGiam");
            entity.Property(e => e.Ma).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.NgayHetHan).HasColumnName("ngayHetHan");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quyen__3213E83F63867134");

            entity.ToTable("Quyen");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IconClass)
                .HasMaxLength(50)
                .HasColumnName("iconClass");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Rout)
                .HasMaxLength(500)
                .HasColumnName("rout");
            entity.Property(e => e.Ten)
                .HasMaxLength(500)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham__3213E83F1C164B26");

            entity.ToTable("SanPham");

            entity.HasIndex(e => e.MaSanPham, "UQ__SanPham__5B439C42849C83D7").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ChatLieu)
                .HasMaxLength(255)
                .HasColumnName("chatLieu");
            entity.Property(e => e.DanhGia)
                .HasDefaultValue(0.0)
                .HasComment("đánh giá trung bình, không cho sửa")
                .HasColumnName("danhGia");
            entity.Property(e => e.DuongDanAnh).HasColumnName("duongDanAnh");
            entity.Property(e => e.GhiChu).HasColumnName("ghiChu");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.GiaSauGiam).HasColumnName("giaSauGiam");
            entity.Property(e => e.LoaiSanPhamId).HasColumnName("LoaiSanPham_id");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(255)
                .HasColumnName("maSanPham");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayCapNhat");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.Ten).HasColumnName("ten");

            entity.HasOne(d => d.LoaiSanPham).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.LoaiSanPhamId)
                .HasConstraintName("fk_SanPham_LoaiSanPham_id");
        });

        modelBuilder.Entity<SanPhamDonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham___3213E83F580DD465");

            entity.ToTable("SanPham_DonHang", tb =>
                {
                    tb.HasTrigger("trg_AfterDeleteSanPhamDonHang");
                    tb.HasTrigger("trg_AfterInsertSanPhamDonHang");
                });

            entity.HasIndex(e => new { e.SanPhamId, e.DonHangId, e.KichCo, e.Mau }, "uq_sanpham_donhang").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DonHangId).HasColumnName("DonHang_id");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.KichCo).HasColumnName("kichCo");
            entity.Property(e => e.Mau)
                .HasComment("1.đỏ, 2. cam, 3. vàng, 4. xanh lục, 5. xanh dương, 6. tím, 7.đen, 8. trắng")
                .HasColumnName("mau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPham_id");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.DonHang).WithMany(p => p.SanPhamDonHangs)
                .HasForeignKey(d => d.DonHangId)
                .HasConstraintName("fk_SanPham_DonHang_DonHang_id");

            entity.HasOne(d => d.SanPham).WithMany(p => p.SanPhamDonHangs)
                .HasForeignKey(d => d.SanPhamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_SanPham_DonHang_SanPham_id");
        });

        modelBuilder.Entity<SanPhamGioHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham___3213E83FF7CD71A5");

            entity.ToTable("SanPham_GioHang", tb =>
                {
                    tb.HasTrigger("trg_HuyGioHang");
                    tb.HasTrigger("trg_InsertGioHang");
                    tb.HasTrigger("trg_UpdateSoLuongSanPhamGioHang");
                });

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.GioHangId).HasColumnName("GioHang_id");
            entity.Property(e => e.KichCo).HasColumnName("kichCo");
            entity.Property(e => e.Mau)
                .HasComment("1.đỏ, 2. cam, 3. vàng, 4. xanh lục, 5. xanh dương, 6. tím, 7.đen, 8. trắng")
                .HasColumnName("mau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPham_id");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.GioHang).WithMany(p => p.SanPhamGioHangs)
                .HasForeignKey(d => d.GioHangId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_SanPham_GioHang_GioHang_id");

            entity.HasOne(d => d.SanPham).WithMany(p => p.SanPhamGioHangs)
                .HasForeignKey(d => d.SanPhamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_SanPham_GioHang_SanPham_id");
        });

        modelBuilder.Entity<SanPhamKichCo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham___3213E83F67FADB66");

            entity.ToTable("SanPham_KichCo", tb =>
                {
                    tb.HasTrigger("trg_DeleteSanPhamKichCo");
                    tb.HasTrigger("trg_InsertSanPhamKichCo");
                    tb.HasTrigger("trg_UpdateSanPhamKichCo");
                });

            entity.HasIndex(e => new { e.SanPhamId, e.KichCo, e.Mau }, "uq_sanpham_kichco").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.KichCo).HasColumnName("kichCo");
            entity.Property(e => e.Mau).HasColumnName("mau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPham_id");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.SanPham).WithMany(p => p.SanPhamKichCos)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("fk_SanPham_KichCo_SanPham_id");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VaiTro__3213E83FBF366197");

            entity.ToTable("VaiTro");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
        });

        modelBuilder.Entity<VaiTroQuyen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VaiTro_Q__3213E83F12D834F2");

            entity.ToTable("VaiTro_Quyen");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");

            entity.HasOne(d => d.Quyen).WithMany(p => p.VaiTroQuyens)
                .HasForeignKey(d => d.QuyenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_VaiTro_Quyen_Quyen");

            entity.HasOne(d => d.VaiTro).WithMany(p => p.VaiTroQuyens)
                .HasForeignKey(d => d.VaiTroId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_VaiTro_Quyen_VaiTro");
        });

        modelBuilder.Entity<YeuThich>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__YeuThich__3213E83F3A3C3081");

            entity.ToTable("YeuThich");

            entity.HasIndex(e => new { e.AccountId, e.SanPhamId }, "UQ_accountId_sanphamid").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngayTao");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPham_id");

            entity.HasOne(d => d.Account).WithMany(p => p.YeuThiches)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_YeuThich_Account_id");

            entity.HasOne(d => d.SanPham).WithMany(p => p.YeuThiches)
                .HasForeignKey(d => d.SanPhamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_YeuThich_SanPham_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
