import { Component } from '@angular/core';
// import {GoogleLoginProvider, SocialAuthService} from 'angularx-social-login';
import { Router } from '@angular/router';
import { Question, QuestionsService } from '../questions.service';

@Component({
    selector: 'questions-grid',
    templateUrl: './questions-grid.component.html',
    styleUrls: ['./questions-grid.component.scss']
})
export class QuestionsGridComponent {
    questions: Question[] | undefined;

    constructor(private router: Router,
        private questionsService: QuestionsService) {
    }

    ngOnInit() {
        this.questionsService.getQuestions()
        .subscribe((data: any) => { 
            this.questions = data; 
        });
    }
}