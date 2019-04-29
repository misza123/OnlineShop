import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Photo } from './Photo';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  baseUrl = environment.apiURL + 'auth/';

  constructor(private http: HttpClient) { }

  updatePhoto(productId: number, photo: Photo) {
    return this.http.put(this.baseUrl + 'product/' + productId + '/photo',  photo );
  }
}
