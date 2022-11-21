import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePagoComponent } from './table-pago.component';

describe('TablePagoComponent', () => {
  let component: TablePagoComponent;
  let fixture: ComponentFixture<TablePagoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TablePagoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePagoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
