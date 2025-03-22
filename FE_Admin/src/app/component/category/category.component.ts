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
import { CategoryService } from '../../service/category.service';


@Component({
  selector: 'app-category',
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
    CategoryService,
    MessageService,
    ConfirmationService,
],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  listDanhMuc = [];
  showForm = false;
  action = 0; //0: them, 1: sua, 2: xem
  curId: any;
  body = {
    tenLoai: '',
    moTa: ''
  }


  constructor(
    private _categoryService: CategoryService,
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


  resetBody(){
    this.body = {
      tenLoai: '',
      moTa: ''
    }
  }

  getAll(){
    this._categoryService.getAllDanhMuc().subscribe(data => {
      this.listDanhMuc = data;
    })
  }

  showCate(cateId: any){
    this.action = 2;
    this.showForm = true;
    this.curId = cateId;
    this._categoryService.getCateById(cateId).subscribe(data => {
      this.body = data;
    })
  }

  showSua(cateId: any){
    this.action = 1;
    this.showForm = true;
    this.curId = cateId;
    this._categoryService.getCateById(cateId).subscribe(data => {
      this.body = data;
    })
  }

  showAdd(){
    this.action = 0;
    this.resetBody();
    this.showForm = true;
  }


  addCate(){
    this._categoryService.postDanhMuc(this.body).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thêm danh mục thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  saveCate(){
    this._categoryService.putDanhMuc(this.curId, this.body).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Sửa danh mục thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  deleteCate(cateId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận xóa danh mục này?',
      accept: async () => {
        this._categoryService.deleteDanhMuc(cateId).subscribe(data => {
          if(data.status == "success")
          {
            this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Xóa danh mục thành công'});
            this.getAll();
          }
          else
          {
            this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'Danh mục này đang được sử dụng'});
          }
        })
      }
    });
  }
}
