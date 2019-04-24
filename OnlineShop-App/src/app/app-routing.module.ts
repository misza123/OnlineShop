import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { BasketComponent } from './basket/basket.component';
import { MessagesComponent } from './messages/messages.component';
import { ProductListComponent } from './products/components/product-list/product-list.component';
import { OrderListComponent } from './orders/components/order-list/order-list.component';
import { ProductDetailsComponent } from './products/components/product-details/product-details.component';
import { ProductDetailsResolver } from './products/_resolvers/product-details-resolver';
import { ProductListResolver } from './products/_resolvers/product-list-resolver';
import { ProfileDetailsComponent } from './users/profile-details/profile-details.component';
import { UserProfileDetailsResolver } from './users/user-profile-details-resolver';
import { ProfileEditComponent } from './users/profile-edit/profile-edit.component';
import { PreventUnsavedChanges } from './users/_guards/prevent-unsaved-changes.guard';
import { ProductEditComponent } from './products/components/product-edit/product-edit.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'products', component: ProductListComponent, resolve: { products: ProductListResolver } },
  { path: 'products/:id', component: ProductDetailsComponent, resolve: { product: ProductDetailsResolver } },
  { path: 'products/:id/edit', component: ProductEditComponent, resolve: { product: ProductDetailsResolver } },
  { path: 'basket', component: BasketComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'orders', component: OrderListComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'profile', component: ProfileDetailsComponent, resolve: { userProfile: UserProfileDetailsResolver } },
      {
        path: 'profile/edit', component: ProfileEditComponent,
        resolve: { userProfile: UserProfileDetailsResolver },
        canDeactivate: [PreventUnsavedChanges]
      },
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
