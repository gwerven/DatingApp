import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  // Return true if the user is logged in
  canActivate(): boolean {
    if(this.authService.loggedIn()) {
      return true;
    }

    /* If the user is not logged in, give an error message,
    redirect them to the home page, and return false */
    this.alertify.error('Unauthorized. Please login.');
    this.router.navigate(['/home']);
    return false;
  }
}
