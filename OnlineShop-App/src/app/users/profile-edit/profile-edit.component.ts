import { Component, OnInit, ViewChild } from '@angular/core';
import { UserProfile } from '../user-profile';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/Alertify/AlertifyService.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  userProfile: UserProfile;

  constructor(private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {this.userProfile = data.userProfile; });
  }

  updateUserProfile() {
    this.alertify.success('Profile updated successfully');
    // TODO: go to details
  }

}
