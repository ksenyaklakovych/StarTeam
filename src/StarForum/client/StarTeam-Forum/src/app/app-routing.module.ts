import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/authorization/login/login.component';
import { FavouritesComponent } from './modules/questions/favourites/favourites.component';
import { QuestionPageComponent } from './modules/questions/question-page/question-page.component';
import { QuestionsGridComponent } from './modules/questions/questions-grid/questions-grid.component';
import { QuestionsListComponent } from './modules/questions/questions-list/questions-list.component';
import { TagPageComponent } from './modules/questions/tag-page/tag-page.component';
import { TagsComponent } from './modules/questions/tags/tags.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: 'questions', component: QuestionsGridComponent, children: [
      { path: '', component: QuestionsListComponent },
      { path: 'tags', component: TagsComponent },
      { path: 'favourites', component: FavouritesComponent },
      { path: ':id', component: QuestionPageComponent },
      { path: 'tagged', children: [
        { path: ':name', component: TagPageComponent }
      ]}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
