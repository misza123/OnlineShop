import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../product';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/_services/Products/Product.service';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product: Product;
  mainPhotoUrl: string;
  // TODO: get product from api by id.

  constructor(private alertify: AlertifyService,
              private route: ActivatedRoute,
              private router: Router,
              private productService: ProductService) { }

  ngOnInit() {
    this.route.data.subscribe(data => { this.product = data.product; });
    this.setMainPhoto();
  }

  updateProduct() {
    this.productService.updateProduct(this.product)
      .subscribe(next => {
        this.alertify.success('Profile updated successfully');
        this.router.navigate(['/profile']);
      },
        error => { this.alertify.error(error); });
  }

  setMainPhoto() {
    this.mainPhotoUrl = this.product.photos.find(x => x.isMain).url;
  }
}
