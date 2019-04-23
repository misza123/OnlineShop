import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../product';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product: Product;
  // TODO: get product from api by id.

  constructor() { }
  ngOnInit() {
  }

}
