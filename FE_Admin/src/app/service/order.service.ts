import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
      url = 'https://localhost:7295/api/donhangs';
      constructor(
        private http: HttpClient,
      ) { }

      getAllDonHang(): Observable<any>{
        return this.http.get(this.url, this.httpOptions);
      }

      putDonHang(orderId: any, body: any): Observable<any>{
        return this.http.put(`${this.url}/${orderId}`, body, this.httpOptions);
      }

      // deleteDonHang(orderId: any): Observable<any>{
      //   return this.http.delete(`${this.url}/${orderId}`, this.httpOptions);
      // }

      getDHById(orderId: any): Observable<any>{
        return this.http.get(`${this.url}/${orderId}`, this.httpOptions);
      }

      getListSanPhamByIDDonHang(orderId: any): Observable<any>{
        return this.http.get(`${this.url}/getListSanPhamByIDDonHang/${orderId}`, this.httpOptions);
      }

      changeStatusOrder(action: any, orderId: any, status: any): Observable<any>{
        if(action == 0)
         return this.http.get(`${this.url}/changeStatusDown/${orderId}/${status}`, this.httpOptions);
        return this.http.get(`${this.url}/changeStatusUp/${orderId}/${status}`, this.httpOptions);
      }

      huyDonHang(orderId: any): Observable<any>{
        return this.http.get(`${this.url}/huyDon/${orderId}`, this.httpOptions);
      }
}
