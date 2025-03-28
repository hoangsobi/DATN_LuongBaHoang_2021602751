import { Component, Pipe, PipeTransform } from '@angular/core';
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
import { OrderService } from '../../service/order.service';
import { PhuongThucVanChuyen, TrangThaiDonHang } from '../../Enums/Enums';


@Pipe({ standalone: true, name: 'formatVnd' })
export class FormatVndPipe implements PipeTransform {
  transform(value: any): string {
    const soTien: number = parseFloat(value);

    // Kiểm tra nếu giá trị là NaN hoặc không phải số
    if (isNaN(soTien)) {
      // Trả về giá trị không thay đổi nếu không phải số
      return value;
    }

    // Định dạng số tiền trong đơn vị VND
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(soTien);
  }
}

@Component({
  selector: 'app-order',
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
      FormatVndPipe
  ],
  providers:[
      OrderService,
      MessageService,
      ConfirmationService,
  ],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {

  TrangThaiDonHang = TrangThaiDonHang;
  PhuongThucVanChuyen = PhuongThucVanChuyen;
  listDanhMuc = [];
  showForm = false;
  action = 0; //0: them, 1: sua, 2: xem
  curId: any;
  listOrderProduct: any;
  curOrder = {
    id: '',
    ngayTao: new Date(),
    phuongThucVanChuyen: '',
    trangThai: '',
    maGiamGia: '',
    luongGiam: 0,
    soDienThoai: '',
    tenHienThi: '',
    diaChi: '',
    phuongThucThanhToan: '',
    ghiChu: '',
    thanhTien: 0,
    maGiamGiaId: '',
  };


  constructor(
    private _orderService: OrderService,
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
    this.curOrder = {
      id: '',
      ngayTao: new Date(),
      phuongThucVanChuyen: '',
      trangThai: '',
      maGiamGia: '',
      luongGiam: 0,
      soDienThoai: '',
      tenHienThi: '',
      diaChi: '',
      phuongThucThanhToan: '',
      ghiChu: '',
      thanhTien: 0,
      maGiamGiaId: '',
    };
  }

  getAll(){
    this._orderService.getAllDonHang().subscribe(data => {
      this.listDanhMuc = data;
    })
  }

  showOrder(orderId: any){
    this.showForm = true;
    this._orderService.getDHById(orderId).subscribe(data => {
      this.curOrder = data;
      if(!this.curOrder.maGiamGiaId)
        this.curOrder.luongGiam = 0;
      this._orderService.getListSanPhamByIDDonHang(orderId).subscribe(data => {
        this.listOrderProduct = data;
    })
  })
  }


  changeStatusOrder(action: any, orderId: any, status: any){
    if(status == TrangThaiDonHang.DangChuanBiHang && action == 1)
    {
      this.confirmationService.confirm({
        message: 'Bạn có chắc chắn muốn chuyển trạng thái đơn hàng?',
        accept: () => {
          this._orderService.changeStatusOrder(action, orderId, status).subscribe(data => {
            if(data.status == "success")
            {
              this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thay đổi trạng thái đơn hàng thành công'});
              this.getAll();
            }
            else
            {
              this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'Thay đổi trạng thái đơn hàng thất bại'});
            }
          })
        }
      })
    }
    else
    {
      this._orderService.changeStatusOrder(action, orderId, status).subscribe(data => {
        if(data.status == "success")
        {
          this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thay đổi trạng thái đơn hàng thành công'});
          this.getAll();
        }
        else
        {
          this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'Thay đổi trạng thái đơn hàng thất bại'});
        }
      })
    }
  }


  huyDonHang(orderId: any){
    this._orderService.huyDonHang(orderId).subscribe(data => {
      if(data.status == "success")
      {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Hủy đơn hàng thành công'});
        this.getAll();
      }
      else
      {
        this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'Hủy đơn hàng thất bại'});
      }
    })
  }
}
