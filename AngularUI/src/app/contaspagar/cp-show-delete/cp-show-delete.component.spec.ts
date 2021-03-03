import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CpShowDeleteComponent } from './cp-show-delete.component';

describe('CpShowDeleteComponent', () => {
  let component: CpShowDeleteComponent;
  let fixture: ComponentFixture<CpShowDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CpShowDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CpShowDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
