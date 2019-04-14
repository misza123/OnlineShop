import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BasketComponent } from './basket/basket.component';
import { MessagesComponent } from './messages/messages.component';
import { ProductListComponent } from './products/components/product-list/product-list.component';
import { ProductDetailsComponent } from './products/components/product-details/product-details.component';
import { ProductCardComponent } from './products/components/product-list/product-card/product-card.component';
import { OrderListComponent } from './orders/components/order-list/order-list.component';
import { OrderDetailsComponent } from './orders/components/order-details/order-details.component';
import { OrderCardComponent } from './orders/components/order-list/order-card/order-card.component';

import { AuthService } from './_services/Auth/Auth.service';
import { ErrorInterceptorProvider } from './_services/Interceptors/error.interceptor';
import { AlertifyService } from './_services/Alertify/AlertifyService.service';
import { AuthGuard } from './_guards/auth.guard';
import { ProductService } from './_services/Products/Product.service';
import { OrderService } from './_services/Orders/Order.service';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ProductDetailsComponent,
      ProductListComponent,
      ProductCardComponent,
      OrderDetailsComponent,
      OrderCardComponent,
      OrderListComponent,
      BasketComponent,
      MessagesComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      BsDropdownModule.forRoot()
   ],
   providers: [
      AlertifyService,
      ErrorInterceptorProvider,
      AuthService,
      AuthGuard,
      ProductService,
      OrderService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
