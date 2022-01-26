import { Component, OnInit } from '@angular/core';
import { QuestionsService, Tag } from '../questions.service';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss']
})
export class TagsComponent implements OnInit {
  searchPhrase: string = '';
  tags: Tag[];
  loading: boolean;

  constructor(private questionsService: QuestionsService) { }

  ngOnInit(): void {
  }


  filterChanged(input: string) {
    this.loading = true;
    
    this.questionsService.filterTags(input)
      .subscribe((result) => {
        this.tags = result;
        this.loading = false;
      });
  }
}
