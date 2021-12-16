import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { AuthApiService } from 'src/app/services/auth.service';
import { ConfigService } from 'src/app/services/config.service';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot([{ path: 'login', component: LoginComponent }]),
  ],
  exports: [LoginComponent],
  providers: [AuthApiService, ConfigService],
})
export class AuthorizationModule {}
