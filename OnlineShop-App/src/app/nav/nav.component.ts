import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth/Auth.service';
import { AlertifyService } from '../_services/Alertify/AlertifyService.service';
import { Router } from '@angular/router';
import { CartService } from '../cart/cart.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  productsInCartCount: number;

  constructor(public authService: AuthService,
              private alertify: AlertifyService,
              private router: Router,
              private cartService: CartService) { }

  ngOnInit() {
    this.cartService.actualElementsCount.subscribe(count => { this.productsInCartCount = count; });
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in successfully');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/members']);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Logged out');
    this.router.navigate(['/home']);
  }
}
