import { Component } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { PaginatorModule } from 'primeng/paginator';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { UserService } from '../../service/user.service';
import { CalendarModule } from 'primeng/calendar';
import { Dropdown, DropdownModule } from 'primeng/dropdown';


@Component({
  selector: 'app-user-admin',
  standalone: true,
  imports: [
        ButtonModule,
        TableModule,
        FormsModule,
        HttpClientModule,
        DialogModule,
        ToastModule,
        ConfirmDialogModule,
        InputTextModule,
        InputNumberModule,
        CommonModule,
        CalendarModule,
        RouterModule,
        PaginatorModule,
        DropdownModule,
  ],
  providers:[
    UserService,
    MessageService,
    ConfirmationService,
  ],
  templateUrl: './user-admin.component.html',
  styleUrl: './user-admin.component.css'
})
export class UserAdminComponent {
  showForm = false;
  isAdd = false;
  stateOptions = [
    { label: 'Nam', value: true },
    { label: 'Nữ', value: false }
  ];
  RoleOptions = [];
  listUser = [];
  body = {
    tenHienThi: '',
    tenDangNhap: '',
    vaiTroId: '',
    matKhau: '',
    duongDanAnh: '',
    gioiTinh: false,
    diaChis: [
      {
        ghiChu: '',
        huyen: '',
        tinh: '',
        xa: '',
      }
    ],
    email: '',
    soDienThoai: '',
    ngaySinh: new Date()
  }
  curUserId: any;

  constructor(
    private _userService: UserService,
    private _messageService: MessageService,
    private confirmationService: ConfirmationService,
  )
  {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getAll();
  }

  getAll(){
    this._userService.getAllUserAdmin().subscribe(data => {
      this.listUser = data;
    })
  }

  resetBody(){
    this.body = {
      tenHienThi: '',
      vaiTroId: '',
      tenDangNhap: '',
      duongDanAnh: 'https://www.maxim.com/cdn-cgi/image/width=3966,height=2974,fit=crop,quality=80,format=auto,onerror=redirect,metadata=none/wp-content/uploads/2023/09/Lamborghini-Urus-Performante-1.jpeg',
      matKhau: '',
      gioiTinh: false,
      diaChis: [
        {
          ghiChu: '',
          huyen: '',
          tinh: '',
          xa: '',
        }
      ],
      email: '',
      soDienThoai: '',
      ngaySinh: new Date()
    }
  }

  showUser(userId: any){
    this.showForm = true;
    this.isAdd = false;
    this.curUserId = userId;
    this._userService.getUserById(userId).subscribe(data => {
      this.body = data;
      this.body.ngaySinh = new Date(data.ngaySinh);
    })
    this._userService.getAllRole().subscribe(data => {
      this.RoleOptions = data;
    })
  }

  lockAccount(userId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận khóa tài khoản này?',
      accept: async () => {
        this._userService.lockUser(userId).subscribe(data => {

              this._messageService.add({severity:'success', summary: 'Thông báo', detail: 'Khóa tài khoản thành công', life: 3000});
              this.getAll();
        })
      }
    });
  }

  unlockAccount(userId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận mở khóa tài khoản này?',
      accept: async () => {
        this._userService.unlockUser(userId).subscribe(data => {

              this._messageService.add({severity:'success', summary: 'Thông báo', detail: 'Mở khóa tài khoản thành công', life: 3000});
              this.getAll();
        })
      }
    });
  }

  showThemMoi(){
    this.showForm = true;
    this._userService.getAllRole().subscribe(data => {
      this.RoleOptions = data;
    })
    this.resetBody();
    this.isAdd = true;
  }

  addUser(){
    let newBody = {
      tenHienThi: this.body.tenHienThi,
      tenDangNhap: this.body.tenDangNhap,
      matKhau: this.body.matKhau,
      gioiTinh: this.body.gioiTinh,
      email: this.body.email,
      soDienThoai: this.body.soDienThoai,
      vaiTroId: this.body.vaiTroId,
      ngaySinh: this.body.ngaySinh.toISOString().split('T')[0],
      duongDanAnh: 'https://www.maxim.com/cdn-cgi/image/width=3966,height=2974,fit=crop,quality=80,format=auto,onerror=redirect,metadata=none/wp-content/uploads/2023/09/Lamborghini-Urus-Performante-1.jpeg'
    }

    this._userService.postUser(newBody).subscribe(data => {
      this._messageService.add({severity:'success', summary: 'Thông báo', detail: 'Thêm mới admin thành công', life: 3000});
      this.getAll();
      this.showForm = false;
    })
  }

  saveUser(){
    let newBody = {
      id: this.curUserId,
      tenHienThi: this.body.tenHienThi,
      tenDangNhap: this.body.tenDangNhap,
      matKhau: this.body.matKhau,
      gioiTinh: this.body.gioiTinh,
      email: this.body.email,
      soDienThoai: this.body.soDienThoai,
      ngaySinh: this.body.ngaySinh.toISOString().split('T')[0],
      duongDanAnh: this.body.duongDanAnh,
      vaiTroId: this.body.vaiTroId
    }

    this._userService.saveUser(newBody).subscribe(data => {
      this._messageService.add({severity:'success', summary: 'Thông báo', detail: 'Sửa thông tin thành công', life: 3000});
      this.getAll();
      this.showForm = false;
    })
  }

}
