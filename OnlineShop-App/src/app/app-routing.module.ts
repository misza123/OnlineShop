import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { BasketComponent } from './basket/basket.component';
import { MessagesComponent } from './messages/messages.component';
import { ProductListComponent } from './products/components/product-list/product-list.component';
import { OrderListComponent } from './orders/components/order-list/order-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'basket', component: BasketComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          { path: 'orders', component: OrderListComponent },
          { path: 'messages', component: MessagesComponent },
      ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
