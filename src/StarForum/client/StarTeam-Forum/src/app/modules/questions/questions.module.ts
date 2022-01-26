import {NgModule} from '@angular/core';
import { QuestionsGridComponent } from './questions-grid/questions-grid.component';
import { BrowserModule } from '@angular/platform-browser'
import { QuestionItemComponent } from './question-item/question-item.component';
import { QuestionsService } from './questions.service';
import { AddQuestionComponent } from './add-question/add-question.component';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DirectivesModule } from 'src/app/directives/directives.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { QuestionsListComponent } from './questions-list/questions-list.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { QuestionPageComponent } from './question-page/question-page.component';
import { TagsComponent } from './tags/tags.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TagPageComponent } from './tag-page/tag-page.component';

@NgModule({
  declarations: [
    QuestionsGridComponent,
    QuestionItemComponent,
    QuestionsListComponent,
    AddQuestionComponent,
    QuestionPageComponent,
    TagsComponent,
    TagPageComponent
  ],
  imports: [
    NgSelectModule,
    AppRoutingModule,
    DirectivesModule,
    BrowserModule,
    TagInputModule, 
    SharedModule,
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
