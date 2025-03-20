USE DbQuanAo;
GO
-- ================SanPham_DonHang => SanPham_KichCo================
CREATE OR ALTER TRIGGER trg_InsertDonHang
ON SanPham_DonHang
AFTER INSERT
AS
BEGIN
    UPDATE SanPham_KichCo
    SET soLuong = SanPham_KichCo.soLuong - temp.soLuong
    FROM SanPham_KichCo
	JOIN (SELECT KichCo.id, inserted.SanPham_id, soLuong FROM KichCo JOIN inserted ON KichCo.kichCo = inserted.kichCo) temp
	on SanPham_KichCo.SanPham_id = temp.SanPham_id and SanPham_KichCo.KichCo_id = temp.id
END
go
CREATE OR ALTER TRIGGER trg_HuyDonHang
ON SanPham_DonHang
AFTER DELETE 
AS
BEGIN
	UPDATE SanPham_KichCo
    SET soLuong = SanPham_KichCo.soLuong + temp.soLuong
    FROM SanPham_KichCo
	JOIN (SELECT KichCo.id, deleted.SanPham_id, soLuong FROM KichCo JOIN deleted ON KichCo.kichCo = deleted.kichCo) temp
	on SanPham_KichCo.SanPham_id = temp.SanPham_id and SanPham_KichCo.KichCo_id = temp.id
END;
go
CREATE OR ALTER TRIGGER trg_UpdateSoLuongSanPham
ON SanPham_DonHang
AFTER UPDATE 
AS
BEGIN
	UPDATE SanPham_KichCo
    SET soLuong = SanPham_KichCo.soLuong -
		(SELECT soLuong from inserted WHERE SanPham_id = SanPham_KichCo.SanPham_id) +
		(SELECT soLuong from deleted WHERE SanPham_id = SanPham_KichCo.SanPham_id)
    FROM SanPham_KichCo
	JOIN (SELECT KichCo.id, deleted.SanPham_id, soLuong FROM KichCo JOIN deleted ON KichCo.kichCo = deleted.kichCo) temp
	on SanPham_KichCo.SanPham_id = temp.SanPham_id and SanPham_KichCo.KichCo_id = temp.id
END;
GO
-- ================SanPham_GioHang================
CREATE OR ALTER TRIGGER trg_InsertGioHang
ON SanPham_GioHang
AFTER INSERT
AS
BEGIN
    UPDATE GioHang
    SET tongSoLuong = tongSoLuong + inserted.soLuong
    FROM GioHang join inserted on GioHang.id = inserted.GioHang_id
END
go
CREATE OR ALTER TRIGGER trg_HuyGioHang
ON SanPham_GioHang
AFTER DELETE 
AS
BEGIN
	UPDATE GioHang
    SET tongSoLuong = tongSoLuong - deleted.soLuong
    FROM GioHang join deleted on GioHang.id = deleted.GioHang_id
END;
go
CREATE OR ALTER TRIGGER trg_UpdateSoLuongSanPhamGioHang
ON SanPham_GioHang
AFTER UPDATE 
AS
BEGIN
	UPDATE GioHang
    SET tongSoLuong = soLuong +
		(SELECT soLuong from inserted WHERE GioHang_id = GioHang.id) -
		(SELECT soLuong from deleted WHERE GioHang_id = GioHang.id)
    FROM GioHang join deleted on GioHang.id = deleted.GioHang_id
END;
go
CREATE OR ALTER TRIGGER trg_magiamgia
ON Account_magiamgia
AFTER insert 
AS
BEGIN
	UPDATE MaGiamGia
    SET soLuong = soLuong - 1
    FROM MaGiamGia join inserted on MaGiamGia.id = inserted.Magiamgia_id
END;
GO
-- ================SanPham_KichCo================
CREATE OR ALTER TRIGGER trg_InsertSanPhamKichCo
ON SanPham_KichCo
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET soLuong = SanPham.soLuong + inserted.soLuong
    FROM SanPham join inserted on SanPham.id = inserted.SanPham_id
END
go
CREATE OR ALTER TRIGGER trg_DeleteSanPhamKichCo
ON SanPham_KichCo
AFTER DELETE 
AS
BEGIN
	UPDATE SanPham
    SET soLuong = SanPham.soLuong - deleted.soLuong
    FROM SanPham join deleted on SanPham.id = deleted.SanPham_id
END;
go
CREATE OR ALTER TRIGGER trg_UpdateSanPhamKichCo
ON SanPham_KichCo
AFTER UPDATE 
AS
BEGIN
	UPDATE SanPham
    SET soLuong = SanPham.soLuong +
		(SELECT soLuong from inserted WHERE SanPham_id = SanPham.id) -
		(SELECT soLuong from deleted WHERE SanPham_id = SanPham.id)
    FROM SanPham join deleted on SanPham.id = deleted.SanPham_id
END;
GO