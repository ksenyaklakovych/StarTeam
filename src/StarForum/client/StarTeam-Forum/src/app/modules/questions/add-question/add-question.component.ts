import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { QuestionsService } from '../questions.service';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.scss']
})
export class AddQuestionComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal, private questionService: QuestionsService) { }

  questionModel: QuestionRequestModel = {
    title: null,
    description: null,
    tags: ['programming']
  }

  questionForm: FormGroup = new FormGroup({
    "title": new FormControl(null, [Validators.required]),
    "description": new FormControl(null, [Validators.required]),
    "tags": new FormControl(null)
  });

  ngOnInit(): void {
  }

  create() {
    const request = { ...this.questionModel };

    this.questionService.addQuestion(request).subscribe((result) => {
      this.activeModal.close();

      // todo: navigate to question
    });
  }

}

interface QuestionRequestModel {
  title: string;
  description: string;
  tags: string[];
}
