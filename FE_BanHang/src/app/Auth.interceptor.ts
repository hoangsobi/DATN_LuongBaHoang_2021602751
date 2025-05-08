// auth.interceptor.ts
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable, of, switchMap, throwError } from 'rxjs';
import { StorageMap } from '@ngx-pwa/local-storage';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { firstValueFrom, from } from 'rxjs';
import { error } from 'console';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  // constructor(
  //   private storage: StorageMap,
  //   private router: Router
  // ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // console.log('Interceptor:', req.url);
    // return from(this.checkAccountStatus()).pipe(
    //   switchMap((canProceed) => {
    //     if (!canProceed) {
    //       this.router.navigate(['/login']);
    //       return throwError(() => new Error('Tài khoản đã bị khóa'));
    //     }
    //     return next.handle(req);
    //   }),
    //   catchError((error) => {
    //     console.log('Lỗi Interceptor:', error);
    //     return throwError(() => error);
    //   })
    // );
    const tokenrq = req.clone({
      setHeaders: {
        Authorization: `Bearer 4645654`
      }
    });
    return next.handle(tokenrq);

  }

  // private async checkAccountStatus(): Promise<boolean> {
  //   try {
  //     console.log('Interceptor:' );
  //     const isDangNhap = await firstValueFrom(this.storage.get('isDangNhap'));
  //     const account: any = await firstValueFrom(this.storage.get('account'));
  //     if (isDangNhap === true && account?.Id) {
  //       const res = await fetch(`https://localhost:7295/api/accounts/isLocked/${account.Id}`);
  //       const isLocked = await res.json();
  //       if (isLocked === true) {
  //         await firstValueFrom(this.storage.delete('isDangNhap'));
  //         await firstValueFrom(this.storage.delete('account'));
  //         return false;
  //       }
  //     }
  //     return true;
  //   } catch (e) {
  //     console.error('checkAccountStatus lỗi:', e);
  //     return true; // Cho phép đi tiếp nếu lỗi (tránh chặn request không cần thiết)
  //   }
  // }
}
