import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContaspagasComponent } from './contaspagas.component';

describe('ContaspagasComponent', () => {
  let component: ContaspagasComponent;
  let fixture: ComponentFixture<ContaspagasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContaspagasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaspagasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
