import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  // Create instance of JWT helper
  jwtHelper = new JwtHelperService();

  // Implement our auth service
  constructor(private authService: AuthService) {}

  // Implement our onInit service
  ngOnInit() {
    const token = localStorage.getItem('token');
    // If there is a token in local storage, then decode it and store it in authservice
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}
