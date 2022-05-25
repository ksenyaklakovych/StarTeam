import { CommonModule } from '@angular/common';
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { SpinnerContentComponent } from '../spinner-content/spinner-content.component';
import { SpinnerComponent } from './spinner.component';

describe('SpinnerComponent', () => {
  let component: SpinnerComponent;
  let fixture: ComponentFixture<SpinnerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        CommonModule
      ],
      declarations: [SpinnerComponent, SpinnerContentComponent],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpinnerComponent);
    component = fixture.componentInstance;

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('set message', () => {
    component.message = 'Loading';
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});