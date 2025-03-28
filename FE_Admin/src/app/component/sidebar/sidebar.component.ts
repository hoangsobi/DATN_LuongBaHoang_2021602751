import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { RouterModule, RouterOutlet } from '@angular/router';
import { PaginatorModule } from 'primeng/paginator';
import { UserService } from '../../service/user.service';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-sidebar',
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
  ],
  providers:[
    UserService,
    MessageService,
    ConfirmationService,
    AuthService,
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  username: string | null = '';
  anhAccount: any;
  curRole: any;

  listFunc: any;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    const user = this.authService.getUser();
    this.username = user ? user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'][1] : null;
    this.anhAccount = user ? user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'][2] : null;
    this.curRole = user ? user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : null;
    this.listFunc = user ? (Array.isArray(user['Permissions']) ? user['Permissions'] : [user['Permissions']]).map((permission: any) => {
      const [ten, rout, iconClass, order] = permission.split(':');
      return { ten, rout, iconClass, order };
    }): [];

    console.log(this.listFunc);
  }

  logout() {
    this.authService.logout();
  }
}
