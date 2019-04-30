import { Component, OnInit } from '@angular/core';
import { CartElement } from './cart-element';
import { CartService } from './cart.service';

@Component({
  selector: 'app-basket',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartElements: CartElement[];

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.cartElements = this.cartService.getCart();
  }

  removeProduct(cartElement: CartElement) {
    this.cartService.removeProduct(cartElement);
    this.cartElements = this.cartService.getCart();
  }

  increaseCount(cartElement: CartElement) {
    this.cartService.setCount(cartElement, cartElement.count + 1);
    this.cartElements = this.cartService.getCart();
  }

  decreaseCount(cartElement: CartElement) {
    this.cartService.setCount(cartElement, cartElement.count - 1);
    this.cartElements = this.cartService.getCart();
  }

  clearCart() {
    this.cartService.clear();
    this.cartElements = this.cartService.getCart();
  }

  proceed() {
    // TODO implement me
  }
}
