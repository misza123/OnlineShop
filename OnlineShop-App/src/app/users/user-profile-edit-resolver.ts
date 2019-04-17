import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserProfile } from './user-profile';
import { UserService } from './user.service';
import { AuthService } from '../_services/Auth/Auth.service';

@Injectable()
export class UserProfileEditResolver implements Resolve<UserProfile> {

    constructor(private userService: UserService,
                private router: Router,
                private alertify: AlertifyService,
                private authService: AuthService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<UserProfile> {
        return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving your data.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
