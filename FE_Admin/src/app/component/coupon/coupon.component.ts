
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
import { CouponService } from '../../service/coupon.service';

@Component({
  selector: 'app-coupon',
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
      CouponService,
      MessageService,
      ConfirmationService,
  ],
  templateUrl: './coupon.component.html',
  styleUrl: './coupon.component.css'
})
export class CouponComponent {

  listMaGiamGia = [];
    allMGG: any;
    totalRecords = 0;
    showForm = false;
    action = 0; //0: them, 1: sua, 2: xem
    curId: any;
    body = {
      ma: '',
      soLuong: 0,
      luongGiam: 0,
      ngayHetHan: new Date(),
      ngayTao: new Date(),
      moTa: ''
    }


    constructor(
      private _couponService: CouponService,
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
        ma: '',
        soLuong: 0,
        luongGiam: 0,
        ngayHetHan: new Date(),
        ngayTao: new Date(),
        moTa: ''
      }
    }

    getAll(){
      this._couponService.getAllMaGiamGia().subscribe(data => {
        this.listMaGiamGia = data.slice(0, 10);
        this.allMGG = data;
        this.totalRecords = data.length;
      })
    }

    showCate(cateId: any){
      this.action = 2;
      this.showForm = true;
      this.curId = cateId;
      this._couponService.getMaGiamGiaById(cateId).subscribe(data => {
        this.body = data;
        this.body.ngayTao = new Date(data.ngayTao);
        this.body.ngayHetHan = new Date(data.ngayHetHan);
      })
    }

    showSua(cateId: any){
      this.action = 1;
      this.showForm = true;
      this.curId = cateId;
      this._couponService.getMaGiamGiaById(cateId).subscribe(data => {
        this.body = data;
        this.body.ngayTao = new Date(data.ngayTao);
        this.body.ngayHetHan = new Date(data.ngayHetHan);
      })
    }

    showAdd(){
      this.action = 0;
      this.resetBody();
      this.showForm = true;
    }


    addCate(){
      let newBody = {
        ma: this.body.ma,
        soLuong: this.body.soLuong,
        luongGiam: this.body.luongGiam,
        ngayTao: new Date(),
        moTa: this.body.moTa,
        ngayHetHan: this.body.ngayHetHan.toISOString().split('T')[0]
      }
      if(this.checkrq())
      {
        this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Vui lòng nhập đầy đủ thông tin'});
        return;
      }
      this._couponService.postMaGiamGia(newBody).subscribe(data => {
          this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thêm mã giảm giá thành công'});
          this.showForm = false;
          this.getAll();
      })
    }

    saveCate(){
      if(this.checkrq())
      {
        this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Tên mã giảm giá không được để trống'});
        return;
      }
      this._couponService.putMaGiamGia(this.curId, this.body).subscribe(data => {
          this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Sửa mã giảm giá thành công'});
          this.showForm = false;
          this.getAll();
      })
    }

    deleteCate(cateId: any){
      this.confirmationService.confirm({
        message: 'Xác nhận xóa mã giảm giá này?',
        accept: async () => {
          this._couponService.deleteMaGiamGia(cateId).subscribe(data => {
            if(data.status == "success")
            {
              this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Xóa mã giảm giá thành công'});
              this.getAll();
            }
            else
            {
              this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'mã giảm giá này đang được sử dụng'});
            }
          })
        }
      });
    }

    checkrq(){
      if(!this.body.ma || ! this.body.luongGiam || !this.body.ngayHetHan || !this.body.soLuong){
        return true;
      }
      return false;
    }


    onPageChange(event: any)
    {
      this.listMaGiamGia = this.allMGG.slice(event.page * 10, event.page * 10 + 10);
    }
}
