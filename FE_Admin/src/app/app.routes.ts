import { Routes } from '@angular/router';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { UserComponent } from './component/user/user.component';
import { UserAdminComponent } from './component/user-admin/user-admin.component';
import { CategoryComponent } from './component/category/category.component';
import { OrderComponent } from './component/order/order.component';
import { ProductComponent } from './component/product/product.component';
import { SubCategoryComponent } from './component/sub-category/sub-category.component';
import { ExpenseComponent } from './component/expense/expense.component';
import { LoginComponent } from './component/login/login.component';
import { AdminLayoutComponent } from './component/admin-layout/admin-layout.component';
import { AuthGuard } from './service/auth.guard';
import { PermissionComponent } from './component/permission/permission.component';
import { CouponComponent } from './component/coupon/coupon.component';
import { ContactComponent } from './component/contact/contact.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent, title: 'Login' },
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      { path: '', component: DashboardComponent, title:'Dashboard', canActivate: [AuthGuard] },
      { path: 'dashboard', component: DashboardComponent, title:'Dashboard', canActivate: [AuthGuard] },
      { path: 'user', component: UserComponent, title:'User', canActivate: [AuthGuard] },
      { path: 'user-admin', component: UserAdminComponent, title:'Admin', canActivate: [AuthGuard] },
      { path: 'category', component: CategoryComponent, title:'Category', canActivate: [AuthGuard] },
      { path: 'subCategory', component: SubCategoryComponent, title:'Sub-Category', canActivate: [AuthGuard] },
      { path: 'order', component: OrderComponent, title:'Order', canActivate: [AuthGuard] },
      { path: 'product', component: ProductComponent, title:'Product', canActivate: [AuthGuard] },
      { path: 'expense', component: ExpenseComponent, title:'Expense', canActivate: [AuthGuard] },
      { path: 'permission', component: PermissionComponent, title:'Permission', canActivate: [AuthGuard] },
      { path: 'coupon', component: CouponComponent, title:'Coupon', canActivate: [AuthGuard] },
      { path: 'contact', component: ContactComponent, title:'Contact', canActivate: [AuthGuard] },
    ]
  }
];
