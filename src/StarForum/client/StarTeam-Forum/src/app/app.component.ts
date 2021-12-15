/// <reference path="../../node_modules/@types/gapi/index.d.ts" />
/// <reference path="../../node_modules/@types/gapi.auth2/index.d.ts" />
import { Component, OnInit } from '@angular/core';
import { AuthApiService } from './services/auth.service';
import { GoogleAuthDto } from './types/authentication/GoogleAuthDto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'StarTeam-Forum';
  authInstance: gapi.auth2.GoogleAuth | undefined;
  gapiSetup: boolean | undefined;
  user: gapi.auth2.GoogleUser | undefined;
  errorMsg: any;

  constructor(private authService: AuthApiService) {}

  async initGoogleAuth(): Promise<void> {
    //  Create a new Promise where the resolve
    // function is the callback passed to gapi.load
    const pload = new Promise((resolve) => {
      gapi.load('auth2', resolve);
    });

    // When the first promise resolves, it means we have gapi
    // loaded and that we can call gapi.init
    return pload.then(async () => {
      await gapi.auth2
        .init({
          client_id:
            'client_id',
        })
        .then((auth: gapi.auth2.GoogleAuth) => {
          this.gapiSetup = true;
          this.authInstance = auth;
        });
    });
  }

  async authenticate(): Promise<gapi.auth2.GoogleUser> {
    // Initialize gapi if not done yet
    if (!this.gapiSetup) {
      await this.initGoogleAuth();
    }

    // Resolve or reject signin Promise
    return new Promise(async () => {
      await this.authInstance?.signIn().then(
        (user: gapi.auth2.GoogleUser) => {
          this.user = user;
          const externalAuth: GoogleAuthDto = {
            idToken: user.getAuthResponse().id_token,
          };
          this.validateExternalAuth(externalAuth);
        },
        (error: any) => (this.errorMsg = error)
      );
    });
  }

  private validateExternalAuth(externalAuth: GoogleAuthDto) {
    var that = this;
    this.authService
      .externalLogin(externalAuth)
      .subscribe({
        next(res) {
          localStorage.setItem('token', res.token);
        },
        error(msg) {
          that.errorMsg = msg;
          //that.authService.signOutExternal();
        }
      });
  }

  async checkIfUserAuthenticated(): Promise<boolean> {
    // Initialize gapi if not done yet
    if (!this.gapiSetup) {
      await this.initGoogleAuth();
    }

    return this.authInstance ? this.authInstance.isSignedIn.get() : false;
  }

  async ngOnInit() {
    if (await this.checkIfUserAuthenticated()) {
      this.user = this.authInstance?.currentUser.get();
    }
  }
}
