import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddQuestionComponent } from '../add-question/add-question.component';

@Component({
    selector: 'questions-grid',
    templateUrl: './questions-grid.component.html',
    styleUrls: ['./questions-grid.component.scss']
})
export class QuestionsGridComponent {
    constructor(private modalService: NgbModal, private router: Router) {
        if(this.router.url == '/questions/create') 
        {
          this.openCreateModal();
        }
    }

    ngOnInit() {
    }

    openCreateModal() {
        const modalRef = this.modalService.open(AddQuestionComponent);
    }
}