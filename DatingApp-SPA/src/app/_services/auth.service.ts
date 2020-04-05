import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/auth/';
  jwtHelper = new JwtHelperService();
  // Property to store decoded token intside our auth service
  decodedToken: any;

  constructor(private http: HttpClient) {}

  // Login method in Angular service
  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          // Store the decoded token
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          console.log(this.decodedToken);
        }
      })
    );
  }

  // Model is just an object used to store username and password
  register(model: any) {
    // Post method returns an observable
    return this.http.post(this.baseUrl + 'register', model);
  }

  // Returns false if token is expired, true if token is not expired
  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
