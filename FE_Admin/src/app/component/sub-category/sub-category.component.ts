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
  selector: 'app-sub-category',
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
  templateUrl: './sub-category.component.html',
  styleUrl: './sub-category.component.css'
})
export class SubCategoryComponent {
  listDanhMuc = [];
  allDM: any;
  totalrecords = 0;
  showForm = false;
  action = 0; //0: them, 1: sua, 2: xem
  curId: any;
  listCategoryCha: any;
  body = {
    tenLoai: '',
    loaiSanPhamChaId: '',
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
      loaiSanPhamChaId: '',
      moTa: ''
    }
  }

  getAll(){
    this._categoryService.getAllDanhMucCon().subscribe(data => {
      this.listDanhMuc = data.slice(0, 10);
      this.allDM = data;
      this.totalrecords = data.length;
    })
  }

  showCate(cateId: any){
    this.action = 2;
    this.showForm = true;
    this.curId = cateId;
    this._categoryService.getCateById(cateId).subscribe(data => {
      this.body = data;
    })
    this._categoryService.getAllDanhMuc().subscribe(data => {
      this.listCategoryCha = data;
    })
  }

  showSua(cateId: any){
    this.action = 1;
    this.showForm = true;
    this.curId = cateId;
    this._categoryService.getCateById(cateId).subscribe(data => {
      this.body = data;
    })
    this._categoryService.getAllDanhMuc().subscribe(data => {
      this.listCategoryCha = data;
    })
  }

  showAdd(){
    this.action = 0;
    this.resetBody();
    this._categoryService.getAllDanhMuc().subscribe(data => {
      this.listCategoryCha = data;
    })
    this.showForm = true;
  }


  addCate(){
    if(this.checkrq())
      {
        this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Vui lòng nhập đầy đủ thông tin'});
        return;
      }
    this._categoryService.postDanhMuc(this.body).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thêm danh mục thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  saveCate(){
    if(this.checkrq())
    {
      this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Vui lòng nhập đầy đủ thông tin'});
      return;
    }
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

  checkrq(){
    if(!this.body.tenLoai || !this.body.loaiSanPhamChaId) return true;
    return false;
  }


  onPageChange(event: any)
  {
    this.listDanhMuc = this.allDM.slice(event.page * 10, event.page * 10 + 10);
  }
}
