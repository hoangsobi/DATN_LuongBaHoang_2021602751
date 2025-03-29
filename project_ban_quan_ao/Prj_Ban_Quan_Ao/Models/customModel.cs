namespace Prj_Ban_Quan_Ao.Models
{
    public class customModel
    {
    }

    public class LoginRequestCustom
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }

    public class AccountCustom
    {
        public Guid Id {  get; set; }
        public string TenDangNhap {  get; set; }
        public string TenHienThi {  get; set; }
        public string MatKhau {  get; set; }
        public string SoDienThoai {  get; set; }
        public string  Email {  get; set; }
        public string DuongDanAnh {  get; set; }
        public bool? IsLocked {  get; set; }
        public string VaiTroName {  get; set; }
        public List<QuyenDto> listRout {  get; set; }
    }
    public class QuyenDto
    {
        public string Rout { get; set; }
        public string Ten { get; set; }
        public string IconClass { get; set;}
        public int? Order { get; set;}
    }
    public class TrangThaiDonHang
    {
        public const string ChoXacNhan = "Chờ xác nhận";
        public const string DaHuy = "Đã hủy";
        public const string DangChuanBiHang = "Đang chuẩn bị hàng";
        public const string DangGiaoHang = "Đang giao hàng";
        public const string GiaoHangThanhCong = "Giao hàng thành công";
    }
}
