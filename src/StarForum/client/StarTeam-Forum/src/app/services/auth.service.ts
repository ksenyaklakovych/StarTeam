import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Config } from '../types/Config';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { GoogleAuthDto } from '../types/authentication/GoogleAuthDto';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: 'my-auth-token',
  }),
};

@Injectable()
export class ConfigService {
  constructor(private http: HttpClient) {}

  configUrl = 'assets/config.json';

  getConfig() {
    return this.http.get<Config>(this.configUrl);
  }
}

@Injectable()
export class AuthApiService {
  config!: Config;

  constructor(private http: HttpClient, private configService: ConfigService) {
    configService.getConfig().subscribe((responce) => {
      this.config = responce;
    });
  }

  configUrl = 'assets/config.json';

  getConfig() {
    return this.http.get<Config>(this.configUrl);
  }

  externalLogin(loginModel: GoogleAuthDto): Observable<any> {
    return this.http
      .post<any>(this.config.externalLoginUrl, loginModel, httpOptions)
      .pipe(catchError(this.handleError));
  }

  signOutExternal(): Observable<any> {
    return this.http
      .get(this.config.externalSignOutUrl, httpOptions)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    // Return an observable with a user-facing error message.
    return throwError('Something bad happened; please try again later.');
  }
}
