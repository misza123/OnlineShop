import { Component, OnInit } from '@angular/core';
import { Order } from '../Order';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { OrderService } from 'src/app/_services/Orders/Order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: Order[];
  constructor(private orderService: OrderService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders(){
    this.orderService.getOrders().subscribe(
      (orders: Order[]) => {
        this.orders = orders;
      },
      error => {
        this.alertify.error(error);
      });
  }
}
