import { Component, Input, OnInit } from '@angular/core';
import { Question, QuestionsService } from '../questions.service';

@Component({
  selector: 'question-item',
  templateUrl: './question-item.component.html',
  styleUrls: ['./question-item.component.scss']
})
export class QuestionItemComponent implements OnInit {
  @Input()
  question: Question;

  isFavourite: boolean;

  constructor(private questionsService: QuestionsService) { 
  }

  ngOnInit(): void {
    this.questionsService.isQuestionFavourite(this.question.id).subscribe((result) => {
      this.isFavourite = result;
    });
  }

  favouriteClicked() {
    this.questionsService.changeIsFavourite(!this.isFavourite, this.question.id).subscribe((result) => {
      this.isFavourite = !this.isFavourite;

      this.questionsService.favouriteChanged$.next(this.isFavourite);
    });
  }
}
