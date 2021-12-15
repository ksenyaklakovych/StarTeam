import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Config } from '../types/Config';
import { catchError, Observable, Subject, throwError } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { GoogleAuthDto } from '../types/authentication/GoogleAuthDto';
import { ConfigService } from './config.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: `Bearer ${window.localStorage.getItem('token')}`,
  }),
};

@Injectable()
export class AuthApiService {
  config!: Config;
  private _authChangeSub = new Subject<boolean>();
  public authChanged = this._authChangeSub.asObservable();

  constructor(private http: HttpClient, private configService: ConfigService) {
    configService.getConfig().subscribe((responce) => {
      this.config = responce;
    });

    this._authChangeSub.next(!!window.localStorage.getItem('token'));
  }

  configUrl = 'assets/config.json';

  getConfig() {
    return this.http.get<Config>(this.configUrl);
  }

  externalLogin(loginModel: GoogleAuthDto): Observable<any> {
    console.log(loginModel);
    return this.http
      .post<any>(
        `${this.config.baseURL}${this.config.externalLoginUrl}`,
        loginModel,
        httpOptions
      )
      .pipe(catchError(this.handleError));
  }

  signOutExternal() {
    window.localStorage.removeItem('token');
    this.sendAuthStateChangeNotification(false);
  }

  sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  };

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
