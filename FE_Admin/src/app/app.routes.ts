import { Routes } from '@angular/router';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { UserComponent } from './component/user/user.component';
import { UserAdminComponent } from './component/user-admin/user-admin.component';
import { CategoryComponent } from './component/category/category.component';
import { OrderComponent } from './component/order/order.component';
import { ProductComponent } from './component/product/product.component';

export const routes: Routes = [
  { path: '', component: DashboardComponent, title:'Dashboard' },
  { path: 'dashboard', component: DashboardComponent, title:'Dashboard' },
  { path: 'user', component: UserComponent, title:'User' },
  { path: 'user-admin', component: UserAdminComponent, title:'Admin' },
  { path: 'category', component: CategoryComponent, title:'Category' },
  { path: 'order', component: OrderComponent, title:'Order' },
  { path: 'product', component: ProductComponent, title:'Product' },
];
