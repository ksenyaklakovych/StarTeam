import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
    ])
  ],
  exports: [
    LoginComponent
  ]
})
export class AuthorizationModule {
}