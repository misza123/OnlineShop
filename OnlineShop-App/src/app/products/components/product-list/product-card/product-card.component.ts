import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/products/product';
import { AuthService } from 'src/app/_services/Auth/Auth.service';
import { CartService } from 'src/app/cart/cart.service';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() product: Product;
  constructor(private authService: AuthService, private cartService: CartService) { }

  ngOnInit() {
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  addToCart() {
    // TODO resolve counting
    this.cartService.addToCart(this.product);
  }
}
