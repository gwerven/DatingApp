import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

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
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  // Login method
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    });
  }

  // We want to do some things, like show the user a welcome message, only if they are logged in
  loggedIn() {
    const token = localStorage.getItem('token');
    // If there's something in this token, it will return true, if token is empty, return false
    return !!token;
  }

  logout() {
    // Delete token if user manually logs out
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
