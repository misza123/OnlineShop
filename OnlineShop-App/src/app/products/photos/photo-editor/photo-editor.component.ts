import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Photo } from '../Photo';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { PhotoService } from '../photo.service';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css']
})

export class PhotoEditorComponent implements OnInit {
  @Input() photos: Photo[];
  @Input() productId: number;
  @Output() getProductMainPhotoChange = new EventEmitter<string>();
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiURL + 'auth/';
  currentMain: Photo;

  constructor(private photoService: PhotoService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.initializeUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'product/' + this.productId + '/photo',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => { file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const res: Photo = JSON.parse(response);
        const photo = {
          id: res.id,
          url: res.url,
          description: res.description,
          isMain: res.isMain
        };

        this.photos.push(photo);
      }
    };
  }

  setAsMain(photo: Photo) {
    this.photoService.updatePhoto(this.productId, { id: photo.id, isMain: true, description: photo.description, url: photo.url }).subscribe(
      () => {
        this.currentMain = this.photos.filter(p => p.isMain === true)[0];
        this.currentMain.isMain = false;
        photo.isMain = true;
        this.getProductMainPhotoChange.emit(photo.url);
        this.alertify.success('Successfully set photo to main.');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
