import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    url = 'https://localhost:7295/api/chiphis';
    constructor(
      private http: HttpClient,
    ) { }

    getAllChiPhi(): Observable<any>{
      return this.http.get(this.url, this.httpOptions);
    }

    putChiPhi(chiphiId: any, body: any): Observable<any>{
      return this.http.put(`${this.url}/${chiphiId}`, body, this.httpOptions);
    }

    thanhToanChiPhi(chiphiId: any): Observable<any>{
      return this.http.get(`${this.url}/thanhToan/${chiphiId}`, this.httpOptions);
    }

    postChiPhi(body: any): Observable<any>{
      return this.http.post(this.url, body, this.httpOptions);
    }

    deleteChiPhi(chiphiId: any): Observable<any>{
      return this.http.delete(`${this.url}/${chiphiId}`, this.httpOptions);
    }

    getChiPhiById(chiphiId: any): Observable<any>{
      return this.http.get(`${this.url}/${chiphiId}`, this.httpOptions);
    }
}
