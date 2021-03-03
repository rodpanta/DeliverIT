import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CpPaymentComponent } from './cp-payment.component';

describe('CpPaymentComponent', () => {
  let component: CpPaymentComponent;
  let fixture: ComponentFixture<CpPaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CpPaymentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CpPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
