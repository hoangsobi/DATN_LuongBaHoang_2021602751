import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:7295/api/accounts';
  private tokenKey = 'token';
  private userPermissions: string[] = [];

  constructor(private http: HttpClient, private router: Router) {}

  // Lưu token
  saveToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  // Lấy token
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  // Giải mã token để lấy user info
  getUser() {
    const token = this.getToken();
    if (token) {
      console.log(jwtDecode<any>(token))
      return jwtDecode<any>(token); // Giải mã token
    }
    return null;
  }

  // Kiểm tra role của user
  hasRole(requiredRole: string): boolean {
    const user = this.getUser();
    return user?.role === requiredRole;
  }

  // Xóa token khi logout
  logout() {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);
  }

  login(body: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, body);
  }













  setUserPermissions(permissions: string[]) {
    this.userPermissions = permissions;
  }

  // Kiểm tra người dùng có quyền cụ thể hay không
  hasPermission(permission: string): boolean {
    return this.userPermissions.includes(permission);
  }
}
