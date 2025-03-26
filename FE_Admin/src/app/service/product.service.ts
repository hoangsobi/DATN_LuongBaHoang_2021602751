import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

   httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  url = 'https://localhost:7295/api/sanphams';
  urlspkc = 'https://localhost:7295/api/sanphamkichcoes';
  constructor(
    private http: HttpClient,
  ) { }

  getAllDonHang(): Observable<any>{
    return this.http.get(this.url, this.httpOptions);
  }

  postSanPham(body: any): Observable<any>{
    return this.http.post(`${this.url}`, body, this.httpOptions);
  }

  postSanPhamMul( body: any): Observable<any>{
    return this.http.post(`${this.url}/AddMultiple`, body, this.httpOptions);
  }

  deleteSanPham(productId: any): Observable<any>{
    return this.http.delete(`${this.url}/${productId}`, this.httpOptions);
  }

  getProductById(productId: any): Observable<any>{
    return this.http.get(`${this.url}/${productId}`, this.httpOptions);
  }

  putSanPham(productId: any, body: any): Observable<any>{
    return this.http.put(`${this.url}/${productId}`, body, this.httpOptions);
  }

  updateSoLuong(sanPhamId: any, body: any): Observable<any>{
    return this.http.post(`${this.urlspkc}/updateSoLuong/${sanPhamId}`, body, this.httpOptions);
  }

  getSoLuong(sanPhamId: any): Observable<any>{
    return this.http.get(`${this.urlspkc}/getSoLuong/${sanPhamId}`, this.httpOptions);
  }


}
