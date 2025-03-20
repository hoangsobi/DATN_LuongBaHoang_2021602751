using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prj_Ban_Quan_Ao.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Account",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        tenDangNhap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        tenHienThi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        matKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        vaiTro = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
            //        gioiTinh = table.Column<bool>(type: "bit", nullable: true),
            //        ngaySinh = table.Column<DateOnly>(type: "date", nullable: true),
            //        soDienThoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        duongDanAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Account__3213E83F29E21319", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "BaiViet",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BaiViet__3213E83F2DB3782D", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatBox",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        Admin_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        Account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        nguoiGui_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ChatBox__3213E83F3911B4B1", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GopY",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        hoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        soDienThoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__GopY__3213E83F8D93A4D8", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LoaiSanPham",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        tenLoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        moTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__LoaiSanP__3213E83FE10F5703", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MaGiamGia",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        soLuong = table.Column<int>(type: "int", nullable: true),
            //        Ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        luongGiam = table.Column<double>(type: "float", nullable: true, comment: "theo phần trăm"),
            //        ngayHetHan = table.Column<DateOnly>(type: "date", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        moTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__MaGiamGi__3213E83FD86A52CC", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DiaChi",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        Account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        xa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        huyen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        tinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        ghiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__DiaChi__3213E83FFCBD13B5", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_DiaChi_Account_id",
            //            column: x => x.Account_id,
            //            principalTable: "Account",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DonHang",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        Account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        MaGiamGia_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        thanhTien = table.Column<double>(type: "float", nullable: true),
            //        diaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        phuongThucVanChuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        phuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        trangThai = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Chờ xác nhận đơn hàng, Đang chuẩn bị hàng, Đang giao hàng, Giao hàng thành công, Đã hủy"),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        ngayHuy = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__DonHang__3213E83F9B700232", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_DonHang_Account_id",
            //            column: x => x.Account_id,
            //            principalTable: "Account",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GioHang",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        tongSoLuong = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__GioHang__3213E83FC552FA08", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_GioHang_id",
            //            column: x => x.id,
            //            principalTable: "Account",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "SanPham",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        LoaiSanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        maSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        gia = table.Column<double>(type: "float", nullable: true),
            //        soLuong = table.Column<int>(type: "int", nullable: true),
            //        moTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        danhGia = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0, comment: "đánh giá trung bình, không cho sửa"),
            //        ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        giaSauGiam = table.Column<double>(type: "float", nullable: true),
            //        chatLieu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        ngayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        duongDanAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SanPham__3213E83F1C164B26", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_SanPham_LoaiSanPham_id",
            //            column: x => x.LoaiSanPham_id,
            //            principalTable: "LoaiSanPham",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Account_MaGiamGia",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        Account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        Magiamgia_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Account___3213E83F129DEC7B", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_Account_MaGiamGia_Account_id",
            //            column: x => x.Magiamgia_id,
            //            principalTable: "MaGiamGia",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "fk_Account_MaGiamGia_MaGiamGia_id",
            //            column: x => x.Account_id,
            //            principalTable: "Account",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AnhSanPham",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        SanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        duongDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__AnhSanPh__3213E83F3AC1BB1B", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_AnhSanPham_SanPham_id",
            //            column: x => x.SanPham_id,
            //            principalTable: "SanPham",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DanhGia",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        Account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        DonHang_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        vote = table.Column<double>(type: "float", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        kichCo = table.Column<double>(type: "float", nullable: true),
            //        mau = table.Column<int>(type: "int", nullable: true, comment: "1.đỏ, 2. cam, 3. vàng, 4. xanh lục, 5. xanh dương, 6. tím, 7.đen, 8. trắng")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__DanhGia__3213E83F6069BE80", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_DanhGia_Account_id",
            //            column: x => x.Account_id,
            //            principalTable: "Account",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "fk_SanPham_DanhGia_id",
            //            column: x => x.SanPham_id,
            //            principalTable: "SanPham",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SanPham_DonHang",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        SanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        DonHang_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        soLuong = table.Column<int>(type: "int", nullable: false),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        kichCo = table.Column<double>(type: "float", nullable: true),
            //        mau = table.Column<int>(type: "int", nullable: true, comment: "1.đỏ, 2. cam, 3. vàng, 4. xanh lục, 5. xanh dương, 6. tím, 7.đen, 8. trắng")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SanPham___3213E83F580DD465", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_SanPham_DonHang_DonHang_id",
            //            column: x => x.DonHang_id,
            //            principalTable: "DonHang",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "fk_SanPham_DonHang_SanPham_id",
            //            column: x => x.SanPham_id,
            //            principalTable: "SanPham",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SanPham_GioHang",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        GioHang_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        SanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        soLuong = table.Column<int>(type: "int", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        kichCo = table.Column<double>(type: "float", nullable: true),
            //        mau = table.Column<int>(type: "int", nullable: true, comment: "1.đỏ, 2. cam, 3. vàng, 4. xanh lục, 5. xanh dương, 6. tím, 7.đen, 8. trắng")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SanPham___3213E83FF7CD71A5", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_SanPham_GioHang_GioHang_id",
            //            column: x => x.GioHang_id,
            //            principalTable: "GioHang",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "fk_SanPham_GioHang_SanPham_id",
            //            column: x => x.SanPham_id,
            //            principalTable: "SanPham",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SanPham_KichCo",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        SanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        kichCo = table.Column<double>(type: "float", nullable: true),
            //        soLuong = table.Column<int>(type: "int", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        mau = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SanPham___3213E83F67FADB66", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_SanPham_KichCo_SanPham_id",
            //            column: x => x.SanPham_id,
            //            principalTable: "SanPham",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "YeuThich",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        Account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        SanPham_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__YeuThich__3213E83F3A3C3081", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_YeuThich_Account_id",
            //            column: x => x.Account_id,
            //            principalTable: "Account",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "fk_YeuThich_SanPham_id",
            //            column: x => x.SanPham_id,
            //            principalTable: "SanPham",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AnhDanhGia",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        DanhGia_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        duongDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ngayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__AnhDanhG__3213E83F0936EDFE", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_AnhDanhGia_DanhGia_id",
            //            column: x => x.DanhGia_id,
            //            principalTable: "DanhGia",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Account_MaGiamGia_Account_id",
            //    table: "Account_MaGiamGia",
            //    column: "Account_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Account_MaGiamGia_Magiamgia_id",
            //    table: "Account_MaGiamGia",
            //    column: "Magiamgia_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AnhDanhGia_DanhGia_id",
            //    table: "AnhDanhGia",
            //    column: "DanhGia_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AnhSanPham_SanPham_id",
            //    table: "AnhSanPham",
            //    column: "SanPham_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DanhGia_Account_id",
            //    table: "DanhGia",
            //    column: "Account_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DanhGia_SanPham_id",
            //    table: "DanhGia",
            //    column: "SanPham_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiaChi_Account_id",
            //    table: "DiaChi",
            //    column: "Account_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonHang_Account_id",
            //    table: "DonHang",
            //    column: "Account_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SanPham_LoaiSanPham_id",
            //    table: "SanPham",
            //    column: "LoaiSanPham_id");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__SanPham__5B439C42849C83D7",
            //    table: "SanPham",
            //    column: "maSanPham",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_SanPham_DonHang_DonHang_id",
            //    table: "SanPham_DonHang",
            //    column: "DonHang_id");

            //migrationBuilder.CreateIndex(
            //    name: "uq_sanpham_donhang",
            //    table: "SanPham_DonHang",
            //    columns: new[] { "SanPham_id", "DonHang_id", "kichCo", "mau" },
            //    unique: true,
            //    filter: "[SanPham_id] IS NOT NULL AND [DonHang_id] IS NOT NULL AND [kichCo] IS NOT NULL AND [mau] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SanPham_GioHang_GioHang_id",
            //    table: "SanPham_GioHang",
            //    column: "GioHang_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SanPham_GioHang_SanPham_id",
            //    table: "SanPham_GioHang",
            //    column: "SanPham_id");

            //migrationBuilder.CreateIndex(
            //    name: "UC_SanphamKichco",
            //    table: "SanPham_KichCo",
            //    columns: new[] { "SanPham_id", "kichCo" },
            //    unique: true,
            //    filter: "[SanPham_id] IS NOT NULL AND [kichCo] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "uq_sanpham_kichCo",
            //    table: "SanPham_KichCo",
            //    columns: new[] { "SanPham_id", "kichCo", "mau" },
            //    unique: true,
            //    filter: "[SanPham_id] IS NOT NULL AND [kichCo] IS NOT NULL AND [mau] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YeuThich_SanPham_id",
            //    table: "YeuThich",
            //    column: "SanPham_id");

            //migrationBuilder.CreateIndex(
            //    name: "UQ_accountId_sanphamid",
            //    table: "YeuThich",
            //    columns: new[] { "Account_id", "SanPham_id" },
            //    unique: true,
            //    filter: "[Account_id] IS NOT NULL AND [SanPham_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account_MaGiamGia");

            migrationBuilder.DropTable(
                name: "AnhDanhGia");

            migrationBuilder.DropTable(
                name: "AnhSanPham");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "ChatBox");

            migrationBuilder.DropTable(
                name: "DiaChi");

            migrationBuilder.DropTable(
                name: "GopY");

            migrationBuilder.DropTable(
                name: "SanPham_DonHang");

            migrationBuilder.DropTable(
                name: "SanPham_GioHang");

            migrationBuilder.DropTable(
                name: "SanPham_KichCo");

            migrationBuilder.DropTable(
                name: "YeuThich");

            migrationBuilder.DropTable(
                name: "MaGiamGia");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");
        }
    }
}
