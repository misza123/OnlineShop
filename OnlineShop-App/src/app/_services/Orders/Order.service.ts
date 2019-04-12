import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from 'src/app/orders/components/Order';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiURL;

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.baseUrl + 'order', httpOptions);
  }

  getOrder(id: number): Observable<Order> {
    return this.http.get<Order>(this.baseUrl + 'order/' + id, httpOptions);
  }
}
