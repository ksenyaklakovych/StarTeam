import { Component, OnInit } from '@angular/core';
import { Question, QuestionsService } from '../questions.service';

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['./favourites.component.scss']
})
export class FavouritesComponent implements OnInit {
  questions: Question[];
  
  constructor(private questionsService: QuestionsService) { }

  ngOnInit(): void {
    this.loadQuestions();
    this.questionsService.favouriteChanged$.subscribe(() => {
      this.loadQuestions();
    });
  }

  loadQuestions() {
    this.questionsService.getFavourites()
    .subscribe((data: any) => {
        this.questions = data;

        //this.loading = false;
    });
  }

}
