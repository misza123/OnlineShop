import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../user-profile';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.css']
})
export class ProfileDetailsComponent implements OnInit {
  userProfile: UserProfile;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {this.userProfile = data.userProfile; });
  }

}
