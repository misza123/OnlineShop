import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Product } from '../product';
import { ProductService } from 'src/app/_services/Products/Product.service';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ProductDetailsResolver implements Resolve<Product> {

    constructor(private productService: ProductService,
        private router: Router,
        private alertify: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<Product> {
        return this.productService.getProduct(route.params.id).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/products']);
                return of(null);
            })
        );
    }
}