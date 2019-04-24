import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from 'src/app/products/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiURL + 'product/';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + id);
  }

  updateProduct(product: Product) {
    // TODO: implementation at web api
    return this.http.put(this.baseUrl, product);
  }
}
