import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

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
  // Make authService public to avoid error because everything in JS is public
  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  // Login method
  login() {
    // If next is reached, this means our request was successful
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // After the user logs in, redirect them to the members page
      this.router.navigate(['/members']);
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
    // After the user logs out, redirect them to the home page
    this.router.navigate(['/home']);
  }

}
