import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddQuestionComponent } from '../add-question/add-question.component';
import { QuestionsService } from '../questions.service';

@Component({
    selector: 'questions-grid',
    templateUrl: './questions-grid.component.html',
    styleUrls: ['./questions-grid.component.scss']
})
export class QuestionsGridComponent {
    constructor(private modalService: NgbModal, private questionService: QuestionsService) {
    }

    ngOnInit() {
        this.questionService.openCreateModal$.subscribe(() => {
            this.openCreateModal();
        });
    }

    openCreateModal() {
        const modalRef = this.modalService.open(AddQuestionComponent);
    }
}