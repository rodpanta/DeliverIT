import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContaspagarComponent } from './contaspagar.component';

describe('ContaspagarComponent', () => {
  let component: ContaspagarComponent;
  let fixture: ComponentFixture<ContaspagarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContaspagarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaspagarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
