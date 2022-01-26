import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner-content',
  templateUrl: './spinner-content.component.html',
  styleUrls: ['./spinner-content.component.scss']
})
export class SpinnerContentComponent implements OnInit {
  @Input() showSpinner: boolean;
  
  constructor() { }

  ngOnInit(): void {
  }

}
