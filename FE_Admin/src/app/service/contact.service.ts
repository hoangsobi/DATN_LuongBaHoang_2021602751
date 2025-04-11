import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

 httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  url = 'https://localhost:7295/api/gopies';
  constructor(
    private http: HttpClient,
  ) { }

  getAllContact(): Observable<any>{
    return this.http.get(this.url, this.httpOptions);
  }

  getContactById(id: any): Observable<any>{
    return this.http.get(`${this.url}/${id}`, this.httpOptions);
  }

  phanHoiContact(id: any, email:  any, body: any): Observable<any>{
    return this.http.put(`${this.url}/phanHoi/${id}/${email}`, body, this.httpOptions);
  }
}
