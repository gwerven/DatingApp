import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  // Bring in the api URL from environment variables
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // Returns an array of all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  // Returns the user object with the specified ID
  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }
}
