import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { QuestionsService } from '../questions.service';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.scss']
})
export class AddQuestionComponent implements OnInit {
  loading: boolean;

  constructor(public activeModal: NgbActiveModal, 
    private questionService: QuestionsService,
    private router: Router) { }

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
    this.loading = true;
    const tags = this.questionModel.tags.map((t: any) => typeof (t) == 'object' ? t.value : t);
    const request = { ...this.questionModel, tags: tags };

    this.questionService.addQuestion(request).subscribe((result: any) => {
      this.loading = false;
      this.router.navigate([`/questions/${result.id}`]);
      this.activeModal.close();
    });
  }

}

interface QuestionRequestModel {
  title: string;
  description: string;
  tags: string[];
}
