import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Question, QuestionsService } from '../questions.service';

@Component({
  selector: 'app-question-page',
  templateUrl: './question-page.component.html',
  styleUrls: ['./question-page.component.scss']
})
export class QuestionPageComponent implements OnInit {
  question: Question;

  constructor(private route: ActivatedRoute, private questionsService: QuestionsService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      const id = +params['id'];

      this.questionsService.getQuestionById(id).subscribe((result) => {
        this.question = result;
      })
    })
  }

}
