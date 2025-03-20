USE DbQuanAo
GO
-- ================LoaiSanPham================
INSERT INTO LoaiSanPham (id, tenLoai, moTa, ngayTao)
VALUES
    ('AF60CBAC-CC26-414A-98DE-0ADD96792401', N'Quần khaki', NULL, '2024-04-17 11:27:11.630'),
    ('36A8691F-7AB8-4148-A19E-1A65F8C9E04B', N'Đồng hồ', NULL, '2024-04-17 11:25:14.930'),
    ('5660EA77-B947-4168-A75C-26EBD73D1838', N'Balo', NULL, '2024-04-17 11:25:34.557'),
    ('9CA5D890-DAC1-467A-B06A-28CF711AA898', N'Áo sweater', NULL, '2024-04-17 11:21:37.657'),
    ('44B14E5F-E84E-44B9-81D9-2FFDA01E0FD2', N'Áo phao', NULL, '2024-04-17 11:26:39.517'),
    ('48F1B6D1-EF14-44ED-8BD9-4305669B74A0', N'Áo khoác gió', NULL, '2024-04-17 11:21:03.127'),
    ('D4F1D78D-7505-4041-8F36-68200096E893', N'Mũ', NULL, '2024-04-17 11:25:25.163'),
    ('44A4EC7A-7EE6-4C92-A311-73F1DB460FEA', N'Áo bomber', NULL, '2024-04-17 11:21:47.777'),
    ('F5439B71-98C9-4CCE-AC2F-7A689E924CEA', N'Áo polo', NULL, '2024-04-17 11:20:04.060'),
    ('2904143F-949A-4BF6-A530-A0E9D24507B9', N'Áo sơ mi', NULL, '2024-04-17 11:20:08.860'),
    ('7EEAA5E7-41EF-49A6-AC4D-A23DFFBE3F81', N'Áo thun', NULL, '2024-04-17 11:19:50.600'),
    ('2FA78891-38B8-4616-BAF3-C0C1309D49E0', N'Quần ngủ', NULL, '2024-04-17 11:22:17.967'),
    ('A2E2E9F9-C630-44EC-AAF4-D83C61CAC11D', N'Áo hoodie', NULL, '2024-04-17 11:21:12.547'),
    ('21729103-15E7-4448-9309-DE07B2720E03', N'Quần shorts', NULL, '2024-04-17 11:22:05.633'),
    ('FDD00170-D6FD-4749-9D08-E351F09461B7', N'Quần jeans', NULL, '2024-04-17 11:22:01.997'),
    ('71A9CE9B-559D-4EB3-9727-E659FB1F8D95', N'Váy', NULL, '2024-04-17 11:24:34.450'),
    ('63496EB6-EEED-478C-8FCF-F0DC30002D0A', N'Quần tây', NULL, '2024-04-17 11:21:58.143');
GO
-- ================SanPham================
-- ----------Quan KhaKi----------
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
	DECLARE @masp NVARCHAR(30) = 'QuanKhaKi' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Quần Khaki ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/quanKhaki' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('AF60CBAC-CC26-414A-98DE-0ADD96792401', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Dong ho----------
DECLARE @j INT = 1;
WHILE @j <= 25
BEGIN
	DECLARE @masp NVARCHAR(30) = 'DongHo' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Đồng hồ ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/dongho' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('36A8691F-7AB8-4148-A19E-1A65F8C9E04B', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Balo----------
DECLARE @j INT = 1;
WHILE @j <= 12
BEGIN
	DECLARE @masp NVARCHAR(30) = 'Balo' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = 'Balo ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/balo' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('5660EA77-B947-4168-A75C-26EBD73D1838', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao sweater----------
DECLARE @j INT = 1;
WHILE @j <= 12
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoSweater' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Áo sweater ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/sweater' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('9CA5D890-DAC1-467A-B06A-28CF711AA898', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao phao----------
DECLARE @j INT = 1;
WHILE @j <= 16
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoPhao' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Áo phao ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/aophao' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('44B14E5F-E84E-44B9-81D9-2FFDA01E0FD2', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao gio----------
DECLARE @j INT = 1;
WHILE @j <= 29
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoGio' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Áo gió ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/aogio' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('36A8691F-7AB8-4148-A19E-1A65F8C9E04B', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Mu----------
DECLARE @j INT = 1;
WHILE @j <= 19
BEGIN
	DECLARE @masp NVARCHAR(30) = 'Mu' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Mũ ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/mu' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('D4F1D78D-7505-4041-8F36-68200096E893', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao Bomber----------
DECLARE @j INT = 1;
WHILE @j <= 26
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoBomber' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Áo Bomber ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/aobomber' + CAST(@j AS NVARCHAR(2));

    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('44A4EC7A-7EE6-4C92-A311-73F1DB460FEA', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao Polo----------
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoPolo' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Áo Polo ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/aopolo' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('F5439B71-98C9-4CCE-AC2F-7A689E924CEA', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao SoMi----------
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoSoMi' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Áo sơ mi ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/aosomi' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('2904143F-949A-4BF6-A530-A0E9D24507B9', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao Thun----------
DECLARE @j INT = 1;
WHILE @j <= 11
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoThun' +  RIGHT('00' + CAST(@j AS NVARCHAR(3)), 3);
	DECLARE @ten NVARCHAR(25) = N'Áo Thun ' + CAST(@j AS NVARCHAR(3));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/aothun' + CAST(@j AS NVARCHAR(3));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('7EEAA5E7-41EF-49A6-AC4D-A23DFFBE3F81', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Quan ngu----------
DECLARE @j INT = 1;
WHILE @j <= 28
BEGIN
	DECLARE @masp NVARCHAR(30) = 'QuanNgu' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Quần ngủ ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/quanngu' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('2FA78891-38B8-4616-BAF3-C0C1309D49E0', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Ao Hoodie----------
DECLARE @j INT = 1;
WHILE @j <= 12
BEGIN
	DECLARE @masp NVARCHAR(30) = 'AoHoodie' +  RIGHT('00' + CAST(@j AS NVARCHAR(3)), 160);
	DECLARE @ten NVARCHAR(25) = N'Áo hoodie ' + CAST(@j AS NVARCHAR(3));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/hoodie' + CAST(@j AS NVARCHAR(3));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('A2E2E9F9-C630-44EC-AAF4-D83C61CAC11D', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Quan Short----------
DECLARE @j INT = 1;
WHILE @j <= 12
BEGIN
	DECLARE @masp NVARCHAR(30) = 'QuanShort' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Quần short ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/quanshort' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('21729103-15E7-4448-9309-DE07B2720E03', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Quan Jeans----------
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
	DECLARE @masp NVARCHAR(30) = 'QuanJeans' +  RIGHT('0' + CAST(@j AS NVARCHAR(2)), 2);
	DECLARE @ten NVARCHAR(25) = N'Quần Jeans ' + CAST(@j AS NVARCHAR(2));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/quanjeans' + CAST(@j AS NVARCHAR(2));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('FDD00170-D6FD-4749-9D08-E351F09461B7', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Vay----------
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
	DECLARE @masp NVARCHAR(30) = 'Vay' +  RIGHT('00' + CAST(@j AS NVARCHAR(3)), 3);
	DECLARE @ten NVARCHAR(25) = N'Váy ' + CAST(@j AS NVARCHAR(3));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/vay' + CAST(@j AS NVARCHAR(3));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('71A9CE9B-559D-4EB3-9727-E659FB1F8D95', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO
-- ----------Quan Tay----------
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
	DECLARE @masp NVARCHAR(30) = 'QuanTay' +  RIGHT('00' + CAST(@j AS NVARCHAR(3)), 3);
	DECLARE @ten NVARCHAR(25) = N'Quần tây ' + CAST(@j AS NVARCHAR(3));
	DECLARE @mau INT = FLOOR(RAND() * 9) + 1;
	DECLARE @giachung FLOAT = CEILING(RAND() * (2000000 - 100000) / 100000) * 100000;
	DECLARE @gia FLOAT = @giachung;
	DECLARE @mota NVARCHAR(25) = NULL;
	DECLARE @ghichu NVARCHAR(25) = NULL
	DECLARE @giasaugiam FLOAT = @giachung - CEILING(RAND() * (@giachung - 50000) / 50000) * 50000;
	DECLARE @chatlieu NVARCHAR(25) = NULL
	DECLARE @duongDanAnh NVARCHAR(25) = '../assests/AnhSanPham/quantay' + CAST(@j AS NVARCHAR(3));


    INSERT INTO SanPham(LoaiSanPham_id, maSanPham, ten, gia, moTa, ghiChu, giaSauGiam, chatLieu, duongDanAnh)
    VALUES ('63496EB6-EEED-478C-8FCF-F0DC30002D0A', @masp, @ten, @mau, @gia, @mota, @ghichu, @giasaugiam, @chatlieu, @duongDanAnh);

    SET @j = @j + 1;
END;
GO

select count(*) from SanPham