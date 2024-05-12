import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetaljiProizvodaComponent } from './detalji-proizvoda.component';

describe('DetaljiProizvodaComponent', () => {
  let component: DetaljiProizvodaComponent;
  let fixture: ComponentFixture<DetaljiProizvodaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetaljiProizvodaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetaljiProizvodaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
