import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../user-profile';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  userProfile: UserProfile;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {this.userProfile = data.userProfile; });
  }

  updateUserProfile() {
  }

}
