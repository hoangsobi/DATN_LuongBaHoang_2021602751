import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  url = 'https://localhost:7295/api/dashboards';
  constructor(
    private http: HttpClient,
  ) { }

  getHeaderThongKe(): Observable<any>{
    return this.http.get(`${this.url}/getThongKeHead`, this.httpOptions);
  }

  getThongKeDoanhThuChiPhi(): Observable<any>{
    return this.http.get(`${this.url}/getThongKeDoanhThuChiPhi`, this.httpOptions);
  }

  getDoanhThuTheoThangTrongNam(): Observable<any>{
    return this.http.get(`${this.url}/getDoanhThuTheoThangTrongNam`, this.httpOptions);
  }

  getKhachThanThiet(): Observable<any>{
    return this.http.get(`${this.url}/getKhachThanThiet`, this.httpOptions);
  }

  getDonHangGanNhat(): Observable<any>{
    return this.http.get(`${this.url}/getDonHangGanNhat`, this.httpOptions);
  }
}
