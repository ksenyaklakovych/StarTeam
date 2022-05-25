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
import { QuestionsService } from '../questions.service';
import { AddQuestionComponent } from './add-question.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';

describe('AddQuestionComponent', () => {
    let component: AddQuestionComponent;
    let fixture: ComponentFixture<AddQuestionComponent>;

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
            declarations: [AddQuestionComponent],
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(AddQuestionComponent);
        component = fixture.componentInstance;

        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('set loading', () => {
        component.loading = true;
        fixture.detectChanges();
        expect(component).toBeTruthy();
    });

    it('should call addQuestion', () => {
        const createSpy = spyOn(component['questionService'], 'addQuestion').and.returnValue(of())
        component.create();

        expect(createSpy).toHaveBeenCalledTimes(1);
    });
});