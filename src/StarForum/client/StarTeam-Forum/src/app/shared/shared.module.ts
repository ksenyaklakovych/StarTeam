import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './spinner/spinner.component';
import { SpinnerContentComponent } from './spinner-content/spinner-content.component';

@NgModule({
  declarations: [
    SpinnerComponent,
    SpinnerContentComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    SpinnerComponent,
    SpinnerContentComponent
  ]
})
export class SharedModule { }
