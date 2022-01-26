import {NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontWeightBoldDirective } from './font-weight-bold/font-weight-bold.directive'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    FontWeightBoldDirective
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    FontWeightBoldDirective
  ],
  providers: [
  ]
})
export class DirectivesModule {
}
