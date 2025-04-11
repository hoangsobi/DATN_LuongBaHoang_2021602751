
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  urlBaiViet = 'https://localhost:7295/api/BaiViets';
  urlMaGiamGia = 'https://localhost:7295/api/Magiamgiums';
  urlDangNhap = 'https://localhost:7295/api/Accounts';
  urlDiaChi = 'https://localhost:7295/api/DiaChis';
  urlAccount_MaGiamGia = 'https://localhost:7295/api/accountMagiamgiums';
  urlSanPham = 'https://localhost:7295/api/sanphams';
  urlLoaiSanPham = 'https://localhost:7295/api/loaisanphams';
  urlSanPhamKichCo = 'https://localhost:7295/api/sanphamkichcoes';
  urlAnhSanPham = 'https://localhost:7295/api/anhsanphams';
  urlSanPhamGioHang = 'https://localhost:7295/api/sanphamgiohangs';
  urlGioHang = 'https://localhost:7295/api/giohangs'
  urlDonHang = 'https://localhost:7295/api/donhangs';
  urlSanPhamDonHang = 'https://localhost:7295/api/sanphamdonhangs';
  urlDanhGia = 'https://localhost:7295/api/danhgiums';
  urlAnhDanhGia = 'https://localhost:7295/api/anhdanhgiums';
  urlAccount = 'https://localhost:7295/api/Accounts';
  urlChatbox = 'https://localhost:7295/api/ChatBoxes';
  urlYeuThich = 'https://localhost:7295/api/YeuThiches';
  urlGopY = 'https://localhost:7295/api/gopies';
  urlNganHang = 'https://script.googleusercontent.com/macros/echo?user_content_key=KKOXq9WoXNQjrgip6gZklMO289nVsbFtAxfTPQcBLocKO5G4FkR8E4xZ9vOblohxonR3pKYOBzQL7QZq_D0gOXrkjdH8gguHm5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnE3Gn5h3gdOjQImlD03Ta2b-eJegv4hVZ8ICk7HExm88oPoTx5DtFvyS5I90xLDGdKhmu_ADNuU2HRjtSZcdGl3s5oHYTKmyIA&lib=MK3RoRVaPzSOwqCAUHf3RT0TUDqEcDcnD';
  constructor(
    private http: HttpClient,
  ) { }

  getAllBaiViet(): Observable<any>{
    return this.http.get(this.urlBaiViet, this.httpOptions);
  }

  getBaiVietByID(id: string): Promise<any>{
    return this.http.get(`${this.urlBaiViet}/${id}`, this.httpOptions).toPromise();
  }

  getMaGiamGiaConLai(idAccount: any): Observable<any>{
    return this.http.get(`${this.urlMaGiamGia}/getmagiamgiaconlai/${idAccount}`, this.httpOptions);
  }

  getAccountByAuth(tendangnhap: string, matkhau: string): Observable<any>{
    const encodedMatKhau = encodeURIComponent(matkhau);
    return this.http.get(`${this.urlDangNhap}/checkdangnhap?tendangnhap=${tendangnhap}&matkhau=${encodedMatKhau}`, this.httpOptions);
  }

  getDiaChiByIdUser(idAccount: string): Observable<any>
  {
    return this.http.get(`${this.urlDiaChi}/listdiachitheouser/${idAccount}`, this.httpOptions);
  }
  postDiaChiByUser(diaChi: any): Observable<any>
  {
    return this.http.post(this.urlDiaChi,diaChi,this.httpOptions);
  }
  deleteDiaChi(id: any): Observable<any>
  {
    return this.http.delete(`${this.urlDiaChi}/${id}`,this.httpOptions);
  }
  putUser(user: any): Observable<any>
  {
    return this.http.put(`${this.urlDangNhap}/${user.id}`,user, this.httpOptions);
  }
  getAccountById(id: any): Observable<any>
  {
    return this.http.get(`${this.urlDangNhap}/${id}`, this.httpOptions);
  }

  getMaGiamGiaByAccount(idAccount: any): Observable<any>
  {
    return this.http.get(`${this.urlAccount_MaGiamGia}/getmagiamgiabyaccount/${idAccount}`, this.httpOptions);
  }

  getMaGiamGiaDaLuu(idAccount: any): Observable<any>
  {
    return this.http.get(`${this.urlMaGiamGia}/getmagiamgiadaluu/${idAccount}`, this.httpOptions);
  }

  postAccountMaGiamGia(account_magiamgiaa: any): Observable<any>
  {
    return this.http.post(this.urlAccount_MaGiamGia, account_magiamgiaa, this.httpOptions);
  }

  getAllSanPham(): Observable<any>
  {
    return this.http.get(this.urlSanPham, this.httpOptions);
  }

  getSLSanPhamByDanhMuc(idDanhMuc: string): Observable<any>
  {
    return this.http.get(`${this.urlSanPham}/getallsanphambydanhmuc/${idDanhMuc}`, this.httpOptions);
  }

  getSanPhamByPage(page: number, idDanhMuc: string): Observable<any>
  {
    return this.http.get(`${this.urlSanPham}/getsanphambypage/${idDanhMuc}/${page}`, this.httpOptions);
  }

  getSanPhamById(id: string): Observable<any>
  {
    return this.http.get(`${this.urlSanPham}/${id}`, this.httpOptions);
  }

  getLoaiSanPhamById(id: string): Observable<any>
  {
    return this.http.get(`${this.urlLoaiSanPham}/${id}`, this.httpOptions);
  }

  getSanPhamByDanhMuc(idDanhMuc: string): Observable<any>
  {
    return this.http.get(`${this.urlSanPham}/getsanphambydanhmuc/${idDanhMuc}`, this.httpOptions);
  }

  getSanPhamKichCoBySanPham(idSanPham: string): Observable<any>
  {
    return this.http.get(`${this.urlSanPhamKichCo}/getkichcosanpham/${idSanPham}`, this.httpOptions);
  }

  getAnhSanPhamBySanPham(idSanPham: string): Observable<any>
  {
    return this.http.get(`${this.urlAnhSanPham}/getanhsanphambysanpham/${idSanPham}`, this.httpOptions);
  }

  postSanPhamGioHang(sanphamgiohang: any): Observable<any>
  {
    return this.http.post(this.urlSanPhamGioHang,sanphamgiohang,this.httpOptions);
  }

  getSanPhamInGioHang(idGioHang: any):  Observable<any>
  {
    return this.http.get(`${this.urlSanPhamGioHang}/getsanphamtronggiohang/${idGioHang}`,this.httpOptions);
  }

  postDonHang(body: any): Observable<any>
  {
    return this.http.post(this.urlDonHang, body, this.httpOptions);
  }

  postSanPhamDonHang(body: any): Observable<any>
  {
    return this.http.post(this.urlSanPhamDonHang, body, this.httpOptions);
  }

  xoaSanPhamTrongGio(idGioHang: any): Observable<any>
  {
    return this.http.delete(`${this.urlSanPhamGioHang}/xoasanphamtronggiohang/${idGioHang}`,this.httpOptions);
  }

  xoaAccountMaGiamGia(idMaGiamGia: any, idAccount: any): Observable<any>
  {
    return this.http.delete(`${this.urlAccount_MaGiamGia}/xoaaccountmagiamgia/${idAccount}/${idMaGiamGia}`,this.httpOptions);
  }

  getListDonHang(idAccount: any):  Observable<any>
  {
    return this.http.get(`${this.urlDonHang}/getlistdonhangbyaccountid/${idAccount}`, this.httpOptions);
  }

  getDonHangById(idDonHang: any):  Observable<any>
  {
    return this.http.get(`${this.urlDonHang}/${idDonHang}`, this.httpOptions);
  }

  getListSanPhamByIDDonHang(idDonHang: any, accountId: any):  Observable<any>
  {
    return this.http.get(`${this.urlSanPhamDonHang}/getlistsanphambyiddonhang/${idDonHang}/${accountId}`, this.httpOptions);
  }

  huyDonHangById(idDonHang: any, don: any): Promise<any>
  {
    return this.http.put(`${this.urlDonHang}/huyDonHang/${idDonHang}`, don, this.httpOptions).toPromise();
  }

  suaSanPhamTrongDonHang(idSanPham: any, idDonHang: any, kichCo: any, mau: any): Promise<any>
  {
    return this.http.put(`${this.urlSanPhamDonHang}/suasanphamdonhang/${idSanPham}/${idDonHang}/${kichCo}/${mau}`,this.httpOptions).toPromise();
  }

  xoaMotSanPhamTrongGio(idGioHang: any, idSanPham: any, kichCo: any, mau: any): Observable<any>
  {
    return this.http.delete(`${this.urlSanPhamGioHang}/xoamotsanphamtronggiohang/${idGioHang}/${idSanPham}/${kichCo}/${mau}`,this.httpOptions);
  }

  postDanhGia(body: any): Observable<any>
  {
    return this.http.post(this.urlDanhGia, body, this.httpOptions);
  }

  postAnh(body: any): Observable<any>
  {
    return this.http.post(this.urlAnhDanhGia, body, this.httpOptions);
  }

  getDanhGiaVeSanPhamByAccount(sanPhamId: any, accountId: any): Observable<any>
  {
    return this.http.get(`${this.urlDanhGia}/getdanhgiavesanphambyaccount/${sanPhamId}/${accountId}`, this.httpOptions);
  }

  getListDanhGiaByIdSanPham(sanPhamId: any): Observable<any>
  {
    return this.http.get(`${this.urlDanhGia}/getlistdanhgiabyidsanpham/${sanPhamId}`, this.httpOptions);
  }

  getSanPhamMoiVe(soSanPham: any): Observable<any>
  {
    return this.http.get(`${this.urlSanPham}/getsanphammoive/${soSanPham}`, this.httpOptions);
  }

  getSanPhamNhieuLuotMua(): Observable<any>
  {
    return this.http.get(`${this.urlSanPham}/getsanphamnhieuluotmua`, this.httpOptions);
  }

  guiEmailConfirm(emailNguoiDung: any, randomNumberString: any): Observable<any>
  {
    return this.http.get(`${this.urlAccount}/guiemail/${emailNguoiDung}/${randomNumberString}`);
  }

  postAccount(body: any): Observable<any>{
    return this.http.post(this.urlAccount, body, this.httpOptions);
  }

  checkUsername(username: any): Observable<any>{
    return this.http.get(`${this.urlAccount}/checkusername/${username}`, this.httpOptions);
  }

  getChatBoxFromUser(idAccount: any): Observable<any>{
    return this.http.get(`${this.urlChatbox}/${idAccount}`, this.httpOptions);
  }

  postMessage(body: any): Observable<any>
  {
    return this.http.post(this.urlChatbox, body, this.httpOptions);
  }

  getListUserForAdminSupport(): Observable<any>{
    return this.http.get(`${this.urlAccount}/getlistuserforadminsupport`, this.httpOptions);
  }

  postYeuThich(body: any): Observable<any>
  {
    return this.http.post(this.urlYeuThich,body,this.httpOptions);
  }

  checkYeuThich(sanPhamId: any, accountId: any): Promise<any>
  {
    return this.http.get(`${this.urlYeuThich}/checkYeuThich/${sanPhamId}/${accountId}`,this.httpOptions).toPromise();
  }

  deleteYeuThich(sanPhamId: any, accountId: any): Observable<any>
  {
    return this.http.delete(`${this.urlYeuThich}/xoaSanPhamYeuThich/${sanPhamId}/${accountId}`,this.httpOptions);
  }

  getAllSanPhamYeuThich(accountId: any): Observable<any>{
    return this.http.get(`${this.urlYeuThich}/getallsanphamyeuthich/${accountId}`, this.httpOptions);
  }

  getSanPhamBySearchKey(searchKey: any): Observable<any>{
    return this.http.get(`${this.urlSanPham}/getsanphambysearchkey/${searchKey}`, this.httpOptions);
  }

  getLoaiSanPham(): Observable<any>{
    return this.http.get(`${this.urlLoaiSanPham}/getAllLoaiSanPhamAll`, this.httpOptions);
  }

  getSoLuongTrongGio(idAccount: any): Observable<any>{
    return this.http.get(`${this.urlGioHang}/getslsptronggiobyidaccount/${idAccount}`, this.httpOptions);
  }

  getThanhToan(): Observable<any>{
    return this.http.get(this.urlNganHang);
  }

  postGopY(body: any): Observable<any>
  {
    return this.http.post(this.urlGopY, body, this.httpOptions);
  }
}
