import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { ApiService } from '../api.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [
    ButtonModule,
    FormsModule,
    RouterModule,
    ToastModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [
    MessageService,
    ApiService
  ],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {

  body = {
    hoTen: '',
    email: '',
    soDienThoai: '',
    tieuDe: '',
    noiDung: '',
  }
  constructor(
    private messageService: MessageService,
    private _apiService: ApiService
  ) { }

  resetBody(){
    this.body = {
      hoTen: '',
      email: '',
      soDienThoai: '',
      tieuDe: '',
      noiDung: '',
    }
  }

  addContact() {
    if (!this.body.hoTen || !this.body.email || !this.body.soDienThoai || !this.body.tieuDe || !this.body.noiDung) {
      this.messageService.add({ severity: 'error', summary: 'Thất bại', detail: 'Vui lòng điền đầy đủ thông tin!' });
      return;
    }
    this._apiService.postGopY(this.body).subscribe(data =>{
      this.messageService.add({ severity: 'success', summary: 'Thành công', detail: 'Gửi thông tin thành công!' });
      this.resetBody();
    })
  }
}
