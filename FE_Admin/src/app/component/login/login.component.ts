import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { ToastModule } from 'primeng/toast';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterModule,
    FormsModule,
    ToastModule,
    HttpClientModule,
  ],
  providers: [
    AuthService,
    ConfirmationService,
    MessageService
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  body = {
    tenDangNhap: '',
    matKhau: ''
  }
  constructor(
    private _authService: AuthService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService
  ) { }

  ngOnInit() {
  }

  login() {
    if(!this.body.tenDangNhap || !this.body.matKhau) {
      this._messageService.add({severity:'error', summary:'Thông báo', detail:'Vui lòng nhập đầy đủ thông tin'});
      return;
    }
    this._authService.login(this.body).subscribe(res => {
      if(res.status == "wrong"){
        this._messageService.add({severity:'error', summary:'Thông báo', detail:'Sai tên đăng nhập hoặc mật khẩu'});
        return;
      }
      else if (res.status == "success"){
        this._messageService.add({severity:'success', summary:'Thông báo', detail:'Đăng nhập thành công'});
        localStorage.setItem('token', res.token);
        setTimeout(() => {
                  window.location.href = '/dashboard';
        }, 2000);

      }

      else {
        this._messageService.add({severity:'error', summary:'Thông báo', detail:'Đăng nhập thất bại'});
      }
    });
  }
}
