import { Component, Input, OnInit } from '@angular/core';
import { Question } from '../questions.service';

@Component({
  selector: 'question-item',
  templateUrl: './question-item.component.html',
  styleUrls: ['./question-item.component.scss']
})
export class QuestionItemComponent implements OnInit {
  @Input()
  question: Question | undefined;

  constructor() { 
  }

  ngOnInit(): void {
  }

}
