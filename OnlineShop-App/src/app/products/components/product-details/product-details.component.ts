import { Component, OnInit } from '@angular/core';
import { Product } from '../../product';
import { ProductService } from 'src/app/_services/Products/Product.service';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/Auth/Auth.service';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private productService: ProductService,
              private alertify: AlertifyService,
              private route: ActivatedRoute,
              private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {this.product = data.product; });

    this.galleryOptions = [{
      width: '300px',
      height: '300px',
      thumbnailsColumns: 4,
      imageAnimation: NgxGalleryAnimation.Slide,
      previewCloseOnClick: true,
      previewCloseOnEsc: true,
      previewKeyboardNavigation: true,
      previewAutoPlay: true,
      previewAutoPlayPauseOnHover: true,
    }];

    this.galleryImages = this.getImages();
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  getImages() {
    const imageUrls = [];
    for (let i = 0; i < this.product.photos.length; i++) {
      imageUrls.push({
        small: this.product.photos[i].url,
        medium: this.product.photos[i].url,
        big: this.product.photos[i].url,
        description: this.product.photos[i].description
      });
    }
    return imageUrls;
  }
}
