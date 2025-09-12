import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Createtransaction } from './createtransaction';

describe('Createtransaction', () => {
  let component: Createtransaction;
  let fixture: ComponentFixture<Createtransaction>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Createtransaction]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Createtransaction);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
