import { Component, OnInit } from '@angular/core';
import { Product } from '../../product';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/Auth/Auth.service';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { CartService } from 'src/app/cart/cart.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private route: ActivatedRoute,
              private authService: AuthService,
              private cartService: CartService) { }

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
    for (const photo of this.product.photos) {
      imageUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url,
        description: photo.description
      });
    }
    return imageUrls;
  }

  addToCart() {
    // TODO resolve counting
    this.cartService.addToCart(this.product);
  }
}
