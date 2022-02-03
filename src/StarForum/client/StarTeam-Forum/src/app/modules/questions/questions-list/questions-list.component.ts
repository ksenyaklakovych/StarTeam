import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { IQuestionRequest, Question, QuestionsService } from '../questions.service';

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.scss']
})
export class QuestionsListComponent implements OnInit {
  questions: Question[];
  orderOptions = ['Date', 'Title'];
  orderByOption: string;
  
  loading: boolean = true;

  @Output()
  sortChanged: EventEmitter<string> = new EventEmitter();

  constructor(private questionsService: QuestionsService, private route: Router) {
   }

  ngOnInit(): void {
    if (this.route.url == '/questions/create') {
      this.questionsService.openCreateModal$.next();
    }

    this.queryQuestions();
  }

  queryQuestions(orderby?: string, tags?: string) {
    const request: IQuestionRequest = {
        orderOption: orderby != 'undefined' ? orderby : null,
        tags: tags != 'undefined' ? tags : null
    };
    this.questionsService.getQuestions(request)
        .subscribe((data: any) => {
            this.questions = data;

            this.loading = false;
        });
  }

  onSortingChange(orderByValue: string) {
    this.queryQuestions(orderByValue);
  }
}
