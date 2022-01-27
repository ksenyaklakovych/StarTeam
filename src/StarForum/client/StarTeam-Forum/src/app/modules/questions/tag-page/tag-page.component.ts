import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Question, QuestionsService } from '../questions.service';

@Component({
  selector: 'app-tag-page',
  templateUrl: './tag-page.component.html',
  styleUrls: ['./tag-page.component.scss']
})
export class TagPageComponent implements OnInit {
  tagName: string;
  questions: Question[];
  
  constructor(private route: ActivatedRoute, private questionsService: QuestionsService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.tagName = params['name'];

      this.questionsService.getQuestionsByTagName(this.tagName).subscribe((result) => {
        this.questions = result;
      })
    });
  }

}
