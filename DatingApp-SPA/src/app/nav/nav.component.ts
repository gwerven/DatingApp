import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  // Create model object of type any and set it to an empty object
  // Stores username and password from form
  model: any = {};

  // Inject authservice into constructor
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  // Login method
  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  // Return true if user is logged in, false otherwise
  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    // Delete token if user manually logs out
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }

}
