import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';

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
import { ProfileEditComponent } from './users/profile-edit/profile-edit.component';
import { AddressEditComponent } from './users/address-edit/address-edit.component';
import { AddressDetailsComponent } from './users/address-details/address-details.component';
import { ProfileDetailsComponent } from './users/profile-details/profile-details.component';

import { AuthService } from './_services/Auth/Auth.service';
import { ErrorInterceptorProvider } from './_services/Interceptors/error.interceptor';
import { AlertifyService } from './_services/Alertify/AlertifyService.service';
import { AuthGuard } from './_guards/auth.guard';
import { ProductService } from './_services/Products/Product.service';
import { OrderService } from './_services/Orders/Order.service';
import { ProductDetailsResolver } from './products/_resolvers/product-details-resolver';
import { ProductListResolver } from './products/_resolvers/product-list-resolver';
import { UserService } from './users/user.service';
import { UserProfileDetailsResolver } from './users/user-profile-details-resolver';
import { PreventUnsavedChanges } from './users/_guards/prevent-unsaved-changes.guard';

export function tokenGetter() {
   return localStorage.getItem('token');
}

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
      MessagesComponent,
      ProfileEditComponent,
      ProfileDetailsComponent,
      AddressEditComponent,
      AddressDetailsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      AppRoutingModule,
      NgxGalleryModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AlertifyService,
      ErrorInterceptorProvider,
      AuthService,
      AuthGuard,
      ProductService,
      OrderService,
      ProductDetailsResolver,
      ProductListResolver,
      UserService,
      UserProfileDetailsResolver,
      PreventUnsavedChanges
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
