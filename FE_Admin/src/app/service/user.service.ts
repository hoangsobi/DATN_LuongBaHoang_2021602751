import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  url = 'https://localhost:7295/api/accounts';
  constructor(
    private http: HttpClient,
  ) { }

  getAllUser(page: any): Observable<any>{
    return this.http.get(`${this.url}/page/${page}`, this.httpOptions);
  }

  getAllRole(): Observable<any>{
    return this.http.get(`${this.url}/getAllRole`, this.httpOptions);
  }

  getAllUserAdmin(): Observable<any>{
    return this.http.get(`${this.url}/getalluseradmin`, this.httpOptions);
  }

  getUserById(userId: any): Observable<any>{
    return this.http.get(`${this.url}/${userId}`, this.httpOptions);
  }

  lockUser(userId: any): Observable<any>{
    return this.http.get(`${this.url}/lockUser/${userId}`, this.httpOptions);
  }

  unlockUser(userId: any): Observable<any>{
    return this.http.get(`${this.url}/unlockUser/${userId}`, this.httpOptions);
  }
  postUser(body: any): Observable<any>{
    return this.http.post(this.url, body, this.httpOptions);
  }

  saveUser(body: any): Observable<any>{
    return this.http.put(`${this.url}/${body.id}`, body, this.httpOptions);
  }
}
