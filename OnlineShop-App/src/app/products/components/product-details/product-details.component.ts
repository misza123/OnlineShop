import { Component, OnInit } from '@angular/core';
import { Product } from '../../product';
import { ProductService } from 'src/app/_services/Products/Product.service';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;

  constructor(private productService: ProductService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {this.product = data.product;});
  }
}
