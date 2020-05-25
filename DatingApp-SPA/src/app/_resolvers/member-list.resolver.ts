import { Injectable } from '@angular/core';
import { User } from '../_models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
// Create a resolver so that we don't have to use the ? operator when referencing data
export class MemberListResolver implements Resolve<User[]> {
  constructor(
    private userService: UserService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
    return this.userService.getUsers().pipe(
      catchError((error) => {
        // Notify the user of the error getting the member list
        this.alertify.error('Problem retrieving data');
        // Redirect user back to home page in case of an error in getting the list of members
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
