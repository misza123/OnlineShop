import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from './user-profile';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiURL + 'auth/';

  constructor(private http: HttpClient) { }

  getUser(id: number): Observable<UserProfile> {
    return this.http.get<UserProfile>(this.baseUrl + 'user' + id);
  }

}
