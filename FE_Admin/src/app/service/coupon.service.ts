import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CouponService {

  httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    url = 'https://localhost:7295/api/magiamgiums';
    constructor(
      private http: HttpClient,
    ) { }

    getAllMaGiamGia(): Observable<any>{
      return this.http.get(this.url, this.httpOptions);
    }

    putMaGiamGia(cateId: any, body: any): Observable<any>{
      return this.http.put(`${this.url}/${cateId}`, body, this.httpOptions);
    }

    postMaGiamGia(body: any): Observable<any>{
      return this.http.post(this.url, body, this.httpOptions);
    }

    deleteMaGiamGia(mggId: any): Observable<any>{
      return this.http.delete(`${this.url}/${mggId}`, this.httpOptions);
    }

    getMaGiamGiaById(mggId: any): Observable<any>{
      return this.http.get(`${this.url}/${mggId}`, this.httpOptions);
    }
}
