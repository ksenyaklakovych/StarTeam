import {Component} from '@angular/core';
// import {GoogleLoginProvider, SocialAuthService} from 'angularx-social-login';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private router: Router) {
  }

  loginWithGoogle(): void {
      alert('login');
    // this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID)
    //   .then(() => this.router.navigate(['mainpage']));
  }
}