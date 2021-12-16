import {NgModule} from '@angular/core';
import { QuestionsGridComponent } from './questions-grid/questions-grid.component';
import { BrowserModule } from '@angular/platform-browser'
import { QuestionItemComponent } from './question-item/question-item.component';
import { QuestionsService } from './questions.service';

@NgModule({
  declarations: [
    QuestionsGridComponent,
    QuestionItemComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [
    QuestionsService
  ]
})
export class QuestionsModule {
}
