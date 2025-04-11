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
import { ContactService } from '../../service/contact.service';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FloatLabelModule } from 'primeng/floatlabel';


@Component({
  selector: 'app-contact',
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
    InputTextareaModule,
    FloatLabelModule
  ],
  providers:[
      ContactService,
      MessageService,
      ConfirmationService,
  ],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {

  listDanhMuc = [];
  allDM: any;
  totalRecords = 0;
  showForm = false;
  curId: any;
  curEmail: any;
  body: any;
  status = 0; //0: chua phan hoi, 1: da phan hoi
  curContact = {
    tieuDe: '',
    noiDung: '',
  };


  constructor(
    private _contactService: ContactService,
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
    this.body = null;
  }

  getAll(){
    this._contactService.getAllContact().subscribe(data => {
      this.listDanhMuc = data.slice(0, 10);
      this.allDM = data;
      this.totalRecords = data.length;
    })
  }

  showCate(cateId: any, email: any){
    this.showForm = true;
    this.curId = cateId;
    this.curEmail = email;
    this._contactService.getContactById(cateId).subscribe(data => {
      this.curContact = data;
      if(data.phanHoi == '' || data.phanHoi == null)
      {
          this.body = null;
          this.status = 0;
      }
      else
      {
        this.body = data.phanHoi;
        this.status = 1;
      }
    })
  }

  saveCate(){
    if(this.checkrq())
    {
      this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Nội dung không được để trống!'});
      return;
    }
    var gridInfo = {
      phanHoi: this.body,
    }
    this._contactService.phanHoiContact(this.curId, this.curEmail, gridInfo).subscribe(data => {
      if(data.status == "success"){
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Phản hồi thành công!'});

      }
      else{
        this._messageService.add({severity:'error', summary: 'Thất bại', detail: 'Phản hồi thất bại!'});
      }
      this.body = null;
      this.showForm = false;
      this.getAll();
    })
  }

  checkrq(){
    if(!this.body){
      return true;
    }
    return false;
  }


  onPageChange(event: any)
  {
    this.listDanhMuc = this.allDM.slice(event.page * 10, event.page * 10 + 10);
  }
}
