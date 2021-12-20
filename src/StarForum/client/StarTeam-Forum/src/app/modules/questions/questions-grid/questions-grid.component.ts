import { Component } from '@angular/core';
// import {GoogleLoginProvider, SocialAuthService} from 'angularx-social-login';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddQuestionComponent } from '../add-question/add-question.component';
import { Question, QuestionsService } from '../questions.service';

@Component({
    selector: 'questions-grid',
    templateUrl: './questions-grid.component.html',
    styleUrls: ['./questions-grid.component.scss']
})
export class QuestionsGridComponent {
    questions: Question[] | undefined;
    loading: boolean = true;

    constructor(private router: Router,
        private questionsService: QuestionsService,
        private modalService: NgbModal) {
    }

    ngOnInit() {
        this.questionsService.getQuestions()
            .subscribe((data: any) => {
                this.questions = data;

                this.loading = false;
            });
    }

    openCreateModal() {
        const modalRef = this.modalService.open(AddQuestionComponent);
        modalRef.componentInstance.name = 'World';
    }
}