import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { AdminLayoutComponent } from "../admin-layout/admin-layout.component";
import { FormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { PermissionService } from '../../service/permission.service';
import { CommonModule } from '@angular/common';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-permission',
  standalone: true,
  imports: [
    AdminLayoutComponent,
    FormsModule,
    DropdownModule,
    HttpClientModule,
    CommonModule,
    CheckboxModule,
    ButtonModule,
    ToastModule
  ],
  providers: [
    PermissionService,
    MessageService
  ],
  templateUrl: './permission.component.html',
  styleUrl: './permission.component.css'
})
export class PermissionComponent {

  listRole: any;
  selectedRole: any;
  listPermission: any;
  listPermissionRole: any[] = [];

  constructor(
    private _permissionService: PermissionService,
    private messageService: MessageService,
  ) {
    this.getAllRole();
    this.getListQuyen();
  }

  ngOnInit() {

  }


  getAllRole() {
    this._permissionService.getAllVaiTro().subscribe((res: any) => {
      this.listRole = res;
    })
  }


  getListPermissionRole() {
    console.log(this.selectedRole);
    this._permissionService.getQuyenByVaiTroId(this.selectedRole).subscribe((res: any) => {
      this.listPermissionRole = res;
    })
  }

  isChecked(route: string): boolean {
    return this.listPermissionRole.some((p: any) => p.rout === route);
  }


  getListQuyen(){
    this._permissionService.getListQuyen().subscribe((res: any) => {
      this.listPermission = res;
    })
  }

  togglePermission(per: any) {
    const index = this.listPermissionRole.findIndex((p: any) => p.rout === per.rout);

    if (index > -1) {
      this.listPermissionRole.splice(index, 1); // Bỏ quyền nếu đã có
    } else {
      this.listPermissionRole.push({id: per.id, ten: per.ten, rout: per.rout }); // Thêm quyền nếu chưa có
    }
  }

  updatePermissionRole(){
    if(this.selectedRole == null){
      this.messageService.add({ severity: 'warn', summary: 'Cảnh báo', detail: 'Vui lòng chọn vai trò' });
      return;
    }

    // console.log(this.selectedRole);
    // console.log(this.listPermissionRole);
    this._permissionService.updatePermissionRole(this.selectedRole, this.listPermissionRole).subscribe((res: any) => {
      console.log(res);
      if(res.status == 'success')
        this.messageService.add({ severity: 'success', summary: 'Thành công', detail: 'Cập nhật quyền thành công' });
      else
        this.messageService.add({ severity: 'error', summary: 'Thất bại', detail: 'Cập nhật quyền thất bại' });
    });
  }


}
