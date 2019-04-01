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


@NgModule({
   declarations: [
      AppComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      BsDropdownModule.forRoot(),
   ],
   providers: [
      AlertifyService,
      ErrorInterceptorProvider,
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
