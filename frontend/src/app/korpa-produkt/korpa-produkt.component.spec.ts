import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorpaProduktComponent } from './korpa-produkt.component';

describe('KorpaProduktComponent', () => {
  let component: KorpaProduktComponent;
  let fixture: ComponentFixture<KorpaProduktComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorpaProduktComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KorpaProduktComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
