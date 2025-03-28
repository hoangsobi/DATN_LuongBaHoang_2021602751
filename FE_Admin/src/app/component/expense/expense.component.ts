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
import { ExpenseService } from '../../service/expense.service';

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
  selector: 'app-expense',
  standalone: true,
  imports: [
    ButtonModule,
    TableModule,
    InputNumberModule,
    FormsModule,
    HttpClientModule,
    DialogModule,
    ToastModule,

    ConfirmDialogModule,
    InputTextModule,
    CommonModule,
    CalendarModule,
    RouterModule,
    PaginatorModule,
    DropdownModule,
    FormatVndPipe,
],
providers:[
    ExpenseService,
    MessageService,
    ConfirmationService,
],
  templateUrl: './expense.component.html',
  styleUrl: './expense.component.css'
})
export class ExpenseComponent {

  listChiPhi = [];
  showForm = false;
  action = 0; //0: them, 1: sua, 2: xem
  curId: any;
  body = {
    tenChiPhi: '',
    mucDich: '',
    soTien: 0,
    ngayTao: new Date(),
    ngayChi: null as string | null,
    accountId: '',
  }


  constructor(
    private _expenseService: ExpenseService,
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
      tenChiPhi: '',
      mucDich: '',
      soTien: 0,
      ngayTao: new Date(),
      ngayChi: null as string | null,
      accountId: '',
    }
  }

  getAll(){
    this._expenseService.getAllChiPhi().subscribe(data => {
      this.listChiPhi = data;
    })
  }

  showChiphi(chiphiId: any){
    this.action = 2;
    this.showForm = true;
    this.curId = chiphiId;
    this._expenseService.getChiPhiById(chiphiId).subscribe(data => {
      this.body = data;
    })
  }

  showSua(chiphiId: any){
    this.action = 1;
    this.showForm = true;
    this.curId = chiphiId;
    this._expenseService.getChiPhiById(chiphiId).subscribe(data => {
      this.body = data;
    })
  }

  showAdd(){
    this.action = 0;
    this.resetBody();
    this.showForm = true;
  }


  addChiphi(){
    this.body.ngayChi = null;
    this.body.accountId = '725d0b9b-3975-4d18-8e10-02cd7172cd25';
    this._expenseService.postChiPhi(this.body).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thêm chi phí thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  saveChiphi(){
    this._expenseService.putChiPhi(this.curId, this.body).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Sửa chi phí thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  deleteChiphi(chiphiId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận xóa chi phí này?',
      accept: async () => {
        this._expenseService.deleteChiPhi(chiphiId).subscribe(data => {
          if(data.status == "success")
          {
            this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Xóa chi phí thành công'});
            this.getAll();
          }
          else
          {
            this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Xóa chi phí không thành công'});
          }
        })
      }
    });
  }

  thanhToan(chiphiId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận thanh toán chi phí này?',
      accept: async () => {
        this._expenseService.thanhToanChiPhi(chiphiId).subscribe(data => {
          this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thanh toán chi phí thành công'});
          this.getAll();
        })
      }
    });
  }
}
