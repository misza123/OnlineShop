import { Component, OnInit } from '@angular/core';
import { Product } from '../../product';
import { ProductService } from 'src/app/_services/Products/Product.service';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];
  constructor(private productService: ProductService,
              private alertify: AlertifyService,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe(data => {this.products = data.products;});
  }
}
