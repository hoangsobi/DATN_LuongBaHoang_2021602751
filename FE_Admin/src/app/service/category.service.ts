import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  url = 'https://localhost:7295/api/loaisanphams';
  constructor(
    private http: HttpClient,
  ) { }

  getAllDanhMuc(): Observable<any>{
    return this.http.get(this.url, this.httpOptions);
  }

  putDanhMuc(cateId: any, body: any): Observable<any>{
    return this.http.put(`${this.url}/${cateId}`, body, this.httpOptions);
  }

  postDanhMuc(body: any): Observable<any>{
    return this.http.post(this.url, body, this.httpOptions);
  }

  deleteDanhMuc(cateId: any): Observable<any>{
    return this.http.delete(`${this.url}/${cateId}`, this.httpOptions);
  }

  getCateById(cateId: any): Observable<any>{
    return this.http.get(`${this.url}/${cateId}`, this.httpOptions);
  }
}
