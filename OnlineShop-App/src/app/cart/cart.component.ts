import { Component, OnInit } from '@angular/core';
import { Product } from '../products/product';

@Component({
  selector: 'app-basket',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  products: Product[];
  
  constructor() { }

  ngOnInit() {
  }

}
