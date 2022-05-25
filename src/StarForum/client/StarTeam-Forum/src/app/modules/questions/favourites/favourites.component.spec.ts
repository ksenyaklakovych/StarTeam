import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { TagInputModule } from 'ngx-chips';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { DirectivesModule } from 'src/app/directives/directives.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { Question, QuestionsService } from '../questions.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';
import { FavouritesComponent } from './favourites.component';

describe('FavouritesComponent', () => {
    let component: FavouritesComponent;
    let fixture: ComponentFixture<FavouritesComponent>;

    beforeEach(waitForAsync(() => {
        TestBed.configureTestingModule({
            imports: [
                NgSelectModule,
                AppRoutingModule,
                DirectivesModule,
                BrowserModule,
                TagInputModule,
                SharedModule,
                BrowserAnimationsModule,
                FormsModule,
                ReactiveFormsModule,
                HttpClientTestingModule 
            ],
            providers: [
                QuestionsService,
                NgbActiveModal
            ],
            declarations: [FavouritesComponent],
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(FavouritesComponent);
        component = fixture.componentInstance;

        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should have initial state', () => {
      const questionsArray: Question[] = [];
      expect(component['questions']).toEqual(questionsArray);
    });

    it('should call getFavourites', () => {
        const createSpy = spyOn(component['questionsService'], 'getFavourites').and.returnValue(of())
        component.loadQuestions();

        expect(createSpy).toHaveBeenCalledTimes(1);
    });
});