import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CpAddEditComponent } from './cp-add-edit.component';

describe('CpAddEditComponent', () => {
  let component: CpAddEditComponent;
  let fixture: ComponentFixture<CpAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CpAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CpAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
