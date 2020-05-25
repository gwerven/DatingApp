import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
})
// Get detailed user from API
export class MemberDetailComponent implements OnInit {
  user: User;

  // Inject the user service as a parameter
  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // Bind the data to the component at the time it is created/initialized
    // Get the data from the route itself using a route resolver
    this.route.data.subscribe((data) => {
      this.user = data['user'];
    });
  }

  // No longer necessary due to the route resolver
  /*loadUser() {
    // id string will be converted to a number and passed to the getUser method
    this.userService.getUser(+this.route.snapshot.params['id']).subscribe((user: User) => {
      this.user = user;
    }, error => {
      // If an error is encountered whilr trying to access the user's detailed info, display it
      this.alertify.error(error);
    });
  }*/
}
