import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/authorization/login/login.component';
import { QuestionsGridComponent } from './modules/questions/questions-grid/questions-grid.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'home', component: QuestionsGridComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
