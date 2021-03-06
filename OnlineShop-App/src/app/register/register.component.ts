import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/Auth/Auth.service';
import { AlertifyService } from '../_services/Alertify/AlertifyService.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() { }

  register() {
    this.authService.register(this.model).subscribe(
      () => { this.alertify.success('Registration successfull'); },
      error => { this.alertify.error(error); }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
