import { Injectable } from '@angular/core';
import { Product } from '../products/product';
import { CartElement } from './cart-element';
import { AlertifyService } from '../_services/Alertify/AlertifyService.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  elementsCounter = new BehaviorSubject<number>(0);
  actualElementsCount = this.elementsCounter.asObservable();

  constructor(private alertify: AlertifyService) {
    const cart = this.getCart();
    if (cart != null) {
      this.setElementsCouter(cart.length);
    }
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

    this.setCart(cart);
    this.alertify.success(product.name + ' successfully added to cart.');
  }

  getCart(): CartElement[] {
    return JSON.parse(localStorage.getItem('cart'));
  }

  private setCart(cartElements: CartElement[]) {
    localStorage.setItem('cart', JSON.stringify(cartElements));
    this.setElementsCouter(cartElements.length);
  }

  setElementsCouter(count: number) {
    this.elementsCounter.next(count);
  }

  clear() {
    // TODO add confirmation popup
    localStorage.removeItem('cart');
    this.setElementsCouter(0);
    this.alertify.success('Cart successfully cleared.');
  }

  removeProduct(cartElement: CartElement) {
    let cart: CartElement[] = this.getCart();
    cart.splice(cart.indexOf(cartElement), 1);
    this.setCart(cart);
    this.alertify.success(cartElement.product.name + ' successfully removed from cart.');
  }

  setCount(cartElement: CartElement, count: number) {
    let cart: CartElement[] = this.getCart();

    if (cart.some(x => x.id === cartElement.id)) {
      cart.find(x => x.id === cartElement.id).count = count;
    }
    if (cart.find(x => x.id === cartElement.id).count === 0) {
      cart.splice(cart.indexOf(cartElement), 1);
      this.alertify.success(cartElement.product.name + ' successfully removed from cart.');
    }

    this.setCart(cart);
  }
}
