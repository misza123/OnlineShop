import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { AuthService } from './_services/Auth/Auth.service';
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
      AppRoutingModule
   ],
   providers: [
      AlertifyService,
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
