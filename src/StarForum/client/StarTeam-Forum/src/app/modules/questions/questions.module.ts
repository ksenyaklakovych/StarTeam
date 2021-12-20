import {NgModule} from '@angular/core';
import { QuestionsGridComponent } from './questions-grid/questions-grid.component';
import { BrowserModule } from '@angular/platform-browser'
import { QuestionItemComponent } from './question-item/question-item.component';
import { QuestionsService } from './questions.service';
import { AddQuestionComponent } from './add-question/add-question.component';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    QuestionsGridComponent,
    QuestionItemComponent,
    AddQuestionComponent
  ],
  imports: [
    BrowserModule,
    TagInputModule, 
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    QuestionsService
  ]
})
export class QuestionsModule {
}
