import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Login } from './login';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private url: string = "http://localhost:5000/api/authentication";

  constructor(private http: HttpClient) { }

  createToken(login: Login) {
    return this.http.post<Login>(this.url, login, httpOptions)
      .pipe(
        map((data: Login) => {
          localStorage.setItem('API_TOKEN', data.token);
        }));

  }

  isAuthenticated(): boolean {
    return localStorage.getItem('API_TOKEN') != undefined;
  }
}
