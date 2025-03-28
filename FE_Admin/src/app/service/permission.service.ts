import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    url = 'https://localhost:7295/api/VaiTros';
    constructor(
      private http: HttpClient,
    ) { }

    getAllVaiTro(): Observable<any>{
      return this.http.get(this.url, this.httpOptions);
    }

    getQuyenByVaiTroId(vaitroId: any): Observable<any>{
      return this.http.get(`${this.url}/getQuyenByVaiTroId/${vaitroId}`, this.httpOptions);
    }

    getListQuyen(): Observable<any>{
      return this.http.get(`${this.url}/getListQuyen`, this.httpOptions);
    }

    updatePermissionRole(roleId: any, body: any): Observable<any>{
      return this.http.put(`${this.url}/updatePermissionRole/${roleId}`, body, this.httpOptions);
    }
}
