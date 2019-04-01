import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { AuthService } from './_services/Auth/Auth.service';
import { ErrorInterceptorProvider } from './_services/Interceptors/error.interceptor';
import { AlertifyService } from './_services/Alertify/AlertifyService.service';
import { AuthGuard } from './_guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ProductsComponent,
      OrdersComponent
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
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
