import { Component, OnInit } from '@angular/core';
import { Product } from '../products/product';
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

}
