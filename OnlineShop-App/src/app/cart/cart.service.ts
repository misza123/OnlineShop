import { Injectable } from '@angular/core';
import { Product } from '../products/product';
import { CartElement } from './cart-element';
import { AlertifyService } from '../_services/Alertify/AlertifyService.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService{
  elementsCounter = new BehaviorSubject<number>(0);
  actualElementsCount = this.elementsCounter.asObservable();

  constructor(private alertify: AlertifyService) {
    this.setElementsCouter(this.getCart().length);
   }

  addToCart(product: Product) {
    let cart: CartElement[] = this.getCart();
    if (cart == null) {
      cart = new Array();
    }

    if (cart.some(x => x.product.id === product.id)) {
      cart.find(x => x.product.id === product.id).count++;
    } else {
      cart.push({ id: cart.length + 1, product, count: 1 });
    }

    localStorage.setItem('cart', JSON.stringify(cart));
    this.setElementsCouter(cart.length);
    this.alertify.success(product.name + ' successfully added to cart.');
  }

  getCart(): CartElement[] {
    return JSON.parse(localStorage.getItem('cart'));
  }

  setElementsCouter(count: number) {
    this.elementsCounter.next(count);
  }
}
